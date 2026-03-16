using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct PathFaceRecord
{
	public int FaceIndex;

	public int FaceGroupIndex;

	public int FaceIslandIndex;

	public static readonly PathFaceRecord NullFaceRecord;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord(int index, int groupIndex, int islandIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PathFaceRecord()
	{
		throw null;
	}
}
