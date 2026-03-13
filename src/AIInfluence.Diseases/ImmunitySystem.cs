using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace AIInfluence.Diseases;

public static class ImmunitySystem
{
	public static float CalculateImmunityChance(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return 0f;
		}
		int skillValue = hero.GetSkillValue(DefaultSkills.Medicine);
		float num = (float)skillValue / 300f * 0.5f;
		float severityModifier = disease.GetSeverityModifier();
		float num2 = num * severityModifier;
		DiseaseInstance diseaseInstance = DiseaseManager.Instance?.GetHeroDiseases(hero).Find((DiseaseInstance d) => d.DiseaseId == disease.Id);
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(hero);
		if (list != null)
		{
			foreach (DiseaseInstance item in list)
			{
				if (item.HasPreventionEffect && !item.IsPreventionExpired())
				{
					num2 += GetPreventionBonus(item.PreventionStrength);
					break;
				}
			}
		}
		num2 += DiseasePerkBonuses.GetHeroImmunityBonus(hero, hero.PartyBelongedTo);
		return Math.Min(1f, num2);
	}

	public static bool CheckImmunity(Hero hero, Disease disease)
	{
		float num = CalculateImmunityChance(hero, disease);
		Random random = new Random();
		float num2 = (float)random.NextDouble();
		bool flag = num2 < num;
		if (flag)
		{
			LogMessage($"[IMMUNITY] {hero.Name} is immune to {disease.Name} (chance: {num:P1}, roll: {num2:F2})");
		}
		return flag;
	}

	public static float CalculateTroopImmunityChance(MobileParty party, Disease disease)
	{
		if (party == null || disease == null)
		{
			return 0f;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		int num = ((effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : 0);
		float num2 = (float)num / 300f * 0.5f;
		float severityModifier = disease.GetSeverityModifier();
		float num3 = num2 * severityModifier;
		num3 += DiseasePerkBonuses.GetTroopImmunityBonus(party);
		return Math.Min(1f, num3);
	}

	public static bool CheckTroopImmunity(MobileParty party, Disease disease)
	{
		float num = CalculateTroopImmunityChance(party, disease);
		if (num <= 0f)
		{
			return false;
		}
		Random random = new Random();
		float num2 = (float)random.NextDouble();
		bool flag = num2 < num;
		if (flag)
		{
			LogMessage($"[IMMUNITY] Troops in {party.Name} resisted {disease.Name} (chance: {num:P1}, roll: {num2:F2})");
		}
		return flag;
	}

	public static float CalculateSettlementImmunity(Settlement settlement, Disease disease)
	{
		if (settlement == null || disease == null)
		{
			return 0f;
		}
		int medicalTier = TreatmentSystem.GetMedicalTier(settlement);
		float tierSettlementImmunity = TreatmentSystem.GetTierSettlementImmunity(medicalTier);
		float severityModifier = disease.GetSeverityModifier();
		float val = tierSettlementImmunity * severityModifier;
		return Math.Min(0.3f, val);
	}

	public static bool CheckSettlementImmunity(Settlement settlement, Disease disease)
	{
		float num = CalculateSettlementImmunity(settlement, disease);
		Random random = new Random();
		float num2 = (float)random.NextDouble();
		return num2 < num;
	}

	public static float GetPreventionBonus(int strength)
	{
		return strength switch
		{
			1 => 0.05f, 
			2 => 0.1f, 
			3 => 0.15f, 
			4 => 0.2f, 
			5 => 0.25f, 
			_ => 0f, 
		};
	}

	private static void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
