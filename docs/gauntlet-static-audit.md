# Gauntlet static audit (engine DLLs in repo)

This document replaces hand-waving about “only the real client can tell.” **Anything below is checked against the TaleWorlds assemblies under `.github/workflows/dlls/`** (same API surface as shipping). What **cannot** be proven here is listed explicitly.

## 1. Mouse wheel on `ScrollablePanel`

**Source:** `TaleWorlds.GauntletUI.BaseTypes.ScrollablePanel` (`TaleWorlds.GauntletUI.dll`).

- `OnMouseScroll()` adds velocity to **horizontal** scroll only when `(Shift && HorizontalScrollbar != null)` **or** `VerticalScrollbar == null`; otherwise it uses **vertical** if `VerticalScrollbar != null`. It does **not** read `MouseScrollAxis`.
- A repo-wide search of the decompiled `ScrollablePanel` type shows **`MouseScrollAxis` is declared but never referenced** in that type’s implementation (only the field declaration appears).

**Implication:** Setting `MouseScrollAxis="Vertical"` in XML is **not** what drives wheel direction; wiring a **non-null `VerticalScrollbar`** is. Keeping `MouseScrollAxis` on a prefab is at best documentation; at worst it implies behavior the engine does not implement in this build.

**Our prefabs:** `ChatInterface.xml` — `ChatScrollPanel` uses `VerticalScrollbar="..\ChatScrollBar\Scrollbar"`; `InfoScrollPanel` uses `VerticalScrollbar="..\..\InfoScrollBar\Scrollbar"` (two `..` because `InfoScrollBar` is a **sibling** of `InfoFrame` under `RightColumn`, not a child of `InfoScrollPanel`).

## 2. `OnlyAcceptScrollEventIfCanScroll`

**Source:** same `ScrollablePanel`, `OnPreviewMouseScroll()`.

Default field `_onlyAcceptScrollEventIfCanScroll` is **false** unless XML sets it. When false, preview always allows the scroll event through (subject to other rules).

**Our prefabs:** we do not set this attribute; engine default applies.

## 3. `NavigationScopeTargeter` + `ScopeMovements="Vertical"`

**Source:** `TaleWorlds.MountAndBlade.GauntletUI.Widgets.NavigationScopeTargeter` (`TaleWorlds.MountAndBlade.GauntletUI.Widgets.dll`).

- `ScopeMovements` maps to `GamepadNavigationScope.ScopeMovements`.
- `ScopeParent` assigns **`NavigationScope.ParentWidget`** and registers the scope with `GamepadNavigationContext`.

**Enum:** `TaleWorlds.GauntletUI.GamepadNavigation.GamepadNavigationTypes` (`TaleWorlds.GauntletUI.dll`):

- `[Flags]` with `Vertical = 3` (`Up | Down`).

So **`ScopeMovements="Vertical"`** is a **valid** literal for the XML loader.

**Path:** `ScopeParent="..\InfoSectionsList"` from a widget that shares the same parent as `NavigatableListPanel` `Id="InfoSectionsList"` resolves that list as the scope parent (prefab loader binds string paths to widgets before the setter runs).

## 4. `NavigatableListPanel` + scrolling while navigating

**Source:** `TaleWorlds.MountAndBlade.GauntletUI.Widgets.NavigatableListPanel`.

- On `OnConnectedToRoot`, if `ParentPanel == null`, it sets **`ParentPanel = FindParentPanel()`** (walks ancestors for a `ScrollablePanel`).
- `OnWidgetGainedGamepadFocus` calls **`ParentPanel.ScrollToChild(widget, scrollParameters)`** when `ParentPanel` is set.

**Our prefab:** `InfoSectionsList` is inside `InfoScrollPanel`; **no explicit `ParentPanel` attribute is required** for auto-linking, assuming the ancestor `ScrollablePanel` is found.

**Ancestor walk:** `TaleWorlds.GauntletUI.BaseTypes.Container.FindParentPanel()` walks `ParentWidget` until it finds a `ScrollablePanel`. Hierarchy here is `InfoSectionsList` → `InfoClipRect` → `InfoScrollPanel` (`ScrollablePanel`), so the lookup **succeeds**.

## 5. `OrderFormationClassVisualBrushWidget` + mod brush

**Source:** `TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.Order.OrderFormationClassVisualBrushWidget` — `FormationClassValue` switches `SetState("Infantry" | "Ranged" | "Cavalry" | "HorseArcher" | default→Infantry)`.

**Our brush:** `AIInfluence.ClanPartyFormationStrip` in `GUI/Brushes/PopUpBrush.xml` defines those four style names with `Layer` + `Sprite` — `BrushFactory.LoadBrushLayerInto` resolves `Sprite` via `SpriteData.GetSprite` (same pipeline as vanilla brushes).

**Remaining risk (not DLL-provable here):** runtime widget name resolution for `OrderFormationClassVisualBrushWidget` in XML (module load order / widget factory). If the game fails to instantiate the type, the log will show a prefab parse error.

## 6. Vanilla `Encyclopedia.*` brush names

**Limit:** Brush **definitions** live in the game’s Native/Sandbox **GUI brush XML**, not in these DLLs. The DLLs only implement **loading** and **lookup by name**.

**What we can do statically:** enumerate every `Brush="..."` in `GUI/Prefabs/ChatInterface.xml` and ensure each non-mod brush is **intentional** (see grep / review in PR). A **missing** brush name fails at **Gauntlet load** when that widget is first built, which is still “runtime,” but it is **deterministic** (not gameplay-dependent).

### `Encyclopedia.*` names referenced in `ChatInterface.xml`

| Brush name |
|------------|
| `Encyclopedia.Page.SoundBrush` |
| `Encyclopedia.Character.Smoke` |
| `Encyclopedia.Character.Smoke2` |
| `Encyclopedia.SubPage.Info.Text` |
| `Encyclopedia.SubPage.Title.Text` |
| `Encyclopedia.Skill.Text` |
| `Encyclopedia.TopBanner` |
| `Encyclopedia.Frame` |

**Mod-local:** `AIInfluence.ClanPartyFormationStrip` (defined in our `PopUpBrush.xml`).

## 7. Vertical stack order (`VerticalTopToBottom` vs `VerticalBottomToTop`)

**Source:** `TaleWorlds.GauntletUI.Layout.StackLayout.LayoutLinearVertical` (`TaleWorlds.GauntletUI.dll`). Children are laid out in **XML / `ChildCount` order** (`j = 0 .. ChildCount-1`).

From the implementation:

- **`VerticalTopToBottom`:** each child is placed **below** the previous one (working from the **top** of the parent downward). **First child in the container = visually at the top** (reading order = declaration order).
- **`VerticalBottomToTop`:** each child is placed **above** the previous one (working from the **bottom** upward). **First child = visually at the bottom** of the parent; **last child = visually at the top**.

**`ChatInterface.xml` usage (intentional split):**

| Region | `ListPanel` | Meaning |
|--------|-------------|--------|
| **`InfoSectionsList`** | `VerticalTopToBottom` | `NpcChatWindowVM` pushes sections in reading order (Character → … → Party). **First in `InfoSections` = top of the column.** Matches `RebuildInfoPanelSections` comment. |
| **Section item template** (header + body) | `VerticalTopToBottom` | Header `ButtonWidget` is declared **first**, expanded body **second** → **header above body** (not reversed). |
| **GlyphLines / TextLines** | `VerticalTopToBottom` | Lines appear in list order top-to-bottom. |
| **`ChatMessageList`** | `VerticalBottomToTop` | **Not** the same as the info column: first `MessageList` item is anchored to the **bottom** of the inner stack; appending messages (`MessageList.Add`) puts **older messages lower** and **newer higher** in the scroll area. Do **not** “fix” the info column to match this unless you also change chat UX on purpose. |

**Gamepad index caveat:** `NavigatableListPanel` assigns `GamepadNavigationIndex` using **different formulas** for `VerticalTopToBottom` vs other layouts (`SetNavigationIndexForChild` in `NavigatableListPanel`). Focus order can **feel** different from mouse hit order — that is separate from **visual** stacking.

## 8. What still needs a real client (honest list)

- **Visuals:** pixel alignment, alpha stacking, and font metrics.
- **Input devices:** physical gamepad focus order and Steam Deck quirks.
- **Asset packs:** a brush name can exist in **1.2** and be renamed in **1.3** — DLLs here don’t embed the full Native brush list.

---

*When updating scroll/navigation behavior, re-run `ilspycmd` on `ScrollablePanel` / `NavigationScopeTargeter` if the game updates `TaleWorlds.GauntletUI.dll` — behavior can change between patches.*
