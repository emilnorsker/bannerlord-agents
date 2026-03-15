using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(AiPatrollingBehavior), "AiHourlyTick")]
public static class AiPatrollingBehaviorDiagnosticsPatch
{
	[HarmonyFinalizer]
	private static Exception Finalizer(Exception __exception, MobileParty mobileParty, PartyThinkParams p)
	{
		if (__exception == null)
		{
			return null;
		}
		try
		{
			string partyId = ((MBObjectBase)mobileParty)?.StringId ?? "null";
			string leaderId = ((MBObjectBase)(mobileParty?.LeaderHero))?.StringId ?? "null";
			string clanId = ((MBObjectBase)(mobileParty?.ActualClan))?.StringId ?? "null";
			string currentSettlementId = ((MBObjectBase)(mobileParty?.CurrentSettlement))?.StringId ?? "null";
			string targetSettlementId = ((MBObjectBase)(mobileParty?.TargetSettlement))?.StringId ?? "null";
			string targetPartyId = ((MBObjectBase)(mobileParty?.TargetParty))?.StringId ?? "null";
			string behavior = (mobileParty != null) ? mobileParty.DefaultBehavior.ToString() : "null";
			AIInfluenceBehavior.Instance?.LogMessage($"[AI_PATROL_CRASH] {__exception.GetType().Name}: {__exception.Message} | party={partyId} bandit={(mobileParty?.IsBandit ?? false)} behavior={behavior} leader={leaderId} clan={clanId} current_settlement={currentSettlementId} target_settlement={targetSettlementId} target_party={targetPartyId}");
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[AI_PATROL_CRASH] Diagnostics logger failed: " + ex.Message);
		}
		return __exception;
	}
}
