# Chat UI Figma -> Bannerlord Sprite Sheet Pipeline

This file defines the **Bannerlord-compliant** process for turning Figma chat UI assets into sprites we can reference from `GUI/Prefabs/ChatInterface.xml`.

Figma source:

- https://www.figma.com/design/iqGFT5UhhPPyogfq3z1K7t/Some-game-interface--Community-?node-id=0-1&p=f&t=wXQnSdI0fVM2mhsX-0

## 1) What Bannerlord requires (direct quotes)

From TaleWorlds mod docs:

> "Create a new folder named SpriteParts under the newly created folder GUI. Create a new folder named ui_{YOUR_CATEGORY_NAME} under the newly created folder SpriteParts."
>
> "SpriteSheetGenerator.exe will create two folders named Assets and AssetSources under Modules\\YOUR_MODULE_NAME. It will also create a SpriteData.xml file (with a prefix of your module name) under Modules\\YOUR_MODULE_NAME\\GUI."
>
> "Type resource.show_resource_browser, then hit enter."
>
> "You should now see a new file named ui_{YOUR_CATEGORY_NAME}_1_tex.tpac under Modules\\YOUR_MODULE_NAME\\Assets\\GauntletUI."
>
> "You may now refer to your sprites in this file as Sprite=\"mysprite\"."

Source: https://moddocs.bannerlord.com/asset-management/generating_and_loading_ui_sprite_sheets/

From BannerlordModding.LT docs:

> "Put your sprites (PNG files) into folder: Modules\\YOUR_MODULE_NAME\\GUI\\SpriteParts\\ui_{YOUR_CATEGORY_NAME}"
>
> "In file: Modules\\YOUR_MODULE_NAME\\GUI\\Config.xml add ... <SpriteCategory Name=\"ui_{YOUR_CATEGORY_NAME}\"> <AlwaysLoad/> ..."
>
> "Close the resource browser and the Editor(game). You should now see a new file named ui_{YOUR_CATEGORY_NAME}_1_tex.tpac under Modules\\YOUR_MODULE_NAME\\Assets\\GauntletUI."

Source: https://docs.bannerlordmodding.lt/gauntletui/sprites/

## 2) Module wiring now in this repo

This repository now contains:

- `GUI/Config.xml` with:
  - `SpriteCategory Name="ui_aiinfluence_chat"`
  - `<AlwaysLoad/>`
- `GUI/SpriteParts/ui_aiinfluence_chat/` folder for source PNG parts.

## 3) Required asset workflow

1. Export chat UI parts from Figma as transparent PNGs.
2. Put files in:
   - `GUI/SpriteParts/ui_aiinfluence_chat/`
3. Run Bannerlord's tool:
   - `...\\bin\\Win64_Shipping_wEditor\\TaleWorlds.TwoDimension.SpriteSheetGenerator.exe`
4. Start Modding Kit, open console (`Alt + \``), run:
   - `resource.show_resource_browser`
5. Select module -> **Scan new asset files** (or **Reimport** for updates).
6. Confirm outputs:
   - `Assets/GauntletUI/ui_aiinfluence_chat_1_tex.tpac`
   - `GUI/*SpriteData.xml` includes `ui_aiinfluence_chat` and `AlwaysLoad`.

## 4) Naming convention for reliable `Sprite="..."`

Use flat, stable names (no spaces, lowercase, underscore), for example:

- `chat_frame_outer`
- `chat_header_bg`
- `chat_panel_center`
- `chat_panel_right`
- `chat_input_bg`
- `chat_button_send`
- `chat_button_close`

Then reference exactly the generated sprite name in prefabs:

- `Sprite="chat_frame_outer"`
- `Sprite="chat_header_bg"`

The source of truth is the generated `*SpriteData.xml`; always copy sprite names from there.

## 5) Practical validation checklist

- Category name starts with `ui_` (`ui_aiinfluence_chat`).
- `Config.xml` exists under `GUI/`.
- `*SpriteData.xml` includes category + `AlwaysLoad`.
- `ui_aiinfluence_chat_1_tex.tpac` exists under `Assets/GauntletUI`.
- Chat prefab renders without missing-texture placeholders.

