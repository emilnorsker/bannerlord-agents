# OpenRouter migration — full tracking audit

**Purpose:** Single source of truth for **(1)** what the migration changed, **(2)** every compile-time LLM call site with **line numbers**, **(3)** error-shape vs caller logic, **(4)** `EnableModification` coverage, **(5)** **numbered** defects and **silent information loss**, **(6)** re-verification commands.

**Git scope (OpenRouter-only work):** commits `179768f` … `ce51445` (inclusive), i.e.  
`feat: use OpenRouter as the only AI backend` through `docs: add OpenRouter migration tracking`.

**Not in scope:** Other commits on the branch (UI, quests, CI, etc.) unless they touch the same files.

---

## Part A — Files changed by the migration (authoritative `git diff`)

```
git diff 179768f^..ce51445 --name-status -- \
  src/AIInfluence.API/ src/AIInfluence.Diplomacy/ \
  src/AIInfluence.DynamicEvents/DynamicEventsGenerator.cs \
  src/AIInfluence/ModSettings.cs src/AIInfluence/AIInfluenceBehavior.cs \
  src/AIInfluence/NpcChatWindowVM.cs src/AIInfluence/SubModule.cs \
  docs/OPENROUTER_MIGRATION_AUDIT.md
```

| St | Path |
|----|------|
| A | `docs/OPENROUTER_MIGRATION_AUDIT.md` |
| M | `src/AIInfluence.API/AIClient.cs` |
| D | `src/AIInfluence.API/DeepSeekChatChoice.cs` |
| D | `src/AIInfluence.API/DeepSeekChatRequest.cs` |
| D | `src/AIInfluence.API/DeepSeekChatResponse.cs` |
| D | `src/AIInfluence.API/DeepSeekClient.cs` |
| D | `src/AIInfluence.API/DeepSeekMessage.cs` |
| D | `src/AIInfluence.API/KoboldCppClient.cs` |
| D | `src/AIInfluence.API/KoboldCppGenerateRequest.cs` |
| D | `src/AIInfluence.API/KoboldCppResponse.cs` |
| D | `src/AIInfluence.API/KoboldCppResult.cs` |
| D | `src/AIInfluence.API/OllamaChatRequest.cs` |
| D | `src/AIInfluence.API/OllamaClient.cs` |
| D | `src/AIInfluence.API/OllamaGenerateRequest.cs` |
| D | `src/AIInfluence.API/OllamaMessage.cs` |
| D | `src/AIInfluence.API/OllamaOptions.cs` |
| D | `src/AIInfluence.API/OllamaResponse.cs` |
| M | `src/AIInfluence.API/Player2Client.cs` |
| D | `src/AIInfluence.API/Player2UsageTracker.cs` |
| M | `src/AIInfluence.Diplomacy/KingdomStatementGenerator.cs` |
| M | `src/AIInfluence.Diplomacy/PlayerStatementAnalyzer.cs` |
| M | `src/AIInfluence.DynamicEvents/DynamicEventsGenerator.cs` |
| M | `src/AIInfluence/AIInfluenceBehavior.cs` |
| M | `src/AIInfluence/ModSettings.cs` |
| M | `src/AIInfluence/NpcChatWindowVM.cs` |
| M | `src/AIInfluence/SubModule.cs` |

### Per-file change summary (migration intent)

| File | Change |
|------|--------|
| `AIClient.cs` | Single provider: OpenRouter HTTP; removed other backends’ code paths; merged raw API; streaming comment for `json_object`. |
| Deleted `DeepSeek*` / `Ollama*` / `KoboldCpp*` | Entire alternate LLM clients + DTOs removed. |
| `Player2Client.cs` | Removed LLM chat completions + chat-based connection test; kept TTS + heartbeat. |
| `Player2UsageTracker.cs` | **Deleted** (unused; side effects / anti-tamper removed). |
| `ModSettings.cs` | Removed backend dropdowns + non-OpenRouter provider fields; Player2 hints = TTS only. |
| `AIInfluenceBehavior.cs` | `SendAIRequest*` renames/signature cleanup; direct OpenRouter; setting-handler removals as applicable. |
| `NpcChatWindowVM.cs` | Streaming always on + finalize when no partial pump. |
| `SubModule.cs` | Removed dead `_backendCheckTimer` / interval. |
| `KingdomStatementGenerator.cs` / `PlayerStatementAnalyzer.cs` | `SendAIRequestForFeature`; no provider string. |
| `DynamicEventsGenerator.cs` | Same. |

---

## Part B — Master table: every LLM invocation (compile-time)

**Convention:** `AIClient` is the **only** HTTP LLM implementation remaining.

| # | File:line | Call expression | Wrapper / notes |
|---|-----------|-----------------|-----------------|
| 1 | `AIInfluenceBehavior.cs:213` | `AIClient.GetAIResponse` **or** `GetRawTextResponse` | Inside `SendAIRequest`; if `requestType == "multi_dialogue_analysis"` → raw only. |
| 2 | `AIInfluenceBehavior.cs:238` | `AIClient.GetRawTextResponse(prompt, cachePrefixLength)` | `SendAIRequestForFeature`. |
| 3 | `AIInfluenceBehavior.cs:269` | `AIClient.GetRawTextResponse(prompt)` | `SendAIRequestRaw`. |
| 4 | `AIInfluenceBehavior.cs:2793` | `AIClient.GetAIResponse(...)` **no stream** | World / dynamic NPC dialogue path; retry loop. |
| 5 | `AIInfluenceBehavior.cs:3330` | `AIClient.GetAIResponse(..., streamCallback)` | `ProcessChatInput`; retry loop. |
| 6 | `AIInfluenceBehavior.cs:4921` | `SendAIRequestRaw` (async task) | Quest debug; `Task.Run` + 45s timeout. |
| 7 | `ModSettings.cs` (TestOpenRouter) | `AIClient.TestOpenRouterConnection()` | MCM button. |
| 8 | `DeathHistoryBehavior.cs:104` | `SendAIRequest(..., "history_gen")` | Uses row 1 → `GetAIResponse`. |
| 9–12 | `NPCInitiativeSystem.cs:963,1525,1967,2183` | `SendAIRequest` | Same. |
| 13–14 | `SettlementCombatManager.cs:581,2326` | `SendAIRequestRaw` | Row 3. |
| 15 | `DynamicEventsAnalyzer.cs:1074` | `SendAIRequestRaw` | Row 3. |
| 16–19 | `DynamicEventsGenerator.cs:228,289,1813,4133` | `SendAIRequestForFeature` | Row 2. |
| 20 | `KingdomStatementGenerator.cs:1816` | `SendAIRequestForFeature(..., cachePrefixLength)` | Row 2. |
| 21 | `PlayerStatementAnalyzer.cs:42` | `SendAIRequestForFeature` | Row 2. |

**Total direct `AIClient` surface:** `GetAIResponse`, `GetRawTextResponse`, `TestOpenRouterConnection`.  
**Total call sites through wrappers:** table rows 1–21 (excluding MCM test).

---

## Part C — Error shapes (exact) and what callers assume

### C.1 Shape definitions

| ID | Shape | Produced by | First bytes / example |
|----|--------|-------------|------------------------|
| S1 | JSON error envelope | `GenerateErrorResponse(msg)` in `AIClient.cs` ~242–255 | `{` … `"Response":"…"` |
| S2 | Plain error string | `GetRawTextResponse` catch ~40–43 | `Error: AI request failed: …` |
| S3 | Raw HTTP-style | `GetOpenRouterRawResponse` catch ~235–238 | `Error: ` + `ex.Message` (no response body) |
| S4 | Missing key (raw) | `GetOpenRouterRawResponse` ~187–190 | `API key is missing.` — **does not** start with `Error:` |
| S5 | `null` | `SendAIRequestForFeature` / `SendAIRequestRaw` **catch** in behavior ~259 | `null` |
| S6 | Success model output | HTTP 200 body | JSON or text per prompt |

### C.2 `SendAIRequest` predicate (`AIInfluenceBehavior.cs` ~215–222)

```csharp
if (!string.IsNullOrEmpty(response) && !response.StartsWith("Error:"))
    return response; // logged SUCCESS
return null;
```

| Response | `StartsWith("Error:")` | `SendAIRequest` returns | Log line |
|----------|-------------------------|---------------------------|----------|
| S1 JSON | **false** | **String (JSON)** as “success” | SUCCESS |
| S2 | **true** | `null` | ERROR |
| Empty | — | `null` | ERROR |

**Impact [ERR-001]:** S1 is **indistinguishable** from success JSON by this predicate. Callers using only `StartsWith("Error:")` **do not** treat S1 as failure.

### C.3 Retry loops (`ProcessChatInput` ~3320–3334, world map ~2788–2816)

Break condition: `!string.IsNullOrEmpty(aiResponse) && !aiResponse.StartsWith("Error:")`.

**Impact [ERR-002]:** S1 satisfies break → **no retry** on provider-side failure returned as JSON envelope.

### C.4 `SendAIRequestForFeature` / `SendAIRequestRaw` (~246–250, 276–279)

They check `response.StartsWith("Error:")` — **matches S2/S3**; **S4** (`API key is missing.`) **does not** match → treated as **success string** downstream [ERR-003].

### C.5 `EnableModification`

| Function | Checks `EnableModification`? |
|----------|------------------------------|
| `GetOpenRouterResponse` | **Yes** (~77–80) |
| `GetOpenRouterRawResponse` | **No** |

**Impact [ERR-004]:** Raw path can still POST if invoked while “Enable Modification” is false.

---

## Part D — Numbered defect & information-loss register

| ID | Severity | Title | Detail |
|----|----------|-------|--------|
| ERR-001 | **High** | `SendAIRequest` vs S1 | JSON errors logged as SUCCESS; callers with `StartsWith("Error:")` miss API failure. |
| ERR-002 | **High** | Retries vs S1 | Retry loops exit on first S1; transient failures not retried. |
| ERR-003 | **Medium** | `API key is missing.` | Not `Error:`-prefixed; `SendAIRequestForFeature` may pass through as “success” body. |
| ERR-004 | **Medium** | Raw path vs MCM disable | `GetOpenRouterRawResponse` ignores `EnableModification`. |
| ERR-005 | **Medium** | Exception → `null` | `SendAIRequestForFeature` catch returns `null`; many callers use `IsNullOrEmpty` only — **exception text** only in behavior log, not in return value. |
| ERR-006 | **Medium** | HTTP body discarded | `GetOpenRouterRawResponse` catch returns `ex.Message` only; OpenRouter JSON error body **lost** to caller. |
| ERR-007 | **Medium** | Shared `HttpClient` auth | `DefaultRequestHeaders.Authorization` set per call; concurrent requests can race (intermittent wrong bearer). |
| ERR-008 | **Low** | Non-stream `dynamic` | `responseObject.choices[0]...` throws → caught → S1 generic message; **provider body** not embedded in S1. |
| ERR-009 | **Low** | Stream `JObject.Parse` | Malformed SSE line throws → same inner catch → S1. |
| ERR-010 | **Low** | `TestOpenRouterConnection` | Non-success: status + body **shown** in game message (good); catch shows exception (good). |

### Silent sinks (LLM-adjacent UI / infra)

| ID | File:line | What is swallowed |
|----|-----------|-------------------|
| SIL-001 | `NpcChatWindowVM.cs` ~736 | `catch (Exception) { }` when reading `playerHistoryIdx` — **silent** (no log). |
| SIL-002 | `NpcChatWindowManager.cs` ~75 | Empty catch (verify line in file). |
| SIL-003 | `SubModule.cs` ~61–63, ~77–79 | Harmony patch failures **silent** (startup may partially patch). |
| SIL-004 | `Player2Client.cs` ~141–143 | Timer dispose — empty catch (low risk). |

---

## Part E — `AIClient.cs` catch blocks (what is preserved vs lost)

| Lines | Catch | Logged | Returned to caller | Lost |
|-------|-------|--------|---------------------|------|
| 27–30 | `GetAIResponse` outer | `ex.Message` | S1 with inner message text | Stack / inner exception detail not in JSON |
| 40–43 | `GetRawTextResponse` outer | yes | S2 | Same |
| 178–181 | `GetOpenRouterResponse` inner | `LogError(ex.Message)` | S1 generic user text | **HTTP response body** from OpenRouter |
| 235–238 | `GetOpenRouterRawResponse` | `LogError` | S3 | **Full error payload** |
| 297–301 | `TestOpenRouterConnection` | in-game message | `false` | OK for test |

---

## Part F — Dynamic events: empty + error branches (logic trap)

In `DynamicEventsGenerator.cs`, patterns like:

```csharp
if (string.IsNullOrEmpty(dialogueAiResponse)) {
    if (dialogueAiResponse != null && (dialogueAiResponse.Contains("API key is missing") || dialogueAiResponse.Contains("Error:")))
```

When `dialogueAiResponse` is **`null`** (exception path from wrapper), the **inner** `if` is **false** — scheduling retry only happens when string is non-null **and** contains markers. **Exception** was already logged in `SendAIRequestForFeature`; **caller** still only sees “empty” [ERR-005].

---

## Part G — Re-verification commands (run after any change)

```bash
# All LLM wrapper / client calls
rg -n 'SendAIRequest|AIClient\.Get|GetRawTextResponse' src --glob '*.cs'

# Error: checks (audit drift)
rg -n 'StartsWith\(\"Error:' src --glob '*.cs'

# EnableModification near AI
rg -n 'EnableModification' src/AIInfluence.API/AIClient.cs src/AIInfluence/AIInfluenceBehavior.cs

# Migration file list
git diff 179768f^..HEAD --name-status -- src/AIInfluence.API/ \
  src/AIInfluence.Diplomacy/ src/AIInfluence.DynamicEvents/DynamicEventsGenerator.cs \
  src/AIInfluence/ModSettings.cs src/AIInfluence/NpcChatWindowVM.cs src/AIInfluence/SubModule.cs
```

---

## Part H — Runtime checklist (not done in CI)

- [ ] Bad / missing OpenRouter key: chat, event gen, diplomacy — **expected** user-visible behavior documented?
- [ ] MCM “Enable Modification” off: confirm **raw** paths blocked or not (product decision).
- [ ] Old `AIInfluence` JSON settings load without exception after removing keys.
- [ ] Concurrent LLM calls (e.g. debug quest + chat) — watch for 401 / wrong key if race exists.

---

## Part I — Changelog (append only)

| Date | Commit | Note |
|------|--------|------|
| — | `179768f` | OpenRouter-only LLM; delete other providers’ client code. |
| — | `4439f27` | Remove MCM backend dropdowns. |
| — | `8b53a53` | Rename API surface; remove `OpenRouterBackendId`; SubModule dead fields. |
| — | `1189451` | Delete `Player2UsageTracker`; strip Player2 LLM from `Player2Client`. |
| — | `a70601a` | Streaming `json_object` comment; NpcChat finalize if no pump. |
| — | `ce51445` | Initial audit doc. |
| — | *(this edit)* | Full register: Parts A–I, ERR/SIL IDs, master table, git scope. |

---

*Update this file when fixing ERR-### or when adding new LLM call sites.*
