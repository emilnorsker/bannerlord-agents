using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.View.MissionViews.Order;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

public class DeploymentMissionView : MissionView
{
	protected OrderTroopPlacer _orderTroopPlacer;

	protected MissionDeploymentBoundaryMarker _deploymentBoundaryMarkerHandler;

	protected MissionEntitySelectionUIHandler _entitySelectionHandler;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentPlanMade(Team team, bool isFirstPlan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeploymentMissionView()
	{
		throw null;
	}
}
