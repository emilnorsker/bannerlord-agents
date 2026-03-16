using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[MissionManager]
public static class BannerlordMissions
{
	private enum CustomBattleGameTypes
	{
		AttackerGeneral,
		DefenderGeneral,
		AttackerSergeant,
		DefenderSergeant
	}

	private const string Level1Tag = "level_1";

	private const string Level2Tag = "level_2";

	private const string Level3Tag = "level_3";

	private const string SiegeTag = "siege";

	private const string SallyOutTag = "sally";

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Type GetSiegeWeaponType(SiegeEngineType siegeWeaponType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Dictionary<Type, int> GetSiegeWeaponTypes(Dictionary<SiegeEngineType, int> values)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AtmosphereInfo CreateAtmosphereInfoForMission(string seasonId, int timeOfDay)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCustomBattleMission(string scene, BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, CustomBattleCombatant enemyParty, bool isPlayerGeneral, BasicCharacterObject playerSideGeneralCharacter, string sceneLevels = "", string seasonString = "", float timeOfDay = 6f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenSiegeMissionWithDeployment(string scene, BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, CustomBattleCombatant enemyParty, bool isPlayerGeneral, float[] wallHitPointPercentages, bool hasAnySiegeTower, List<MissionSiegeWeapon> siegeWeaponsOfAttackers, List<MissionSiegeWeapon> siegeWeaponsOfDefenders, bool isPlayerAttacker, int sceneUpgradeLevel = 0, string seasonString = "", bool isSallyOut = false, bool isReliefForceAttack = false, float timeOfDay = 6f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCustomBattleLordsHallMission(string scene, BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, CustomBattleCombatant enemyParty, BasicCharacterObject playerSideGeneralCharacter, string sceneLevels = "", int sceneUpgradeLevel = 0, string seasonString = "")
	{
		throw null;
	}
}
