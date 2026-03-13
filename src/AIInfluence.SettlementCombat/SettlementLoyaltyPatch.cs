using System;
using System.Collections.Generic;
using AIInfluence.DynamicEvents;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace AIInfluence.SettlementCombat;

[HarmonyPatch(typeof(DefaultSettlementLoyaltyModel))]
public class SettlementLoyaltyPatch
{
	[HarmonyPatch("CalculateLoyaltyChange")]
	[HarmonyPostfix]
	public static void CalculateLoyaltyChange_Postfix(Town town, bool includeDescriptions, ref ExplainedNumber __result)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		try
		{
			if (Campaign.Current != null && town != null && ((SettlementComponent)town).Settlement != null)
			{
				if (EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(((SettlementComponent)town).Settlement, out var prosperityPerDay, out var foodPerDay, out var securityPerDay, out var loyaltyPerDay, out var reason) && Math.Abs(loyaltyPerDay) > 0.001f)
				{
					TextObject val = new TextObject(reason, (Dictionary<string, object>)null);
					((ExplainedNumber)(ref __result)).Add(loyaltyPerDay, val, (TextObject)null);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
