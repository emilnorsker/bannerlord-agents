# NPC chat — Information panel (right column)

## Sections (top → bottom)

| Order | Header            | Purpose |
|------:|-------------------|--------|
| 1 | NPC party info    | Troop formations + party food (glyph rows + optional food line). |
| 2 | Quests            | Active / incoming AI quests (`TextLines` only). |
| 3 | World events      | Recent dynamic events with skill icon (`GlyphLines`) or “None” (`TextLines`). |
| 4 | Character history | AI `character_backstory` → `NPCContext.AIGeneratedBackstory` (`TextLines`; newline-split). |
| 5 | Behavior          | AI personality, quirks, speech, mood (`TextLines`). |
| 6 | Character         | Relation, trust, interaction count (`TextLines`). |

Stripe colors alternate per section in `RebuildInfoPanelSections`.

## Data → UI mapping

| VM | Gauntlet |
|----|----------|
| `InfoSectionVM.GlyphLines` (`InfoGlyphLineVM`) | One template: **skill icon** (`IsSkill`) **or** **formation sprite** (`IsFormation`) + `Text` + `Color`. World events and party troops use the same list. |
| `InfoSectionVM.TextLines` (`TextItemVM`) | Plain rich-text bullets (no left glyph). |
| `PartyFoodText` / `PartyFoodColor` + `ShowPartyFood` | Single optional line under the lists. |

## Visibility

Call **`InfoSectionVM.RefreshVisibility()`** after filling a section. It sets:

- `HasGlyphLines` = `GlyphLines.Count > 0`
- `HasStandardTextLines` = `TextLines.Count > 0`
- `ShowPartyFood` = previous `ShowPartyFood` && non-empty `PartyFoodText`

Prefab: `GUI/Prefabs/ChatInterface.xml` — **`InfoScrollPanel`** (`ClipRect` = **`InfoClipRect`**, inner = **`InfoSectionsList`**); sibling **`InfoScrollBar`** (invisible). Expanded body order: **GlyphLines → TextLines → party food** (see XML comments).

## Vanilla reference (game install)

Clan / party **screens** use different UX (tabs + rosters). This panel is **encyclopedia-style** reference next to chat; match **brushes/spacing** to vanilla as needed — prefab names live under the game’s `Modules` / `GUI` trees (not in this repo’s CI DLL set).
