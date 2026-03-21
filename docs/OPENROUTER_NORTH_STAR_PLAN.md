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

**Goal:** One way to call OpenRouter with streaming and **tools**; `response_format` only where a feature is **not** fully tool-expressed (e.g. diplomacy text-only) or the API requires a minimal final message.

| Deliverable | Notes |
|-------------|--------|
| Replace `SendAIRequestWithBackend` / `GetRawTextResponseWithBackend` for in-mod features | Route diplomacy, dynamic events, etc. through `GetAIResponse` (or one OpenRouter facade) with per-call **`tools`**; add optional `response_format` per domain only when needed. |
| Per-domain tool registries | e.g. NPC chat, diplomacy, dynamic events — compose into the request body; overlap only where intentional. |
| Tool telemetry | `OnToolInvoked` / `OnToolCompleted(feature, name, argsJson, resultJson, error)` — single hook all handlers use. |

**Exit:** No production path uses a separate “diplomacy backend” HTTP shape; OpenRouter is the only completion API.

---

## Phase 1 — NPC chat: tool-first dialogue (speech + social + flow)

**Goal:** No monolithic `AIResponse` / dialogue JSON for **speech, tone, lies, escalation, romance, decisions**. Those become **tools** with small schemas (e.g. `npc_say` with `line` + optional `tone`; `lie_suspect` / `lie_resolve`; `conflict_update`; `dialogue_decision`; `romance_set_intent`; …). World tools (`transfer_money`, `quest_action`, map tools, …) stay **only** as tools.

| Deliverable | Notes |
|-------------|--------|
| Define tool schemas + handlers | Speech/emote stream via **tool argument deltas** where supported; handlers update `NPCContext` and UI. |
| Remove `DeserializeObject<AIResponse>` for NPC final message | No `OpenRouterNpcResponseSchema` envelope for **dialogue** (delete or shrink to API-required ack only). |
| Remove `JsonCleaner` / `OpenRouterDialogueJson` on default NPC path | No big blob to clean or strip. |
| **Optional** minimal `response_format` | Only if provider requires non-empty assistant `content`; prefer **empty** or trivial `turn_done` tool instead of a 20-field JSON. |

**Exit:** NPC chat turn is **tool calls + context updates**, not one parsed dialogue object.

---

## Phase 2 — NPC chat: world effects + deferrals only via tools

**Goal:** No money / items / quests / kingdom / workshop / death from any **legacy JSON envelope**.

| Deliverable | Notes |
|-------------|--------|
| Remove `ProcessChatInput` blocks that read envelope fields from parsed `aiResult` | Already redundant once Phase 1 removes deserialize. |
| Remove merging deferrals onto `AIResponse` | Death / map → `NPCContext` or apply in handler + bus. |

**Exit:** No game-effect fields on `AIResponse` for the NPC path.

---

## Phase 3 — Map: end `technical_action` string protocol

**Goal:** No `name:payload:STOP` mini-language as the contract.

| Option A | Use existing map tools only; DialogManager does not parse command strings. |
| Option B | One `map_command` tool with strict JSON `{ "action", "payload" }`. |
| Remove DialogManager `TechnicalAction` parsing once behavior comes only from tools + typed pending. |

**Exit:** No reliance on `PendingAIResponse.TechnicalAction` as a command string.

---

## Phase 4 — `DialogManager` + pending payload shrink

**Goal:** Pending payload is not a god object.

| Deliverable | Notes |
|-------------|--------|
| `PendingNpcTurn` / context fields | Only what conversation menus need — **filled from tool handlers**, not from a JSON envelope. |
| Quest / kingdom from pending envelope | Remove if execution is tools-only. |
| Unify `HandlePlayerInput` and `ProcessChatInput` internals | One orchestrator; two UI entry points. |

**Exit:** `DialogManager` does not re-run effects from legacy envelope duplicates.

---

## Phase 5 — Diplomacy & dynamic events (OpenRouter-native)

**Goal:** Same stack as NPC chat; different prompts and tools.

| Deliverable | Notes |
|-------------|--------|
| Diplomacy | `GetAIResponse` + diplomacy tools; optional small `response_format` only if needed. |
| Dynamic events | Same + event tools. |
| Subscribers | React via tool bus, not string parsing. |

**Exit:** No default `JsonCleaner` path for these features; failures are explicit.

---

## Phase 6 — Prompts + streaming UX

**Goal:** Prompts describe **tools**, not “put these keys in JSON.”

| Deliverable | Notes |
|-------------|--------|
| Trim `PromptGenerator` envelope prose for NPC. |
| Streaming preview | **Tool args** for `npc_say` / `npc_emote` (not regex on partial dialogue JSON). |

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
