# AI Influence — Intrigue implementation plan

**Audience:** Engineers implementing the intrigue layer described in `docs/INTRIGUE_SYSTEM_DESIGN.md`.

**Scope:** This file turns design **slices** into **ordered work packages**. Each slice is **shippable**, **testable**, and has **explicit success criteria**. It does not replace the design spec.

**Normative:** The same documentation rules as `agents.md` (no editorial tone; define terms; neutral headings). Requirements use **must** and **must not**.

**Depends on:** `docs/INTRIGUE_SYSTEM_DESIGN.md` (data model, pipelines, constraints).

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
| I-02 | Runtime secret store | I-01 |
| I-03 | Deterministic step executor | I-01, I-02 |
| I-04 | Plot scheduler triggers | I-03 |
| I-05 | Catalog migration bridge | I-02 |
| I-06 | Hooks and chat alignment | I-02, I-05 |
| I-07 | Hook evidence items | I-06 |
| I-08 | LLM proposal path | I-03, I-04 |
| I-09 | Plot id on dynamic events | I-01, I-04 |
| I-10 | Dialogue path audit | I-06, I-08 |
| I-11 | Caps and expiry | I-01, I-02 |
| I-12 | Manual test specification document | I-01 through I-06 |

---

## I-01 — Plot instance persistence

**Goal:** Persist at least one plot record type (id, phase, context blob, status) in the campaign save or a dedicated intrigue file. No LLM. Load and save must round-trip without corruption.

**Depends on:** None.

**Deliverables:** Serialization types; load on campaign start; save on campaign save or intrigue save hook; log line on load with plot count (optional).

**Test case (primary)**

- **Automated (preferred):** If the solution has a test project, add a test that serializes a plot instance with fixed field values to JSON (or the chosen format), deserializes, and asserts equality on all fields.
- **Manual (if no test project):** Start campaign, trigger one-time code path or MCM debug action that writes one plot instance, save game, load game, confirm the same id and phase appear in save file or log.

**Success criteria**

- After load, the in-memory plot registry matches what was saved.
- No exception during save or load.
- Plot id and phase are stable strings suitable for `origin` references in I-02.

---

## I-02 — Runtime secret store

**Goal:** Store runtime secret records with `id`, `description`, `access`, `subjects`, `origin` (`plot_id`, `step_id`), `created_campaign_day`. Resolve secret text for prompts by id with **runtime store first**, then catalog (`world_secrets.json`) fallback.

**Depends on:** I-01 (for `plot_id` in `origin`).

**Deliverables:** Secret store CRUD; integration with `PromptGenerator` (or equivalent) so `KnownSecrets` ids resolve through runtime first.

**Test case (primary)**

- **Automated:** Insert a runtime secret with `id = sec_test_runtime_01` and a fixed description; build a minimal `NPCContext` with `KnownSecrets` containing that id; call the resolver used by prompts; assert the returned string equals the runtime description, not any catalog row with the same id if both existed.
- **Manual:** Same check via MCM debug that prints resolved prompt text for a test NPC.

**Success criteria**

- Runtime secret wins over catalog when both could apply.
- Missing id logs a clear error and does not crash.

---

## I-03 — Deterministic step executor

**Goal:** Execute plot step definitions with `requires` predicates and `effects` including `emit_plot_point` and `emit_secret` **without** calling the LLM. Unit-testable with a fake campaign context.

**Depends on:** I-01, I-02.

**Deliverables:** Step executor service; at least one plot template with one step that emits one secret when predicates pass.

**Test case (primary)**

- **Automated:** Unit test with a frozen `PlotContext` / mock campaign state where `requires` is satisfied; run executor; assert one new runtime secret row exists with correct `origin.step_id` and one plot point id if `emit_plot_point` is used.

**Success criteria**

- When `requires` fails, no secrets or plot points are created.
- When `requires` passes, effects run exactly once (idempotent flag on step).

---

## I-04 — Plot scheduler triggers

**Goal:** Wire campaign hooks (`on_daily_tick`, `on_battle_end`, `on_enter_settlement` or the subset agreed in code review) to enqueue the plot scheduler so I-03 runs at the right time.

**Depends on:** I-03.

**Deliverables:** Subscriptions from existing campaign event handlers; single-threaded execution consistent with `AIInfluenceBehavior.Tick` discipline.

**Test case (primary)**

- **Manual:** With a test plot that advances on `on_battle_end`, win a battle in-game (or trigger battle end in debug); verify log shows scheduler run and plot state changes per template.
- **Automated (optional):** Mock `MapEvent` end and assert scheduler invoked once.

**Success criteria**

- Scheduler does not run on unrelated ticks.
- No duplicate execution for the same battle event (guard by event id or flag).

---

## I-05 — Catalog migration bridge

**Goal:** Preserve existing behavior for saves that only have catalog `KnownSecrets` while enabling runtime ids. Options: MCM flag to freeze old roll behavior; or one-time migration that copies eligible catalog secrets into runtime records with `origin: migration`.

**Depends on:** I-02.

**Deliverables:** Documented migration or compatibility path; MCM entry if needed.

**Test case (primary)**

- **Manual:** Load a save from before I-02; confirm NPCs still resolve secrets in dialogue; no new runtime secrets unless migration runs; after migration (if implemented), confirm `KnownSecrets` still valid.

**Success criteria**

- No regression on existing campaigns for the default compatibility mode.

---

## I-06 — Hooks and chat alignment

**Goal:** Persist hook records (`PlayerHooks` or equivalent); include `description`, `strength`, `target_hero_string_id`, `basis`. Chat UI row (leverage) and prompt builder read **the same** hook list for the current interlocutor.

**Depends on:** I-02, I-05.

**Deliverables:** Hook store; prompt injection; `NpcChatWindowVM` (or successor) bindings for leverage row.

**Test case (primary)**

- **Manual:** Create a hook with `description` in debug; open chat with target hero; verify row matches; log prompt snippet for that NPC and verify same hook id appears.

**Success criteria**

- Hook visible in UI **if and only if** hook is in prompt inputs for that session (same ids).

---

## I-07 — Hook evidence items

**Goal:** Optional `evidence_item` on hook: spawn or reference RP item when `basis` warrants; store `generated_item_string_id` on hook.

**Depends on:** I-06.

**Deliverables:** Hook schema extension; item spawn hook into existing item pipeline (if any).

**Test case (primary)**

- **Manual:** Create hook with evidence item; verify item exists in player inventory or quest stash per design; reload save; id stable.

**Success criteria**

- Hooks without evidence item unchanged.

---

## I-08 — LLM-assisted proposal path

**Goal:** HTTP completion returns JSON proposal; host validates schema; commits or rejects; logs correlation id; **no** commit on invalid JSON.

**Depends on:** I-03, I-04.

**Deliverables:** JSON schema or DTO; validator; correlation id in logs from enqueue through commit.

**Test case (primary)**

- **Manual or automated:** Feed **invalid** JSON; assert no new rows; log shows validation failure. Feed **valid** JSON matching a dry-run operation; assert rows appear or dry-run log confirms.

**Success criteria**

- Invalid proposals never mutate save.

---

## I-09 — Plot id on dynamic events

**Goal:** `DynamicEvent` (or parallel record) carries optional `plot_id` linking to I-01 instance for diplomacy and UI.

**Depends on:** I-01, I-04.

**Deliverables:** Schema extension; writer when creating events from plot; reader for UI.

**Test case (primary)**

- **Manual:** Trigger event from plot; inspect `dynamic_events` storage (or log); `plot_id` matches active plot.

**Success criteria**

- Events without plots remain `plot_id` null.

---

## I-10 — Dialogue path audit

**Goal:** Prove that raw assistant text from NPC dialogue does **not** append `KnownSecrets`, runtime secrets, hooks, or plot rows without a validated tool or post-commit path.

**Depends on:** I-06, I-08.

**Deliverables:** Code audit checklist or automated guard; logging when dialogue would attempt mutation.

**Test case (primary)**

- **Manual:** Send chat messages that **claim** a new secret; verify save unchanged; only tool path adds rows.

**Success criteria**

- Documented evidence that no code path maps free text directly to `KnownSecrets` append.

---

## I-11 — Caps and expiry

**Goal:** Enforce maximum concurrent plots; optional expiry for plot points and secrets; prevent unbounded save growth.

**Depends on:** I-01, I-02.

**Deliverables:** Config (MCM or const); cleanup on tick or daily.

**Test case (primary)**

- **Automated:** Insert N+1 plots; assert cap rejects or evicts oldest per policy.
- **Manual:** Same via debug spam.

**Success criteria**

- Save file size stays within configured bounds under stress.

---

## I-12 — Manual test specification document

**Goal:** Add `docs/INTRIGUE_TEST_SPEC.md` with TC ids mapping to slices I-01 through I-06 (primary regression set), prerequisites, steps, and success criteria aligned with this plan.

**Depends on:** I-01 through I-06 complete.

**Deliverables:** `docs/INTRIGUE_TEST_SPEC.md` only.

**Test case (primary)**

- **Review:** Document exists; each TC references one slice id; sign-off table present.

**Success criteria**

- Another engineer can run I-01–I-06 regression using only `INTRIGUE_TEST_SPEC.md` and this plan.

---

## Sign-off

| Slice | Owner | Date | Test case reference |
|-------|--------|------|---------------------|
| I-01 | | | |
| I-02 | | | |
| … | | | |

---

## Maintenance

Update this plan when a slice is split, merged, or reordered. When `INTRIGUE_SYSTEM_DESIGN.md` slices table changes, align this document’s ids and dependencies.
