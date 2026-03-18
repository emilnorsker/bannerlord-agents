# Extracted Bannerlord UI Sprites for Chat Window

Sprites extracted from the game for potential use as ChatInterface assets.
Structure: `extracted/<component_name>/bannerlord_gui_<sprite_name>.png`

## Components

| Component | Description | Candidate Sprites |
|-----------|-------------|-------------------|
| left_column_background | Left panel solid backdrop | BlankWhiteSquare_9, standart_popup, Frame1.Broken\canvas |
| left_separator | Vertical separator line | BlankWhiteSquare_9, list_divider, divider_vertical |
| fullscreen_backdrop | Opaque backdrop center+right | BlankWhiteSquare_9, standart_popup, canvas_gradient |
| header_background | "Conversation Log" header area | canvas_gradient, standart_popup, npc_dialogue_panel |
| middle_panel_background | Main message area | canvas_gradient, canvas, canvas_dark, standart_popup, Encyclopedia\canvas, Frame1.Broken\canvas |
| message_separator | Separator between message groups | Popup\divider, list_divider, list_closed_divider, horizontal_gradient_divider |
| sender_name_shadow | Name badge for message sender | Conversation\name_shadow, name_shadow_9 |
| right_column_background | Right panel (Diplomacy) | canvas_gradient, standart_popup, canvas |
| input_bar_background | Input bar area | BlankWhiteSquare_9, canvas_gradient, character_creation_background_gradient |
| input_bar_frame | Frame around input | frame_9, Popup\frame, Frame1.Broken\frame |
| name_input_area | Text input field | name_input_area, text_input, text_box |
| separator_above_input | Thin line above input | BlankWhiteSquare_9, Popup\divider |

## Regenerating

```bash
# Download BannerEdge sprites from Google Drive, unzip GUI.zip, then:
python scripts/extract_chat_ui_sprites.py --banneredge-dir /path/to/GUI/SpriteParts/Sve --output-dir extracted
```

## Alpha Note

Sprite texture alpha multiplies with widget Color/AlphaFactor. If a sprite has transparent pixels (gradients, soft edges), it will remain transparent even at full opacity. Prefer solid sprites (e.g. `StdAssets\standart_popup`, `BlankWhiteSquare_9`) for opaque backgrounds.
