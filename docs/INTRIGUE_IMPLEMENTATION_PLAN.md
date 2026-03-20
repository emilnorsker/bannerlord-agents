# AI Influence — Intrigue implementation plan

**Audience:** Engineers implementing the intrigue layer described in `docs/INTRIGUE_SYSTEM_DESIGN.md`.

**Scope:** This file turns **ten** design slices into **ordered work packages**. Each slice is **shippable**, **testable**, and has **explicit success criteria**. It does not replace the design spec.

**Normative:** The same documentation rules as `agents.md` (no editorial tone; define terms; neutral headings). Requirements use **must** and **must not**.

**Depends on:** `docs/INTRIGUE_SYSTEM_DESIGN.md` (data model, pipelines, constraints).

**Consolidation:** Earlier drafts used twelve slices. The following **ten** merge prior scope: **migration** sits inside **runtime store** (I-02); **evidence items** sit inside **hooks** (I-06); **correlation logging** sits inside **scheduler** (I-04); **caps** are a dedicated slice (I-09); **manual test spec** is the final slice (I-10).

---

## Terms

| Term | Definition |
|------|------------|
| **Slice** | One implementation unit with a single primary verification path. A slice **must** be testable without requiring later slices. |
| **Test case** | Steps or code that prove the slice works. May be **automated** (unit or integration test in the solution) or **manual** (in-game or log inspection). Each slice lists one **primary** test case; additional tests may be added but are not required for sign-off. |
| **Success criteria** | Observable conditions that **must** all hold before the slice is marked complete. |

---

## Slice overview

| Id | Title | Depends on |
|----|--------|------------|
| I-01 | Plot instance persistence | — |
| I-02 | Runtime secret store and catalog compatibility | I-01 |
| I-03 | Deterministic step executor and knowledge propagation | I-01, I-02 |
| I-04 | Plot scheduler, triggers, correlation logging | I-03 |
| I-05 | Dynamic events and `plot_id` | I-01, I-04 |
| I-06 | Hooks, chat leverage row, optional evidence | I-02 |
| I-07 | LLM-assisted proposal path | I-03, I-04 |
| I-08 | Dialogue path audit | I-06, I-07 |
| I-09 | Caps, expiry, cleanup | I-01, I-02, I-03 |
| I-10 | Manual test specification and regression sign-off | I-01 through I-06 |

---

## I-01 — Plot instance persistence

**Goal:** Persist at least one plot record type (id, phase, context blob, status) in the campaign save or a dedicated intrigue file. No LLM. Load and save must round-trip without corruption.

**Depends on:** None.

**Deliverables:** Serialization types; load on campaign start; save on campaign save or intrigue save hook; optional log line on load with plot count.

**Test case (primary)**

- **Automated (preferred):** If the solution has a test project, serialize a plot instance with fixed field values, deserialize, assert equality on all fields.
- **Manual (if no test project):** Start campaign; trigger MCM debug or one-time path that writes one plot instance; save; load; confirm same id and phase in save or log.

**Success criteria**

- After load, in-memory plot registry matches what was saved.
- No exception during save or load.
- Plot id and phase are stable strings suitable for `origin` references.

---

## I-02 — Runtime secret store and catalog compatibility

**Goal:** Store runtime secret records with `id`, `description`, `access`, `subjects`, `origin` (`plot_id`, `step_id` where applicable), `created_campaign_day`. Resolve prompt text by id with **runtime store first**, then `world_secrets.json` fallback. Preserve behavior for existing saves: MCM flag to freeze legacy `CheckSecretKnowledge` rolls and/or one-time migration of catalog-backed ids to runtime rows with `origin` set for migration (exact policy in implementation notes).

**Depends on:** I-01.

**Deliverables:** Secret store CRUD; resolver integrated with `PromptGenerator` (or equivalent); compatibility path documented; MCM entry if freezing rolls.

**Test case (primary)**

- **Automated:** (1) Runtime-only id: insert runtime secret `sec_test_runtime_01` with fixed description; `KnownSecrets` contains that id; resolver returns runtime text. (2) Catalog-only id: id present only in catalog; resolver returns catalog text. (3) Unknown id: resolver logs error and does not throw.
- **Manual:** Same three cases via MCM debug output.

**Success criteria**

- Resolution order is runtime then catalog for every id.
- Default compatibility mode does not break existing campaigns (manual load of pre-change save).

---

## I-03 — Deterministic step executor and knowledge propagation

**Goal:** Execute plot step definitions with `requires` predicates and effects (`emit_plot_point`, `emit_secret`, `propagate_knowledge` or equivalent) **without** the LLM. **Plot point** records must follow one chosen storage strategy documented in the deliverables (dedicated intrigue rows and/or `DynamicEvent` integration—pick one for v1 and document). Propagation must append secret ids (or plot point ids) to per-hero state per rule (e.g. lords of clan).

**Depends on:** I-01, I-02.

**Deliverables:** Step executor; at least one template with one step; propagation rules; idempotency guard so a step does not double-apply without explicit policy.

**Test case (primary)**

- **Automated:** Satisfy `requires` with mock context; run executor; assert runtime secret row with correct `origin.step_id`; assert target heroes’ knowledge lists updated per rule; assert no writes when `requires` fails.

**Success criteria**

- Failed `requires` creates no secrets or propagated ids.
- Successful run is idempotent per step completion flag.

---

## I-04 — Plot scheduler, triggers, correlation logging

**Goal:** Subscribe to campaign hooks (`on_daily_tick`, `on_battle_end`, `on_enter_settlement` or reviewed subset) so I-03 runs on the correct thread and tick budget. Every enqueue or completion related to intrigue must log a **correlation id** from trigger through executor so parallel jobs are distinguishable in `mod_log` (or dedicated channel).

**Depends on:** I-03.

**Deliverables:** Event subscriptions; queue or direct call consistent with `AIInfluenceBehavior.Tick`; logging format documented (prefix + Guid).

**Test case (primary)**

- **Manual:** Trigger test plot on `on_battle_end` (use debug template delivered with I-03); logs show one correlation id per run; duplicate battle does not double-run (guard verified).
- **Automated (optional):** Mock battle end; assert scheduler invoked once with expected correlation pattern.

**Success criteria**

- No scheduler run on unrelated ticks in control test.
- Correlation id present for every intrigue execution path in this slice.

---

## I-05 — Dynamic events and `plot_id`

**Goal:** Extend `DynamicEvent` (or agreed parallel record) with optional `plot_id` linking to the I-01 plot instance. Writer sets field when events originate from plot pipeline; readers use it for diplomacy and UI.

**Depends on:** I-01, I-04.

**Deliverables:** Schema change; writer path from plot effects; backward compatibility for null `plot_id`.

**Test case (primary)**

- **Manual:** Emit event from plot; inspect persisted event; `plot_id` matches active plot id. Create non-plot event; `plot_id` is null.

**Success criteria**

- No crash when loading saves without the new field (migration or default).

---

## I-06 — Hooks, chat leverage row, optional evidence

**Goal:** Persist hooks (`PlayerHooks` or equivalent) with `description`, `strength`, `target_hero_string_id`, `basis`. Chat UI row and prompt builder use **identical** hook ids for the current interlocutor. **Optional:** `evidence_item` spawns or references RP item; store `generated_item_string_id`. If no item pipeline exists, evidence path is **skipped** with success criteria “hooks without evidence unchanged.”

**Depends on:** I-02.

**Deliverables:** Hook store; prompt injection; `NpcChatWindowVM` (or successor) bindings; optional item integration.

**Test case (primary)**

- **Manual:** Create hook via debug; open chat with target; leverage row matches prompt log for same hook id. If evidence enabled: item exists and id survives reload; if disabled: hook-only path passes.

**Success criteria**

- Hook appears in UI **if and only if** hook is in prompt inputs for that session (same ids).

---

## I-07 — LLM-assisted proposal path

**Goal:** HTTP completion returns JSON proposal; host validates schema; commits or rejects; logs **correlation id**; invalid JSON never mutates save. Dry-run mode acceptable for first merge.

**Depends on:** I-03, I-04.

**Deliverables:** JSON schema or DTO; validator; integration with enqueue path from I-04 logging.

**Test case (primary)**

- **Automated or manual:** Invalid JSON → no new intrigue rows; log shows validation failure. Valid minimal proposal → rows appear or dry-run log confirms commit path.

**Success criteria**

- Invalid proposals never mutate save.

---

## I-08 — Dialogue path audit

**Goal:** Establish that raw NPC chat text does not append `KnownSecrets`, runtime secrets, hooks, or plot rows without a validated tool or post-commit path.

**Depends on:** I-06, I-07.

**Deliverables:** Checklist; optional CI grep or unit test forbidding direct `KnownSecrets.Add` from dialogue handlers; logging when mutation APIs are called.

**Test case (primary)**

- **Manual:** Send messages that assert new secrets in prose; save hash or row count unchanged for intrigue stores.
- **Automated (preferred):** Static rule or test fails if forbidden call sites exist.

**Success criteria**

- Written evidence (grep output or test name) stored with sign-off.

---

## I-09 — Caps, expiry, cleanup

**Goal:** Enforce maximum concurrent plot instances; expiry for plot points and secrets where applicable; prevent unbounded growth. **Success must be measurable:** e.g. cap = N rejects or evicts per written policy; optional file-size or row-count ceiling documented as manual stress procedure.

**Depends on:** I-01, I-02, I-03.

**Deliverables:** Config (MCM or const); cleanup on tick or daily.

**Test case (primary)**

- **Automated:** Insert N+1 plots when cap is N; assert rejection or eviction per policy.
- **Manual:** Documented stress run for row count; record before/after in sign-off.

**Success criteria**

- Cap enforced deterministically.
- Expiry removes or archives rows without crashing saves.

---

## I-10 — Manual test specification and regression sign-off

**Goal:** Add `docs/INTRIGUE_TEST_SPEC.md` with test case ids for **I-01 through I-06**, prerequisites, steps, success criteria aligned with this plan; sign-off table for release candidates.

**Depends on:** I-01 through I-06 complete.

**Deliverables:** `docs/INTRIGUE_TEST_SPEC.md` only.

**Test case (primary)**

- **Review:** File exists; each TC maps to one of I-01–I-06; another engineer can execute regression without reading source.

**Success criteria**

- Document linked from this plan; dated sign-off row for at least one full I-01–I-06 pass.

---

## Sign-off

| Slice | Owner | Date | Test case reference |
|-------|--------|------|---------------------|
| I-01 | | | |
| I-02 | | | |
| I-03 | | | |
| I-04 | | | |
| I-05 | | | |
| I-06 | | | |
| I-07 | | | |
| I-08 | | | |
| I-09 | | | |
| I-10 | | | |

---

## Maintenance

Update this plan when a slice is split, merged, or reordered. When `INTRIGUE_SYSTEM_DESIGN.md` changes, align dependencies and numbering here.
