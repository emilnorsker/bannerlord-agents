using HarmonyLib;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(SetPartyAiAction), "GetActionForPatrollingAroundSettlement")]
public static class PatrolAroundSettlementPatch
{
	private static bool Prefix(MobileParty owner, Settlement settlement, NavigationType navigationType, bool isFromPort, bool isTargetingPort)
	{
		PatrolActionGuard.ShouldBlockSettlementOrder(owner, settlement);
		return true;
	}
}
