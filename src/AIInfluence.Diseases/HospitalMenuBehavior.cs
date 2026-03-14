using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using OnConditionDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConditionDelegate;
using OnConsequenceDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConsequenceDelegate;

namespace AIInfluence.Diseases;

public class HospitalMenuBehavior : CampaignBehaviorBase
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static OnConditionDelegate _003C0_003E__VisitHospitalCondition;

		public static OnConsequenceDelegate _003C1_003E__VisitHospitalConsequence;

		public static OnConditionDelegate _003C2_003E__DiseaseInfoCondition;

		public static OnConsequenceDelegate _003C3_003E__DiseaseInfoConsequence;

		public static OnConditionDelegate _003C4_003E__TreatPlayerCondition;

		public static OnConsequenceDelegate _003C5_003E__TreatPlayerConsequence;

		public static OnConditionDelegate _003C6_003E__TreatCompanionsCondition;

		public static OnConsequenceDelegate _003C7_003E__TreatCompanionsConsequence;

		public static OnConditionDelegate _003C8_003E__TreatTroopsCondition;

		public static OnConsequenceDelegate _003C9_003E__TreatTroopsConsequence;

		public static OnConditionDelegate _003C10_003E__TreatPrisonersCondition;

		public static OnConsequenceDelegate _003C11_003E__TreatPrisonersConsequence;

		public static OnConditionDelegate _003C12_003E__PreventionCondition;

		public static OnConsequenceDelegate _003C13_003E__PreventionConsequence;

		public static OnConditionDelegate _003C14_003E__LeaveCondition;

		public static OnConsequenceDelegate _003C15_003E__LeaveConsequence;

		public static Action<List<InquiryElement>> _003C16_003E__OnPlayerTreatmentSelected;

		public static Action<List<InquiryElement>> _003C17_003E__OnCompanionTreatmentSelected;

		public static Action<List<InquiryElement>> _003C18_003E__OnCompanionTreatmentMethodSelected;

		public static Action<List<InquiryElement>> _003C19_003E__OnDiseaseGroupSelected;

		public static Action<List<InquiryElement>> _003C20_003E__OnTroopTreatmentMethodSelected;

		public static Action<List<InquiryElement>> _003C21_003E__OnPrisonerGroupSelected;

		public static Action<List<InquiryElement>> _003C22_003E__OnPrisonerLordTreatmentSelected;

		public static Action<List<InquiryElement>> _003C23_003E__OnPrisonerTroopTreatmentMethodSelected;

		public static Action<List<InquiryElement>> _003C24_003E__OnHerbSelected;
	}

	private static string _parentMenuId = "town";

	private static DiseaseInstance _selectedDiseaseForTreatment;

	private static Hero _selectedCompanionForTreatment;

	private static List<DiseaseInstance> _selectedTroopDiseasesForTreatment;

	private static List<DiseaseInstance> _selectedPrisonerDiseasesForTreatment;

	private static Hero _selectedPrisonerHeroForTreatment;

	public override void RegisterEvents()
	{
	}

	public override void SyncData(IDataStore dataStore)
	{
		if (dataStore.IsSaving)
		{
			DiseaseManager.Instance?.SaveAll();
		}
	}

	public static void AddMenus(CampaignGameStarter starter)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || instance.EnableDiseaseSystem)
		{
			starter.AddGameMenu("hospital_menu", "{HOSPITAL_MENU_TEXT}", new OnInitDelegate(OnHospitalMenuInit), (MenuOverlayType)3, (MenuFlags)0, (object)null);
			object obj = _003C_003EO._003C0_003E__VisitHospitalCondition;
			if (obj == null)
			{
				OnConditionDelegate val = VisitHospitalCondition;
				_003C_003EO._003C0_003E__VisitHospitalCondition = val;
				obj = (object)val;
			}
			object obj2 = _003C_003EO._003C1_003E__VisitHospitalConsequence;
			if (obj2 == null)
			{
				OnConsequenceDelegate val2 = VisitHospitalConsequence;
				_003C_003EO._003C1_003E__VisitHospitalConsequence = val2;
				obj2 = (object)val2;
			}
			starter.AddGameMenuOption("town", "visit_hospital", "{=AIInfluence_VisitHospital}Visit hospital", (OnConditionDelegate)obj, (OnConsequenceDelegate)obj2, false, 5, false, (object)null);
			object obj3 = _003C_003EO._003C0_003E__VisitHospitalCondition;
			if (obj3 == null)
			{
				OnConditionDelegate val3 = VisitHospitalCondition;
				_003C_003EO._003C0_003E__VisitHospitalCondition = val3;
				obj3 = (object)val3;
			}
			object obj4 = _003C_003EO._003C1_003E__VisitHospitalConsequence;
			if (obj4 == null)
			{
				OnConsequenceDelegate val4 = VisitHospitalConsequence;
				_003C_003EO._003C1_003E__VisitHospitalConsequence = val4;
				obj4 = (object)val4;
			}
			starter.AddGameMenuOption("castle", "visit_hospital", "{=AIInfluence_VisitHospital}Visit hospital", (OnConditionDelegate)obj3, (OnConsequenceDelegate)obj4, false, 5, false, (object)null);
			object obj5 = _003C_003EO._003C0_003E__VisitHospitalCondition;
			if (obj5 == null)
			{
				OnConditionDelegate val5 = VisitHospitalCondition;
				_003C_003EO._003C0_003E__VisitHospitalCondition = val5;
				obj5 = (object)val5;
			}
			object obj6 = _003C_003EO._003C1_003E__VisitHospitalConsequence;
			if (obj6 == null)
			{
				OnConsequenceDelegate val6 = VisitHospitalConsequence;
				_003C_003EO._003C1_003E__VisitHospitalConsequence = val6;
				obj6 = (object)val6;
			}
			starter.AddGameMenuOption("village", "visit_village_healer", "{=AIInfluence_VisitHealer}Visit healer", (OnConditionDelegate)obj5, (OnConsequenceDelegate)obj6, false, 5, false, (object)null);
			object obj7 = _003C_003EO._003C2_003E__DiseaseInfoCondition;
			if (obj7 == null)
			{
				OnConditionDelegate val7 = DiseaseInfoCondition;
				_003C_003EO._003C2_003E__DiseaseInfoCondition = val7;
				obj7 = (object)val7;
			}
			object obj8 = _003C_003EO._003C3_003E__DiseaseInfoConsequence;
			if (obj8 == null)
			{
				OnConsequenceDelegate val8 = DiseaseInfoConsequence;
				_003C_003EO._003C3_003E__DiseaseInfoConsequence = val8;
				obj8 = (object)val8;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_disease_info", "{=AIInfluence_DiseaseInfo}Disease information", (OnConditionDelegate)obj7, (OnConsequenceDelegate)obj8, false, 0, false, (object)null);
			object obj9 = _003C_003EO._003C4_003E__TreatPlayerCondition;
			if (obj9 == null)
			{
				OnConditionDelegate val9 = TreatPlayerCondition;
				_003C_003EO._003C4_003E__TreatPlayerCondition = val9;
				obj9 = (object)val9;
			}
			object obj10 = _003C_003EO._003C5_003E__TreatPlayerConsequence;
			if (obj10 == null)
			{
				OnConsequenceDelegate val10 = TreatPlayerConsequence;
				_003C_003EO._003C5_003E__TreatPlayerConsequence = val10;
				obj10 = (object)val10;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_treat_player", "{=AIInfluence_TreatPlayer}Treat player", (OnConditionDelegate)obj9, (OnConsequenceDelegate)obj10, false, 1, false, (object)null);
			object obj11 = _003C_003EO._003C6_003E__TreatCompanionsCondition;
			if (obj11 == null)
			{
				OnConditionDelegate val11 = TreatCompanionsCondition;
				_003C_003EO._003C6_003E__TreatCompanionsCondition = val11;
				obj11 = (object)val11;
			}
			object obj12 = _003C_003EO._003C7_003E__TreatCompanionsConsequence;
			if (obj12 == null)
			{
				OnConsequenceDelegate val12 = TreatCompanionsConsequence;
				_003C_003EO._003C7_003E__TreatCompanionsConsequence = val12;
				obj12 = (object)val12;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_treat_companions", "{HOSPITAL_TREAT_COMPANIONS_TEXT}", (OnConditionDelegate)obj11, (OnConsequenceDelegate)obj12, false, 2, false, (object)null);
			object obj13 = _003C_003EO._003C8_003E__TreatTroopsCondition;
			if (obj13 == null)
			{
				OnConditionDelegate val13 = TreatTroopsCondition;
				_003C_003EO._003C8_003E__TreatTroopsCondition = val13;
				obj13 = (object)val13;
			}
			object obj14 = _003C_003EO._003C9_003E__TreatTroopsConsequence;
			if (obj14 == null)
			{
				OnConsequenceDelegate val14 = TreatTroopsConsequence;
				_003C_003EO._003C9_003E__TreatTroopsConsequence = val14;
				obj14 = (object)val14;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_treat_troops", "{HOSPITAL_TREAT_TROOPS_TEXT}", (OnConditionDelegate)obj13, (OnConsequenceDelegate)obj14, false, 3, false, (object)null);
			object obj15 = _003C_003EO._003C10_003E__TreatPrisonersCondition;
			if (obj15 == null)
			{
				OnConditionDelegate val15 = TreatPrisonersCondition;
				_003C_003EO._003C10_003E__TreatPrisonersCondition = val15;
				obj15 = (object)val15;
			}
			object obj16 = _003C_003EO._003C11_003E__TreatPrisonersConsequence;
			if (obj16 == null)
			{
				OnConsequenceDelegate val16 = TreatPrisonersConsequence;
				_003C_003EO._003C11_003E__TreatPrisonersConsequence = val16;
				obj16 = (object)val16;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_treat_prisoners", "{HOSPITAL_TREAT_PRISONERS_TEXT}", (OnConditionDelegate)obj15, (OnConsequenceDelegate)obj16, false, 4, false, (object)null);
			object obj17 = _003C_003EO._003C12_003E__PreventionCondition;
			if (obj17 == null)
			{
				OnConditionDelegate val17 = PreventionCondition;
				_003C_003EO._003C12_003E__PreventionCondition = val17;
				obj17 = (object)val17;
			}
			object obj18 = _003C_003EO._003C13_003E__PreventionConsequence;
			if (obj18 == null)
			{
				OnConsequenceDelegate val18 = PreventionConsequence;
				_003C_003EO._003C13_003E__PreventionConsequence = val18;
				obj18 = (object)val18;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_prevention", "{=AIInfluence_Prevention}Health prevention", (OnConditionDelegate)obj17, (OnConsequenceDelegate)obj18, false, 5, false, (object)null);
			object obj19 = _003C_003EO._003C14_003E__LeaveCondition;
			if (obj19 == null)
			{
				OnConditionDelegate val19 = LeaveCondition;
				_003C_003EO._003C14_003E__LeaveCondition = val19;
				obj19 = (object)val19;
			}
			object obj20 = _003C_003EO._003C15_003E__LeaveConsequence;
			if (obj20 == null)
			{
				OnConsequenceDelegate val20 = LeaveConsequence;
				_003C_003EO._003C15_003E__LeaveConsequence = val20;
				obj20 = (object)val20;
			}
			starter.AddGameMenuOption("hospital_menu", "hospital_leave", "{=AIInfluence_HospitalLeave}Return", (OnConditionDelegate)obj19, (OnConsequenceDelegate)obj20, true, 6, false, (object)null);
		}
	}

	private static void OnHospitalMenuInit(MenuCallbackArgs args)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		TextObject val = new TextObject("{=AIInfluence_HospitalMenuTitle}Hospital — {SETTLEMENT_NAME}", (Dictionary<string, object>)null);
		val.SetTextVariable("SETTLEMENT_NAME", currentSettlement.Name);
		stringBuilder.AppendLine(((object)val).ToString());
		stringBuilder.AppendLine();
		int medicalTier = TreatmentSystem.GetMedicalTier(currentSettlement);
		string tierName = TreatmentSystem.GetTierName(medicalTier);
		stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_MedicalLevel}Medical level", (Dictionary<string, object>)null)).ToString() + $": {tierName} ({medicalTier}/4)");
		stringBuilder.AppendLine(SeasonalDiseaseSystem.GetSeasonRiskDescription());
		stringBuilder.AppendLine();
		DiseaseManager instance = DiseaseManager.Instance;
		if (instance != null && instance.IsHeroInfected(Hero.MainHero))
		{
			List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(Hero.MainHero);
			int num = list?.Count ?? 0;
			TextObject val2 = new TextObject("{=AIInfluence_PlayerSick}Sick ({COUNT} diseases)", (Dictionary<string, object>)null);
			val2.SetTextVariable("COUNT", num);
			stringBuilder.AppendLine(((object)val2).ToString());
			if (list != null && list.Count > 0)
			{
				foreach (DiseaseInstance item3 in list)
				{
					Disease disease = DiseaseManager.Instance?.GetDiseaseById(item3.DiseaseId);
					if (disease != null)
					{
						string arg = "";
						if (item3.IsTreated)
						{
							arg = " " + ((object)new TextObject("{=AIInfluence_UnderTreatment}(under treatment)", (Dictionary<string, object>)null)).ToString();
						}
						else if (item3.HasPostTreatmentEffect)
						{
							TextObject val3 = new TextObject("{=AIInfluence_PostTreatmentStatus}(recovering, {DAYS} days left)", (Dictionary<string, object>)null);
							val3.SetTextVariable("DAYS", item3.PostTreatmentDaysRemaining);
							arg = " " + ((object)val3).ToString();
						}
						else if (item3.DiseaseProgress > 0f)
						{
							arg = " " + ((object)new TextObject("{=AIInfluence_NeedsTreatment}(needs treatment)", (Dictionary<string, object>)null)).ToString();
						}
						stringBuilder.AppendLine($"  - {disease.Name} ({item3.DiseaseProgress:F0}%){arg}");
					}
				}
			}
		}
		else
		{
			stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_YouAreHealthy}You are healthy.", (Dictionary<string, object>)null)).ToString());
		}
		if (MobileParty.MainParty != null)
		{
			DiseaseManager instance2 = DiseaseManager.Instance;
			if (instance2 != null && instance2.PartyHasInfectedTroops(MobileParty.MainParty))
			{
				(int infectedCount, int totalCount, float progress, Dictionary<int, int> tierDistribution) partyTroopInfectionInfo = TreatmentSystem.GetPartyTroopInfectionInfo(MobileParty.MainParty);
				int item = partyTroopInfectionInfo.infectedCount;
				int item2 = partyTroopInfectionInfo.totalCount;
				TextObject val4 = new TextObject("{=AIInfluence_OverviewTroopStatus}Troops: {INFECTED}/{TOTAL} infected", (Dictionary<string, object>)null);
				val4.SetTextVariable("INFECTED", item);
				val4.SetTextVariable("TOTAL", item2);
				stringBuilder.AppendLine(((object)val4).ToString());
			}
		}
		MBTextManager.SetTextVariable("HOSPITAL_MENU_TEXT", new TextObject(stringBuilder.ToString(), (Dictionary<string, object>)null), false);
	}

	private static bool VisitHospitalCondition(MenuCallbackArgs args)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		args.optionLeaveType = (LeaveType)2;
		return GlobalSettings<ModSettings>.Instance?.EnableDiseaseSystem ?? false;
	}

	private static void VisitHospitalConsequence(MenuCallbackArgs args)
	{
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement != null)
		{
			if (currentSettlement.IsTown)
			{
				_parentMenuId = "town";
			}
			else if (currentSettlement.IsCastle)
			{
				_parentMenuId = "castle";
			}
			else if (currentSettlement.IsVillage)
			{
				_parentMenuId = "village";
			}
		}
		GameMenu.SwitchToMenu("hospital_menu");
	}

	private static bool DiseaseInfoCondition(MenuCallbackArgs args)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		args.optionLeaveType = (LeaveType)22;
		return true;
	}

	private static void DiseaseInfoConsequence(MenuCallbackArgs args)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(Hero.MainHero);
		if (list != null && list.Count > 0)
		{
			stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_YourDiseases}Your diseases", (Dictionary<string, object>)null)).ToString() + ":");
			stringBuilder.AppendLine();
			foreach (DiseaseInstance item in list)
			{
				Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
				if (disease != null)
				{
					stringBuilder.AppendLine(DiseaseUI.GetDiseaseInfoForDisplay(item, disease));
				}
			}
		}
		else
		{
			stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_YouAreHealthy}You are healthy.", (Dictionary<string, object>)null)).ToString());
			stringBuilder.AppendLine();
		}
		if (MobileParty.MainParty != null)
		{
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance != null && instance.PartyHasInfectedTroops(MobileParty.MainParty))
			{
				stringBuilder.AppendLine(DiseaseUI.GetDetailedTroopDiseaseInfoForDisplay(MobileParty.MainParty));
			}
			else
			{
				stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_YourTroopsHealthy}Your troops are healthy.", (Dictionary<string, object>)null)).ToString());
			}
		}
		InformationManager.ShowInquiry(new InquiryData(((object)new TextObject("{=AIInfluence_DiseaseInfoTitle}Disease information", (Dictionary<string, object>)null)).ToString(), stringBuilder.ToString(), true, false, ((object)new TextObject("{=AIInfluence_Close}Close", (Dictionary<string, object>)null)).ToString(), (string)null, (Action)null, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), false, false);
	}

	private static bool TreatPlayerCondition(MenuCallbackArgs args)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		bool flag = DiseaseManager.Instance?.IsHeroInfected(Hero.MainHero) ?? false;
		args.optionLeaveType = (LeaveType)18;
		args.IsEnabled = flag;
		if (!flag)
		{
			args.Tooltip = new TextObject("{=AIInfluence_YouAreHealthy}You are healthy.", (Dictionary<string, object>)null);
		}
		return true;
	}

	private static void TreatPlayerConsequence(MenuCallbackArgs args)
	{
		ShowPlayerTreatmentOptions();
	}

	private static void ShowPlayerTreatmentOptions()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(Hero.MainHero);
		if (list == null || list.Count == 0)
		{
			return;
		}
		if (list.Count((DiseaseInstance i) => !i.IsTreated && !i.HasPostTreatmentEffect) == 0)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NoTreatableDiseases}No diseases require treatment.", (Dictionary<string, object>)null)).ToString()));
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list2 = new List<InquiryElement>();
		int medicalTier = TreatmentSystem.GetMedicalTier(currentSettlement);
		string tierName = TreatmentSystem.GetTierName(medicalTier);
		float tierRecoveryBonus = TreatmentSystem.GetTierRecoveryBonus(medicalTier);
		int generalTreatmentCost = TreatmentSystem.GetGeneralTreatmentCost(Hero.MainHero, currentSettlement);
		Hero mainHero = Hero.MainHero;
		bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= generalTreatmentCost;
		TextObject val = new TextObject("{=AIInfluence_HospitalTreatment}Hospital treatment (level {TIER}/4) — {COST} {GOLD} (x{BONUS})", (Dictionary<string, object>)null);
		val.SetTextVariable("TIER", medicalTier);
		val.SetTextVariable("COST", generalTreatmentCost);
		val.SetTextVariable("GOLD", text);
		val.SetTextVariable("BONUS", tierRecoveryBonus.ToString("F1"));
		list2.Add(new InquiryElement((object)"standard", ((object)val).ToString(), (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		foreach (HealingHerb item in availableHerbs)
		{
			int generalTreatmentCost2 = TreatmentSystem.GetGeneralTreatmentCost(Hero.MainHero, currentSettlement, item);
			float treatmentRecoveryBonus = item.GetTreatmentRecoveryBonus();
			Hero mainHero2 = Hero.MainHero;
			bool flag2 = ((mainHero2 != null) ? mainHero2.Gold : 0) >= generalTreatmentCost2;
			list2.Add(new InquiryElement((object)item, $"{item.Name} — {generalTreatmentCost2} {text} (x{treatmentRecoveryBonus:F1})", (ImageIdentifier)null, flag2, flag2 ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		TextObject val2 = new TextObject("{=AIInfluence_SelectTreatmentMethod}Medical level: {TIER_NAME} ({TIER}/4). Select treatment method:", (Dictionary<string, object>)null);
		val2.SetTextVariable("TIER_NAME", tierName);
		val2.SetTextVariable("TIER", medicalTier);
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_TreatPlayer}Treat player", (Dictionary<string, object>)null)).ToString(), ((object)val2).ToString(), list2, true, 1, 1, ((object)new TextObject("{=AIInfluence_Treat}Treat", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnPlayerTreatmentSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnPlayerTreatmentSelected(List<InquiryElement> selected)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		if (selected == null || selected.Count == 0)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		object identifier = selected[0].Identifier;
		HealingHerb healingHerb = identifier as HealingHerb;
		if (TreatmentSystem.TreatHeroGeneral(Hero.MainHero, currentSettlement, healingHerb))
		{
			string text = ((healingHerb != null) ? healingHerb.Name.ToString() : ((object)new TextObject("{=AIInfluence_StandardTreatment}Standard Treatment", (Dictionary<string, object>)null)).ToString());
			TextObject val = new TextObject("{=AIInfluence_TreatmentStartedGeneral}Treatment started ({METHOD}).", (Dictionary<string, object>)null);
			val.SetTextVariable("METHOD", text);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString()));
			DiseaseManager.Instance?.SaveAll();
		}
		else
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_TreatmentFailed}Treatment failed (not enough gold?).", (Dictionary<string, object>)null)).ToString()));
		}
		GameMenu.SwitchToMenu("hospital_menu");
	}

	private static bool TreatCompanionsCondition(MenuCallbackArgs args)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		List<Hero> availableCompanionsForTreatment = TreatmentSystem.GetAvailableCompanionsForTreatment(currentSettlement);
		TextObject val = new TextObject("{=AIInfluence_TreatCompanions}Treat companions ({COUNT})", (Dictionary<string, object>)null);
		val.SetTextVariable("COUNT", availableCompanionsForTreatment.Count);
		MBTextManager.SetTextVariable("HOSPITAL_TREAT_COMPANIONS_TEXT", val, false);
		args.optionLeaveType = (LeaveType)18;
		args.IsEnabled = availableCompanionsForTreatment.Count > 0;
		if (availableCompanionsForTreatment.Count == 0)
		{
			args.Tooltip = new TextObject("{=AIInfluence_NoSickCompanions}No sick companions.", (Dictionary<string, object>)null);
		}
		return true;
	}

	private static void TreatCompanionsConsequence(MenuCallbackArgs args)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		List<Hero> availableCompanionsForTreatment = TreatmentSystem.GetAvailableCompanionsForTreatment(currentSettlement);
		if (availableCompanionsForTreatment.Count == 0)
		{
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list = new List<InquiryElement>();
		foreach (Hero item in availableCompanionsForTreatment)
		{
			List<DiseaseInstance> list2 = DiseaseManager.Instance?.GetHeroDiseases(item);
			int num = 0;
			foreach (DiseaseInstance item2 in list2 ?? new List<DiseaseInstance>())
			{
				if (!item2.IsTreated && !item2.HasPostTreatmentEffect)
				{
					num += TreatmentSystem.GetTreatmentCost(item, item2, currentSettlement);
				}
			}
			int num2 = 0;
			foreach (DiseaseInstance item3 in list2 ?? new List<DiseaseInstance>())
			{
				if (!item3.IsTreated && !item3.HasPostTreatmentEffect)
				{
					num2++;
				}
			}
			string text2 = ((object)new TextObject("{=AIInfluence_DiseasesCount}({COUNT} diseases)", (Dictionary<string, object>)null).SetTextVariable("COUNT", num2)).ToString();
			Hero mainHero = Hero.MainHero;
			bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= num;
			list.Add(new InquiryElement((object)item, $"{item.Name} — {num} {text} {text2}", (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_CompanionTreatmentTitle}Companion treatment", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_SelectCompanionToTreat}Select a companion to treat:", (Dictionary<string, object>)null)).ToString(), list, true, 1, 1, ((object)new TextObject("{=AIInfluence_Treat}Treat", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnCompanionTreatmentSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnCompanionTreatmentSelected(List<InquiryElement> selected)
	{
		if (selected == null || selected.Count == 0)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		object identifier = selected[0].Identifier;
		Hero val = (Hero)((identifier is Hero) ? identifier : null);
		if (val != null)
		{
			_selectedCompanionForTreatment = val;
			ShowCompanionTreatmentOptions(val);
		}
	}

	private static void ShowCompanionTreatmentOptions(Hero companion)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(companion);
		if (list == null || list.Count == 0)
		{
			return;
		}
		if (list.Count((DiseaseInstance i) => !i.IsTreated && !i.HasPostTreatmentEffect) == 0)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NoTreatableDiseases}No diseases require treatment.", (Dictionary<string, object>)null)).ToString()));
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list2 = new List<InquiryElement>();
		int medicalTier = TreatmentSystem.GetMedicalTier(currentSettlement);
		float tierRecoveryBonus = TreatmentSystem.GetTierRecoveryBonus(medicalTier);
		int generalTreatmentCost = TreatmentSystem.GetGeneralTreatmentCost(companion, currentSettlement);
		Hero mainHero = Hero.MainHero;
		bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= generalTreatmentCost;
		TextObject val = new TextObject("{=AIInfluence_HospitalTreatment}Hospital treatment (level {TIER}/4) — {COST} {GOLD} (x{BONUS})", (Dictionary<string, object>)null);
		val.SetTextVariable("TIER", medicalTier);
		val.SetTextVariable("COST", generalTreatmentCost);
		val.SetTextVariable("GOLD", text);
		val.SetTextVariable("BONUS", tierRecoveryBonus.ToString("F1"));
		list2.Add(new InquiryElement((object)"standard", ((object)val).ToString(), (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		foreach (HealingHerb item in availableHerbs)
		{
			int generalTreatmentCost2 = TreatmentSystem.GetGeneralTreatmentCost(companion, currentSettlement, item);
			float treatmentRecoveryBonus = item.GetTreatmentRecoveryBonus();
			Hero mainHero2 = Hero.MainHero;
			bool flag2 = ((mainHero2 != null) ? mainHero2.Gold : 0) >= generalTreatmentCost2;
			list2.Add(new InquiryElement((object)item, $"{item.Name} — {generalTreatmentCost2} {text} (x{treatmentRecoveryBonus:F1})", (ImageIdentifier)null, flag2, flag2 ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		TextObject val2 = new TextObject("{=AIInfluence_SelectCompanionTreatmentDesc}Select treatment method for {NAME}:", (Dictionary<string, object>)null);
		val2.SetTextVariable("NAME", companion.Name);
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_CompanionTreatmentTitle}Companion treatment", (Dictionary<string, object>)null)).ToString(), ((object)val2).ToString(), list2, true, 1, 1, ((object)new TextObject("{=AIInfluence_Treat}Treat", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnCompanionTreatmentMethodSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnCompanionTreatmentMethodSelected(List<InquiryElement> selected)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		Hero selectedCompanionForTreatment = _selectedCompanionForTreatment;
		_selectedCompanionForTreatment = null;
		if (selected == null || selected.Count == 0 || selectedCompanionForTreatment == null)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		object identifier = selected[0].Identifier;
		HealingHerb healingHerb = identifier as HealingHerb;
		if (TreatmentSystem.TreatCompanionGeneral(selectedCompanionForTreatment, currentSettlement, Hero.MainHero, healingHerb))
		{
			string text = ((healingHerb != null) ? healingHerb.Name.ToString() : ((object)new TextObject("{=AIInfluence_StandardTreatment}Standard Treatment", (Dictionary<string, object>)null)).ToString());
			TextObject val = new TextObject("{=AIInfluence_CompanionTreatmentStarted}Treatment of {NAME} started ({METHOD}).", (Dictionary<string, object>)null);
			val.SetTextVariable("NAME", selectedCompanionForTreatment.Name);
			val.SetTextVariable("METHOD", text);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString()));
			DiseaseManager.Instance?.SaveAll();
		}
		else
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_TreatmentFailed}Treatment failed (not enough gold?).", (Dictionary<string, object>)null)).ToString()));
		}
		GameMenu.SwitchToMenu("hospital_menu");
	}

	private static bool TreatTroopsCondition(MenuCallbackArgs args)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		int num = 0;
		int num2 = 0;
		if (MobileParty.MainParty != null)
		{
			List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(MobileParty.MainParty);
			if (list != null)
			{
				foreach (DiseaseInstance item3 in list)
				{
					if (!item3.HasPostTreatmentEffect && !item3.IsRecovered)
					{
						if (item3.IsTreated)
						{
							num2++;
						}
						else
						{
							num++;
						}
					}
				}
			}
		}
		bool flag = num > 0 || num2 > 0;
		if (num > 0)
		{
			(int infectedCount, int totalCount, float progress, Dictionary<int, int> tierDistribution) partyTroopInfectionInfo = TreatmentSystem.GetPartyTroopInfectionInfo(MobileParty.MainParty);
			int item = partyTroopInfectionInfo.infectedCount;
			int item2 = partyTroopInfectionInfo.totalCount;
			TextObject val = new TextObject("{=AIInfluence_TreatTroops}Treat troops ({INFECTED}/{TOTAL} infected)", (Dictionary<string, object>)null);
			val.SetTextVariable("INFECTED", item);
			val.SetTextVariable("TOTAL", item2);
			MBTextManager.SetTextVariable("HOSPITAL_TREAT_TROOPS_TEXT", val, false);
		}
		else if (num2 > 0)
		{
			TextObject val2 = new TextObject("{=AIInfluence_ChangeTroopTreatment}Change troop treatment ({COUNT})", (Dictionary<string, object>)null);
			val2.SetTextVariable("COUNT", num2);
			MBTextManager.SetTextVariable("HOSPITAL_TREAT_TROOPS_TEXT", val2, false);
		}
		else
		{
			MBTextManager.SetTextVariable("HOSPITAL_TREAT_TROOPS_TEXT", new TextObject("{=AIInfluence_TreatTroopsSimple}Treat troops", (Dictionary<string, object>)null), false);
		}
		args.optionLeaveType = (LeaveType)18;
		args.IsEnabled = flag;
		if (!flag)
		{
			args.Tooltip = new TextObject("{=AIInfluence_YourTroopsHealthy}Your troops are healthy.", (Dictionary<string, object>)null);
		}
		return true;
	}

	private static void TreatTroopsConsequence(MenuCallbackArgs args)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		if (MobileParty.MainParty == null)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyDiseases(MobileParty.MainParty);
		if (list == null || list.Count == 0)
		{
			return;
		}
		List<DiseaseInstance> list2 = list.Where((DiseaseInstance d) => !d.HasPostTreatmentEffect && !d.IsRecovered).ToList();
		if (list2.Count == 0)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NoTreatableDiseases}No diseases require treatment.", (Dictionary<string, object>)null)).ToString()));
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Disease_Soldiers}soldiers", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list3 = new List<InquiryElement>();
		TroopRoster memberRoster = MobileParty.MainParty.MemberRoster;
		int num = ((memberRoster != null) ? memberRoster.TotalManCount : 0);
		int num2 = list2.Sum((DiseaseInstance d) => d.InfectedTroopCount);
		float infectionRateFraction = ((num > 0) ? ((float)num2 / (float)num) : 0f);
		TextObject val = new TextObject("{=AIInfluence_TreatAllTroops}All diseases ({COUNT} soldiers)", (Dictionary<string, object>)null);
		val.SetTextVariable("COUNT", num2);
		list3.Add(new InquiryElement((object)"all", ((object)val).ToString(), (ImageIdentifier)null, true, ""));
		foreach (DiseaseInstance item in list2)
		{
			Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
			if (disease != null)
			{
				string text2 = (item.IsTreated ? (" " + ((object)new TextObject("{=AIInfluence_UnderTreatment}(under treatment)", (Dictionary<string, object>)null)).ToString()) : "");
				string singleDiseaseHintForTroops = DiseaseUI.GetSingleDiseaseHintForTroops(item, infectionRateFraction);
				list3.Add(new InquiryElement((object)item, $"{disease.Name} — {item.InfectedTroopCount} {text} ({item.DiseaseProgress:F0}%){text2}", (ImageIdentifier)null, true, singleDiseaseHintForTroops));
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(DiseaseUI.GetCompactTroopDiseaseSummary(MobileParty.MainParty));
		stringBuilder.Append(((object)new TextObject("{=AIInfluence_SelectDiseaseGroup}Select which troops to treat:", (Dictionary<string, object>)null)).ToString());
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_TroopTreatmentTitle}Troop treatment", (Dictionary<string, object>)null)).ToString(), stringBuilder.ToString(), list3, true, 1, 1, ((object)new TextObject("{=AIInfluence_Next}Next", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnDiseaseGroupSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnDiseaseGroupSelected(List<InquiryElement> selected)
	{
		if (selected == null || selected.Count == 0)
		{
			GameMenu.SwitchToMenu("hospital_menu");
		}
		else
		{
			if (MobileParty.MainParty == null)
			{
				return;
			}
			List<DiseaseInstance> list = (DiseaseManager.Instance?.GetPartyDiseases(MobileParty.MainParty))?.Where((DiseaseInstance d) => !d.HasPostTreatmentEffect && !d.IsRecovered).ToList();
			if (list == null || list.Count == 0)
			{
				return;
			}
			object identifier = selected[0].Identifier;
			if (identifier is string text && text == "all")
			{
				_selectedTroopDiseasesForTreatment = list;
			}
			else
			{
				if (!(identifier is DiseaseInstance item))
				{
					GameMenu.SwitchToMenu("hospital_menu");
					return;
				}
				_selectedTroopDiseasesForTreatment = new List<DiseaseInstance> { item };
			}
			ShowTroopTreatmentMethodSelection();
		}
	}

	private static void ShowTroopTreatmentMethodSelection()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		List<DiseaseInstance> selectedTroopDiseasesForTreatment = _selectedTroopDiseasesForTreatment;
		if (selectedTroopDiseasesForTreatment == null || selectedTroopDiseasesForTreatment.Count == 0)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list = new List<InquiryElement>();
		int num = 0;
		foreach (DiseaseInstance item in selectedTroopDiseasesForTreatment)
		{
			num += TreatmentSystem.GetTroopTreatmentCost(item, currentSettlement);
		}
		int medicalTier = TreatmentSystem.GetMedicalTier(currentSettlement);
		float tierRecoveryBonus = TreatmentSystem.GetTierRecoveryBonus(medicalTier);
		Hero mainHero = Hero.MainHero;
		bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= num;
		TextObject val = new TextObject("{=AIInfluence_HospitalTreatment}Hospital treatment (level {TIER}/4) — {COST} {GOLD} (x{BONUS})", (Dictionary<string, object>)null);
		val.SetTextVariable("TIER", medicalTier);
		val.SetTextVariable("COST", num);
		val.SetTextVariable("GOLD", text);
		val.SetTextVariable("BONUS", tierRecoveryBonus.ToString("F1"));
		list.Add(new InquiryElement((object)"standard", ((object)val).ToString(), (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		foreach (HealingHerb item2 in availableHerbs)
		{
			int num2 = 0;
			foreach (DiseaseInstance item3 in selectedTroopDiseasesForTreatment)
			{
				num2 += TreatmentSystem.GetTroopTreatmentCostWithHerb(item3, currentSettlement, item2);
			}
			float treatmentRecoveryBonus = item2.GetTreatmentRecoveryBonus();
			Hero mainHero2 = Hero.MainHero;
			bool flag2 = ((mainHero2 != null) ? mainHero2.Gold : 0) >= num2;
			list.Add(new InquiryElement((object)item2, $"{item2.Name} — {num2} {text} (x{treatmentRecoveryBonus:F1})", (ImageIdentifier)null, flag2, flag2 ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		int num3 = selectedTroopDiseasesForTreatment.Sum((DiseaseInstance d) => d.InfectedTroopCount);
		TextObject val2 = new TextObject("{=AIInfluence_TroopTreatmentMethodDesc}Treating {COUNT} soldiers. Select treatment method:", (Dictionary<string, object>)null);
		val2.SetTextVariable("COUNT", num3);
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_TroopTreatmentTitle}Troop treatment", (Dictionary<string, object>)null)).ToString(), ((object)val2).ToString(), list, true, 1, 1, ((object)new TextObject("{=AIInfluence_Treat}Treat", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnTroopTreatmentMethodSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnTroopTreatmentMethodSelected(List<InquiryElement> selected)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		List<DiseaseInstance> selectedTroopDiseasesForTreatment = _selectedTroopDiseasesForTreatment;
		_selectedTroopDiseasesForTreatment = null;
		if (selected == null || selected.Count == 0 || selectedTroopDiseasesForTreatment == null)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		object identifier = selected[0].Identifier;
		HealingHerb healingHerb = identifier as HealingHerb;
		int num = 0;
		bool flag = true;
		foreach (DiseaseInstance item in selectedTroopDiseasesForTreatment)
		{
			if ((healingHerb == null) ? TreatmentSystem.TreatTroops(item, currentSettlement, Hero.MainHero) : TreatmentSystem.TreatTroopsWithHerb(item, currentSettlement, healingHerb, Hero.MainHero))
			{
				num++;
			}
			else
			{
				flag = false;
			}
		}
		if (num > 0)
		{
			string text = ((healingHerb != null) ? healingHerb.Name.ToString() : ((object)new TextObject("{=AIInfluence_StandardTreatment}Standard Treatment", (Dictionary<string, object>)null)).ToString());
			TextObject val = new TextObject("{=AIInfluence_TroopTreatmentStartedMethod}Troop treatment started ({METHOD}).", (Dictionary<string, object>)null);
			val.SetTextVariable("METHOD", text);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString()));
			DiseaseManager.Instance?.SaveAll();
		}
		else if (!flag)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		GameMenu.SwitchToMenu("hospital_menu");
	}

	private static bool TreatPrisonersCondition(MenuCallbackArgs args)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		MobileParty mainParty = MobileParty.MainParty;
		if (mainParty == null || mainParty.PrisonRoster == null)
		{
			MBTextManager.SetTextVariable("HOSPITAL_TREAT_PRISONERS_TEXT", new TextObject("{=AIInfluence_TreatPrisonersSimple}Treat prisoners", (Dictionary<string, object>)null), false);
			args.optionLeaveType = (LeaveType)18;
			args.IsEnabled = false;
			args.Tooltip = new TextObject("{=AIInfluence_NoPrisoners}You have no prisoners.", (Dictionary<string, object>)null);
			return true;
		}
		List<DiseaseInstance> source = DiseaseManager.Instance?.GetPartyPrisonerDiseases(mainParty) ?? new List<DiseaseInstance>();
		List<DiseaseInstance> source2 = source.Where((DiseaseInstance d) => !d.IsRecovered).ToList();
		List<Hero> list = new List<Hero>();
		if (mainParty.PrisonRoster != null)
		{
			for (int num = 0; num < mainParty.PrisonRoster.Count; num++)
			{
				TroopRosterElement elementCopyAtIndex = mainParty.PrisonRoster.GetElementCopyAtIndex(num);
				CharacterObject character = elementCopyAtIndex.Character;
				if (character == null || !((BasicCharacterObject)character).IsHero)
				{
					continue;
				}
				Hero heroObject = elementCopyAtIndex.Character.HeroObject;
				if (heroObject != null)
				{
					DiseaseManager instance = DiseaseManager.Instance;
					if (instance != null && instance.IsHeroInfected(heroObject))
					{
						list.Add(heroObject);
					}
				}
			}
		}
		int num2 = source2.Sum((DiseaseInstance d) => d.InfectedTroopCount);
		int count = list.Count;
		int num3 = num2 + count;
		if (num3 > 0)
		{
			TextObject val = new TextObject("{=AIInfluence_TreatPrisoners}Treat prisoners ({SICK} sick)", (Dictionary<string, object>)null);
			val.SetTextVariable("SICK", num3);
			MBTextManager.SetTextVariable("HOSPITAL_TREAT_PRISONERS_TEXT", val, false);
		}
		else
		{
			MBTextManager.SetTextVariable("HOSPITAL_TREAT_PRISONERS_TEXT", new TextObject("{=AIInfluence_TreatPrisonersSimple}Treat prisoners", (Dictionary<string, object>)null), false);
		}
		args.optionLeaveType = (LeaveType)18;
		args.IsEnabled = num3 > 0;
		if (num3 <= 0)
		{
			args.Tooltip = new TextObject("{=AIInfluence_PrisonersHealthy}Your prisoners are healthy.", (Dictionary<string, object>)null);
		}
		return true;
	}

	private static void TreatPrisonersConsequence(MenuCallbackArgs args)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		MobileParty mainParty = MobileParty.MainParty;
		if (mainParty == null)
		{
			return;
		}
		List<InquiryElement> list = new List<InquiryElement>();
		string text = ((object)new TextObject("{=AIInfluence_Disease_Soldiers}soldiers", (Dictionary<string, object>)null)).ToString();
		List<DiseaseInstance> source = DiseaseManager.Instance?.GetPartyPrisonerDiseases(mainParty) ?? new List<DiseaseInstance>();
		List<DiseaseInstance> list2 = source.Where((DiseaseInstance d) => !d.IsRecovered && !d.HasPostTreatmentEffect).ToList();
		List<Hero> list3 = new List<Hero>();
		if (mainParty.PrisonRoster != null)
		{
			for (int num = 0; num < mainParty.PrisonRoster.Count; num++)
			{
				TroopRosterElement elementCopyAtIndex = mainParty.PrisonRoster.GetElementCopyAtIndex(num);
				CharacterObject character = elementCopyAtIndex.Character;
				if (character == null || !((BasicCharacterObject)character).IsHero)
				{
					continue;
				}
				Hero heroObject = elementCopyAtIndex.Character.HeroObject;
				if (heroObject != null)
				{
					DiseaseManager instance = DiseaseManager.Instance;
					if (instance != null && instance.IsHeroInfected(heroObject))
					{
						list3.Add(heroObject);
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			int num2 = list2.Sum((DiseaseInstance d) => d.InfectedTroopCount);
			if (list2.Count > 1)
			{
				TextObject val = new TextObject("{=AIInfluence_TreatAllPrisoners}All prisoner diseases ({COUNT} soldiers)", (Dictionary<string, object>)null);
				val.SetTextVariable("COUNT", num2);
				list.Add(new InquiryElement((object)"all_prisoners", ((object)val).ToString(), (ImageIdentifier)null, true, ""));
			}
			foreach (DiseaseInstance item in list2)
			{
				Disease disease = DiseaseManager.Instance?.GetDiseaseById(item.DiseaseId);
				if (disease != null)
				{
					string text2 = (item.IsTreated ? (" " + ((object)new TextObject("{=AIInfluence_UnderTreatment}(under treatment)", (Dictionary<string, object>)null)).ToString()) : "");
					list.Add(new InquiryElement((object)item, $"{disease.Name} — {item.InfectedTroopCount} {text} ({item.DiseaseProgress:F0}%){text2}", (ImageIdentifier)null, true, ""));
				}
			}
		}
		string text3 = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		foreach (Hero item2 in list3)
		{
			List<DiseaseInstance> list4 = (DiseaseManager.Instance?.GetHeroDiseases(item2))?.Where((DiseaseInstance i) => !i.IsTreated && !i.HasPostTreatmentEffect).ToList() ?? new List<DiseaseInstance>();
			if (list4.Count != 0)
			{
				string arg = string.Join(", ", list4.Select((DiseaseInstance i) => i.DiseaseName ?? "?"));
				list.Add(new InquiryElement((object)item2, $"{item2.Name} — {arg} ({list4.First().DiseaseProgress:F0}%)", (ImageIdentifier)null, true, ""));
			}
		}
		if (list.Count == 0)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NoTreatableDiseases}No diseases require treatment.", (Dictionary<string, object>)null)).ToString()));
		}
		else
		{
			MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_PrisonerTreatmentTitle}Prisoner treatment", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_SelectPrisonerToTreat}Select prisoners to treat:", (Dictionary<string, object>)null)).ToString(), list, true, 1, 1, ((object)new TextObject("{=AIInfluence_Next}Next", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnPrisonerGroupSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
		}
	}

	private static void OnPrisonerGroupSelected(List<InquiryElement> selected)
	{
		if (selected == null || selected.Count == 0)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		object identifier = selected[0].Identifier;
		Hero val = (Hero)((identifier is Hero) ? identifier : null);
		if (val != null)
		{
			_selectedPrisonerHeroForTreatment = val;
			_selectedPrisonerDiseasesForTreatment = null;
			ShowPrisonerLordTreatmentOptions(val);
			return;
		}
		_selectedPrisonerHeroForTreatment = null;
		if (identifier is string text && text == "all_prisoners")
		{
			List<DiseaseInstance> list = DiseaseManager.Instance?.GetPartyPrisonerDiseases(MobileParty.MainParty)?.Where((DiseaseInstance d) => !d.IsRecovered && !d.HasPostTreatmentEffect).ToList();
			_selectedPrisonerDiseasesForTreatment = list ?? new List<DiseaseInstance>();
		}
		else
		{
			if (!(identifier is DiseaseInstance item))
			{
				GameMenu.SwitchToMenu("hospital_menu");
				return;
			}
			_selectedPrisonerDiseasesForTreatment = new List<DiseaseInstance> { item };
		}
		ShowPrisonerTroopTreatmentMethodSelection();
	}

	private static void ShowPrisonerLordTreatmentOptions(Hero lord)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<DiseaseInstance> list = DiseaseManager.Instance?.GetHeroDiseases(lord);
		if (list == null || list.Count == 0)
		{
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list2 = new List<InquiryElement>();
		int medicalTier = TreatmentSystem.GetMedicalTier(currentSettlement);
		float tierRecoveryBonus = TreatmentSystem.GetTierRecoveryBonus(medicalTier);
		int generalTreatmentCost = TreatmentSystem.GetGeneralTreatmentCost(lord, currentSettlement);
		Hero mainHero = Hero.MainHero;
		bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= generalTreatmentCost;
		TextObject val = new TextObject("{=AIInfluence_HospitalTreatment}Hospital treatment (level {TIER}/4) — {COST} {GOLD} (x{BONUS})", (Dictionary<string, object>)null);
		val.SetTextVariable("TIER", medicalTier);
		val.SetTextVariable("COST", generalTreatmentCost);
		val.SetTextVariable("GOLD", text);
		val.SetTextVariable("BONUS", tierRecoveryBonus.ToString("F1"));
		list2.Add(new InquiryElement((object)"standard", ((object)val).ToString(), (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		foreach (HealingHerb item in availableHerbs)
		{
			int generalTreatmentCost2 = TreatmentSystem.GetGeneralTreatmentCost(lord, currentSettlement, item);
			float treatmentRecoveryBonus = item.GetTreatmentRecoveryBonus();
			Hero mainHero2 = Hero.MainHero;
			bool flag2 = ((mainHero2 != null) ? mainHero2.Gold : 0) >= generalTreatmentCost2;
			list2.Add(new InquiryElement((object)item, $"{item.Name} — {generalTreatmentCost2} {text} (x{treatmentRecoveryBonus:F1})", (ImageIdentifier)null, flag2, flag2 ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_PrisonerLordTreatmentTitle}Treat prisoner lord", (Dictionary<string, object>)null)).ToString(), $"{lord.Name}", list2, true, 1, 1, ((object)new TextObject("{=AIInfluence_Treat}Treat", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnPrisonerLordTreatmentSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnPrisonerLordTreatmentSelected(List<InquiryElement> selected)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		Hero selectedPrisonerHeroForTreatment = _selectedPrisonerHeroForTreatment;
		_selectedPrisonerHeroForTreatment = null;
		if (selected == null || selected.Count == 0 || selectedPrisonerHeroForTreatment == null)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		object identifier = selected[0].Identifier;
		HealingHerb healingHerb = identifier as HealingHerb;
		if ((healingHerb == null) ? TreatmentSystem.TreatCompanionGeneral(selectedPrisonerHeroForTreatment, currentSettlement, Hero.MainHero) : TreatmentSystem.TreatCompanionGeneral(selectedPrisonerHeroForTreatment, currentSettlement, Hero.MainHero, healingHerb))
		{
			string text = ((healingHerb != null) ? healingHerb.Name.ToString() : ((object)new TextObject("{=AIInfluence_StandardTreatment}Standard Treatment", (Dictionary<string, object>)null)).ToString());
			TextObject val = new TextObject("{=AIInfluence_PrisonerLordTreated}Prisoner {LORD} is being treated ({METHOD}).", (Dictionary<string, object>)null);
			val.SetTextVariable("LORD", selectedPrisonerHeroForTreatment.Name);
			val.SetTextVariable("METHOD", text);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString()));
			DiseaseManager.Instance?.SaveAll();
		}
		else
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		GameMenu.SwitchToMenu("hospital_menu");
	}

	private static void ShowPrisonerTroopTreatmentMethodSelection()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		List<DiseaseInstance> selectedPrisonerDiseasesForTreatment = _selectedPrisonerDiseasesForTreatment;
		if (selectedPrisonerDiseasesForTreatment == null || selectedPrisonerDiseasesForTreatment.Count == 0)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list = new List<InquiryElement>();
		int num = 0;
		foreach (DiseaseInstance item in selectedPrisonerDiseasesForTreatment)
		{
			num += TreatmentSystem.GetTroopTreatmentCost(item, currentSettlement);
		}
		int medicalTier = TreatmentSystem.GetMedicalTier(currentSettlement);
		float tierRecoveryBonus = TreatmentSystem.GetTierRecoveryBonus(medicalTier);
		Hero mainHero = Hero.MainHero;
		bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= num;
		TextObject val = new TextObject("{=AIInfluence_HospitalTreatment}Hospital treatment (level {TIER}/4) — {COST} {GOLD} (x{BONUS})", (Dictionary<string, object>)null);
		val.SetTextVariable("TIER", medicalTier);
		val.SetTextVariable("COST", num);
		val.SetTextVariable("GOLD", text);
		val.SetTextVariable("BONUS", tierRecoveryBonus.ToString("F1"));
		list.Add(new InquiryElement((object)"standard", ((object)val).ToString(), (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		foreach (HealingHerb item2 in availableHerbs)
		{
			int num2 = 0;
			foreach (DiseaseInstance item3 in selectedPrisonerDiseasesForTreatment)
			{
				num2 += TreatmentSystem.GetTroopTreatmentCostWithHerb(item3, currentSettlement, item2);
			}
			float treatmentRecoveryBonus = item2.GetTreatmentRecoveryBonus();
			Hero mainHero2 = Hero.MainHero;
			bool flag2 = ((mainHero2 != null) ? mainHero2.Gold : 0) >= num2;
			list.Add(new InquiryElement((object)item2, $"{item2.Name} — {num2} {text} (x{treatmentRecoveryBonus:F1})", (ImageIdentifier)null, flag2, flag2 ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		int num3 = selectedPrisonerDiseasesForTreatment.Sum((DiseaseInstance d) => d.InfectedTroopCount);
		TextObject val2 = new TextObject("{=AIInfluence_PrisonerTreatmentMethodDesc}Treating {COUNT} prisoners. Select treatment method:", (Dictionary<string, object>)null);
		val2.SetTextVariable("COUNT", num3);
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_PrisonerTreatmentTitle}Prisoner treatment", (Dictionary<string, object>)null)).ToString(), ((object)val2).ToString(), list, true, 1, 1, ((object)new TextObject("{=AIInfluence_Treat}Treat", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnPrisonerTroopTreatmentMethodSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnPrisonerTroopTreatmentMethodSelected(List<InquiryElement> selected)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		List<DiseaseInstance> selectedPrisonerDiseasesForTreatment = _selectedPrisonerDiseasesForTreatment;
		_selectedPrisonerDiseasesForTreatment = null;
		if (selected == null || selected.Count == 0 || selectedPrisonerDiseasesForTreatment == null)
		{
			GameMenu.SwitchToMenu("hospital_menu");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		object identifier = selected[0].Identifier;
		HealingHerb healingHerb = identifier as HealingHerb;
		int num = 0;
		bool flag = true;
		foreach (DiseaseInstance item in selectedPrisonerDiseasesForTreatment)
		{
			if ((healingHerb == null) ? TreatmentSystem.TreatTroops(item, currentSettlement, Hero.MainHero) : TreatmentSystem.TreatTroopsWithHerb(item, currentSettlement, healingHerb, Hero.MainHero))
			{
				num++;
			}
			else
			{
				flag = false;
			}
		}
		if (num > 0)
		{
			string text = ((healingHerb != null) ? healingHerb.Name.ToString() : ((object)new TextObject("{=AIInfluence_StandardTreatment}Standard Treatment", (Dictionary<string, object>)null)).ToString());
			TextObject val = new TextObject("{=AIInfluence_PrisonerTreatmentStarted}Prisoner treatment started ({METHOD}).", (Dictionary<string, object>)null);
			val.SetTextVariable("METHOD", text);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString()));
			DiseaseManager.Instance?.SaveAll();
		}
		else if (!flag)
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		GameMenu.SwitchToMenu("hospital_menu");
	}

	private static bool PreventionCondition(MenuCallbackArgs args)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		args.optionLeaveType = (LeaveType)14;
		args.IsEnabled = availableHerbs.Count > 0;
		if (availableHerbs.Count == 0)
		{
			args.Tooltip = new TextObject("{=AIInfluence_HerbsUnavailable}Healing herbs are not available in this settlement.", (Dictionary<string, object>)null);
		}
		return true;
	}

	private static void PreventionConsequence(MenuCallbackArgs args)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		List<HealingHerb> availableHerbs = PreventionSystem.GetAvailableHerbs(currentSettlement);
		if (availableHerbs.Count == 0)
		{
			return;
		}
		string text = ((object)new TextObject("{=AIInfluence_Gold}gold", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list = new List<InquiryElement>();
		foreach (HealingHerb item in availableHerbs)
		{
			int herbCost = PreventionSystem.GetHerbCost(item, currentSettlement);
			TextObject val = new TextObject("{=AIInfluence_HerbImmunityHint}+{BONUS}% immunity for {DAYS} days", (Dictionary<string, object>)null);
			val.SetTextVariable("BONUS", (item.ImmunityBonus * 100f).ToString("F0"));
			val.SetTextVariable("DAYS", item.DurationDays);
			Hero mainHero = Hero.MainHero;
			bool flag = ((mainHero != null) ? mainHero.Gold : 0) >= herbCost;
			list.Add(new InquiryElement((object)item, $"{item.Name} — {herbCost} {text} ({val})", (ImageIdentifier)null, flag, flag ? "" : ((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
		}
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_PreventionTitle}Prevention", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_PreventionDescription}Choose herbs to buy:", (Dictionary<string, object>)null)).ToString(), list, true, 1, 1, ((object)new TextObject("{=AIInfluence_Buy}Buy", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnHerbSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
	}

	private static void OnHerbSelected(List<InquiryElement> selected)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		if (selected != null && selected.Count != 0 && selected[0].Identifier is HealingHerb healingHerb)
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (PreventionSystem.BuyHerb(Hero.MainHero, healingHerb, currentSettlement))
			{
				DiseaseManager.Instance?.SaveAll();
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_HerbImmunityUsed}You used {HERB_NAME}. Immunity bonus: +{BONUS}%", (Dictionary<string, object>)null).SetTextVariable("HERB_NAME", healingHerb.Name).SetTextVariable("BONUS", (healingHerb.ImmunityBonus * 100f).ToString("F0"))).ToString()));
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NotEnoughGold}Not enough gold.", (Dictionary<string, object>)null)).ToString()));
			}
			GameMenu.SwitchToMenu("hospital_menu");
		}
	}

	private static bool LeaveCondition(MenuCallbackArgs args)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		args.optionLeaveType = (LeaveType)16;
		return true;
	}

	private static void LeaveConsequence(MenuCallbackArgs args)
	{
		GameMenu.SwitchToMenu(_parentMenuId);
	}
}
