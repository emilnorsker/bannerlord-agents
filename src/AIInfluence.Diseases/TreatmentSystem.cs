using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Patches.Diseases;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace AIInfluence.Diseases;

public static class TreatmentSystem
{
	public static int GetMedicalTier(Settlement settlement)
	{
		if (settlement == null)
		{
			return 1;
		}
		int num;
		if (settlement.IsVillage)
		{
			num = 1;
		}
		else if (settlement.IsCastle)
		{
			float prosperity = settlement.Town.Prosperity;
			num = ((!(prosperity >= 1500f)) ? 1 : 2);
		}
		else if (settlement.IsTown)
		{
			float prosperity2 = settlement.Town.Prosperity;
			num = ((prosperity2 >= 7000f) ? 4 : ((prosperity2 >= 4000f) ? 3 : ((!(prosperity2 >= 2000f)) ? 1 : 2)));
		}
		else
		{
			num = 1;
		}
		if (IsKingdomCapital(settlement))
		{
			num = Math.Min(4, num + 1);
		}
		return num;
	}

	public static int GetEffectiveMedicalTier(Settlement settlement, Hero treatedHero = null)
	{
		int medicalTier = GetMedicalTier(settlement);
		medicalTier += DiseasePerkBonuses.GetMedicalTierBonus(settlement, treatedHero);
		return Math.Min(4, medicalTier);
	}

	public static float GetTierRecoveryBonus(int tier)
	{
		return tier switch
		{
			1 => 1f, 
			2 => 1.3f, 
			3 => 1.7f, 
			4 => 2f, 
			_ => 1f, 
		};
	}

	public static float GetTierCostMultiplier(int tier)
	{
		return tier switch
		{
			1 => 1f, 
			2 => 1.5f, 
			3 => 2f, 
			4 => 2.5f, 
			_ => 1f, 
		};
	}

	public static int GetTierMaxHerbStrength(int tier)
	{
		return tier switch
		{
			1 => 2, 
			2 => 3, 
			3 => 4, 
			4 => 5, 
			_ => 2, 
		};
	}

	public static float GetTierSettlementImmunity(int tier)
	{
		return tier switch
		{
			1 => 0.05f, 
			2 => 0.1f, 
			3 => 0.2f, 
			4 => 0.3f, 
			_ => 0.05f, 
		};
	}

	public static string GetTierName(int tier)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		return tier switch
		{
			1 => ((object)new TextObject("{=AIInfluence_MedTier1}Basic", (Dictionary<string, object>)null)).ToString(), 
			2 => ((object)new TextObject("{=AIInfluence_MedTier2}Standard", (Dictionary<string, object>)null)).ToString(), 
			3 => ((object)new TextObject("{=AIInfluence_MedTier3}Advanced", (Dictionary<string, object>)null)).ToString(), 
			4 => ((object)new TextObject("{=AIInfluence_MedTier4}Elite", (Dictionary<string, object>)null)).ToString(), 
			_ => ((object)new TextObject("{=AIInfluence_MedTier1}Basic", (Dictionary<string, object>)null)).ToString(), 
		};
	}

	public static bool IsKingdomCapital(Settlement settlement)
	{
		if (settlement == null || !settlement.IsTown)
		{
			return false;
		}
		foreach (Kingdom item in (List<Kingdom>)(object)Kingdom.All)
		{
			if (!((List<Settlement>)(object)item.Settlements).Contains(settlement))
			{
				continue;
			}
			Hero leader = item.Leader;
			Clan val = ((leader != null) ? leader.Clan : null);
			if (val == null)
			{
				continue;
			}
			List<Settlement> list = (from s in (IEnumerable<Settlement>)val.Settlements
				where s.IsTown
				orderby s.Town.Prosperity descending
				select s).ToList();
			Settlement val2 = (Settlement)((list.Count <= 0) ? ((object)(from s in (IEnumerable<Settlement>)item.Settlements
				where s.IsTown
				orderby s.Town.Prosperity descending
				select s).FirstOrDefault()) : ((object)list[0]));
			return settlement == val2;
		}
		return false;
	}

	public static bool TreatHero(Hero hero, DiseaseInstance instance, Settlement settlement)
	{
		if (hero == null || instance == null || settlement == null)
		{
			return false;
		}
		int treatmentCost = GetTreatmentCost(hero, instance, settlement);
		if (hero.Gold < treatmentCost)
		{
			LogMessage($"[TREATMENT] {hero.Name} cannot afford treatment ({treatmentCost} gold)");
			return false;
		}
		hero.Gold -= treatmentCost;
		int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, hero);
		float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		instance.StartTreatment(tierRecoveryBonus);
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		LogMessage(string.Format("[TREATMENT] {0} started treatment for {1} at {2} (cost: {3}, tier: {4})", hero.Name, disease?.Name ?? "unknown", settlement.Name, treatmentCost, effectiveMedicalTier));
		return true;
	}

	public static bool TreatCompanion(Hero companion, DiseaseInstance instance, Settlement settlement, Hero payer)
	{
		if (companion == null || instance == null || settlement == null || payer == null)
		{
			return false;
		}
		int treatmentCost = GetTreatmentCost(companion, instance, settlement);
		if (payer.Gold < treatmentCost)
		{
			LogMessage($"[TREATMENT] {payer.Name} cannot afford treatment for {companion.Name} ({treatmentCost} gold)");
			return false;
		}
		payer.Gold -= treatmentCost;
		int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, companion);
		float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		instance.StartTreatment(tierRecoveryBonus);
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		LogMessage(string.Format("[TREATMENT] {0} started treatment for {1} (paid by {2}, tier: {3})", companion.Name, disease?.Name ?? "unknown", payer.Name, effectiveMedicalTier));
		return true;
	}

	public static bool TreatAIHero(Hero hero, DiseaseInstance instance, Settlement settlement)
	{
		if (hero == null || instance == null || settlement == null)
		{
			return false;
		}
		if (hero.IsNotable || hero.IsWanderer || (hero.Clan == null && hero.CurrentSettlement != null))
		{
			int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, hero);
			float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
			instance.StartTreatment(tierRecoveryBonus);
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
			LogMessage(string.Format("[TREATMENT] {0} (notable/wanderer/settlement) received free treatment at {1} for {2} (tier: {3})", hero.Name, settlement.Name, disease?.Name ?? "unknown", effectiveMedicalTier));
			return true;
		}
		int treatmentCost = GetTreatmentCost(hero, instance, settlement);
		if (hero.Gold < treatmentCost)
		{
			if (hero.Clan != null && hero.Clan == Clan.PlayerClan)
			{
				int num = treatmentCost - hero.Gold;
				int gold = hero.Gold;
				hero.Gold = 0;
				DiseaseTreatmentExpensePatch.AddDebt(hero.Clan, num);
				int effectiveMedicalTier2 = GetEffectiveMedicalTier(settlement, hero);
				float tierRecoveryBonus2 = GetTierRecoveryBonus(effectiveMedicalTier2);
				instance.StartTreatment(tierRecoveryBonus2);
				Disease disease2 = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
				ShowAITreatmentNotification(hero, disease2, settlement);
				LogMessage($"[TREATMENT] {hero.Name} (player companion) started treatment: paid {gold}/{treatmentCost}, " + $"{num} deferred to clan income (tier: {effectiveMedicalTier2})");
				return true;
			}
			Clan clan = hero.Clan;
			Hero val = ((clan != null) ? clan.Leader : null);
			if (val != null && val != hero && val.IsAlive)
			{
				int val2 = treatmentCost - hero.Gold;
				int num2 = Math.Min(val2, val.Gold);
				if (num2 > 0)
				{
					val.Gold -= num2;
					hero.Gold += num2;
					LogMessage($"[TREATMENT] Clan leader {val.Name} funded {num2} gold for {hero.Name}'s treatment");
				}
			}
		}
		if (hero.Gold >= treatmentCost)
		{
			hero.Gold -= treatmentCost;
			int effectiveMedicalTier3 = GetEffectiveMedicalTier(settlement, hero);
			float tierRecoveryBonus3 = GetTierRecoveryBonus(effectiveMedicalTier3);
			instance.StartTreatment(tierRecoveryBonus3);
			Disease disease3 = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
			ShowAITreatmentNotification(hero, disease3, settlement);
			LogMessage($"[TREATMENT] {hero.Name} started treatment at {settlement.Name} (tier: {effectiveMedicalTier3})");
			return true;
		}
		LogMessage($"[TREATMENT] {hero.Name} and clan cannot afford treatment ({treatmentCost} gold needed)");
		return false;
	}

	private static void ShowAITreatmentNotification(Hero hero, Disease disease, Settlement settlement)
	{
		if (hero != null && settlement != null && (hero.IsLord || hero.IsWanderer))
		{
			HospitalVisitSettlementNotification.NotifyHeroVisitedHospital(hero, settlement);
		}
	}

	public static bool TreatHeroWithHerb(Hero hero, DiseaseInstance instance, Settlement settlement, HealingHerb herb)
	{
		if (hero == null || instance == null || settlement == null || herb == null)
		{
			return false;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return false;
		}
		int num = GetHerbTreatmentCost(herb, disease);
		float herbCostReduction = DiseasePerkBonuses.GetHerbCostReduction(settlement);
		if (herbCostReduction > 0f)
		{
			num = Math.Max(1, (int)((float)num * (1f - herbCostReduction)));
		}
		if (hero.Gold < num)
		{
			LogMessage($"[TREATMENT] {hero.Name} cannot afford treatment with {herb.Name} ({num} gold)");
			return false;
		}
		hero.Gold -= num;
		float treatmentRecoveryBonus = herb.GetTreatmentRecoveryBonus();
		instance.StartTreatment(treatmentRecoveryBonus);
		LogMessage($"[TREATMENT] {hero.Name} started treatment for {disease.Name} with {herb.Name} at {settlement.Name} (cost: {num}, recovery: x{treatmentRecoveryBonus:F1})");
		return true;
	}

	public static bool TreatHeroGeneral(Hero hero, Settlement settlement, HealingHerb herb = null)
	{
		if (hero == null || settlement == null)
		{
			return false;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(hero);
		if (list == null || list.Count == 0)
		{
			return false;
		}
		List<DiseaseInstance> list2 = list.Where((DiseaseInstance i) => !i.IsTreated && !i.HasPostTreatmentEffect).ToList();
		if (list2.Count == 0)
		{
			return false;
		}
		int generalTreatmentCost = GetGeneralTreatmentCost(hero, settlement, herb);
		if (hero.Gold < generalTreatmentCost)
		{
			LogMessage($"[TREATMENT] {hero.Name} cannot afford general treatment ({generalTreatmentCost} gold)");
			return false;
		}
		hero.Gold -= generalTreatmentCost;
		float qualityBonus;
		if (herb != null)
		{
			qualityBonus = herb.GetTreatmentRecoveryBonus();
		}
		else
		{
			int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, hero);
			qualityBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		}
		foreach (DiseaseInstance item in list2)
		{
			item.StartTreatment(qualityBonus);
			LogMessage(string.Format(arg1: (DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId))?.Name ?? "unknown", format: "[TREATMENT] {0} started treatment for {1} (General Treatment, cost: {2} total)", arg0: hero.Name, arg2: generalTreatmentCost));
		}
		return true;
	}

	public static bool TreatCompanionGeneral(Hero companion, Settlement settlement, Hero payer, HealingHerb herb = null)
	{
		if (companion == null || settlement == null || payer == null)
		{
			return false;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(companion);
		if (list == null || list.Count == 0)
		{
			return false;
		}
		List<DiseaseInstance> list2 = list.Where((DiseaseInstance i) => !i.IsTreated && !i.HasPostTreatmentEffect).ToList();
		if (list2.Count == 0)
		{
			return false;
		}
		int generalTreatmentCost = GetGeneralTreatmentCost(companion, settlement, herb);
		if (payer.Gold < generalTreatmentCost)
		{
			LogMessage($"[TREATMENT] {payer.Name} cannot afford companion treatment for {companion.Name} ({generalTreatmentCost} gold)");
			return false;
		}
		payer.Gold -= generalTreatmentCost;
		float qualityBonus;
		if (herb != null)
		{
			qualityBonus = herb.GetTreatmentRecoveryBonus();
		}
		else
		{
			int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, companion);
			qualityBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		}
		foreach (DiseaseInstance item in list2)
		{
			item.StartTreatment(qualityBonus);
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			LogMessage(string.Format("[TREATMENT] {0} started treatment for {1} (paid by {2}, herb: {3})", companion.Name, disease?.Name ?? "unknown", payer.Name, (herb != null) ? herb.Name.ToString() : "standard"));
		}
		return true;
	}

	public static int GetGeneralTreatmentCost(Hero hero, Settlement settlement, HealingHerb herb = null)
	{
		if (hero == null || settlement == null)
		{
			return 0;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(hero);
		if (list == null || list.Count == 0)
		{
			return 0;
		}
		List<DiseaseInstance> list2 = list.Where((DiseaseInstance i) => !i.IsTreated && !i.HasPostTreatmentEffect).ToList();
		if (list2.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (DiseaseInstance item in list2)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease != null)
			{
				num = ((herb == null) ? (num + GetTreatmentCost(hero, item, settlement)) : (num + GetHerbTreatmentCost(herb, disease)));
			}
		}
		return num;
	}

	public static int GetHerbTreatmentCost(HealingHerb herb, Disease disease)
	{
		if (herb == null || disease == null)
		{
			return 0;
		}
		float num = 1f + (float)(disease.Severity - 1) * 0.5f;
		return Math.Max(1, (int)((float)herb.Cost * num));
	}

	public static int GetRecoveryTimeWithHerb(Hero hero, DiseaseInstance instance, HealingHerb herb)
	{
		if (hero == null || instance == null || herb == null)
		{
			return 0;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return 0;
		}
		float baseRecoveryRate = disease.GetBaseRecoveryRate();
		int maxTreatmentDays = disease.GetMaxTreatmentDays();
		float treatmentRecoveryBonus = herb.GetTreatmentRecoveryBonus();
		float diseaseProgress = instance.DiseaseProgress;
		if (diseaseProgress <= 0f)
		{
			return 0;
		}
		int combinedMedicineSkill = GetCombinedMedicineSkill(hero);
		float num = DiseaseEffectSystem.CalculateTreatmentSuccessChance(disease, treatmentRecoveryBonus, combinedMedicineSkill);
		float num2 = num / 100f;
		int num3 = 0;
		float num4 = diseaseProgress;
		for (int i = 0; i < maxTreatmentDays; i++)
		{
			if (!(num4 > 0f))
			{
				break;
			}
			float num5 = Math.Max(0f, 1f - (float)i / (float)maxTreatmentDays);
			float progressDifficultyMultiplier = DiseaseEffectSystem.GetProgressDifficultyMultiplier(num4);
			float num6 = baseRecoveryRate * num5 * treatmentRecoveryBonus * num2 * progressDifficultyMultiplier;
			num4 = Math.Max(0f, num4 - num6);
			num3++;
		}
		float num7 = baseRecoveryRate * treatmentRecoveryBonus * 0.5f;
		for (int j = 0; j < maxTreatmentDays; j++)
		{
			if (!(num4 > 0f))
			{
				break;
			}
			float progressDifficultyMultiplier2 = DiseaseEffectSystem.GetProgressDifficultyMultiplier(num4);
			num4 = Math.Max(0f, num4 - num7 * progressDifficultyMultiplier2);
			num3++;
		}
		if (num4 > 0f)
		{
			float num8 = diseaseProgress - num4;
			if (num8 > 0f)
			{
				int num9 = (int)Math.Ceiling(num4 / num8);
				num3 += num9 * (maxTreatmentDays * 2);
			}
			else
			{
				num3 = 100;
			}
		}
		return num3;
	}

	public static bool TreatTroops(DiseaseInstance instance, Settlement settlement, Hero payer)
	{
		if (instance == null || settlement == null || payer == null)
		{
			return false;
		}
		int troopTreatmentCost = GetTroopTreatmentCost(instance, settlement);
		if (payer.Gold < troopTreatmentCost)
		{
			LogMessage($"[TREATMENT] {payer.Name} cannot afford troop treatment ({troopTreatmentCost} gold)");
			return false;
		}
		payer.Gold -= troopTreatmentCost;
		int effectiveMedicalTier = GetEffectiveMedicalTier(settlement);
		float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		instance.StartTreatment(tierRecoveryBonus);
		LogMessage(string.Format("[TREATMENT] Troops started treatment for {0} (cost: {1}, tier: {2})", (DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId))?.Name ?? "unknown", troopTreatmentCost, effectiveMedicalTier));
		return true;
	}

	public static bool TreatTroopsFree(DiseaseInstance instance, Settlement settlement, string ownerDisplayName)
	{
		if (instance == null || settlement == null)
		{
			return false;
		}
		int effectiveMedicalTier = GetEffectiveMedicalTier(settlement);
		float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		instance.StartTreatment(tierRecoveryBonus);
		LogMessage(string.Format("[TREATMENT] Troops (no payer) started treatment for {0} (tier: {1}, owner: {2})", (DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId))?.Name ?? "unknown", effectiveMedicalTier, ownerDisplayName ?? "?"));
		return true;
	}

	public static bool TreatTroopsWithHerb(DiseaseInstance instance, Settlement settlement, HealingHerb herb, Hero payer)
	{
		if (instance == null || settlement == null || herb == null || payer == null)
		{
			return false;
		}
		int troopTreatmentCostWithHerb = GetTroopTreatmentCostWithHerb(instance, settlement, herb);
		if (payer.Gold < troopTreatmentCostWithHerb)
		{
			LogMessage($"[TREATMENT] {payer.Name} cannot afford troop treatment with {herb.Name} ({troopTreatmentCostWithHerb} gold)");
			return false;
		}
		payer.Gold -= troopTreatmentCostWithHerb;
		float treatmentRecoveryBonus = herb.GetTreatmentRecoveryBonus();
		instance.StartTreatment(treatmentRecoveryBonus);
		LogMessage(string.Format("[TREATMENT] Troops started treatment for {0} with {1} (cost: {2})", (DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId))?.Name ?? "unknown", herb.Name, troopTreatmentCostWithHerb));
		return true;
	}

	public static int GetTroopTreatmentCost(DiseaseInstance instance, Settlement settlement)
	{
		if (instance == null || settlement == null)
		{
			return 0;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return 0;
		}
		float num = GlobalSettings<ModSettings>.Instance?.DiseaseTreatmentBaseCost ?? 100f;
		int medicalTier = GetMedicalTier(settlement);
		float tierCostMultiplier = GetTierCostMultiplier(medicalTier);
		float num2 = GlobalSettings<ModSettings>.Instance?.DiseaseTreatmentTroopMultiplier ?? 0.5f;
		int num3 = (int)(num * (float)disease.Severity * tierCostMultiplier);
		float num4 = (float)Math.Sqrt(instance.InfectedTroopCount);
		return Math.Max(1, (int)((float)num3 * num4 * num2));
	}

	public static int GetTroopTreatmentCostWithHerb(DiseaseInstance instance, Settlement settlement, HealingHerb herb)
	{
		if (instance == null || settlement == null || herb == null)
		{
			return 0;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return 0;
		}
		int herbTreatmentCost = GetHerbTreatmentCost(herb, disease);
		float num = GlobalSettings<ModSettings>.Instance?.DiseaseTreatmentTroopMultiplier ?? 0.5f;
		float num2 = (float)Math.Sqrt(instance.InfectedTroopCount);
		int num3 = Math.Max(1, (int)((float)herbTreatmentCost * num2 * num));
		float herbCostReduction = DiseasePerkBonuses.GetHerbCostReduction(settlement);
		if (herbCostReduction > 0f)
		{
			num3 = Math.Max(1, (int)((float)num3 * (1f - herbCostReduction)));
		}
		return num3;
	}

	public static void AutoTreatSettlementForces(Settlement settlement, SettlementDiseaseInstance instance, Disease disease)
	{
		if (settlement != null && instance != null && disease != null && instance.NeedsAutoTreatment())
		{
			int effectiveMedicalTier = GetEffectiveMedicalTier(settlement);
			float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
			float baseRecoveryRate = disease.GetBaseRecoveryRate();
			float progressDifficultyMultiplier = DiseaseEffectSystem.GetProgressDifficultyMultiplier(instance.InfectionProgress);
			float num = baseRecoveryRate * tierRecoveryBonus * progressDifficultyMultiplier;
			DiseaseManager instance2 = DiseaseManager.Instance;
			if (instance2 != null && instance2.IsSettlementUnderQuarantine(settlement))
			{
				num *= DiseaseSpreadSystem.QuarantineTreatmentBonus;
			}
			instance.InfectionProgress = Math.Max(0f, instance.InfectionProgress - num);
			instance.IsTreated = true;
			instance.MarkAutoTreatmentDone();
			LogMessage($"[TREATMENT] Auto-treated {instance.TargetType} in {settlement.Name}: progress now {instance.InfectionProgress:F1}% (tier: {effectiveMedicalTier})");
			HospitalVisitSettlementNotification.NotifySettlementForceTreated(settlement, instance.TargetType);
		}
	}

	public static int GetTreatmentCost(Hero hero, DiseaseInstance instance, Settlement settlement)
	{
		if (hero == null || instance == null || settlement == null)
		{
			return 0;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return 0;
		}
		float num = GlobalSettings<ModSettings>.Instance?.DiseaseTreatmentBaseCost ?? 100f;
		int medicalTier = GetMedicalTier(settlement);
		float tierCostMultiplier = GetTierCostMultiplier(medicalTier);
		return (int)(num * (float)disease.Severity * tierCostMultiplier);
	}

	public static int GetRecoveryTime(Hero hero, DiseaseInstance instance, Settlement settlement)
	{
		if (hero == null || instance == null || settlement == null)
		{
			return 0;
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return 0;
		}
		float baseRecoveryRate = disease.GetBaseRecoveryRate();
		int maxTreatmentDays = disease.GetMaxTreatmentDays();
		int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, hero);
		float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		float diseaseProgress = instance.DiseaseProgress;
		if (diseaseProgress <= 0f)
		{
			return 0;
		}
		int combinedMedicineSkill = GetCombinedMedicineSkill(hero);
		float num = DiseaseEffectSystem.CalculateTreatmentSuccessChance(disease, tierRecoveryBonus, combinedMedicineSkill);
		float num2 = num / 100f;
		int num3 = 0;
		float num4 = diseaseProgress;
		for (int i = 0; i < maxTreatmentDays; i++)
		{
			if (!(num4 > 0f))
			{
				break;
			}
			float num5 = Math.Max(0f, 1f - (float)i / (float)maxTreatmentDays);
			float progressDifficultyMultiplier = DiseaseEffectSystem.GetProgressDifficultyMultiplier(num4);
			float num6 = baseRecoveryRate * num5 * tierRecoveryBonus * num2 * progressDifficultyMultiplier;
			num4 = Math.Max(0f, num4 - num6);
			num3++;
		}
		float num7 = baseRecoveryRate * tierRecoveryBonus * 0.5f;
		for (int j = 0; j < maxTreatmentDays; j++)
		{
			if (!(num4 > 0f))
			{
				break;
			}
			float progressDifficultyMultiplier2 = DiseaseEffectSystem.GetProgressDifficultyMultiplier(num4);
			num4 = Math.Max(0f, num4 - num7 * progressDifficultyMultiplier2);
			num3++;
		}
		if (num4 > 0f)
		{
			float num8 = diseaseProgress - num4;
			if (num8 > 0f)
			{
				int num9 = (int)Math.Ceiling(num4 / num8);
				num3 += num9 * (maxTreatmentDays * 2);
			}
			else
			{
				num3 = 100;
			}
		}
		return num3;
	}

	public static void UpdateTreatmentEffectiveness(DiseaseInstance instance, Disease disease)
	{
		if (instance != null && disease != null && instance.IsTreated)
		{
			int maxTreatmentDays = disease.GetMaxTreatmentDays();
			int daysSinceTreatmentStart = instance.DaysSinceTreatmentStart;
			instance.TreatmentEffectiveness = Math.Max(0f, 1f - (float)daysSinceTreatmentStart / (float)maxTreatmentDays);
			if (instance.TreatmentEffectiveness < 0.5f && instance.TreatmentEffectiveness > 0f)
			{
				LogMessage($"[TREATMENT] Treatment effectiveness low: {instance.TreatmentEffectiveness:P0}");
			}
		}
	}

	public static bool ShouldRetreatment(DiseaseInstance instance)
	{
		if (instance == null)
		{
			return false;
		}
		if (instance.IsTreated && instance.TreatmentEffectiveness < 0.5f)
		{
			return true;
		}
		if (!instance.IsTreated && !instance.HasPostTreatmentEffect && instance.DiseaseProgress > 0f)
		{
			return true;
		}
		return false;
	}

	public static List<Hero> GetAvailableCompanionsForTreatment(Settlement settlement)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		List<Hero> list = new List<Hero>();
		if (settlement == null || Hero.MainHero == null)
		{
			return list;
		}
		if (MobileParty.MainParty != null)
		{
			foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)MobileParty.MainParty.MemberRoster.GetTroopRoster())
			{
				CharacterObject character = item.Character;
				if (((character != null) ? character.HeroObject : null) != null && item.Character.HeroObject != Hero.MainHero && item.Character.HeroObject.IsPlayerCompanion)
				{
					Hero heroObject = item.Character.HeroObject;
					DiseaseManager instance = DiseaseManager.Instance;
					if (instance != null && instance.IsHeroInfected(heroObject))
					{
						list.Add(heroObject);
					}
				}
			}
		}
		foreach (MobileParty item2 in ((IEnumerable<MobileParty>)MobileParty.All).Where((MobileParty p) => p.CurrentSettlement == settlement))
		{
			Hero leaderHero = item2.LeaderHero;
			if (leaderHero != null && leaderHero.IsPlayerCompanion && item2.LeaderHero != Hero.MainHero)
			{
				DiseaseManager instance2 = DiseaseManager.Instance;
				if (instance2 != null && instance2.IsHeroInfected(item2.LeaderHero) && !list.Contains(item2.LeaderHero))
				{
					list.Add(item2.LeaderHero);
				}
			}
		}
		return list;
	}

	public static List<(DiseaseInstance instance, Disease disease)> GetHeroDiseasesForTreatment(Hero hero)
	{
		List<(DiseaseInstance, Disease)> list = new List<(DiseaseInstance, Disease)>();
		if (hero == null)
		{
			return list;
		}
		List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(hero);
		if (list2 == null)
		{
			return list;
		}
		foreach (DiseaseInstance item in list2)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease != null)
			{
				list.Add((item, disease));
			}
		}
		return list;
	}

	public static (int infectedCount, int totalCount, float progress, Dictionary<int, int> tierDistribution) GetPartyTroopInfectionInfo(MobileParty party)
	{
		if (party == null)
		{
			return (infectedCount: 0, totalCount: 0, progress: 0f, tierDistribution: new Dictionary<int, int>());
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		if (list == null || list.Count == 0)
		{
			TroopRoster memberRoster = party.MemberRoster;
			return (infectedCount: 0, totalCount: (memberRoster != null) ? memberRoster.TotalManCount : 0, progress: 0f, tierDistribution: new Dictionary<int, int>());
		}
		int num = 0;
		float num2 = 0f;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (DiseaseInstance item3 in list)
		{
			num += item3.InfectedTroopCount;
			num2 += item3.DiseaseProgress;
			foreach (KeyValuePair<int, int> item4 in item3.TroopTierDistribution)
			{
				if (dictionary.ContainsKey(item4.Key))
				{
					dictionary[item4.Key] += item4.Value;
				}
				else
				{
					dictionary[item4.Key] = item4.Value;
				}
			}
		}
		float item = ((list.Count > 0) ? (num2 / (float)list.Count) : 0f);
		int item2 = num;
		TroopRoster memberRoster2 = party.MemberRoster;
		return (infectedCount: item2, totalCount: (memberRoster2 != null) ? memberRoster2.TotalManCount : 0, progress: item, tierDistribution: dictionary);
	}

	public static int GetCombinedMedicineSkill(Hero hero)
	{
		if (hero == null)
		{
			return 0;
		}
		MobileParty partyBelongedTo = hero.PartyBelongedTo;
		if (partyBelongedTo != null)
		{
			Hero effectiveSurgeon = partyBelongedTo.EffectiveSurgeon;
			return (effectiveSurgeon != null) ? effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine) : hero.GetSkillValue(DefaultSkills.Medicine);
		}
		return hero.GetSkillValue(DefaultSkills.Medicine);
	}

	public static float GetTreatmentSuccessChance(Hero hero, Disease disease, Settlement settlement)
	{
		if (hero == null || disease == null || settlement == null)
		{
			return 0f;
		}
		int effectiveMedicalTier = GetEffectiveMedicalTier(settlement, hero);
		float tierRecoveryBonus = GetTierRecoveryBonus(effectiveMedicalTier);
		int combinedMedicineSkill = GetCombinedMedicineSkill(hero);
		return DiseaseEffectSystem.CalculateTreatmentSuccessChance(disease, tierRecoveryBonus, combinedMedicineSkill);
	}

	public static float GetTreatmentSuccessChanceWithHerb(Hero hero, Disease disease, HealingHerb herb)
	{
		if (hero == null || disease == null || herb == null)
		{
			return 0f;
		}
		float treatmentRecoveryBonus = herb.GetTreatmentRecoveryBonus();
		int combinedMedicineSkill = GetCombinedMedicineSkill(hero);
		return DiseaseEffectSystem.CalculateTreatmentSuccessChance(disease, treatmentRecoveryBonus, combinedMedicineSkill);
	}

	private static void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
