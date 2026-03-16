using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Deployment;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class DefaultNavalMissionLogic : MissionLogic, IAgentStateDecider, IMissionBehavior
{
	private NavalShipsLogic _shipsLogic;

	private NavalMissionDeploymentPlanningLogic _deploymentPlan;

	private readonly MBList<IShipOrigin> _playerTeamShips;

	private readonly MBList<IShipOrigin> _playerAllyTeamShips;

	private readonly MBList<IShipOrigin> _enemyTeamShips;

	private readonly NavalShipDeploymentLimit _playerTeamShipDeploymentLimit;

	private readonly NavalShipDeploymentLimit _playerAllyTeamShipDeploymentLimit;

	private readonly NavalShipDeploymentLimit _enemyTeamShipDeploymentLimit;

	public MBReadOnlyList<IShipOrigin> PlayerShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<IShipOrigin> PlayerAllyShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<IShipOrigin> PlayerEnemyShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void DeployBattleSide(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultNavalMissionLogic(MBList<IShipOrigin> playerShips, MBList<IShipOrigin> playerAllyShips, MBList<IShipOrigin> enemyShips, NavalShipDeploymentLimit playerTeamShipDeploymentLimit, NavalShipDeploymentLimit playerAllyTeamShipDeploymentLimit, NavalShipDeploymentLimit enemyTeamShipDeploymentLimit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeShipAssignments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<(FormationClass formationIndex, IShipOrigin ship)> AssignShipsToFormations(MBReadOnlyList<IShipOrigin> ships, int shipCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeDeploymentPlansForSide(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSceneWindDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSceneWaterStrength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTeamShipsToDeploymentPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentState GetAgentState(Agent affectedAgent, float deathProbability, out bool usedSurgery)
	{
		throw null;
	}
}
