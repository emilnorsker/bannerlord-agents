using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

public class MissionDeploymentBoundaryMarker : MissionView
{
	public const string AttackerStaticDeploymentBoundaryName = "walk_area";

	public const string DefenderStaticDeploymentBoundaryName = "deployment_castle_boundary";

	public readonly float MarkerInterval;

	protected readonly Dictionary<string, List<GameEntity>>[] _boundaryMarkersPerSide;

	protected readonly string _prefabName;

	protected GameEntity _cachedEntity;

	protected bool _boundaryMarkersRemoved;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionDeploymentBoundaryMarker(string prefabName, float markerInterval = 2f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentPlanMade(Team team, bool isFirstPlan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBoundaryMarkerForSide(BattleSideEnum side, KeyValuePair<string, ICollection<Vec2>> boundary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryRemoveBoundaryMarkers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveBoundaryMarker(string boundaryName, BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void MarkLine(Vec3 startPoint, Vec3 endPoint, List<GameEntity> boundary, Banner banner = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity MakeEntity(Banner banner = null)
	{
		throw null;
	}
}
