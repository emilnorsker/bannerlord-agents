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
		string stringId = ((MBObjectBase)mobileParty).StringId;
		if (mobileParty.MapFaction == null || mobileParty.MapFaction.FactionMidSettlement == null)
		{
			instance.LogMessage($"[ERROR] [QUEST] Skipping AiPatrollingBehavior.AiHourlyTick for AIInfluence quest party '{stringId}' due to invalid map faction state");
			return false;
		}
		if (!mobileParty.MapFaction.IsBanditFaction)
		{
			return true;
		}
		if (GlobalSettings<ModSettings>.Instance?.DebugQuestScenarioVerboseLogging ?? false)
		{
			instance.LogMessage($"[QuestDebugVerbose] Skipping AiPatrollingBehavior.AiHourlyTick for AIInfluence quest party '{stringId}' (bandit map faction)");
		}
		return false;
	}
}
