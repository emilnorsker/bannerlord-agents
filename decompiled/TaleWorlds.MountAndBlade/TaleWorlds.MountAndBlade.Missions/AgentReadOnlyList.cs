using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Missions;

public class AgentReadOnlyList : MBReadOnlyList<Agent>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentReadOnlyList(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentReadOnlyList(IEnumerable<Agent> collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentReadOnlyList(List<Agent> collection)
	{
		throw null;
	}
}
