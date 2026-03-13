using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[HarmonyPatch(typeof(QuestBase), "get_IsSpecialQuest")]
public static class QuestBase_IsSpecialQuest_Patch
{
	public static void Postfix(QuestBase __instance, ref bool __result)
	{
		if (__instance is AIGeneratedQuest)
		{
			__result = true;
		}
	}
}
