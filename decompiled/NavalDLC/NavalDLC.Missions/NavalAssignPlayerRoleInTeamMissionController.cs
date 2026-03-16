using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions;

public class NavalAssignPlayerRoleInTeamMissionController : AssignPlayerRoleInTeamMissionController
{
	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private ShipAgentSpawnLogic _shipAgentSpawnLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalAssignPlayerRoleInTeamMissionController(bool isPlayerGeneral, bool isPlayerSergeant, bool isPlayerInArmy, List<string> charactersInPlayerSideByPriority = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerChoiceMade(int chosenIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerTeamDeployed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AssignSergeant(Formation formationToLead, Agent sergeant)
	{
		throw null;
	}
}
