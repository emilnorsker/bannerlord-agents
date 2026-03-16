using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class StandingPointWithAgentLimit : StandingPoint
{
	private readonly List<Agent> _validAgents;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddValidAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearValidAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandingPointWithAgentLimit()
	{
		throw null;
	}
}
