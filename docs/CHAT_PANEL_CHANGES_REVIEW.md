# Thorough Review of Chat Panel Changes

Review of the real-time CHARACTER refresh implementation and related artifacts.

**Status:** Issues 1–11 addressed. Issue 12 is pre-existing.

---

## 1. **TrustLabel thresholds are wrong (BUG)** — FIXED

**Location:** `NpcChatWindowVM.cs` line 90

```csharp
TrustLabel = context.TrustLevel >= 60 ? "High Trust" : context.TrustLevel >= 30 ? "Moderate Trust" : "Low Trust";
```

**Issue:** `TrustLevel` is a float in the range **0–1** (see `AIInfluenceBehavior.UpdateTrustLevel` lines 3389, 3397: `Math.Min(1f, ...)`). Comparing to 60 and 30 means "High Trust" and "Moderate Trust" are never shown.

**Fix:** Use `>= 0.6f` and `>= 0.3f`. ✓

---

## 2. **Context saved before UpdateContextData — stale persistence (BUG)** — FIXED

**Location:** `NpcChatWindowVM.cs` doFinalize, lines 523–531

**Issue:** `SaveNPCContext` is called before `UpdateContextData`. `UpdateContextData` recomputes TrustLevel, EmotionalState, etc., but those changes are never persisted. The saved file has the pre-`UpdateContextData` state.

**Fix:** Call `SaveNPCContext` again after `UpdateContextData`. ✓

---

## 3. **Dead code: unused variable in PopulateRightPanel** — FIXED

**Location:** `NpcChatWindowVM.cs` line 144

```csharp
int rel = (int)npc.GetRelation(Hero.MainHero);
RightPanelItems.Add(new TextItemVM(" ", "#00000000"));
_characterSectionStartIndex = RightPanelItems.Count;
```

**Issue:** `rel` is never used. `AddCharacterSectionItems` computes relation internally.

**Fix:** Remove the unused `rel` variable. ✓

---

## 4. **Trust display in CHARACTER section may be unclear** — FIXED

**Location:** `NpcChatWindowVM.cs` line 157

```csharp
RightPanelItems.Add(new TextItemVM($"Trust: {context?.TrustLevel:F0}"));
```

**Issue:** With TrustLevel in 0–1, `F0` shows "0" or "1". That is not very informative.

**Fix:** Use `Trust: {(context?.TrustLevel ?? 0) * 100:F0}%`. ✓

---

## 5. **OnPropertyChangedWithValue overload for strings** — FIXED

**Location:** `NpcChatWindowVM.cs` lines 97–100

```csharp
((ViewModel)this).OnPropertyChangedWithValue(RelationText, "RelationText");
```

**Issue:** Other ViewModels use `OnPropertyChangedWithValue<string>(value, "PropertyName")` for string properties (e.g. `AIInfluenceTextQueryPopupVM`, `ContentSegmentVM`). The non-generic overload may work but is inconsistent.

**Fix:** Use `OnPropertyChangedWithValue<string>` for all string properties. ✓

---

## 6. **Null check for AIInfluenceBehavior.Instance** — FIXED

**Location:** `NpcChatWindowVM.cs` lines 414–419

```csharp
if (ctx != null)
{
    AIInfluenceBehavior.Instance?.UpdateContextData(ctx, _npc);
    RefreshTraitOverlay(_npc, ctx);
    RefreshCharacterSection(_npc, ctx);
}
```

**Issue:** If `AIInfluenceBehavior.Instance` is null, `UpdateContextData` is skipped but `RefreshTraitOverlay` and `RefreshCharacterSection` still run with stale `ctx`. That could be intentional (show last known state), but it is inconsistent.

**Fix:** Guard with `ctx != null && AIInfluenceBehavior.Instance != null`. ✓

---

## 7. **UpdateContextData can throw** — FIXED

**Location:** `NpcChatWindowVM.cs` doFinalize

**Issue:** `UpdateContextData` performs many operations (e.g. `WorldInfoManager`, `UpdateTrustLevel`). If it throws, the outer catch logs and the UI is not refreshed. That is acceptable, but the user might see partial or stale UI.

**Fix:** Wrap `UpdateContextData` in try/catch so refresh still runs. ✓

---

## 8. **Wireframe documentation** — FIXED

**Location:** `docs/CHAT_PANEL_WIREFRAME.md`

**Fix:** Added NpcTitle note and TrustLabel threshold note. ✓

---

## 9. **RIGHT_PANEL_AUDIT.md is stale** — FIXED

**Location:** `RIGHT_PANEL_AUDIT.md` Section 3

**Issue:** Still states "CHARACTER — No Real-Time Updates" and "Fix: Refresh..." even though the feature is implemented.

**Fix:** Updated audit. ✓

---

## 10. **RIGHT_PANEL_RESEARCH.md is stale** — FIXED

**Location:** `RIGHT_PANEL_RESEARCH.md` Sections 3 and 4

**Issue:** Still states "The current implementation only reliably updates Interactions" and "What would be needed for true real-time updates" even though `UpdateContextData` is now called before refresh.

**Fix:** Updated research. ✓

---

## 11. **ChatInterface.xml comment vs constants** — FIXED

**Location:** `ChatInterface.xml` lines 4–5

**Fix:** Updated comment to 460. ✓

---

## 12. **Early return leaves player message without reply** — PRE-EXISTING

**Location:** `NpcChatWindowVM.cs` line 388

```csharp
if (AIInfluenceBehavior.Instance == null) return;
```

**Issue:** If `Instance` is null, we return after adding the player message but before any reply. The player sees their message but no response. This is pre-existing behavior.

---

## Summary of issues by severity

| # | Severity | Issue |
|---|----------|-------|
| 1 | **High** | TrustLabel thresholds 60/30 wrong for 0–1 TrustLevel |
| 2 | **High** | Context saved before UpdateContextData — stale persistence |
| 3 | Low | Dead code: unused `rel` |

| 4 | Medium | Trust display "0" or "1" in CHARACTER section |
| 5 | Low | OnPropertyChangedWithValue generic overload |
| 6 | Low | Null check for Instance |
| 7 | Low | UpdateContextData exception handling |
| 8 | Low | Wireframe missing NpcTitle |
| 9 | Low | Audit doc stale |
| 10 | Low | Research doc stale |
| 11 | Low | XML comment outdated |
| 12 | Low | Pre-existing early return behavior |
