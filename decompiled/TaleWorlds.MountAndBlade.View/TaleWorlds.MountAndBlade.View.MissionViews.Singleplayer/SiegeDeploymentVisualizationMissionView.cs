using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

public class SiegeDeploymentVisualizationMissionView : MissionView
{
	public enum DeploymentVisualizationPreference
	{
		ShowUndeployed = 1,
		Line = 2,
		Arc = 4,
		Banner = 8,
		Path = 16,
		Ghost = 32,
		Contour = 64,
		LiftLadders = 128,
		Light = 256,
		AllEnabled = 1023
	}

	private static int deploymentVisualizerSelector;

	private List<DeploymentPoint> _deploymentPoints;

	private bool _deploymentPointsVisible;

	private Dictionary<DeploymentPoint, List<Vec3>> _deploymentArcs;

	private Dictionary<DeploymentPoint, (GameEntity, GameEntity)> _deploymentBanners;

	private Dictionary<DeploymentPoint, GameEntity> _deploymentLights;

	private const uint EntityHighlightColor = 4289622555u;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryRemoveDeploymentVisibilities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveDeploymentVisibility(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetSelectorStateDescription()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("set_deployment_visualization_selector", "mission")]
	public static string SetDeploymentVisualizationSelector(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDeploymentStateChanged(DeploymentPoint deploymentPoint, SynchedMissionObject targetObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDeploymentPointStateSet(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowLineFromDeploymentPointToTarget(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Vec3> CreateArcPoints(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowArcFromDeploymentPointToTarget(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowDeploymentBanners(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HideDeploymentBanners(DeploymentPoint deploymentPoint, bool isRemoving = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (GameEntity, GameEntity) CreateBanners(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity CreateBannerEntity(bool isTargetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowPath(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGhostVisibility(DeploymentPoint deploymentPoint, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDeploymentTargetContourState(DeploymentPoint deploymentPoint, bool isHighlighted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetLaddersUpState(DeploymentPoint deploymentPoint, bool isRaised)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetLightState(DeploymentPoint deploymentPoint, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateLight(DeploymentPoint deploymentPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeDeploymentVisualizationMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SiegeDeploymentVisualizationMissionView()
	{
		throw null;
	}
}
