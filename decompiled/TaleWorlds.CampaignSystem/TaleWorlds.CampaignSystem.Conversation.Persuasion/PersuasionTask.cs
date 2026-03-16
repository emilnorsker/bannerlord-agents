using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Conversation.Persuasion;

public class PersuasionTask
{
	public readonly MBList<PersuasionOptionArgs> Options;

	public TextObject SpokenLine;

	public TextObject ImmediateFailLine;

	public TextObject FinalFailLine;

	public TextObject TryLaterLine;

	public readonly int ReservationType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PersuasionTask(int reservationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddOptionToTask(PersuasionOptionArgs option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BlockAllOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnblockAllOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyEffects(float moveToNextStageChance, float blockRandomOptionChance)
	{
		throw null;
	}
}
