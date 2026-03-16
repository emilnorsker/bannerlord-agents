using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public struct WorldFrame
{
	public Mat3 Rotation;

	public WorldPosition Origin;

	public static readonly WorldFrame Invalid;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldFrame(Mat3 rotation, WorldPosition origin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame ToGroundMatrixFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame ToGroundMatrixFrameMT()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame ToNavMeshMatrixFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static WorldFrame()
	{
		throw null;
	}
}
