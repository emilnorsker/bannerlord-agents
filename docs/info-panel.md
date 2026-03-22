# NPC chat — Information panel (right column)

## Sections (top → bottom)

| Order | Header            | Purpose |
|------:|-------------------|--------|
| 1 | Character         | Relation, trust, interaction count (`TextLines`). Header skill icon: Charm. |
| 2 | Character history | AI `character_backstory` → `NPCContext.AIGeneratedBackstory` (`TextLines`; newline-split). Roguery. |
| 3 | Behavior          | AI personality, quirks, speech, mood (`TextLines`). Steward. |
| 4 | Quests            | Active / incoming AI quests (`TextLines` only). Trade. |
| 5 | World events      | Recent dynamic events with skill icon (`GlyphLines`) or “None” (`TextLines`). Tactics. |
| 6 | NPC party info    | Vanilla-style troop count strip (`ShowPartyTroopStrip` + `InfantryCount`…`HorseArcherCount`, same layout as Clan → Parties detail) + optional food line. Leadership. |

`SectionPanelColor` is a **single** subtle tint for all sections (encyclopedia frame provides the main chrome; no alternating zebra).

## Data → UI mapping

| VM | Gauntlet |
|----|----------|
| `InfoSectionVM.GlyphLines` (`InfoGlyphLineVM`) | **World events only:** `IsSkill` + `SkillIconVisualWidget` + text. |
| `ShowPartyTroopStrip` + `InfantryCount` / `RangedCount` / `CavalryCount` / `HorseArcherCount` + `InfantryHint`…`HorseArcherHint` (`HintViewModel`) | **NPC party info:** same widget tree as vanilla `ClanPartiesRightPanel` `TroopCountsParent` / `TroopCountsList` — `General\TroopTypeIcons\icon_troop_type_*`, `GamepadNavigationIndex` 0–3, `HintWidget` + `str_formation_class_string.*` tooltips, `Clan.TroopCount.Text` `IntText`. |
| `InfoSectionVM.TextLines` (`TextItemVM`) | Plain rich-text bullets (no left glyph). |
| `PartyFoodText` / `PartyFoodColor` + `ShowPartyFood` | Single optional line under the lists. |

## Visibility

Call **`InfoSectionVM.RefreshVisibility()`** after filling a section. It sets:

- `HasGlyphLines` = `GlyphLines.Count > 0`
- `HasStandardTextLines` = `TextLines.Count > 0`
- `ShowPartyFood` = previous `ShowPartyFood` && non-empty `PartyFoodText`
- `ShowPartyTroopStrip` = previous `ShowPartyTroopStrip` && sum of the four formation counts &gt; 0

Prefab: `GUI/Prefabs/ChatInterface.xml` — **`ChatMainInset`**: vanilla **`Frame1Brush`** (Native `Main.xml`: `Frame1_canvas` / `Frame1_frame` — same brush family as Clan parties left list / `Standard.Window`). Right column uses **`InfoBody`** (`Widget` only; **`Encyclopedia.Frame` removed** to avoid the strong top/body split). Horizontal padding for scroll content is **`!Info.Inset`** (24px) on **`InfoScrollPanel`** only; inner lists use **0** lateral margin. Section headers use **`SkillIconVisualWidget`** + `InfoSectionVM.HeaderSkillId` (vanilla skill art). Expand/collapse uses ASCII **`v` / `>`** (Unicode arrows were missing glyphs and showed “?”). **`NavigationScopeTargeter`** (`NpcChatInfoSectionsScope`) → **`InfoSectionsList`**. **`InfoScrollPanel`** (`ClipRect` = **`InfoClipRect`**, inner = **`InfoSectionsList`**); sibling **`InfoScrollBar`** (invisible). Expanded body order: **GlyphLines → TextLines → `NpcPartyTroopCountsParent` (party section only) → party food**.

**Engine verification (no game client required):** `docs/gauntlet-static-audit.md` — scroll wheel, nav scope, `NavigatableListPanel` ↔ `ScrollablePanel`, and `Encyclopedia.*` brush names referenced by this prefab are traced from **`TaleWorlds.GauntletUI.dll`** / **`TaleWorlds.MountAndBlade.GauntletUI.Widgets.dll`**. What still needs a real install is listed there (pixels, device quirks, brush renames across game patches).

## Vanilla reference (game install)

Clan / party **screens** use different UX (tabs + rosters). This panel is **encyclopedia-style** reference next to chat; match **brushes/spacing** to vanilla as needed — prefab names live under the game’s `Modules` / `GUI` trees (not in this repo’s CI DLL set).
