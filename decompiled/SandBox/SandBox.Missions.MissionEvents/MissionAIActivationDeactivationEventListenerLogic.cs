using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects;

namespace SandBox.Missions.MissionEvents;

public class MissionAIActivationDeactivationEventListenerLogic : MissionLogic
{
	public const string ActivationEventId = "activate_agent_ai";

	public const string DeactivationEventId = "deactivate_agent_ai";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAIActivationDeactivationEventListenerLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGenericMissionEventTriggered(GenericMissionEvent missionEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckRemoveScriptedBehaviorFromAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAddScriptedBehaviorToAgent(Agent agent)
	{
		throw null;
	}
}
