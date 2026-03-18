# Custom Sprite Build

The mod uses custom sprites in `GUI/SpriteParts/ui_aiinfluence/`. To make them load in-game, you must run **SpriteSheetGenerator** to pack them.

## Prerequisites

- Mount & Blade II: Bannerlord installed (with editor)
- Module folder at `GAME_INSTALL/Modules/AIInfluence/` (or run from repo with correct structure)

## Steps

1. Copy or symlink the mod files so the structure is:
   ```
   Modules/AIInfluence/
   ├── GUI/
   │   ├── Config.xml
   │   ├── SpriteData.xml
   │   └── SpriteParts/
   │       └── ui_aiinfluence/
   │           ├── chat_panel_bg.png
   │           ├── chat_msg_separator.png
   │           ├── name_shadow_9.png
   │           ├── frame_9.png
   │           └── ...
   └── SubModule.xml
   ```

2. Run SpriteSheetGenerator:
   ```
   GAME_INSTALL/bin/Win64_Shipping_wEditor/TaleWorlds.TwoDimension.SpriteSheetGenerator.exe
   ```
   (Or use the "Update Sprite Sheets" option in the modding tools.)

3. The tool creates `Assets/` and `AssetSources/` under the module. Commit these if you want them in the repo, or ensure they are included when packaging the mod.

4. Press ENTER in the SpriteSheetGenerator window to finish and unlock the PNG files.

## Sprite Names

Sprite names = filename without extension. Ensure XML references match:
- `chat_panel_bg.png` → `chat_panel_bg`
- `chat_msg_separator.png` → `chat_msg_separator`
- `name_shadow_9.png` → `name_shadow_9`
- `frame_9.png` → `frame_9`
