#!/usr/bin/env python3
"""
Parse Gauntlet UI XML prefabs and render them as HTML matching in-game layout.
Usage: python gauntlet_xml_to_html.py <prefab_name> [--output out.html]
Example: python gauntlet_xml_to_html.py ChatInterface
"""

import argparse
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

GUI_PREFABS = Path(__file__).resolve().parent.parent / "GUI" / "Prefabs"


def resolve_constants(val: str, constants: dict) -> str:
    """Resolve !ConstantName to value."""
    if not val or not isinstance(val, str):
        return val or ""
    for name, v in constants.items():
        val = val.replace(f"!{name}", str(v))
    return val


def parse_margin(s: str) -> dict:
    """Parse Margin='4,2,4,2' or MarginTop='10' etc."""
    out = {}
    if not s:
        return out
    parts = [p.strip() for p in s.split(",")]
    if len(parts) == 4:
        out["margin"] = f"{parts[0]}px {parts[1]}px {parts[2]}px {parts[3]}px"
    elif len(parts) == 1 and parts[0].isdigit():
        out["margin"] = f"{parts[0]}px"
    return out


def get_attr(el: ET.Element, name: str, constants: dict, default: str = "") -> str:
    v = el.get(name, default)
    return resolve_constants(v, constants)


def infer_flex_direction(el: ET.Element) -> str:
    """Infer row vs column from children alignment when no StackLayout."""
    children = []
    for c in el:
        if c.tag == "Children":
            children = list(c)
            break
        elif c.tag == "ItemTemplate":
            return "column"
    if len(children) < 2:
        return "column"
    has_left = any(ch.get("HorizontalAlignment") == "Left" for ch in children)
    has_right = any(ch.get("HorizontalAlignment") == "Right" for ch in children)
    if has_left and has_right:
        return "row"
    if has_right and len(children) == 2:
        return "row"
    return "column"


def widget_to_css(el: ET.Element, constants: dict) -> str:
    """Build CSS from Gauntlet widget attributes."""
    parts = []
    w = get_attr(el, "WidthSizePolicy", constants)
    h = get_attr(el, "HeightSizePolicy", constants)
    sw = get_attr(el, "SuggestedWidth", constants)
    sh = get_attr(el, "SuggestedHeight", constants)
    color = get_attr(el, "Color", constants)
    ha = get_attr(el, "HorizontalAlignment", constants)
    va = get_attr(el, "VerticalAlignment", constants)
    ml = get_attr(el, "MarginLeft", constants)
    mr = get_attr(el, "MarginRight", constants)
    mt = get_attr(el, "MarginTop", constants)
    mb = get_attr(el, "MarginBottom", constants)
    margin = get_attr(el, "Margin", constants)
    layout = get_attr(el, "StackLayout.LayoutMethod", constants)
    alpha = get_attr(el, "AlphaFactor", constants)

    if w == "StretchToParent" or w == "Fixed":
        if w == "StretchToParent":
            parts.append("flex: 1")
            parts.append("min-width: 0")
        elif sw:
            parts.append(f"width: {sw}px")
    if h == "StretchToParent" or h == "Fixed":
        if h == "StretchToParent":
            parts.append("flex: 1")
            parts.append("min-height: 0")
        elif sh:
            parts.append(f"height: {sh}px")

    if color and re.match(r"^#[0-9A-Fa-f]{6,8}$", color):
        parts.append(f"background-color: {color}")

    if layout == "VerticalTopToBottom":
        parts.append("display: flex")
        parts.append("flex-direction: column")
    elif layout == "VerticalBottomToTop":
        parts.append("display: flex")
        parts.append("flex-direction: column-reverse")
    elif layout == "HorizontalLeftToRight":
        parts.append("display: flex")
        parts.append("flex-direction: row")
    else:
        parts.append("display: flex")
        fd = infer_flex_direction(el)
        parts.append(f"flex-direction: {fd}")

    if ha == "Left":
        parts.append("align-self: flex-start")
    elif ha == "Right":
        parts.append("align-self: flex-end")
    elif ha == "Center":
        parts.append("align-self: center")
    if va == "Top":
        parts.append("align-self: flex-start")
    elif va == "Bottom":
        parts.append("align-self: flex-end")
    elif va == "Center":
        parts.append("align-self: center")

    margins = []
    if ml:
        margins.append(f"margin-left: {ml}px")
    if mr:
        margins.append(f"margin-right: {mr}px")
    if mt:
        margins.append(f"margin-top: {mt}px")
    if mb:
        margins.append(f"margin-bottom: {mb}px")
    if margin:
        m = parse_margin(margin)
        if m.get("margin"):
            margins.append(f"margin: {m['margin']}")
    parts.extend(margins)

    if alpha:
        try:
            a = float(alpha)
            parts.append(f"opacity: {a}")
        except ValueError:
            pass

    return "; ".join(parts)


def widget_to_html(el: ET.Element, constants: dict, depth: int = 0, parent: ET.Element | None = None) -> str:
    """Recursively convert Gauntlet widget tree to HTML."""
    tag = el.tag
    css = widget_to_css(el, constants)
    style = f' style="{css}"' if css else ""
    wid = el.get("Id", "")
    id_attr = f' id="{wid}"' if wid else ""

    if tag == "ItemTemplate":
        children_html = []
        for c in el:
            if c.tag == "Children":
                for ch in c:
                    children_html.append(widget_to_html(ch, constants, depth + 1, el))
        inner = "".join(children_html) if children_html else f'<span>{get_attr(el, "Text", constants) or "[Item]"}</span>'
        ds = get_attr(parent, "DataSource", constants) if parent is not None else ""
        return f'<div class="item-template" data-datasource="{ds}">{inner}</div>'

    if tag in ("TextWidget", "RichTextWidget"):
        text = get_attr(el, "Text", constants)
        if text.startswith("@"):
            text = f"[{text}]"
        font_size = el.get("Brush.FontSize", "")
        if not font_size or font_size.startswith("@"):
            font_size = "14"
        color = get_attr(el, "Color", constants) or "#e0e0e0"
        if color.startswith("!"):
            color = constants.get(color[1:], "#e0e0e0")
        full_style = f"{css}; font-size: {font_size}px; color: {color}"
        return f'<span{id_attr} data-gauntlet="{tag}" data-text="{text}" style="{full_style}">{text}</span>'

    if tag == "EditableTextWidget":
        return f'<input{id_attr} type="text" placeholder="..." value="" style="{css}; padding: 4px 10px; font-size: 14px; color: #e0e0e0; background: #2a1a11; border: 1px solid rgba(255,255,255,0.2); border-radius: 4px" />'

    if tag == "ButtonWidget":
        children_html = []
        for c in el:
            if c.tag == "Children":
                for ch in c:
                    children_html.append(widget_to_html(ch, constants, depth + 1))
            elif c.tag in ("TextWidget", "RichTextWidget"):
                children_html.append(widget_to_html(c, constants, depth + 1))
        inner = "".join(children_html) if children_html else f'<span>{get_attr(el, "Text", constants) or "Button"}</span>'
        return f'<button{id_attr}{style} data-gauntlet="ButtonWidget">{inner}</button>'

    if tag == "ItemTemplate":
        children_html = []
        for c in el:
            if c.tag == "Children":
                for ch in c:
                    children_html.append(widget_to_html(ch, constants, depth + 1, el))
        inner = "".join(children_html) if children_html else f'<span>{get_attr(el, "Text", constants) or "[Item]"}</span>'
        ds = get_attr(parent, "DataSource", constants) if parent is not None else ""
        return f'<div class="item-template" data-datasource="{ds}">{inner}</div>'

    children_html = []
    for c in el:
        if c.tag == "Children":
            for ch in c:
                children_html.append(widget_to_html(ch, constants, depth + 1))
        elif c.tag == "ItemTemplate":
            children_html.append(widget_to_html(c, constants, depth + 1, el))

    if tag in ("ScrollablePanel", "ClipContents"):
        extra = " overflow: auto;"
    else:
        extra = ""

    inner = "".join(children_html)
    if tag in ("ListPanel", "NavigatableListPanel"):
        return f'<div{id_attr} class="gauntlet-{tag}" style="{css}{extra}">{inner}</div>'
    if tag == "Standard.VerticalScrollbar":
        return f'<div{id_attr} class="scrollbar" style="{css}; width: 22px; background: rgba(255,255,255,0.1); border-radius: 4px"></div>'
    return f'<div{id_attr} class="gauntlet-{tag}" style="{css}{extra}">{inner}</div>'


def parse_prefab(path: Path) -> tuple[dict, ET.Element]:
    """Parse prefab XML, return (constants, root)."""
    tree = ET.parse(path)
    root = tree.getroot()
    constants = {}
    for const in root.findall(".//Constants/Constant"):
        name = const.get("Name")
        val = const.get("Value")
        if name and val:
            constants[name] = val
    return constants, root


def find_window(root: ET.Element) -> ET.Element | None:
    for w in root.iter("Window"):
        return w
    return None


def main():
    parser = argparse.ArgumentParser(description="Parse Gauntlet XML prefab and render as HTML")
    parser.add_argument("prefab", help="Prefab name (e.g. ChatInterface)")
    parser.add_argument("-o", "--output", help="Output HTML file")
    parser.add_argument("--prefabs-dir", default=GUI_PREFABS, type=Path, help="Prefabs directory")
    args = parser.parse_args()

    xml_path = args.prefabs_dir / f"{args.prefab}.xml"
    if not xml_path.exists():
        print(f"Error: {xml_path} not found", file=sys.stderr)
        sys.exit(1)

    constants, root = parse_prefab(xml_path)
    window = find_window(root)
    if window is None:
        print("Error: No Window found in prefab", file=sys.stderr)
        sys.exit(1)

    html_parts = []
    for child in window:
        if child.tag == "Children":
            for w in child:
                html_parts.append(widget_to_html(w, constants))
        else:
            html_parts.append(widget_to_html(child, constants))

    html = f"""<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Gauntlet UI — {args.prefab}</title>
  <style>
    * {{ box-sizing: border-box; margin: 0; padding: 0; }}
    body {{ font-family: system-ui, sans-serif; background: #0a0a0a; color: #e0e0e0; min-height: 100vh; }}
    .gauntlet-scene {{ display: flex; flex-direction: column; min-height: 100vh; width: 100%; }}
    .gauntlet-Widget, .gauntlet-BrushWidget {{ display: flex; flex-direction: column; }}
    .gauntlet-scrollbar {{ flex-shrink: 0; }}
    button {{ cursor: pointer; color: #FFE6B6; background: #3a2a1a; border: none; border-radius: 4px; }}
    input {{ outline: none; }}
  </style>
</head>
<body>
  <div class="gauntlet-scene" data-prefab="{args.prefab}">
    {"".join(html_parts)}
  </div>
</body>
</html>"""

    out_path = Path(args.output) if args.output else Path(f"{args.prefab}.html")
    out_path.write_text(html, encoding="utf-8")
    print(f"Wrote {out_path}")


if __name__ == "__main__":
    main()
