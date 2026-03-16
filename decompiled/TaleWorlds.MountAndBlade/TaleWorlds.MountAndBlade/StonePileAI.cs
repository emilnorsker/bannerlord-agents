using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class StonePileAI : UsableMachineAIBase
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public StonePileAI(StonePile stonePile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent GetSuitableAgentForStandingPoint(StonePile usableMachine, StandingPoint standingPoint, List<Agent> agents, List<Agent> usedAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent GetSuitableAgentForStandingPoint(StonePile stonePile, StandingPoint standingPoint, List<(Agent, float)> agents, List<Agent> usedAgents, float weight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAgentAssignable(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleAgentStopUsingStandingPoint(Agent agent, StandingPoint standingPoint)
	{
		throw null;
	}
}
