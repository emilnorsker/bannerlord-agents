using System.Runtime.CompilerServices;
using NavalDLC.DWA;
using TaleWorlds.Library;

public static class DWAHelpers
{
	private const float Epsilon = 1E-06f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AgentToAgentSignedClearance(in Vec2 center1, in Vec2 dir1, in Vec2 halfSize1, in Vec2 center2, in Vec2 dir2, in Vec2 halfSize2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AgentToConvexPolySignedClearance(in Vec2 center, in Vec2 dir, in Vec2 half, Vec2[] verts, int count, out bool overlap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckAxisSeparationBetweenOBBs(in Vec2 axis, in Vec2 centerDiff, in Vec2 side1, in Vec2 fwd1, in Vec2 half1, in Vec2 side2, in Vec2 fwd2, in Vec2 half2, ref bool separated, ref float maxGap, ref float minOverlap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckAxisSeparationBetweenOBBAndPoly(in Vec2 axis, in Vec2 center, in Vec2 side, in Vec2 fwd, in Vec2 half, Vec2[] verts, int count, ref bool separated, ref float maxGap, ref float minOverlap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	private static float ProjectOBBOnAxis(in Vec2 axis, in Vec2 side, in Vec2 fwd, in Vec2 half)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	private static void ProjectPolyOnAxis(in Vec2 axis, Vec2[] verts, int vertexCount, out float dMin, out float dMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	private static void OBBAxes(in Vec2 forward, out Vec2 xSide, out Vec2 yFwd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	internal static void ReadStaticObstacle(DWAObstacleVertex obstacleVertex, Vec2[] obsVertices, out int obsVertexCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public static float GateNear(float distance, float gateLength, float gateStart = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public static float GateFar(float distance, float gateLength, float gateStart = 0f)
	{
		throw null;
	}
}
