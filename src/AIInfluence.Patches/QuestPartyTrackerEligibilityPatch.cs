using System;
using HarmonyLib;
using SandBox.ViewModelCollection.Map.Tracker;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(MapTrackerProvider), "CanAddMobileParty")]
public static class QuestPartyTrackerEligibilityPatch
{
	private static void Postfix(MobileParty mobileParty, ref bool __result)
	{
		if (__result || mobileParty == null)
		{
			return;
		}
		string stringId = ((MBObjectBase)mobileParty).StringId;
		if (!string.IsNullOrEmpty(stringId) && stringId.StartsWith("quest_party_", StringComparison.OrdinalIgnoreCase))
		{
			__result = true;
		}
	}
}
