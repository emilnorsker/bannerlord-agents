using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(CampaignEventDispatcher), "OnBeforeMainCharacterDied")]
public static class PlayerDeathPatch
{
	[HarmonyPrefix]
	public static bool Prefix()
	{
		return true;
	}
}
