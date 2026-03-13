using System.Collections.Generic;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Overlay;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Localization;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(SettlementMenuOverlayVM), "ExecuteOnSetAsActiveContextMenuItem")]
public static class DisableTalkButtonPatch
{
	private static readonly FieldRef<SettlementMenuOverlayVM, GameMenuOverlayActionVM> QuickTalkRef = AccessTools.FieldRefAccess<SettlementMenuOverlayVM, GameMenuOverlayActionVM>("_overlayQuickTalkItem");

	private static void Postfix(SettlementMenuOverlayVM __instance)
	{
		TryDisable(QuickTalkRef.Invoke(__instance));
	}

	private static void TryDisable(GameMenuOverlayActionVM action)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		if (action != null)
		{
			((StringItemWithEnabledAndHintVM)action).IsEnabled = false;
			((StringItemWithEnabledAndHintVM)action).Hint = new HintViewModel(new TextObject("{=AIInfluence_TalkDisabled}Disabled by AIInfluence", (Dictionary<string, object>)null), (string)null);
		}
	}
}
