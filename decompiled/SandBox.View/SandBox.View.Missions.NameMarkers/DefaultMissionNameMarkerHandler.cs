using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using SandBox.ViewModelCollection.Missions.NameMarker;
using SandBox.ViewModelCollection.Missions.NameMarker.Targets;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.View.Missions.NameMarkers;

public class DefaultMissionNameMarkerHandler : MissionNameMarkerProvider
{
	private MissionMode _lastMissionMode;

	private DisguiseMissionLogic _disguiseMissionLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDestroy(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CreateMarkers(List<MissionNameMarkerTargetBaseVM> markers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAgentTarget(Agent agent, List<MissionAgentMarkerTargetVM> markers, bool isAdditional = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMissionNameMarkerHandler()
	{
		throw null;
	}
}
