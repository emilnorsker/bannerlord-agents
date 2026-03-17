# Right Panel Audit — Chat Menu Side Panel

## Summary

The right panel in `ChatInterface.xml` displays three sections: **WORLD EVENTS**, **WHAT WE KNOW**, and **CHARACTER**. This audit identifies why each section may fail or behave incorrectly.

---

## 1. WHAT WE KNOW — Not Always Displayed

### Root causes

**A) KnownInfo stores IDs, not display text**

```101:133:src/AIInfluence/NpcChatWindowVM.cs
    private void PopulateRightPanel(Hero npc, NPCContext context)
    {
        // ...
        foreach (string info in context?.KnownInfo ?? new List<string>())
            if (!string.IsNullOrWhiteSpace(info))
                RightPanelItems.Add(new TextItemVM("• " + info));
```

`KnownInfo` holds **Information.Id** values (e.g. `"war_kingdom_a"`), not human-readable text. The panel shows these raw IDs.

PromptGenerator resolves IDs to descriptions:

```385:391:src/AIInfluence/PromptGenerator.cs
		if (context.KnownInfo.Any())
		{
			List<string> list2 = (from i in WorldInfoManager.InformationManager.Instance.GetInfo()
				where context.KnownInfo.Contains(i.Id)
				select i.Description.Replace("{character}", npcName) + " (category: " + i.Category + ")").ToList();
```

**Fix:** Resolve IDs via `WorldInfoManager.InformationManager.Instance.GetInfo()` and show `i.Description` (and optionally `i.Category`), same as PromptGenerator.

**B) Quirks vs AIGeneratedSpeechQuirks**

The panel uses `context?.Quirks` (a `List<string>`), but the system mainly populates `AIGeneratedSpeechQuirks` (a single string). `Quirks` is often empty.

**Fix:** Also show `context.AIGeneratedSpeechQuirks` when non-empty.

**C) AIGeneratedPersonality timing**

`AIGeneratedPersonality` is filled during conversations (AI response, initiative system). New NPCs or first-time chats may not have it yet.

**Fix:** No code change; this is expected. Optionally show a placeholder like “Personality not yet discovered” when empty.

---

## 2. WORLD EVENTS — Not Visible Despite Events Existing

### Root causes

**A) Chat panel vs World Events window**

- **Chat panel:** Uses only `DynamicEventsManager.Instance?.GetActiveEvents()`.
- **World Events window:** Uses both `GetActiveEvents()` and `DiplomacyStorage.LoadDiplomaticEvents()` and merges them.

Events that exist only in diplomacy storage (e.g. from previous sessions or diplomatic flow) will appear in the World Events window but not in the chat panel.

**Fix:** Mirror the World Events logic: also load from `DiplomacyStorage.LoadDiplomaticEvents()` and merge with `GetActiveEvents()` before displaying.

**B) DynamicEventsManager initialization**

`GetActiveEvents()` returns `_activeEvents`, which is filled in `Initialize()` from `DynamicEventsStorage.LoadEvents()`. If:

- `Initialize()` has not run yet, or
- `DynamicEventsManager.Reset()` was called (e.g. via `ResetAllSystems` when leaving a campaign),

then `_activeEvents` is empty and the panel shows nothing.

**C) EnableDynamicEvents / EnableModification**

These settings only affect **generation** in `OnDailyTick()`. They do not clear existing events. If events were loaded from storage, they should still appear. If no events were ever generated or saved, the list stays empty.

**D) Exception handling**

```117:121:src/AIInfluence/NpcChatWindowVM.cs
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] PopulateRightPanel DynamicEvents failed: " + ex.Message);
        }
```

Exceptions are caught and logged; the panel continues with an empty list. Check logs for `[NpcChatWindow] PopulateRightPanel DynamicEvents failed`.

---

## 3. CHARACTER — Real-Time Updates (FIXED)

**Status:** Implemented. The CHARACTER section and left trait overlay now refresh after each AI reply. `UpdateContextData` is called before refresh so Trust and Mood are recomputed. Context is saved after `UpdateContextData` to persist the recomputed values.

---

## 4. Data Flow Summary

| Section        | Data source                                      | When populated | Refresh? |
|----------------|--------------------------------------------------|----------------|----------|
| WORLD EVENTS   | `DynamicEventsManager.GetActiveEvents()`         | Constructor     | No       |
| WHAT WE KNOW   | `context.AIGeneratedPersonality`, `Quirks`, `KnownInfo` | Constructor     | No       |
| CHARACTER      | `npc.GetRelation()`, `context.TrustLevel`, etc.  | Constructor     | Yes (after each reply) |

---

## 5. Recommended Fixes (in order)

1. **KnownInfo:** Resolve IDs to descriptions via `WorldInfoManager.InformationManager.Instance.GetInfo()`.
2. **Quirks:** Include `AIGeneratedSpeechQuirks` in WHAT WE KNOW.
3. **World events:** Merge with `DiplomacyStorage.LoadDiplomaticEvents()` like the World Events window.
4. **Real-time CHARACTER:** Refresh CHARACTER (or full panel) after each AI reply in `ExecuteSendMessage`.
