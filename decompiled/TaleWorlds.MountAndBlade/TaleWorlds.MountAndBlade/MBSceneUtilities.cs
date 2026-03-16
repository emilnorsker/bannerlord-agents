using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MBSceneUtilities
{
	public const int MaxNumberOfSpawnPaths = 32;

	public const string SpawnPathPrefix = "spawn_path_";

	public const string SoftBorderVertexTag = "walk_area_vertex";

	public const string HardBorderVertexTag = "walk_area_vertex_hard";

	public const string SoftBoundaryName = "walk_area";

	public const string SceneBoundaryName = "scene_boundary";

	public const float SceneToHardBoundaryMargin = 100f;

	public const string DefenderDeploymentReferencePositionTag = "defender_infantry";

	public const string AttackerDeploymentReferencePositionTag = "attacker_infantry";

	private const string DeploymentBoundaryTag = "deployment_castle_boundary";

	private const string DeploymentBoundaryTagExpression = "deployment_castle_boundary(_\\d+)*";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<Path> GetAllSpawnPaths(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<Vec2> GetSoftBoundaryPoints(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<Vec2> GetHardBoundaryPoints(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<Vec2> GetSceneLimitPoints(Scene scene, out Vec2 sceneLimitMin, out Vec2 sceneLimitMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<(string tag, MBList<Vec2> boundaryPoints, bool insideAllowance)> GetDeploymentBoundaries(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetAxisAlignedBoundaryRectangle(List<Vec2> boundaryPoints, out Vec2 boundsMin, out Vec2 boundsMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FindConvexHull(ref MBList<Vec2> boundary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RadialSortBoundary(ref MBList<Vec2> boundary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RadialSortBoundary(ref MBList<Vec3> boundary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsConvexAndRadiallySorted(MBList<Vec2> boundary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPointInsideBoundaries(in Vec2 point, MBList<Vec2> boundaries, float acceptanceThreshold = 0.05f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestPointToBoundaries(in Vec2 position, MBList<Vec2> boundaries, out Vec2 closestPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindClosestPointToBoundariesReturnDistanceSquared(in Vec2 position, MBList<Vec2> boundaries, out Vec2 closestPoint, out bool isPositionInsideBoundaries)
	{
		throw null;
	}
}
