# AI-Native LLM Usage in Games

This document defines practical design patterns for narrative-first games where LLM output can change world state through events, direct actions, delayed actions, and procedural generation (quests, items, characters).

## Core principles

1. Prefer tool side effects over output parsing.  
   The authoritative world changes come from tool execution, not from post-processing large model JSON.
2. Keep context thin.  
   Use a stable system prompt and a compact runtime envelope; let tools fetch additional facts on demand.
3. Use events as the shared language.  
   Game logic emits events, UI consumes events, and persistence stores events.
4. Never mask errors.  
   Failed tool calls and invalid states must be explicit, logged, and visible to the orchestration layer.

## Current rewrite decisions (agreed)

- One unified event queue/channel for dialogue + actions (single ordering).
- Multiple consumers subscribe to the same queue (conversation UI, world systems, future narrative systems).
- LLM-to-game interaction is tool-only for authoritative side effects.
- Event kinds include instant (`dialogue.spoken`, `transfer_item.completed`) and long-running (`action.started` -> `action.completed`).
- Initial action scope: `follow_player`, `go_to_settlement`, `attack_party`, `return_to_player`.

## Pattern 1: Input Envelope Pattern (thin context in, no heavy formatting)

Each turn starts from a compact envelope:

- `actor`: player id, npc id, location, current mode (conversation/combat/travel)
- `intent`: player utterance or game-triggered incident
- `state_refs`: lightweight references (quest ids, party ids, event ids)
- `constraints`: hard rules (cannot teleport, cannot create duplicates, etc.)

The envelope is small by design. It avoids large pre-expanded summaries and avoids complex prompt templates for edge-case branches.

## Pattern 2: Tool-First Inference Pattern (model decides, tools commit)

Inference loop:

1. LLM receives envelope + system policy.
2. LLM chooses natural language output and/or tool calls.
3. Tool calls execute immediately and produce side effects.
4. Every side effect emits a domain event.

Important: tool calls are intended behavior, not exceptional behavior. The model should not need to produce deeply structured response payloads for normal gameplay.

## Pattern 3: World Event Log Pattern (single source of truth)

Write every meaningful effect as a typed event:

- `dialogue.spoken`
- `action.started`
- `action.completed`
- `action.failed`
- `timer.scheduled`
- `timer.fired`
- `quest.generated`
- `item.generated`
- `character.generated`

Required event fields:

- `event_id`, `timestamp`, `turn_id`, `source` (`llm`, `system`, `tool`)
- `type`, `payload`
- `causation_id` (what caused this)
- `correlation_id` (same interaction chain)

This keeps orchestration simple: no giant parser pass, no fragile reconciliation pass, and no hidden mutation paths.

## Pattern 4: Direct Action Pattern (immediate state mutation)

Use for actions that should happen now (example: transfer troops, start following player, attack target).

Flow:

1. LLM calls tool (e.g. `start_follow`, `attack_party`, `transfer_troops`).
2. Tool validates invariants and mutates domain state.
3. Tool emits `action.started` and success/failure completion event.
4. UI renders event pills and chat output directly from events.

No secondary parser should reinterpret model text to discover these actions.

## Pattern 5: Delayed Action Pattern (explicit scheduling)

Use for actions that should happen later (example: "return in 3 days", "deliver message at dawn").

Flow:

1. LLM calls scheduler tool (`schedule_action` with due time + action spec).
2. Scheduler emits `timer.scheduled`.
3. When due, system emits `timer.fired` and executes action tool.
4. Execution emits normal action events (`started/completed/failed`).

Delayed behavior must be represented as events and queue entries, never as hidden prompt memory.

## Pattern 6: Procedural Generation Pattern (quests, items, characters)

Generation is an explicit tool domain, not free-form text parsing.

- `generate_quest(seed_context)` -> emits `quest.generated`
- `generate_item(seed_context)` -> emits `item.generated`
- `generate_character(seed_context)` -> emits `character.generated`

Guidelines:

1. Generate minimal canonical fields first (id, name, tags, goals, rewards).
2. Store generated artifacts as domain records and reference them by id in later turns.
3. Let narrative richness come from follow-up dialogue, not oversized generation payloads.
4. Add duplicate prevention at tool level (name+type+owner checks), not parser level.

## Pattern 7: Projection Pattern (UI reads event stream)

UI should project from event types:

- chat panel reads `dialogue.spoken` and narration events
- world UI reads `action.*`, `quest.*`, `item.*`, `character.*`
- timeline/log view reads full event stream

This removes the need for one huge response parser to convert model output into UI widgets.

## Pattern 8: Capability-Bounded Tooling Pattern

Give the LLM a focused capability set per mode:

- conversation mode: speak, inspect npc memory, propose action
- strategy mode: schedule action, move party, diplomacy actions
- generation mode: quest/item/character generation tools

Smaller tool surfaces reduce accidental side effects and reduce prompt complexity.

## Pattern 9: Error-Transparent Orchestration Pattern

When something fails:

- emit `action.failed` (or generation failure event)
- include machine-readable reason codes
- return concise natural-language failure feedback to player
- keep failure visible in logs and event history

Never swallow exceptions and never silently convert failures into success text.

## Pattern 10: Iterative Hardening Pattern (minimal parser boundary)

Accept a tiny parser boundary only where unavoidable:

- sentence chunking for streaming display
- markdown/emote segment boundaries if needed for UI voice routing

Do not reintroduce large correctness parsers that attempt to recover all gameplay semantics from raw model text.

## Recommended baseline architecture

1. `input/` - builds thin turn envelopes.
2. `inference/` - runs model with tool calling.
3. `tools/` - authoritative domain mutations.
4. `events/` - append-only event log + queue.
5. `projection/` - UI/world projections from events.

This architecture keeps NPC dialogue and NPC actions simple first, while leaving room for delayed actions and procedural systems without returning to parser-heavy design.

