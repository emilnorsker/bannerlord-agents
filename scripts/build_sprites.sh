#!/bin/bash
# Run SpriteSheetGenerator to pack GUI/SpriteParts into Assets/AssetSources.
# Requires: Bannerlord + Proton installed, X display (or Xvfb for headless).

set -e
STEAM_DIR="${STEAM_DIR:-$HOME/.local/share/Steam}"
GAME_DIR="${GAME_DIR:-$STEAM_DIR/steamapps/common/Mount & Blade II Bannerlord}"
PROTON_DIR="${PROTON_DIR:-$STEAM_DIR/steamapps/common/Proton - Experimental}"
COMPAT_DIR="${COMPAT_DIR:-$STEAM_DIR/steamapps/compatdata/261550}"
MOD_DIR="$GAME_DIR/Modules/AIInfluence"

# Sync workspace GUI to module
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
WORKSPACE="$(cd "$SCRIPT_DIR/.." && pwd)"
cp -r "$WORKSPACE/GUI/"* "$MOD_DIR/GUI/"

# Run with virtual display if none
if [ -z "$DISPLAY" ]; then
  export DISPLAY=:99
  Xvfb :99 -screen 0 1024x768x24 &
  XVFB_PID=$!
  sleep 2
fi

cd "$GAME_DIR"
export STEAM_COMPAT_CLIENT_INSTALL_PATH="$STEAM_DIR"
export STEAM_COMPAT_DATA_PATH="$COMPAT_DIR"
timeout 35 "$PROTON_DIR/proton" run ./bin/Win64_Shipping_wEditor/TaleWorlds.TwoDimension.SpriteSheetGenerator.exe 2>/dev/null || true

[ -n "$XVFB_PID" ] && kill $XVFB_PID 2>/dev/null || true

# Copy generated assets back to workspace
cp -r "$MOD_DIR/Assets" "$WORKSPACE/"
cp -r "$MOD_DIR/AssetSources" "$WORKSPACE/"
cp "$MOD_DIR/GUI/AIInfluenceSpriteData.xml" "$WORKSPACE/GUI/"
echo "Sprite sheets built. Assets and AssetSources copied to workspace."
