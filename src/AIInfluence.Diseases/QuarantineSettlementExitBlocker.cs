using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AIInfluence.Patches.Diseases;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using OnConditionDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConditionDelegate;
using OnConsequenceDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConsequenceDelegate;

namespace AIInfluence.Diseases;

public class QuarantineSettlementExitBlocker : CampaignBehaviorBase
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static OnInitDelegate _003C1_003E__OnInitQuarantineBlockedMenu;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static OnConditionDelegate _003C_003E9__6_0;

		public static OnConsequenceDelegate _003C_003E9__6_1;

		internal bool _003CAddMenus_003Eb__6_0(MenuCallbackArgs args)
		{
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			args.optionLeaveType = (LeaveType)16;
			return true;
		}

		internal void _003CAddMenus_003Eb__6_1(MenuCallbackArgs _)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			MobileParty mainParty = MobileParty.MainParty;
			if (((mainParty != null) ? mainParty.CurrentSettlement : null) != null)
			{
				MobileParty.MainParty.Position = MobileParty.MainParty.CurrentSettlement.GatePosition;
			}
			PlayerEncounter.LeaveSettlement();
			PlayerEncounter.Finish(true);
			Campaign.Current.SaveHandler.SignalAutoSave();
		}
	}

	public const string QuarantineBlockedMenuId = "quarantine_blocked_entry";

	private static readonly string[] BlockedMenuOptionIds = new string[3] { "town_leave", "castle_leave", "leave" };

	private static readonly string[] QuarantineRestrictedOptionIds = new string[16]
	{
		"town_streets", "town_arena", "trade", "town_backstreet", "town_tavern", "town_port", "go_to_port", "visit_port", "take_a_walk_around_the_castle", "castle_prison",
		"castle_prison_cheat", "manage_garrison", "manage_production", "open_stash", "leave_troops_to_garrison", "castle_return_to_army"
	};

	public override void RegisterEvents()
	{
		CampaignEvents.SettlementEntered.AddNonSerializedListener((object)this, (Action<MobileParty, Settlement, Hero>)OnSettlementEntered);
	}

	private static void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		if (party != MobileParty.MainParty || settlement == null || settlement.IsCastle)
		{
			return;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem || DiseaseManager.Instance == null || !DiseaseManager.Instance.IsSettlementUnderQuarantine(settlement) || settlement.OwnerClan == Clan.PlayerClan)
		{
			return;
		}
		if (Hero.MainHero != null && Hero.MainHero.IsKingdomLeader)
		{
			Clan ownerClan = settlement.OwnerClan;
			if (((ownerClan != null) ? ownerClan.Kingdom : null) != null)
			{
				Kingdom kingdom = settlement.OwnerClan.Kingdom;
				Clan clan = Hero.MainHero.Clan;
				if (kingdom == ((clan != null) ? clan.Kingdom : null))
				{
					return;
				}
			}
		}
		GameMenu.SwitchToMenu("quarantine_blocked_entry");
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	public static void AddMenus(CampaignGameStarter starter)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return;
		}
		QuarantineCastleEntryPatch.RegisterMenus(starter);
		object obj = _003C_003EO._003C1_003E__OnInitQuarantineBlockedMenu;
		if (obj == null)
		{
			OnInitDelegate val = OnInitQuarantineBlockedMenu;
			_003C_003EO._003C1_003E__OnInitQuarantineBlockedMenu = val;
			obj = (object)val;
		}
		starter.AddGameMenu("quarantine_blocked_entry", "{QUARANTINE_BLOCKED_TEXT}", (OnInitDelegate)obj, (MenuOverlayType)3, (MenuFlags)0, (object)null);
		object obj2 = _003C_003Ec._003C_003E9__6_0;
		if (obj2 == null)
		{
			OnConditionDelegate val2 = delegate(MenuCallbackArgs args)
			{
				//IL_0004: Unknown result type (might be due to invalid IL or missing references)
				args.optionLeaveType = (LeaveType)16;
				return true;
			};
			_003C_003Ec._003C_003E9__6_0 = val2;
			obj2 = (object)val2;
		}
		object obj3 = _003C_003Ec._003C_003E9__6_1;
		if (obj3 == null)
		{
			OnConsequenceDelegate val3 = delegate
			{
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				MobileParty mainParty = MobileParty.MainParty;
				if (((mainParty != null) ? mainParty.CurrentSettlement : null) != null)
				{
					MobileParty.MainParty.Position = MobileParty.MainParty.CurrentSettlement.GatePosition;
				}
				PlayerEncounter.LeaveSettlement();
				PlayerEncounter.Finish(true);
				Campaign.Current.SaveHandler.SignalAutoSave();
			};
			_003C_003Ec._003C_003E9__6_1 = val3;
			obj3 = (object)val3;
		}
		starter.AddGameMenuOption("quarantine_blocked_entry", "quarantine_leave", "{=AIInfluence_QuarantineLeave}Leave", (OnConditionDelegate)obj2, (OnConsequenceDelegate)obj3, true, -1, false, (object)null);
	}

	private static void OnInitQuarantineBlockedMenu(MenuCallbackArgs args)
	{
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement?.Town != null)
		{
			args.MenuContext.SetBackgroundMeshName(((SettlementComponent)currentSettlement.Town).WaitMeshName);
		}
		TextObject quarantineEntryBlockedMessage = GetQuarantineEntryBlockedMessage(currentSettlement);
		MBTextManager.SetTextVariable("QUARANTINE_BLOCKED_TEXT", quarantineEntryBlockedMessage, false);
	}

	public static bool IsPlayerBlockedByQuarantine()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return false;
		}
		DiseaseManager instance2 = DiseaseManager.Instance;
		if (instance2 == null)
		{
			return false;
		}
		if (!instance2.IsSettlementUnderQuarantine(currentSettlement))
		{
			return false;
		}
		if (currentSettlement.OwnerClan == Clan.PlayerClan)
		{
			return false;
		}
		Hero mainHero = Hero.MainHero;
		if (((mainHero != null) ? mainHero.Clan : null) != null && currentSettlement.OwnerClan == Hero.MainHero.Clan)
		{
			return false;
		}
		if (!instance2.IsHeroInfected(Hero.MainHero))
		{
			return false;
		}
		return true;
	}

	public static TextObject GetQuarantineBlockedTooltip()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		return new TextObject("{=AIInfluence_QuarantineExitBlockedInfected}You are infected and cannot leave the quarantined settlement.", (Dictionary<string, object>)null);
	}

	public static TextObject GetQuarantineEntryBlockedMessage(Settlement settlement)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		if (settlement == null)
		{
			return new TextObject("{=AIInfluence_QuarantineEntryBlockedGeneric}This settlement is closed for quarantine. You are not allowed to enter.", (Dictionary<string, object>)null);
		}
		return new TextObject("{=AIInfluence_QuarantineEntryBlocked}{SETTLEMENT} is closed for quarantine. You are not allowed to enter.", (Dictionary<string, object>)null).SetTextVariable("SETTLEMENT", ((object)settlement.Name)?.ToString() ?? ((MBObjectBase)settlement).StringId);
	}

	public static void ShowQuarantineEntryBlockedPopup(Settlement settlement)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		string text = ((object)new TextObject("{=AIInfluence_QuarantineEntryTitle}Quarantine", (Dictionary<string, object>)null)).ToString();
		string text2 = ((object)GetQuarantineEntryBlockedMessage(settlement)).ToString();
		string text3 = ((object)new TextObject("{=AIInfluence_QuarantineEntryOK}Understood", (Dictionary<string, object>)null)).ToString();
		InformationManager.ShowInquiry(new InquiryData(text, text2, true, false, text3, (string)null, (Action)null, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), false, false);
	}

	public static bool IsBlockedOptionId(string optionId)
	{
		if (string.IsNullOrEmpty(optionId))
		{
			return false;
		}
		for (int i = 0; i < BlockedMenuOptionIds.Length; i++)
		{
			if (optionId == BlockedMenuOptionIds[i])
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsOwnerInQuarantinedSettlement()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return false;
		}
		if (DiseaseManager.Instance == null || !DiseaseManager.Instance.IsSettlementUnderQuarantine(currentSettlement))
		{
			return false;
		}
		if (currentSettlement.OwnerClan != Clan.PlayerClan)
		{
			Hero mainHero = Hero.MainHero;
			if (((mainHero != null) ? mainHero.Clan : null) == null || currentSettlement.OwnerClan != Hero.MainHero.Clan)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsInQuarantinedSettlement()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null || (!currentSettlement.IsTown && !currentSettlement.IsCastle))
		{
			return false;
		}
		if (DiseaseManager.Instance == null || !DiseaseManager.Instance.IsSettlementUnderQuarantine(currentSettlement))
		{
			return false;
		}
		return true;
	}

	public static bool IsQuarantineRestrictedOptionId(string optionId)
	{
		if (string.IsNullOrEmpty(optionId))
		{
			return false;
		}
		for (int i = 0; i < QuarantineRestrictedOptionIds.Length; i++)
		{
			if (optionId == QuarantineRestrictedOptionIds[i])
			{
				return true;
			}
		}
		return false;
	}

	public static TextObject GetQuarantineRestrictedTooltip()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		return new TextObject("{=AIInfluence_QuarantineRestricted}Closed due to quarantine.", (Dictionary<string, object>)null);
	}
}
