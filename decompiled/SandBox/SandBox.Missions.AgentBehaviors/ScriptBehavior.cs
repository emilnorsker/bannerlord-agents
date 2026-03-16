using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class ScriptBehavior : AgentBehavior
{
	public delegate bool SelectTargetDelegate(Agent agent, ref Agent targetAgent, ref UsableMachine targetUsableMachine, ref WorldFrame targetFrame, ref float customTargetReachedRangeThreshold, ref float customTargetReachedRotationThreshold);

	public delegate bool OnTargetReachedDelegate(Agent agent, ref Agent targetAgent, ref UsableMachine targetUsableMachine, ref WorldFrame targetFrame);

	public delegate void OnTargetReachedWaitDelegate(Agent agent, ref float waitTimeInSeconds);

	private enum State
	{
		NoTarget,
		GoToUsableMachine,
		GoToAgent,
		GoToTargetFrame,
		NearAgent,
		NearStationaryTarget
	}

	private UsableMachine _targetUsableMachine;

	private Agent _targetAgent;

	private WorldFrame _targetFrame;

	private State _state;

	private bool _sentToTarget;

	private float _waitTimeInSeconds;

	private bool _isWaiting;

	private MissionTimer _waitTimer;

	private float _customTargetReachedRangeThreshold;

	private float _customTargetReachedRotationThreshold;

	private float _initialWaitInSeconds;

	private bool _isInitiallyWaiting;

	private SelectTargetDelegate _selectTargetDelegate;

	private OnTargetReachedDelegate _onTargetReachedDelegate;

	private OnTargetReachedWaitDelegate _onTargetReachWaitDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddUsableMachineTarget(Agent ownerAgent, UsableMachine targetUsableMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddAgentTarget(Agent ownerAgent, Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddWorldFrameTarget(Agent ownerAgent, WorldFrame targetWorldFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddTargetWithDelegate(Agent ownerAgent, SelectTargetDelegate selectTargetDelegate, OnTargetReachedWaitDelegate onTargetReachWaitDelegate, OnTargetReachedDelegate onTargetReachedDelegate, float initialWaitInSeconds = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsNearTarget(Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckForSearchNewTarget(State endState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SearchForNewTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAvailability(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveTargets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetDebugInfo()
	{
		throw null;
	}
}
