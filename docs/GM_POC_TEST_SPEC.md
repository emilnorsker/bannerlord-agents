# Bannerlord.GameMaster (BLGM) POC — manual test specification

**Audience:** engineers and QA validating the **GameMaster proof-of-concept queue** inside AIInfluence (or a sibling build) before NPC Chat / World Events paths emit real plans.

**Tone:** this is a **test contract**. It assumes the architecture in the BLGM integration design notes: **two completion paths** (NPC Chat vs World Events) exist conceptually, but **slices 1–8** exercise only the **POC executor** (queue, drain, serializer stub, OpenRouter debug hop, diagnostics). Later slices extend this spec.

**Document status:** update when slice numbers, MCM labels, or log prefixes change. Failed runs attach **correlation ids** and **log excerpts** to the bug.

---

## What this spec validates (and does not)

**In scope for TC-01–TC-11**

- **Thread safety pattern:** async producers may enqueue; **only** the agreed drain site (e.g. `AIInfluenceBehavior.Tick`) consumes the queue on the simulation thread.
- **Correlation:** every batch has a **Guid**; logs for enqueue, serialize, and `CallFunction` return share it so parallel work does not cross streams.
- **Drain budget:** configurable max drains per tick prevents frame spikes when batches grow.
- **Serializer v1:** structured JSON (OpenRouter-shaped DTO) → exact BLGM line → local validation before execution.
- **Observations:** ground truth for “what the console returned” comes from **runtime**, appended/logged—not from assistant prose pretending to be output.
- **Diagnostics surface:** testers can confirm the loop without tailing `mod_log` alone (MCM readonly field / overlay / message).

**Out of scope for TC-01–TC-11**

- **NPC Chat** and **World Events** paths wiring plans into live prompts (slice 9–10).
- **Hazard index**, **full command index**, **RAG**, **MissionGM**, **campaign lifecycle queue policy** on save load.
- **Automated** golden tests for the serializer (deferred per design notes); this spec is **manual** unless noted.

---

## Prerequisites (every session)

1. **Game:** Mount & Blade II: Bannerlord, version pinned to whatever your mod targets (record in run notes).
2. **Mods loaded (minimum):** `Bannerlord.Harmony`, `Bannerlord.UIExtenderEx`, Native stack, **Bannerlord.GameMaster** (load order: GameMaster **before** AIInfluence per `SubModule.xml` design).
3. **AIInfluence build** containing POC types: `GameMasterPocQueue`, `GameMasterCommandSerializer`, `GameMasterPocDiagnostics`, MCM Debug entries for GM POC.
4. **Campaign:** load or start any save where `Campaign.Current` is non-null (some TCs only need main menu + tick; others need in-game).
5. **Logging:** `mod_log.txt` (or dedicated channel if slice 13 landed) writable; note log path from MCM **Open Logs Folder** if available.
6. **OpenRouter (TC-07 only):** valid API key in MCM, network allowed; if skipped, mark TC-07 **N/A** and record why.

**Baseline MCM settings for a clean run**

- Enable mod / modification ON.
- **GM POC** debug section: record defaults for **max queue drains per tick**, any **async** / **batch** toggles you use during TCs.

---

## Log conventions (how to read passes)

- **Prefix:** `[GM_POC]` (or current code prefix—if renamed, replace throughout this doc).
- **Correlation id:** expect a **Guid** on: enqueue start, each serialized line (if batch), `CallFunction` invocation, raw return capture, observation append.
- **Failure classes (distinct):**
  - **A — Schema / parse failure:** JSON did not match DTO; serializer rejected before BLGM.
  - **B — Policy failure:** parsed but command not allowlisted or failed preflight syntax check.
  - **C — BLGM execution failure:** line reached `CallFunction` but engine returned error/help text.
  - **D — Infrastructure:** null campaign, missing GameMaster, crash.

Bug reports must state **A/B/C/D** and paste the **correlation block**.

---

## Sign-off checklist (release gate for POC slice pack)

Use after TC-01–TC-08 pass on a reference machine; TC-09–TC-11 strongly recommended.

- [ ] All executed TCs recorded in a run log (date, build hash, game version).
- [ ] No unhandled exceptions in `mod_log` during drain.
- [ ] Correlation ids present for every enqueue in sampled runs.
- [ ] At least one successful **read-only** `gm.query.*` observation captured (stdout/help text from engine).
- [ ] Serializer rejection (TC-09) produces **no** `CallFunction` call (prove with log: no BLGM line for that id).
- [ ] OpenRouter hop (TC-07) either **pass** or **documented N/A** with reason.

---

## Test cases

### TC-01 — Fixed read-only probe: queue, single drain, log-only observation

**Objective:** Prove one enqueue → one drain per tick (default budget 1) executes a **read-only** query and logs the **real** return string.

**Prerequisites:** In campaign; GameMaster installed; POC MCM button **GM POC: enqueue read-only kingdom query** (or equivalent label from slice 1).

**Steps**

1. Clear or mark tail of `mod_log.txt`.
2. Open MCM → Debug → GM POC section.
3. Press the slice-1 button that enqueues `gm.query.kingdom` (or documented equivalent).
4. Advance time **one** application tick (stay paused or unpause one frame—use minimal advance per team practice).
5. Repeat step 4 until one drain occurs (usually same frame as tick if queue was pending).

**Expected**

- Log line with `[GM_POC]` showing enqueue with a **Guid**.
- Within the same correlation id, a serialized BLGM line matching serializer output for that query.
- A following line or block with **raw return** from `CallFunction` (may be multi-line kingdom dump or help text—content varies by game state; **presence** matters, not exact copy).
- **No** relation change, gold change, or party mutation attributable to this action.

**Failure indicators:** no drain after N ticks; duplicate drains for one enqueue; crash; observation text obviously LLM-authored (should not occur in TC-01—no LLM).

---

### TC-02 — Correlation id end-to-end

**Objective:** Enqueue two probes **back-to-back**; logs prove **two distinct Guids** and no interleaving of returns between them.

**Prerequisites:** TC-01 passing.

**Steps**

1. Tail `mod_log`.
2. Press read-only enqueue **twice** in quick succession (same MCM button as TC-01).
3. Allow **two** ticks with drain budget ≥ 1 (or one tick if budget allows two drains—**record which**).

**Expected**

- Two correlation ids **≠** each other.
- For each id: enqueue → serialize → return sequence complete before the other id’s return appears (no crossed stdout).

**Failure indicators:** shared id; return block under wrong id.

---

### TC-03 — Drain budget caps work per tick

**Objective:** With **max queue drains per tick = 1**, a burst enqueue of **three** items leaves **two** pending until subsequent ticks.

**Prerequisites:** MCM **GM POC: max queue drains per tick** = 1. Three items enqueued (MCM **batch ×3** read-only probe if slice 5 provides it, or triple-click single enqueue—**document method**).

**Steps**

1. Set drain budget to **1**.
2. Enqueue **three** read-only jobs (locked batch enqueue preferred—TC-05—or three manual clicks; state which).
3. Observe logs across **three** consecutive drain opportunities (ticks).

**Expected**

- Exactly **one** `CallFunction` per tick for three ticks (or until queue empty).
- After tick 3, queue depth **zero** (log may expose depth—if not, infer from three distinct completes).

**Failure indicators:** three executes one tick; starvation (never completes third).

---

### TC-04 — Async producer stress

**Objective:** Enqueue from a **thread-pool** path (MCM **GM POC async enqueue** stub) does not corrupt the queue and still drains on main thread.

**Prerequisites:** Slice 4 button present.

**Steps**

1. Press async enqueue (or trigger documented `Task.Run` path) **10×** rapidly.
2. Let campaign run **several** seconds of ticks.

**Expected**

- No exception in log from `ConcurrentQueue` / concurrent modification.
- Eventually **10** correlation completes (order may vary—**count** matters).
- No duplicate or dropped ids when compared to enqueue count (if enqueue logs each id).

**Failure indicators:** `InvalidOperationException`, fewer than 10 completes, deadlock.

---

### TC-05 — Batch enqueue lock (no interleaved lines from two completions)

**Objective:** Simulate two concurrent “plans” each batching **three** lines; locking ensures lines from plan A are not interleaved with plan B in the queue.

**Prerequisites:** MCM **GM POC batch ×3** locked enqueue; a way to fire **two** batches overlapping (e.g. two async completions stubbed, or double-button mash documented by engineering).

**Steps**

1. Trigger batch A (3 lines) and batch B (3 lines) with overlap as defined by implementer.
2. Drain until empty.

**Expected**

- Log shows for each correlation id a **contiguous** triple of serialized lines before the other id’s triple begins (order between batches unspecified).

**Failure indicators:** `line1A, line1B, line2A…` pattern in log order.

---

### TC-06 — Serializer v1: valid DTO → line → execution

**Objective:** Structured DTO (JSON) round-trips: parse → `SerializeLine` → string passes local validation → `CallFunction` receives exact format BLGM expects (single quotes, `name:value` rules per wiki).

**Prerequisites:** Slice 6; MCM or dev hook that feeds **one frozen good JSON** plan (not LLM).

**Steps**

1. Trigger **frozen good JSON** path (document file name / MCM label).
2. Capture log: parsed fields, serialized line, return.

**Expected**

- No schema error.
- Serialized line matches golden expectation for that fixture (team maintains **one** golden string per fixture in repo or wiki).
- BLGM returns **something** (success or in-engine error message)—either is fine; **C** class failures are still a **pass** for serializer slice if the line was valid BLGM syntax.

**Failure indicators:** **A** class before `CallFunction`; double-quote wrapping where BLGM forbids; spaces around `:` in named args.

---

### TC-07 — Debug OpenRouter hop (LLM → parse → serialize → enqueue → observe)

**Objective:** One real completion returns JSON matching DTO; host parses, serializes, enqueues, drains, logs observation.

**Prerequisites:** OpenRouter key; MCM **GM POC OpenRouter plan**; network.

**Steps**

1. Configure provider per mod docs.
2. Press OpenRouter plan button once.
3. Wait for async completion + drain.

**Expected**

- Correlation id threads from HTTP completion through enqueue.
- If model returns invalid JSON, log shows **A** class and **no** BLGM call—or documented fallback behavior.
- If valid: same chain as TC-06 plus proof the **producer** was LLM.

**Failure indicators:** silent skip; BLGM called with non-serializer line; hang with no timeout log.

---

### TC-08 — Observation visibility (in-game diagnostics)

**Objective:** Last observation visible in MCM readonly field / overlay / message (`GameMasterPocDiagnostics`).

**Prerequisites:** TC-01 passing.

**Steps**

1. Run TC-01 once.
2. Open MCM → read **GM POC last observation** (exact label per implementation).

**Expected**

- Text **matches** (or faithfully truncates) the latest raw `CallFunction` return shown in log for that correlation.

**Failure indicators:** stale text; LLM filler; empty after successful TC-01.

---

### TC-09 — Invalid JSON: reject before BLGM

**Objective:** Malformed plan JSON never reaches `CallFunction`.

**Prerequisites:** Dev inject or MCM “bad JSON” fixture.

**Steps**

1. Trigger bad JSON path.
2. Search log for correlation id.

**Expected**

- **A** class log entry; explicit “parse failed” or validator message.
- **No** `CallFunction` line for that id.

**Failure indicators:** BLGM invoked; crash.

---

### TC-10 — Schema valid but policy forbidden command

**Objective:** DTO parses and serializes to a syntactically valid line that **policy** rejects (disabled command or allowlist block).

**Prerequisites:** One forbidden fixture (e.g. mutate command disabled for POC).

**Steps**

1. Trigger forbidden fixture.
2. Inspect log.

**Expected**

- **B** class (policy) rejection before `CallFunction`, **or** execution blocked with clear log reason—**product decision**; document which. Preferred: **no** `CallFunction` for forbidden.

**Failure indicators:** command runs.

---

### TC-11 — Parallel OpenRouter completions (if TC-07 enabled)

**Objective:** Two overlapping HTTP completions produce **two** correlation ids; observations and logs do not cross.

**Prerequisites:** TC-07 passing; slow model or artificial delay acceptable.

**Steps**

1. Fire OpenRouter plan **twice** without waiting for first to finish.
2. Wait for both drains.

**Expected**

- Two Guids; each return block matches its plan only.

**Failure indicators:** same Guid reused; mixed observations.

---

## After POC (forward reference)

When **slice 9–10** land, add **TC-12** (NPC Chat snapshot shape) and **TC-13** (World Events snapshot shape): same queue executor, different snapshot builder and allowlist table. Do not reuse NPC Chat correlation ids for World Events jobs without explicit path tag in log.

---

## References

- BLGM integration design notes (internal): two paths, six layers, constraints, slice table.
- BLGM wiki / command syntax: <https://github.com/SolWayward/Bannerlord.GameMaster/wiki>
- BLGM API reference: <https://solwayward.github.io/Bannerlord.GameMaster/api/index>

---

*Manual QA sign-off: name, date, build, game version, TC results table (pass/fail/N/A + notes).*
