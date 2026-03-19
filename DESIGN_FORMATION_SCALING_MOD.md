# Formation Scaling Mod – Full Design Document

## 1. Overview

A Mount & Blade II: Bannerlord mod that changes how parties and battles work to be more Total War–like:

- **One party unit = many battlefield agents** (e.g. 1 Levy Spearman → 50 men on the field)
- **Formation-based combat** with distinct formations per troop type
- **Fractional casualties** tracked over time
- **20 formations per side** (up from 8)
- **Total War–style reinforcements** (one formation at a time)

**Base:** Fork of the Retinues mod. Retinues provides clan/kingdom troops, upgrade trees, and per-troop customization.

---

## 2. Formation Size System

### 2.1 Per-Unit Formation Size

Each troop type has a **formation size** (e.g. 10–100). One party unit = one formation of that many men on the battlefield.

| Troop Type        | Example Formation Size |
|-------------------|-------------------------|
| Levy Spearman     | 50 (upgradeable)        |
| Vlandian Knight   | 5                       |
| Peasant           | 20                      |

### 2.2 Storage Location

- **Retinues fork:** Add `FormationSize` (int) to troop data in the Retinues editor.
- **Clan vs Kingdom:** Only the player can change kingdom troop formation sizes. Clan troops are player-editable; kingdom troops are fixed for AI.
- **Vanilla troops:** Default formation size (e.g. 10) when no custom value exists.

### 2.3 Upgrades

Formation size can be upgraded in the Retinues troop editor (Clan → Troops). E.g. Levy Spearman: 20 → 35 → 50.

---

## 3. Formation Health Storage

### 3.1 Design: Custom Formation Index

**Key:** `(PartyBase, CharacterObject, int formationId)`  
**Value:** `float effectiveCount`

- `formationId` is a stable, unique identifier per formation within `(party, troop type)`.
- New formations get `formationId = GetNextFormationId(party, character)`.
- When a formation is removed, we delete that key only; no reindexing.

### 3.2 FormationId Assignment

- Per `(PartyBase, CharacterObject)`: `formationId` = 0, 1, 2, …
- New formations: `formationId = max(existingIds) + 1`.
- When a formation is removed, its id is not reused; gaps are allowed.
- Stored in `CampaignBehavior` or `SaveableCampaignBehavior` for persistence.

### 3.3 GetNextFormationId

```csharp
int GetNextFormationId(PartyBase party, CharacterObject character)
{
    var keys = GetAllFormationKeys(party, character);
    return keys.Count == 0 ? 0 : keys.Max(k => k.formationId) + 1;
}
```

### 3.4 Save/Load

Storage must be serializable. `(PartyBase, CharacterObject, formationId)` → `effectiveCount` stored in a saveable structure (e.g. `Dictionary` with `SaveableField`).

---

## 4. Casualty Flow

### 4.1 Agent → Formation Mapping

At spawn, record for each agent:

```
Agent → (PartyBase, CharacterObject, int formationId)
```

### 4.2 On Agent Death (Real-Time)

Use `OnAgentRemoved` or equivalent:

1. Look up `(party, char, formationId) = agentMap[agent]`.
2. `effectiveCount = storage[(party, char, formationId)]`.
3. `effectiveCount -= 1`.
4. If `effectiveCount < 0.5`:
   - `roster.AddToCounts(char, -1)`
   - Delete `storage[(party, char, formationId)]`
   - Remove agent from map (no index shift needed for other agents)
5. Remove agent from map (whether or not formation was removed).

### 4.3 Sync Rule

When `effectiveCount < 0.5`, treat the formation as dead:

- Remove 1 from roster.
- Delete the storage entry.
- No reindexing; other formations keep their `formationId`s.

---

## 5. Recruitment & Transfer

### 5.1 Recruitment

```csharp
// When roster.AddToCounts(character, 1) is called:
formationId = GetNextFormationId(party, character);
formationSize = GetFormationSize(character);  // from Retinues/our config
storage[(party, character, formationId)] = formationSize;
```

### 5.2 Transfer (Party Screen)

When troops move between parties:

- Copy storage entries for the transferred formations.
- Remove from source party.
- Add to destination party.
- `formationId` can be reused per destination (new party = new id space) or kept unique globally.

### 5.3 Upgrade

When a troop upgrades (e.g. Levy Spearman → Veteran Spearman):

- Migrate `effectiveCount` to the new character type.
- Remove old formation entry.
- Add new formation entry.

---

## 6. Party Screen UI

### 6.1 Collapsed View (Default)

- **Levy Spearman x50** (avg 42.5/50)
- One row per troop type.
- Average health per formation: `Sum(effectiveCount) / formationSize / count`.

### 6.2 Expanded View (Dropdown)

Same style as the upgrade dropdown (e.g. chevron/arrow):

- Formation 0: 50/50
- Formation 1: 47/50
- Formation 2: 45/50
- …

### 6.3 Implementation

- **UIExtenderEx** to patch the party screen.
- Custom ViewModel or patch existing one to expose `AverageHealth`, `FormationSize`, `IndividualFormations`.
- Expand trigger: same chevron/arrow as upgrade UI.

---

## 7. Heroes & Companions

### 7.1 Heroes

- Stackable in the party UI (no separate rows per hero).
- Formation size: 1 (hero = 1 agent).

### 7.2 Companions

- Act as **bodyguard** for the hero.
- Formation size: 1.
- Placed in the hero’s formation (General/Bodyguard).

---

## 8. Battle Component

### 8.1 Spawn Logic

- Each formation in storage spawns `floor(effectiveCount)` agents.
- Each agent is assigned to a Formation (0–19).
- Formation index mapping: our formations (e.g. by troop type) → FormationIndex 10–19.
- Record `Agent → (party, character, formationId)` for each spawned agent.

### 8.2 Formation Assignment

- Map troop types to FormationIndex 0–19.
- Use `team.FormationsIncludingEmpty[index]` or `team.FormationsIncludingSpecialAndEmpty[index]` for indices 10–19.
- Ensure `formationId` is passed through so we can map back on death.

### 8.3 Reinforcements

- Total War style: one formation at a time.
- Use Bannerlord’s reinforcement system.
- Each wave = one formation from our storage.

---

## 9. Battle UI

### 9.1 20 Formation Slots

- New UI for 20 formations (reuse Bannerlord components where possible).
- Same interaction pattern as the upgrade dropdown for the expand trigger.

### 9.2 Deployment Screen

- Extend or replace to show 20 formation slots.
- Ensure `OrderOfBattleCampaignBehavior` has 20 entries when the UI is expanded.

---

## 10. Harmony Patches (20 Formations)

### 10.1 Patch List

| Target | File | Change |
|--------|------|--------|
| Team.Initialize | TaleWorlds.MountAndBlade/Team.cs | Create 20 formations; add all to FormationsIncludingEmpty |
| GeneralsAndCaptainsAssignmentLogic | GeneralsAndCaptainsAssignmentLogic.cs:133 | `numRegularFormations = 20` |
| TacticPerimeterDefense | TacticPerimeterDefense.cs:213 | `8 - num` → `20 - num` |
| SandboxBattleSpawnModel | SandBox.GameComponents/SandboxBattleSpawnModel.cs | `FormationOrderOfBattleConfiguration[8]` → `[20]`; loops `i < 8` → `i < 20` |
| DefaultDeploymentPlan | DefaultDeploymentPlan.cs | `num = 11` → `20`; extend `_formationPlans`, `_formationFootTroopCounts`, `_formationMountedTroopCounts`; `IsPlanSuitableForFormations` length 20 |
| MissionReinforcementsHelper | MissionReinforcementsHelper.cs:184 | `[8]` → `[20]`; loop `8` → `20` |

### 10.2 Native Structure (Team)

```csharp
// Team.Initialize() - PATCH TO:
FormationsIncludingSpecialAndEmpty = new MBList<Formation>(20);
FormationsIncludingEmpty = new MBList<Formation>(20);
for (int i = 0; i < 20; i++)
{
    Formation formation = new Formation(this, i);
    FormationsIncludingSpecialAndEmpty.Add(formation);
    FormationsIncludingEmpty.Add(formation);  // all 20, not just i < 8
    formation.AI.OnActiveBehaviorChanged += FormationAI_OnActiveBehaviorChanged;
}
```

### 10.3 Accessing Formations 10–19

- `team.FormationsIncludingEmpty[index]` or `team.FormationsIncludingSpecialAndEmpty[index]`
- `GetFormation(FormationClass)` only works for 0–10.
- For 10–19, use direct indexing.

---

## 11. Risky Areas (Resolved)

| Area | Status | Notes |
|------|--------|------|
| FormationQuerySystem | ✅ Safe | Uses agent composition, not FormationIndex |
| FormationIndex 10–19 | ✅ Acceptable | GetName() works; TeamAI treats as regular |
| DefaultDeploymentPlan | ⚠️ Patch | Extend arrays to 20 |
| OrderOfBattleCampaignBehavior | ✅ Flexible | List-based; no hardcoded size |
| MissionReinforcementsHelper | ⚠️ Patch | Extend to 20 |
| Settlement Combat | ✅ No change | Uses vanilla 8 formations |

---

## 12. Implementation Phases

### Phase 1: Foundation
- Retinues fork + formation size field
- FormationHealthStorage: `(PartyBase, CharacterObject, formationId)` → `effectiveCount`
- CampaignBehavior for storage + save/load
- GetNextFormationId, recruitment hook

### Phase 2: Casualties
- Agent → (party, char, formationId) mapping at spawn
- OnAgentRemoved handler
- Sync when effectiveCount < 0.5

### Phase 3: Party Screen
- Average health display
- Expandable dropdown for individual formations
- UIExtenderEx patches

### Phase 4: Battle (20 Formations)
- Team.Initialize patch
- Other Harmony patches (GeneralsAndCaptainsAssignmentLogic, etc.)
- Deployment plan extension

### Phase 5: Spawn & Assignment
- Spawn logic: formation size → agent count
- Formation assignment to 10–19
- Agent mapping for death handling

### Phase 6: Battle UI
- 20-formation UI
- Deployment screen extension

### Phase 7: Reinforcements
- One formation per wave
- Integration with existing reinforcement system

---

## 13. Data Structures Summary

```
FormationSizeStorage: CharacterObject → int (formation size, e.g. 50)
FormationHealthStorage: (PartyBase, CharacterObject, formationId) → float effectiveCount
AgentFormationMap: Agent → (PartyBase, CharacterObject, formationId)  [runtime only, cleared on battle end]
NextFormationId: (PartyBase, CharacterObject) → int  [or derived from max existing formationId]
```

---

## 14. Dependencies

- Bannerlord.Harmony
- Bannerlord.UIExtenderEx
- MCM (Mod Configuration Menu)
- Retinues (forked)
- Native, SandBox, Sandbox, StoryMode, CustomBattle

---

## 15. References

- Retinues source: `/workspace/Retinues-mod/`
- Decompiled DLLs: `/workspace/decompiled/`
- Formation patching details: `DESIGN_FORMATION_PATCHING.md`
- FormationClass: TaleWorlds.Core
- Team, Formation: TaleWorlds.MountAndBlade
