using System;
using System.Collections.Generic;
using AIInfluence.Diseases;
using AIInfluence.DynamicEvents;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace AIInfluence.SettlementCombat;

[HarmonyPatch(typeof(DefaultSettlementSecurityModel))]
public class SettlementSecurityPatch
{
	[HarmonyPatch("CalculateSecurityChange")]
	[HarmonyPostfix]
	public static void CalculateSecurityChange_Postfix(Town town, bool includeDescriptions, ref ExplainedNumber __result)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		try
		{
			if (Campaign.Current != null && town != null && ((SettlementComponent)town).Settlement != null)
			{
				if (EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(((SettlementComponent)town).Settlement, out var prosperityPerDay, out var foodPerDay, out var securityPerDay, out var loyaltyPerDay, out var reason) && Math.Abs(securityPerDay) > 0.001f)
				{
					TextObject val = new TextObject(reason, (Dictionary<string, object>)null);
					((ExplainedNumber)(ref __result)).Add(securityPerDay, val, (TextObject)null);
				}
				if (DiseaseManager.Instance != null && DiseaseManager.Instance.TryGetQuarantineSettlementEffect(((SettlementComponent)town).Settlement, out loyaltyPerDay, out foodPerDay, out var securityPerDay2, out prosperityPerDay, out var _, out var reason2) && Math.Abs(securityPerDay2) > 0.001f)
				{
					((ExplainedNumber)(ref __result)).Add(securityPerDay2, new TextObject(reason2, (Dictionary<string, object>)null), (TextObject)null);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
