# Native LLM Usage in Games

This document defines only the patterns required for the new NPC dialogue + NPC action rewrite.

## Scope

- One unified queue/channel for dialogue and action events.
- LLM interacts with the game through tools for state changes.
- Model output format is plain assistant text plus tool calls from the runtime.
- Initial action scope:
  - `follow_player`
  - `go_to_settlement`
  - `attack_party`
  - `return_to_player`

## Non-goals

- No giant parser that reconstructs gameplay semantics from raw model text.
- No large response schema contract from the model.
- No old-system edge-case prompt branching in this new path.

## Runtime contract

1. Player sends natural language input.
2. Runtime calls LLM with system prompt + minimal current context.
3. LLM returns plain text and may call tools.
4. Tool execution is the authoritative world-state mutation path.
5. Every relevant side effect appends an event into one unified queue.
6. Consumers project UI/world behavior from the queue.

## Minimal unified queue spec

Required event fields:

- `sequence` (monotonic in one process)
- `timestamp_utc`
- `correlation_id` (one interaction chain)
- `npc_id`
- `type`
- `name`
- `message`

Queue event types for v1:

- `dialogue_spoken`
- `action_started`
- `action_completed`
- `action_failed`

## Instant vs long-running semantics

Instant tools:

- `npc_say` emits `dialogue_spoken` immediately.
- Future instant tools (example: `transfer_item`) emit completion in the same tick.

Long-running tools:

- `follow_player`, `go_to_settlement`, `attack_party`, `return_to_player` emit `action_started` when accepted.
- World systems emit `action_completed` or `action_failed` later when resolved.

## Producer and consumer model

Producers:

- LLM tool executor (primary)
- World/action resolver (for completions/failures)

Consumers (same queue, independent):

- Dialogue consumer: renders chat panel and conversation UI.
- Action consumer: renders pills/world notifications and applies state transitions.
- Future systems: quest/item/character generators can subscribe without changing the queue contract.

## Minimal processing loop

1. Handle assistant text:
   - append `dialogue_spoken` when non-empty.
2. Handle each tool call:
   - execute tool
   - append `action_started` (or immediate result event for instant tools)
3. On world tick outcomes:
   - append `action_completed` or `action_failed`
4. Consumers read in queue order.

## Error policy

- Never swallow exceptions.
- Unknown tool names are hard failures.
- Failed actions must append `action_failed` with a concrete reason message.

## Why this is minimal

- One queue, one event contract, one ordering.
- No UI merge logic across channels.
- No deep parser layer between model output and gameplay effects.
- Easy to extend by adding tools and consumers, not by adding parser branches.

