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
| `TextItemVM` | Lines inside each `InfoSectionVM` (`TextLines`). |
| `InfoSectionVM` / `PartyTroopRowVM` | Collapsible right-panel sections; party rows use `InventoryImageIdentifierWidget` + formation label + count. |

## Information panel (right column) — components

**Prefab:** `GUI/Prefabs/ChatInterface.xml` (right column only). **Root VM field:** `NpcChatWindowVM.InfoSections` (`MBBindingList<InfoSectionVM>`).

| Order in XML (outside → in) | Gauntlet widget | Data / command | Brushes / notes |
|----------------------------|-----------------|----------------|-----------------|
| Column shell | `Widget` (fixed `!Info.W`) | — | `BlankWhiteSquare_9` fill `#141414FF` |
| Panel title | `RichTextWidget` | `Text="Information"` (literal) | `SPScoreboard.Subtitle.Text`, `Color="!Gold"` |
| Title underline | `Widget` | — | `BlankWhiteSquare_9` `!SepColor` |
| Scroll | `ScrollablePanel` `InfoScroll` | `ClipRect` / `InnerPanel` → `InfoRect\InfoList` | Vertical scrollbar `InfoScrollbar` |
| Clip | `Widget` `InfoRect` | — | `ClipContents="true"` |
| **Section list** | `NavigatableListPanel` `InfoList` | `DataSource="{InfoSections}"` | **`StackLayout.LayoutMethod="VerticalBottomToTop"`** (same stacking direction as center `MsgList`). |
| Section row (template) | `Widget` | — | One per `InfoSectionVM` |
| Section header | `ButtonWidget` | `Command.Click="ExecuteToggle"` on `InfoSectionVM` | `Encyclopedia.TopBanner` + `Color="#0F141FFF"` |
| Header row layout | `ListPanel` | — | `HorizontalLeftToRight` |
| Header title | `RichTextWidget` | `@HeaderText` | `Encyclopedia.SubPage.Title.Text` |
| Expand/collapse | `TextWidget` | `@ExpandGlyph` | `Encyclopedia.SubPage.Info.Text` |
| Expanded block | `Widget` | `IsVisible="@IsExpanded"` | — |
| Body lines | `ListPanel` | `DataSource="{TextLines}"` (`TextItemVM`) | `VerticalTopToBottom` |
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
