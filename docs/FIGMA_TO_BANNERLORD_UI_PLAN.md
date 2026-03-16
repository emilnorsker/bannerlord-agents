# Figma → Bannerlord GauntletUI — Custom Asset Plan

*Confirmed against: decompiled `random_logs` branch source, existing `GUI/Prefabs/`, `GUI/Brushes/`, and official modding docs.*

---

## 1. How Bannerlord's UI Stack Works

Bannerlord uses **GauntletUI** — a data-driven, XML-described UI framework. Four layers matter for custom assets:

| Layer | Files | Location | What it does |
|-------|-------|----------|-------------|
| **Sprites** | PNG → `SpriteData.xml` + `.tpac` | `GUI/SpriteParts/ui_{category}/` | Raw image atoms; packed into 4096×4096 atlas sheets |
| **Brushes** | `*.xml` | `GUI/Brushes/` | Composite visual style — layers of sprites, colours, fonts, hover/pressed states |
| **Prefabs** | `*.xml` | `GUI/Prefabs/` | Widget tree — layout, bindings to ViewModel properties, references to brushes |
| **Widgets** | `*.cs` | `src/AIInfluence.UI*/` | Custom C# logic classes when pure XML isn't enough |

The mod already has all four layers in use. The plan below extends each one with custom-designed assets from Figma.

---

## 2. What Exists Today (Baseline)

### 2a. Prefabs
| File | Purpose | Key brushes used |
|------|---------|-----------------|
| `ChatInterface.xml` | Full-screen NPC chat window | `Encyclopedia.Frame`, `Encyclopedia.TopBanner`, `Conversation.HeaderText`, `Popup.Done.Button`, `Popup.Cancel.Button` |
| `PopUpDialogue.xml` | In-battle speech-bubble overlay | `Popup.Message.Text` |
| `WorldEventsWindow.xml` | World events modal (1180×760) | `Encyclopedia.Frame`, `Encyclopedia.TopBanner`, `SPScoreboard.Subtitle.Text` |
| `WorldEventsButton.xml` | Map button to open events | Native buttons |
| `AIInfluenceTextQueryPopup.xml` | AI text query popup | Native |

### 2b. Brushes
| Name | File | Notes |
|------|------|-------|
| `Popup.Message.Text` | `PopUpBrush.xml` | Gold text, Galahad font, FontSize 42 |

### 2c. Custom Widgets (C#)
`PopUpConversationScreenWidget`, `PopUpConversationListPanel`, `AIInfluencePortraitWidget`

### 2d. Native brushes relied upon (from game's own files)
`Encyclopedia.Frame` · `Encyclopedia.TopBanner` · `Popup.Done.Button` · `Popup.Cancel.Button` · `Popup.Button.Text` · `Conversation.HeaderText` · `Conversation.Relation.Text` · `Review.NameInput.Text` · `SPScoreboard.Subtitle.Text`

---

## 3. GauntletUI Asset Formats — Reference

### 3a. Brush XML (confirmed from `BrushFactory.cs`, `BrushLayer.cs`, `Style.cs`, `StyleLayer.cs`)

```xml
<Brushes>
  <Brush Name="AIInfluence.ChatBubble.NPC"
         Font="Galahad"
         TransitionDuration="0.1">

    <!-- Default layer: background image for the bubble -->
    <Layers>
      <BrushLayer Name="Default"
                  Sprite="ui_aiinfluence\chat_bubble_bg"
                  Color="#1A1208FF"
                  ColorFactor="1"
                  AlphaFactor="0.9"
                  ExtendLeft="12" ExtendRight="12" ExtendTop="8" ExtendBottom="8" />
      <!-- Optional overlay: top-edge highlight -->
      <BrushLayer Name="Overlay"
                  Sprite="ui_aiinfluence\chat_bubble_border"
                  AlphaFactor="0.5"
                  ExtendLeft="12" ExtendRight="12" ExtendTop="8" ExtendBottom="8" />
    </Layers>

    <!-- Named styles for widget states -->
    <Styles>
      <Style Name="Default"
             FontColor="#E8D4AAFF"
             FontSize="16"
             TextGlowColor="#00000000"
             TextOutlineColor="#000000FF"
             TextOutlineAmount="0.05" />
      <Style Name="Hovered">
        <!-- Only override what changes -->
        <StyleLayers>
          <StyleLayer Name="Default" AlphaFactor="1.0" />
        </StyleLayers>
      </Style>
      <Style Name="Pressed">
        <StyleLayers>
          <StyleLayer Name="Default" ColorFactor="0.8" />
        </StyleLayers>
      </Style>
      <Style Name="Disabled">
        <StyleLayers>
          <StyleLayer Name="Default" AlphaFactor="0.4" />
        </StyleLayers>
      </Style>
    </Styles>
  </Brush>
</Brushes>
```

Key `BrushLayer` properties (from `BrushLayer.cs`):
- `ExtendLeft/Right/Top/Bottom` — 9-patch slice margins
- `OverriddenWidth`, `OverriddenHeight` — fixed-size layers
- `OverlaySprite`, `OverlayMethod` — texture blending overlay
- `HueFactor`, `SaturationFactor`, `ValueFactor` — HSV tint controls

### 3b. Sprite pipeline (confirmed from `SpriteData.cs`, `SpriteCategory.cs`, `UIResourceManager.cs`)

**Step 1 — Place PNGs:**
```
GUI/SpriteParts/ui_aiinfluence/
    chat_bubble_bg.png          ← 9-patch panel background
    chat_bubble_border.png      ← 9-patch panel border/highlight
    chat_bubble_tail_npc.png    ← directional tail (left)
    chat_bubble_tail_player.png ← directional tail (right)
    btn_primary_bg.png          ← button background (9-patch)
    btn_primary_hover.png       ← hover overlay
    btn_primary_pressed.png     ← pressed overlay
    icon_send.png               ← send icon (24×24 or 32×32)
    icon_close.png              ← close icon
    panel_header_bg.png         ← header strip (9-patch)
    panel_frame.png             ← outer frame (9-patch)
    separator_h.png             ← 1px horizontal rule
    separator_v.png             ← 1px vertical rule
    pill_bg.png                 ← pill/tag badge (9-patch)
    scroll_track.png            ← scrollbar track
    scroll_thumb.png            ← scrollbar thumb
```

**Step 2 — Config.xml** (`GUI/Config.xml`):
```xml
<Config>
  <SpriteCategory Name="ui_aiinfluence">
    <AlwaysLoad />
  </SpriteCategory>
</Config>
```

**Step 3 — Run SpriteSheetGenerator** (Windows only, game tool):
```
<game>\bin\Win64_Shipping_wEditor\TaleWorlds.TwoDimension.SpriteSheetGenerator.exe
```
Point to the module folder → press ENTER → outputs:
- `GUI/SpriteData.xml` (merged with existing game sprite data)
- `Assets/GauntletUI/ui_aiinfluence_1.png` (atlas sheet, max 4096×4096)
- `AssetSources/GauntletUI/ui_aiinfluence_1.png`

**Step 4 — Import via Modding Kit** (in-editor):
```
Alt + ` → resource.show_resource_browser
→ navigate to module GauntletUI folder
→ "Scan new asset files" → select → Import
```
Generates `.tpac` texture files under `Assets/GauntletUI/`.

### 3c. Prefab XML patterns (confirmed from existing prefabs + `Widget.cs`, `BrushWidget.cs`)

```xml
<!-- 9-patch panel with custom brush -->
<BrushWidget Brush="AIInfluence.Panel.Frame"
             WidthSizePolicy="StretchToParent" HeightSizePolicy="StretchToParent" />

<!-- Image-only sprite (no brush) -->
<Widget Sprite="ui_aiinfluence\icon_send"
        WidthSizePolicy="Fixed" SuggestedWidth="24"
        HeightSizePolicy="Fixed" SuggestedHeight="24" />

<!-- Button with custom brush + icon child -->
<ButtonWidget Brush="AIInfluence.Btn.Primary"
              WidthSizePolicy="Fixed" SuggestedWidth="90"
              HeightSizePolicy="Fixed" SuggestedHeight="38"
              UpdateChildrenStates="true"
              Command.Click="ExecuteSendMessage">
  <Children>
    <Widget Sprite="ui_aiinfluence\icon_send"
            WidthSizePolicy="Fixed" SuggestedWidth="20"
            HeightSizePolicy="Fixed" SuggestedHeight="20"
            VerticalAlignment="Center" HorizontalAlignment="Left"
            MarginLeft="10" />
    <TextWidget Text="Send"
                Brush="AIInfluence.Btn.Label"
                WidthSizePolicy="StretchToParent" HeightSizePolicy="CoverChildren"
                VerticalAlignment="Center" MarginLeft="34" />
  </Children>
</ButtonWidget>
```

---

## 4. Components to Design in Figma

Below are the exact components needed, with the constraints the engine imposes.

### 4a. Chat Interface (replaces raw `Sprite="..."` colour hacks in `ChatInterface.xml`)

| Component | Figma frame name | Engine constraints |
|-----------|-----------------|-------------------|
| Chat bubble — NPC | `chat/bubble-npc` | Min width 100px. Tail: 12px triangle bottom-left. 9-patch inner margin ≥8px all sides |
| Chat bubble — Player | `chat/bubble-player` | Mirror of NPC. Tail bottom-right |
| Bubble — action/emote pill | `chat/pill-action` | Pill shape. 9-patch horizontal only (8px L/R) |
| Chat input field | `chat/input-field` | 9-patch. Three states: idle, focused, disabled |
| Chat send button | `chat/btn-send` | 38px tall. States: default, hover, pressed, disabled |
| Chat close button | `chat/btn-close` | 38px, outlined style |
| Chat header bar | `chat/header-bg` | Full-width strip, 80px tall, 9-patch |
| Message list background | `chat/scroll-bg` | Dark panel, 9-patch |
| Vertical scrollbar track | `shared/scroll-track` | 22px wide, 9-patch vertical |
| Vertical scrollbar thumb | `shared/scroll-thumb` | 22px wide, 9-patch vertical, hover state |
| NPC name badge | `chat/name-badge` | Semi-transparent, 9-patch |

### 4b. World Events Window

| Component | Figma frame name | Engine constraints |
|-----------|-----------------|-------------------|
| Window outer frame | `events/frame` | 9-patch. Currently uses native `Encyclopedia.Frame` |
| Window header | `events/header` | Currently uses native `Encyclopedia.TopBanner` |
| Event card | `events/card` | 86px tall, full width minus padding, 9-patch |
| Event card — active | `events/card-active` | Highlighted variant |
| Map button | `events/map-btn` | Fixed 48×48 or 48px tall, states: default/hover/pressed |

### 4c. Pop-Up Dialogue (Combat Phrases)

| Component | Figma frame name | Engine constraints |
|-----------|-----------------|-------------------|
| Speech-bubble container | `popup/speech-bubble` | Variable width (SuggestedWidth="500"), semi-transparent |
| Faction icon badge | `popup/faction-badge` | 32×32 or 40×40 |

### 4d. Shared Design Tokens

These map directly to brush style properties and must be defined first in Figma as Styles/Tokens:

| Token | Value | Brush property |
|-------|-------|---------------|
| `color/text/primary` | `#E8D4AAFF` (gold) | `FontColor` |
| `color/text/secondary` | `#9BA4B5FF` (cool grey) | `FontColor` |
| `color/text/accent` | `#FFE6B685` (bright gold) | `FontColor` |
| `color/bg/dark` | `#0A0A0AFF` | Layer `Color` |
| `color/bg/panel` | `#130D09FF` | Layer `Color` |
| `color/bg/header` | `#1A120DFF` | Layer `Color` |
| `color/bg/input` | `#1A110CFF` | Layer `Color` |
| `color/sep` | `#FFFFFF22` | Layer `Color` |
| `font/body` | Galahad 16px | `Font`, `FontSize` |
| `font/header` | Galahad 24px | `Font`, `FontSize` |
| `font/subtitle` | Galahad 15px | `Font`, `FontSize` |
| `radius/bubble` | 9-patch 12px corners | `ExtendLeft/Right/Top/Bottom` |
| `radius/pill` | 9-patch 8px corners | `ExtendLeft/Right/Top/Bottom` |

---

## 5. Figma Export Settings

All sprites must be exported as **PNG**. Bannerlord's UI renders at a reference resolution of ~1080p; export at **1×** for standard, **2×** for any sprite you want sharp on 4K.

| Type | Format | Min size | Notes |
|------|--------|----------|-------|
| 9-patch panels / frames | PNG 1× | ≥ 24×24 | Keep corner regions exact to your 9-patch margins |
| Icons | PNG 1× | 16–64px | Power-of-two preferred but not required |
| Full-bleed backgrounds | PNG 1× | 256×64 or larger | Will be scaled by engine; soft OK |
| Button backgrounds | PNG 1× | 40px tall | Export all 3 states as separate files |

**Figma component structure to request:**

```
ui_aiinfluence/              ← one Figma page, one export group
  chat/
    bubble-npc.png           → chat_bubble_npc_bg.png
    bubble-player.png        → chat_bubble_player_bg.png
    ...
  events/
    frame.png                → panel_frame.png
    ...
  shared/
    scroll-track.png
    scroll-thumb.png
    ...
```

---

## 6. Brush Authoring Guide

One Brush XML file per logical UI section (keeps things readable and matches BrushFactory scanning).

| File | Brushes inside |
|------|---------------|
| `GUI/Brushes/ChatBrushes.xml` | `AIInfluence.Chat.Bubble.NPC`, `AIInfluence.Chat.Bubble.Player`, `AIInfluence.Chat.Pill`, `AIInfluence.Chat.Header`, `AIInfluence.Chat.Input`, `AIInfluence.Chat.InputText`, `AIInfluence.Chat.SendBtn`, `AIInfluence.Chat.CloseBtn`, `AIInfluence.Chat.NameBadge` |
| `GUI/Brushes/PanelBrushes.xml` | `AIInfluence.Panel.Frame`, `AIInfluence.Panel.Header`, `AIInfluence.Panel.EventCard`, `AIInfluence.Panel.EventCardActive` |
| `GUI/Brushes/SharedBrushes.xml` | `AIInfluence.Scrollbar.Track`, `AIInfluence.Scrollbar.Thumb`, `AIInfluence.Separator.H`, `AIInfluence.Separator.V` |
| `GUI/Brushes/PopUpBrush.xml` | `Popup.Message.Text` *(existing, extend only)* |

Button brushes must use `UpdateChildrenStates="true"` in prefab so children transition alongside parent state.

---

## 7. Prefab Update Plan

After brushes are ready, update these prefabs in order:

### Pass 1 — Drop-in replacements (no structural change)
These are colour/sprite substitutions only:

1. `ChatInterface.xml` — Replace inline `Sprite="StdAssets\Popup\canvas*"` hacks with `Brush="AIInfluence.Panel.Frame"` etc.
2. `WorldEventsWindow.xml` — Replace `Encyclopedia.Frame`/`Encyclopedia.TopBanner` with custom equivalents.

### Pass 2 — Structural improvements

3. `ChatInterface.xml` — Add chat bubble tail widget (left of NPC bubble, right of player bubble) using `Sprite="ui_aiinfluence\chat_bubble_tail_npc"`.
4. `ChatInterface.xml` — Replace `Sprite="General\CharacterCreation\name_input_area"` input field with `Brush="AIInfluence.Chat.Input"`.
5. `ChatInterface.xml` — Add send-button icon inside `ButtonWidget`.
6. `WorldEventsButton.xml` — Replace native button with custom map button brush.

### Pass 3 — New prefab
7. (Optional) Extract right-panel "Diplomacy & Relation" section into its own prefab `RightInfoPanel.xml` for reuse.

---

## 8. Custom Widget Plan

Custom C# widgets are needed for:

| Widget | Why C# is needed | Class | Base |
|--------|-----------------|-------|------|
| `ChatBubbleTailWidget` | Flip tail sprite based on `IsNpc` boolean at runtime | `src/AIInfluence.UI/ChatBubbleTailWidget.cs` | `BrushWidget` |
| `AnimatedTypingIndicator` | Three animated dots for "NPC is typing" state | `src/AIInfluence.UI/TypingIndicatorWidget.cs` | `Widget` |

All other components can be pure XML.

---

## 9. Step-by-Step Implementation Order

```
Phase 0: Figma credentials / exports
  □ Obtain Figma API token or exported PNGs from the user
  □ Confirm component naming matches this plan

Phase 1: Sprite assets
  □ Place PNGs in GUI/SpriteParts/ui_aiinfluence/
  □ Create GUI/Config.xml with AlwaysLoad declaration
  □ Run SpriteSheetGenerator.exe (requires Windows + game install)
  □ Import via Modding Kit → generate .tpac files
  □ Commit: Assets/GauntletUI/ui_aiinfluence_1.tpac + SpriteData.xml

Phase 2: Brush XML
  □ ChatBrushes.xml — chat-window brushes
  □ PanelBrushes.xml — panel/frame/header brushes
  □ SharedBrushes.xml — scrollbar, separator brushes
  □ Test: load game, open chat window, check visual output
  □ Commit after each file

Phase 3: Prefab Pass 1 (drop-in)
  □ Update ChatInterface.xml (brush replacements only)
  □ Update WorldEventsWindow.xml
  □ Commit + test

Phase 4: Prefab Pass 2 (structural)
  □ Add chat bubble tails
  □ Update input field and send button
  □ Update map button
  □ Commit + test

Phase 5: Custom widgets (if needed)
  □ ChatBubbleTailWidget.cs
  □ TypingIndicatorWidget.cs
  □ Commit + test
```

---

## 10. Folder Structure to Create Now

```
GUI/
  Config.xml                       ← new: sprite category config
  SpriteParts/
    ui_aiinfluence/                ← new: place Figma PNGs here
      .gitkeep
  Brushes/
    PopUpBrush.xml                 ← existing
    ChatBrushes.xml                ← new (Phase 2)
    PanelBrushes.xml               ← new (Phase 2)
    SharedBrushes.xml              ← new (Phase 2)
  Prefabs/
    AIInfluenceTextQueryPopup.xml  ← existing
    ChatInterface.xml              ← existing (Phase 3+)
    PopUpDialogue.xml              ← existing
    WorldEventsButton.xml          ← existing (Phase 4)
    WorldEventsWindow.xml          ← existing (Phase 3)
Assets/
  GauntletUI/                      ← generated by Modding Kit (gitignored until final)
    ui_aiinfluence_1.tpac
```

---

## 11. What We Need From You Before Starting

1. **Figma access** — A Figma API personal access token works best for programmatic export. Alternatively, export the components as PNGs per the settings in §5 and drop them into `GUI/SpriteParts/ui_aiinfluence/`.
2. **Figma file link** — So I can enumerate components and map them to the plan above.
3. **Windows game install** — SpriteSheetGenerator.exe must run on Windows with the game installed. You will need to run that step locally; I can generate all the surrounding XML.

---

## 12. Risk / Constraints

| Risk | Mitigation |
|------|-----------|
| SpriteSheetGenerator is Windows-only | All XML authoring and folder structure can be done here; generator runs locally once |
| Native brushes (Encyclopedia.Frame etc.) may update across game patches | Prefer our own brushes everywhere; only keep native brush name if a native prefab forces it |
| UIExtenderEx disables AutoGens globally | Already accepted in this mod (it uses UIExtenderEx v2.11.0); no action needed |
| Texture atlas overflow (>4096×4096) | Keep individual PNGs ≤512×512; use multiple categories if needed |
| 9-patch margin mismatch | Always match `ExtendLeft/Right/Top/Bottom` in BrushLayer to actual corner pixels in the PNG |
