# Bannerlord Conversation System — Full Explanation

This document explains the conversation/dialogue system in Mount & Blade II: Bannerlord, based on the official API documentation (apidoc.bannerlord.com) and the modding community.

---

## 1. API Documentation Sources

- **ConversationManager**: https://apidoc.bannerlord.com/v/1.3.4/class_tale_worlds_1_1_campaign_system_1_1_conversation_1_1_conversation_manager.html
- **ConversationTokens**: https://apidoc.bannerlord.com/v/1.0.0/class_tale_worlds_1_1_campaign_system_1_1_conversation_1_1_conversation_tokens.html
- **Conversation Namespace**: https://apidoc.bannerlord.com/v/1.3.4/namespace_tale_worlds_1_1_campaign_system_1_1_conversation.html
- **DialogFlow**: https://apidoc.bannerlord.com/v/1.3.4/class_tale_worlds_1_1_campaign_system_1_1_dialog_flow.html
- **CampaignGameStarter**: https://apidoc.bannerlord.com/v/1.3.4/class_tale_worlds_1_1_campaign_system_1_1_campaign_game_starter.html
- **CampaignMapConversation**: https://apidoc.bannerlord.com/v/1.2.7/class_tale_worlds_1_1_campaign_system_1_1_conversation_1_1_campaign_map_conversation.html
- **PlayerEncounter**: https://apidoc.bannerlord.com/v/1.2.9/class_tale_worlds_1_1_campaign_system_1_1_encounters_1_1_player_encounter.html
- **LocationEncounter**: https://apidoc.bannerlord.com/v/1.3.4/class_tale_worlds_1_1_campaign_system_1_1_encounters_1_1_location_encounter.html
- **Modding Wiki (Conversation)**: https://mbmodwiki.github.io/Conversation
- **Dialogs (BannerlordModding.LT)**: https://docs.bannerlordmodding.lt/modding/dialogs/

---

## 2. Core Conversation Architecture

### 2.1 ConversationManager

The `ConversationManager` (TaleWorlds.CampaignSystem.Conversation) is the central class for managing dialogue flow:

| Method | Purpose |
|--------|---------|
| `StartNew(int startingToken, bool setActionsInstantly)` | Initiates a new conversation. `startingToken` is an int (0–4) mapping to the `ConversationToken` enum. |
| `ProcessSentence(ConversationSentenceOption option)` | Processes a selected dialogue option and runs its consequence. |
| `UpdateCurrentSentenceText()` | Updates the displayed text. |
| `IsConversationEnded()` | Returns whether the conversation has ended. |
| `ClearCurrentOptions()` / `AddToCurrentOptions()` | Manages available dialogue options. |
| `CreateConversationSentenceIndex()` | Builds the sentence index for the current state. |

### 2.2 ConversationToken Enum (Starting Tokens)

`ConversationManager.StartNew(int startingToken, ...)` uses these enum values:

| Value | Name | Context |
|-------|------|---------|
| 0 | **Start** | General conversation start — towns, world map, settlements. |
| 1 | **EventTriggered** | Automatically triggered (e.g. after battle, quest event). |
| 2 | **MemberChat** | Talking to party members (companions, troops). |
| 3 | **PrisonerChat** | Talking to prisoners. |
| 4 | **CloseWindow** | Conversation end / window close. |
| 5 | **NumTokens** | Sentinel (total count). |

### 2.3 String-Based Tokens (ConversationTokens Class)

Dialogue lines use **string tokens** for branching. The `ConversationTokens` class defines:

- `LordStart` = `"lord_start"`
- `LordPretalk` = `"lord_pretalk"`

Vanilla and mods use many more string tokens, e.g.:

- `"start"` — general entry
- `"hero_main_options"` — main hero options (used by AI Influence mod)
- `"lord_demands_surrender_after_comment"` — surrender demand flow
- `"player_responds_to_surrender_demand"` — surrender response flow
- `"member_chat"` — party member chat
- `"event_triggered"` — event-triggered
- `"prisoner_liberated"` — after liberating a prisoner
- `"enemy_defeated"` — after defeating an enemy hero
- `"party_relieved"` — after an ally wins a battle

---

## 3. Conversation Contexts (Where & With Whom)

### 3.1 Physical Context: Map vs Settlement

| Context | Encounter Type | Scene | Notes |
|---------|----------------|-------|-------|
| **Campaign map** | `PlayerEncounter` | Map overlay (no 3D scene) | `CampaignMapConversation` handles this. |
| **Town** | `TownEncounter` (extends `LocationEncounter`) | Town center scene | Uses `sp_player_conversation` spawn points. |
| **Village** | `VillageEncounter` (extends `LocationEncounter`) | Village scene | Up to 3 notables. |
| **Castle** | `CastleEncounter` (extends `LocationEncounter`) | Castle scene | Similar to town. |

**Settlement scenes**: When the player enters a settlement and talks to an NPC, both spawn at `"sp_player_conversation"` prefabs. Multiple such points add variation.

### 3.2 NPC Role Context (Who You Talk To)

| Role | Token / Flow | Notes |
|------|--------------|-------|
| **Lord / notable (in settlement)** | `lord_start`, `hero_main_options` | Main dialogue tree. |
| **Party member** | `MemberChat` (2) | Companions, family, troops in party. |
| **Prisoner** | `PrisonerChat` (3) | Prisoners in player party or settlement. |
| **Event-triggered NPC** | `EventTriggered` (1) | Post-battle, quest, etc. |

### 3.3 Combat vs Non-Combat State

From your `DialogManager.IsNonCombatConversation()`:

- **Non-combat**: `CombatResponse == null`, not surrendering, no pending death, no marriage response.
- **Combat**: Surrender demand, attack, or other combat-related flow.
- **Prisoner**: Always treated as non-combat for AI Influence logic.

---

## 4. Dialogue Flow (Token-Based Branching)

### 4.1 How Tokens Work

1. `ConversationManager.StartNew(token)` sets the initial **input token**.
2. Each dialogue line has:
   - **inputToken** — when this line is available
   - **outputToken** — where the conversation goes next
3. Matching: lines whose `inputToken` equals the current token are evaluated.
4. Conditions filter which options are shown; consequences run when selected.
5. `"close_window"` or equivalent ends the conversation.

### 4.2 CampaignGameStarter Methods

```csharp
// Player says something
AddPlayerLine(id, inputToken, outputToken, text, condition, consequence, priority, clickableCondition, persuasionOption);

// NPC says something
AddDialogLine(id, inputToken, outputToken, text, condition, consequence, priority);
AddDialogLineMultiAgent(...);  // For multi-agent conversations
```

### 4.3 DialogFlow (Fluent API)

```csharp
DialogFlow.Create("id", (campaignGameStarter) => {
    campaignGameStarter.AddPlayerLine(...);
    campaignGameStarter.AddDialogLine(...);
})
.NpcLine("text")           // NPC line
.PlayerLine("text")        // Player option
.BeginPlayerOptions()      // Start player choice block
.Variation("alt text")     // Text variations
```

---

## 5. Conversation States Summary

### 5.1 By Starting Token (ConversationToken enum)

| State | Int | When Used |
|-------|-----|-----------|
| Start | 0 | Towns, world map, general encounters. |
| EventTriggered | 1 | Post-battle, quest events, scripted encounters. |
| MemberChat | 2 | Party members (companions, family). |
| PrisonerChat | 3 | Prisoners. |
| CloseWindow | 4 | End conversation. |

### 5.2 By Location

| Location | Encounter | Conversation Type |
|----------|-----------|-------------------|
| World map | `PlayerEncounter` | `CampaignMapConversation` — map overlay. |
| Town | `TownEncounter` | 3D town scene, `sp_player_conversation`. |
| Village | `VillageEncounter` | 3D village scene. |
| Castle | `CastleEncounter` | 3D castle scene. |

### 5.3 By NPC State

| NPC State | Restrictions |
|-----------|--------------|
| Free lord | Full dialogue. |
| Party member | `MemberChat` flow. |
| Prisoner | `PrisonerChat` flow; limited options. |
| In combat / surrender | Combat-specific branches (e.g. `lord_demands_surrender_after_comment`). |
| Dead | No conversation. |

### 5.4 By Initiative

| Initiative | Flow |
|------------|------|
| Player-initiated | Player chooses "Talk" → `Start` or `lord_start` → main options. |
| NPC-initiated (neutral) | `start` → `aiinfluence_neutral_waiting` (AI Influence). |
| NPC-initiated (hostile) | `start` → `aiinfluence_hostile_waiting` (AI Influence). |
| Event-triggered | `EventTriggered` → scripted flow. |

---

## 6. Key Classes Reference

| Class | Namespace | Purpose |
|-------|-----------|---------|
| `ConversationManager` | TaleWorlds.CampaignSystem.Conversation | Core conversation logic. |
| `ConversationSentence` | TaleWorlds.CampaignSystem.Conversation | Single dialogue line (condition, consequence, tokens). |
| `ConversationSentenceOption` | TaleWorlds.CampaignSystem.Conversation | One selectable option. |
| `CampaignMapConversation` | TaleWorlds.CampaignSystem.Conversation | Map overlay conversation. |
| `CampaignGameStarter` | TaleWorlds.CampaignSystem | Registers dialogues via `AddDialogFlow`, `AddPlayerLine`, etc. |
| `DialogFlow` | TaleWorlds.CampaignSystem | Fluent dialog registration. |
| `IConversationStateHandler` | TaleWorlds.CampaignSystem.Conversation | Handles install/uninstall, activate/deactivate. |
| `GauntletMapConversationView` | SandBox.GauntletUI.Map | Implements `IConversationStateHandler` for map UI. |

---

## 7. Decompilation Note

To inspect the exact implementation:

1. **Binaries**: `TaleWorlds.CampaignSystem.dll`, `TaleWorlds.MountAndBlade.dll`, `SandBox.dll` in  
   `Steam/steamapps/common/Mount & Blade II Bannerlord/bin/Win64_Shipping_Client/`
2. **Tools**: dnSpy, ILSpy, or dotPeek.
3. **Relevant types**: `ConversationManager`, `CampaignMapConversation`, `ConversationToken`, `ConversationTokens`, campaign behaviors that register dialogues (e.g. `CaravanConversationsCampaignBehavior`, `WorkshopsCharactersCampaignBehavior`).

---

## 8. AI Influence Mod Integration

Your mod hooks into:

- **Input tokens**: `hero_main_options`, `start`, `player_responds_to_surrender_demand`, `aiinfluence_input`, etc.
- **Output tokens**: `aiinfluence_response`, `aiinfluence_processing`, `end_conversation`, `lord_demands_surrender_after_comment`, etc.
- **Conditions**: `Hero.OneToOneConversationHero`, `IsNonCombatConversation()`, `IsNeutralNPCInitiatedConversation()`, `IsHostileNPCInitiatedConversation()`.
- **Patches**: `CaravanConversationPatch`, `WorkshopsConversationPatch`, `TalkVisitRedirectPatch` (redirects QuickConversation → Conversation).
