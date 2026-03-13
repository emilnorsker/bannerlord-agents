using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Overlay;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Localization;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(SettlementMenuOverlayVM), "ExecuteOnSetAsActiveContextMenuItem")]
public static class QuarantineNotableVisitPatch
{
	private static readonly FieldRef<SettlementMenuOverlayVM, GameMenuOverlayActionVM> TalkRef = AccessTools.FieldRefAccess<SettlementMenuOverlayVM, GameMenuOverlayActionVM>("_overlayTalkItem");

	private static readonly FieldRef<SettlementMenuOverlayVM, GameMenuOverlayActionVM> QuickTalkRef = AccessTools.FieldRefAccess<SettlementMenuOverlayVM, GameMenuOverlayActionVM>("_overlayQuickTalkItem");

	private static readonly TextObject QuarantineHint = new TextObject("{=AIInfluence_QuarantineVisitBlocked}The settlement is under quarantine. You cannot visit.", (Dictionary<string, object>)null);

	private static void Postfix(SettlementMenuOverlayVM __instance)
	{
		if (ShouldDisableVisit(__instance))
		{
			TryDisable(TalkRef.Invoke(__instance));
			TryDisable(QuickTalkRef.Invoke(__instance));
		}
	}

	private static bool ShouldDisableVisit(SettlementMenuOverlayVM overlay)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		if (DiseaseManager.Instance == null)
		{
			return false;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null || (!currentSettlement.IsTown && !currentSettlement.IsCastle))
		{
			return false;
		}
		if (!DiseaseManager.Instance.IsSettlementUnderQuarantine(currentSettlement))
		{
			return false;
		}
		return true;
	}

	private static void TryDisable(GameMenuOverlayActionVM action)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		if (action != null)
		{
			((StringItemWithEnabledAndHintVM)action).IsEnabled = false;
			((StringItemWithEnabledAndHintVM)action).Hint = new HintViewModel(QuarantineHint, (string)null);
		}
	}
}
