using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public static class DiseaseUI
{
	public static Color InfectionColor => Colors.Gray;

	public static Color RecoveryColor => ExtraColors.GreenAIInfluence;

	public static void NotifyPlayerInfection(bool isPlayerInfected, bool areTroopsInfected)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		if (isPlayerInfected)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_Disease_PlayerFeelsUnwell}You don't feel well...", (Dictionary<string, object>)null)).ToString(), Colors.Gray));
		}
		if (areTroopsInfected)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_Disease_TroopsSick}It seems the troops in your party have fallen ill.", (Dictionary<string, object>)null)).ToString(), Colors.Gray));
		}
	}

	public static void NotifyCompanionInfection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_Disease_CompanionFeelsUnwell}Someone among your companions in the party is feeling unwell...", (Dictionary<string, object>)null)).ToString(), Colors.Gray));
	}

	public static void NotifyPlayerRecovery(bool isPlayerRecovered, bool areTroopsRecovered)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		if (isPlayerRecovered)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_Disease_PlayerRecovered}You have fully recovered.", (Dictionary<string, object>)null)).ToString(), ExtraColors.GreenAIInfluence));
		}
		if (areTroopsRecovered)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_Disease_TroopsRecovered}Your troops have fully recovered.", (Dictionary<string, object>)null)).ToString(), ExtraColors.GreenAIInfluence));
		}
	}

	public static void NotifyLordDeathFromDisease(Hero hero, Disease disease)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		if (hero == null || disease == null)
		{
			return;
		}
		bool hasMet = hero.HasMet;
		if (hero.IsLord || hasMet)
		{
			TextObject val = new TextObject("{=AIInfluence_LordDeathFromDisease}{HERO_NAME} died from {DISEASE_NAME}", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", hero.Name);
			val.SetTextVariable("DISEASE_NAME", disease.Name);
			if (hero.Clan == Clan.PlayerClan || hasMet)
			{
				MBInformationManager.AddQuickInformation(val, 0, (BasicCharacterObject)(object)hero.CharacterObject, (Equipment)null, "");
			}
		}
	}

	public static string GetDiseaseInfoForDisplay(DiseaseInstance instance, Disease disease)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		if (instance == null || disease == null)
		{
			return ((object)new TextObject("{=AIInfluence_Disease_NoData}No disease data", (Dictionary<string, object>)null)).ToString();
		}
		StringBuilder stringBuilder = new StringBuilder();
		string arg = ((object)new TextObject("{=AIInfluence_Disease_Severity}Disease severity", (Dictionary<string, object>)null)).ToString();
		string arg2 = ((object)new TextObject("{=AIInfluence_Disease_Progress}Progress", (Dictionary<string, object>)null)).ToString();
		string arg3 = ((object)new TextObject("{=AIInfluence_Disease_TreatmentEffectiveness}Treatment effectiveness", (Dictionary<string, object>)null)).ToString();
		string text = ((object)new TextObject("{=AIInfluence_Disease_RetreatmentRecommended}Retreatment recommended", (Dictionary<string, object>)null)).ToString();
		string text2 = ((object)new TextObject("{=AIInfluence_Disease_Effects}Effects", (Dictionary<string, object>)null)).ToString();
		string arg4 = ((object)new TextObject("{=AIInfluence_Disease_CombatDamage}Damage", (Dictionary<string, object>)null)).ToString();
		string arg5 = ((object)new TextObject("{=AIInfluence_Disease_CombatSpeed}Attack/movement speed", (Dictionary<string, object>)null)).ToString();
		string arg6 = ((object)new TextObject("{=AIInfluence_Disease_Accuracy}Accuracy", (Dictionary<string, object>)null)).ToString();
		string arg7 = ((object)new TextObject("{=AIInfluence_Disease_Defense}Defense", (Dictionary<string, object>)null)).ToString();
		string arg8 = ((object)new TextObject("{=AIInfluence_Disease_MapSpeed}Party speed on map", (Dictionary<string, object>)null)).ToString();
		string arg9 = ((object)new TextObject("{=AIInfluence_Disease_Morale}Morale", (Dictionary<string, object>)null)).ToString();
		stringBuilder.AppendLine("<b>" + disease.Name + "</b>");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(disease.Description);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine($"{arg}: {disease.Severity}/5");
		stringBuilder.AppendLine($"{arg2}: {instance.DiseaseProgress:F1}%");
		if (instance.IsTreated)
		{
			stringBuilder.AppendLine($"{arg3}: {instance.TreatmentEffectiveness:P0}");
			if (instance.ShouldRetreat())
			{
				stringBuilder.AppendLine("  • " + text);
			}
		}
		else if (instance.HasPostTreatmentEffect)
		{
			string arg10 = ((object)new TextObject("{=AIInfluence_Disease_PostTreatment}Post-treatment recovery", (Dictionary<string, object>)null)).ToString();
			string arg11 = ((object)new TextObject("{=AIInfluence_Disease_DaysLeft}days left", (Dictionary<string, object>)null)).ToString();
			stringBuilder.AppendLine($"{arg10}: {instance.PostTreatmentDaysRemaining} {arg11} " + string.Format("(-{0:F1}%/{1})", instance.PostTreatmentRecoveryRate, ((object)new TextObject("{=AIInfluence_Disease_PerDay}day", (Dictionary<string, object>)null)).ToString()));
		}
		else if (instance.DiseaseProgress > 0f)
		{
			Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == instance.TargetId));
			MobileParty val2 = ((val != null) ? val.PartyBelongedTo : null);
			int? obj;
			if (val2 == null)
			{
				obj = null;
			}
			else
			{
				Hero effectiveSurgeon = val2.EffectiveSurgeon;
				obj = ((effectiveSurgeon != null) ? new int?(effectiveSurgeon.GetSkillValue(DefaultSkills.Medicine)) : ((int?)null));
			}
			int medicineSkill = obj ?? ((val != null) ? val.GetSkillValue(DefaultSkills.Medicine) : 0);
			if (!DiseaseEffectSystem.CheckNaturalRecovery(disease, medicineSkill))
			{
				stringBuilder.AppendLine("  • " + text);
			}
		}
		stringBuilder.AppendLine();
		if (disease.Effects != null)
		{
			stringBuilder.AppendLine("<b>" + text2 + "</b>");
			if (!(disease.Type == "seasonal") && disease.Effects.SkillModifiers != null && disease.Effects.SkillModifiers.Count > 0)
			{
				List<KeyValuePair<string, float>> list = disease.Effects.SkillModifiers.Where((KeyValuePair<string, float> kvp) => DiseaseEffects.PhysicalSkills.Contains(kvp.Key) && kvp.Value != 0f).ToList();
				List<KeyValuePair<string, float>> list2 = disease.Effects.SkillModifiers.Where((KeyValuePair<string, float> kvp) => !DiseaseEffects.PhysicalSkills.Contains(kvp.Key) && kvp.Value != 0f).ToList();
				if (list.Count > 0)
				{
					float physicalVal = list[0].Value;
					if (list.All((KeyValuePair<string, float> kvp) => Math.Abs(kvp.Value - physicalVal) < 0.01f))
					{
						string arg12 = ((object)new TextObject("{=AIInfluence_Disease_PhysicalSkills}Physical Skills", (Dictionary<string, object>)null)).ToString();
						string arg13 = ((physicalVal > 0f) ? "+" : "");
						stringBuilder.AppendLine($"  • {arg12}: {arg13}{physicalVal:F0}");
					}
					else
					{
						foreach (KeyValuePair<string, float> item in list)
						{
							string arg14 = ((item.Value > 0f) ? "+" : "");
							stringBuilder.AppendLine($"  • {item.Key}: {arg14}{item.Value:F0}");
						}
					}
				}
				foreach (KeyValuePair<string, float> item2 in list2)
				{
					string arg15 = ((item2.Value > 0f) ? "+" : "");
					stringBuilder.AppendLine($"  • {item2.Key}: {arg15}{item2.Value:F0}");
				}
			}
			if (disease.Effects.CombatModifiers != null)
			{
				CombatModifiers combatModifiers = disease.Effects.CombatModifiers;
				if (combatModifiers.DamageMultiplier != 1f)
				{
					float num = (1f - combatModifiers.DamageMultiplier) * 100f;
					stringBuilder.AppendLine($"  • {arg4}: -{num:F0}%");
				}
				if (combatModifiers.SpeedMultiplier != 1f)
				{
					float num2 = (1f - combatModifiers.SpeedMultiplier) * 100f;
					stringBuilder.AppendLine($"  • {arg5}: -{num2:F0}%");
				}
				if (combatModifiers.AccuracyMultiplier != 1f)
				{
					float num3 = (1f - combatModifiers.AccuracyMultiplier) * 100f;
					stringBuilder.AppendLine($"  • {arg6}: -{num3:F0}%");
				}
				if (combatModifiers.DefenseMultiplier != 1f)
				{
					float num4 = (1f - combatModifiers.DefenseMultiplier) * 100f;
					stringBuilder.AppendLine($"  • {arg7}: -{num4:F0}%");
				}
			}
			if (disease.Effects.MapModifiers != null)
			{
				MapModifiers mapModifiers = disease.Effects.MapModifiers;
				if (mapModifiers.MovementSpeedMultiplier != 1f)
				{
					float num5 = (1f - mapModifiers.MovementSpeedMultiplier) * 100f;
					stringBuilder.AppendLine($"  • {arg8}: -{num5:F0}%");
				}
				if (mapModifiers.MoraleModifier != 0f)
				{
					stringBuilder.AppendLine($"  • {arg9}: {mapModifiers.MoraleModifier:F0}");
				}
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public static string GetTroopInfectionInfoForDisplay(int infectedCount, int totalCount)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		float num = ((totalCount > 0) ? ((float)infectedCount / (float)totalCount * 100f) : 0f);
		string text = ((object)new TextObject("{=AIInfluence_Disease_TroopInfection}Troop infection", (Dictionary<string, object>)null)).ToString();
		string text2 = ((object)new TextObject("{=AIInfluence_Disease_InfectedCount}Infected", (Dictionary<string, object>)null)).ToString();
		stringBuilder.AppendLine("<b>" + text + "</b>");
		stringBuilder.AppendLine($"{text2}: {infectedCount} / {totalCount} ({num:F1}%)");
		return stringBuilder.ToString();
	}

	public static string GetDetailedTroopDiseaseInfoForDisplay(MobileParty party)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		if (party == null)
		{
			return "";
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		if (list == null || list.Count == 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		foreach (DiseaseInstance item in list)
		{
			num += item.InfectedTroopCount;
		}
		TroopRoster memberRoster = party.MemberRoster;
		int num2 = ((memberRoster != null) ? memberRoster.TotalManCount : 0);
		float num3 = ((num2 > 0) ? ((float)num / (float)num2 * 100f) : 0f);
		string text = ((object)new TextObject("{=AIInfluence_Disease_TroopInfection}Troop infection", (Dictionary<string, object>)null)).ToString();
		string text2 = ((object)new TextObject("{=AIInfluence_Disease_InfectedCount}Infected", (Dictionary<string, object>)null)).ToString();
		string text3 = ((object)new TextObject("{=AIInfluence_Disease_Soldiers}soldiers", (Dictionary<string, object>)null)).ToString();
		string arg = ((object)new TextObject("{=AIInfluence_Disease_CombatDamage}Damage", (Dictionary<string, object>)null)).ToString();
		string arg2 = ((object)new TextObject("{=AIInfluence_Disease_CombatSpeed}Attack/movement speed", (Dictionary<string, object>)null)).ToString();
		string arg3 = ((object)new TextObject("{=AIInfluence_Disease_Accuracy}Accuracy", (Dictionary<string, object>)null)).ToString();
		string arg4 = ((object)new TextObject("{=AIInfluence_Disease_Defense}Defense", (Dictionary<string, object>)null)).ToString();
		string arg5 = ((object)new TextObject("{=AIInfluence_Disease_MapSpeed}Party speed on map", (Dictionary<string, object>)null)).ToString();
		string arg6 = ((object)new TextObject("{=AIInfluence_Disease_Morale}Morale", (Dictionary<string, object>)null)).ToString();
		stringBuilder.AppendLine("<b>" + text + "</b>");
		stringBuilder.AppendLine($"{text2}: {num} / {num2} ({num3:F1}%)");
		stringBuilder.AppendLine();
		float num4 = ((num2 > 0) ? ((float)num / (float)num2) : 0f);
		float num5 = 0f;
		float num6 = 0f;
		foreach (DiseaseInstance item2 in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item2.DiseaseId);
			if (disease == null)
			{
				continue;
			}
			string text4 = "";
			if (item2.IsTreated)
			{
				text4 = " " + ((object)new TextObject("{=AIInfluence_UnderTreatment}(under treatment)", (Dictionary<string, object>)null)).ToString();
			}
			else if (item2.HasPostTreatmentEffect)
			{
				TextObject val = new TextObject("{=AIInfluence_PostTreatmentStatus}(recovering, {DAYS} days left)", (Dictionary<string, object>)null);
				val.SetTextVariable("DAYS", item2.PostTreatmentDaysRemaining);
				text4 = " " + ((object)val).ToString();
			}
			else if (item2.DiseaseProgress > 0f)
			{
				text4 = " " + ((object)new TextObject("{=AIInfluence_NeedsTreatment}(needs treatment)", (Dictionary<string, object>)null)).ToString();
			}
			stringBuilder.AppendLine($"<b>{disease.Name}</b> — {item2.InfectedTroopCount} {text3} ({item2.DiseaseProgress:F0}%){text4}");
			if (disease.Effects != null)
			{
				if (disease.Effects.CombatModifiers != null)
				{
					CombatModifiers combatModifiers = disease.Effects.CombatModifiers;
					if (combatModifiers.DamageMultiplier != 1f)
					{
						stringBuilder.AppendLine($"  • {arg}: -{(1f - combatModifiers.DamageMultiplier) * 100f:F0}%");
					}
					if (combatModifiers.SpeedMultiplier != 1f)
					{
						stringBuilder.AppendLine($"  • {arg2}: -{(1f - combatModifiers.SpeedMultiplier) * 100f:F0}%");
					}
					if (combatModifiers.AccuracyMultiplier != 1f)
					{
						stringBuilder.AppendLine($"  • {arg3}: -{(1f - combatModifiers.AccuracyMultiplier) * 100f:F0}%");
					}
					if (combatModifiers.DefenseMultiplier != 1f)
					{
						stringBuilder.AppendLine($"  • {arg4}: -{(1f - combatModifiers.DefenseMultiplier) * 100f:F0}%");
					}
				}
				if (disease.Effects.MapModifiers != null)
				{
					MapModifiers mapModifiers = disease.Effects.MapModifiers;
					if (mapModifiers.MovementSpeedMultiplier != 1f)
					{
						float num7 = (1f - mapModifiers.MovementSpeedMultiplier) * 100f * num4;
						stringBuilder.AppendLine($"  • {arg5}: -{num7:F1}%");
						num5 += 1f - mapModifiers.MovementSpeedMultiplier;
					}
					if (mapModifiers.MoraleModifier != 0f)
					{
						float num8 = mapModifiers.MoraleModifier * num4;
						stringBuilder.AppendLine($"  • {arg6}: {num8:F1}");
						num6 += mapModifiers.MoraleModifier;
					}
				}
			}
			stringBuilder.AppendLine();
		}
		float num9 = num5 * num4 * 100f;
		float num10 = num6 * num4;
		if (num9 > 0.5f || num10 < -0.5f)
		{
			TextObject val2 = new TextObject("{=AIInfluence_Disease_ActualPartyPenalties}Current party penalties ({PERCENT}% infected)", (Dictionary<string, object>)null);
			val2.SetTextVariable("PERCENT", $"{num3:F1}");
			stringBuilder.AppendLine($"<b>{val2}</b>");
			if (num9 > 0.5f)
			{
				stringBuilder.AppendLine($"  • {arg5}: -{num9:F1}%");
			}
			if (num10 < -0.5f)
			{
				stringBuilder.AppendLine($"  • {arg6}: {num10:F1}");
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public static string GetCompactTroopDiseaseSummary(MobileParty party)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		if (party == null)
		{
			return "";
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(party);
		if (list == null || list.Count == 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		foreach (DiseaseInstance item in list)
		{
			num += item.InfectedTroopCount;
		}
		TroopRoster memberRoster = party.MemberRoster;
		int num2 = ((memberRoster != null) ? memberRoster.TotalManCount : 0);
		float num3 = ((num2 > 0) ? ((float)num / (float)num2 * 100f) : 0f);
		float num4 = ((num2 > 0) ? ((float)num / (float)num2) : 0f);
		string text = ((object)new TextObject("{=AIInfluence_Disease_InfectedCount}Infected", (Dictionary<string, object>)null)).ToString();
		stringBuilder.AppendLine($"{text}: {num} / {num2} ({num3:F1}%)");
		float num5 = 0f;
		float num6 = 0f;
		foreach (DiseaseInstance item2 in list)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item2.DiseaseId);
			if (disease?.Effects?.MapModifiers != null)
			{
				MapModifiers mapModifiers = disease.Effects.MapModifiers;
				if (mapModifiers.MovementSpeedMultiplier != 1f)
				{
					num5 += 1f - mapModifiers.MovementSpeedMultiplier;
				}
				if (mapModifiers.MoraleModifier != 0f)
				{
					num6 += mapModifiers.MoraleModifier;
				}
			}
		}
		float num7 = num5 * num4 * 100f;
		float num8 = num6 * num4;
		string arg = ((object)new TextObject("{=AIInfluence_Disease_MapSpeed}Party speed on map", (Dictionary<string, object>)null)).ToString();
		string arg2 = ((object)new TextObject("{=AIInfluence_Disease_Morale}Morale", (Dictionary<string, object>)null)).ToString();
		if (num7 > 0.5f)
		{
			stringBuilder.AppendLine($"{arg}: -{num7:F1}%");
		}
		if (num8 < -0.5f)
		{
			stringBuilder.AppendLine($"{arg2}: {num8:F1}");
		}
		return stringBuilder.ToString();
	}

	public static string GetSingleDiseaseHintForTroops(DiseaseInstance instance, float infectionRateFraction)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		if (instance == null)
		{
			return "";
		}
		Disease disease = DiseaseManager.Instance?.GetDiseaseById(instance.DiseaseId);
		if (disease == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		string arg = ((object)new TextObject("{=AIInfluence_Disease_Severity}Disease severity", (Dictionary<string, object>)null)).ToString();
		stringBuilder.AppendLine($"{arg}: {disease.Severity}/5");
		if (disease.Effects == null)
		{
			return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
		}
		string arg2 = ((object)new TextObject("{=AIInfluence_Disease_CombatDamage}Damage", (Dictionary<string, object>)null)).ToString();
		string arg3 = ((object)new TextObject("{=AIInfluence_Disease_CombatSpeed}Attack/movement speed", (Dictionary<string, object>)null)).ToString();
		string arg4 = ((object)new TextObject("{=AIInfluence_Disease_Accuracy}Accuracy", (Dictionary<string, object>)null)).ToString();
		string arg5 = ((object)new TextObject("{=AIInfluence_Disease_Defense}Defense", (Dictionary<string, object>)null)).ToString();
		string arg6 = ((object)new TextObject("{=AIInfluence_Disease_MapSpeed}Party speed on map", (Dictionary<string, object>)null)).ToString();
		string arg7 = ((object)new TextObject("{=AIInfluence_Disease_Morale}Morale", (Dictionary<string, object>)null)).ToString();
		if (disease.Effects.CombatModifiers != null)
		{
			CombatModifiers combatModifiers = disease.Effects.CombatModifiers;
			if (combatModifiers.DamageMultiplier != 1f)
			{
				stringBuilder.AppendLine($"{arg2}: -{(1f - combatModifiers.DamageMultiplier) * 100f:F0}%");
			}
			if (combatModifiers.SpeedMultiplier != 1f)
			{
				stringBuilder.AppendLine($"{arg3}: -{(1f - combatModifiers.SpeedMultiplier) * 100f:F0}%");
			}
			if (combatModifiers.AccuracyMultiplier != 1f)
			{
				stringBuilder.AppendLine($"{arg4}: -{(1f - combatModifiers.AccuracyMultiplier) * 100f:F0}%");
			}
			if (combatModifiers.DefenseMultiplier != 1f)
			{
				stringBuilder.AppendLine($"{arg5}: -{(1f - combatModifiers.DefenseMultiplier) * 100f:F0}%");
			}
		}
		if (disease.Effects.MapModifiers != null)
		{
			MapModifiers mapModifiers = disease.Effects.MapModifiers;
			if (mapModifiers.MovementSpeedMultiplier != 1f)
			{
				float num = (1f - mapModifiers.MovementSpeedMultiplier) * 100f * infectionRateFraction;
				stringBuilder.AppendLine($"{arg6}: -{num:F1}%");
			}
			if (mapModifiers.MoraleModifier != 0f)
			{
				float num2 = mapModifiers.MoraleModifier * infectionRateFraction;
				stringBuilder.AppendLine($"{arg7}: {num2:F1}");
			}
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	public static void NotifyPrisonerInfection(string diseaseName, int infectedCount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		TextObject val = new TextObject("{=AIInfluence_PrisonerInfected}Captured prisoners are infected: {DISEASE} ({COUNT})", (Dictionary<string, object>)null);
		val.SetTextVariable("DISEASE", diseaseName ?? "?");
		val.SetTextVariable("COUNT", infectedCount);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
	}
}
