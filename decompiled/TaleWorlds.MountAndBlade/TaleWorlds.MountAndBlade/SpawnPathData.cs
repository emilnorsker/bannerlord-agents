using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct SpawnPathData
{
	public enum SnapMethod
	{
		DontSnap,
		SnapToTerrain,
		SnapToWaterLevel
	}

	public const float SpawnPathEpsilon = 0.01f;

	public static readonly SpawnPathData Invalid;

	public readonly Scene Scene;

	public readonly Path Path;

	public readonly bool IsInverted;

	public readonly float PivotRatio;

	public readonly SnapMethod SnapType;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnPathData Invert()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float ClampPathOffset(float pathOffsetRatio)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetOffsetOverflow(float pathOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSpawnPathFrameFacingTarget(float baseOffset, float targetOffset, bool useTangentDirection, out Vec2 spawnPathPosition, out Vec2 spawnPathDirection, bool decideDirectionDynamically = false, float dynamicDistancePercentage = 0.2f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSpawnPathFrameFacingPivot(float pathOffset, bool useTangentDirection, out Vec2 spawnPathPosition, out Vec2 spawnPathDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSpawnPathFrameFacingTangentDirection(float baseOffset, int tangentDirection, out Vec2 spawnPathPosition, out Vec2 spawnPathDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SpawnPathData(Scene scene = null, Path path = null, float pivotRatio = 0f, bool isInverted = false, SnapMethod snapType = SnapMethod.DontSnap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetSpawnFrame(float pathOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SpawnPathData Create(Scene scene, Path path, float pivotRatio = 0f, bool isInverted = false, SnapMethod snapType = SnapMethod.DontSnap)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SpawnPathData()
	{
		throw null;
	}
}
