using System;
using System.Collections.Generic;
using System.Linq;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace AIInfluence.Diseases;

public static class DiseaseEffectSystem
{
	public const float LowProgressRecoveryThreshold = 5f;

	public static float CalculateInitialProgress(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return 15f;
		}
		float num = CalculateMedicineEffectiveness(hero, disease);
		float val = 15f - 15f * num;
		return Math.Max(1f, val);
	}

	public static float CalculateMedicineEffectiveness(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return 0f;
		}
		int skillValue = hero.GetSkillValue(DefaultSkills.Medicine);
		float num = (float)skillValue / 300f * 0.5f;
		float severityModifier = disease.GetSeverityModifier();
		return num * severityModifier;
	}

	public static float CalculateCombinedMedicineEffectiveness(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return 0f;
		}
		MobileParty partyBelongedTo = hero.PartyBelongedTo;
		int num;
		if (partyBelongedTo == null)
		{
			num = hero.GetSkillValue(DefaultSkills.Medicine);
		}
		else
		{
			Hero effectiveSurgeon = partyBelongedTo.EffectiveSurgeon;
			num = ((effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : hero.GetSkillValue(DefaultSkills.Medicine));
		}
		int num2 = num;
		float num3 = (float)num2 / 300f * 0.5f;
		float severityModifier = disease.GetSeverityModifier();
		return num3 * severityModifier;
	}

	public static float CalculateTroopMedicineEffectiveness(MobileParty party, Disease disease)
	{
		if (party == null || disease == null)
		{
			return 0f;
		}
		Hero effectiveSurgeon = party.EffectiveSurgeon;
		int num = ((effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : 0);
		float num2 = GlobalSettings<ModSettings>.Instance?.DiseaseMedicineSkillForTroopsMultiplier ?? 0.75f;
		float num3 = (float)num * num2;
		float num4 = num3 / 300f * 0.5f;
		float severityModifier = disease.GetSeverityModifier();
		return num4 * severityModifier;
	}

	public static float GetProgressDifficultyMultiplier(float progress)
	{
		if (progress <= 0f)
		{
			return 2f;
		}
		if (progress >= 100f)
		{
			return 0.25f;
		}
		float num = progress / 100f;
		if (num <= 0.5f)
		{
			return 2f - 2f * num;
		}
		float num2 = (num - 0.5f) / 0.5f;
		return 1f - 0.75f * num2;
	}

	public static void UpdateDiseaseProgress(DiseaseInstance instance, Disease disease)
	{
		if (instance != null && disease != null && !instance.IsRecovered && !instance.IsDead)
		{
			if (instance.TargetType == DiseaseTargetType.Hero)
			{
				UpdateHeroDiseaseProgress(instance, disease);
			}
			else if (instance.TargetType == DiseaseTargetType.PartyTroops)
			{
				UpdateTroopDiseaseProgress(instance, disease);
			}
			else if (instance.TargetType == DiseaseTargetType.PartyPrisoners)
			{
				UpdatePrisonerDiseaseProgress(instance, disease);
			}
			if (disease.Severity <= 2 && instance.DiseaseProgress > 90f)
			{
				instance.DiseaseProgress = 90f;
			}
		}
	}

	private static void UpdateHeroDiseaseProgress(DiseaseInstance instance, Disease disease)
	{
		Hero val = DiseaseManager.Instance?.LookupHero(instance.TargetId);
		if (val == null || !val.IsAlive || val.IsDead || val.IsChild)
		{
			return;
		}
		MobileParty partyBelongedTo = val.PartyBelongedTo;
		int num;
		if (partyBelongedTo == null)
		{
			num = val.GetSkillValue(DefaultSkills.Medicine);
		}
		else
		{
			Hero effectiveSurgeon = partyBelongedTo.EffectiveSurgeon;
			num = ((effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : val.GetSkillValue(DefaultSkills.Medicine));
		}
		int medicineSkill = num;
		float num2 = CalculateCombinedMedicineEffectiveness(val, disease);
		if (instance.IsTreated)
		{
			if (instance.TreatmentEffectiveness > 0f)
			{
				float num3 = CalculateTreatmentSuccessChance(disease, instance.TreatmentQualityBonus, medicineSkill);
				if (MBRandom.RandomFloat * 100f <= num3)
				{
					float baseRecoveryRate = disease.GetBaseRecoveryRate();
					float progressDifficultyMultiplier = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
					float num4 = baseRecoveryRate * instance.TreatmentEffectiveness * instance.TreatmentQualityBonus * progressDifficultyMultiplier;
					num4 *= DiseasePerkBonuses.GetHeroRecoveryMultiplier(val, partyBelongedTo);
					Settlement currentSettlement = val.CurrentSettlement;
					if (currentSettlement != null)
					{
						DiseaseManager instance2 = DiseaseManager.Instance;
						if (instance2 != null && instance2.IsSettlementUnderQuarantine(currentSettlement))
						{
							num4 *= DiseaseSpreadSystem.QuarantineTreatmentBonus;
						}
					}
					instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num4);
					LogMessage($"[DISEASE_EFFECT] {val.Name} treated for {disease.Name}: progress {instance.DiseaseProgress:F1}% (-{num4:F2}%, quality x{instance.TreatmentQualityBonus:F1}, difficulty x{progressDifficultyMultiplier:F2})");
				}
				else
				{
					float dailyProgressIncrease = disease.GetDailyProgressIncrease();
					float siegeProgressionReduction = DiseasePerkBonuses.GetSiegeProgressionReduction(partyBelongedTo);
					float num5 = dailyProgressIncrease - dailyProgressIncrease * num2;
					num5 *= 1f - siegeProgressionReduction;
					instance.DiseaseProgress = Math.Min(100f, instance.DiseaseProgress + num5);
					LogMessage($"[DISEASE_EFFECT] {val.Name} treatment failed for {disease.Name} (chance: {num3:F1}%). Disease progresses: {instance.DiseaseProgress:F1}% (+{num5:F2}%)");
				}
			}
			else
			{
				float baseRecoveryRate2 = disease.GetBaseRecoveryRate();
				float num6 = baseRecoveryRate2 * instance.TreatmentQualityBonus * 0.5f;
				int maxTreatmentDays = disease.GetMaxTreatmentDays();
				instance.StartPostTreatmentRecovery(num6, maxTreatmentDays);
				float progressDifficultyMultiplier2 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
				instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num6 * progressDifficultyMultiplier2);
				instance.PostTreatmentDaysRemaining--;
				LogMessage($"[DISEASE_EFFECT] {val.Name} treatment course ended for {disease.Name}, post-treatment started " + $"(rate: {num6:F2}%/day, {maxTreatmentDays} days, difficulty x{progressDifficultyMultiplier2:F2}). Progress: {instance.DiseaseProgress:F1}%");
			}
			return;
		}
		if (instance.HasPostTreatmentEffect)
		{
			float num7 = instance.PostTreatmentRecoveryRate;
			Settlement currentSettlement2 = val.CurrentSettlement;
			if (currentSettlement2 != null)
			{
				DiseaseManager instance3 = DiseaseManager.Instance;
				if (instance3 != null && instance3.IsSettlementUnderQuarantine(currentSettlement2))
				{
					num7 *= DiseaseSpreadSystem.QuarantineTreatmentBonus;
				}
			}
			float progressDifficultyMultiplier3 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
			instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num7 * progressDifficultyMultiplier3);
			instance.PostTreatmentDaysRemaining--;
			LogMessage($"[DISEASE_EFFECT] {val.Name} post-treatment recovery from {disease.Name}: " + $"progress {instance.DiseaseProgress:F1}% (-{num7 * progressDifficultyMultiplier3:F2}%, difficulty x{progressDifficultyMultiplier3:F2}, " + $"{instance.PostTreatmentDaysRemaining} days left)");
			if (instance.PostTreatmentDaysRemaining <= 0 && instance.DiseaseProgress > 0f)
			{
				LogMessage($"[DISEASE_EFFECT] {val.Name} post-treatment ended for {disease.Name}, " + $"remaining progress: {instance.DiseaseProgress:F1}%");
			}
			return;
		}
		bool flag = CheckNaturalRecovery(disease, medicineSkill);
		float lowProgressThreshold = DiseasePerkBonuses.GetLowProgressThreshold(partyBelongedTo);
		if (!flag && instance.DiseaseProgress < lowProgressThreshold)
		{
			flag = true;
		}
		if (flag)
		{
			float progressDifficultyMultiplier4 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
			float num8 = disease.GetBaseNaturalRecoveryRate();
			if (num8 <= 0f)
			{
				num8 = 0.3f;
			}
			float num9 = num8 * Math.Max(0.1f, num2) * progressDifficultyMultiplier4;
			num9 *= DiseasePerkBonuses.GetHeroRecoveryMultiplier(val, partyBelongedTo);
			instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num9);
			LogMessage($"[DISEASE_EFFECT] {val.Name} naturally recovering from {disease.Name}: progress {instance.DiseaseProgress:F1}% (difficulty x{progressDifficultyMultiplier4:F2})");
		}
		else
		{
			float dailyProgressIncrease2 = disease.GetDailyProgressIncrease();
			float siegeProgressionReduction2 = DiseasePerkBonuses.GetSiegeProgressionReduction(partyBelongedTo);
			float num10 = dailyProgressIncrease2 - dailyProgressIncrease2 * num2;
			num10 *= 1f - siegeProgressionReduction2;
			instance.DiseaseProgress = Math.Min(100f, instance.DiseaseProgress + num10);
			if (instance.DiseaseProgress >= 100f)
			{
				DiseasePerkBonuses.TryCheatDeath(val, instance);
			}
			LogMessage($"[DISEASE_EFFECT] {val.Name} disease progress: {instance.DiseaseProgress:F1}% (+{num10:F2}%)");
		}
	}

	private static void UpdateTroopDiseaseProgress(DiseaseInstance instance, Disease disease)
	{
		MobileParty val = DiseaseManager.Instance?.LookupParty(instance.PartyId);
		if (val == null)
		{
			return;
		}
		float num = CalculateTroopMedicineEffectiveness(val, disease);
		Hero effectiveSurgeon = val.EffectiveSurgeon;
		int num2 = ((effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : 0);
		int medicineSkill = (int)((float)num2 * (GlobalSettings<ModSettings>.Instance?.DiseaseMedicineSkillForTroopsMultiplier ?? 0.75f));
		if (instance.IsTreated)
		{
			if (instance.TreatmentEffectiveness > 0f)
			{
				float num3 = CalculateTreatmentSuccessChance(disease, instance.TreatmentQualityBonus, medicineSkill);
				if (MBRandom.RandomFloat * 100f <= num3)
				{
					float baseRecoveryRate = disease.GetBaseRecoveryRate();
					float progressDifficultyMultiplier = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
					float num4 = baseRecoveryRate * instance.TreatmentEffectiveness * instance.TreatmentQualityBonus * progressDifficultyMultiplier;
					num4 *= DiseasePerkBonuses.GetTroopRecoveryMultiplier(val);
					instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num4);
					LogMessage($"[DISEASE_EFFECT] Troops in {val.Name} treated for {disease.Name}: progress {instance.DiseaseProgress:F1}% (quality x{instance.TreatmentQualityBonus:F1}, difficulty x{progressDifficultyMultiplier:F2})");
				}
				else
				{
					float dailyProgressIncrease = disease.GetDailyProgressIncrease();
					float siegeProgressionReduction = DiseasePerkBonuses.GetSiegeProgressionReduction(val);
					float num5 = dailyProgressIncrease - dailyProgressIncrease * num;
					num5 *= 1f - siegeProgressionReduction;
					instance.DiseaseProgress = Math.Min(100f, instance.DiseaseProgress + num5);
					LogMessage($"[DISEASE_EFFECT] Troop treatment in {val.Name} failed for {disease.Name} (chance: {num3:F1}%). Disease progresses: {instance.DiseaseProgress:F1}% (+{num5:F2}%)");
				}
			}
			else
			{
				float baseRecoveryRate2 = disease.GetBaseRecoveryRate();
				float num6 = baseRecoveryRate2 * instance.TreatmentQualityBonus * 0.5f;
				int maxTreatmentDays = disease.GetMaxTreatmentDays();
				instance.StartPostTreatmentRecovery(num6, maxTreatmentDays);
				float progressDifficultyMultiplier2 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
				instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num6 * progressDifficultyMultiplier2);
				instance.PostTreatmentDaysRemaining--;
				LogMessage($"[DISEASE_EFFECT] Troop treatment course ended for {disease.Name} in {val.Name}, post-treatment started (difficulty x{progressDifficultyMultiplier2:F2})");
			}
			return;
		}
		if (instance.HasPostTreatmentEffect)
		{
			float progressDifficultyMultiplier3 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
			instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - instance.PostTreatmentRecoveryRate * progressDifficultyMultiplier3);
			instance.PostTreatmentDaysRemaining--;
			LogMessage($"[DISEASE_EFFECT] Troops in {val.Name} post-treatment recovery from {disease.Name}: " + $"progress {instance.DiseaseProgress:F1}% (difficulty x{progressDifficultyMultiplier3:F2}, {instance.PostTreatmentDaysRemaining} days left)");
			return;
		}
		bool flag = CheckNaturalRecovery(disease, medicineSkill);
		float lowProgressThreshold = DiseasePerkBonuses.GetLowProgressThreshold(val);
		if (!flag && instance.DiseaseProgress < lowProgressThreshold)
		{
			flag = true;
		}
		if (!flag)
		{
			flag = DiseasePerkBonuses.CanRecoverFromPerkPhysician(val, disease);
		}
		if (flag)
		{
			float progressDifficultyMultiplier4 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
			float num7 = disease.GetBaseNaturalRecoveryRate();
			if (num7 <= 0f)
			{
				num7 = 0.3f;
			}
			float num8 = num7 * Math.Max(0.1f, num) * progressDifficultyMultiplier4;
			num8 *= DiseasePerkBonuses.GetTroopRecoveryMultiplier(val);
			instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num8);
		}
		else
		{
			float dailyProgressIncrease2 = disease.GetDailyProgressIncrease();
			float siegeProgressionReduction2 = DiseasePerkBonuses.GetSiegeProgressionReduction(val);
			float num9 = dailyProgressIncrease2 - dailyProgressIncrease2 * num;
			num9 *= 1f - siegeProgressionReduction2;
			instance.DiseaseProgress = Math.Min(100f, instance.DiseaseProgress + num9);
		}
	}

	private static void UpdatePrisonerDiseaseProgress(DiseaseInstance instance, Disease disease)
	{
		MobileParty val = DiseaseManager.Instance?.LookupParty(instance.PartyId);
		if (val == null)
		{
			instance.IsRecovered = true;
			return;
		}
		TroopRoster prisonRoster = val.PrisonRoster;
		int num = ((prisonRoster != null) ? prisonRoster.TotalManCount : 0);
		if (num <= 0)
		{
			instance.InfectedTroopCount = 0;
			instance.IsRecovered = true;
			return;
		}
		if (instance.InfectedTroopCount > num)
		{
			instance.InfectedTroopCount = num;
		}
		instance.TotalTroopCount = num;
		float num2 = CalculateTroopMedicineEffectiveness(val, disease);
		Hero effectiveSurgeon = val.EffectiveSurgeon;
		int num3 = ((effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : 0);
		int medicineSkill = (int)((float)num3 * (GlobalSettings<ModSettings>.Instance?.DiseaseMedicineSkillForTroopsMultiplier ?? 0.75f));
		if (instance.IsTreated)
		{
			if (instance.TreatmentEffectiveness > 0f)
			{
				float num4 = CalculateTreatmentSuccessChance(disease, instance.TreatmentQualityBonus, medicineSkill);
				if (MBRandom.RandomFloat * 100f <= num4)
				{
					float baseRecoveryRate = disease.GetBaseRecoveryRate();
					float progressDifficultyMultiplier = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
					float num5 = baseRecoveryRate * instance.TreatmentEffectiveness * instance.TreatmentQualityBonus * progressDifficultyMultiplier;
					instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num5);
				}
				else
				{
					float dailyProgressIncrease = disease.GetDailyProgressIncrease();
					float num6 = dailyProgressIncrease - dailyProgressIncrease * num2;
					instance.DiseaseProgress = Math.Min(100f, instance.DiseaseProgress + num6);
				}
			}
			else
			{
				float baseRecoveryRate2 = disease.GetBaseRecoveryRate();
				float num7 = baseRecoveryRate2 * instance.TreatmentQualityBonus * 0.5f;
				int maxTreatmentDays = disease.GetMaxTreatmentDays();
				instance.StartPostTreatmentRecovery(num7, maxTreatmentDays);
				float progressDifficultyMultiplier2 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
				instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - num7 * progressDifficultyMultiplier2);
				instance.PostTreatmentDaysRemaining--;
			}
		}
		else if (instance.HasPostTreatmentEffect)
		{
			float progressDifficultyMultiplier3 = GetProgressDifficultyMultiplier(instance.DiseaseProgress);
			instance.DiseaseProgress = Math.Max(0f, instance.DiseaseProgress - instance.PostTreatmentRecoveryRate * progressDifficultyMultiplier3);
			instance.PostTreatmentDaysRemaining--;
		}
		else
		{
			float num8 = disease.GetDailyProgressIncrease() * 0.7f;
			instance.DiseaseProgress = Math.Min(100f, instance.DiseaseProgress + num8);
		}
	}

	public static float CalculateTreatmentSuccessChance(Disease disease, float qualityBonus, int medicineSkill)
	{
		if (disease == null)
		{
			return 0f;
		}
		float num = 50f;
		float num2 = (float)medicineSkill * 0.2f;
		float num3 = qualityBonus * 25f;
		float num4 = (float)disease.Severity * 15f;
		float val = num + num2 + num3 - num4;
		return Math.Max(0f, Math.Min(100f, val));
	}

	public static bool CheckNaturalRecovery(Disease disease, int medicineSkill)
	{
		if (disease == null)
		{
			return false;
		}
		int minMedicineForNaturalRecovery = disease.GetMinMedicineForNaturalRecovery();
		return medicineSkill >= minMedicineForNaturalRecovery;
	}

	public static void KillTroopsFromDisease(DiseaseInstance instance, Disease disease, MobileParty party)
	{
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		if (instance == null || disease == null || ((party != null) ? party.MemberRoster : null) == null || instance.InfectedTroopCount <= 0)
		{
			return;
		}
		float num;
		if (instance.DiseaseProgress >= 100f)
		{
			num = 0.05f + (float)disease.Severity * 0.01f;
		}
		else
		{
			if (!(instance.DiseaseProgress >= 80f))
			{
				return;
			}
			num = (instance.DiseaseProgress - 80f) / 400f;
		}
		int num2 = Math.Max(1, (int)((float)instance.InfectedTroopCount * num));
		int num3 = num2;
		TroopRoster memberRoster = party.MemberRoster;
		foreach (int item in instance.TroopTierDistribution.Keys.OrderBy((int t) => t))
		{
			if (num3 <= 0)
			{
				break;
			}
			int troopCountInTier = instance.GetTroopCountInTier(item);
			if (troopCountInTier <= 0 || DiseasePerkBonuses.ShouldPreventTroopDeath(party, disease, item))
			{
				continue;
			}
			float num4 = DiseaseManager.Instance.CalculateTierModifier(item);
			int num5 = Math.Max(1, (int)((float)Math.Min(num3, troopCountInTier) * num4));
			int num6 = 0;
			foreach (TroopRosterElement item2 in ((IEnumerable<TroopRosterElement>)memberRoster.GetTroopRoster()).ToList())
			{
				TroopRosterElement current2 = item2;
				if (num6 >= num5)
				{
					break;
				}
				if (current2.Character != null && !((BasicCharacterObject)current2.Character).IsHero)
				{
					int troopTier = DiseaseManager.Instance.GetTroopTier(current2.Character);
					if (troopTier == item)
					{
						int num7 = Math.Min(num5 - num6, (current2).Number);
						memberRoster.RemoveTroop(current2.Character, num7, default(UniqueTroopDescriptor), 0);
						num6 += num7;
					}
				}
			}
			instance.RemoveTroopsFromTier(item, num6);
			num3 -= num6;
			if (num6 > 0)
			{
				LogMessage($"[DISEASE_EFFECT] {num6} tier {item} troops died from {disease.Name} in {party.Name}");
			}
		}
		instance.TotalTroopCount = memberRoster.TotalRegulars;
	}

	public static DiseaseEffects GetHeroDiseaseEffects(Hero hero)
	{
		if (hero == null)
		{
			return new DiseaseEffects();
		}
		List<DiseaseEffects> list = new List<DiseaseEffects>();
		List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(hero);
		if (list2 != null)
		{
			foreach (DiseaseInstance item in list2)
			{
				Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
				if (disease?.Effects != null)
				{
					list.Add(disease.Effects);
				}
			}
		}
		List<DiseaseInstance> list3 = DiseaseManager.Instance?.GetHeroPermanentModifierInstances(hero);
		if (list3 != null)
		{
			foreach (DiseaseInstance item2 in list3)
			{
				list.Add(item2.PermanentModifiers);
			}
		}
		if (list.Count == 0)
		{
			return new DiseaseEffects();
		}
		return DiseaseEffects.Combine(list);
	}

	public static DiseaseEffects GetPartyTroopDiseaseEffects(MobileParty party)
	{
		if (party == null)
		{
			return new DiseaseEffects();
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		if (list == null || list.Count == 0)
		{
			return new DiseaseEffects();
		}
		List<DiseaseEffects> list2 = new List<DiseaseEffects>();
		foreach (DiseaseInstance item in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease?.Effects != null)
			{
				list2.Add(disease.Effects);
			}
		}
		return DiseaseEffects.Combine(list2);
	}

	public static DiseaseEffects GetTierAdjustedEffects(DiseaseEffects baseEffects, int tier)
	{
		if (baseEffects == null)
		{
			return new DiseaseEffects();
		}
		float factor = DiseaseManager.Instance?.CalculateTierModifier(tier) ?? 1f;
		return baseEffects.ScaleBy(factor);
	}

	private static void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
