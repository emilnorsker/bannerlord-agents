using HarmonyLib;

namespace AIInfluence.Patches;

/// <summary>Slice 15 placeholder: engine/BLGM hook to suppress interactive entity pickers for console ambiguity is not wired yet (Harmony target TBD).</summary>
[HarmonyPatch]
internal static class GameMasterNoUiDisambiguationDeferralPatch
{
	[HarmonyPrepare]
	private static bool Prepare()
	{
		return false;
	}
}
