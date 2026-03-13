using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public static class SeasonalDiseaseSystem
{
	private readonly struct SeasonalDiseaseTemplate
	{
		public readonly string NameId;

		public readonly string DescId;

		public readonly string NameEn;

		public readonly string DescEn;

		public readonly int Severity;

		public readonly Seasons? SeasonRestriction;

		public SeasonalDiseaseTemplate(string nameId, string descId, string nameEn, string descEn, int severity, Seasons? seasonRestriction = null)
		{
			NameId = nameId;
			DescId = descId;
			NameEn = nameEn;
			DescEn = descEn;
			Severity = severity;
			SeasonRestriction = seasonRestriction;
		}
	}

	private static readonly Random _random = new Random();

	private static readonly SeasonalDiseaseTemplate[] DiseaseTemplates = new SeasonalDiseaseTemplate[12]
	{
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_CommonCold", "AIInfluence_DiseaseSeasonal_CommonColdDesc", "Common cold", "Mild fever, runny nose and general weakness. A typical traveler's ailment.", 1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_HeadCold", "AIInfluence_DiseaseSeasonal_HeadColdDesc", "Head cold", "Runny nose, headache and fatigue. Often caused by wet weather or wind.", 1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_SeasonalCough", "AIInfluence_DiseaseSeasonal_SeasonalCoughDesc", "Seasonal cough", "Dry or wet cough accompanied by mild weakness.", 1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_SoreThroat", "AIInfluence_DiseaseSeasonal_SoreThroatDesc", "Sore throat", "Soreness and difficulty swallowing. Often follows exposure to cold.", 1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_MildFever", "AIInfluence_DiseaseSeasonal_MildFeverDesc", "Mild fever", "Chills, fever and weakness. Usually passes within a few days.", 2),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_SeasonalMalaise", "AIInfluence_DiseaseSeasonal_SeasonalMalaiseDesc", "Seasonal malaise", "Mild malaise associated with the change of season.", 1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_WinterCold", "AIInfluence_DiseaseSeasonal_WinterColdDesc", "Winter cold", "Severe cold caused by cold winter weather. Causes chills, cough and general weakness.", 2, (Seasons)3),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_Bronchitis", "AIInfluence_DiseaseSeasonal_BronchitisDesc", "Bronchitis", "Cough, shortness of breath and fatigue. Often develops in cold, damp weather.", 2, (Seasons)3),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_HeatExhaustion", "AIInfluence_DiseaseSeasonal_HeatExhaustionDesc", "Heat exhaustion", "Weakness, dizziness and headache from prolonged heat exposure.", 1, (Seasons)1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_SummerFever", "AIInfluence_DiseaseSeasonal_SummerFeverDesc", "Summer fever", "Fever and weakness caused by heat and dehydration.", 2, (Seasons)1),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_AutumnCold", "AIInfluence_DiseaseSeasonal_AutumnColdDesc", "Autumn cold", "Mild cold typical of autumn weather. Runny nose and fatigue.", 1, (Seasons)2),
		new SeasonalDiseaseTemplate("AIInfluence_DiseaseSeasonal_SpringCold", "AIInfluence_DiseaseSeasonal_SpringColdDesc", "Spring cold", "Mild cold typical of spring weather. Sneezing and fatigue.", 1, (Seasons)0)
	};

	private static float BaseChancePer6h => GlobalSettings<ModSettings>.Instance?.SeasonalDiseaseBaseChance ?? 0.02f;

	private static float MaxTotalChance => GlobalSettings<ModSettings>.Instance?.SeasonalDiseaseMaxChance ?? 0.35f;

	private static float SeasonWinterAdd => GlobalSettings<ModSettings>.Instance?.SeasonalWinterBonus ?? 0.08f;

	private static float SeasonAutumnAdd => GlobalSettings<ModSettings>.Instance?.SeasonalAutumnBonus ?? 0.05f;

	private static float SeasonSpringAdd => GlobalSettings<ModSettings>.Instance?.SeasonalSpringBonus ?? 0.03f;

	private static float SeasonSummerAdd => GlobalSettings<ModSettings>.Instance?.SeasonalSummerBonus ?? 0.01f;

	private static float WeatherLightRainAdd => GlobalSettings<ModSettings>.Instance?.SeasonalWeatherLightRainBonus ?? 0.02f;

	private static float WeatherHeavyRainStormAdd => GlobalSettings<ModSettings>.Instance?.SeasonalWeatherHeavyRainBonus ?? 0.04f;

	private static float WeatherSnowyAdd => GlobalSettings<ModSettings>.Instance?.SeasonalWeatherSnowyBonus ?? 0.05f;

	private static float WeatherBlizzardAdd => GlobalSettings<ModSettings>.Instance?.SeasonalWeatherBlizzardBonus ?? 0.08f;

	private static float WeatherWetAdd => GlobalSettings<ModSettings>.Instance?.SeasonalWeatherWetBonus ?? 0.01f;

	private static float ShipAtSeaAdd => GlobalSettings<ModSettings>.Instance?.SeasonalShipAtSeaBonus ?? 0.04f;

	public static Seasons GetCurrentSeason()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		_ = CampaignTime.Now;
		if (false)
		{
			return (Seasons)1;
		}
		CampaignTime now = CampaignTime.Now;
		return ((CampaignTime)(ref now)).GetSeasonOfYear;
	}

	public static float GetSeasonAdditiveBonus()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected I4, but got Unknown
		Seasons currentSeason = GetCurrentSeason();
		return (int)currentSeason switch
		{
			3 => SeasonWinterAdd, 
			2 => SeasonAutumnAdd, 
			0 => SeasonSpringAdd, 
			1 => SeasonSummerAdd, 
			_ => 0.02f, 
		};
	}

	public static float GetWeatherAdditiveBonusForHero(Hero hero)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected I4, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Invalid comparison between Unknown and I4
		float num = 0f;
		try
		{
			MobileParty val = ((hero != null) ? hero.PartyBelongedTo : null) ?? MobileParty.MainParty;
			if (val == null)
			{
				return num;
			}
			Vec2 position2D = val.GetPosition2D();
			bool flag = false;
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current.Models;
				obj = ((models != null) ? models.MapWeatherModel : null);
			}
			MapWeatherModel val2 = (MapWeatherModel)obj;
			if (val2 == null)
			{
				return num;
			}
			WeatherEvent weatherEventInPosition = val2.GetWeatherEventInPosition(position2D);
			WeatherEvent val3 = weatherEventInPosition;
			WeatherEvent val4 = val3;
			switch (val4 - 1)
			{
			case 0:
				num += WeatherLightRainAdd;
				break;
			case 1:
			case 4:
				num += WeatherHeavyRainStormAdd;
				break;
			case 2:
				num += WeatherSnowyAdd;
				break;
			case 3:
				num += WeatherBlizzardAdd;
				break;
			}
			WeatherEventEffectOnTerrain weatherEffectOnTerrainForPosition = val2.GetWeatherEffectOnTerrainForPosition(position2D);
			if ((int)weatherEffectOnTerrainForPosition == 1)
			{
				num += WeatherWetAdd;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[SEASONAL_DISEASE] Error checking weather: " + ex.Message);
		}
		return num;
	}

	public static bool IsPartyAtSea(Hero hero)
	{
		try
		{
			MobileParty party = ((hero != null) ? hero.PartyBelongedTo : null) ?? MobileParty.MainParty;
			return IsPartyAtSea(party);
		}
		catch
		{
			return false;
		}
	}

	public static bool IsPartyAtSea(MobileParty party)
	{
		try
		{
			if (party == null)
			{
				return false;
			}
			if (party.Ships == null || ((List<Ship>)(object)party.Ships).Count == 0)
			{
				return false;
			}
			return party.IsCurrentlyAtSea;
		}
		catch
		{
			return false;
		}
	}

	public static float GetWeatherAdditiveBonusForParty(MobileParty party)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected I4, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		float num = 0f;
		try
		{
			if (party == null)
			{
				return num;
			}
			Vec2 position2D = party.GetPosition2D();
			bool flag = false;
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current.Models;
				obj = ((models != null) ? models.MapWeatherModel : null);
			}
			MapWeatherModel val = (MapWeatherModel)obj;
			if (val == null)
			{
				return num;
			}
			WeatherEvent weatherEventInPosition = val.GetWeatherEventInPosition(position2D);
			WeatherEvent val2 = weatherEventInPosition;
			WeatherEvent val3 = val2;
			switch (val3 - 1)
			{
			case 0:
				num += WeatherLightRainAdd;
				break;
			case 1:
			case 4:
				num += WeatherHeavyRainStormAdd;
				break;
			case 2:
				num += WeatherSnowyAdd;
				break;
			case 3:
				num += WeatherBlizzardAdd;
				break;
			}
			WeatherEventEffectOnTerrain weatherEffectOnTerrainForPosition = val.GetWeatherEffectOnTerrainForPosition(position2D);
			if ((int)weatherEffectOnTerrainForPosition == 1)
			{
				num += WeatherWetAdd;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[SEASONAL_DISEASE] Error checking weather for party: " + ex.Message);
		}
		return num;
	}

	public static bool CheckSeasonalDiseaseChance(Hero hero)
	{
		if (hero == null || !hero.IsAlive)
		{
			return false;
		}
		float baseChancePer6h = BaseChancePer6h;
		baseChancePer6h += GetSeasonAdditiveBonus();
		baseChancePer6h += GetWeatherAdditiveBonusForHero(hero);
		if (IsPartyAtSea(hero))
		{
			baseChancePer6h += ShipAtSeaAdd;
		}
		int skillValue = hero.GetSkillValue(DefaultSkills.Medicine);
		float val = 1f - (float)skillValue / 600f;
		baseChancePer6h *= Math.Max(0.5f, val);
		baseChancePer6h = Math.Min(baseChancePer6h, MaxTotalChance);
		return (float)_random.NextDouble() < baseChancePer6h;
	}

	public static bool CheckSeasonalDiseaseChanceForParty(MobileParty party)
	{
		if (party != null)
		{
			TroopRoster memberRoster = party.MemberRoster;
			if (memberRoster == null || memberRoster.TotalRegulars > 0)
			{
				float baseChancePer6h = BaseChancePer6h;
				baseChancePer6h += GetSeasonAdditiveBonus();
				baseChancePer6h += GetWeatherAdditiveBonusForParty(party);
				if (IsPartyAtSea(party))
				{
					baseChancePer6h += ShipAtSeaAdd;
				}
				Hero leaderHero = party.LeaderHero;
				if (leaderHero != null && leaderHero.IsAlive)
				{
					int skillValue = leaderHero.GetSkillValue(DefaultSkills.Medicine);
					float val = 1f - (float)skillValue / 600f;
					baseChancePer6h *= Math.Max(0.5f, val);
				}
				baseChancePer6h = Math.Min(baseChancePer6h, MaxTotalChance);
				return (float)_random.NextDouble() < baseChancePer6h;
			}
		}
		return false;
	}

	public static Disease CreateSeasonalDisease(Hero hero)
	{
		if (hero == null)
		{
			return null;
		}
		MobileParty party = ((hero != null) ? hero.PartyBelongedTo : null) ?? MobileParty.MainParty;
		return CreateSeasonalDiseaseForParty(party);
	}

	public static Disease CreateSeasonalDiseaseForParty(MobileParty party)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Invalid comparison between Unknown and I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Invalid comparison between Unknown and I4
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Invalid comparison between Unknown and I4
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		if (party == null)
		{
			return null;
		}
		Seasons currentSeason = GetCurrentSeason();
		bool flag = IsPartyAtSea(party);
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		try
		{
			Vec2 position2D = party.GetPosition2D();
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current.Models;
				obj = ((models != null) ? models.MapWeatherModel : null);
			}
			if (obj != null)
			{
				WeatherEvent weatherEventInPosition = Campaign.Current.Models.MapWeatherModel.GetWeatherEventInPosition(position2D);
				flag2 = (int)weatherEventInPosition == 3;
				flag4 = (int)weatherEventInPosition == 4;
				flag3 = (int)weatherEventInPosition == 1 || (int)weatherEventInPosition == 2 || (int)weatherEventInPosition == 5;
			}
		}
		catch
		{
		}
		List<(SeasonalDiseaseTemplate, float)> list = new List<(SeasonalDiseaseTemplate, float)>();
		SeasonalDiseaseTemplate[] diseaseTemplates = DiseaseTemplates;
		for (int i = 0; i < diseaseTemplates.Length; i++)
		{
			SeasonalDiseaseTemplate item = diseaseTemplates[i];
			if (!item.SeasonRestriction.HasValue || item.SeasonRestriction.Value == currentSeason)
			{
				float num = 1f;
				if (flag && (item.NameId.EndsWith("HeadCold") || item.NameId.EndsWith("CommonCold") || item.NameId.EndsWith("SoreThroat")))
				{
					num *= 2f;
				}
				if ((int)currentSeason == 3 && (flag2 || flag4) && (item.NameId.EndsWith("WinterCold") || item.NameId.EndsWith("Bronchitis")))
				{
					num *= 2f;
				}
				if ((int)currentSeason == 1 && (item.NameId.EndsWith("HeatExhaustion") || item.NameId.EndsWith("SummerFever")))
				{
					num *= 2f;
				}
				if ((flag3 || flag4) && (item.NameId.EndsWith("CommonCold") || item.NameId.EndsWith("MildFever")))
				{
					num *= 1.5f;
				}
				list.Add((item, num));
			}
		}
		if (list.Count == 0)
		{
			SeasonalDiseaseTemplate[] diseaseTemplates2 = DiseaseTemplates;
			for (int j = 0; j < diseaseTemplates2.Length; j++)
			{
				SeasonalDiseaseTemplate item2 = diseaseTemplates2[j];
				if (!item2.SeasonRestriction.HasValue)
				{
					list.Add((item2, 1f));
				}
			}
		}
		if (list.Count == 0)
		{
			SeasonalDiseaseTemplate seasonalDiseaseTemplate = DiseaseTemplates[0];
			return BuildDisease(((object)new TextObject("{=" + seasonalDiseaseTemplate.NameId + "}" + seasonalDiseaseTemplate.NameEn, (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=" + seasonalDiseaseTemplate.DescId + "}" + seasonalDiseaseTemplate.DescEn, (Dictionary<string, object>)null)).ToString(), seasonalDiseaseTemplate.Severity);
		}
		float num2 = list.Sum<(SeasonalDiseaseTemplate, float)>(((SeasonalDiseaseTemplate t, float w) x) => x.w);
		float num3 = (float)_random.NextDouble() * num2;
		foreach (var item5 in list)
		{
			SeasonalDiseaseTemplate item3 = item5.Item1;
			float item4 = item5.Item2;
			num3 -= item4;
			if (num3 <= 0f)
			{
				string name = ((object)new TextObject("{=" + item3.NameId + "}" + item3.NameEn, (Dictionary<string, object>)null)).ToString();
				string description = ((object)new TextObject("{=" + item3.DescId + "}" + item3.DescEn, (Dictionary<string, object>)null)).ToString();
				return BuildDisease(name, description, item3.Severity);
			}
		}
		SeasonalDiseaseTemplate seasonalDiseaseTemplate2 = DiseaseTemplates[0];
		string name2 = ((object)new TextObject("{=" + seasonalDiseaseTemplate2.NameId + "}" + seasonalDiseaseTemplate2.NameEn, (Dictionary<string, object>)null)).ToString();
		string description2 = ((object)new TextObject("{=" + seasonalDiseaseTemplate2.DescId + "}" + seasonalDiseaseTemplate2.DescEn, (Dictionary<string, object>)null)).ToString();
		return BuildDisease(name2, description2, seasonalDiseaseTemplate2.Severity);
	}

	private static Disease BuildDisease(string name, string description, int severity)
	{
		DiseaseEffects diseaseEffects = new DiseaseEffects();
		diseaseEffects.CombatModifiers.DamageMultiplier = 1f - 0.1f * (float)severity;
		diseaseEffects.CombatModifiers.SpeedMultiplier = 1f - 0.15f * (float)severity;
		diseaseEffects.CombatModifiers.AccuracyMultiplier = 1f - 0.12f * (float)severity;
		diseaseEffects.CombatModifiers.DefenseMultiplier = 1f - 0.08f * (float)severity;
		diseaseEffects.MapModifiers.MovementSpeedMultiplier = 1f - 0.1f * (float)severity;
		diseaseEffects.MapModifiers.MoraleModifier = -5f * (float)severity;
		diseaseEffects.DeathChance = 0f;
		return new Disease
		{
			Id = Guid.NewGuid().ToString(),
			Name = name,
			Description = description,
			Type = "seasonal",
			Severity = severity,
			Effects = diseaseEffects,
			SpreadRate = 0.1f,
			DurationDays = 14,
			SettlementId = null
		};
	}

	public static void ProcessDailySeasonalCheck()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return;
		}
		ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
		if ((instance2 != null && !instance2.EnableSeasonalDiseases) || DiseaseManager.Instance == null)
		{
			return;
		}
		foreach (Hero item in (List<Hero>)(object)Hero.AllAliveHeroes)
		{
			if (item != null && item.IsAlive)
			{
				ProcessSeasonalCheckForHero(item);
			}
		}
		foreach (MobileParty item2 in (List<MobileParty>)(object)MobileParty.All)
		{
			ProcessSeasonalCheckForParty(item2);
		}
	}

	public static void ProcessSeasonalCheckForHero(Hero hero)
	{
		if (hero == null || !hero.IsAlive || hero.IsChild)
		{
			return;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if ((instance != null && !instance.EnableSeasonalDiseases) || DiseaseManager.Instance == null || DiseaseManager.Instance.IsHeroInfected(hero) || hero.CurrentSettlement != null || !CheckSeasonalDiseaseChance(hero))
		{
			return;
		}
		Disease diseaseTemplate = CreateSeasonalDisease(hero);
		if (diseaseTemplate != null)
		{
			Disease disease = DiseaseManager.Instance.Diseases.FirstOrDefault((Disease d) => d.Name == diseaseTemplate.Name && d.Type == "seasonal" && !d.IsExpired());
			Disease disease2 = ((disease != null) ? disease : DiseaseManager.Instance.RegisterSeasonalDisease(diseaseTemplate.Name, diseaseTemplate.Description, diseaseTemplate.Severity, diseaseTemplate.Effects));
			if (disease2 != null && DiseaseManager.Instance.InfectHero(hero, disease2))
			{
				LogMessage($"[SEASONAL_DISEASE] {hero.Name} ({GetHeroTypeTag(hero)}) contracted {diseaseTemplate.Name}");
			}
		}
	}

	public static void ProcessSeasonalCheckForParty(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if ((instance != null && !instance.EnableSeasonalDiseases) || DiseaseManager.Instance == null || party.CurrentSettlement != null || party.MemberRoster == null || party.MemberRoster.TotalRegulars <= 0 || !CheckSeasonalDiseaseChanceForParty(party))
		{
			return;
		}
		Disease diseaseTemplate = CreateSeasonalDiseaseForParty(party);
		if (diseaseTemplate == null)
		{
			return;
		}
		Disease disease = DiseaseManager.Instance.Diseases.FirstOrDefault((Disease d) => d.Name == diseaseTemplate.Name && d.Type == "seasonal" && !d.IsExpired());
		Disease disease2 = ((disease != null) ? disease : DiseaseManager.Instance.RegisterSeasonalDisease(diseaseTemplate.Name, diseaseTemplate.Description, diseaseTemplate.Severity, diseaseTemplate.Effects));
		if (disease2 == null)
		{
			return;
		}
		int totalRegulars = party.MemberRoster.TotalRegulars;
		float num = 1f - ImmunitySystem.CalculateTroopImmunityChance(party, disease2);
		if (!(num <= 0f))
		{
			int num2 = Math.Max(1, (int)((float)totalRegulars * 0.02f * num));
			if (DiseaseManager.Instance.InfectPartyTroops(party, disease2, num2))
			{
				LogMessage($"[SEASONAL_DISEASE] {num2} troops in {party.Name} contracted {diseaseTemplate.Name}");
			}
		}
	}

	public static string GetSeasonName(Seasons season)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected I4, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		return (int)season switch
		{
			0 => ((object)new TextObject("{=AIInfluence_Season_Spring}Spring", (Dictionary<string, object>)null)).ToString(), 
			1 => ((object)new TextObject("{=AIInfluence_Season_Summer}Summer", (Dictionary<string, object>)null)).ToString(), 
			2 => ((object)new TextObject("{=AIInfluence_Season_Autumn}Autumn", (Dictionary<string, object>)null)).ToString(), 
			3 => ((object)new TextObject("{=AIInfluence_Season_Winter}Winter", (Dictionary<string, object>)null)).ToString(), 
			_ => ((object)new TextObject("{=AIInfluence_Season_Unknown}Unknown", (Dictionary<string, object>)null)).ToString(), 
		};
	}

	public static float GetTotalChanceModifierForHero(Hero hero)
	{
		float baseChancePer6h = BaseChancePer6h;
		baseChancePer6h += GetSeasonAdditiveBonus();
		baseChancePer6h += GetWeatherAdditiveBonusForHero(hero);
		if (IsPartyAtSea(hero))
		{
			baseChancePer6h += ShipAtSeaAdd;
		}
		return Math.Min(baseChancePer6h, MaxTotalChance);
	}

	public static string GetSeasonRiskDescription()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		Seasons currentSeason = GetCurrentSeason();
		float num = BaseChancePer6h + GetSeasonAdditiveBonus();
		string text = ((num >= 0.12f) ? ((object)new TextObject("{=AIInfluence_DiseaseRisk_VeryHigh}Very high", (Dictionary<string, object>)null)).ToString() : ((num >= 0.08f) ? ((object)new TextObject("{=AIInfluence_DiseaseRisk_High}High", (Dictionary<string, object>)null)).ToString() : ((!(num >= 0.05f)) ? ((object)new TextObject("{=AIInfluence_DiseaseRisk_Low}Low", (Dictionary<string, object>)null)).ToString() : ((object)new TextObject("{=AIInfluence_DiseaseRisk_Medium}Medium", (Dictionary<string, object>)null)).ToString())));
		string text2 = text;
		TextObject val = new TextObject("{=AIInfluence_SeasonRiskFormat}Season: {SEASON} (Disease risk: {RISK})", (Dictionary<string, object>)null);
		val.SetTextVariable("SEASON", GetSeasonName(currentSeason));
		val.SetTextVariable("RISK", text2);
		return ((object)val).ToString();
	}

	internal static string GetHeroTypeTag(Hero hero)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null)
		{
			return "null";
		}
		string text = (hero.IsLord ? "Lord" : (hero.IsNotable ? "Notable" : (hero.IsWanderer ? "Wanderer" : ((!hero.IsMinorFactionHero) ? $"Other({hero.Occupation})" : "MinorFactionHero"))));
		string text2 = ((hero.Clan == null) ? "no clan" : (((object)hero.Clan.Name)?.ToString() ?? "?"));
		string text3 = ((hero.CurrentSettlement == null) ? ((hero.PartyBelongedTo != null) ? $"party:{hero.PartyBelongedTo.Name}" : "map") : (((object)hero.CurrentSettlement.Name)?.ToString() ?? "?"));
		return text + ", clan:" + text2 + ", at:" + text3 + ", StringId:" + ((MBObjectBase)hero).StringId;
	}

	private static void LogMessage(string message)
	{
		DiseaseLogger.Instance?.Log(message);
	}
}
