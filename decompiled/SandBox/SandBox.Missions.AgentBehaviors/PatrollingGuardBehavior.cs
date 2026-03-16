using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class PatrollingGuardBehavior : AgentBehavior
{
	private readonly MissionAgentHandler _missionAgentHandler;

	private UsableMachine _target;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PatrollingGuardBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
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
	public override string GetDebugInfo()
	{
		throw null;
	}
}
