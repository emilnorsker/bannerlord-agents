# NPC chat UI (single surface)

This module exposes **one** in-game Gauntlet conversation UI for AI NPC chat.

## Stack

| Piece | Role |
|--------|------|
| `GUI/Prefabs/ChatInterface.xml` | Gauntlet prefab (`Window` id `ChatInterfaceWindow`). Encyclopedia-style shell + custom message list / pills / input. |
| `NpcChatWindowLayer` | `GauntletLayer` that loads movie name **`ChatInterface`**. |
| `NpcChatWindowManager` | Show / close / `IsOpen`; only owner of the layer. |
| `NpcChatWindowVM` | Root datasource: hero strip, `MessageList`, `RightPanelItems`, commands. |
| `ChatMessageItemVM` / `ContentSegmentVM` | Per-turn rows and speech / pill segments. |
| `TextItemVM` | Right “Information” column lines. |

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

## Optional follow-ups

- `GUI/Brushes/PopUpBrush.xml` TODOs reference future segment types (`IsEvent`, `IsItemGrant`) in `ChatInterface.xml`; current template only uses **body / pill** (`IsBody` / `IsPill`).
