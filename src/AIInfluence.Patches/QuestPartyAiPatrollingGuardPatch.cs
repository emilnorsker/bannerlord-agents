using AIInfluence;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(AiPatrollingBehavior), "AiHourlyTick")]
public static class QuestPartyAiPatrollingGuardPatch
{
	private static bool Prefix(MobileParty mobileParty)
	{
		AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
		if (instance == null || mobileParty == null)
		{
			return true;
		}
		if (!instance.IsAiInfluenceSpawnedQuestParty(mobileParty))
		{
			return true;
		}
		if (!(mobileParty.MapFaction?.IsBanditFaction ?? false))
		{
			return true;
		}
		if (GlobalSettings<ModSettings>.Instance?.DebugQuestScenarioVerboseLogging ?? false)
		{
			instance.LogMessage($"[QuestDebugVerbose] Skipping AiPatrollingBehavior.AiHourlyTick for AIInfluence quest party '{((MBObjectBase)mobileParty).StringId}' (bandit map faction)");
		}
		return false;
	}
}
