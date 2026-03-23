# AI Influence — World system implementation plan

**Audience:** Engineers implementing the World system described in `docs/INTRIGUE_SYSTEM_DESIGN.md`.

**Scope:** **Twelve** ordered work packages (slices). Each slice is **shippable**, **testable**, and has **explicit success criteria**. It does not replace the design spec.

**Normative:** The same documentation rules as `agents.md` (no editorial tone; define terms; neutral headings). Requirements use **must** and **must not**.

**Depends on:** `docs/INTRIGUE_SYSTEM_DESIGN.md` (sole design spec for the World system; no separate “plan” file).

**Consolidation:** **I-02** covers runtime secret store plus catalog fallback for resolution only (no save migration). Evidence in I-06, correlation in I-04, caps as I-09, manual spec as I-10. **I-11** adds the **belief matrix service**. **I-12** adds **execution guard and replan**. **I-03** includes **episode event patterns**, **offline pattern library** loading, **append-only event diary**, and **I-06** includes **recall phrase** injection per `INTRIGUE_SYSTEM_DESIGN.md`.

---

## Terms

| Term | Definition |
|------|------------|
| **Slice** | One implementation unit with a single primary verification path. A slice **must** be testable without requiring later slices. |
| **Test case** | Steps or code that prove the slice works. May be **automated** or **manual**. Each slice lists one **primary** test case. |
| **Success criteria** | Observable conditions that **must** all hold before the slice is marked complete. |

---

## Slice overview

| Id | Title | Depends on |
|----|--------|------------|
| I-01 | Plot instance persistence | — |
| I-02 | Runtime secret store and catalog compatibility | I-01 |
| I-03 | Step executor, episodes, pattern library, event diary, propagation | I-01, I-02 |
| I-04 | Plot scheduler, triggers, correlation logging | I-03 |
| I-05 | Dynamic events, `plot_id`, World snapshot | I-01, I-04 |
| I-06 | Hooks, chat leverage row, recall phrases, optional evidence | I-02 |
| I-07 | LLM-assisted proposal path | I-03, I-04 |
| I-08 | Dialogue path audit | I-06, I-07 |
| I-09 | Caps, expiry, cleanup | I-01, I-02, I-03 |
| I-10 | Manual test specification and regression sign-off | I-01 through I-08 |
| I-11 | Belief matrix service | I-02, I-03 |
| I-12 | Execution guard and replan | I-03, I-04 |

---

## I-01 — Plot instance persistence

**Goal:** Persist at least one plot record type (id, phase, context blob, status) in the campaign save or a dedicated World file. No LLM. Load and save must round-trip without corruption.

**Depends on:** None.

**Deliverables:** Serialization types; load on campaign start; save on campaign save or World save hook; optional log line on load with plot count.

**Test case (primary)**

- **Automated (preferred):** Serialize a plot instance with fixed field values, deserialize, assert equality on all fields.
- **Manual (if no test project):** Start campaign; trigger MCM debug that writes one plot instance; save; load; confirm same id and phase in save or log.

**Success criteria**

- After load, in-memory plot registry matches what was saved.
- No exception during save or load.
- Plot id and phase are stable strings suitable for `origin` references.

---

## I-02 — Runtime secret store and catalog compatibility

**Goal:** Store runtime secret records; resolve prompt text **runtime first**, then catalog when an id exists only there. Document behavior for unknown ids and duplicate id namespaces. See design doc for fields.

**Depends on:** I-01.

**Deliverables:** Secret store CRUD; resolver integrated with `PromptGenerator` (or equivalent); documented resolution rules; optional MCM to disable catalog fallback for testing.

**Test case (primary)**

- **Automated:** (1) Runtime-only id resolves to runtime text. (2) Catalog-only id resolves to catalog text. (3) Unknown id logs error and does not throw.

**Success criteria**

- For each id passed to the resolver, resolution order is runtime store then catalog.
- Documented resolution rules cover ids present in runtime store, catalog only, both, or neither.

---

## I-03 — Step executor, episodes, pattern library, event diary, propagation

**Goal:** Execute plot steps **without** the LLM. Support **episodes**: **event patterns** with `match_type` in `{ single, consecutive, non_consecutive }`, template events with **wildcard** terms, and **resolution** with **`RSTATE`** / **`RGOAL`**. Load a **pattern library** artifact (offline trace analysis output) keyed by `template_id`. Maintain an **append-only event diary** (or ring buffer with documented cap): each committed, trace-visible effect appends **`event_id`**, ordering, **`event_code`**, and refs; **event patterns** match this diary only. Effects include `emit_plot_point`, `emit_secret`, `propagate_knowledge`. **Plot point** storage strategy fixed and documented (`DynamicEvent` and/or intrigue rows).

**Depends on:** I-01, I-02.

**Deliverables:** Step executor; one template with at least one episode and one library file or embedded fixture; pattern match unit tests; propagation rules; idempotency guard; diary append API and persistence.

**Test case (primary)**

- **Automated:** Mock diary: pattern `consecutive` matches and applies `RSTATE`/`RGOAL`; `single` and `non_consecutive` fixtures pass and fail as designed; library load registers patterns; failed `requires` writes nothing; committed effect produces new diary tail entry with stable ordering.

**Success criteria**

- Pattern types and wildcards behave per documented semantics.
- Offline library loads without runtime network access.
- Diary is append-only for committed entries; pattern matcher reads the same store the executor appends to.

---

## I-04 — Plot scheduler, triggers, correlation logging

**Goal:** Subscribe to campaign hooks so I-03 runs on the correct thread and tick budget. Log **correlation id** from trigger through executor.

**Depends on:** I-03.

**Deliverables:** Event subscriptions; queue or direct call consistent with `AIInfluenceBehavior.Tick`; logging format documented.

**Test case (primary)**

- **Manual:** Trigger test plot on `on_battle_end`; logs show correlation id; duplicate battle does not double-run.

**Success criteria**

- Correlation id present for every World execution path in this slice.

---

## I-05 — Dynamic events, `plot_id`, World snapshot

**Goal:** Optional `plot_id` on `DynamicEvent` (or parallel). Provide **World snapshot builder** fragment that includes recent event summaries for campaign jobs (integrate with existing `DynamicEventsManager` APIs).

**Depends on:** I-01, I-04.

**Deliverables:** Schema change; writer from plot pipeline; snapshot helper; backward compatibility for null `plot_id`.

**Test case (primary)**

- **Manual:** Plot-originated event has `plot_id`; non-plot event null; snapshot includes events in log or debug dump.

**Success criteria**

- Loads old saves without crash.

---

## I-06 — Hooks, chat leverage row, recall phrases, optional evidence

**Goal:** Hook store; chat row and prompt use identical ids; optional evidence item path. **Recall phrases:** load records that **bind** text to diary **`event_id`**, **plot point** id, **secret** id, or **belief key**; include bound phrases in the **NPC dialogue** snapshot when visibility policy passes (see design doc). Phrases must not mutate World state.

**Depends on:** I-02.

**Deliverables:** Hook store; prompt injection; **recall phrase** selection for dialogue prompts; `NpcChatWindowVM` bindings; optional item integration.

**Test case (primary)**

- **Manual:** Debug hook; chat matches prompt for same hook id. Fixture or manual: bound **recall phrase** appears in prompt when binding is visible; absent when not.

**Success criteria**

- UI shows hook **if and only if** prompt input includes that hook id.
- Recall phrase injection does not add secrets or hooks without a validated commit path.

---

## I-07 — LLM-assisted proposal path

**Goal:** Schema JSON proposals; validate; commit or reject; correlation id logged; invalid JSON never mutates save.

**Depends on:** I-03, I-04.

**Deliverables:** JSON schema or DTO; validator; logging integration.

**Test case (primary)**

- **Automated or manual:** Invalid JSON → no save mutation; valid proposal → commit or dry-run log.

**Success criteria**

- Invalid proposals never mutate save.

---

## I-08 — Dialogue path audit

**Goal:** Raw NPC chat text does not append `KnownSecrets`, runtime secrets, hooks, **belief matrix** rows, or plot rows without validated commit path.

**Depends on:** I-06, I-07.

**Deliverables:** Checklist; optional static test; logging on mutation APIs.

**Test case (primary)**

- **Manual:** Prose claims new secret; intrigue + belief stores unchanged.
- **Automated (preferred):** Forbidden call sites fail CI.

**Success criteria**

- Written evidence stored with sign-off.

---

## I-09 — Caps, expiry, cleanup

**Goal:** Max concurrent plots; expiry; measurable stress procedure.

**Depends on:** I-01, I-02, I-03.

**Deliverables:** Config; cleanup on tick or daily.

**Test case (primary)**

- **Automated:** N+1 plots with cap N → reject or evict per policy.

**Success criteria**

- Cap deterministic; expiry does not corrupt saves.

---

## I-10 — Manual test specification and regression sign-off

**Goal:** `docs/INTRIGUE_TEST_SPEC.md` with TC ids for **I-01 through I-08**, prerequisites, steps, success criteria; sign-off table.

**Depends on:** I-01 through I-08 complete.

**Deliverables:** `docs/INTRIGUE_TEST_SPEC.md` only.

**Test case (primary)**

- **Review:** File exists; TCs map to I-01–I-08; external engineer can run regression.

**Success criteria**

- Dated sign-off for at least one full I-01–I-08 pass.

---

## I-11 — Belief matrix service

**Goal:** Persist and update **belief matrices** per `belief_key` (secret id or defined proposition id). Diagonal = holder confidence proposition true; off-diagonal = A’s confidence B knows. Integrate **propagation** and **prompt excerpts** per policy. Sync with `KnownSecrets` where design maps list membership to thresholded beliefs.

**Depends on:** I-02, I-03.

**Deliverables:** Belief store; API for get/set slice; integration with propagation effect type `update_belief_matrix`; documented thresholds.

**Test case (primary)**

- **Automated:** Set matrix for two heroes; update one cell; read back; propagation effect adjusts diagonal/off-diagonal as specified in fixture.

**Success criteria**

- No crash on partial participant lists; thresholds documented.

---

## I-12 — Execution guard and replan

**Goal:** Immediately before applying a mutating effect that depends on Bannerlord state, **re-check preconditions** (presence, war, relation band, inventory, etc.). If fail: **skip** effect, log, and apply **replan policy** (abort step, enqueue recovery proposal, or transition plot phase—behavior documented per template).

**Depends on:** I-03, I-04.

**Deliverables:** Guard wrapper or executor phase; logging; at least one template policy for fail path.

**Test case (primary)**

- **Automated:** Simulate state change between proposal acceptance and execution; guard blocks stale effect; log contains `replan` or `abort` marker.

**Success criteria**

- No silent application of effects whose preconditions are false at execution time.

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
| I-11 | | | |
| I-12 | | | |

---

## Maintenance

Update this plan when slices split, merge, or reorder. Align with `docs/INTRIGUE_SYSTEM_DESIGN.md` on every change.
