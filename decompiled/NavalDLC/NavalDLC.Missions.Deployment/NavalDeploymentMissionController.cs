using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Handlers;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalDeploymentMissionController : DeploymentMissionController
{
	private ShipAgentSpawnLogic _shipAgentSpawnLogic;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private DefaultNavalMissionLogic _navalMissionLogic;

	private NavalDeploymentHandler _navalDeploymentHandler;

	public event Action PlayerShipsUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDeploymentMissionController(bool isPlayerAttacker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnAfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryAssignShipToFormation(IShipOrigin shipOrigin, Formation formation, bool updateShips = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateShips(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsShipAssignedToFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryAssignCaptainToFormation(IAgentOriginBase captainOrigin, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetTroopClassFilter(TroopTraitsMask troopClassFilter, Formation targetFormation, bool updateShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetTroopTraitsFilter(TroopTraitsMask troopTraitsFilter, Formation targetFormation, bool updateShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IReadOnlyCollection<IAgentOriginBase> GetAllPlayerTeamHeroes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<IShipOrigin> GetAllPlayerShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<Formation> GetUsableFormations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSetupTeamsOfSide(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSetupTeamsFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetupAIOfEnemySide(BattleSideEnum enemySide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetupAIOfEnemyTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void BeforeDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AfterDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnPlayerShipsUpdated()
	{
		throw null;
	}
}
