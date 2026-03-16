using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using SandBox.Objects.Usables;

namespace SandBox.Missions.AgentBehaviors;

public class ChangeLocationBehavior : AgentBehavior
{
	private readonly MissionAgentHandler _missionAgentHandler;

	private readonly float _initializeTime;

	private Passage _selectedDoor;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeLocationBehavior(AgentBehaviorGroup behaviorGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Passage SelectADoor()
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
