using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Source.Missions.Handlers.Logic;

public class AgentMoraleInteractionLogic : MissionLogic
{
	private const float DebacleVoiceChance = 0.7f;

	private const float MoraleEffectRadius = 4f;

	private const int MaxNumAgentsToGainMorale = 10;

	private const int MaxNumAgentsToLoseMorale = 10;

	private const float SquaredDistanceForSeparateAffectorQuery = 2.25f;

	private const ushort RandomSelectorCapacity = 1024;

	private readonly HashSet<Agent> _agentsToReceiveMoraleGain;

	private readonly HashSet<Agent> _agentsToReceiveMoraleLoss;

	private readonly MBFastRandomSelector<Agent> _randomAgentSelector;

	private readonly MBFastRandomSelector<IFormationUnit> _randomFormationUnitSelector;

	private readonly MBList<Agent> _nearbyAgentsCache;

	private readonly MBList<Agent> _nearbyAllyAgentsCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentMoraleInteractionLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentFleeing(Agent affectedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyMoraleEffectOnAgentIncapacitated(Agent affectedAgent, Agent affectorAgent, float affectedSideMaxMoraleLoss, float affectorSideMoraleMaxGain, float effectRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectRandomAgentsFromListToAgentSet(MBReadOnlyList<Agent> agentsList, HashSet<Agent> outputAgentsSet, int maxCountInSet, Predicate<Agent> conditions = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectRandomAgentsFromFormationToAgentSet(Formation formation, HashSet<Agent> outputAgentsSet, int maxCountInSet, Predicate<IFormationUnit> conditions = null)
	{
		throw null;
	}
}
