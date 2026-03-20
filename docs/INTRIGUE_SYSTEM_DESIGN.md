# AI Influence — Intrigue and plot-driven secrets

**Audience:** Engineers extending AIInfluence with plots, runtime secrets, hooks, and plot points on Mount & Blade II: Bannerlord.

**Scope:** This file defines **target behavior**, **data shapes**, and **constraints** for the intrigue layer. It does not list pull requests. Implementation order is in **Implementation slices** at the end.

**Normative:** Sentences using **must** or **must not** are requirements for the target design unless marked **should** (strong recommendation) or **may** (optional).

**Related documents:** `TECHNICAL_GUIDE.en.md` (file formats, prompts). Related code today: `NPCContext`, `WorldSecret`, `WorldInfoManager.CheckSecretKnowledge`, `PromptGenerator`, `AIInfluence.DynamicEvents`.

---

## Terms

| Term | Definition |
|------|------------|
| **LLM** | The language model used for a given HTTP request (remote or local). |
| **HTTP job** | One request–response cycle to the LLM API (or one non-LLM test job treated the same in logs). |
| **Completion** | The response body from one HTTP job. |
| **Snapshot** | Structured data built in C# from `Campaign`, intrigue stores, and `NPCContext`. Snapshots are inputs to prompts or proposal validators. The LLM must not invent snapshot fields. |
| **Proposal** | Structured output (usually JSON) listing intended intrigue or Bannerlord operations **before** validation. Not persisted until validated and committed. |
| **Authoritative state** | Values last written to the save (or memory backed by save) after validation. Assistant text is not authoritative. |
| **Intrigue store** | Persisted records for plots, runtime secrets, hooks, and plot points (exact files or tables are implementation details). |
| **Campaign intrigue job** | Work run from campaign time or engine events (battle end, daily tick, settlement entry, peace, prisoner moves, etc.). Used when the player may not be in dialogue. |
| **NPC dialogue job** | Work run for player↔NPC chat. One `Hero` and that hero’s `NPCContext` are in scope per message generation. |
| **Plot point** | A situation beat (rumor, movement, pressure) tied to a plot; not the same record type as a secret. May align with or extend `DynamicEvent` integration. |
| **Runtime secret** | A secret record created by the intrigue pipeline with `origin` pointing at a plot and step (or validated effect), not only a row in `world_secrets.json`. |
| **Hook** | A leverage record: owner, target `Hero`, optional `description`, basis (secret or event id), strength, optional evidence item link. |
| **Chat leverage row** | UI in the NPC chat window showing which hooks and verified secrets apply to the current interlocutor. Must use the same ids as the prompt builder for that hero. |

---

## Campaign intrigue jobs and NPC dialogue jobs

The host must record which kind of job each HTTP job belongs to. Both kinds share validation rules for proposals and saves, but **snapshot contents** and **allowed side effects** differ.

**Campaign intrigue job**

- **Trigger:** Campaign clock, battle resolution, entering or leaving a settlement, peace, prisoner transfer, or other engine hooks defined by the scheduler.
- **Snapshot includes (non-exhaustive):** Active plot instances; involved kingdom and clan ids; recent or relevant `DynamicEvent` summaries; policy flags; aggregates needed for world-scale prompts.
- **May:** Emit proposals that update the intrigue store and, through validated adapters, call Bannerlord APIs (relations, parties, etc.).
- **Must not:** Assume the player is in a dialogue scene.

**NPC dialogue job**

- **Trigger:** Player sends a message in the NPC chat UI (or equivalent).
- **Snapshot includes (non-exhaustive):** One `Hero`; `NPCContext`; relation, trust, emotion; player-owned hooks and applicable secrets for that interlocutor; plot points and events linked to that hero’s saved lists.
- **Produces:** Natural-language reply text for the NPC.
- **May:** Emit small JSON for tone or short-lived UI (implementation-specific).
- **Must not:** Persist plot, secret, or hook changes from raw assistant text alone. Durable changes require a validated path (tool handler, explicit post-step commit, or deterministic intrigue step).
- **Must:** Use the same secret, hook, and plot-point ids in the prompt and in the chat leverage row so the UI does not show data that the prompt did not receive (no unsynchronized display).

---

## Scope of the intrigue subsystem

The intrigue layer **stores** plot instances, plot points, runtime secrets, and hooks, and **runs** rules to create and propagate them.

Mount & Blade II: Bannerlord remains authoritative for: battles, parties, prisoners, settlements, relations, wars, crime, and other engine-level state. The intrigue layer **reads** that state and **writes** Bannerlord state only through defined, validated calls (existing diplomacy and event systems where applicable).

**LLM:** The LLM may fill parameters inside a fixed schema (proposals). Only operations committed after validation change the intrigue store or the campaign save.

---

## Current implementation and target behavior

**Implemented today**

- `world_secrets.json` defines catalog secrets (`WorldSecret`).
- `CheckSecretKnowledge` rolls `knowledgeChance` when knowledge is first generated for an `NPCContext`; winning rolls append secret ids to `KnownSecrets`.
- `PromptGenerator` resolves `KnownSecrets` to `description (access: …)` in the prompt.
- `world_info.json` and `KnownInfo` follow a parallel pattern for non-secret info.
- `DynamicEvents` on NPCs and `DynamicEventsManager` drive living events.

**Target behavior**

- Campaign-born hidden facts are **runtime secrets** with `origin` metadata (plot id, step id). The catalog becomes **optional** (modpack lore, migration, static scenarios).
- Plot steps **create** secrets and plot points by validated effects, not by first-chat dice against a static list alone.

**Migration:** New saves should prefer runtime secret ids with `origin`. Existing `KnownSecrets` entries may resolve through the catalog until migration tools run. Migration details belong in implementation work, not in this requirement list.

---

## Constraints

**Threading**

Code that touches `Campaign`, heroes, parties, or save data must follow the mod’s existing pattern: completion handlers enqueue work; the simulation or UI thread drains the queue under a time budget (see `AIInfluenceBehavior.Tick`). HTTP must not block the map thread.

**Authoritative state**

The assistant’s reply string is not evidence that a secret exists or who knows it. Only validated writes to the intrigue store or deterministic step execution count.

**Errors**

Schema failures, policy rejections, and engine errors must be logged. The system must not report success when a commit did not occur.

---

## Proposals, validation, and fallback

**Proposal format**

The host accepts proposals as JSON (or equivalent DTOs) listing typed operations, for example: `emit_plot_point`, `emit_secret`, `advance_plot_phase`, `propagate_knowledge`, `create_hook`, `apply_bannerlord_effect` with enums and string ids.

**Validation**

The host must verify: referenced ids exist; plot phase allows the operation; targets satisfy policy; Bannerlord invariants hold (valid `Hero.StringId`, kingdom exists, etc.).

**Parameter text**

Narrow plot templates may fix structure; wording and targets may come from a procedural generator from live state or from an LLM **inside** the schema. On validation failure, the host should fall back to procedural text or skip the operation and log the reason. Invalid JSON must not be committed.

**Plot step triggers**

Plot definitions may attach the same step to multiple triggers (`on_daily`, `on_battle_end`, `on_enter_settlement`) with different `requires` blocks so behavior varies by event without duplicating entire plot files.

---

## NPC dialogue output versus authoritative state

Displayed NPC lines are not authoritative. Authoritative state is whatever was committed to the save before that reply was generated.

The prompt builder must inject plot points, resolved secrets (`KnownSecrets` plus runtime secret store), hooks, and `DynamicEvent` slices **exactly** as stored for that hero. The chat leverage row must read the same hook and secret records as the prompt for that interlocutor.

---

## Processing steps from snapshot to UI

1. Build the snapshot (campaign job or dialogue job).
2. Choose execution mode: deterministic plot step, LLM-assisted proposal within schema, or dialogue-only generation.
3. Validate proposals: schema, allowlists, engine invariants.
4. On failure, fall back or skip; log.
5. Execute: append intrigue store rows, call Bannerlord APIs on the correct thread, update diplomacy or event queues as existing code requires.
6. Build prompt and chat UI only from state **after** step 5 for that turn.

---

## Data model (normative shapes)

Field names are logical; align with C# and JSON save layout in implementation.

**Plot instance (save):** `id`, `template_id`, `status`, `phase`, `started_campaign_day`, `context` (battle uid, prisoner ids, kingdom ids), `completed_step_ids`, `linked_plot_point_ids`, `linked_secret_ids`, optional `deadline_campaign_day`.

**Plot step (template, mod data):** `step_id`, `requires` (predicates), `effects[]` with typed operations (`emit_plot_point`, `emit_secret`, `advance_phase`, `spawn_hook`, `apply_relation_delta` if allowed). Lists which engine events activate the step.

**Secret record (runtime, save):** `id`, `description`, `access`, `subjects` (heroes or clans), `origin` `{ plot_id, step_id, cause }`, `created_campaign_day`, `status`. Created by executed effects, not by chat text alone.

**Plot point:** `id`, `plot_id`, `summary`, `importance`, spread and expiry fields, integration with diplomacy or `DynamicEvent` as designed.

**Hook:** `id`, `owner` (player or npc), `target_hero_string_id`, `description` (what the leverage is in play), `basis` `{ kind: secret or event, id }`, `strength` (`weak` or `strong`), optional `evidence_item` (`rp_item_template_id`, `generated_item_string_id`), lifecycle fields.

**Per-hero knowledge:** `KnownSecrets` remains a list of string ids; resolution checks runtime secret store first, then catalog. Optional separate list for plot point ids if not folded into `DynamicEvents`.

---

## Identity

Stored references must use `Hero.StringId`, `Clan.StringId`, and `Kingdom.StringId`. Display names are for UI only. Hooks and secrets must not be written with ambiguous partial names.

---

## Player-facing interface

- **Chat UI** (`ChatInterface.xml`, `NpcChatWindowVM`): Show plot points, applicable secrets, and player-owned hooks for the current interlocutor; distinguish rumor from verified per policy. Data source must match the prompt builder.
- **MCM:** Optional toggles for labels and verbosity are implementation details.

---

## Accepted risks (early phases)

- Mixed catalog ids and runtime ids until migration completes.
- Stale snapshots if the host does not refresh before a proposal; mitigation is refresh and strict validation.
- Concurrent campaign and dialogue HTTP jobs touching one plot: logs should include correlation ids to separate completions.

---

## Out of scope

- Replacing `DynamicEventsManager` with a second parallel event system without a merge plan.
- First-class mission-scene intrigue until a mission-layer design exists.
- Full legal or trial simulation per secret.

---

## References (internal)

- `TECHNICAL_GUIDE.en.md` — `world_secrets.json`, `world_info.json`, `dynamic_events.json`, NPC save fields.
- `docs/INTRIGUE_SYSTEM_PLAN.md` — pointer to this document.
- `docs/INTRIGUE_IMPLEMENTATION_PLAN.md` — ordered slices, test cases, success criteria.
- Code: `WorldInfoManager.CheckSecretKnowledge`, `PromptGenerator`, `NPCContext`, `AIInfluence.DynamicEvents`.

---

## Implementation slices

Ten slices; detail, test cases, and sign-off are in `docs/INTRIGUE_IMPLEMENTATION_PLAN.md`. Status is planning until work items mark otherwise.

| # | Slice | Outcome |
|---|--------|--------|
| 1 | Plot instance persistence | Serialize plot id, phase, context; no LLM; load and save safe. |
| 2 | Runtime secret store and catalog compatibility | CRUD; runtime-before-catalog resolution; legacy roll freeze or migration. |
| 3 | Step executor and propagation | Deterministic `requires` / effects; plot point storage strategy fixed; propagate knowledge to heroes. |
| 4 | Scheduler, triggers, correlation logging | Campaign hooks run executor; correlation ids in logs. |
| 5 | Dynamic events and `plot_id` | Optional link from event to plot instance. |
| 6 | Hooks, chat leverage, optional evidence | Hook store; UI aligned with prompt; optional RP item. |
| 7 | LLM-assisted proposal | Schema JSON; validate; commit or reject; correlation id. |
| 8 | Dialogue path audit | No silent intrigue writes from chat text alone. |
| 9 | Caps, expiry, cleanup | Max plots; expiry; measurable stress procedure. |
| 10 | Manual test spec and sign-off | `docs/INTRIGUE_TEST_SPEC.md` for slices 1–6 regression. |

Playtesting after slice 6 is recommended before heavy reliance on slices 7–9.

---

## Maintenance

Update this document when `TECHNICAL_GUIDE` artifacts change, when slice boundaries change, or when the intrigue store schema changes. Log prefix and MCM label changes should be reflected here if they affect integration.
