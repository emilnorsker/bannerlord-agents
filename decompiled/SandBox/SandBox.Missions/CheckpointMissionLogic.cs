using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions;

public class CheckpointMissionLogic : MissionLogic
{
	private readonly Dictionary<Agent, AgentSaveData> _allSpawnedSaveableAgents;

	private readonly CheckpointCampaignBehavior _checkpointCampaignBehavior;

	private bool _isInitialized;

	private bool _isRenderingStarted;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheckpointMissionLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnEarlyAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanUseCheckpoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCheckpointUsed(int checkpointUniqueId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisablePatrolAreasAccordingToTheLastUsedCheckpoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCorpses()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterAgent(Agent agent)
	{
		throw null;
	}
}
