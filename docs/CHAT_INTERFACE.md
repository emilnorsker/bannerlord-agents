# NPC chat UI (single surface)

This module exposes **one** in-game Gauntlet conversation UI for AI NPC chat.

## Stack

| Piece | Role |
|--------|------|
| `GUI/Prefabs/ChatInterface.xml` | Gauntlet prefab (`Window` id `ChatInterfaceWindow`). Encyclopedia-style shell + custom message list / pills / input. |
| `NpcChatWindowLayer` | `GauntletLayer` that loads movie name **`ChatInterface`**. |
| `NpcChatWindowManager` | Show / close / `IsOpen`; only owner of the layer. |
| `NpcChatWindowVM` | Root datasource: hero strip, `MessageList`, `InfoSections` (collapsible blocks), commands. |
| `ChatMessageItemVM` / `ContentSegmentVM` | Per-turn rows and speech / pill segments. |
| `TextItemVM` | Lines inside each `InfoSectionVM` (`TextLines`) when `HasStandardTextLines` is true. |
| `WorldEventLineVM` | World events only: `SkillIconVisualWidget` + text; skill from `DynamicEvent.Type` via `WorldEventSkillMapper` → `DefaultSkills` IDs (same as encyclopedia). |
| `InfoSectionVM` / `PartyTroopRowVM` | Collapsible right-panel sections; party rows use `InventoryImageIdentifierWidget` + formation label + count. |

## Component tree (`ChatInterface.xml`)

Prefab: `GUI/Prefabs/ChatInterface.xml`. **Layout constants:** `EncyLeft.W`=370, `Info.W`=540, `Header.H`, `Input.H`, `Inset`, `Sep.W`. **Non–text widgets** get a short role note (`TextWidget` / `RichTextWidget` shown as `…`). Indentation = containment.

```
Window ChatInterfaceWindow (Layer=Overlay)
└── BrushWidget [Encyclopedia.Page.SoundBrush] — full-screen shell; encyclopedia page brush (sound/visual parent for this screen).
    └── Widget — inset margin; receives input for the whole window.
        └── ListPanel [HorizontalLeftToRight] — three columns: hero (~370) | chat (stretch) | info (~540).
            │
            ├── Widget [left ~EncyLeft.W] — column background gradient.
            │   ├── Widget (clip) — clips the tableau stack.
            │   │   ├── EncyclopediaCharacterTableauWidget {HeroCharacter} — 3D portrait / equipment tableau.
            │   │   ├── Widget [hero_silhouette] — shown when information is hidden.
            │   │   ├── ParallaxItemBrushWidget [Smoke] — animated smoke (vanilla encyclopedia).
            │   │   └── ParallaxItemBrushWidget [Smoke2]
            │   ├── TextWidget …
            │   ├── ListPanel [VerticalBottomToTop] — name / title / traits block.
            │   │   ├── TextWidget …
            │   │   ├── TextWidget …
            │   │   ├── Widget [pregnant icon] — sprite container.
            │   │   │   └── HintWidget {PregnantHint}
            │   │   ├── NavigationScopeTargeter — focus entry into trait strip.
            │   │   └── NavigatableListPanel Id=NpcChatTraits {Traits}
            │   │       └── ItemTemplate: EncyclopediaHeroTraitVisualWidget
            │   │           └── HintWidget {Hint}
            │   ├── ListPanel [VerticalBottomToTop] — skills header + grid (bottom-aligned).
            │   │   ├── TextWidget …
            │   │   ├── NavigationScopeTargeter — focus entry into skills grid.
            │   │   └── NavigatableGridWidget Id=NpcChatSkillsGrid {HeroSkillList}
            │   │       └── ItemTemplate: SkillIconVisualWidget @SkillId
            │   │           ├── TextWidget …
            │   │           └── HintWidget {Hint}
            │   └── Widget [vertical divider sprite]
            │
            ├── Widget [Sep.W] — thin column separator.
            │
            ├── Widget [center, stretch]
            │   ├── Widget — chat column fill #141414.
            │   └── Widget — interactive layer (header, message scroll, input bar).
            │       ├── Widget [header bar !Header.H]
            │       │   ├── TextWidget …
            │       │   ├── RichTextWidget …
            │       │   ├── RichTextWidget …
            │       │   └── TextWidget …
            │       ├── ScrollablePanel Id=MsgScroll — message list; InnerPanel MsgClip\MsgList; mouse wheel only (no visible scrollbar).
            │       │   └── Widget Id=MsgClip — clip rect for messages.
            │       │       └── ListPanel Id=MsgList {MessageList} [VerticalBottomToTop]
            │       │           └── ItemTemplate: Widget — one message row.
            │       │               ├── ListPanel [NPC] @IsNpc
            │       │               │   ├── Widget [name_shadow]
            │       │               │   │   └── ListPanel [Horizontal] — sender name + type tag.
            │       │               │   │       ├── RichTextWidget …
            │       │               │   │       └── TextWidget …
            │       │               │   └── ListPanel {ContentSegments} [VerticalBottomToTop]
            │       │               │       └── ItemTemplate: Widget — segment wrapper.
            │       │               │           ├── Widget @IsBody → TextWidget …
            │       │               │           └── Widget @IsPill → TextWidget …
            │       │               └── ListPanel [Player] @IsPlayer
            │       │                   ├── Widget — sender name strip.
            │       │                   │   └── RichTextWidget …
            │       │                   └── ListPanel {ContentSegments} …
            │       │                       └── ItemTemplate: Widget — same body/pill pattern, right-aligned.
            │       ├── Widget [thin horizontal rule above input]
            │       └── Widget [input bar !Input.H]
            │           ├── Widget [frame_9]
            │           ├── Widget [gradient]
            │           ├── Widget [text_input chrome]
            │           │   ├── Widget [inner frame_9]
            │           │   └── EditableTextWidget @InputText — player typing; OnTextChanged.
            │           └── ButtonWidget ExecuteSendMessage @IsSendEnabled
            │               └── TextWidget …
            │
            ├── Widget [Sep.W]
            │
            └── Widget [right column fixed width !Info.W = 540px]
                ├── Widget — column fill #141414.
                ├── BrushWidget [Encyclopedia.TopBanner] — fixed “Information” strip (not collapsible; no ExecuteToggle).
                ├── Widget [title underline]
                ├── BrushWidget [Encyclopedia.Frame] — outer frame around the scroll area only.
                │   └── ScrollablePanel Id=InfoScroll — InnerPanel InfoRect\InfoList; VerticalScrollbar ..\..\InfoScrollbar; mouse wheel.
                │       └── Widget Id=InfoRect — clip; holds section list + bottom shadow.
                │           ├── NavigatableListPanel Id=InfoList {InfoSections} [VerticalBottomToTop]
                │           │   └── ItemTemplate: Widget [BlankWhiteSquare_9 Color=@SectionPanelColor] — alternating stripe tint per section (VM: #121820F0 / #1E1810F0 top→bottom).
                │           │       └── ListPanel — one collapsible section (header button + expanded body).
                │           │           ├── ButtonWidget ExecuteToggle [Encyclopedia.TopBanner]
                │           │           │   └── ListPanel [Horizontal] — @HeaderText + @ExpandGlyph (text widgets).
                │           │           └── ListPanel @IsExpanded
                │           │               ├── ListPanel {WorldEventLines} @HasWorldEventLines
                │           │               │   └── ItemTemplate: ListPanel [Horizontal]
                │           │               │       ├── SkillIconVisualWidget @SkillId
                │           │               │       └── RichTextWidget …
                │           │               ├── ListPanel {TextLines} @HasStandardTextLines
                │           │               │   └── ItemTemplate: Widget → RichTextWidget …
                │           │               ├── ListPanel {TroopRows} @HasTroopRows
                │           │               │   └── ItemTemplate: ListPanel [Horizontal]
                │           │               │       ├── InventoryImageIdentifierWidget @Portrait
                │           │               │       ├── RichTextWidget …
                │           │               │       └── TextWidget …
                │           │               └── RichTextWidget … @ShowPartyFood
                │           └── BrushWidget [Encyclopedia.Scroll.Shadow] — bottom fade over scroll content.
                ├── ScrollbarWidget Id=InfoScrollbar — custom flat track + handle.
                │   ├── BrushWidget [scrollbar bed]
                │   └── BrushWidget Id=InfoScrollbarHandle
                └── ButtonWidget ExecuteReturn
                    └── TextWidget …
```

## Information panel (right column) — components

**Prefab:** `GUI/Prefabs/ChatInterface.xml` (right column only). **Root VM field:** `NpcChatWindowVM.InfoSections` (`MBBindingList<InfoSectionVM>`).

| Order in XML (outside → in) | Gauntlet widget | Data / command | Brushes / notes |
|----------------------------|-----------------|----------------|-----------------|
| Column shell | `Widget` (fixed `!Info.W`, **540px**) | — | `BlankWhiteSquare_9` fill `#141414FF` |
| Panel title (fixed, not collapsible) | `BrushWidget` | — | `Encyclopedia.TopBanner` + `Color="#0F141FFF"`; child `RichTextWidget` `Text="Information"` |
| Title underline | `Widget` | — | `BlankWhiteSquare_9` `!SepColor` |
| Scroll | `BrushWidget` `Encyclopedia.Frame` → `ScrollablePanel` `InfoScroll` | `ClipRect` / `InnerPanel` → `InfoRect\InfoList` | Same frame pattern as `WorldEventsWindow` list area; scrollbar path `..\..\InfoScrollbar` (nested under frame). |
| Clip | `Widget` `InfoRect` | — | `ClipContents="true"` |
| **Section list** | `NavigatableListPanel` `InfoList` | `DataSource="{InfoSections}"` | **`VerticalBottomToTop`**: first VM in the list sits at the **bottom** of the scroll, last at the **top**. `RebuildInfoPanelSections` adds sections so **top→bottom** reads: NPC party → Quests → World events → What we know → Character. |
| **Section stripe** | `Widget` | `Sprite="BlankWhiteSquare_9"`, `Color="@SectionPanelColor"` | Alternating tints (`#121820F0` / `#1E1810F0`) by visual index from top; wraps each collapsible block. |
| **Section row** | `ListPanel` `VerticalTopToBottom` | Header `ButtonWidget` then body `ListPanel` | **Do not** use a plain `Widget` for multiple children — Gauntlet stacks list panels; bare `Widget` overlays children (caused header/body overlap before this fix). |
| Section row (template) | `ListPanel` | — | One per `InfoSectionVM`, inside stripe `Widget` |
| Section header | `ButtonWidget` | `Command.Click="ExecuteToggle"` on `InfoSectionVM` | `Encyclopedia.TopBanner` + `Color="#0F141FFF"` |
| Header row layout | `ListPanel` | — | `HorizontalLeftToRight` |
| Header title | `RichTextWidget` | `@HeaderText` | `Encyclopedia.SubPage.Title.Text` |
| Expand/collapse | `TextWidget` | `@ExpandGlyph` | `Encyclopedia.SubPage.Info.Text` |
| Expanded block | `ListPanel` | `IsVisible="@IsExpanded"` | — |
| World event lines (optional) | `ListPanel` | `IsVisible="@HasWorldEventLines"`, `DataSource="{WorldEventLines}"` | `SkillIconVisualWidget` + `RichTextWidget`; type→skill: military→Tactics, political→Charm, economic→Trade, social→Leadership, mysterious→Roguery, disease→Medicine, news/other→Scouting |
| Body lines | `ListPanel` | `IsVisible="@HasStandardTextLines"`, `DataSource="{TextLines}"` (`TextItemVM`) | `VerticalTopToBottom` |
| Body line | `RichTextWidget` | `@Text`, `@Color` | `Encyclopedia.SubPage.Info.Text` |
| Party rows | `ListPanel` | `DataSource="{TroopRows}"`, `IsVisible="@HasTroopRows"` | `VerticalTopToBottom` |
| Party row | `ListPanel` (horizontal) | — | `PartyTroopRowVM` |
| Troop portrait | `InventoryImageIdentifierWidget` | `@Portrait` (`ImageIdentifier`) | Vanilla party/inventory screens use the same widget name. |
| Formation label | `RichTextWidget` | `@FormationName` | `Encyclopedia.SubPage.Info.Text` |
| Count | `TextWidget` | `@CountLabel` | `Encyclopedia.SubPage.Info.Text` |
| Food narrative | `RichTextWidget` | `IsVisible="@ShowPartyFood"`, `@PartyFoodText`, `@PartyFoodColor` | `Encyclopedia.SubPage.Info.Text` |
| Scroll shadow | `BrushWidget` (bottom of clip) | — | `Encyclopedia.Scroll.Shadow` |
| Scrollbar | `ScrollbarWidget` `InfoScrollbar` | `Handle` → `InfoScrollbarHandle` | `Encyclopedia.Scrollbar.Flat.Bed` / `Flat.Handle` |
| Close | `ButtonWidget` | `Command.Click="ExecuteReturn"` | `Popup.Cancel.Button` + `Popup.Button.Text` |

### Where to match vanilla (game install, not this repo)

Under `…/Mount & Blade II Bannerlord/`:

| Look here | What to grep / open |
|-----------|----------------------|
| `Modules/SandBox/GUI/Prefabs/` | `Encyclopedia`, `Clan`, `Kingdom`, `Party` in filenames — encyclopedia pages, clan management, party UI. |
| `Modules/Native/GUI/Prefabs/` | Core overlays, common widgets. |
| `Modules/StoryMode/GUI/Prefabs/` | Story-mode-only screens (if needed). |
| `Modules/SandBox/GUI/Brushes/` (and `Native` / module `GUI/Brushes`) | Definitions for `Brush="Encyclopedia...."` names used above. |

**Decompiled reference (optional):** branch `random_logs`, folders like `decompiled/SandBox.ViewModelCollection/` — class names only; art source is still the XML in the install.

## Entry points

- **`DialogManager`** opens chat via `NpcChatWindowManager.Show(...)`.
- **`AIInfluenceBehavior.ProcessChatInput`** is used for sending messages from this UI only (no second chat pipeline).

## Related UI that is **not** this chat

These use other prefabs / layers and must not be confused with NPC chat:

| UI | Prefab / manager | Purpose |
|----|-------------------|---------|
| Messenger letter input | `AIInfluenceTextQueryPopup` / `AIInfluenceTextQueryPopupManager` | Player types a **letter** to send via messenger; uses `AIInfluencePortraitWidget`. |
| World events | `WorldEventsWindow` / `WorldEventsButton` | Event list overlay. |
| Combat phrases | `PopUpDialogue` (SettlementCombat) | Short phrase popup. |

## Removed / obsolete (chat-specific)

- **Portrait preload on chat open:** `NpcChatWindowLayer` no longer sets `AIInfluencePortraitWidget.PendingCharacterCode`. The chat prefab uses **`EncyclopediaCharacterTableauWidget`** + `HeroViewModel`, not `AIInfluencePortraitWidget`.
- **Encyclopedia bookmark button:** Removed from `ChatInterface.xml` and VM; see `UPCOMING_FEATURES.md`.

## Segment VM

- **`ContentSegmentVM`**: single-arg ctor = body speech (Gauntlet `Chat.Body.Text` only). Two-arg ctor `(text, pillTextColor)` = pill (`Brush.FontColor="@TextColor"`). No unused `BackColor` / per-body text color on the VM.

## Optional follow-ups

- `GUI/Brushes/PopUpBrush.xml` TODOs reference future segment types (`IsEvent`, `IsItemGrant`) in `ChatInterface.xml`; current template only uses **body / pill** (`IsBody` / `IsPill`).

---

## `AIResponse` → game execution vs chat pills

After each send, `AIInfluenceBehavior` applies many `AIResponse` fields (money, items, quests, kingdom, workshop, …). **Chat pills** are a separate summary built in `NpcChatWindowVM.BuildPlayerActionPills` (player’s message row) and `BuildNpcActionPills` (NPC reply row). Both read the **same** `AIResponse` so **money and items are mirrored on both rows** (wording from player vs NPC perspective).

### `money_transfer` (`MoneyTransferInfo`)

| `action` | Meaning in `ProcessMoneyTransfer` | Player-row pill | NPC-row pill |
|----------|-----------------------------------|-----------------|--------------|
| `receive` | Player pays NPC (player −gold, NPC +gold) | `You gave {amt} gold to {npc}` | `{npc} received {amt} gold from you` |
| `give` | NPC pays player (NPC −gold, player +gold) | `You received {amt} gold from {npc}` | `{npc} gave you {amt} gold` |

Other `action` strings: **no pill**; execution logs `Unknown action` and does not move gold.

Optional `opposed_attribute`: opposed roll before any transfer (same for money/items).

### `item_transfers[]` (`ItemTransferData`)

| `action` | Meaning in `ProcessItemTransfers` | Player-row pill | NPC-row pill |
|----------|-----------------------------------|-----------------|--------------|
| `take` | Player → NPC (items leave player) | `You gave {items} to {npc}` | `{npc} took {items} from you` |
| `give` | NPC → player | `You received {items} from {npc}` | `{npc} gave you {items}` |

Other `action` values: transfer fails with “Unknown action”; **no pill**.

### `workshop_action`

Prompt / schema (`PromptGenerator`): **`none`** or **`sell`** only. There is **no** documented `buy` or other value.

| Value | Execution | Pill (NPC row only) |
|-------|-----------|---------------------|
| `sell` (final agreement) | `ProcessWorkshopSale` / delayed sale | `Sold workshop to you` |
| `none` / omitted | No workshop UI | — |
| Anything else | Not handled like `sell` | **No pill** (and sale will not run) |

### `quest_action` (`QuestActionData`)

- **`action`**: free string (e.g. create / update / complete / fail — see `ProcessQuestAction`). **Pill (NPC row):** `Quest: {action}` (raw string).
- Other quest fields drive behavior, not separate pill lines.

### `decision`

- Non-`none` text → **NPC row** pill: `• {decision}` (`ActionColor`). No player-row mirror.

### `LastTechnicalActionForDisplay` (on `NPCContext`)

- Pipe-separated `name:payload` entries; special cases (`follow_player`, `transfer_troops_and_prisoners`, …). **NPC row only** (technical / follow / travel pills).

### `romance_intent`

- Not `none` → **NPC row** pill (flirt / romance / proposal labels or raw). No player-row mirror.

### `kingdom_action` + `kingdom_action_reason`

- **`kingdom_action`**: must be `none` or one of many strings from **`GetKingdomActionsSection`** in `PromptGenerator` (war/peace, alliance, trade, tribute, reparations, fief grant/receive, hire/dismiss mercenary, vassalage, join clan/kingdom, kick, `transfer_kingdom`, … — **context-dependent**; the prompt only lists what the NPC *may* use).
- **`kingdom_action_reason`**: brief justification (prompt: required when action ≠ `none`). Also fed into `InformationManager` toasts as `{REASON}`.
- **Pill (NPC row):** `Kingdom: {action}` if reason empty; otherwise `Kingdom: {action} — {reason}` (reason whitespace collapsed to single spaces).
- **`ExecuteKingdomAction`** runs the real diplomacy.

### Fields with **no** chat pill (examples)

Still applied or stored elsewhere; not rendered as structured pills: `internal_thoughts`, `claimed_*`, `threat_level`, `escalation_state`, `workshop_string_id` / `workshop_price` (used for sale, not pill text), `character_death`, `character_personality` / backstory / quirks (context + UI panels), `tts_instructions`, `settlement_id` alone, `item_transfers_opposed_attribute` (affects roll only), etc.

### Relation / narrative pills (history string)

From **`ParseLine`**: blocks after `\\n---\\n` (action) and `\\n===\\n` (relation) become pills when **reloaded from `ConversationHistory`**, independent of `AIResponse`.
