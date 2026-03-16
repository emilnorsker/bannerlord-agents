using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class FollowAgentBehavior : AgentBehavior
{
	private enum State
	{
		Idle,
		OnMove,
		Fight
	}

	private const float _moveReactionProximityThreshold = 4f;

	private const float _longitudinalClearanceOffset = 2f;

	private const float _onFootMoveProximityThreshold = 1.2f;

	private const float _mountedMoveProximityThreshold = 2.2f;

	private const float _onFootAgentLongitudinalOffset = 0.6f;

	private const float _onFootAgentLateralOffset = 1f;

	private const float _mountedAgentLongitudinalOffset = 1.25f;

	private const float _mountedAgentLateralOffset = 1.5f;

	private float _idleDistance;

	private Agent _selectedAgent;

	private State _state;

	private Agent _deactivatedAgent;

	private bool _myLastStateWasRunning;

	private bool _updatePositionThisFrame;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FollowAgentBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ControlMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryMoveStateTransition(bool forceMove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveToFollowingAgent(bool forcedMove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMovePos(WorldPosition pos, float rotationInRadians, float rangeThreshold, AIScriptedFrameFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
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
}
