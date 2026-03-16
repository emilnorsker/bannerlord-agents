using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox.Issues.IssueQuestTasks;

public class FollowAgentQuestTask : QuestTaskBase
{
	private Agent _followedAgent;

	private CharacterObject _followedAgentChar;

	private GameEntity _targetEntity;

	private Agent _targetAgent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FollowAgentQuestTask(Agent followedAgent, GameEntity targetEntity, Action onSucceededAction, Action onCanceledAction, DialogFlow dialogFlow = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FollowAgentQuestTask(Agent followedAgent, Agent targetAgent, Action onSucceededAction, Action onCanceledAction, DialogFlow dialogFlow = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartAgentMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetReferences()
	{
		throw null;
	}
}
