using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public static class PreventionSystem
{
	private static HealingHerb[] _predefinedHerbs;

	public static HealingHerb[] AllHerbs => _predefinedHerbs ?? (_predefinedHerbs = HealingHerb.GetPredefinedHerbs());

	public static List<HealingHerb> GetAvailableHerbs(Settlement settlement)
	{
		List<HealingHerb> list = new List<HealingHerb>();
		if (settlement == null)
		{
			return list;
		}
		int medicalTier = TreatmentSystem.GetMedicalTier(settlement);
		int tierMaxHerbStrength = TreatmentSystem.GetTierMaxHerbStrength(medicalTier);
		HealingHerb[] allHerbs = AllHerbs;
		foreach (HealingHerb healingHerb in allHerbs)
		{
			if (healingHerb.Strength <= tierMaxHerbStrength)
			{
				list.Add(healingHerb);
			}
		}
		return list;
	}

	public static HealingHerb GetHerbById(string herbId)
	{
		return AllHerbs.FirstOrDefault((HealingHerb h) => h.Id == herbId);
	}

	public static int GetHerbCost(HealingHerb herb, Settlement settlement)
	{
		if (herb == null)
		{
			return 0;
		}
		float num = herb.Cost;
		float num2 = GlobalSettings<ModSettings>.Instance?.DiseasePreventionHerbCostMultiplier ?? 1f;
		return Math.Max(1, (int)(num * num2));
	}

	public static bool BuyHerb(Hero hero, HealingHerb herb, Settlement settlement)
	{
		if (hero == null || herb == null || settlement == null)
		{
			return false;
		}
		List<HealingHerb> availableHerbs = GetAvailableHerbs(settlement);
		if (!availableHerbs.Any((HealingHerb h) => h.Id == herb.Id))
		{
			LogMessage($"[PREVENTION] Herb {herb.Name} not available in {settlement.Name}");
			return false;
		}
		int herbCost = GetHerbCost(herb, settlement);
		if (hero.Gold < herbCost)
		{
			LogMessage($"[PREVENTION] {hero.Name} cannot afford {herb.Name} ({herbCost} gold)");
			return false;
		}
		hero.Gold -= herbCost;
		UseHerb(hero, herb);
		LogMessage($"[PREVENTION] {hero.Name} bought and used {herb.Name} for {herbCost} gold");
		return true;
	}

	public static void UseHerb(Hero hero, HealingHerb herb)
	{
		if (hero != null && herb != null)
		{
			List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(hero);
			if (list != null && list.Count > 0)
			{
				DiseaseInstance diseaseInstance = list[0];
				diseaseInstance.ApplyPrevention(herb.Strength, herb.DurationDays);
				return;
			}
			LogMessage($"[PREVENTION] {hero.Name} used {herb.Name} (Strength {herb.Strength}, Duration {herb.DurationDays} days)");
		}
	}

	public static float ApplyPreventionBonus(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return 0f;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(hero);
		if (list == null)
		{
			return 0f;
		}
		foreach (DiseaseInstance item in list)
		{
			if (item.HasPreventionEffect && !item.IsPreventionExpired())
			{
				return ImmunitySystem.GetPreventionBonus(item.PreventionStrength);
			}
		}
		return 0f;
	}

	public static void CheckPreventionExpiration()
	{
		IReadOnlyList<DiseaseInstance> readOnlyList = DiseaseManager.Instance?.DiseaseInstances;
		if (readOnlyList == null)
		{
			return;
		}
		foreach (DiseaseInstance instance in readOnlyList)
		{
			if (instance.HasPreventionEffect && instance.IsPreventionExpired())
			{
				instance.RemovePrevention();
				Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == instance.TargetId));
				if (val != null)
				{
					LogMessage($"[PREVENTION] Prevention effect expired for {val.Name}");
				}
			}
		}
	}

	public static string GetHerbInfoForDisplay(HealingHerb herb, Settlement settlement)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		if (herb == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("**" + herb.Name + "**");
		stringBuilder.AppendLine("_" + herb.Description + "_");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(string.Format("{0}: {1}/5", ((object)new TextObject("{=AIInfluence_Herb_Strength}Strength", (Dictionary<string, object>)null)).ToString(), herb.Strength));
		stringBuilder.AppendLine(string.Format("{0}: +{1:F0}%", ((object)new TextObject("{=AIInfluence_Herb_ImmunityBonus}Immunity bonus", (Dictionary<string, object>)null)).ToString(), herb.ImmunityBonus * 100f));
		TextObject arg = new TextObject("{=AIInfluence_Herb_Duration}Duration", (Dictionary<string, object>)null);
		TextObject val = new TextObject("{=AIInfluence_Herb_DurationDays}{DAYS} days", (Dictionary<string, object>)null);
		val.SetTextVariable("DAYS", herb.DurationDays);
		stringBuilder.AppendLine($"{arg}: {val}");
		if (settlement != null)
		{
			int herbCost = GetHerbCost(herb, settlement);
			TextObject arg2 = new TextObject("{=AIInfluence_Herb_Cost}Cost", (Dictionary<string, object>)null);
			TextObject val2 = new TextObject("{=AIInfluence_Herb_CostGold}{COST} gold", (Dictionary<string, object>)null);
			val2.SetTextVariable("COST", herbCost);
			stringBuilder.AppendLine($"{arg2}: {val2}");
		}
		return stringBuilder.ToString();
	}

	private static void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
