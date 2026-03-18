# UI Sprite Reference — ChatInterface & Built-in Alternatives

Reference for textures/backgrounds used in ChatInterface and built-in alternatives when not using the modkit.

## Sprites Used in ChatInterface (Current)

| Sprite Name | Source | SheetID | SheetX | SheetY | W | H | Category |
|-------------|--------|---------|--------|--------|---|---|----------|
| BlankWhiteSquare_9 | Native | 3 | 3552 | 710 | 25 | 25 | ui_group1 |
| BlankWhite | Engine (procedural) | — | — | — | — | — | solid white |
| chat_panel_bg | **Custom** (ui_aiinfluence) | — | — | — | — | — | — |
| chat_msg_separator | **Custom** (ui_aiinfluence) | — | — | — | — | — | — |
| name_shadow_9 | Native (Conversation\name_shadow) or Custom | 1 | 2282 | 4 | 142 | 65 | ui_conversation |
| frame_9 | Native | 2 | 2976 | 4 | 540 | 673 | ui_group1 (StdAssets\Popup\frame) |
| General\CharacterCreation\character_creation_background_gradient | Native | 1 | 4028 | 2671 | 32 | 382 | ui_group1 |
| General\CharacterCreation\name_input_area | Native | 1 | 1453 | 1497 | 397 | 32 | ui_group1 |

## Built-in Alternatives (Replace Custom with Native)

| Use Case | Built-in Sprite | SheetID | SheetX | SheetY | W | H |
|----------|-----------------|---------|--------|--------|---|---|
| Panel background | StdAssets\Popup\canvas_gradient | 2 | 1048 | 685 | 512 | 645 |
| Panel background | StdAssets\standart_popup | 1 | 4 | 4 | 1500 | 960 |
| Header/divider | StdAssets\Popup\divider | 2 | 871 | 3602 | 521 | 23 |
| Message separator | StdAssets\Popup\divider | 2 | 871 | 3602 | 521 | 23 |
| Frame border | frame_9 (StdAssets\Popup\frame) | 2 | 2976 | 4 | 540 | 673 |
| Frame border | Frame1Broken_canvas | 1 | 868 | 972 | 512 | 512 |
| Frame border | Frame1Broken_frame | 1 | 1388 | 977 | 512 | 512 |

## Party Screen (Troop Panel) Backgrounds

From `SandBox/GUI/Brushes/PartyScreen.xml` and `Party/PartyScreen.xml`:

| Brush/Sprite | Sprite Name | SheetID | SheetX | SheetY | W | H |
|--------------|-------------|---------|--------|--------|---|---|
| Party.UpgradePopup.Frame | StdAssets\standart_popup | 1 | 4 | 4 | 1500 | 960 |
| Party.UpgradePopup.Frame | Frame1_frame | 1 | 1570 | 2079 | 663 | 847 |
| Party.UpgradePopup.Dent | SPGeneral\dent_leftlist | 1 | 2241 | 2248 | 683 | 750 |

## StdAssets\Popup — Full List (ui_group1)

| Sprite | SheetID | SheetX | SheetY | W | H |
|--------|---------|--------|--------|---|---|
| canvas | 2 | 1568 | 706 | 512 | 645 |
| canvas_dark | 1 | 3085 | 3179 | 699 | 666 |
| canvas_gradient | 2 | 1048 | 685 | 512 | 645 |
| divider | 2 | 871 | 3602 | 521 | 23 |
| divider_vertical | 2 | 4032 | 1144 | 23 | 714 |
| frame | 2 | 2976 | 4 | 540 | 673 |
| button_default | 2 | 616 | 2822 | 251 | 64 |
| done_button | 2 | 2660 | 3227 | 251 | 64 |
| text_input | 2 | 2543 | 4046 | 370 | 40 |

## Sprite Sheet Locations

- **Native**: `Modules/Native/AssetPackages/gauntlet_ui.tpac`
- **SandBox**: `Modules/SandBox/AssetPackages/gauntlet_ui.tpac`
- **ui_group1** sheets: 4096×4096 (ID 1,2), 4096×2048 (ID 3)

## Extracting Textures

To extract and view the actual PNG textures:

1. **TpacTool** (GUI): https://github.com/hunharibo/TpacTool/releases  
   - Point to Bannerlord folder, open `gauntlet_ui.tpac`, export textures.

2. **Pre-extracted sprites**: https://drive.google.com/drive/folders/1gfE8ERq6hzKGy6Ya_RbpaUPVy3DXsP6u  
   - BannerEdge-extracted native sprites (organized by category).

3. **Crop from sheet**: Run `python scripts/extract_sprite_regions.py --output-dir docs/extracted_sprites` to generate `crop_regions.sh`.  
   Run after extracting sheets from tpac with TpacTool.  
   `--list-used` prints only ChatInterface sprites as JSON.

## Switching to Built-in Only

Replace custom sprites in `ChatInterface.xml`:

- `chat_panel_bg` → `StdAssets\Popup\canvas_gradient` or `StdAssets\standart_popup`
- `chat_msg_separator` → `StdAssets\Popup\divider`
- `name_shadow_9` → remove or use `BlankWhiteSquare_9` with `AlphaFactor`

Remove `GUI/AIInfluenceSpriteData.xml` and `GUI/Config.xml` sprite category if using only built-in.
