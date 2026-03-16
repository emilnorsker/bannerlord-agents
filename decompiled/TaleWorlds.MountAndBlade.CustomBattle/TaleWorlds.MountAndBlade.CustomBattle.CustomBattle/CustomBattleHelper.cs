using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.CustomBattle.CustomBattle;

public static class CustomBattleHelper
{
	public const string DefaultBattleGameTypeStringId = "Battle";

	public const string DefaultSiegeGameTypeStringId = "Siege";

	public const string DefaultVillageGameTypeStringId = "Village";

	private const string EmpireInfantryTroop = "imperial_veteran_infantryman";

	private const string EmpireRangedTroop = "imperial_archer";

	private const string EmpireCavalryTroop = "imperial_heavy_horseman";

	private const string EmpireHorseArcherTroop = "bucellarii";

	private const string SturgiaInfantryTroop = "sturgian_spearman";

	private const string SturgiaRangedTroop = "sturgian_archer";

	private const string SturgiaCavalryTroop = "sturgian_hardened_brigand";

	private const string AseraiInfantryTroop = "aserai_infantry";

	private const string AseraiRangedTroop = "aserai_archer";

	private const string AseraiCavalryTroop = "aserai_mameluke_cavalry";

	private const string AseraiHorseArcherTroop = "aserai_faris";

	private const string VlandiaInfantryTroop = "vlandian_swordsman";

	private const string VlandiaRangedTroop = "vlandian_hardened_crossbowman";

	private const string VlandiaCavalryTroop = "vlandian_knight";

	private const string BattaniaInfantryTroop = "battanian_picked_warrior";

	private const string BattaniaRangedTroop = "battanian_hero";

	private const string BattaniaCavalryTroop = "battanian_scout";

	private const string KhuzaitInfantryTroop = "khuzait_spear_infantry";

	private const string KhuzaitRangedTroop = "khuzait_archer";

	private const string KhuzaitCavalryTroop = "khuzait_lancer";

	private const string KhuzaitHorseArcherTroop = "khuzait_horse_archer";

	private const string NordInfantryTroop = "nord_spear_warrior";

	private const string NordRangedTroop = "nord_marksman";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetIndexFromGameTypeStringId(string gameTypeStringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartGame(CustomBattleData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int[] GetTroopCounts(int armySize, CustomBattleCompositionData compositionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float[] GetWallHitpointPercentages(int breachedWallCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SiegeEngineType GetSiegeWeaponType(SiegeEngineType siegeWeaponType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CustomBattleData PrepareBattleData(BasicCharacterObject playerCharacter, BasicCharacterObject playerSideGeneralCharacter, CustomBattleCombatant playerParty, CustomBattleCombatant enemyParty, CustomBattlePlayerSide playerSide, CustomBattlePlayerType battlePlayerType, string gameTypeStringId, string scene, string season, float timeOfDay, List<MissionSiegeWeapon> attackerMachines, List<MissionSiegeWeapon> defenderMachines, float[] wallHitPointsPercentages, int sceneLevel, bool isSallyOut)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CustomBattleCombatant[] GetCustomBattleParties(BasicCharacterObject playerCharacter, BasicCharacterObject playerSideGeneralCharacter, BasicCharacterObject enemyCharacter, BasicCultureObject playerFaction, int[] playerNumbers, List<BasicCharacterObject>[] playerTroopSelections, BasicCultureObject enemyFaction, int[] enemyNumbers, List<BasicCharacterObject>[] enemyTroopSelections, bool isPlayerAttacker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PopulateListsWithDefaults(ref CustomBattleCombatant customBattleParties, int[] numbers, List<BasicCharacterObject>[] troopList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AssertMissingTroopsForDebug()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BasicCharacterObject GetDefaultTroopOfFormationForFaction(BasicCultureObject culture, FormationClass formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static BasicCharacterObject GetTroopFromId(string troopId)
	{
		throw null;
	}
}
