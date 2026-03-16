using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.ComponentInterfaces;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.GameComponents;

public class NavalDLCShipDeploymentModel : ShipDeploymentModel
{
	private const int BaseShipDeploymentLimit = 3;

	private const int MaxShipDeploymentLimit = 8;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetShipDeploymentLimit(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetMapEventPartiesOfPlayerTeams(MBReadOnlyList<MapEventParty> playerSideMapEventParties, bool isPlayerSergeant, out MapEventParty playerMapEventParty, out MBList<MapEventParty> playerTeamMapEventParties, out MBList<MapEventParty> playerAllyTeamMapEventParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetShipDeploymentLimitsOfPlayerTeams(MBList<MapEventParty> playerTeamMapEventParties, MBList<MapEventParty> playerAllyTeamMapEventParties, out NavalShipDeploymentLimit playerTeamDeploymentLimit, out NavalShipDeploymentLimit playerAllyTeamDeploymentLimit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override NavalShipDeploymentLimit GetTeamShipDeploymentLimit(MBReadOnlyList<MapEventParty> teamMapEventParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Ship GetSuitablePlayerShip(MapEventParty playerMapEventParty, MBList<MapEventParty> playerTeamMapEventParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void FillShipsOfTeamParties(MBReadOnlyList<MapEventParty> teamMapEventParties, NavalShipDeploymentLimit shipDeploymentLimit, MBList<IShipOrigin> teamShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetOrderedCaptainsForPlayerTeamShips(MBReadOnlyList<MapEventParty> playerTeamMapEventParties, MBReadOnlyList<IShipOrigin> playerTeamShips, out List<string> playerTeamCaptainsByPriority)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int[] GetMaximumDeployableTroopCountPerTeam(MBList<IShipOrigin> playerTeamShips, MBList<IShipOrigin> playerAllyTeamShips, MBList<IShipOrigin> enemyTeamShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetNavalPartyPriority(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CanShipsBeFilled(int troopCount, float fillPercentage, MBReadOnlyList<(Ship ship, MapEventParty party, bool fixedShip)> ships, out int firstUnfilledIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsSkeletalCrewLimitationSatisfied(MBList<(Ship ship, MapEventParty party, bool fixedShip)> ships, int troopCount, int shipsToProcessCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool FindBestSwapShipBelowSkeletalCrewLimit(MBList<(Ship ship, MapEventParty party, bool fixedShip)> ships, (Ship ship, MapEventParty party, bool fixedShip) shipTupleToBeSwapped, int startIndex, bool checkTeamMatch, out int swapIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCShipDeploymentModel()
	{
		throw null;
	}
}
