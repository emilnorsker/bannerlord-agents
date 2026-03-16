using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AreaMarkers;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects;
using TaleWorlds.MountAndBlade.Objects.Usables;

namespace SandBox.Missions;

public class SabotageMissionController : MissionLogic
{
	private const string SabotageObjectiveTag = "sabotage_objective";

	private const string SabotageMissionExitBarrierTag = "sabotage_mission_exit_barrier";

	private const string SabotageMissionExitAreaTag = "sabotage_mission_exit_area";

	private const string SabotageObjectiveUsedEventId = "sabotage_objective_used_event";

	private readonly List<EventTriggeringUsableMachine> _sabotageObjectives;

	private GameEntity _missionExitBarrier;

	private BasicAreaIndicator _missionExitArea;

	private int _allSabotageObjectivesCount;

	private int _usedSabotageObjectivesCount;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SabotageMissionController()
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
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSabotageObjectiveUsed(EventTriggeringUsableMachine eventTriggeringUsableMachine, string eventDescriptionTextId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}
}
