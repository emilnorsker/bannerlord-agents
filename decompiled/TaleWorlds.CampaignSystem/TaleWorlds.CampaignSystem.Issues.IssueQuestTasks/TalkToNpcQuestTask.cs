using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Issues.IssueQuestTasks;

public class TalkToNpcQuestTask : QuestTaskBase
{
	private CharacterObject _character;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TalkToNpcQuestTask(Hero hero, Action onSucceededAction, DialogFlow dialogFlow = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TalkToNpcQuestTask(CharacterObject character, Action onSucceededAction, DialogFlow dialogFlow = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTaskCharacter()
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
