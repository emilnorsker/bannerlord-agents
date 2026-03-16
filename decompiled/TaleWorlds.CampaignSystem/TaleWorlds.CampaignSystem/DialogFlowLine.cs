using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem;

internal class DialogFlowLine
{
	internal TextObject Text;

	internal string InputToken;

	internal string OutputToken;

	internal bool ByPlayer;

	internal ConversationSentence.OnConditionDelegate ConditionDelegate;

	internal ConversationSentence.OnClickableConditionDelegate ClickableConditionDelegate;

	internal ConversationSentence.OnConsequenceDelegate ConsequenceDelegate;

	internal ConversationSentence.OnMultipleConversationConsequenceDelegate SpeakerDelegate;

	internal ConversationSentence.OnMultipleConversationConsequenceDelegate ListenerDelegate;

	internal bool IsRepeatable;

	internal bool IsSpecialOption;

	internal bool IsUsedOnce;

	public List<KeyValuePair<TextObject, List<GameTextManager.ChoiceTag>>> Variations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public bool HasVariation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal DialogFlowLine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddVariation(TextObject text, List<GameTextManager.ChoiceTag> list)
	{
		throw null;
	}
}
