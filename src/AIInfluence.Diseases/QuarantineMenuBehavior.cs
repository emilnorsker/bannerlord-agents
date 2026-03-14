using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using OnConditionDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConditionDelegate;
using OnConsequenceDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConsequenceDelegate;

namespace AIInfluence.Diseases;

public class QuarantineMenuBehavior : CampaignBehaviorBase
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static OnConditionDelegate _003C0_003E__ManageQuarantineCondition;

		public static OnConsequenceDelegate _003C1_003E__ManageQuarantineConsequence;

		public static Action<List<InquiryElement>> _003C2_003E__OnQuarantineOptionSelected;
	}

	public override void RegisterEvents()
	{
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	public static void AddMenus(CampaignGameStarter starter)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || instance.EnableDiseaseSystem)
		{
			object obj = _003C_003EO._003C0_003E__ManageQuarantineCondition;
			if (obj == null)
			{
				OnConditionDelegate val = ManageQuarantineCondition;
				_003C_003EO._003C0_003E__ManageQuarantineCondition = val;
				obj = (object)val;
			}
			object obj2 = _003C_003EO._003C1_003E__ManageQuarantineConsequence;
			if (obj2 == null)
			{
				OnConsequenceDelegate val2 = ManageQuarantineConsequence;
				_003C_003EO._003C1_003E__ManageQuarantineConsequence = val2;
				obj2 = (object)val2;
			}
			starter.AddGameMenuOption("town", "manage_quarantine", "{=AIInfluence_ManageQuarantine}Manage quarantine", (OnConditionDelegate)obj, (OnConsequenceDelegate)obj2, false, 6, false, (object)null);
			object obj3 = _003C_003EO._003C0_003E__ManageQuarantineCondition;
			if (obj3 == null)
			{
				OnConditionDelegate val3 = ManageQuarantineCondition;
				_003C_003EO._003C0_003E__ManageQuarantineCondition = val3;
				obj3 = (object)val3;
			}
			object obj4 = _003C_003EO._003C1_003E__ManageQuarantineConsequence;
			if (obj4 == null)
			{
				OnConsequenceDelegate val4 = ManageQuarantineConsequence;
				_003C_003EO._003C1_003E__ManageQuarantineConsequence = val4;
				obj4 = (object)val4;
			}
			starter.AddGameMenuOption("castle", "manage_quarantine", "{=AIInfluence_ManageQuarantine}Manage quarantine", (OnConditionDelegate)obj3, (OnConsequenceDelegate)obj4, false, 6, false, (object)null);
		}
	}

	private static bool ManageQuarantineCondition(MenuCallbackArgs args)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return false;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && !instance.EnableDiseaseSystem)
		{
			return false;
		}
		bool flag = currentSettlement.OwnerClan == Clan.PlayerClan;
		int num;
		if (Hero.MainHero != null && Hero.MainHero.IsKingdomLeader)
		{
			Clan ownerClan = currentSettlement.OwnerClan;
			Kingdom obj = ((ownerClan != null) ? ownerClan.Kingdom : null);
			Clan clan = Hero.MainHero.Clan;
			num = ((obj == ((clan != null) ? clan.Kingdom : null)) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag2 = (byte)num != 0;
		if (!flag && !flag2)
		{
			return false;
		}
		args.optionLeaveType = (LeaveType)18;
		return true;
	}

	private static void ManageQuarantineConsequence(MenuCallbackArgs args)
	{
		ShowQuarantineMenu();
	}

	private static void ShowQuarantineMenu()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement != null)
		{
			List<Disease> list = DiseaseManager.Instance?.GetAllDiseasesForSettlement(currentSettlement);
			bool flag = list != null && list.Count > 0;
			bool flag2 = DiseaseManager.Instance?.IsSettlementUnderQuarantine(currentSettlement) ?? false;
			string quarantineStatusText = GetQuarantineStatusText(currentSettlement, list, flag2, flag);
			List<InquiryElement> list2 = new List<InquiryElement>();
			if (flag2)
			{
				list2.Add(new InquiryElement((object)"remove", ((object)new TextObject("{=AIInfluence_QuarantineRemove}Remove quarantine", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_QuarantineRemoveHint}Open settlement for visits", (Dictionary<string, object>)null)).ToString()));
			}
			else
			{
				string text = (currentSettlement.IsTown ? ((object)new TextObject("{=AIInfluence_QuarantineSetButtonTown}Introduce quarantine in town", (Dictionary<string, object>)null)).ToString() : (currentSettlement.IsCastle ? ((object)new TextObject("{=AIInfluence_QuarantineSetButtonCastle}Introduce quarantine in castle", (Dictionary<string, object>)null)).ToString() : ((object)new TextObject("{=AIInfluence_QuarantineSetButtonVillage}Introduce quarantine in village", (Dictionary<string, object>)null)).ToString()));
				string text2 = (flag ? ((object)new TextObject("{=AIInfluence_QuarantineSetButtonHint}Close settlement until you remove quarantine", (Dictionary<string, object>)null)).ToString() : ((object)new TextObject("{=AIInfluence_QuarantineSetNoDiseaseHint}No active disease — quarantine will impose severe economic penalties", (Dictionary<string, object>)null)).ToString());
				list2.Add(new InquiryElement((object)"set", text, (ImageIdentifier)null, true, text2));
			}
			MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_QuarantineTitle}Quarantine management", (Dictionary<string, object>)null)).ToString(), quarantineStatusText, list2, true, 1, 1, ((object)new TextObject("{=AIInfluence_Confirm}Confirm", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)OnQuarantineOptionSelected, (Action<List<InquiryElement>>)null, "", false), false, false);
		}
	}

	private static string GetQuarantineStatusText(Settlement settlement, List<Disease> diseases, bool isQuarantined, bool hasDisease)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		StringBuilder stringBuilder = new StringBuilder();
		TextObject val = new TextObject("{=AIInfluence_QuarantineSettlement}Settlement: {NAME}", (Dictionary<string, object>)null);
		val.SetTextVariable("NAME", settlement.Name);
		stringBuilder.AppendLine(((object)val).ToString());
		stringBuilder.AppendLine();
		if (diseases != null && diseases.Count > 0)
		{
			stringBuilder.Append("**").Append(((object)new TextObject("{=AIInfluence_QuarantineActiveDiseases}Active diseases", (Dictionary<string, object>)null)).ToString()).AppendLine(":**");
			foreach (Disease disease in diseases)
			{
				string text = (disease.IsQuarantined ? (" " + ((object)new TextObject("{=AIInfluence_QuarantineOnSettlement}(UNDER QUARANTINE)", (Dictionary<string, object>)null)).ToString()) : "");
				stringBuilder.AppendLine("- " + disease.Name + " (" + ((object)new TextObject("{=AIInfluence_Disease_Severity}Disease severity", (Dictionary<string, object>)null)).ToString() + " " + disease.Severity + ")" + text);
				if (disease.IsQuarantined && disease.QuarantineEndDays.HasValue)
				{
					float value = disease.QuarantineEndDays.Value;
					CampaignTime now = CampaignTime.Now;
					int num = (int)(value - (float)(now).ToDays);
					if (num > 0)
					{
						TextObject val2 = new TextObject("{=AIInfluence_QuarantineDaysLeft}Days remaining: {DAYS}", (Dictionary<string, object>)null);
						val2.SetTextVariable("DAYS", num);
						stringBuilder.AppendLine("  " + (object)val2);
					}
				}
			}
		}
		else
		{
			stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_NoActiveDiseases}No active diseases.", (Dictionary<string, object>)null)).ToString());
		}
		if (isQuarantined && !hasDisease)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(((object)new TextObject("{=AIInfluence_QuarantineNoDiseaseWarning}WARNING: No active disease — quarantine penalties are doubled!", (Dictionary<string, object>)null)).ToString());
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("**").Append(((object)new TextObject("{=AIInfluence_QuarantineEffects}Quarantine effects", (Dictionary<string, object>)null)).ToString()).AppendLine(":**");
		stringBuilder.AppendLine("- " + ((object)new TextObject("{=AIInfluence_QuarantineEffect1}Prevents disease spread", (Dictionary<string, object>)null)).ToString());
		stringBuilder.AppendLine("- " + ((object)new TextObject("{=AIInfluence_QuarantineEffect2}Blocks epidemics", (Dictionary<string, object>)null)).ToString());
		stringBuilder.AppendLine("- " + ((object)new TextObject("{=AIInfluence_QuarantineEffect3}Restricts trade and visits", (Dictionary<string, object>)null)).ToString());
		return stringBuilder.ToString();
	}

	private static void OnQuarantineOptionSelected(List<InquiryElement> selectedElements)
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		if (selectedElements == null || selectedElements.Count == 0)
		{
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		string text = selectedElements[0].Identifier as string;
		int num;
		if (Hero.MainHero != null && Hero.MainHero.IsKingdomLeader)
		{
			Clan ownerClan = currentSettlement.OwnerClan;
			Kingdom obj = ((ownerClan != null) ? ownerClan.Kingdom : null);
			Clan clan = Hero.MainHero.Clan;
			if (obj == ((clan != null) ? clan.Kingdom : null))
			{
				num = ((currentSettlement.OwnerClan != Clan.PlayerClan) ? 1 : 0);
				goto IL_0090;
			}
		}
		num = 0;
		goto IL_0090;
		IL_0090:
		bool forceByKingdomLeader = (byte)num != 0;
		if (text == "remove")
		{
			DiseaseManager.Instance?.SetQuarantine(currentSettlement, quarantined: false, 0, forceByKingdomLeader);
			TextObject val = new TextObject("{=AIInfluence_QuarantineRemoved}Quarantine lifted in {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
			val.SetTextVariable("SETTLEMENT_NAME", currentSettlement.Name);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString()));
		}
		else if (text == "set")
		{
			DiseaseManager.Instance?.SetQuarantine(currentSettlement, quarantined: true, 0, forceByKingdomLeader);
			TextObject val2 = new TextObject("{=AIInfluence_QuarantineSetManual}Quarantine set in {SETTLEMENT_NAME}. Remove it when you want.", (Dictionary<string, object>)null);
			val2.SetTextVariable("SETTLEMENT_NAME", currentSettlement.Name);
			InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString()));
		}
	}
}
