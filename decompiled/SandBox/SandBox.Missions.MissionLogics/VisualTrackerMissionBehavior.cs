using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class VisualTrackerMissionBehavior : MissionLogic
{
	public enum AgentTrackTypes
	{
		AvailableIssue,
		ActiveIssue,
		ActiveStoryQuest,
		TrackedIssue,
		TrackedStoryQuest
	}

	private List<TrackedObject> _currentTrackedObjects;

	private int _trackedObjectsVersion;

	private readonly VisualTrackerManager _visualTrackerManager;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentCreated(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterLocalOnlyObject(ITrackableBase obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCommonAreas()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<CompassItemUpdateParams> GetCompassTargets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveLocalObject(ITrackableBase obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentDeleted(Agent affectedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualTrackerMissionBehavior()
	{
		throw null;
	}
}
