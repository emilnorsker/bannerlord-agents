using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

internal struct NavalTroopAssignment
{
	public readonly IAgentOriginBase Origin;

	public readonly Agent Agent;

	public bool HasAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Priority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NavalTroopAssignment(IAgentOriginBase origin, Agent agent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(in NavalTroopAssignment other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalTroopAssignment Invalid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NavalTroopAssignment Create(IAgentOriginBase origin, Agent agent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetPriority(IAgentOriginBase origin, Agent agent = null)
	{
		throw null;
	}
}
