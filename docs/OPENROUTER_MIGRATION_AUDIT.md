# OpenRouter migration — source audit (evidence-tagged)

**What this document is:** A **static** audit of the **current** `src/` tree: what the code **does** on paper, with **every substantive claim tagged**.

**What this document is not:** Proof of in-game behavior, MCM serialization, network timing, or “no bugs in production.” Those require **you** running Bannerlord and/or tests we cannot run here.

**Honesty policy**

| Tag | Meaning |
|-----|--------|
| **SRC** | Statement is backed by **quoted or cited** code in this repo (file + line or short excerpt). |
| **INF** | **Inference** from documented .NET / HTTP behavior or logical follow-on from **SRC** — not observed in a running game. |
| **NRV** | **Not verified** in this environment (needs runtime, git history compare, or external tool). |

If a line has **no tag**, treat it as **narrative** (organizational only), not evidence.

---

## 1. Scope of the migration (git) — **SRC**

**Command used:** `git diff 179768f^..HEAD --name-status` on migration-related paths (see repo history).

**Files touched by OpenRouter-only commits** include: `AIClient.cs`, deleted alternate-provider files, **deleted** `Player2Client.cs` + `VoiceInfo.cs` (Player2/TTS companion removed), deleted `Player2UsageTracker.cs`, `ModSettings.cs`, `AIInfluenceBehavior.cs`, `NpcChatWindowVM.cs`, `SubModule.cs`, `TtsLipSyncService.cs` (PrepareAsync no-op), `NPCInitiativeSystem.cs`, diplomacy + `DynamicEventsGenerator.cs`, and this doc.

**SRC:** `ModSettings.EnableTTS` / `TTSSpeed` / etc. remain as **stub properties** (always disabled / fixed defaults) so existing saves and call sites compile; TTS UI and Player2 MCM groups were removed.

**NRV:** Whether each line of those diffs is bug-free — **not** proven here.

---

## 2. Single LLM HTTP implementation — **SRC**

All dialogue / raw feature traffic goes through `AIInfluence.API.AIClient` to `https://openrouter.ai/api/v1/chat/completions` (see `AIClient.cs` lines 110, 230).

**NRV:** TLS, DNS, OpenRouter account limits, regional blocking.

---

## 3. Return shapes from `AIClient` — **SRC**

Read: full file `src/AIInfluence.API/AIClient.cs` (305 lines).

| Case | Return value | Lines |
|------|----------------|-------|
| `GetAIResponse` outer catch | `GenerateErrorResponse(...)` → **JSON string** beginning with `{` | 27–30, 242–255 |
| `GetOpenRouterResponse` inner catch | `GenerateErrorResponse("I am unable…")` | 178–181 |
| Missing API key (dialogue path) | `GenerateErrorResponse(...)` | 72–75 |
| Mod disabled (dialogue path only) | `GenerateErrorResponse(...)` | 77–80 |
| `GetRawTextResponse` outer catch | `"Error: AI request failed: " + ex.Message` | 40–43 |
| `GetOpenRouterRawResponse` missing key | `"API key is missing."` (**does not** start with `"Error:"`) | 187–190 |
| `GetOpenRouterRawResponse` HTTP catch | `"Error: " + ex.Message` | 235–238 |

---

## 4. `SendAIRequest` predicate — **SRC**

`src/AIInfluence/AIInfluenceBehavior.cs` lines 215–222:

```csharp
if (!string.IsNullOrEmpty(response) && !response.StartsWith("Error:"))
{
    LogMessage("[SEND_AI_REQUEST_SUCCESS] ...");
    return response;
}
LogMessage("[SEND_AI_REQUEST_ERROR] ...");
return null;
```

**SRC:** Any string returned from `GetAIResponse` that is **`GenerateErrorResponse` JSON** begins with `{`, not `"Error:"`. Therefore `!response.StartsWith("Error:")` is **true** for that failure mode, and the method takes the **first** branch and logs **SUCCESS** (lines 217–218).

**INF:** Callers that only use `StartsWith("Error:")` to detect failure may **not** treat JSON error envelopes as errors.

**NRV:** Whether this mismatch existed **before** the OpenRouter-only branch (requires `git blame` / old `AIClient`).

---

## 5. Retry loops using `StartsWith("Error:")` — **SRC**

| Location | Lines (approx.) | Condition to break retry |
|----------|------------------|---------------------------|
| World / dynamic NPC | `AIInfluenceBehavior.cs` ~2794 | `!IsNullOrEmpty && !StartsWith("Error:")` |
| `ProcessChatInput` | ~3331 | same |

**SRC:** JSON error from `GenerateErrorResponse` does **not** start with `"Error:"`, so the break condition can fire on **error JSON** as if it were a successful model response.

**INF:** Transient HTTP failures that return JSON error bodies may **not** trigger retries.

---

## 6. `SendAIRequestForFeature` / `SendAIRequestRaw` — **SRC**

Lines 246–253 (`ForFeature`): failure detected with `response.StartsWith("Error:")` **after** empty check.

**SRC:** The literal `"API key is missing."` (from `GetOpenRouterRawResponse` line 190) **does not** start with `"Error:"` → **ForFeature** treats it as **success path** (251–253) and returns that string to callers.

**INF:** Downstream code may try to parse that as JSON for events/diplomacy.

---

## 7. `EnableModification` — **SRC**

| Path | Checks `EnableModification`? | Lines |
|------|------------------------------|-------|
| `GetOpenRouterResponse` | Yes | 77–80 |
| `GetOpenRouterRawResponse` | **No** | 185–239 |

**INF:** If raw entry points run while mod is “disabled,” HTTP may still occur.

**NRV:** Whether any code path reaches raw APIs with mod disabled in a real session.

---

## 8. Compile-time call sites to `AIClient` / wrappers — **SRC**

Produced by repository search for `SendAIRequest`, `AIClient.Get`, `GetRawTextResponse` in `src/**/*.cs`.

| # | File:line | Expression |
|---|-------------|------------|
| 1 | `AIInfluenceBehavior.cs:213` | `SendAIRequest` → `GetAIResponse` or `GetRawTextResponse` |
| 2 | `AIInfluenceBehavior.cs:238` | `SendAIRequestForFeature` → `GetRawTextResponse` |
| 3 | `AIInfluenceBehavior.cs:269` | `SendAIRequestRaw` → `GetRawTextResponse` |
| 4 | `AIInfluenceBehavior.cs:2793` | direct `GetAIResponse` |
| 5 | `AIInfluenceBehavior.cs:3330` | `GetAIResponse` + stream |
| 6 | `AIInfluenceBehavior.cs:4921` | `SendAIRequestRaw` in background task |
| 7 | `ModSettings.cs` (test) | `TestOpenRouterConnection` |
| 8 | `DeathHistoryBehavior.cs:104` | `SendAIRequest` |
| 9–12 | `NPCInitiativeSystem.cs:963,1525,1967,2183` | `SendAIRequest` |
| 13–14 | `SettlementCombatManager.cs:581,2326` | `SendAIRequestRaw` |
| 15 | `DynamicEventsAnalyzer.cs:1074` | `SendAIRequestRaw` |
| 16–19 | `DynamicEventsGenerator.cs:228,289,1813,4133` | `SendAIRequestForFeature` |
| 20 | `KingdomStatementGenerator.cs:1816` | `SendAIRequestForFeature` |
| 21 | `PlayerStatementAnalyzer.cs:42` | `SendAIRequestForFeature` |

**NRV:** Whether this list is **complete** at any future commit — re-run search before release.

---

## 9. Information loss in `AIClient` catches — **SRC**

| Catch | Logged | Returned | Body of HTTP error response to caller? |
|-------|--------|----------|----------------------------------------|
| `GetOpenRouterResponse` ~178–181 | `ex.Message` | Fixed `GenerateErrorResponse` text | **No** — generic user-facing JSON `Response` only |
| `GetOpenRouterRawResponse` ~235–238 | `ex.Message` | `"Error: " + ex.Message` | **Partial** — exception message only, not full OpenRouter JSON body |

---

## 10. Silent / empty catches (LLM-adjacent only) — **SRC**

| File | Line | Pattern |
|------|------|---------|
| `NpcChatWindowVM.cs` | 736 | `catch (Exception) { }` |
| `NpcChatWindowManager.cs` | 75 | `catch (Exception) { }` |
| `SubModule.cs` | 61–63, 77–79 | `catch (Exception) { }` around Harmony |

**INF:** Whether those hide user-visible failures — depends on what exceptions occur.

---

## 11. `HttpClient` — **INF**

**INF:** `httpClient.DefaultRequestHeaders.Authorization` is assigned before each request (`AIClient.cs` 107, 227, 288). Microsoft docs: mutating default headers on a shared `HttpClient` under concurrency can cause races.

**NRV:** Whether two LLM calls overlap in your typical session.

---

## 12. Build — **SRC** (point in time)

`dotnet build src/AIInfluence.csproj` was run successfully in the agent environment during this work.

**NRV:** Future commits may break the build.

---

## 13. Register: defects (for tracking)

Use this table to **track fixes**. Each row is **SRC** for the mechanism; **INF/NRV** columns say what we did not prove.

| ID | Mechanism (SRC) | Risk (INF/NRV) |
|----|-----------------|----------------|
| R1 | `SendAIRequest` uses `StartsWith("Error:")`; `GenerateErrorResponse` returns `{` | Callers may mis-classify JSON errors **INF**; pre-existed **NRV** |
| R2 | Retry loops use same `StartsWith` test | May not retry on JSON error **INF** |
| R3 | `"API key is missing."` not prefixed `Error:` | `SendAIRequestForFeature` success branch **SRC** |
| R4 | `GetOpenRouterRawResponse` no `EnableModification` | Policy gap **INF** |
| R5 | `SendAIRequestForFeature` catch returns `null` | Callers conflate with empty **INF** |
| R6 | HTTP error bodies dropped in inner catch of `GetOpenRouterResponse` | Debugging harder **INF** |
| R7 | Shared `HttpClient` + default headers | Race **INF** |
| R8 | Empty catches in §10 | Exceptions swallowed **SRC**; impact **NRV** |

---

## 14. Re-verify (commands) — **SRC**

```bash
rg -n 'SendAIRequest|AIClient\.Get|GetRawTextResponse' src --glob '*.cs'
rg -n 'StartsWith\(\"Error:' src --glob '*.cs'
dotnet build src/AIInfluence.csproj
```

---

## 15. What I (the author of this audit) did not do — explicit

- Did **not** run Bannerlord.
- Did **not** execute automated tests beyond `dotnet build` where run.
- Did **not** use `git blame` on every line of `AIClient` vs `main`.
- Did **not** prove **concurrency** bugs; only stated **INF** from API design.

This section exists so nobody can confuse this file with a **runtime** certification.
