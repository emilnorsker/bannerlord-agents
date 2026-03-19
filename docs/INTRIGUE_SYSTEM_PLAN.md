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
| **B — Dialogue** | NPC slice (`KnownSecrets`, `KnownInfo`, `DynamicEvents`, plot obfuscation by role) + pressure | Natural language only | Conversation history only; **no** silent state change unless a separate **explicit** tool/patch path exists |
| **Optional — Propagation narrative** | Edge (A learned event E) | Short “why they heard” string | Debug / flavor; **not** source of truth for propagation rules |

---

## 10. Reference scenarios (for testing the design)

- **Secret as hook** — Single lord, blackmail phases, escalation to rumor or exposure.
- **Assassination chain** — Graph with partial knowledge per role; strike tied to travel/camp.
- **Fabricated claim / coup** — Template gated by kingdom/clan state; diplomatic statements follow `event_id`.
- **Companion as weak link** — Leak phase tied to battle loss or leaving companion in settlement.

Use these to validate **phase tables**, **propagation**, and **prompt slices**.

---

## 11. Phased delivery

1. **Schema + persistence** — Plot records and optional `plot_id` / metadata on dynamic events; migration-safe saves.
2. **Tick + validation** — Triggers invoke pipeline; only **enum-safe** effects at first.
3. **Secret–plot links** — Leverage, hook flags, phase unlocks from known secrets.
4. **LLM Pass A** — Structured world-beat generation wired to existing dynamic event creation path.
5. **Pressure + Pass B** — Per-NPC pressure updates; dialogue prompts use slices only.
6. **Polish** — Caps on concurrent plots, MCM intensity, logging and replay checks.

---

## 12. Non-goals and risks

- **Non-goal** — Fully simulated court politics inside the LLM with no save-backed state.
- **Risk** — Unbounded LLM freedom → inconsistent saves; mitigated by **patches only** for durable changes.
- **Risk** — Player never notices off-screen plots; mitigated by **discovery** subphases, missions, encyclopedia/rumor hooks, and diplomatic visibility.

---

## 13. Inspirational references (outside the mod)

- **Crusader Kings III** — Secrets, hooks, schemes as *state*.
- **Dwarf Fortress** — Long-horizon plots and graphs.
- **Disco Elysium** — Asymmetric information and voice under pressure.

---

*This document is the single consolidated reference for intrigue direction; implementation tasks should trace back to sections here.*
