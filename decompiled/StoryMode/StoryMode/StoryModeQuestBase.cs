using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;

namespace StoryMode;

public abstract class StoryModeQuestBase : QuestBase
{
	public override string SpecialQuestType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool IsRemainingTimeHidden
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected StoryModeQuestBase(string questId, Hero questGiver, CampaignTime duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTimedOut()
	{
		throw null;
	}
}
