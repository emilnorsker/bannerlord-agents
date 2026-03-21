# OpenRouter-only migration — tracking audit

**Purpose:** Single place to track **compile-time LLM call sites**, **error-shape vs caller checks**, **policy gaps** (`EnableModification`), **silent failure / information loss**, and **PR-scoped changes**.  
**Scope:** `src/` as of branch work; **not** validated in-game unless noted.

---

## 1. Migration summary (behavioral)

| Topic | Before (multi-backend) | After (this work) |
|--------|-------------------------|-------------------|
| LLM provider | MCM chose OpenRouter / DeepSeek / Player2 / Ollama / KoboldCpp | **OpenRouter only** (HTTP to `openrouter.ai`) |
| MCM | Multiple backend dropdowns + provider API fields | **Removed** backend dropdowns; OpenRouter model + key; Player2 URL for **TTS/heartbeat** only |
| `Player2Client` | Had **chat completions** + TTS | **Removed** LLM/chat test paths; **kept** `/v1/health`, `/v1/tts/speak` |
| `Player2UsageTracker` | Unused singleton + `.p2usage` file + anti-tamper scaffolding | **File removed** entirely |
| Constants | e.g. `ModSettings.OpenRouterBackendId` (later removed) | Call sites use `SendAIRequestForFeature` **without** provider id parameter |

---

## 2. Compile-time LLM entry points (exhaustive `grep`)

### 2.1 `AIClient` (only network LLM implementation)

| Symbol | File |
|--------|------|
| `GetAIResponse` | `src/AIInfluence.API/AIClient.cs` |
| `GetRawTextResponse(prompt, cachePrefixLength = 0)` | same |
| `TestOpenRouterConnection` | same |

### 2.2 Direct callers of `AIClient` (non-wrapper)

| Location | Call |
|----------|------|
| `ModSettings.cs` | `AIClient.TestOpenRouterConnection()` |
| `AIInfluenceBehavior.cs` | `AIClient.GetAIResponse` (×2), `GetAIResponse` with stream callback (×1) |

### 2.3 `AIInfluenceBehavior` wrappers

| Method | Implements via |
|--------|----------------|
| `SendAIRequest` | `GetAIResponse` **or** `GetRawTextResponse` if `requestType == "multi_dialogue_analysis"` |
| `SendAIRequestForFeature` | `GetRawTextResponse(prompt, cachePrefixLength)` |
| `SendAIRequestRaw` | `GetRawTextResponse(prompt)` |
| Quest debug | `Task.Run` + `SendAIRequestRaw` + `Task.WhenAny` timeout |

### 2.4 Callers of wrappers (all call sites)

| File | Method / context | Wrapper used |
|------|-------------------|--------------|
| `AIInfluenceBehavior.cs` | World-map / dynamic NPC input (~2793) | `GetAIResponse` direct |
| `AIInfluenceBehavior.cs` | `ProcessChatInput` (~3330) | `GetAIResponse` + stream |
| `AIInfluenceBehavior.cs` | Quest debug (~4921) | `SendAIRequestRaw` |
| `DeathHistoryBehavior.cs` | `GenerateAndShowHistory` | `SendAIRequest` |
| `NPCInitiativeSystem.cs` | messenger, letter, hostile, neutral (~963, 1525, 1967, 2183) | `SendAIRequest` |
| `SettlementCombatManager.cs` | ×2 | `SendAIRequestRaw` |
| `DynamicEventsAnalyzer.cs` | `SendAnalysisToAI` | `SendAIRequestRaw` |
| `DynamicEventsGenerator.cs` | ×4 | `SendAIRequestForFeature` |
| `KingdomStatementGenerator.cs` | `GetAIStatement` | `SendAIRequestForFeature` |
| `PlayerStatementAnalyzer.cs` | `AnalyzePlayerStatement` | `SendAIRequestForFeature` |

**Count:** 1 + 2 + 1 + 4 + 4 + 2 + 1 + 4 + 1 + 1 = **direct + indirect** as per grep; **no** remaining alternate LLM DLL paths.

---

## 3. Error-shape taxonomy (validated in source)

### 3.1 Shape A — JSON envelope (`GenerateErrorResponse`)

**Source:** `AIClient.GenerateErrorResponse` → `JsonConvert.SerializeObject(new AIResponse { Response = message, ... })`  
**First character:** `{` (never `"Error:"`).

**Used when:** `GetOpenRouterResponse` / `GetAIResponse` path fails inside inner `try` (HTTP, parse, stream) **or** `GetAIResponse` outer catch.

### 3.2 Shape B — Plain string `"Error: …"`

**Source:** `GetRawTextResponse` outer catch → `"Error: AI request failed: " + ex.Message`; also `GetOpenRouterRawResponse` inner catch → `"Error: " + ex.Message`; `SendAIRequestRaw` / `SendAIRequestForFeature` synthesize empty errors.

**First characters:** `"Error:"`

### 3.3 Shape C — `null`

**Source:** `SendAIRequest` when response is “failure” (see §4.1); `SendAIRequestForFeature` / `SendAIRequestRaw` **catch** blocks return `null` (exception).

### 3.4 Shape D — HTTP success body (model output)

JSON or text as returned by API; dialogue path expects **JSON** matching `AIResponse` for `CleanJsonResponse` / deserialize.

---

## 4. `SendAIRequest` — predicate vs shapes (critical)

**Code:** `AIInfluenceBehavior.cs` ~215–222

```text
if (!string.IsNullOrEmpty(response) && !response.StartsWith("Error:"))
    → SUCCESS: return response
else
    → FAILURE: return null
```

| Incoming `response` | `StartsWith("Error:")` | Result | Logged as |
|---------------------|-------------------------|--------|-----------|
| Shape A (JSON error) | **false** | **Returned as success** | `[SEND_AI_REQUEST_SUCCESS]` |
| Shape B | **true** | `null` | error |
| Empty string | `IsNullOrEmpty` true | `null` | error |
| Shape D (valid JSON) | false | returned | success |

**Implication:** `SendAIRequest` **does not** distinguish Shape A (failure JSON) from Shape D (valid JSON) by string prefix. Downstream callers that only check `StartsWith("Error:")` **will not** route to “hard failure” for Shape A; they typically **parse JSON** and may surface `Response` text as **in-world text** (UX issue), not a dedicated error screen.

**Retry loops** that use `!aiResponse.StartsWith("Error:")` (e.g. `ProcessChatInput` ~3331, world map ~2794) **will not retry** when the API returns Shape A from `GetOpenRouterResponse`’s inner catch — because the string **does not** start with `"Error:"`.

**Note:** This coupling predates “OpenRouter-only” unless historical `GetAIResponse` used a different error format; **git history** required to claim regression vs pre-existing.

---

## 5. `SendAIRequestForFeature` / `SendAIRequestRaw`

**Checks:** `string.IsNullOrEmpty` then `response.StartsWith("Error:")` — **aligned** with Shape B from `GetRawTextResponse`.

**Exception path:** returns **`null`** (not `"Error: …"`). Callers often use `string.IsNullOrEmpty(aiResponse)` → treats **`null`** like **empty** → **exception message only** in `SendAIRequestForFeature` log, not always in caller-facing log.

---

## 6. `EnableModification` vs LLM calls

| Layer | Checks `EnableModification`? |
|--------|-------------------------------|
| `GetOpenRouterResponse` (dialogue-style JSON) | **Yes** (~77–80) |
| `GetOpenRouterRawResponse` | **No** (only API key) |
| `ProcessChatInput` / world-map dialogue | Gated by **behavior** / game flow in many places; **raw path** can still run if code invoked |

**Policy gap:** Disabling “Modification” in MCM blocks **structured dialogue** path in `AIClient`, but **any** code that only calls `GetRawTextResponse` / `SendAIRequestForFeature` / `SendAIRequestRaw` **can still hit OpenRouter** if those entry points are reached.

---

## 7. Silent information loss & weak error visibility

### 7.1 HTTP response body dropped on failure

**Where:** `AIClient` inner `catch` returns `GenerateErrorResponse("…Try again later.")` or generic message — **does not** append `response.Content` from OpenRouter to the **returned string** (user sees generic JSON `Response`).

**Loss:** Provider error JSON / status details unless logged elsewhere.

### 7.2 `null` from `SendAIRequestForFeature` / `SendAIRequestRaw` conflated with empty

**Where:** Multiple callers: `if (string.IsNullOrEmpty(aiResponse))` — **`null`** (exception) and **`""`** are treated the same; user-facing text often “empty” without distinguishing **exception**.

**Exception is logged** inside `SendAIRequestForFeature` (~258) but **not** returned to caller.

### 7.3 `DynamicEventsGenerator` empty branch

**Pattern:** `if (string.IsNullOrEmpty(dialogueAiResponse)) { if (dialogueAiResponse != null && ...)` — inner `Contains("Error:")` **never runs** when `dialogueAiResponse` is **`null`**. Relies on **prior** logging in wrapper. **Not** a logic bug; **redundant** inner check when `IsNullOrEmpty` already true for null — **dead** for the `null` case.

### 7.4 Empty `catch` blocks (grep)

| File | Note |
|------|------|
| `NpcChatWindowVM.cs` ~736 | `catch (Exception) { }` — **swallows** exception when resolving `playerHistoryIdx` |
| `NpcChatWindowManager.cs` ~75 | same pattern |
| `SubModule.cs` ~61–63, ~77–79 | Harmony `PatchAll` / optional patch — **silent** failure to patch |
| `DialogManager.cs` ~422 | `EndConversation` try/catch empty |
| `Player2Client.cs` ~141–143 | `catch` empty on timer dispose — low risk |

### 7.5 Shared `HttpClient` + `DefaultRequestHeaders.Authorization`

**Risk:** Concurrent async calls can **race** on mutating default headers on one `HttpClient` instance (`AIClient` + `Player2Client` each have their own static client — **cross-call** race still within each).

**Loss:** Wrong bearer on a request under overlap — **intermittent** 401s; **not** logged as “wrong auth” if server returns 401 body discarded.

---

## 8. NpcChat streaming finalize (post-fix behavior)

**Intent:** If **no** partial chunks started `streamPumpActive`, `doFinalize()` runs **immediately** after `ProcessChatInput` returns — avoids stuck placeholder bubble.

**Residual risk:** `streamPumpActive == true` + `DelayedTaskManager` may **overlap** with synchronous `streamPumpStep()` — possible **UI flicker**; **not** a silent failure, hard to prove without runtime.

---

## 9. Files removed / added (PR tracking)

| Action | Path |
|--------|------|
| Removed | `src/AIInfluence.API/Player2UsageTracker.cs` |
| Removed | DeepSeek / Ollama / KoboldCpp client + DTOs (see git history) |
| Removed | `Player2Client` chat completions + connection test via chat API |
| Changed | `AIClient.cs`, `ModSettings.cs`, `AIInfluenceBehavior.cs`, `NpcChatWindowVM.cs`, diplomacy/dynamic-events call sites, `SubModule.cs` |

---

## 10. Recommended follow-ups (not implemented here)

1. **Unify failure contract:** e.g. `TryParseLLMFailure(string body, out string userMessage)` or always use Shape B for failures from `GetAIResponse` too — **breaking** callers.
2. **Retries:** Base retry on **parsed** JSON error field or `response.IsSuccessStatusCode` log — not `StartsWith("Error:")` alone.
3. **`EnableModification`:** Apply same gate in `GetOpenRouterRawResponse` if product requires **no network** when mod disabled.
4. **Per-request auth:** `Authorization` on `HttpRequestMessage` instead of `HttpClient.DefaultRequestHeaders`.
5. **Runtime QA:** Load old MCM JSON; **one** forced 401/429 from OpenRouter; verify chat + events + diplomacy.

---

## 11. Review checklist (copy/paste)

- [ ] All rows in §2.4 still grep-match after merge.
- [ ] Confirm with `git blame` whether §4 retry/`Error:` mismatch is **new** or **legacy**.
- [ ] In-game: mod disabled → confirm whether **raw** LLM features still fire (§6).
- [ ] Load **pre-migration** `AIInfluence` settings JSON → MCM opens without exception.

---

*Generated for ongoing PR tracking; update this file when fixing items in §10.*
