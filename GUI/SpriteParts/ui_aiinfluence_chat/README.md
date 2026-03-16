Place Figma-exported PNG parts for the chat UI in this folder.

Bannerlord sprite generation expects:

- `Modules\\AIInfluence\\GUI\\SpriteParts\\ui_aiinfluence_chat\\*.png`
- `Modules\\AIInfluence\\GUI\\Config.xml` with:
  - `<SpriteCategory Name="ui_aiinfluence_chat">`
  - `<AlwaysLoad/>`

After adding/updating PNG files:

1. Run `TaleWorlds.TwoDimension.SpriteSheetGenerator.exe` (wEditor bin).
2. In the Modding Kit console run `resource.show_resource_browser`.
3. Select this module and run **Scan new asset files** (or **Reimport**).
4. Verify `ui_aiinfluence_chat_1_tex.tpac` exists under `Assets\\GauntletUI`.

Use generated sprite names from `*SpriteData.xml` inside `GUI\\` in prefab `Sprite="..."` attributes.
