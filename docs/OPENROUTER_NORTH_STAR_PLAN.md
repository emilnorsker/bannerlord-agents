# OpenRouter north star & overhaul plan

## North star (one sentence)

**SSE stream → accumulate tool calls (and stream `npc_say` / `npc_emote` tool arguments for live UI) → run the tool loop until the model is done → apply all speech, social, conflict, and world state only inside tool handlers and `NPCContext` → do not deserialize a monolithic dialogue JSON envelope; tone, suspected lies, escalation, romance, decisions, money, quests, and map are all named tools with small argument schemas, not fields in one parsed blob.**

We do **not** treat the session as “produce one JSON object with `tone`, `suspected_lie`, … then parse it.” We treat it as **consuming a sequence of actions** from the model (tool calls), same as world actions.

---

## Legacy scar tissue (migration targets)

Everything that duplicates authority (legacy envelope on `AIResponse`, stringly-typed `technical_action`, `JsonCleaner` as default repair, per-feature raw backends, monolithic `PromptGenerator` JSON prose) is to be removed or relegated to debug-only fallback.

---

## Principles

1. **Single AI transport:** OpenRouter completions for in-mod features (other backends removed on dedicated branches).
2. **Three layers:** HTTP/SSE + agent loop → **tool calls** (and optional minimal assistant `content` only if the API requires it) → **tool handlers** → **game state / subscribers**.
3. **No second authority:** No parallel “dialogue JSON” path for fields that also exist as tools. Small per-tool `arguments` JSON (from the API) is the only structured shape per action.
4. **Observable tools:** Every tool invocation is loggable and broadcast on an internal bus (`OnToolCompleted` or equivalent), not re-encoded as opaque strings.

---

## Phase 0 — Repo + contract groundwork

**Status:** **In progress.** OpenRouter-only transport is in place. **`ToolCallTelemetry.ToolCompleted`** (`feature`, `toolName`, `argsJson`, `resultJson`, `error`) fires after each NPC chat tool handler completes; subscribe for logging/analytics. Per-domain tool **registries** (diplomacy/events) and routing **`SendAIRequestWithBackend`** through tool catalogs are **not done**.

| Deliverable | Notes |
|-------------|--------|
| Replace `SendAIRequestWithBackend` / `GetRawTextResponseWithBackend` for in-mod features | Raw OpenRouter only today; still no shared tool catalog for diplomacy/events. |
| Per-domain tool registries | Pending. |
| Tool telemetry | **`ToolCallTelemetry`** added; handlers invoke it from `ToolHandlers.Run`. |

**Exit:** No production path uses a separate “diplomacy backend” HTTP shape; OpenRouter is the only completion API.

---

## Phase 1 — NPC chat: tool-first dialogue (speech + social + flow)

**Status:** **In progress.** Dialogue tools + merge + `ClearNpcTurnDialogueTools` remain. **`NpcOpenRouterAssistantParser`** is the single entry for assistant text → `AIResponse`: tries raw JSON, then **`JsonCleaner` only on parse failure**, then **`OpenRouterDialogueJson.StripGameEffectKeys`**. **`OpenRouterNpcResponseSchema`** no longer requires `response` (tool-only `{}` turns). **`PrepareForAiResponseDeserialize`** removed (use parser + `StripGameEffectKeys`).

| Deliverable | Notes |
|-------------|--------|
| Define tool schemas + handlers | Ongoing; `map_command` added (structured map line; `technical_action` legacy). |
| Remove `DeserializeObject<AIResponse>` for NPC final message | **Not complete** — still deserialize after strip; goal is context-only + minimal ack. |
| Remove `JsonCleaner` on default NPC path | **Reduced** — not first resort; fallback only inside parser. |
| **Optional** minimal `response_format` | Relaxed required list; can narrow further later. |

**Exit:** NPC chat turn is **tool calls + context updates**, not one parsed dialogue object. **Not fully at exit yet.**

---

## Phase 2 — NPC chat: world effects + deferrals only via tools

**Status:** **Partial.** Envelope fields stripped before deserialize; deferrals merged from `NPCContext`. **`HandlePlayerInput`** no longer applies legacy money/item/workshop from JSON. Full removal of game-effect fields from `AIResponse` usage in NPC path **pending**.

---

## Phase 3 — Map: end `technical_action` string protocol

**Status:** **Started.** New **`map_command`** tool (`action` + optional `payload`) writes the same deferred line format as `technical_action`. DialogManager still consumes **`AIResponse.TechnicalAction`** after merge — **exit not met** until consumers read typed/tool-only data only.

---

## Phase 4 — `DialogManager` + pending payload shrink

**Status:** **Not started** (design in plan; implementation pending).

---

## Phase 5 — Diplomacy & dynamic events (OpenRouter-native)

**Status:** **Not started** — still raw completions + local JSON cleanup in diplomacy files. Subscribers via **`ToolCallTelemetry`** can be added when these flows use tools.

---

## Phase 6 — Prompts + streaming UX

**Status:** **Partial** — NPC prompt prose trimmed earlier; **`GetNpcMessagePreview`** still uses partial JSON heuristics where not driven by tool-arg streaming.

---

## Dependency order

```
Phase 0 (OpenRouter + bus + registries)
    → Phase 1 (tool-first dialogue: say, lie, conflict, … + remove dialogue envelope)
    → Phase 2 (world effects only tools; remove deferrals onto AIResponse)
    → Phase 3 (map)  — can overlap Phase 4 design
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
