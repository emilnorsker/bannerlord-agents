using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public abstract class UsableMachineAIBase
{
	protected readonly UsableMachine UsableMachine;

	private GameEntity _lastActiveWaitStandingPoint;

	public virtual bool HasActionCompleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual MovementOrder NextOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected UsableMachineAIBase(UsableMachine usableMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual Agent.AIScriptedFrameFlags GetScriptedFrameFlags(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(Agent agentToCompareTo, Formation formationToCompareTo, Team potentialUsersTeam, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTick(Agent agentToCompareTo, Formation formationToCompareTo, Team potentialUsersTeam, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void TickForDebug()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent GetSuitableAgentForStandingPoint(UsableMachine usableMachine, StandingPoint standingPoint, IEnumerable<Agent> agents, List<Agent> usedAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent GetSuitableAgentForStandingPoint(UsableMachine usableMachine, StandingPoint standingPoint, List<(Agent, float)> agents, List<Agent> usedAgents, float weight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void TeleportUserAgentsToMachine(List<Agent> agentList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopUsingStandingPoint(StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected Agent.StopUsingGameObjectFlags GetStopUsingStandingPointFlags(Agent agent, StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void HandleAgentStopUsingStandingPoint(Agent agent, StandingPoint standingPoint)
	{
		throw null;
	}
}
