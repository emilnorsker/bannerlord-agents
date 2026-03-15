using System;
using System.Collections.Generic;
using AIInfluence;
using MCM.Abstractions.Base.Global;
using HarmonyLib;
using SandBox.ViewModelCollection.Map.Tracker;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(MapTrackerProvider), "CanAddMobileParty")]
public static class QuestPartyTrackerEligibilityPatch
{
	private static readonly Dictionary<string, DateTime> _lastDebugLogByPartyId = new Dictionary<string, DateTime>();

	private static void Postfix(MobileParty mobileParty, ref bool __result)
	{
		if (mobileParty == null)
		{
			return;
		}
		string stringId = ((MBObjectBase)mobileParty).StringId;
		if (string.IsNullOrEmpty(stringId) || !stringId.StartsWith("quest_party_", StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		bool flag = __result;
		if (!__result)
		{
			__result = true;
		}
		if (ShouldEmitDebugLog(stringId) && (GlobalSettings<ModSettings>.Instance?.DebugQuestScenarioVerboseLogging ?? false))
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[QuestDebugVerbose] TrackerEligibility CanAddMobileParty | party={stringId} vanilla_result={flag} forced_result={__result}");
		}
	}

	private static bool ShouldEmitDebugLog(string partyId)
	{
		DateTime utcNow = DateTime.UtcNow;
		if (_lastDebugLogByPartyId.TryGetValue(partyId, out var value) && (utcNow - value).TotalSeconds < 3.0)
		{
			return false;
		}
		_lastDebugLogByPartyId[partyId] = utcNow;
		return true;
	}
}
