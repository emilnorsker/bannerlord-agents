using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(SetPartyAiAction), "GetActionForPatrollingAroundPoint")]
public static class PatrolAroundPointPatch
{
	private static bool Prefix(MobileParty owner, CampaignVec2 position, NavigationType navigationType, bool isFromPort)
	{
		return !PatrolActionGuard.ShouldBlockPointOrder(owner);
	}
}
