using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.CampaignBehaviors;

public class NavalForceStartNavalMissionCampaignBehavior : CampaignBehaviorBase
{
	private static bool _forceStartNavalMission;

	private const string DefaultTestSceneName = "battle_terrain_opensea_northern";

	private static string _sceneName;

	private static int _enemyMeleeTroopCount;

	private static int _enemyRangedTroopCount;

	private static int _playerMeleeTroopCount;

	private static int _playerRangedTroopCount;

	private static bool _maximizeTroopCounts;

	private static MBList<string> _defaultShipHullIds;

	private static MBList<string>[] _shipHullIds;

	private PartyBase _enemyParty;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGameMenus(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HealPartiesInPlayerEncounterCheat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartNavalMissionFromCheats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartNavalMissionWithHandlingCheat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupTeamForEncounterCheat(TeamSideEnum teamSide, PartyBase teamParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddTroopsToTeamPartyForEncounterCheat(TeamSideEnum teamSide, PartyBase teamParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MBList<Ship> AddShipsToTeamPartyForEncounterCheat(TeamSideEnum teamSide, PartyBase teamParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetMaximumTroopCountForShipList(MBReadOnlyList<Ship> shipList, out int maxMeleeTroopCount, out int maxRangedTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartNavalBattle(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Ship CreateShip(string shipHullId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MBList<Ship> GetDefaultShipSet(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetMissionSettings()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ResetMissionSettings()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ResetShipHullsToDefault()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("get_mission_settings", "naval")]
	public static string GetMissionSettings(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("reset_mission_settings", "naval")]
	public static string ResetMissionSettings(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_mission_scene", "naval")]
	public static string SetMissionScene(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_mission_ships", "naval")]
	public static string SetMissionShips(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_maximize_troop_counts", "naval")]
	public static string SetMaximizeTroopCounts(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_mission_troop_counts", "naval")]
	public static string SetMissionTroopCounts(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("start_mission", "naval")]
	public static string StartMission(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalForceStartNavalMissionCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NavalForceStartNavalMissionCampaignBehavior()
	{
		throw null;
	}
}
