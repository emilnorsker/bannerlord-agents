# Intrigue system — design plan

Consolidated plan for a **living-world intrigue layer** in the AI Influence / Bannerlord stack: mix **Crusader Kings III–style** secrets and leverage, **Dwarf Fortress–style** long-horizon plots and graphs, and **Disco Elysium–style** asymmetric dialogue—while **Bannerlord remains the authority** for consequences and **existing dynamic events** stay the pulse of a living world.

---

## 1. Vision

- The world **moves without the player in every room**: plots and rumors **spawn, spread, decay**, and tie into **diplomacy** the same way `dynamic_events` already do.
- **Secrets** stay objects (who knows, severity, optional hook use); **plots** are **intent + phases + participants**, not only prose.
- The **LLM is the creative engine** (beats, plausibility, voice, pressure); the **save layer stores typed state** (events, knowledge, patches) so campaigns stay consistent and debuggable.

---

## 2. Design principles

1. **Split fact from fiction in data** — Secrets = *known facts*; plots = *goals and phases*. Prompts combine both per NPC, filtered by what they plausibly know.
2. **Three layers**  
   - **Ledger** — Durable records: plots, phases, participants, links to events/secrets.  
   - **Simulation** — Ticks and triggers advance phases and emit **Bannerlord-safe** effects.  
   - **Presentation** — Dialogue LLM only **interprets** the slice + pressure variables; it does not silently own world truth.
3. **Bannerlord as physics** — Read clan, kingdom, war, relation, gold, settlements, battles, crime, quests; write consequences through **normal game channels** (relations, wars, missions, incidents, statements).
4. **Living world = same rhythm as dynamic events** — New intrigue should **extend or attach to** `dynamic_events` (and related diplomacy files), reuse **propagation**, **importance**, **expiry**, **spread_speed**, and **per-NPC `DynamicEvents`**.
5. **LLM used to the fullest** — Rich context in; **structured patches** out (event rows, knowledge updates, diplomatic intents). Soft “is this plausible?” reasoning lives in the model; **hard invariants** live in code.
6. **No masking errors** — Failed parses, invalid actions, or API failures surface clearly (logs, UI, or explicit fallback behavior)—never silent success.

---

## 3. Architecture overview

```
Triggers (time, battle, travel, diplomacy, …)
    → Context bundle (Bannerlord snapshot + recent events + relations)
    → LLM Pass A — world beat (structured proposals)
    → Validate & commit (schema + engine invariants)
    → Propagation (who gets DynamicEvents / knowledge updates)
    → [Player talks]
    → LLM Pass B — dialogue (NPC slice + pressure only)
```

**Directed graph (DF-style)** — `mastermind → lieutenants → pawns → target` (target often player or clan), stored as references to **heroes/clans/kingdoms** where the game provides ids.

**Phases (example)** — `gather_intel → position → strike → cover_up` (template-specific). Advancement is **trigger-driven** + optional checks (battle outcome, visits, companions left in settlement, etc.).

**Pressure variables (Disco-style)** — Per-NPC scalars or tags: e.g. fear_of_exposure, greed, loyalty_to_faction. Same ledger row produces **different speech** without hand-authored branches for every line.

---

## 4. Data model (target shape)

*Exact field names can follow existing mod conventions; this is the logical model.*

| Concept | Purpose |
|--------|---------|
| **Secret** (existing + optional extensions) | `id`, description, severity, `knowledgeChance`, `applicableNPCs`, `accessLevel`, tags; optional: `leverage`, `contradicts`, `implicates` |
| **Plot instance** | `id`, `template_id` (murder, coup, blackmail, fabricate_claim, …), `phase`, `phase_started_day`, `deadline_day`, `status` (active/failed/exposed/resolved), links to `dynamic_event_id`(s) |
| **Plot participants** | Roles: mastermind, lieutenant, pawn, target; map to game entities + optional anonymity flags |
| **Knowledge sync** | Per NPC: which plot **roles** they know about; which **secrets**; which **event ids** in `DynamicEvents` |
| **Pressure** | Per NPC (or per NPC–plot): small structured block updated by analysis or rules |
| **Hook** (player- or NPC-held) | First-class leverage object: `id`, `target_hero_id` (or clan), `basis` (`secret_id` and/or `evidence_event_id`), **`strength`** (`weak` / `strong`), optional `decay_campaign_days` or use limits. **Strong** = defensible proof, hard to deny, large relation / diplomatic / coercion range. **Weak** = hearsay, single witness, forged or partial—usable but may **backfire**, be **disputed**, or **burn** on use. Hooks are **not** free-text; the LLM role-plays around **committed** hook state. |
| **Player knowledge** | Track what the **player** has verified: `PlayerKnownSecretIds`, `PlayerHooks` (owned hooks only). Distinguish **verified secret** (entered ledger by investigation, document, confession, reliable chain) from **rumor** (only `world_info` / unconfirmed events in UI). |

**Attachment to living events** — Prefer `dynamic_events` entries that carry or reference `plot_id`, so intrigue **rises and falls** with the same propagation and diplomacy hooks described in `TECHNICAL_GUIDE.en.md` (`type`, `importance`, `kingdoms_involved`, `spread_speed`, `expiration_campaign_days`, `allows_diplomatic_response`, etc.).

---

## 5. Integration with existing mod artifacts

| Artifact | Role |
|----------|------|
| `world_secrets.json` | Canonical secret definitions; optional new fields for plot linkage / leverage |
| `world_info.json` | Public rumor layer vs `Secrets:` / `General Info:` split in prompts |
| `dynamic_events.json` | **Primary carrier** for “something is happening”; intrigue **creates or extends** these |
| `diplomatic_statements.json`, `diplomatic_events.json`, … | Ruler reactions and actions tied to `event_id` |
| `save_data/.../NPC (id).json` | `KnownSecrets`, `KnownInfo`, `DynamicEvents` — **who knows what** |
| Logs (`dynamicEvents.log`, `diplomacy.txt`) | Full prompts/responses for generation and debugging |

---

## 6. Triggers (inputs)

| Trigger | Typical use |
|---------|----------------|
| Campaign **daily / weekly** tick | Timeouts, coalition building, rumor spread |
| **Enter / leave** settlement | Intel, positioning, meetings, assassination windows |
| **Battle end** | Escalation, capture reveals, cover-up |
| **Relation / influence / gold** shifts | Hook strength, template eligibility signals |
| **Quest / mission** state | Player commitment; vanilla-shaped follow-ups |
| **Conversation open** | Refresh **read-only** context for prompts; optional intent tags from player text (processed on next tick) |

**Ordering** — Run simulation **before** assembling dialogue context for that session. Effects should be **idempotent** where possible (phase flags) to avoid double application on duplicate triggers.

---

## 7. Update pipeline (each processing batch)

1. **Queue** — Triggers append candidate transitions (e.g. “strike eligible”).
2. **Validate** — **Hard** gates: engine/API safety, schema. **Soft** gates: LLM plausibility score + reason (optional).
3. **Advance** — Update `phase` / `status`; branch on success/fail/exposed.
4. **Emit** — Apply Bannerlord effects (relations, war, crime, missions, incidents).
5. **Sync knowledge** — Update NPC `DynamicEvents`, `KnownSecrets` / plot visibility by role.
6. **Dialogue** — Build prompt only from **that NPC’s slice** + pressure.

---

## 8. Gateways (three lanes)

1. **Engine invariants** — Minimal; prevents invalid ids, impossible actions, crashes.
2. **World plausibility (LLM)** — Model sees accurate state; proposes beats and likelihood; not the only line of defense.
3. **Schema / patch application** — LLM outputs **typed JSON** (new event, knowledge delta, diplomatic intent enum); code commits only valid patches.

---

## 9. LLM passes

| Pass | Input | Output | Commit |
|------|--------|--------|--------|
| **A — World beat** | Snapshot + active plots/events + diplomacy context | 0–k structured **event/plot** proposals | Merge into `dynamic_events` / plot ledger after validation |
| **B — Dialogue** | NPC slice + pressure + **player-owned** hooks/secrets that apply to this interlocutor (same facts the **leverage strip** shows) | Natural language only | Conversation history only; **no** silent state change unless a separate **explicit** tool/patch path exists |
| **Optional — Propagation narrative** | Edge (A learned event E) | Short “why they heard” string | Debug / flavor; **not** source of truth for propagation rules |

---

## 10. Player-facing interface — hooks, verified secrets, paranoia

**Goal:** The player **learns the mechanics** by seeing **durable game objects** at the moment of talk, and stays **a little paranoid** about context—without dumping internal plot phase names by default.

### 10.1 Chat UI — leverage strip (current interlocutor)

**Requirement:** Verified secrets and hooks (**strong** / **weak**) **must** appear on the **same chat surface** the player uses for AI dialogue—not only encyclopedia or inventory. Concretely: extend **`GUI/Prefabs/ChatInterface.xml`** (`ChatInterfaceWindow`), in the **left stat banner** (with `@RelationText` / `@TrustLabel` / `@EmotionLabel`) **and/or** the **center header** (below `@NpcName` / title), so leverage is visible **while typing and reading messages**.

When the player talks to hero **H**, show a compact **leverage strip** there (icons + short labels, tooltips for detail):

| Indicator | When shown | What it teaches |
|-----------|------------|-----------------|
| **Verified secret** | `secret_id` ∈ `PlayerKnownSecretIds` and secret **implicates** or **applies to** H (tag, subject, or explicit link) | You hold **truth** usable in negotiation; not the same as tavern gossip. |
| **Hook (strong)** | Player owns a `Hook` with `target_hero_id == H`, `strength == strong` | High-stakes leverage; system will weight coercion / compliance in prompts and outcomes. |
| **Hook (weak)** | Same, `strength == weak` | You can push, but **risk** of denial, counter-reveal, or burned hook—UI tooltip says so. |
| **No hook / no verified secret** | — | Either you have nothing solid on **this** character, or only rumors (see world events / encyclopedia). |

**Copy discipline:** Labels use in-world words where possible (“You have proof of…” / “You could press them on…”); **strong/weak** can appear as **stamina-bar style** or **metal vs rope** metaphor if you want full diegesis, with strength exposed in tooltip.

**Rumor vs secret:** If the player only has a **rumor** (dynamic event or `world_info`, not verified), show **no** verified-secret badge; optional muted “Rumor (unconfirmed)” if you want to teach the distinction without granting mechanical hook power.

### 10.2 Hook list & detail (inventory screen or encyclopedia subpage)

- List all **player-owned hooks**: target name, **basis** one-liner (which secret/event), **strong/weak**, optional expiry.
- Click → short **mechanical reminder**: what strong vs weak means for **burn risk** and **AI behavior** (one paragraph, not a novel).

### 10.3 MCM

- Toggle: show **hook strength** as explicit words vs purely diegetic.
- Toggle: show **verified secret** strip in conversation (on by default for learnability).

### 10.4 Paranoia without obscurity

Ambient “who might hear” cues (from the earlier interface concept) **stack** with the strip: the player sees **both** “I have a **weak** hook” and “**Public** setting”—i.e. using it here may be **risky**. Strong hooks might still be **dangerous** socially even if hard to deny.

---

## 11. Reference scenarios (for testing the design)

Short labels for QA / implementation checks:

- **Blackmail** — You have real leverage on one lord; they push back or fold.
- **Hunt / reprisal** — You win a fight; the other side does not forget.
- **Quiet politics** — No battle; reputation and rumors move anyway.
- **Broken battle + missing friend** — You lose badly; someone you care about is left behind.

---

## 12. Phased delivery

1. **Schema + persistence** — Plot records and optional `plot_id` / metadata on dynamic events; migration-safe saves.
2. **Hooks + player knowledge** — `PlayerHooks` (with `weak` / `strong`), `PlayerKnownSecretIds`, rules for creating/burning hooks from verified secrets or evidence events.
3. **Tick + validation** — Triggers invoke pipeline; only **enum-safe** effects at first.
4. **Secret–plot links** — Leverage, hook flags, phase unlocks from known secrets.
5. **LLM Pass A** — Structured world-beat generation wired to existing dynamic event creation path.
6. **Pressure + Pass B** — Per-NPC pressure updates; dialogue prompts use slices only; Pass B receives **player hook/secret context** only when UI shows it (same source of truth).
7. **Interface** — **Chat UI** leverage strip in `ChatInterface.xml` (with optional hook inventory page) + MCM toggles.
8. **Polish** — Caps on concurrent plots, MCM intensity, logging and replay checks.

---

## 13. Non-goals and risks

- **Non-goal** — Fully simulated court politics inside the LLM with no save-backed state.
- **Risk** — Unbounded LLM freedom → inconsistent saves; mitigated by **patches only** for durable changes.
- **Risk** — Player never notices off-screen plots; mitigated by **discovery** subphases, missions, encyclopedia/rumor hooks, and diplomatic visibility.

---

## 14. Inspirational references (outside the mod)

- **Crusader Kings III** — Secrets, hooks, schemes as *state*.
- **Dwarf Fortress** — Long-horizon plots and graphs.
- **Disco Elysium** — Asymmetric information and voice under pressure.

---

*This document is the single consolidated reference for intrigue direction; implementation tasks should trace back to sections here.*
