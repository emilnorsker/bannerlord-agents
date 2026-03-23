# Dynamic events — antipatterns and status

This document tracks integration issues between **dynamic events**, **diplomacy storage**, **NPC save data**, and the future **World system**. It complements `docs/INTRIGUE_SYSTEM_DESIGN.md`.

## Resolved in code (this branch)

| Issue | Mitigation |
|--------|------------|
| Ad hoc merge of primary + diplomatic JSON in multiple UIs | `DynamicEventsManager.GetActiveEvents()` returns merged, deduped events; `WorldEventsReadFacade` is the documented entry point. |
| Prompt ignored `NPCContext.DynamicEvents` | `GetEventsForNPC` syncs knowledge and filters by saved ids; prompts use `GetEventsForNPC`. |
| Duplicate `ShouldNPCKnowEvent` in generator | Dialogue-only path calls `DynamicEventsManager.ShouldNPCKnowEvent`. |
| `RecentEvents` init used only `CharactersInvolved` | `InitializeActiveEventsForNPC` uses `GetEventsForNPC(..., persistKnowledgeSync: false)` so seeding matches visibility rules. |
| Statement cleanup scanned two event lists | `CleanupOldStatements` uses merged `GetActiveEvents()` only. |
| Global rumor shortcut (`importance` threshold) | Private const `GlobalRumorImportanceThresholdInclusive` in `DynamicEventsManager` (default 8; set to 11 in code to disable). Not in MCM. |
| `_generationInProgress` cleared on thread pool | Continuation runs on `MainThreadDispatcher` so the flag matches map-thread usage. |

## Optional field

- **`plot_id`** on `DynamicEvent` (JSON `plot_id`): reserved for intrigue linkage; emitters can set when plot pipeline exists.

## Backlog (not implemented here)

| Issue | Notes |
|--------|--------|
| Single physical store | Still two files at rest; merge is read-time. Consolidation is a larger migration. |
| LLM path = proposal → validate → commit | Generator/analyzer remain prose/JSON-parse; align with World spec in a dedicated refactor. |
| Append-only **event diary** | Required for episode patterns; see `INTRIGUE_SYSTEM_DESIGN.md`. |
| Replace singleton fan-out | Introduce injectable services or a World coordinator when intrigue lands. |
| `WorldEventsReadFacade` | Thin wrapper only; expand when snapshot builder exists. |

## Terms

| Term | Definition |
|------|------------|
| **Merged registry** | Result of `GetActiveEvents()`: primary dynamic events plus `diplomatic_events.json`, deduped by `id`. |
| **NPC dynamic event knowledge** | `NPCContext.DynamicEvents` (list of event ids), maintained by spread + sync. |
