using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class StandGuardBehavior : AgentBehavior
{
	private enum GuardState
	{
		StandIdle,
		StandAttention,
		StandCautious,
		GotToStandPoint
	}

	private UsableMachine _oldStandPoint;

	private UsableMachine _standPoint;

	private readonly MissionAgentHandler _missionAgentHandler;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandGuardBehavior(AgentBehaviorGroup behaviorGroup)
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
	public override float GetAvailability(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetDebugInfo()
	{
		throw null;
	}
}
