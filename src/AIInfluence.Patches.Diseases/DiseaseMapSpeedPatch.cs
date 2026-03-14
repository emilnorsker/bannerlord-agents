using System;
using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class DiseaseMapSpeedPatch
{
	[HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
	public class CalculateFinalSpeed_Patch
	{
		[HarmonyPostfix]
		public static ExplainedNumber Postfix(ExplainedNumber __result, MobileParty mobileParty)
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			try
			{
				if (mobileParty == null || !(GlobalSettings<ModSettings>.Instance?.EnableDiseaseSystem ?? false))
				{
					return __result;
				}
				float partySpeedMultiplier = GetPartySpeedMultiplier(mobileParty);
				if (partySpeedMultiplier < 1f)
				{
					(__result).AddFactor(partySpeedMultiplier - 1f, new TextObject("{=AIInfluence_DiseaseSpeedPenalty}Disease", (Dictionary<string, object>)null));
				}
			}
			catch (Exception)
			{
			}
			return __result;
		}
	}

	[HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
	public class GetEffectivePartyMorale_Patch
	{
		[HarmonyPostfix]
		public static ExplainedNumber Postfix(ExplainedNumber __result, MobileParty mobileParty)
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			try
			{
				if (mobileParty == null || !(GlobalSettings<ModSettings>.Instance?.EnableDiseaseSystem ?? false))
				{
					return __result;
				}
				float partyMoraleModifier = GetPartyMoraleModifier(mobileParty);
				if (partyMoraleModifier < 0f)
				{
					(__result).Add(partyMoraleModifier, new TextObject("{=AIInfluence_DiseaseMoralePenalty}Disease in party", (Dictionary<string, object>)null), (TextObject)null);
				}
			}
			catch (Exception)
			{
			}
			return __result;
		}
	}

	public static float GetPartySpeedMultiplier(MobileParty party)
	{
		if (party == null || DiseaseManager.Instance == null)
		{
			return 1f;
		}
		float num = 1f;
		if (party.LeaderHero != null)
		{
			DiseaseEffects heroDiseaseEffects = DiseaseEffectSystem.GetHeroDiseaseEffects(party.LeaderHero);
			if (heroDiseaseEffects?.MapModifiers != null)
			{
				num *= heroDiseaseEffects.MapModifiers.MovementSpeedMultiplier;
			}
		}
		DiseaseEffects partyTroopDiseaseEffects = DiseaseEffectSystem.GetPartyTroopDiseaseEffects(party);
		if (partyTroopDiseaseEffects?.MapModifiers != null)
		{
			float num2 = DiseaseManager.Instance.GetPartyInfectionRate(party) / 100f;
			float num3 = 1f + (partyTroopDiseaseEffects.MapModifiers.MovementSpeedMultiplier - 1f) * num2;
			num *= num3;
		}
		if (num < 1f)
		{
			float speedPenaltyReduction = DiseasePerkBonuses.GetSpeedPenaltyReduction(party);
			if (speedPenaltyReduction > 0f)
			{
				float num4 = 1f - num;
				num = 1f - num4 * (1f - speedPenaltyReduction);
			}
		}
		return Math.Max(0.5f, num);
	}

	public static float GetPartyMoraleModifier(MobileParty party)
	{
		if (party == null || DiseaseManager.Instance == null)
		{
			return 0f;
		}
		float num = 0f;
		if (party.LeaderHero != null)
		{
			DiseaseEffects heroDiseaseEffects = DiseaseEffectSystem.GetHeroDiseaseEffects(party.LeaderHero);
			if (heroDiseaseEffects?.MapModifiers != null)
			{
				num += heroDiseaseEffects.MapModifiers.MoraleModifier;
			}
		}
		DiseaseEffects partyTroopDiseaseEffects = DiseaseEffectSystem.GetPartyTroopDiseaseEffects(party);
		if (partyTroopDiseaseEffects?.MapModifiers != null)
		{
			float num2 = DiseaseManager.Instance.GetPartyInfectionRate(party) / 100f;
			num += partyTroopDiseaseEffects.MapModifiers.MoraleModifier * num2;
		}
		return Math.Max(-50f, num);
	}
}
