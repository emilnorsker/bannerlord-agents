using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Overlay;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(GameMenuOverlay), "ExecuteTroopAction")]
public static class TalkVisitRedirectPatch
{
	private static readonly Type ContextEnumType = AccessTools.Inner(typeof(GameMenuOverlay), "MenuOverlayContextList");

	private static readonly object QuickConversationValue = ((ContextEnumType != null) ? Enum.Parse(ContextEnumType, "QuickConversation") : null);

	private static readonly object ConversationValue = ((ContextEnumType != null) ? Enum.Parse(ContextEnumType, "Conversation") : null);

	private static void Prefix(ref object o)
	{
		try
		{
			if (!(ContextEnumType == null) && QuickConversationValue != null && ConversationValue != null && o != null && o.GetType() == ContextEnumType && o.Equals(QuickConversationValue))
			{
				o = ConversationValue;
			}
		}
		catch
		{
		}
	}
}
