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

**Files touched by OpenRouter-only commits** include: `AIClient.cs`, deleted alternate-provider files, **deleted** `Player2Client.cs` + `VoiceInfo.cs`, deleted `Player2UsageTracker.cs`, `ModSettings.cs`, `AIInfluenceBehavior.cs`, `NpcChatWindowVM.cs`, `SubModule.cs`, **deleted** `TtsLipSyncService.cs` + `TtsPreparedData.cs`, added `MainThreadDispatch.cs` (main-thread queue for LLM stream UI only), `NPCInitiativeSystem.cs`, `DialogManager.cs`, `PromptGenerator.cs`, `AIResponse.cs`, `JsonCleaner.cs`, `NPCContext.cs`, diplomacy + `DynamicEventsGenerator.cs`, and this doc.

**SRC:** TTS / `tts_instructions` / NPC voice fields were **removed** from prompts, JSON schema, `AIResponse`, `NPCContext`, and dialog; no TTS stub settings remain in `ModSettings`.

**NRV:** Whether each line of those diffs is bug-free — **not** proven here.

### 1a. Exhaustive removal checklist (Player2 / TTS / lip-sync stack) — **SRC**

Searches used: ripgrep on `src/`, `docs/`, `.github/` for `tts`, `TTS`, `Player2`, `LipSync`, `rhubarb`, `OggEncoder`, `OggVorbis`, `tts_instructions`, `AssignedTTS`, `PreparedTts`, `EnableTTS` (case-insensitive); plus spot-check of `GUI/*.xml`.

| Area | Removed / changed |
|------|-------------------|
| **Deleted C#** | `Player2Client.cs`, `VoiceInfo.cs`, `Player2UsageTracker.cs`, `TtsLipSyncService.cs`, `TtsPreparedData.cs`, `OggEncoder.cs` |
| **Added C#** | `MainThreadDispatch.cs` only (queue for LLM stream / UI; not audio) |
| **Project** | `AIInfluence.csproj` — no `OggVorbisEncoder` reference (**SRC:** current csproj `ItemGroup` is `System.Net.Http` only besides packages) |
| **MCM** | No TTS / Player2 API groups; no `EnableTTS` / speed / volume properties on `ModSettings` |
| **Model / state** | `AIResponse.TTSInstructions`; `NPCContext` voice / prepared-audio fields |
| **Prompts** | `tts_instructions` lines in `PromptGenerator`; example JSON no longer lists `tts_instructions` |
| **Dialog** | TTS playback blocks removed from `DialogManager` |
| **JSON hygiene** | `JsonCleaner` default object and optional-field list — no `tts_instructions` |
| **Death history** | `DeathHistoryBehavior` JSON field regex — no `tts_instructions` alternative |
| **CI / release** | `.github/workflows/publish.yml` — no copy of `OggVorbisEncoder.dll`, `System.Buffers.dll`, `System.Memory.dll`, `rhubarb.exe`, or `bin/Win64_Shipping_Client/res/` (was lip-sync / phonetic resources for rhubarb) |
| **Logs** | Main-thread dequeue errors log as `[MainThreadDispatch]` not `[LipSync]` (`AIInfluenceBehavior`) |

**SRC:** `rhubarb.exe`, `res/`, `OggVorbisEncoder.dll`, `System.Buffers.dll`, and `System.Memory.dll` under `bin/Win64_Shipping_Client/` were **removed from git tracking** and listed in `.gitignore` so they are not re-committed. The **publish workflow** does not copy them (see §1a table). `AIInfluence.dll` may remain under `bin/` for local/Vortex layouts — **NRV** whether your fork still needs that file tracked.

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

## 4. `SendAIRequest` / dialogue failure detection — **SRC** (addressed)

`AIClient.IsDialogueFailureResponse` / `IsRawTextFailureResponse` classify **`GetAIResponse`** JSON envelopes (`ai_error`, legacy `response` text) and **raw** paths (`Error:`, `API key is missing.`). `SendAIRequest` uses them instead of **`StartsWith("Error:")`** alone. `ProcessChatInput` retry / empty guards use **`IsDialogueFailureResponse`** for **`GetAIResponse`** results. Call sites (`NPCInitiativeSystem`, `DeathHistoryBehavior`) use **`IsSendAIRequestResultFailure`** so they do not rely on **`StartsWith("Error:")`** alone.

**SRC:** `GenerateErrorResponse` sets **`AiError = true`** on `AIResponse` (serialized as **`ai_error`**).

---

## 5. Retry loops — **SRC** (addressed)

`AIInfluenceBehavior` retry / empty guards use **`AIClient.IsDialogueFailureResponse`** (e.g. ~2797, ~2821, ~3273, ~3285) instead of **`StartsWith("Error:")`** alone, so JSON error envelopes from **`GenerateErrorResponse`** are classified as failures.

---

## 6. `SendAIRequestForFeature` / `SendAIRequestRaw` consumers — **SRC** (addressed)

**`SendAIRequestForFeature`** and **`SendAIRequestRaw`** in **`AIInfluenceBehavior`** use **`AIClient.IsRawTextFailureResponse`** after the empty-response branch, so **`"API key is missing."`** (no `Error:` prefix) is treated as failure. **`SettlementCombatManager`** (`SendAIRequestRaw`) and the **`[QuestDebug]`** raw path use **`IsRawTextFailureResponse`** instead of **`StartsWith("Error:")`** only.

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
| R1 | `SendAIRequest` + JSON envelopes | **Addressed** — `IsDialogueFailureResponse` / `IsSendAIRequestResultFailure` **SRC** |
| R2 | Retry loops | **Addressed** — `IsDialogueFailureResponse` **SRC** |
| R3 | `"API key is missing."` on raw paths | **Addressed** — `IsRawTextFailureResponse` on **ForFeature** / **Raw** / **SettlementCombat** / **QuestDebug** **SRC** |
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
