using System.Runtime.CompilerServices;
using SandBox.Missions.AgentBehaviors;
using SandBox.Objects.Usables;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.Source.Missions.AgentBehaviors;

public class BoardGameAgentBehavior : AgentBehavior
{
	private enum State
	{
		Idle,
		MovingToChair,
		Finish
	}

	private const int FinishDelayAsSeconds = 3;

	private Chair _chair;

	private State _state;

	private Timer _waitTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoardGameAgentBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetDebugInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAvailability(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveBoardGameBehaviorInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddTargetChair(Agent ownerAgent, Chair chair)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveBoardGameBehaviorOfAgent(Agent ownerAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAgentMovingToChair(Agent ownerAgent)
	{
		throw null;
	}
}
