using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(TooltipRefresherCollection), "RefreshMobilePartyTooltip")]
public static class DiseasePartyTooltipPatch
{
	[HarmonyPostfix]
	public static void Postfix(PropertyBasedTooltipVM propertyBasedTooltipVM, object[] args)
	{
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Expected O, but got Unknown
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Expected O, but got Unknown
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Expected O, but got Unknown
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Expected O, but got Unknown
		try
		{
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance == null || !instance.EnableDiseaseSystem || DiseaseManager.Instance == null)
			{
				return;
			}
			object obj = args[0];
			MobileParty val = (MobileParty)((obj is MobileParty) ? obj : null);
			if (val == null)
			{
				return;
			}
			bool flag = val.LeaderHero != null && DiseaseManager.Instance.IsHeroInfected(val.LeaderHero);
			bool flag2 = DiseaseManager.Instance.PartyHasInfectedTroops(val);
			bool flag3 = GetInfectedCompanions(val).Any();
			int num;
			if (val == MobileParty.MainParty)
			{
				List<DiseaseInstance> partyPrisonerDiseases = DiseaseManager.Instance.GetPartyPrisonerDiseases(val);
				num = (((partyPrisonerDiseases != null && partyPrisonerDiseases.Any((DiseaseInstance d) => !d.IsRecovered)) || GetInfectedPrisonerLords(val).Any()) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag4 = (byte)num != 0;
			if (!flag && !flag2 && !flag3 && !flag4)
			{
				return;
			}
			MBBindingList<TooltipProperty> tooltipPropertyList = propertyBasedTooltipVM.TooltipPropertyList;
			List<TooltipProperty> list = new List<TooltipProperty>();
			if (!((TooltipBaseVM)propertyBasedTooltipVM).IsExtended && ((Collection<TooltipProperty>)(object)tooltipPropertyList).Count >= 2)
			{
				list.Add(((Collection<TooltipProperty>)(object)tooltipPropertyList)[((Collection<TooltipProperty>)(object)tooltipPropertyList).Count - 2]);
				list.Add(((Collection<TooltipProperty>)(object)tooltipPropertyList)[((Collection<TooltipProperty>)(object)tooltipPropertyList).Count - 1]);
				((Collection<TooltipProperty>)(object)tooltipPropertyList).RemoveAt(((Collection<TooltipProperty>)(object)tooltipPropertyList).Count - 1);
				((Collection<TooltipProperty>)(object)tooltipPropertyList).RemoveAt(((Collection<TooltipProperty>)(object)tooltipPropertyList).Count - 1);
			}
			propertyBasedTooltipVM.AddProperty(string.Empty, string.Empty, -1, (TooltipPropertyFlags)0);
			propertyBasedTooltipVM.AddProperty(((object)new TextObject("{=AIInfluence_DiseaseTooltipHeader}Disease", (Dictionary<string, object>)null)).ToString(), " ", 0, (TooltipPropertyFlags)0);
			propertyBasedTooltipVM.AddProperty("", "", 0, (TooltipPropertyFlags)512);
			if (flag && val.LeaderHero != null)
			{
				List<DiseaseInstance> heroDiseases = DiseaseManager.Instance.GetHeroDiseases(val.LeaderHero);
				foreach (DiseaseInstance item in heroDiseases)
				{
					Disease diseaseById = DiseaseManager.Instance.GetDiseaseById(item.DiseaseId);
					if (diseaseById != null)
					{
						string text = ((object)val.LeaderHero.Name).ToString();
						string text2 = diseaseById.Name;
						if (((TooltipBaseVM)propertyBasedTooltipVM).IsExtended)
						{
							text2 += $" ({item.DiseaseProgress:F0}%)";
						}
						propertyBasedTooltipVM.AddProperty(text, text2, 0, (TooltipPropertyFlags)0);
					}
				}
			}
			foreach (Hero infectedCompanion in GetInfectedCompanions(val))
			{
				List<DiseaseInstance> heroDiseases2 = DiseaseManager.Instance.GetHeroDiseases(infectedCompanion);
				foreach (DiseaseInstance item2 in heroDiseases2)
				{
					Disease diseaseById2 = DiseaseManager.Instance.GetDiseaseById(item2.DiseaseId);
					if (diseaseById2 != null)
					{
						string text3 = ((object)infectedCompanion.Name).ToString();
						string text4 = diseaseById2.Name;
						if (((TooltipBaseVM)propertyBasedTooltipVM).IsExtended)
						{
							text4 += $" ({item2.DiseaseProgress:F0}%)";
						}
						propertyBasedTooltipVM.AddProperty(text3, text4, 0, (TooltipPropertyFlags)0);
					}
				}
			}
			if (flag2)
			{
				float partyInfectionRate = DiseaseManager.Instance.GetPartyInfectionRate(val);
				TextObject val2 = new TextObject("{=AIInfluence_DiseaseTooltipTroopsInfected}{RATE}% of troops infected", (Dictionary<string, object>)null);
				val2.SetTextVariable("RATE", partyInfectionRate.ToString("F0"));
				propertyBasedTooltipVM.AddProperty(((object)new TextObject("{=AIInfluence_DiseaseTooltipTroops}Troops", (Dictionary<string, object>)null)).ToString(), ((object)val2).ToString(), 0, (TooltipPropertyFlags)0);
				if (((TooltipBaseVM)propertyBasedTooltipVM).IsExtended)
				{
					List<DiseaseInstance> partyDiseases = DiseaseManager.Instance.GetPartyDiseases(val);
					foreach (DiseaseInstance item3 in partyDiseases)
					{
						Disease diseaseById3 = DiseaseManager.Instance.GetDiseaseById(item3.DiseaseId);
						if (diseaseById3 != null)
						{
							TextObject val3 = new TextObject("{=AIInfluence_DiseaseTooltipTroopDetail}{COUNT} soldiers ({PROGRESS}%)", (Dictionary<string, object>)null);
							val3.SetTextVariable("COUNT", item3.InfectedTroopCount);
							val3.SetTextVariable("PROGRESS", item3.DiseaseProgress.ToString("F0"));
							propertyBasedTooltipVM.AddProperty("  " + diseaseById3.Name, ((object)val3).ToString(), 0, (TooltipPropertyFlags)0);
						}
					}
				}
			}
			if (flag4)
			{
				propertyBasedTooltipVM.AddProperty(string.Empty, string.Empty, -1, (TooltipPropertyFlags)0);
				propertyBasedTooltipVM.AddProperty(((object)new TextObject("{=AIInfluence_DiseaseTooltipPrisoners}Prisoner diseases", (Dictionary<string, object>)null)).ToString(), " ", 0, (TooltipPropertyFlags)0);
				propertyBasedTooltipVM.AddProperty("", "", 0, (TooltipPropertyFlags)512);
				foreach (Hero infectedPrisonerLord in GetInfectedPrisonerLords(val))
				{
					List<DiseaseInstance> heroDiseases3 = DiseaseManager.Instance.GetHeroDiseases(infectedPrisonerLord);
					foreach (DiseaseInstance item4 in heroDiseases3)
					{
						Disease diseaseById4 = DiseaseManager.Instance.GetDiseaseById(item4.DiseaseId);
						if (diseaseById4 != null)
						{
							string text5 = diseaseById4.Name;
							if (((TooltipBaseVM)propertyBasedTooltipVM).IsExtended)
							{
								text5 += $" ({item4.DiseaseProgress:F0}%)";
							}
							propertyBasedTooltipVM.AddProperty(((object)infectedPrisonerLord.Name).ToString(), text5, 0, (TooltipPropertyFlags)0);
						}
					}
				}
				List<DiseaseInstance> partyPrisonerDiseases2 = DiseaseManager.Instance.GetPartyPrisonerDiseases(val);
				if (partyPrisonerDiseases2 != null && partyPrisonerDiseases2.Count > 0)
				{
					TroopRoster prisonRoster = val.PrisonRoster;
					int num2 = ((prisonRoster != null) ? prisonRoster.TotalManCount : 0);
					int num3 = partyPrisonerDiseases2.Sum((DiseaseInstance d) => d.InfectedTroopCount);
					float num4 = ((num2 > 0) ? ((float)num3 / (float)num2 * 100f) : 0f);
					TextObject val4 = new TextObject("{=AIInfluence_DiseaseTooltipPrisonerTroops}{RATE}% infected ({COUNT}/{TOTAL})", (Dictionary<string, object>)null);
					val4.SetTextVariable("RATE", num4.ToString("F0"));
					val4.SetTextVariable("COUNT", num3);
					val4.SetTextVariable("TOTAL", num2);
					propertyBasedTooltipVM.AddProperty(((object)new TextObject("{=AIInfluence_DiseaseTooltipTroops}Troops", (Dictionary<string, object>)null)).ToString(), ((object)val4).ToString(), 0, (TooltipPropertyFlags)0);
					if (((TooltipBaseVM)propertyBasedTooltipVM).IsExtended)
					{
						foreach (DiseaseInstance item5 in partyPrisonerDiseases2)
						{
							Disease diseaseById5 = DiseaseManager.Instance.GetDiseaseById(item5.DiseaseId);
							if (diseaseById5 != null)
							{
								string text6 = (item5.IsTreated ? (" [" + ((object)new TextObject("{=AIInfluence_UnderTreatment}(under treatment)", (Dictionary<string, object>)null)).ToString() + "]") : "");
								TextObject val5 = new TextObject("{=AIInfluence_DiseaseTooltipTroopDetail}{COUNT} soldiers ({PROGRESS}%)", (Dictionary<string, object>)null);
								val5.SetTextVariable("COUNT", item5.InfectedTroopCount);
								val5.SetTextVariable("PROGRESS", item5.DiseaseProgress.ToString("F0"));
								propertyBasedTooltipVM.AddProperty("  " + diseaseById5.Name + text6, ((object)val5).ToString(), 0, (TooltipPropertyFlags)0);
							}
						}
					}
				}
			}
			foreach (TooltipProperty item6 in list)
			{
				((Collection<TooltipProperty>)(object)tooltipPropertyList).Add(item6);
			}
		}
		catch (Exception)
		{
		}
	}

	private static IEnumerable<Hero> GetInfectedCompanions(MobileParty party)
	{
		if (((party != null) ? party.MemberRoster : null) == null || DiseaseManager.Instance == null)
		{
			yield break;
		}
		Hero leader = party.LeaderHero;
		foreach (TroopRosterElement element in (List<TroopRosterElement>)(object)party.MemberRoster.GetTroopRoster())
		{
			CharacterObject character = element.Character;
			if (character != null && ((BasicCharacterObject)character).IsHero && element.Character.HeroObject != null)
			{
				Hero hero = element.Character.HeroObject;
				if (hero != leader && DiseaseManager.Instance.IsHeroInfected(hero))
				{
					yield return hero;
				}
			}
		}
	}

	private static IEnumerable<Hero> GetInfectedPrisonerLords(MobileParty party)
	{
		if (((party != null) ? party.PrisonRoster : null) == null || DiseaseManager.Instance == null)
		{
			yield break;
		}
		for (int i = 0; i < party.PrisonRoster.Count; i++)
		{
			TroopRosterElement element = party.PrisonRoster.GetElementCopyAtIndex(i);
			CharacterObject character = element.Character;
			if (character != null && ((BasicCharacterObject)character).IsHero)
			{
				Hero hero = element.Character.HeroObject;
				if (hero != null && DiseaseManager.Instance.IsHeroInfected(hero))
				{
					yield return hero;
				}
			}
		}
	}

	public static bool IsPartyInfected(MobileParty party)
	{
		if (party == null || DiseaseManager.Instance == null)
		{
			return false;
		}
		if (party.LeaderHero != null && DiseaseManager.Instance.IsHeroInfected(party.LeaderHero))
		{
			return true;
		}
		if (GetInfectedCompanions(party).Any())
		{
			return true;
		}
		if (DiseaseManager.Instance.PartyHasInfectedTroops(party))
		{
			return true;
		}
		return false;
	}

	public static string GetDiseaseTooltipText(MobileParty party)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		if (!IsPartyInfected(party))
		{
			return "";
		}
		return ((object)new TextObject("{=AIInfluence_DiseaseTooltipPossibleInfection} [Possibly infected...]", (Dictionary<string, object>)null)).ToString();
	}
}
