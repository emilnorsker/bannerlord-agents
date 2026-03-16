using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Missions;

public class AgentList : AgentReadOnlyList
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentList(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentList(IEnumerable<Agent> collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentList(List<Agent> collection)
	{
		throw null;
	}
}
