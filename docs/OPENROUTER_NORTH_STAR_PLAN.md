# OpenRouter north star & overhaul plan

## North star (one sentence)

**Player/context → one inference pass with tools → side effects only inside tool handlers → UI subscribes to tool (and derived) events.** No monolithic dialogue JSON as a second execution engine, and **no correctness logic, trimming, or “ensuring” game rules in a parse step**—that belongs in handlers and explicit subscribers.

---

## Target architecture: three stages (the simple system)

Think of it as a **queue of intentions**, not a **blob parser**.

| Stage | What happens | Authority |
|--------|----------------|-----------|
| **1. Generate input** | The player (or game) produces a **question, action, or event**. That payload is **enriched with a thin context layer** (system + compact world facts). The model may **gain new facts only through tools** (search, find_*, etc.)—not by inventing parallel “how to format output” rules in prose. | Prompt + context builders only describe **domain rules** and **available tools**, not a hundred conditional JSON shapes. |
| **2. Handle (inference)** | **One** OpenRouter completion path: tools exposed, streaming as needed. **Side effects are intentional**: they occur **when a tool runs** and returns. That is the designed system—not a side effect of deserializing a string. | **Tool handlers** + optional small internal bus (`ToolCompleted` / feature-specific subscribers). |
| **3. UI** | The UI **consumes events**: e.g. assistant `response` text → chat line; `transfer_money` → action pill / banner; kingdom/quest tools → world notifications or panels. Same idea if “world events” and “chat panel” are different surfaces—they both **listen**, they do not **re-parse one giant envelope** to discover what happened. | View models / dialog nodes react to **named actions**, not to rediscovering state from `AIResponse` JSON. |

**Explicit non-goals for this design**

- **Parsing is not a game loop.** It may validate **syntax** for transport (malformed HTTP/SSE), not **semantics** for gameplay (duplicate tools, trim keys, merge tool vs JSON authority).
- **No second authority:** if a behavior exists as a tool, the **final assistant message must not** be a second place that can trigger the same behavior (no strip/merge/clear dance).

---

## What we have today (why it feels heavy)

Same rough “player talks to AI” story, but **many extra layers**—this is the complexity cost you are paying.

| # | Layer | What it is in the codebase | Problem |
|---|--------|------------------------------|--------|
| 1 | **Generate input** | `PromptGenerator` + `NPCContext` + world managers | OK as far as it goes. |
| 2 | **Extra prompt & format pressure** | Long prose, `response_format` / JSON schema, “how to output” instructions, OpenRouter-specific schema types | **Competing instructions** with tools; model can satisfy prose + tools + JSON in inconsistent ways. |
| 3 | **Alternate entry points** | `GetRawTextResponse`, `SendAIRequestWithBackend`, combat/surrender/initiative branches, `multi_dialogue_analysis` without tools | **Multiple inference shapes** → different failure modes and duplicate glue. |
| 4 | **Handle (inference)** | `AIClient` SSE + tool loop, `ToolHandlers` | This is the **intended** side-effect layer—good. |
| 5 | **Parsing & “correctness”** | `NpcOpenRouterAssistantParser`, `JsonCleaner`, `OpenRouterDialogueJson.StripGameEffectKeys`, merge from `NPCContext` into `AIResponse`, “ensure tools didn’t duplicate JSON,” etc. | **Ambiguous authority**: gameplay semantics smuggled into “make JSON valid / consistent.” |
| 6 | **Queues & deferrals** | `DelayedTaskManager`, pending fields, DialogManager scheduling | Work that could be **immediate** in the tool path gets **re-queued**, ordering gets harder to reason about. |
| 7 | **UI** | Chat VM + `DialogManager` still mix **`AIResponse`** parsing with tool-driven state | **One parser loop** tries to drive both narrative and mechanics until the NPC path is fully tool-first. |

The north star doc must **not** treat step 5 as a permanent home for “a little more logic each time.” Step 5 should shrink to **transport-only** (or disappear for NPC chat).

---

## Legacy scar tissue (migration targets)

- **Monolithic `AIResponse` envelope** as parallel authority to tools.
- **String protocols** (legacy comma-separated map command strings in prompts or docs) alongside typed tools — **remove** wherever they still appear; map behavior is **one tool per step**.
- **`JsonCleaner` / strip / merge** as the default way to get a consistent turn (should be debug-only or deleted on NPC path).
- **Per-feature raw completions** (`GetRawTextResponse*`) where the same feature could use **the same tool catalog + bus**.
- **Prompts that encode output schemas** instead of naming tools.
- **Deferrals** that exist only because effects were not applied in the tool handler path.

---

## Principles

1. **Single AI transport:** OpenRouter completions for in-mod features (other backends removed on dedicated branches).
2. **Three runtime stages:** thin input → **inference with tools** → **UI/event consumers** (no “stage 5” semantics in the parser).
3. **Side effects only in tools (and subscribers):** HTTP/SSE + agent loop → **tool calls** → **handlers** → **game state / bus** → **UI**.
4. **No second authority:** No parallel “dialogue JSON” path for fields that also exist as tools. Per-tool `arguments` JSON from the API is the structured shape for that action.
5. **Observable tools:** Every tool invocation is loggable and broadcast (`ToolCallTelemetry` / `OnToolCompleted`), not re-encoded as opaque strings for another layer to decode.

---

## Phase 0 — Repo + contract groundwork

**Status:** **In progress.** OpenRouter-only transport is in place. **`ToolCallTelemetry.ToolCompleted`** fires after each NPC chat tool handler completes. Per-domain tool **registries** (diplomacy/events) and routing **`SendAIRequestWithBackend`** through tool catalogs are **not done**.

| Deliverable | Notes |
|-------------|--------|
| Replace `SendAIRequestWithBackend` / `GetRawTextResponseWithBackend` for in-mod features | Raw OpenRouter only today; still no shared tool catalog for diplomacy/events. |
| Per-domain tool registries | Pending. |
| Tool telemetry | **`ToolCallTelemetry`** added; handlers invoke it from `ToolHandlers.Run`. |

**Exit:** No production path uses a separate “diplomacy backend” HTTP shape; OpenRouter is the only completion API.

---

## Phase 1 — NPC chat: tool-first dialogue (speech + social + flow)

**Status:** **Largely complete.** Dual-authority dialogue tools (`suspected_lie`, `dialogue_decision`, `romance_intent`, `escalation_update`, `allows_letters`) removed — dialogue state flows exclusively through `NpcOpenRouterDialogueEnvelope` JSON, not through tool scratch fields merged back into `AIResponse`. `ClearNpcTurnDialogueTools` now only resets action-tool scratch (quest, kingdom, pills, map). **`NpcOpenRouterAssistantParser`** is the single entry for assistant text → `AIResponse`.

| Deliverable | Notes |
|-------------|--------|
| Define tool schemas + handlers | Done for game-effect tools; dialogue state lives only in JSON schema. |
| Remove dual-authority merge | **Done** — `ApplyNpcDialogueToolsToAiResponse` and 7 `DialogueTool*` scratch fields deleted. |
| Remove `DeserializeObject<AIResponse>` for NPC final message | **Not complete** — still deserialize after strip; **target is: no envelope execution from this step**. |
| Remove `JsonCleaner` on default NPC path | **Reduced** — must become unnecessary once tools own dialogue. |

**Exit:** NPC chat turn is **tool calls + subscriber/UI updates**, not one parsed dialogue object driving mechanics. Dialogue-state dual authority is resolved; remaining work is `JsonCleaner` removal and full envelope shrink.

---

## Phase 2 — NPC chat: world effects + deferrals only via tools

**Status:** **Partial.** Envelope fields stripped before deserialize; deferrals merged from `NPCContext`. **`HandlePlayerInput`** no longer applies legacy money/item/workshop from JSON in the intended end state. Full removal of game-effect fields from `AIResponse` usage in NPC path **pending**.

**Exit:** No “apply JSON field X” in `ProcessChatInput` for anything that has a tool.

---

## Phase 3 — Map: end string protocols for map behavior

**Status:** **Started.** Map behavior uses **typed tools** only; remove any remaining prose that describes a single string field for chained map orders.

**Exit:** `DialogManager` and map UI do not read **stringly** map commands from `AIResponse`—only tool-emitted facts or handler-written context.

---

## Phase 4 — `DialogManager` + pending payload shrink

**Status:** **Not started** (design in plan; implementation pending).

**Exit:** Dialog nodes **react to known events** (or a thin context snapshot), not to re-parsing a full pending `AIResponse` blob every time.

---

## Phase 5 — Diplomacy & dynamic events (OpenRouter-native)

**Status:** **Not started** — still raw completions + local JSON cleanup in diplomacy files. Subscribers via **`ToolCallTelemetry`** when these flows use tools.

---

## Phase 6 — Prompts + streaming UX

**Status:** **Partial** — NPC prompt prose trimmed earlier; **`GetNpcMessagePreview`** still uses partial JSON heuristics where not driven by tool-arg streaming.

**Exit:** Preview text comes from **streamed assistant content** or a single non-mechanical fallback string—not regex on partial JSON.

---

## Dependency order

```
Phase 0 (OpenRouter + bus + registries)
    → Phase 1 (tool-first dialogue; parser stops executing game semantics)
    → Phase 2 (world effects only tools; no deferrals onto AIResponse)
    → Phase 3 (map: no string protocol)
    → Phase 4 (DialogManager / pending shrink)
    → Phase 5 (diplomacy / events)
    → Phase 6 (prompts / preview)
```

---

## Suggested PR milestones

| Tag | Meaning |
|-----|---------|
| `openrouter-only-transport` | Phase 0 |
| `npc-tool-first-dialogue` | Phase 1 |
| `tools-only-effects-npc` | Phase 2 |
| `map-command-no-string` | Phase 3 |
| `dialogmanager-thin` | Phase 4 |
| `diplomacy-events-openrouter` | Phase 5 |
| `prompts-trimmed` | Phase 6 |

---

## Risks

- **Tool sprawl** — group tools by domain (`npc_*`, `map_*`, `quest_*`, `diplomacy_*`) and document each catalog.
- **Streaming tool args** — preview UX depends on provider streaming of `tool_calls` deltas; have a fallback (buffer until tool complete).
- **Regression** — golden scenarios: multi-tool turn, say-only turn, world-action turn, failure path.
- **Creeping parse logic** — any new “ensure X after deserialize” must be rejected unless it is **pure transport** (malformed JSON), not **game rules**.
