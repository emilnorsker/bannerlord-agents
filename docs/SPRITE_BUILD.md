# Custom Sprite Build

The mod uses custom sprites in `GUI/SpriteParts/ui_aiinfluence/`. To pack them, run **SpriteSheetGenerator** (via Proton on Linux).

## Quick: Use the script

```bash
./scripts/build_sprites.sh
```

Requires: Bannerlord + Proton installed. Uses Xvfb if no display.

## Manual

1. Deploy the mod so `Modules/AIInfluence/GUI/` has Config.xml, SpriteData.xml, SpriteParts/ui_aiinfluence/*.png

2. Run SpriteSheetGenerator (with virtual display on headless):
   ```bash
   export DISPLAY=:99
   Xvfb :99 -screen 0 1024x768x24 &
   cd "GAME_DIR"
   proton run ./bin/Win64_Shipping_wEditor/TaleWorlds.TwoDimension.SpriteSheetGenerator.exe
   ```

3. The tool creates `Assets/`, `AssetSources/`, and `GUI/AIInfluenceSpriteData.xml`. Copy these to the workspace and commit.

## Sprite names

Sprite name = filename without extension. XML references must match:
- `chat_panel_bg.png` → `chat_panel_bg`
- `chat_msg_separator.png` → `chat_msg_separator`
- `name_shadow_9.png` → `name_shadow_9`
- `frame_9.png` → `frame_9`
