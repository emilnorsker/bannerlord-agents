using System.Reflection;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class QuarantineMenuExitPatch
{
	[HarmonyPatch(typeof(GameMenuOption), "GetConditionsHold")]
	public class GameMenuOption_GetConditionsHold_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(GameMenuOption __instance, ref bool __result, Game game, MenuContext menuContext)
		{
			if (__instance == null)
			{
				return;
			}
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance == null || !instance.EnableDiseaseSystem || !__result)
			{
				return;
			}
			if (__instance.IsLeave)
			{
				if (QuarantineSettlementExitBlocker.IsPlayerBlockedByQuarantine() && (QuarantineSettlementExitBlocker.IsBlockedOptionId(__instance.IdString) || (__instance.IdString == "quarantine_leave" && QuarantineCastleMenuPatch.WasInCastleMenuBeforeApproach)))
				{
					__instance.SetEnable(false);
					SetOptionTooltip(__instance, QuarantineSettlementExitBlocker.GetQuarantineBlockedTooltip());
				}
			}
			else if (QuarantineSettlementExitBlocker.IsInQuarantinedSettlement() && QuarantineSettlementExitBlocker.IsQuarantineRestrictedOptionId(__instance.IdString))
			{
				__instance.SetEnable(false);
				SetOptionTooltip(__instance, QuarantineSettlementExitBlocker.GetQuarantineRestrictedTooltip());
			}
		}
	}

	private static readonly PropertyInfo TooltipProperty = typeof(GameMenuOption).GetProperty("Tooltip", BindingFlags.Instance | BindingFlags.Public);

	private static void SetOptionTooltip(GameMenuOption option, TextObject tooltip)
	{
		TooltipProperty?.SetValue(option, tooltip);
	}
}
