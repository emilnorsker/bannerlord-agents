# 🔧 AI Influence — Technical Guide

Short description of the mod files and how to work with them.

---

## 📁 File Structure

```
AIInfluence DEV/
├── world.txt                        # World description for the AI
├── world_secrets.json               # NPC secrets
├── world_info.json                  # General information
├── quirks.json                      # Speech quirks
├── cultural_traditions.json         # Romantic traditions
│
├── save_data/                       # Save data
│   └── [CAMPAIGN_ID]/               # Campaign folder
│       ├── NPC (id).json            # Context for each NPC
│       ├── dynamic_events.json      # All dynamic events + diplomacy schedules (unified v2, mod v5.0.0+)
│       ├── diplomatic_statements.json   # Rulers' statements
│       ├── alliances.json           # Kingdom alliances
│       ├── war_statistics.json      # War statistics
│       ├── pending_player_statements.json # Pending player statements
│       ├── trade_agreements.json    # Trade agreements
│       ├── territory_transfers.json # Territory transfer history
│       ├── tributes.json            # Tribute agreements
│       └── reparations.json         # Reparations between kingdoms
│
└── logs/                            # Logs
    ├── mod_log.txt
    ├── diplomacy.txt
    └── dynamicEvents.log
```

**Embedded campaign save (SyncData, mod v5.0.0+):** AI Influence still persists core state inside the Bannerlord save via `CampaignBehaviorBase.SyncData`. Active keys include `AIInfluence_followingHeroIds`, `AIInfluence_aiActionState`, `AIInfluence_npcContexts`, `AIInfluence_currentSaveFolder`, plus other behaviors (e.g. task manager, non-combatant protector, death history, settlement penalties, economic effects, dialog logger, messenger menu). **Arena training and the disease system were removed** in this line of development: they no longer register behaviors or SyncData slots. Older dev saves may still contain stale binary blobs for removed keys; the engine typically ignores unknown keys. **v5 does not migrate or recover pre-v5 embedded payloads** — use a new campaign for a supported layout.

---

## 🌍 `world.txt`

**What:** Calradia world description for the AI.

**Why:** The AI reads it on every dialogue for context.

**How to edit:**
- Add your lore in the section "Additional Information About Calradia:"
- Use `{Character}` and `{Player}` instead of specific names
- Write in English
- Save → the file will be hot‑reloaded automatically

---

## 🔐 `world_secrets.json`

**What:** Secret knowledge that NPCs may know.

**Format:**
```json
[
  {
    "id": "unique_id",
    "description": "Description for the AI",
    "knowledgeChance": 50,
    "applicableNPCs": ["lords"],
    "accessLevel": "high",
    "tags": ["optional"]
  }
]
```

**How it works:**
1. On first interaction, a 0–100 roll is made
2. If ≤ `knowledgeChance` → the NPC learns the secret
3. The secret is added to the prompt: `"Secrets: ... (access: high)"`
4. The AI decides whether to reveal it (depends on trust)

**Important:** Use `knowledgeChance`, NOT `usageChance`!

---

**Fields:**
- `id` — unique name
- `description` — full text (passed into the AI prompt)
- `knowledgeChance` — 0–100 chance that the NPC learns it on first contact
- `applicableNPCs` — types: `all`, `lords`, `companions`, `faction_leaders`, `village_notables`, `merchants`
- `accessLevel` — `low`, `medium`, `high` (shown in the prompt)
- `tags` — for organization (does not affect logic)

## 📰 `world_info.json`

**What:** Public, non‑secret information.

**Format:**
```json
[
  {
    "id": "unique_id",
    "description": "Description (you can use {character})",
    "usageChance": 75,
    "applicableNPCs": ["all"], (types: `all`, `lords`, `companions`, `faction_leaders`, `village_notables`, `merchants`)
    "category": "world"
  }
]
```

**Fields:**
- `usageChance` — 0–100 chance (works like knowledgeChance)
- `category` — `world` (persistent), `event` (temporary), `personal` (personal)

**Differences from secrets:**
- Field: `usageChance` vs `knowledgeChance`
- Classification: `category` vs `accessLevel`
- In the prompt: "General Info: ..." vs "Secrets: ... (access: high)"

---

## 🗣️ `quirks.json`

**What:** List of speech quirks for NPCs.

**Format:**
```json
[
  "speaks briefly and avoids unnecessary words",
  "uses hunting, battle, or military analogies",
  "questions others like a quiet interrogator"
]
```

**How it works:**
- An NPC gets 1–2 random quirks at creation
- They are added to the prompt: `"Speech Quirks: ..."`
- The AI uses them to shape speaking style

**Customization:** Just add strings to the array.

---

## 💕 `cultural_traditions.json`

**What:** Romantic traditions per culture.

**Format:**
```json
{
  "Aserai": "Description of romantic traditions...",
  "Battania": "..."
}
```

**Affects:** Flirt style and relationship requirements.

---

## 💾 NPC Files: `save_data/[CAMPAIGN_ID]/Name (id).json`

**Main fields:**

| Field | What it does | Can edit |
|------|--------------|----------|
| `CharacterDescription` | Personality description | ✅ YES |
| `KnownSecrets` | Known secrets | ✅ YES (sets a flag) |
| `KnownInfo` | Known information | ✅ YES (sets a flag) |
| `ConversationHistory` | Dialogue history | ❌ Automatic |
| `DynamicEvents` | Known events | ❌ Automatic |
| `Quirks` | Speech quirks | ⚠️ Will be overwritten |

You can also see service fields:

- `KnownSecretsUserEdited` / `KnownInfoUserEdited` — flags that knowledge was edited by the user (if `true`, the system will no longer change these arrays)
- `DynamicEvents` / `LastEventAnalysisMessageIndex` — which dynamic events the NPC knows and which messages were already sent for analysis
- `AIGeneratedPersonality` / `AIGeneratedBackstory` — auto‑generated personality and backstory description
- Romance fields (`RomanceLevel`, `LastRomanceInteractionDays`, `IsRomanceEligible`) and battle fields (`SettlementCombatInfo`) — managed only by the system

**Recommendation:** if you do not fully understand a service field, do not edit it — you may break the system.

**Editing knowledge:**

After changing `KnownSecrets` or `KnownInfo`:
```json
"KnownSecrets": ["My_Custom_Secret"],
"KnownSecretsUserEdited": false  // ← Will automatically become true
```

The `UserEdited: true` flag → the system will not touch this field.

**Resetting flags:** MCM → NPC Management → Reset User‑Edited Knowledge

---

## 📋 `dynamic_events.json`

**What:** Single save file for the dynamic-event catalog and diplomacy postscript data. **Mod v5.0.0+ only** — not compatible with older mod versions or pre-unified layouts.

**Envelope (v2):**
- `format_version` — `2`
- `events` — array of event objects (see below)
- `campaign_days`, `save_time` — bookkeeping
- Optional diplomacy fields (when diplomacy uses events): `statement_schedules`, `analysis_schedules`, `statement_queues`, `pending_statements` (relative day offsets and queues; same role as the former separate diplomatic events file)

**Each event object — important fields:**
- `type` — `military`, `political`, `economic`, `social`, `mysterious`
- `importance` — 1–10 (how important)
- `kingdoms_involved` — array of kingdom `string_id`
- `allows_diplomatic_response` — whether rulers can make statements
- `expiration_campaign_days` — when it expires
- `storage_tags` — optional list: `dynamic` (AI/world pipeline), `diplomatic` (active diplomacy slice). An event may have both.

Additionally, events have:
- `id` — unique event identifier (string, NPCs store knowledge about it in `DynamicEvents`)
- `player_involved` — whether the player participated
- `spread_speed` — how fast it spreads

**Older files:** A bare JSON array, `diplomatic_events.json`, or `format_version` other than `2` is **not** loaded; the catalog starts empty for that campaign folder.

**NPC link:**  
The list of NPCs who know about an event is stored in each `NPC (id).json` in the `DynamicEvents` array. `DynamicEventsManager` automatically updates these fields and removes expired events from NPCs.

**Editing:** Not recommended (managed automatically).

---

## 💬 `diplomatic_statements.json`

**What:** Kingdom rulers' statements.

**Structure:**
```json
{
  "kingdom_id": "battania",
  "statement_text": "Statement text",
  "action": "None/DeclareWar/ProposePeace/...",
  "target_kingdom_id": "khuzait",
  "reason": "Reason",
  "event_id": "event this statement refers to"
}
```

**Storage:** Last 15 statements over 50 in‑game days.

**Editing:** Not needed (automatic system).

---

## 🤝 Additional Diplomacy Files

All files below are in `save_data/[CAMPAIGN_ID]/` and are managed automatically by the diplomacy system.

- `pending_player_statements.json` — deferred player statements to be published later
- `trade_agreements.json` — current trade agreements between kingdoms
- `territory_transfers.json` — history of fief transfers between kingdoms
- `tributes.json` — tribute payment agreements
- `reparations.json` — reparations data (history and open claims)

**Rule:** all these files are intended for automatic system operation. Edit only if you clearly understand the consequences (for debugging); always make a backup first.

## 📊 Logs

### `logs/mod_log.txt` — main log
- Mod initialization
- Config loading
- AI prompts and responses
- API errors

**Check when:**
- NPC does not respond
- Secrets are not loaded
- In‑game errors occur

### `logs/diplomacy.txt` — diplomacy
- Diplomacy system initialization
- Creation of diplomatic situations and statements
- Analysis of diplomatic events (full prompts and AI responses)
- Executing actions (wars, peace, alliances, relation changes)
- Diplomacy system errors and warnings

### `logs/dynamicEvents.log` — dynamic events
- Event generation (including full prompt and AI response with detailed debugging on)
- Event propagation to NPCs (who learned what and why)
- Deletion of expired events and cleanup of NPC knowledge

---

## 🛠️ Common Tasks

### Add a secret
1. Open `world_secrets.json`
2. Add an object to the array:
```json
{
  "id": "My_Secret",
  "description": "Secret text here",
  "knowledgeChance": 100,
  "applicableNPCs": ["lords"],
  "accessLevel": "high",
  "tags": []
}
```
3. Save → hot‑reloaded automatically

### Give a secret to a specific NPC
1. Open `save_data/[ID]/NPC_name (id).json`
2. Find `KnownSecrets`
3. Add the secret ID:
```json
"KnownSecrets": ["My_Secret", "Another_Secret"]
```
4. Save → the `UserEdited` flag will be set automatically. If for some reason it is not, set it manually.

### Change an NPC's personality
1. Open the NPC file
2. Edit:
```json
"CharacterDescription": "Your personality description",
```
3. Save

### Find the campaign ID
1. Open `logs/mod_log.txt`
2. Find the line:
```
Created save directory: ...\save_data\b7ed0c2f2399
                                       ^^^^^^^^^^^^ ID
```

Or: MCM → Debug → Show Save Folder Info

### Reset NPC data
**Option 1:** Delete all
- MCM → NPC Management → Clear Current Campaign NPC Data

**Option 2:** Delete one
- MCM → NPC Management → Erase Specific NPC

**Option 3:** Manually
- Delete the file `save_data/[ID]/NPC_name.json`

```

---

## ⚠️ Important Rules

### JSON files
✅ Always validate JSON (jsonlint.com)  
✅ Make backups before editing  
✅ Do not delete required fields  
❌ Do not edit `dynamic_events.json` and `diplomatic_statements.json` unless necessary

### Secrets vs Info
- `world_secrets.json` → field `knowledgeChance`
- `world_info.json` → field `usageChance`
- **DO NOT CONFUSE THEM!** Otherwise the value will be treated as 0.

### Hot Reload
These files are hot‑reloaded automatically:
- ✅ `world.txt`
- ✅ `world_secrets.json`
- ✅ `world_info.json`
- ✅ `quirks.json`
- ✅ `cultural_traditions.json`

NPC files are reloaded on the next interaction.

### Edit Flags
If you edit `KnownSecrets` or `KnownInfo`:
- The `UserEdited` flag automatically becomes `true`
- The system will no longer touch these fields
- Reset: MCM → Reset User‑Edited Knowledge


---

## 🔄 Workflow

### Adding new content

1. **Come up with an idea** (secret, event, quest)
2. **Add it to JSON** (`world_secrets.json` or `world_info.json`)
3. **Save the file** → hot‑reload
4. **Create new NPCs** or reset existing ones
5. **Start a dialogue** → the AI will know about the new content

### Testing secrets

1. Add a secret with `knowledgeChance: 100`
2. Create a new NPC or reset an existing one
3. Start a dialogue
4. Check the log: `[NPC] Name learned secret: ...`
5. Ask the NPC about the secret directly

### Debugging events

1. Enable detailed logging (MCM)
2. Create an event (Force Generate Event)
3. Check `logs/dynamicEvents.log`
4. See who received the event and why

---

## 📌 Cheat Sheet

### NPC types for `applicableNPCs`
```
"all"              — everyone
"lords"            — lords
"companions"       — companions
"faction_leaders"  — rulers
"village_notables" — village notables
"merchants"        — merchants
```

### Event types
```
"news"        — important news
"political"   — diplomacy
"military"    — wars, battles
"economic"    — trade
"local"       — local
"rumor"       — rumors
```

### Diplomatic actions
```
"None"            — statement only
"DeclareWar"      — declare war
"ProposePeace"    — propose peace
"AcceptPeace"     — accept peace
"RejectPeace"     — reject peace
"ProposeAlliance" — propose alliance
"AcceptAlliance"  — accept alliance
"RejectAlliance"  — reject alliance
"BreakAlliance"   — break alliance
```

---

## 🎯 Key Differences

| Aspect | Secrets | Info |
|--------|---------|------|
| **File** | `world_secrets.json` | `world_info.json` |
| **Chance field** | `knowledgeChance` | `usageChance` |
| **Classification** | `accessLevel` + `tags` | `category` |
| **Purpose** | Secrets, require trust | Public information |

---



