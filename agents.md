# Agent Guidelines

## Before implementing a field/property addition

When adding a field to a data-transfer object (DTO), always search for every place
that object is *constructed* before writing any code. Use the constructor name as the
search term (e.g. `new DiplomaticActionInfo`, `new KingdomStatement`).

For each construction site found:
- Does this site read from a source object that carries the new field?
- If yes, the new field must be propagated here too.

Do not commit until all construction sites are handled. Do not assume one site is
"the primary path" and treat the others as secondary.

## The parallel-field verification rule

When adding a field that mirrors an existing one, pick the *most recently added*
similar field and grep for it across the entire codebase. Every location that
references that field is a location your new field also needs to appear. Missing
even one is a bug.

Example: adding `NewKingdomInformalName` alongside `NewKingdomName` — grep for
`QuarantineDurationDays` (the last field added before yours) to find all sites.

## Trace every value end-to-end before committing

For any value the AI produces in a JSON response, verify the full chain:

  AI JSON → deserialization model → intermediate DTO(s) → persistence model → execution method

If any link in that chain does not pass the value forward, the AI's output is
silently discarded with no error. Trace all paths, not just the one currently
being edited.

In this codebase the chain for NPC diplomatic actions is:
  DiplomaticStatementResponse → KingdomStatement → DiplomaticActionInfo → ExecuteDiplomaticAction

The chain for player diplomatic actions is:
  PlayerStatementAnalysisResponse → DelayedPlayerStatement → SerializedPlayerStatement
  → (save/load) → DelayedPlayerStatement → DiplomaticActionInfo → ExecuteDiplomaticAction

Both chains must be complete for any new field.

## On "one focused change at a time"

This rule governs the *size* of each change, not permission to stop looking. After
making a focused change, ask: "are there other places in the codebase with the same
shape as what I just changed?" If yes, fix them in the same commit or the
immediately following one — do not leave known gaps open.
