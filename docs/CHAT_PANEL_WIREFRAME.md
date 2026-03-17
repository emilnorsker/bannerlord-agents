# Chat Panel Wireframe

ASCII wireframe of the current chat interface layout (ChatInterface.xml).

```
┌─────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                    FULL SCREEN (StretchToParent)                                          │
├──────────────────────┬──┬─────────────────────────────────────────────────────────────┬──┬──────────────┤
│                      │  │                                                             │  │              │
│   LEFT COLUMN        │SE│                    CENTER COLUMN                             │SE│ RIGHT COLUMN │
│   460px fixed        │P │                  (fills remaining width)                     │P │  300px fixed  │
│   Transparent        │  │                                                             │  │              │
│   (3D character      │2 │  ┌─────────────────────────────────────────────────────┐  │2 │  ┌────────┐  │
│    shows through)    │px│  │ HEADER (80px)                                         │  │px│  │Diplomacy│  │
│                      │  │  │ "Conversation Log"                    @NpcName        │  │  │  │& Relation│  │
│  ┌────────────────┐  │  │  └─────────────────────────────────────────────────────┘  │  │  │  (gold)   │  │
│  │ TopBanner (52px)│  │  │                                                             │  │  └────────┘  │
│  │ @RelationText   │  │  │  ┌─────────────────────────────────────────────────────┐  │  │  ─────────   │
│  │ (left)          │  │  │  │                                                     │  │  │              │
│  │        @TrustLab│  │  │  │  MESSAGE SCROLL AREA (MsgScroll)                     │  │  │  RightList   │
│  │ (right)         │  │  │  │  DataSource: MessageList                             │  │  │  (scrollable)│
│  │ @EmotionLabel   │  │  │  │  VerticalBottomToTop                                 │  │  │  DataSource: │
│  │ (left, bottom)  │  │  │  │                                                     │  │  │  RightPanelItems│
│  └────────────────┘  │  │  │  • NPC messages (left)                              │  │  │              │
│                      │  │  │  • Player messages (right)                           │  │  │  WORLD EVENTS│
│                      │  │  │  • Separators between messages                        │  │  │  • event 1   │
│                      │  │  │                                                     │  │  │  • event 2   │
│                      │  │  │                                                     │  │  │  ...          │
│                      │  │  │                                                     │  │  │              │
│                      │  │  │  [MsgScrollbar]  (22px, right)                      │  │  │  WHAT WE KNOW│
│                      │  │  │                                                     │  │  │  • personality│
│                      │  │  │                                                     │  │  │  • quirks     │
│                      │  │  │                                                     │  │  │  • known info │
│                      │  │  │                                                     │  │  │              │
│                      │  │  │                                                     │  │  │  CHARACTER    │
│                      │  │  │                                                     │  │  │  Relation:    │
│                      │  │  │                                                     │  │  │  Trust:       │
│                      │  │  │                                                     │  │  │  Interactions:│
│                      │  │  │                                                     │  │  │  Mood:       │
│                      │  │  │                                                     │  │  │  [RightScroll]│
│                      │  │  └─────────────────────────────────────────────────────┘  │  │  │              │
│                      │  │  ─────────────────────────────────────────────────────  │  │  │  ┌────────┐  │
│                      │  │  │ [Input Text]                              [Send]      │  │  │  │ Close  │  │
│                      │  │  │  (EditableTextWidget)                    (90×38)     │  │  │  │ 130×38 │  │
│                      │  │  └────────────────────────────────────────────────────  │  │  │  └────────┘  │
│                      │  │  INPUT BAR (52px)                                         │  │  │              │
│                      │  └─────────────────────────────────────────────────────┘  │  │  └──────────────┘
│                      │  Dark backdrop #141414CC, chat_panel_bg texture            │  │  Dark backdrop  │
└──────────────────────┴──┴─────────────────────────────────────────────────────────────┴──┴──────────────┘
```

## Key dimensions

| Element | Width | Height |
|---------|-------|--------|
| Left column | 460px | full |
| Separator | 2px | full |
| Right column | 300px | full |
| Header | stretch | 80px |
| Input bar | stretch | 52px |
| TopBanner (left overlay) | stretch | 52px |
| Send button | 90px | 38px |
| Close button | 130px | 38px |
| Message bubble max | 430px | — |

## Data bindings

| UI element | DataSource / Binding |
|------------|----------------------|
| Left overlay | RelationText, RelationColor, TrustLabel, EmotionLabel |
| Header | NpcName (NpcTitle is in VM but not bound in XML) |
| Message list | MessageList (ChatMessageItemVM) |
| Input | InputText, OnTextChanged |
| Send button | IsSendEnabled, ExecuteSendMessage |
| Right list | RightPanelItems (TextItemVM) |
| Close button | ExecuteReturn |

## Right panel sections (RightPanelItems)

1. **WORLD EVENTS** (header) + up to 5 event titles/descriptions
2. **WHAT WE KNOW** (header) + AIGeneratedPersonality, Quirks, KnownInfo
3. **CHARACTER** (header) + Relation, Trust (0–100%), Interactions, Mood

Note: TrustLabel uses thresholds 0.6/0.3 (TrustLevel is 0–1).
