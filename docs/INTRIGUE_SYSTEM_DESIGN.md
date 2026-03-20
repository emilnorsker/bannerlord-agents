# AI Influence — Intrigue & plot-driven secrets — design notes

**Audience:** engineers working on AIInfluence who need a **rigorous contract** for plots, secrets, hooks, and plot points on top of Mount & Blade II: Bannerlord—**without** treating the language model as the save file.

**Tone:** this document records *intent* and *constraints* agreed in design discussion. It is not a task list for a single PR. Update it when schema names, log prefixes, or slice boundaries change.

**Related today:** `TECHNICAL_GUIDE.en.md` (artifacts, prompts), `NPCContext` / `WorldSecret` / `CheckSecretKnowledge` / `PromptGenerator` (shipping behavior). This doc describes the **target** system and how it relates to that baseline.

---

## Two completion paths (precision, not “the model”)

AIInfluence must **name** which pipeline a request belongs to. They share validators and save rules but differ in **snapshot shape** and **what may be proposed**.

**Campaign intrigue path** — Work driven by **campaign time** and **engine events** (battle resolved, daily tick, entered settlement, peace declared, prisoner moved). Completions (when used) receive a **world-shaped** snapshot: active plot instances, involved kingdoms/clans, recent `DynamicEvent` summaries, policy flags. This path may propose **structured operations** that mutate the intrigue ledger and, through validated adapters, Bannerlord state. It must **not** assume the player is in dialogue.

**NPC dialogue path** — Completions driven by **player↔hero** chat: messenger-style prompts, `NPCContext` for **one** `Hero`, relation/trust/emotion. The snapshot is **interlocutor-shaped**. This path produces **speech** and may propose **dialogue-scoped** JSON (tone, short-term intent); **durable** changes to plots, secrets, or hooks require an **explicit** validated mechanism (e.g. tool / post-step commit), not free text. If the UI shows plot points, secrets, and hooks for this talker, the **same ids** must feed the prompt builder—no shadow state.

In the rest of this document, **proposal** means **structured output** from whichever path is active for that HTTP job. We avoid the vague phrase “the model” where it would blur these two.

---

## What we are actually building

Intrigue is **not** a second simulation of Calradia. It is a **ledger** plus **rules**:

- **Plot instances** — phases, participants, links to world facts (battle uid, prisoner ids).
- **Plot points** — “what the world is saying/doing” (situation beats); propagate like living news; **not** the same object kind as secrets.
- **Secrets (runtime)** — hidden facts **minted** when a plot step or validated effect says so, with `origin` pointing at plot + step; **who knows** is explicit per character.
- **Hooks** — leverage on a **named** target (player or NPC-held), optional `description` text, optional tie to **generated RP items** as evidence; **not** the same row as a secret.
- **Bannerlord** remains the authority for battles, parties, prisoners, relations, wars, settlements. Intrigue **reads** that state and **writes** only through defined effects and existing diplomacy/event machinery where applicable.

The **LLM** may propose parameters for beats (within schema); **only committed operations** change saves.

---

## Baseline today (must not be confused with target)

**Implemented:** `world_secrets.json` catalog → `WorldSecret` → `CheckSecretKnowledge` rolls `knowledgeChance` on first knowledge generation pass → `NPCContext.KnownSecrets` holds **ids** → `PromptGenerator` resolves to `description (access: …)` in the prompt. **Parallel:** `world_info.json` / `KnownInfo`. **Parallel:** `DynamicEvents` on NPC + `DynamicEventsManager` for living events.

**Gap vs target:** Catalog-first secrets with a **per-first-chat roll** are **not** plot-driven. The target system makes **runtime secret records** authoritative for campaign-born facts; catalog entries become **optional** (modpack lore, migration, or fill for static scenarios).

Migration strategy belongs in implementation slices; this doc only states the **contract**: new saves should prefer **origin-linked** secrets; old `KnownSecrets` ids may still resolve through catalog until migrated.

---

## Hard constraints from Bannerlord and the mod

- **Threading:** Anything touching `Campaign`, heroes, parties, or save mutation must follow the same discipline as the rest of the mod: **enqueue** work from async completion handlers; **apply** on the simulation/main thread under a budget (see existing `AIInfluenceBehavior.Tick` patterns). Do not block the map on HTTP.
- **Provenance:** Chat assistant text is **not** proof that a secret exists or spread. Only **logged, validated writes** (or deterministic step execution) count.
- **No silent failure:** Schema rejections, policy rejects, and engine errors surface in logs (and where possible UI); no pretending success.

---

## Proposals, validators, and fallbacks

**Structured proposals** — Whether from the campaign path or a future “proposal” step, the host accepts only **JSON** (or equivalent DTOs) that list **typed operations**: e.g. `emit_plot_point`, `emit_secret`, `advance_plot_phase`, `propagate_knowledge`, `create_hook`, `apply_bannerlord_effect` (enum + ids). **Your code** validates ids exist, phases allow the op, and targets pass policy.

**Immersive content without rigid-only templates:** Templates may stay **narrow**; **parameters** (wording, targets) can be filled by a **procedural generator** from live context, or by an LLM **inside** the schema. On validation failure, fall back to **procedural** or **no-op**—never silently accept invalid JSON.

**Reactions, not only schedules:** Plot steps subscribe to **triggers** (`on_daily`, `on_battle_end`, `on_enter_settlement`, …) with per-trigger `requires` blocks. Same template can behave differently by trigger without hand-authoring infinite branches.

---

## “Observations” and dialogue (plain language)

When the player reads NPC lines, those lines are **not** ground truth for the ledger. Ground truth is: **what was committed** before this message was generated. The prompt builder must inject **plot points**, **KnownSecrets** (runtime + catalog resolution), **hooks**, and **DynamicEvent** slices exactly as stored for that hero. If the UI shows a leverage strip, it reads from the **same** hook/secret records the prompt uses.

---

## Six layers (general program)

1. **Inject a structured snapshot** — Campaign path: plots + world aggregates + recent events. Dialogue path: one hero’s context + player verification state + shared campaign facts needed for consistency.
2. **Route intent** — Decide whether this tick is deterministic step execution, LLM-assisted parameter fill, or dialogue-only.
3. **Validate locally** — Schema, allowlists, engine invariants (valid `Hero.StringId`, kingdom exists, phase machine allows op).
4. **Default safe** — Procedural fallback or skip; log reason.
5. **Execute** — Append save rows (`KnownSecrets`, secret store, plot store, hook store), call Bannerlord APIs on the correct thread, enqueue diplomacy/event updates as today’s code expects.
6. **Render** — Build NPC prompt and UI from **post-commit** state only.

---

## Data model (normative shapes)

*Field names are logical; align with C# / JSON save conventions when implementing.*

**Plot instance (save)** — `id`, `template_id`, `status`, `phase`, `started_campaign_day`, `context` (battle uid, prisoner ids, kingdom ids), `completed_step_ids`, `linked_plot_point_ids`, `linked_secret_ids`, optional `deadline_campaign_day`.

**Plot step (template, mod data)** — `step_id`, `requires` (predicate bundle), `effects[]` with typed ops: `emit_plot_point`, `emit_secret`, `advance_phase`, `spawn_hook`, `apply_relation_delta` (if policy allows), etc. Triggers: which engine events wake this step.

**Secret record (runtime, save)** — `id`, `description`, `access`, `subjects` (heroes/clans), `origin` `{ plot_id, step_id, cause }`, `created_campaign_day`, `status`. **Not** created by chat prose; created by executed effects.

**Plot point (save or parallel to `DynamicEvent`)** — `id`, `plot_id`, `summary`, `importance`, spread/expire fields, links to diplomacy/event pipeline as integrated.

**Hook** — `id`, `owner` (player vs npc), `target_hero_string_id`, **`description`** (what leverage means in play), `basis` `{ kind: secret \| event, id }`, `strength` (`weak` \| `strong`), optional `evidence_item` `{ optional, rp_item_template_id, generated_item_string_id }`, lifecycle fields.

**Per-hero knowledge** — Continue `KnownSecrets: string[]` but ids may point to **runtime** secret store first, then catalog fallback. Optional separate `known_plot_point_ids` if not folded into `DynamicEvents`.

---

## Identity and disambiguation

Use **`Hero.StringId`** and **`Clan.StringId`** / **`Kingdom.StringId`** in all stored references. Partial names are for UI only; the ledger stores **canonical ids**. Ambiguous UI selection must not write ambiguous hooks.

---

## Player-facing interface (contract)

- **Chat UI** (`ChatInterface.xml` / `NpcChatWindowVM`): show **plot points** (situation), **secrets** applicable to this talker, **hooks** owned by player toward this talker, with rumor vs verified distinction per policy. Same source as prompt.
- **MCM:** toggles for strength labeling, verbosity—implementation detail, not core contract.

---

## Risks (accepted for early phases)

- **Migration:** Mixed old catalog ids and new runtime ids until migration tools run.
- **LLM proposals:** Wrong targets if snapshot stale; mitigate with **refresh** before proposal and **hard** validation.
- **Concurrent jobs:** Campaign proposal + dialogue completion in flight need **correlation ids** in logs if both touch the same plot.

---

## Out of scope (explicit deferrals)

- **Full replacement** of `DynamicEventsManager`—integrate with or extend it, do not fork two competing event worlds without a merge plan.
- **Mission-time intrigue** as first-class—campaign-authoritative until a mission layer is specified.
- **Per-secret legal simulation** (trial rules)—not required for ledger v1.

---

## References (internal)

- `TECHNICAL_GUIDE.en.md` — `world_secrets.json`, `world_info.json`, `dynamic_events.json`, NPC save fields.
- `docs/INTRIGUE_SYSTEM_PLAN.md` — short pointer to this document.
- Code: `WorldInfoManager.CheckSecretKnowledge`, `PromptGenerator` secret resolution, `NPCContext`, `AIInfluence.DynamicEvents`.

---

## Implementation slices (ordered)

Later slices assume earlier unless noted. Status is **planning** until issues mark otherwise.

| # | Slice | Outcome |
|---|--------|--------|
| **1** | **Plot instance store** | Serialize `plot_id`, phase, context blob; no LLM. Load/save safe. |
| **2** | **Runtime secret store** | CRUD by id; `origin` metadata; resolve in prompt before catalog. |
| **3** | **Step executor (deterministic)** | `requires` + `emit_plot_point` / `emit_secret` without LLM; unit-testable. |
| **4** | **Triggers** | Wire `on_battle_end`, `on_daily_tick`, `on_enter_settlement` to scheduler. |
| **5** | **Migration bridge** | Map legacy `world_secrets` rolls to optional runtime records or freeze behavior behind MCM. |
| **6** | **Hook store + prompt** | `PlayerHooks`, `description`, strength; chat strip reads same rows. |
| **7** | **Optional evidence item** | Spawn RP item on hook create when basis warrants; bind ids. |
| **8** | **LLM-assisted proposal** | Schema-constrained JSON; validate; commit or fallback; log correlation id. |
| **9** | **`plot_id` on events** | Link `DynamicEvent` (or parallel) to plot instance for diplomacy/UI. |
| **10** | **Dialogue path audit** | Guarantee no silent ledger write from assistant text; tool path only. |
| **11** | **Caps & cleanup** | Max concurrent plots; expiry; save size bounds. |
| **12** | **Manual test spec** | Add `docs/INTRIGUE_TEST_SPEC.md` when slices 1–6 are buildable. |

**Review:** After slice **6**, pause for playtest; **8–10** are where reliability and provenance harden.

---

## Document status

*Design agreement for the intrigue layer. Update when POC results or `TECHNICAL_GUIDE` change assumptions.*
