# Formation Patching Design: 20 Formations + AI Support

> **See `DESIGN_FORMATION_SCALING_MOD.md` for the full mod design.** This document focuses on the 20-formation patching details.

## Goal
Extend Bannerlord from 8 player formations to 20 formations per side, and patch AI systems so they iterate over 0–19 instead of 0–7.

---

## Part 1: Extend Team.Formations (indices 10–19)

### Native Structure (DISCOVERED)
**Team.cs** `Initialize()` (lines 256–289):
```csharp
FormationsIncludingSpecialAndEmpty = new MBList<Formation>(10);
FormationsIncludingEmpty = new MBList<Formation>(8);
for (int i = 0; i < 10; i++)
{
    Formation formation = new Formation(this, i);
    FormationsIncludingSpecialAndEmpty.Add(formation);
    if (i < 8)
        FormationsIncludingEmpty.Add(formation);
    formation.AI.OnActiveBehaviorChanged += FormationAI_OnActiveBehaviorChanged;
}
```

**Formation constructor** (index 605–606): `Index = index; FormationIndex = (FormationClass)index;`

**GetFormation** (line 611–614): `return FormationsIncludingSpecialAndEmpty[(int)formationIndex];`

**FormationClass enum** (TaleWorlds.Core): Infantry=0, Ranged=1, Cavalry=2, HorseArcher=3, Skirmisher=4, HeavyInfantry=5, LightCavalry=6, HeavyCavalry=7, NumberOfRegularFormations=General=8, Bodyguard=9, Unset=10.

### Patch Approach
1. **Harmony Prefix** on `Team.Initialize()`: Replace the entire initialization block to create 20 formations.
2. Change: `for (int i = 0; i < 20; i++)`, add all 20 to `FormationsIncludingEmpty` (not just `i < 8`).
3. **Add** `Team.GetFormationByIndex(int index)` via Harmony patch or extension: returns `FormationsIncludingSpecialAndEmpty[index]` for indices 10–19.
4. `GetFormation(FormationClass)` stays for 0–9; indices 10–19 use `GetFormationByIndex`.

---

## Part 2: Patch AI Formation Iteration

### Systems to Patch (DISCOVERED)

| System | File | Patch |
|--------|------|-------|
| **Team.Initialize** | TaleWorlds.MountAndBlade/Team.cs | Prefix: create 20 formations, add all to FormationsIncludingEmpty |
| **GeneralsAndCaptainsAssignmentLogic** | GeneralsAndCaptainsAssignmentLogic.cs:133 | Change `numRegularFormations = 8` → `20` |
| **TacticComponent** | TacticComponent.cs | Uses `Team.FormationsIncludingEmpty` directly – **no patch needed** if Team has 20 |
| **TacticPerimeterDefense** | TacticPerimeterDefense.cs:213 | `8 - num` → `20 - num` (ranged formation count) |
| **SandboxBattleSpawnModel** | SandBox.GameComponents/SandboxBattleSpawnModel.cs | `FormationOrderOfBattleConfiguration[8]` → `[20]`, loops `for (i=0; i<8)` → `i<20` |
| **OrderOfBattleCampaignBehavior** | (CampaignSystem) | `GetFormationDataAtIndex(i, ...)` – may need to support i=10–19 |
| **CreateGeneralFormationForTeam** | GeneralsAndCaptainsAssignmentLogic.cs:207 | Uses `GetFormation(FormationClass.NumberOfRegularFormations)` = index 8 (General). General stays at 8; Bodyguard at 9. Formations 10–19 are extra player formations. |

### Key Finding: TacticComponent
`TacticComponent` uses `Team.FormationsIncludingEmpty` and `FormationsIncludingSpecialAndEmpty` – it iterates whatever is in the list. **No hardcoded 8** in the tactic logic itself. If Team has 20 formations, tactics will consider all 20.

### FormationClass Constants (TaleWorlds.Core) – DO NOT PATCH
Enum is compiled; we cannot change it. Use our constant (20) in patches instead of `NumberOfRegularFormations`.

---

## Part 2b: Accessing Formations 10–19
`Team.GetFormation(FormationClass)` only works for enum values 0–10. For indices 10–19:
- Use `team.FormationsIncludingSpecialAndEmpty[index]` (public property)
- Or `team.FormationsIncludingEmpty[index]` (after patch, will include 10–19)
- No new method needed – the list is indexable.

---

## Part 3: Agent Assignment to Formations 10–19

### Current Flow
- Agent spawn: `agent.Formation = team.GetFormation(character.DefaultFormationClass)`
- `DefaultFormationClass` is an enum (0–9)

### For Our 20 Formations
- **Player troops**: Our spawn logic assigns to formations 10–19 based on troop type.
- **AI troops**: Need to patch spawn logic so AI can assign to 10–19. Options:
  - **A)** Map troop types to 20 slots: e.g. Infantry tier 1 → 10, Infantry tier 2 → 11, etc.
  - **B)** Patch `IMissionTroopSupplier` implementations to use 20 formation indices.
  - **C)** Add FormationClass override per troop (Retinues already has FormationClassOverride) – extend to support indices 10–19.

### CharacterObject DefaultFormationClass
- Vanilla only supports 0–9. We cannot add 10–19 to the enum.
- **Solution**: Store formation index 10–19 in our custom data (Retinues troop data, or FormationHealthStorage). At spawn time, check our data first; if set, use `GetFormationByIndex(ourIndex)`; else use `GetFormation(character.DefaultFormationClass)`.

---

## Part 4: Checklist for Implementation

### Phase 1: Discovery
- [ ] Decompile TaleWorlds.MountAndBlade.dll, inspect Team class
- [ ] Decompile TaleWorlds.Core.dll, inspect FormationClass enum usage
- [ ] Decompile SandBox.dll, search for TacticsBehavior, Formation iteration
- [ ] List all methods that use `(int)FormationClass.NumberOfRegularFormations` or similar
- [ ] List all methods that use `(int)FormationClass.NumberOfAllFormations`

### Phase 2: Team Extension
- [ ] Harmony patch: Team constructor or formation initialization
- [ ] Create 10 additional Formation objects (indices 10–19)
- [ ] Add or patch GetFormationByIndex(int) for indices 10–19
- [ ] Verify FormationsIncludingEmpty returns 20

### Phase 3: AI Patches
- [ ] Patch TacticsBehavior formation iteration (or equivalent)
- [ ] Patch any FormationClassExtensions usage
- [ ] Patch deployment/order-of-battle UI formation count
- [ ] Test: AI issues orders to formations 10–19

### Phase 4: Spawn & Assignment
- [ ] Patch or extend spawn logic to assign agents to formations 10–19
- [ ] Add formation index to Retinues troop data (for player) or AI formation assignment (for AI)

---

## Part 4b: Risky Areas – Investigation Results

### 1. FormationQuerySystem ✅ LOW RISK
**Finding**: Does NOT use FormationIndex. Computes `IsInfantryFormation`, `IsRangedFormation`, etc. from **agent composition** via `GetCountOfUnitsBelongingToPhysicalClass(FormationClass.Infantry, ...)` and unit ratios. Formations 10–19 will get correct QuerySystem values as long as they have agents. **No patch needed.**

### 2. FormationIndex 10–19 ⚠️ MIXED
**Uses found:**
- `FormationIndex.GetName()` → For 10: "Unset"; for 11–19: `ToString()` → "11", "12", etc. **Works.**
- `FormationIndex.GetLocalizedName()` → Looks up `str_troop_group_name` + number. May lack localization for 11–19. **Minor.**
- `TeamAIGeneral`, `TeamAISallyOutDefender`, etc. → Check `== FormationClass.NumberOfRegularFormations` (8) or `== Bodyguard` (9). Formations 10–19 fall through else, treated as regular. **Works.**
- `Formation.FormationIndex` in `FormationPower` calc (line 1459) → Compares to Ranged/HorseArcher. Formations 10–19 would hit default. **Acceptable.**

### 3. Mission.GetFormationSpawnFrame ⚠️ REQUIRES PATCH
**Flow**: `GetFormationSpawnFrame(team, formationClass, ...)` → `_deploymentPlan.GetFormationPlan(team, formationClass)` → `_formationPlans[(int)fClass]`.

**DefaultDeploymentPlan** (line 116–118): `int num = 11; _formationPlans = new DefaultFormationDeploymentPlan[num];` — array size 11 (indices 0–10). For formation index 11+, **IndexOutOfRangeException**.

**Patch**: Change `num = 11` → `num = 20` in `DefaultDeploymentPlan` constructor. Also `_formationFootTroopCounts`, `_formationMountedTroopCounts` (same arrays). And `IsPlanSuitableForFormations` checks `troopDataPerFormationClass.Length == 11` and loop `i < 11` → extend to 20.

### 4. OrderOfBattleCampaignBehavior ✅ FLEXIBLE
**GetFormationDataAtIndex(formationIndex, ...)**: Uses `List.Count > formationIndex` and `list[formationIndex]`. Lists are dynamic; no hardcoded 8. **If** the deployment UI populates 20 entries, this works. Need to ensure initialization creates 20 default entries when we expand the UI.

### 5. Deployment Plan ✅ PATCH IDENTIFIED
**DefaultDeploymentPlan**: `_formationPlans`, `_formationFootTroopCounts`, `_formationMountedTroopCounts` — all size 11. Extend to 20. See Part 4b.3.

### 6. MissionReinforcementsHelper ⚠️ REQUIRES PATCH
**OnMissionStart** (line 184): `_reinforcementFormationsData = new ReinforcementFormationData[current.Teams.Count, 8]` — second dimension 8. Loop `for (int i = 0; i < 8; i++)`. **Patch**: Change 8 → 20.

### 7. Settlement Combat (AIInfluence) ✅ LOW RISK
**PlayerReinforcementMissionLogic**: Uses `GetFormationForCharacter(character)` → `team.GetFormation(FormationClass)` based on troop type (Infantry/Ranged/Cavalry/HorseArcher). Maps to 0–3. Does not use formations 10–19. Settlement combat spawns into vanilla 8 formations. **No change needed** unless we want settlement combat to use 20 formations (separate scope).

---

## Part 5: Risk Mitigation

| Risk | Mitigation |
|------|------------|
| Game update breaks patches | Use Harmony TargetMethod with fallback; version check |
| Formation index out of bounds | Bounds check in GetFormationByIndex; fallback to 0 |
| AI ignores formations 10–19 | Verify TacticsBehavior patch; add debug logging |
| FormationClass enum used in switch | May need to patch each switch or use FormationIndex instead |

---

## References
- FormationClass: TaleWorlds.Core
- Team, Formation: TaleWorlds.MountAndBlade
- TacticsBehavior: SandBox or TaleWorlds.MountAndBlade
- Retinues FormationClassOverride: FormationClassOverride per troop
- FormationClassExtensions: https://apidoc.bannerlord.com/v/1.2.9/class_tale_worlds_1_1_core_1_1_formation_class_extensions.html

---

## Patch Summary (20 Formations)

| Target | File | Change |
|--------|------|--------|
| Team.Initialize | Team.cs | Create 20 formations, add all to FormationsIncludingEmpty |
| GeneralsAndCaptainsAssignmentLogic | GeneralsAndCaptainsAssignmentLogic.cs:133 | numRegularFormations = 20 |
| TacticPerimeterDefense | TacticPerimeterDefense.cs:213 | 8 - num → 20 - num |
| SandboxBattleSpawnModel | SandboxBattleSpawnModel.cs | Array [8]→[20], loops i<8→i<20 |
| DefaultDeploymentPlan | DefaultDeploymentPlan.cs | num=11→20, arrays size 20, IsPlanSuitable length 20 |
| MissionReinforcementsHelper | MissionReinforcementsHelper.cs:184 | [8]→[20], loop 8→20 |
| OrderOfBattleCampaignBehavior | (Campaign) | Ensure 20 entries when UI expands (via deployment UI patch) |
