using System;
using System.Collections.Generic;
using AIInfluence.DynamicEvents;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace AIInfluence.SettlementCombat;

[HarmonyPatch(typeof(DefaultSettlementFoodModel))]
public class SettlementFoodPatch
{
	[HarmonyPatch("CalculateTownFoodStocksChange")]
	[HarmonyPostfix]
	public static void CalculateTownFoodStocksChange_Postfix(Town town, bool includeMarketStocks, bool includeDescriptions, ref ExplainedNumber __result)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		try
		{
			if (Campaign.Current != null && town != null && ((SettlementComponent)town).Settlement != null)
			{
				if (EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(((SettlementComponent)town).Settlement, out var prosperityPerDay, out var foodPerDay, out var reason) && Math.Abs(foodPerDay) > 0.001f)
				{
					TextObject val = new TextObject(reason, (Dictionary<string, object>)null);
					(__result).Add(foodPerDay, val, (TextObject)null);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
