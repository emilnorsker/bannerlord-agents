using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.CustomBattle.CustomBattle;

public static class NavalCustomBattleHelper
{
	private const string EmpireInfantryTroop = "imperial_veteran_infantryman";

	private const string EmpireRangedTroop = "imperial_archer";

	private const string SturgiaInfantryTroop = "sturgian_spearman";

	private const string SturgiaRangedTroop = "sturgian_archer";

	private const string AseraiInfantryTroop = "aserai_infantry";

	private const string AseraiRangedTroop = "aserai_archer";

	private const string VlandiaInfantryTroop = "vlandian_swordsman";

	private const string VlandiaRangedTroop = "vlandian_hardened_crossbowman";

	private const string BattaniaInfantryTroop = "battanian_picked_warrior";

	private const string BattaniaRangedTroop = "battanian_hero";

	private const string KhuzaitInfantryTroop = "khuzait_spear_infantry";

	private const string KhuzaitRangedTroop = "khuzait_archer";

	private const string NordInfantryTroop = "nord_spear_warrior";

	private const string NordRangedTroop = "nord_marksman";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartGame(NavalCustomBattleData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalCustomBattleData PrepareBattleData(BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, List<IShipOrigin> playerShips, CustomBattleCombatant enemyParty, List<IShipOrigin> enemyShips, string scene, string season, float timeOfDay, float windStrength, NavalCustomBattleWindConfig.Direction windDirection, TerrainType terrain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CustomBattleCombatant[] GetCustomBattleParties(BasicCharacterObject playerCharacter, BasicCharacterObject enemyCharacter, List<BasicCharacterObject> remainingHeroes, BasicCultureObject playerFaction, int[] playerNumbers, List<BasicCharacterObject>[] playerTroopSelections, int playerShipCount, BasicCultureObject enemyFaction, int[] enemyNumbers, List<BasicCharacterObject>[] enemyTroopSelections, int enemyShipCount, bool isPlayerAttacker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<IShipOrigin>[] GetCustomBattleShipLists(List<IShipOrigin> playerShips, List<IShipOrigin> enemyShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PopulateListsWithDefaults(ref CustomBattleCombatant customBattleParties, int[] numbers, List<BasicCharacterObject>[] troopList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int[] GetTroopCounts(int armySize, int shipCount, NavalCustomBattleCompositionData compositionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static BasicCharacterObject GetTroopFromId(string troopId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BasicCharacterObject GetDefaultTroopOfFormationForFaction(BasicCultureObject culture, FormationClass formation)
	{
		throw null;
	}
}
