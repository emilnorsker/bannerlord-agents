# Right Panel CHARACTER Section — Research Findings

## Data flow when a message is sent

### 1. ProcessChatInput (AIInfluenceBehavior.cs:3071)

**At start:**
- `UpdateContextData(context, npc)` — updates PlayerRelation, EmotionalState, TrustLevel, etc. from current game state

**After AI response:**
- `context.InteractionCount++` (line 3149) — **immediately updated**
- `context.PendingRelationChange` — set when tone is positive/negative or lie detected
- `ApplyRelationChangeWithDelay(npc, rel, ...)` — **schedules** relation change for 4 seconds later (line 830)
- `UpdateTrustLevel(context, npc)` — **only** when lie detected (line 3317)
- `SaveNPCContext` — persists context

**Relation changes:** Applied via `ApplyRelationChangeWithDelay` → `DelayedTaskManager.AddTask(4.0, ...)`. The actual `ChangeRelationAction.ApplyPlayerRelation` runs 4 seconds after the call. When is it called? From `AIDecisionHandler` / `ProcessChatInput` when tone is positive/negative, or from `DialogManager` when conversation ends (for PendingRelationChange). So relation does **not** update immediately — it is delayed.

### 2. What is fresh when doFinalize runs?

| Field | Updated in ProcessChatInput? | Fresh when we refresh? |
|-------|------------------------------|------------------------|
| **Relation** | No — scheduled 4s later | **No** — `npc.GetRelation()` still returns old value |
| **Trust** | Only for lie case | **No** (typical case) — TrustLevel uses InteractionCount; we never call UpdateTrustLevel after InteractionCount++ |
| **Interactions** | Yes — `context.InteractionCount++` | **Yes** |
| **Mood** | No — UpdateEmotionalState only in UpdateContextData at start | **No** — EmotionalState not refreshed after response |

### 3. What the current fix updates

The fix calls `UpdateContextData(ctx, _npc)` before refresh, then `RefreshTraitOverlay` and `RefreshCharacterSection`. That yields:
- **Interactions:** Correct (incremented in ProcessChatInput)
- **Relation:** Current game state (may lag until delayed task runs)
- **Trust:** Recomputed via UpdateContextData (uses new InteractionCount)
- **Mood:** Recomputed via UpdateContextData

Context is saved after UpdateContextData so recomputed values are persisted.

### 4. Left panel overlay

`RefreshTraitOverlay` updates `RelationText`, `TrustLabel`, `EmotionLabel` and notifies the UI via `OnPropertyChangedWithValue`.

### 5. Gauntlet / MBBindingList

MBBindingList fires `ListChanged` when items are added/removed. The RemoveAt + Add approach should trigger UI refresh. No evidence this is broken.

### 6. Threading

`doFinalize` runs on the main thread (either synchronously for non-streaming, or via the stream pump which uses `TtsLipSyncService.MainThreadQueue` / `DelayedTaskManager`). UI mutations should be safe.

### 7. Other patterns in codebase

- **NPCInitiativeSystem.RefreshContextData:** Calls `UpdateContextData` + `SaveNPCContext` — refreshes context from game state before saving.
- **WorldEventsWindowViewModel:** Creates new `MBBindingList` and assigns to `DeclarationList` — full reload, not incremental update.
- **CombatPhrasePopupVM:** Uses `Clear()` then `Add()` on the list for full refresh.

---

## Summary

The current fix refreshes the CHARACTER section after each reply, but most values shown (Relation, Trust, Mood) remain stale because:

1. Relation changes are applied 4 seconds later.
2. TrustLevel and EmotionalState are not recomputed after the response.

To make the refresh meaningful, we should call `UpdateContextData(ctx, _npc)` before `RefreshCharacterSection` so Trust and Mood are recomputed. Relation will still lag until the delayed task runs.
