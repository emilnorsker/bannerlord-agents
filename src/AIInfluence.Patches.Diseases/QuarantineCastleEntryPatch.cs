using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AIInfluence.Diseases;
using HarmonyLib;
using Helpers;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using OnConditionDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConditionDelegate;
using OnConsequenceDelegate = TaleWorlds.CampaignSystem.GameMenus.GameMenuOption.OnConsequenceDelegate;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class QuarantineCastleEntryPatch
{
	[HarmonyPatch(typeof(DefaultSettlementAccessModel), "CanMainHeroEnterSettlement")]
	public static class CanMainHeroEnterSettlement_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(Settlement settlement, ref AccessDetails accessDetails)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Invalid comparison between Unknown and I4
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Invalid comparison between Unknown and I4
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			if (IsQuarantinedCastle(settlement) && !IsPlayerExempt(settlement) && (int)accessDetails.AccessLevel == 2 && (int)accessDetails.AccessMethod == 1)
			{
				accessDetails.AccessMethod = (AccessMethod)2;
			}
		}
	}

	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static OnInitDelegate _003C0_003E__OnInit;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static OnConditionDelegate _003C_003E9__6_0;

		public static OnConsequenceDelegate _003C_003E9__6_1;

		internal bool _003CRegisterMenus_003Eb__6_0(MenuCallbackArgs conditionArgs)
		{
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			conditionArgs.optionLeaveType = (LeaveType)16;
			return true;
		}

		internal void _003CRegisterMenus_003Eb__6_1(MenuCallbackArgs _)
		{
			GameMenu.SwitchToMenu("castle_outside");
		}
	}

	public const string QuarantineCastleEntryDeniedMenuId = "quarantine_castle_entry_denied";

	private static bool IsQuarantinedCastle(Settlement settlement)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return false;
		}
		if (DiseaseManager.Instance == null)
		{
			return false;
		}
		if (settlement == null || !settlement.IsCastle)
		{
			return false;
		}
		return DiseaseManager.Instance.IsSettlementUnderQuarantine(settlement);
	}

	private static bool IsPlayerExempt(Settlement settlement)
	{
		if (settlement.OwnerClan == Clan.PlayerClan)
		{
			return true;
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
					return true;
				}
			}
		}
		return false;
	}

	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return AccessTools.Method(typeof(EncounterGameMenuBehavior), "game_menu_request_entry_to_castle_on_consequence", (Type[])null, (Type[])null);
	}

	[HarmonyPrefix]
	public static bool Prefix()
	{
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (!IsQuarantinedCastle(currentSettlement))
		{
			return true;
		}
		if (IsPlayerExempt(currentSettlement))
		{
			return true;
		}
		GameMenu.SwitchToMenu("quarantine_castle_entry_denied");
		return false;
	}

	public static void RegisterMenus(CampaignGameStarter starter)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		object obj = _003C_003EO._003C0_003E__OnInit;
		if (obj == null)
		{
			OnInitDelegate val = OnInit;
			_003C_003EO._003C0_003E__OnInit = val;
			obj = (object)val;
		}
		starter.AddGameMenu("quarantine_castle_entry_denied", "{=!}{QUARANTINE_CASTLE_DENIED_TEXT}", (OnInitDelegate)obj, (MenuOverlayType)0, (MenuFlags)0, (object)null);
		object obj2 = _003C_003Ec._003C_003E9__6_0;
		if (obj2 == null)
		{
			OnConditionDelegate val2 = delegate(MenuCallbackArgs conditionArgs)
			{
				//IL_0004: Unknown result type (might be due to invalid IL or missing references)
				conditionArgs.optionLeaveType = (LeaveType)16;
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
				GameMenu.SwitchToMenu("castle_outside");
			};
			_003C_003Ec._003C_003E9__6_1 = val3;
			obj3 = (object)val3;
		}
		starter.AddGameMenuOption("quarantine_castle_entry_denied", "quarantine_castle_denied_back", "{=veWOovVv}Continue...", (OnConditionDelegate)obj2, (OnConsequenceDelegate)obj3, false, -1, false, (object)null);
	}

	private static void OnInit(MenuCallbackArgs args)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		args.MenuContext.SetBackgroundMeshName("encounter_guards");
		Settlement currentSettlement = Settlement.CurrentSettlement;
		TextObject val;
		if (currentSettlement != null)
		{
			val = new TextObject("{=AIInfluence_QuarantineCastleEntryDenied}The guard sergeant raises a hand before you reach the gate. \"{?PLAYER.GENDER}My lady{?}My lord{\\?}, {SETTLEMENT_NAME} is under quarantine by order of {LORD.LINK}. No one enters or leaves until the quarantine is lifted. I must ask you to turn back.\"", (Dictionary<string, object>)null);
			val.SetTextVariable("SETTLEMENT_NAME", currentSettlement.EncyclopediaLinkWithName);
			Clan ownerClan = currentSettlement.OwnerClan;
			if (ownerClan != null)
			{
				Hero leader = ownerClan.Leader;
				if (leader != null)
				{
					HeroHelper.SetPropertiesToTextObject(leader, val, "LORD");
				}
			}
		}
		else
		{
			val = new TextObject("{=AIInfluence_QuarantineCastleEntryDeniedGeneric}The guards bar your way. This castle is under quarantine. You are not permitted to enter.", (Dictionary<string, object>)null);
		}
		MBTextManager.SetTextVariable("QUARANTINE_CASTLE_DENIED_TEXT", val, false);
	}
}
