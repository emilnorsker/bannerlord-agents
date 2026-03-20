# GM POC — full test specification

**Scope:** Bannerlord.GameMaster integration POC (slices 1–8): `GameMasterPocQueue`, `GameMasterCommandSerializer`, `GameMasterPocDiagnostics`, MCM Debug controls.

**Audience:** QA, mod author, or developer verifying a build before merge/release.

---

## 1. Prerequisites

| Requirement | Notes |
|-------------|--------|
| Game | Mount & Blade II: Bannerlord **1.3.x** (match mod target). |
| Mods | **AIInfluence** (this build), **Bannerlord.GameMaster** **v1.3.14.11** (or compatible; `SubModule.xml` declares hard dependency). |
| Load order | Launcher resolves `Bannerlord.GameMaster` **before** AIInfluence (declared dependency). |
| Save | **Active campaign** on the map (not main menu) for any test that runs `gm.*` (needs `Campaign.Current`). |
| MCM | **Enable Modification** = **ON** for AIInfluence, otherwise `Tick` returns early and **the POC queue is never drained** (known limitation). |
| Logs | `mod_log.txt` (or equivalent) writable; tests reference `[GM_POC]` lines. |

**OpenRouter-only tests (slice 7):**

| Requirement | Notes |
|-------------|--------|
| API key | Mod Settings → **OpenRouter** → API key set. |
| Network | Machine can reach OpenRouter. |
| Model | Whatever model is configured for OpenRouter in mod settings (must return compact JSON when asked). |

---

## 2. MCM navigation

**Path:** Mod Options → **AIInfluence** → **Debug & Fixes**

Controls under test (typical order):

| Order | Control |
|-------|---------|
| 0 | Fix Broken Pregnancies *(unrelated; ignore for GM POC)* |
| 1 | **GM POC: max queue drains per tick** (1–50) |
| 2 | **GM POC (query kingdoms)** |
| 3 | **GM POC async enqueue** |
| 4 | **GM POC batch ×3** |
| 5 | **GM POC OpenRouter plan** |
| 6 | **GM POC last observation** |

---

## 3. Test cases

### TC-01 — Baseline: single kingdom query (slice 1–3)

**Preconditions:** Campaign loaded; Enable Modification ON; BLGM loaded.

**Steps:**

1. Set **max queue drains per tick** = **1**.
2. Click **GM POC (query kingdoms)** once.

**Expected:**

- In-game: green message with **Queued job `{Guid}`**.
- Log:  
  - `[GM_POC] job {Guid} enqueued: gm.query.kingdom`  
  - `[GM_POC] job {Guid} drain (executing)`  
  - `[GM_POC] job {Guid} line: gm.query.kingdom`  
  - `[GM_POC] job {Guid} observation (runtime): …` (non-empty BLGM output, or kingdom list text — exact content version-dependent).
- Same **Guid** on all lines for that job.

**Failure cues:**

- `command 'gm.query.kingdom' not registered` → BLGM not loaded or wrong game version.
- No `drain` line after enqueue → **Enable Modification** OFF or not on campaign tick path.

---

### TC-02 — Correlation: two jobs distinct (slice 2)

**Steps:**

1. Click **GM POC (query kingdoms)** twice in quick succession (same tick or adjacent).

**Expected:**

- Two different **Guids** in toast messages.
- Log shows two independent job sequences; **no** shared Guid between the two jobs.

---

### TC-03 — Drain budget: backlog clears faster (slice 3)

**Preconditions:** Same as TC-01.

**Steps:**

1. Set **max queue drains per tick** = **1**.
2. Click **GM POC batch ×3** (queues 3 jobs).
3. Observe logs for ~3–5 application ticks: only **one** `drain (executing)` per tick until queue empty.
4. Set **max queue drains per tick** = **5**.
5. Click **GM POC batch ×3** again.

**Expected:**

- With budget **1**, three jobs spread across **at least** three ticks (usually three `drain` lines on separate log timestamps).
- With budget **5**, all three jobs can drain in **one** tick (three consecutive `drain` blocks in one frame’s worth of log — exact timing may vary).

---

### TC-04 — Async producer (slice 4)

**Preconditions:** Campaign loaded; Enable Modification ON.

**Steps:**

1. Click **GM POC async enqueue**.

**Expected:**

- Green “Async enqueue started” (or equivalent) toast.
- Log sequence matches TC-01 pattern **without** requiring the click to happen on a special thread; job still drains on main tick.
- No unhandled exception in log related to `Task.Run`.

---

### TC-05 — Locked batch (slice 5)

**Preconditions:** Campaign loaded.

**Steps:**

1. Set max drains = **10** (to drain batch in one tick for easier reading).
2. Click **GM POC batch ×3**.

**Expected:**

- Toast: “Queued 3 jobs (locked batch).”
- Log: **three** `enqueued: gm.query.kingdom` lines with **three** distinct Guids.
- All three eventually reach `observation (runtime)` or equivalent terminal line.

**Optional stress:** Rapidly click **batch ×3** and **query kingdoms** alternately many times; expect **no** crash; queue eventually drains; Guids remain unique.

---

### TC-06 — Serializer path (slice 6, implicit)

**Covered by** TC-01: enqueued line must be exactly `gm.query.kingdom` (serializer output for empty args).

**Manual code-level check (optional):** `GameMasterCommandSerializer.SerializeLine("gm.query.kingdom", new[] { "a", "b" })` in a scratch test → `gm.query.kingdom a b`; with a space in an arg → single-quoted segment.

---

### TC-07 — OpenRouter JSON → queue (slice 7)

**Preconditions:** Campaign loaded; **OpenRouter API key** set; network OK; Enable Modification ON.

**Steps:**

1. Click **GM POC OpenRouter plan**.

**Expected:**

- Toast: request started / similar success hint.
- After network latency: log contains  
  - `[GM_POC] job {Guid} from OpenRouter line: gm.query.kingdom` (or same command; model must follow prompt).  
  - Then same drain/observation sequence as TC-01 for that Guid.
- If model returns bad JSON: yellow toast or log `JSON parse: …` and raw response logged on parse failure path.

**Failure cues:**

- `OpenRouter: Error:` → key, quota, or model error.
- Parse fail with raw body in log → tighten prompt or model; not a queue bug.

---

### TC-08 — Last observation UI (slice 8)

**Preconditions:** Complete TC-01 successfully at least once.

**Steps:**

1. Click **GM POC last observation**.

**Expected:**

- Cyan (or configured) banner message containing:
  - `job {Guid}`
  - `line: gm.query.kingdom`
  - `observation:` + substring of BLGM return
  - `updated … UTC`
- If no job ran yet: message indicates **no observation recorded**.

**Steps (truncation):**

1. Run a command that returns a very long string (if you change POC to a verbose query in a dev build), then **show last observation**.

**Expected:** Banner text **truncated** (~450 chars + ellipsis) per MCM handler; full text still in `mod_log` for the job.

---

### TC-09 — Enable Modification OFF (known gap)

**Preconditions:** Campaign loaded; **Enable Modification** = **OFF**.

**Steps:**

1. Click **GM POC (query kingdoms)** (MCM may still enqueue depending on handler — it checks `Campaign.Current` only).

**Expected today:**

- If enqueue still runs: log shows **enqueued** but **no drain** until Enable Modification is ON again — queue may backlog.

**Spec intent for regression:** Either document as accepted or future fix (flush when disabled / refuse enqueue).

---

### TC-10 — No campaign

**Preconditions:** Main menu or no `Campaign.Current`.

**Steps:**

1. Open MCM; click **GM POC (query kingdoms)**.

**Expected:**

- Yellow: start a campaign first (no enqueue).

---

### TC-11 — OpenRouter without API key

**Preconditions:** Campaign loaded; **clear** OpenRouter API key.

**Steps:**

1. Click **GM POC OpenRouter plan**.

**Expected:**

- Yellow: set OpenRouter API key; **no** network call (or fail fast before hang — current code checks key in MCM handler).

---

## 4. Sign-off checklist (release smoke)

- [ ] TC-01 pass  
- [ ] TC-03 pass (budget 1 vs 5)  
- [ ] TC-04 pass  
- [ ] TC-05 pass  
- [ ] TC-07 pass **or** waived (no OpenRouter in CI)  
- [ ] TC-08 pass  
- [ ] TC-10 pass  

---

## 5. Out of scope for this spec

- Automated UI tests / headless Bannerlord.  
- Mission-only / `Campaign.Current == null` mid-mission edge cases (deferred in design doc).  
- Correctness of BLGM command semantics beyond “returns without crash.”  
- Other AI backends for slice 7 (OpenRouter only in current implementation).

---

*Update this document when POC controls or behavior change.*
