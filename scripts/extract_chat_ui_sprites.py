#!/usr/bin/env python3
"""
Extract ChatInterface-relevant sprites from Bannerlord game into:
  extracted/<component_name>/bannerlord_gui_<sprite_name>.png

Components map to candidate sprites we might use for the chat window.
Requires: sprite sheets from TpacTool (export gauntlet_ui.tpac) or
BannerEdge pre-extracted folder.

Usage:
  python scripts/extract_chat_ui_sprites.py [--game-dir PATH] [--sheets-dir PATH] [--output-dir PATH]
  python scripts/extract_chat_ui_sprites.py --game-dir "..." --sheets-dir /path/to/extracted_sheets
  python scripts/extract_chat_ui_sprites.py --game-dir "..."  # creates structure + manifest only

Sheets: place ui_group1_sheet1.png, ui_group1_sheet2.png, ui_group1_sheet3.png,
        ui_conversation_sheet1.png in --sheets-dir (from TpacTool export).
"""
import argparse
import json
import os
import re
import shutil
import subprocess
import sys
from pathlib import Path

# Import from sibling
sys.path.insert(0, str(Path(__file__).resolve().parent))
from extract_sprite_regions import (
    parse_sprite_data,
    build_sprite_index,
)

# ChatInterface components -> candidate sprites (Bannerlord sprite names)
COMPONENT_SPRITES = {
    "left_column_background": [
        "BlankWhiteSquare_9",
        "StdAssets\\standart_popup",
        "SPGeneral\\Frame1.Broken\\canvas",
    ],
    "left_separator": [
        "BlankWhiteSquare_9",
        "Encyclopedia\\list_divider",
        "StdAssets\\Popup\\divider_vertical",
    ],
    "fullscreen_backdrop": [
        "BlankWhiteSquare_9",
        "StdAssets\\standart_popup",
        "StdAssets\\Popup\\canvas_gradient",
    ],
    "header_background": [
        "StdAssets\\Popup\\canvas_gradient",
        "StdAssets\\standart_popup",
        "Conversation\\npc_dialogue_panel",
    ],
    "middle_panel_background": [
        "StdAssets\\Popup\\canvas_gradient",
        "StdAssets\\Popup\\canvas",
        "StdAssets\\Popup\\canvas_dark",
        "StdAssets\\standart_popup",
        "Encyclopedia\\canvas",
        "SPGeneral\\Frame1.Broken\\canvas",
    ],
    "message_separator": [
        "StdAssets\\Popup\\divider",
        "Encyclopedia\\list_divider",
        "Encyclopedia\\list_closed_divider",
        "horizontal_gradient_divider",
    ],
    "sender_name_shadow": [
        "Conversation\\name_shadow",
        "name_shadow_9",
    ],
    "right_column_background": [
        "StdAssets\\Popup\\canvas_gradient",
        "StdAssets\\standart_popup",
        "StdAssets\\Popup\\canvas",
    ],
    "input_bar_background": [
        "BlankWhiteSquare_9",
        "StdAssets\\Popup\\canvas_gradient",
        "General\\CharacterCreation\\character_creation_background_gradient",
    ],
    "input_bar_frame": [
        "frame_9",
        "StdAssets\\Popup\\frame",
        "SPGeneral\\Frame1.Broken\\frame",
        "Frame1Broken_canvas",
    ],
    "name_input_area": [
        "General\\CharacterCreation\\name_input_area",
        "StdAssets\\Popup\\text_input",
        "StdAssets\\text_box",
    ],
    "separator_above_input": [
        "BlankWhiteSquare_9",
        "StdAssets\\Popup\\divider",
    ],
}

def _crop_sprite(sheet_path: str, x: int, y: int, w: int, h: int, out_path: str) -> bool:
    """Crop region from sheet to out_path. Uses ImageMagick or Pillow."""
    try:
        result = subprocess.run(
            ["convert", sheet_path, "-crop", f"{w}x{h}+{x}+{y}", "+repage", out_path],
            capture_output=True,
            text=True,
            timeout=10,
        )
        if result.returncode == 0:
            return True
    except FileNotFoundError:
        pass
    except subprocess.TimeoutExpired:
        return False
    try:
        from PIL import Image
        img = Image.open(sheet_path).convert("RGBA")
        cropped = img.crop((x, y, x + w, y + h))
        cropped.save(out_path)
        return True
    except Exception:
        pass
    return False


# Category -> sheet file pattern (TpacTool / BannerEdge output)
CATEGORY_SHEETS = {
    "ui_group1": ["ui_group1_sheet1.png", "ui_group1_sheet2.png", "ui_group1_sheet3.png"],
    "ui_conversation": ["ui_conversation_sheet1.png"],
    "ui_encyclopedia": ["ui_encyclopedia_sheet1.png"],
}


def safe_filename(name: str) -> str:
    return re.sub(r'[\\/:*?"<>|]', "_", name)


def main():
    ap = argparse.ArgumentParser(description="Extract ChatInterface sprites from Bannerlord")
    ap.add_argument(
        "--game-dir",
        default=os.path.expanduser(
            "~/.local/share/Steam/steamapps/common/Mount & Blade II Bannerlord"
        ),
        help="Bannerlord install path",
    )
    ap.add_argument(
        "--sheets-dir",
        default=None,
        help="Dir with sprite sheet PNGs (ui_group1_sheet1.png etc). If set, crops and writes PNGs.",
    )
    ap.add_argument(
        "--banneredge-dir",
        default=None,
        help="Dir with BannerEdge-extracted individual PNGs (e.g. GUI/SpriteParts/Sve from BannerEdge). Copies sprites directly.",
    )
    ap.add_argument(
        "--output-dir",
        default="extracted",
        help="Root output dir (extracted/component_name/...)",
    )
    args = ap.parse_args()

    game_dir = Path(args.game_dir)
    native_sprite = game_dir / "Modules/Native/GUI/NativeSpriteData.xml"
    sandbox_sprite = game_dir / "Modules/SandBox/GUI/SandBoxSpriteData.xml"

    if not native_sprite.exists():
        print(f"Not found: {native_sprite}")
        return 1

    all_index = {}
    for mod_name, path in [("Native", native_sprite), ("SandBox", sandbox_sprite)]:
        if not path.exists():
            continue
        parts, nine_regions, aliases = parse_sprite_data(path)
        idx = build_sprite_index(parts, nine_regions, aliases, {})
        for k, v in idx.items():
            v["module"] = mod_name
            if k not in all_index or mod_name == "SandBox":
                all_index[k] = v

    out_root = Path(args.output_dir)
    out_root.mkdir(parents=True, exist_ok=True)

    sheets_dir = Path(args.sheets_dir) if args.sheets_dir else None
    banneredge_dir = Path(args.banneredge_dir) if args.banneredge_dir else None
    sheets_available = (
        sheets_dir
        and sheets_dir.exists()
        and any((sheets_dir / f).exists() for f in ["ui_group1_sheet1.png", "ui_group1_sheet2.png"])
    )
    banneredge_available = banneredge_dir and banneredge_dir.exists()

    for component, sprite_names in COMPONENT_SPRITES.items():
        comp_dir = out_root / component
        comp_dir.mkdir(parents=True, exist_ok=True)

        manifest = []
        for sprite_name in sprite_names:
            info = all_index.get(sprite_name)
            if not info:
                manifest.append({"sprite": sprite_name, "status": "not_found"})
                continue

            sheet_id = info.get("sheet_id", 1)
            x = info.get("x", 0)
            y = info.get("y", 0)
            w = info.get("w", 0)
            h = info.get("h", 0)
            category = info.get("category", "ui_group1")

            out_name = f"bannerlord_gui_{safe_filename(sprite_name)}.png"
            out_path = comp_dir / out_name

            manifest.append({
                "sprite": sprite_name,
                "sheet_id": sheet_id,
                "category": category,
                "x": x, "y": y, "w": w, "h": h,
                "out_file": out_name,
            })

            if banneredge_available:
                for try_name in [sprite_name, info.get("part_name", "")]:
                    if not try_name:
                        continue
                    src_path = banneredge_dir / (try_name.replace("\\", "/") + ".png")
                    if src_path.exists():
                        shutil.copy2(src_path, out_path)
                        manifest[-1]["extracted"] = True
                        break
                else:
                    manifest[-1]["extract_error"] = f"not in BannerEdge: {sprite_name}"
            elif sheets_available and w and h:
                sheet_files = CATEGORY_SHEETS.get(category, CATEGORY_SHEETS["ui_group1"])
                sheet_idx = min(sheet_id - 1, len(sheet_files) - 1)
                sheet_path = sheets_dir / sheet_files[sheet_idx]
                if sheet_path.exists():
                    extracted = _crop_sprite(str(sheet_path), x, y, w, h, str(out_path))
                    manifest[-1]["extracted"] = extracted
                    if not extracted:
                        manifest[-1]["extract_error"] = "crop failed (install ImageMagick or Pillow)"

        with open(comp_dir / "manifest.json", "w") as f:
            json.dump(manifest, f, indent=2)
        print(f"  {component}/ ({len(manifest)} sprites)")

    if banneredge_available:
        print("\nExtracted PNGs from BannerEdge to extracted/<component>/bannerlord_gui_*.png")
    elif sheets_available:
        print("\nExtracted PNGs to extracted/<component>/bannerlord_gui_*.png")
    else:
        print("\nTo extract PNGs:")
        print("  1) BannerEdge: download from https://drive.google.com/drive/folders/1gfE8ERq6hzKGy6Ya_RbpaUPVy3DXsP6u")
        print("     Unzip GUI.zip, then: --banneredge-dir /path/to/GUI/SpriteParts/Sve")
        print("  2) TpacTool: export gauntlet_ui.tpac, place sheet PNGs, then: --sheets-dir /path")
        print("     Requires: ImageMagick (apt install imagemagick)")

    return 0


if __name__ == "__main__":
    raise SystemExit(main() or 0)
