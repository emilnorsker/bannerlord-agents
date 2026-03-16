using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

namespace NavalDLC.View.MissionViews;

public class NavalMissionDeploymentBoundaryMarker : MissionDeploymentBoundaryMarker
{
	private readonly string _largePrefabName;

	private GameEntity _cachedLargeEntity;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionDeploymentBoundaryMarker(string smallPrefabName, string largePrefabName, float markerInterval = 20f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void MarkLine(Vec3 startPoint, Vec3 endPoint, List<GameEntity> boundary, Banner banner = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity CreateBoundaryEntity(bool isLarge)
	{
		throw null;
	}
}
