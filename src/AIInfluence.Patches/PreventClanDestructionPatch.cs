using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(FactionDiscontinuationCampaignBehavior), "DiscontinueClan")]
public static class PreventClanDestructionPatch
{
	private static bool Prefix(Clan clan)
	{
		return false;
	}
}
