using System.Runtime.CompilerServices;
using NavalDLC.Missions.Deployment;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Handlers;

public class NavalDeploymentHandler : DeploymentHandler
{
	private NavalMissionDeploymentPlanningLogic _navalDeploymentPlan;

	private NavalShipsLogic _navalShipsLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDeploymentHandler(bool isPlayerAttacker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AutoDeployTeamUsingDeploymentPlan(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ForceUpdateAllUnits()
	{
		throw null;
	}
}
