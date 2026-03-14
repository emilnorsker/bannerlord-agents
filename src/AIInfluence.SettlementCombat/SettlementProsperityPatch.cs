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

[HarmonyPatch(typeof(DefaultSettlementProsperityModel))]
public class SettlementProsperityPatch
{
	[HarmonyPatch("CalculateHearthChange")]
	[HarmonyPostfix]
	public static void CalculateHearthChange_Postfix(Village village, ref ExplainedNumber __result)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		try
		{
			if (Campaign.Current == null || village == null || ((SettlementComponent)village).Settlement == null)
			{
				return;
			}
			if (SettlementPenaltyManager.Instance != null)
			{
				ActivePenalty activePenalty = SettlementPenaltyManager.Instance.GetActivePenalty(((SettlementComponent)village).Settlement);
				if (activePenalty != null && activePenalty.IsActive())
				{
					TextObject val = new TextObject(activePenalty.Reason, (Dictionary<string, object>)null);
					(__result).Add(0f - activePenalty.ProsperityPenaltyPerDay, val, (TextObject)null);
				}
			}
			if (EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(((SettlementComponent)village).Settlement, out var prosperityPerDay, out var foodPerDay, out var reason) && Math.Abs(prosperityPerDay) > 0.001f)
			{
				TextObject val2 = new TextObject(reason, (Dictionary<string, object>)null);
				(__result).Add(prosperityPerDay, val2, (TextObject)null);
			}
			if (DiseaseManager.Instance != null && DiseaseManager.Instance.TryGetQuarantineSettlementEffect(((SettlementComponent)village).Settlement, out var prosperityPerDay2, out foodPerDay, out var _, out var _, out var _, out var reason2) && Math.Abs(prosperityPerDay2) > 0.001f)
			{
				(__result).Add(prosperityPerDay2, new TextObject(reason2, (Dictionary<string, object>)null), (TextObject)null);
			}
		}
		catch (Exception)
		{
		}
	}

	[HarmonyPatch("CalculateProsperityChange")]
	[HarmonyPostfix]
	public static void CalculateProsperityChange_Postfix(Town fortification, ref ExplainedNumber __result)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		try
		{
			if (Campaign.Current == null || fortification == null || ((SettlementComponent)fortification).Settlement == null)
			{
				return;
			}
			if (SettlementPenaltyManager.Instance != null)
			{
				ActivePenalty activePenalty = SettlementPenaltyManager.Instance.GetActivePenalty(((SettlementComponent)fortification).Settlement);
				if (activePenalty != null && activePenalty.IsActive())
				{
					TextObject val = new TextObject(activePenalty.Reason, (Dictionary<string, object>)null);
					(__result).Add(0f - activePenalty.ProsperityPenaltyPerDay, val, (TextObject)null);
				}
			}
			if (EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(((SettlementComponent)fortification).Settlement, out var prosperityPerDay, out var foodPerDay, out var reason) && Math.Abs(prosperityPerDay) > 0.001f)
			{
				TextObject val2 = new TextObject(reason, (Dictionary<string, object>)null);
				(__result).Add(prosperityPerDay, val2, (TextObject)null);
			}
			if (DiseaseManager.Instance != null && DiseaseManager.Instance.TryGetQuarantineSettlementEffect(((SettlementComponent)fortification).Settlement, out var prosperityPerDay2, out foodPerDay, out var _, out var _, out var _, out var reason2) && Math.Abs(prosperityPerDay2) > 0.001f)
			{
				(__result).Add(prosperityPerDay2, new TextObject(reason2, (Dictionary<string, object>)null), (TextObject)null);
			}
		}
		catch (Exception)
		{
		}
	}
}
