using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public struct MissionObjectId
{
	public readonly int Id;

	public readonly bool CreatedAtRuntime;

	public static readonly MissionObjectId Invalid;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionObjectId(int id, bool createdAtRuntime = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(MissionObjectId a, MissionObjectId b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(MissionObjectId a, MissionObjectId b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionObjectId()
	{
		throw null;
	}
}
