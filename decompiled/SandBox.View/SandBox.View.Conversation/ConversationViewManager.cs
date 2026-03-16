using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation;

namespace SandBox.View.Conversation;

public class ConversationViewManager
{
	private Dictionary<string, ConversationViewEventHandlerDelegate> _conditionEventHandlers;

	private Dictionary<string, ConversationViewEventHandlerDelegate> _consequenceEventHandlers;

	public static ConversationViewManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationViewManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillEventHandlers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillEventHandlersWith(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConsequence(ConversationSentence sentence)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCondition(ConversationSentence sentence)
	{
		throw null;
	}
}
