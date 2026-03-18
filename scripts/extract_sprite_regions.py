#!/usr/bin/env python3
"""
Extract sprite metadata from Bannerlord SpriteData XML.
Outputs a JSON index and optional ImageMagick crop commands.

Usage:
  python scripts/extract_sprite_regions.py [--game-dir PATH] [--output-dir PATH]
  python scripts/extract_sprite_regions.py --list-used   # Only sprites used in ChatInterface

Requires: xml.etree (stdlib)
"""
import argparse
import json
import os
import re
import xml.etree.ElementTree as ET
from pathlib import Path

# Sprites referenced in ChatInterface.xml (built-in + custom)
CHAT_INTERFACE_SPRITES = {
    "BlankWhiteSquare_9",
    "BlankWhite",
    "chat_panel_bg",
    "chat_msg_separator",
    "name_shadow_9",
    "frame_9",
    "General\\CharacterCreation\\character_creation_background_gradient",
    "General\\CharacterCreation\\name_input_area",
}


def parse_sprite_parts(root, ns=None):
    """Extract SpritePart elements: Name, SheetID, Width, Height, SheetX, SheetY, CategoryName."""
    parts = []
    for elem in root.iter():
        if elem.tag.endswith("SpritePart"):
            part = {}
            for child in elem:
                tag = child.tag.split("}")[-1] if "}" in child.tag else child.tag
                part[tag] = child.text
            if part.get("Name"):
                parts.append(part)
    return parts


def parse_nine_region(root):
    """Extract NineRegionSprite: Name, SpritePartName, LeftWidth, etc."""
    regions = []
    for elem in root.iter():
        if elem.tag.endswith("NineRegionSprite"):
            region = {}
            for child in elem:
                tag = child.tag.split("}")[-1] if "}" in child.tag else child.tag
                region[tag] = child.text
            if region.get("Name"):
                regions.append(region)
    return regions


def parse_generic_sprite(root):
    """Map GenericSprite Name -> SpritePartName for aliases like frame_9 -> StdAssets\\Popup\\frame."""
    aliases = {}
    for elem in root.iter():
        if elem.tag.endswith("GenericSprite"):
            name = part_name = None
            for child in elem:
                tag = child.tag.split("}")[-1] if "}" in child.tag else child.tag
                if tag == "Name":
                    name = child.text
                elif tag == "SpritePartName":
                    part_name = child.text
            if name and part_name:
                aliases[name] = part_name
    return aliases


def parse_sprite_data(path):
    """Parse SpriteData XML and return (parts, nine_regions, aliases)."""
    tree = ET.parse(path)
    root = tree.getroot()
    parts = parse_sprite_parts(root)
    nine_regions = parse_nine_region(root)
    aliases = parse_generic_sprite(root)
    return parts, nine_regions, aliases


def build_sprite_index(parts, nine_regions, aliases, sheet_sizes):
    """Build a dict: sprite_name -> {sheet_id, x, y, w, h, category}."""
    by_part_name = {p["Name"]: p for p in parts if p.get("Name")}
    index = {}

    for part in parts:
        name = part.get("Name")
        if not name:
            continue
        sheet_id = part.get("SheetID", "1")
        try:
            sheet_id = int(sheet_id)
        except ValueError:
            sheet_id = 1
        index[name] = {
            "sheet_id": sheet_id,
            "x": int(part.get("SheetX", 0)),
            "y": int(part.get("SheetY", 0)),
            "w": int(part.get("Width", 0)),
            "h": int(part.get("Height", 0)),
            "category": part.get("CategoryName", ""),
        }

    for nr in nine_regions:
        name = nr.get("Name")
        part_name = nr.get("SpritePartName")
        if not name or not part_name:
            continue
        base = by_part_name.get(part_name)
        if base:
            index[name] = {
                "sheet_id": int(base.get("SheetID", 1)),
                "x": int(base.get("SheetX", 0)),
                "y": int(base.get("SheetY", 0)),
                "w": int(base.get("Width", 0)),
                "h": int(base.get("Height", 0)),
                "category": base.get("CategoryName", ""),
                "nine_region": True,
                "part_name": part_name,
            }

    return index


def main():
    ap = argparse.ArgumentParser(description="Extract sprite metadata from Bannerlord SpriteData")
    ap.add_argument(
        "--game-dir",
        default=os.path.expanduser(
            "~/.local/share/Steam/steamapps/common/Mount & Blade II Bannerlord"
        ),
        help="Bannerlord install path",
    )
    ap.add_argument("--output-dir", default=None, help="Write JSON and crop script here")
    ap.add_argument("--list-used", action="store_true", help="Only output sprites used in ChatInterface")
    args = ap.parse_args()

    game_dir = Path(args.game_dir)
    native_sprite = game_dir / "Modules/Native/GUI/NativeSpriteData.xml"
    sandbox_sprite = game_dir / "Modules/SandBox/GUI/SandBoxSpriteData.xml"

    if not native_sprite.exists():
        print(f"Not found: {native_sprite}")
        return 1

    # Sheet sizes for ui_group1 (from NativeSpriteData)
    sheet_sizes = {1: (4096, 4096), 2: (4096, 4096), 3: (4096, 2048)}

    all_index = {}
    for mod_name, path in [("Native", native_sprite), ("SandBox", sandbox_sprite)]:
        if not path.exists():
            continue
        parts, nine_regions, aliases = parse_sprite_data(path)
        idx = build_sprite_index(parts, nine_regions, aliases, sheet_sizes)
        for k, v in idx.items():
            v["module"] = mod_name
            if k not in all_index:
                all_index[k] = v
            elif mod_name == "SandBox":
                all_index[k] = v

    if args.list_used:
        used = {k: all_index.get(k, {"module": "custom", "note": "custom or unknown"}) for k in CHAT_INTERFACE_SPRITES}
        print(json.dumps(used, indent=2))
        return 0

    out_dir = Path(args.output_dir) if args.output_dir else Path("docs/extracted_sprites")
    out_dir.mkdir(parents=True, exist_ok=True)

    out_json = out_dir / "sprite_index.json"
    with open(out_json, "w") as f:
        json.dump(all_index, f, indent=2)
    print(f"Wrote {out_json} ({len(all_index)} sprites)")

    # ImageMagick crop commands (for when user has sheet PNGs)
    crop_script = out_dir / "crop_regions.sh"
    lines = [
        "#!/bin/bash",
        "# Crop sprite regions from extracted sheet PNGs.",
        "# Run TpacTool first to export gauntlet_ui textures, then:",
        "# SHEET1=path/to/ui_group1_sheet1.png SHEET2=... bash crop_regions.sh",
        "",
    ]
    for name, info in sorted(all_index.items()):
        if "x" not in info or "w" not in info:
            continue
        sid = info.get("sheet_id", 1)
        x, y = info.get("x", 0), info.get("y", 0)
        w, h = info.get("w", 0), info.get("h", 0)
        safe = re.sub(r'[\\/]', "_", name)
        var = f"SHEET{sid}"
        lines.append(f'# {name}')
        lines.append(f'convert "${var}" -crop {w}x{h}+{x}+{y} +repage "out_{safe}.png"')
        lines.append("")
    with open(crop_script, "w") as f:
        f.write("\n".join(lines))
    print(f"Wrote {crop_script}")

    return 0


if __name__ == "__main__":
    raise SystemExit(main() or 0)
