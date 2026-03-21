# OpenRouter north star & overhaul plan

## North star (one sentence)

**SSE stream → accumulate assistant message and tool calls → run tools until the model returns a final assistant message → parse that message with a strict dialogue-only contract (DTO / `response_format`) → update UI and game state from that DTO and from tool results only → never deserialize world actions from the dialogue JSON.**

Everything that duplicates authority (legacy envelope on `AIResponse`, stringly-typed `technical_action`, `JsonCleaner` as default repair, per-feature raw backends) is migration scar tissue to remove.

---

## Principles

1. **Single AI transport:** OpenRouter completions for in-mod features (other backends removed on dedicated branches).
2. **Three layers:** HTTP/SSE + agent loop → **tools / structured output** → **domain handlers** → **game state / subscribers**.
3. **No second authority:** Game effects come from **tool handlers** (or one strict `map_command` schema), not duplicate keys on a shared envelope type.
4. **Observable tools:** Every tool invocation is loggable and broadcast on an internal bus (`OnToolCompleted` or equivalent), not re-encoded as opaque strings.

---

## Phase 0 — Repo + contract groundwork

**Goal:** One way to call OpenRouter with streaming, tools, and `response_format`.

| Deliverable | Notes |
|-------------|--------|
| Replace `SendAIRequestWithBackend` / `GetRawTextResponseWithBackend` for in-mod features | Route diplomacy, dynamic events, etc. through `GetAIResponse` (or one OpenRouter facade) with per-call `tools` + `response_format`. |
| Per-domain tool registries | e.g. NPC chat, diplomacy, dynamic events — compose into the request body; overlap only where intentional. |
| Tool telemetry | `OnToolInvoked` / `OnToolCompleted(feature, name, argsJson, resultJson, error)` — single hook all handlers use. |

**Exit:** No production path uses a separate “diplomacy backend” HTTP shape; OpenRouter is the only completion API.

---

## Phase 1 — NPC chat: dialogue DTO + strict schema

**Goal:** Final assistant message = dialogue-only JSON.

| Deliverable | Notes |
|-------------|--------|
| `NpcDialogueMessage` (DTO) or generated from schema | Only fields the player and flow need. |
| `OpenRouterNpcResponseSchema`: `strict: true`, `additionalProperties: false` | Delete client-side key stripping (`OpenRouterDialogueJson`) once enforced. |
| Stop using `JsonCleaner` on the default NPC reply path | Parse-or-fail + log + user-visible error. |
| Stop deserializing the final message into `AIResponse` | Deserialize into the dialogue DTO only. |

**Exit:** `AIResponse` is not the type of the final assistant JSON for NPC chat.

---

## Phase 2 — NPC chat: effects only via tools

**Goal:** No money / items / quests / kingdom / workshop / death from dialogue JSON.

| Deliverable | Notes |
|-------------|--------|
| Remove `ProcessChatInput` blocks that set pending transfers, items, workshop from parsed `aiResult` | After Phase 1 these should be unused for OpenRouter. |
| Ensure every effect has a tool | Already mostly true; close gaps. |
| Remove merging deferrals onto `AIResponse` | Death / map deferrals → `NPCContext` pending structs or apply in handler + bus. |

**Exit:** No game-effect fields populated from dialogue JSON on the NPC path.

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
| `PendingNpcDialogue` (or equivalent) | Only what conversation menus need. |
| Quest / kingdom from pending envelope | Remove if Phase 2 moved execution to tools only. |
| Unify `HandlePlayerInput` and `ProcessChatInput` internals | One orchestrator; two UI entry points. |

**Exit:** `DialogManager` does not re-run effects from JSON envelope duplicates.

---

## Phase 5 — Diplomacy & dynamic events (OpenRouter-native)

**Goal:** Same stack as NPC chat; different prompts and tools.

| Deliverable | Notes |
|-------------|--------|
| Diplomacy | `GetAIResponse` + diplomacy tools + strict `response_format` where needed. |
| Dynamic events | Same + event tools. |
| Subscribers | React via tool bus, not string parsing. |

**Exit:** No default `JsonCleaner` path for these features; failures are explicit.

---

## Phase 6 — Prompts + streaming UX

**Goal:** Prompts match the contract.

| Deliverable | Notes |
|-------------|--------|
| Trim `PromptGenerator` prose that teaches legacy envelope JSON for NPC. |
| Revisit `GetNpcMessagePreview` / streaming | Align with dialogue DTO or future `npc_say` tool args. |

---

## Phase 7 (optional) — Speech / emote as tools

**Goal:** Optional tools `npc_say` / `npc_emote` with guarantees and streaming on tool arguments; TTS reads from tool results or dedicated fields.

**Dependency:** Strong streaming story for tool args; can ship after Phases 1–4.

---

## Dependency order

```
Phase 0 (OpenRouter + bus + registries)
    → Phase 1 (dialogue DTO + strict schema)
    → Phase 2 (tools-only effects)
    → Phase 3 (map)  — can overlap Phase 4 design
    → Phase 4 (DialogManager / pending shrink)
    → Phase 5 (diplomacy / events)
    → Phase 6 (prompts / preview)
    → Phase 7 (optional say/emote tools)
```

---

## Suggested PR milestones

| Tag | Meaning |
|-----|---------|
| `openrouter-only-transport` | Phase 0 |
| `npc-dialogue-dto` | Phase 1 |
| `tools-only-effects-npc` | Phase 2 |
| `map-command-no-string` | Phase 3 |
| `dialogmanager-thin` | Phase 4 |
| `diplomacy-events-openrouter` | Phase 5 |
| `prompts-trimmed` | Phase 6 |

---

## Risks

- **Strict schema** will surface more failures — treat as correct; add logging and clear in-game messages, not silent salvage.
- **Tool sprawl** — group tools by domain and document each catalog.
- **Regression** — add golden scenarios: multi-tool turn, dialogue-only turn, failure path.
