using System;
using AIInfluence.Behaviors.AIActions;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(CaravanConversationsCampaignBehavior), "conversation_caravan_build_clickable_condition")]
public static class CaravanConversationPatch
{
	private static bool Prefix(ref bool __result, ref TextObject explanation)
	{
		try
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement == null)
			{
				explanation = null;
				__result = false;
				return false;
			}
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			if (oneToOneConversationHero != null && AIActionManager.Instance.IsActionActive(oneToOneConversationHero, "follow_player"))
			{
				Settlement val = oneToOneConversationHero.HomeSettlement ?? oneToOneConversationHero.StayingInSettlement ?? oneToOneConversationHero.CurrentSettlement;
				if (val != null && currentSettlement != val)
				{
					explanation = null;
					__result = false;
					return false;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] CaravanConversationPatch.Prefix failed: " + ex.Message);
			explanation = null;
			__result = false;
			return false;
		}
	}
}
