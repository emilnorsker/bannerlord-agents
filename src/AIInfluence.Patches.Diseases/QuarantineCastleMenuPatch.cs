using System;
using System.Collections.Generic;
using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch]
public static class QuarantineCastleMenuPatch
{
	[HarmonyPatch(typeof(GameMenu), "ActivateGameMenu", new Type[] { typeof(string) })]
	public static class GameMenu_ActivateGameMenu_Patch
	{
		[HarmonyPrefix]
		public static void Prefix(ref string menuId)
		{
			string replacementMenuId = GetReplacementMenuId(menuId);
			if (replacementMenuId != null)
			{
				menuId = replacementMenuId;
			}
		}
	}

	[HarmonyPatch(typeof(GameMenu), "SwitchToMenu", new Type[] { typeof(string) })]
	public static class GameMenu_SwitchToMenu_Patch
	{
		[HarmonyPrefix]
		public static void Prefix(ref string menuId)
		{
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				MenuContext currentMenuContext = current.CurrentMenuContext;
				if (currentMenuContext == null)
				{
					obj = null;
				}
				else
				{
					GameMenu gameMenu = currentMenuContext.GameMenu;
					obj = ((gameMenu != null) ? gameMenu.StringId : null);
				}
			}
			if (obj == null)
			{
				obj = "";
			}
			string text = (string)obj;
			if (text == "castle" || text == "town")
			{
				WasInCastleMenuBeforeApproach = true;
			}
			string replacementMenuId = GetReplacementMenuId(menuId);
			if (replacementMenuId != null)
			{
				menuId = replacementMenuId;
			}
			else
			{
				WasInCastleMenuBeforeApproach = false;
			}
		}
	}

	private static readonly string[] MenuIdsToIntercept = new string[4] { "castle", "town", "town_outside", "town_outside_ended" };

	internal static bool WasInCastleMenuBeforeApproach { get; set; }

	private static Settlement GetEncounterSettlement()
	{
		LocationEncounter locationEncounter = PlayerEncounter.LocationEncounter;
		if (((locationEncounter != null) ? locationEncounter.Settlement : null) != null)
		{
			return locationEncounter.Settlement;
		}
		if (Settlement.CurrentSettlement != null)
		{
			return Settlement.CurrentSettlement;
		}
		MobileParty mainParty = MobileParty.MainParty;
		if (((mainParty != null) ? mainParty.CurrentSettlement : null) != null)
		{
			return MobileParty.MainParty.CurrentSettlement;
		}
		PartyBase encounteredParty = PlayerEncounter.EncounteredParty;
		if (encounteredParty != null)
		{
			foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
			{
				if (item.Party == encounteredParty)
				{
					return item;
				}
			}
		}
		return null;
	}

	private static string GetReplacementMenuId(string menuId)
	{
		if (string.IsNullOrEmpty(menuId))
		{
			return null;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return null;
		}
		if (DiseaseManager.Instance == null)
		{
			return null;
		}
		bool flag = menuId == "castle";
		bool flag2 = menuId == "town" || menuId == "town_outside" || menuId == "town_outside_ended";
		if (!flag && !flag2)
		{
			return null;
		}
		Settlement encounterSettlement = GetEncounterSettlement();
		if (encounterSettlement == null)
		{
			return null;
		}
		if (flag && !encounterSettlement.IsCastle)
		{
			return null;
		}
		if (flag2 && !encounterSettlement.IsTown)
		{
			return null;
		}
		if (!DiseaseManager.Instance.IsSettlementUnderQuarantine(encounterSettlement))
		{
			return null;
		}
		if (encounterSettlement.OwnerClan == Clan.PlayerClan)
		{
			return null;
		}
		if (Hero.MainHero != null && Hero.MainHero.IsKingdomLeader)
		{
			Clan ownerClan = encounterSettlement.OwnerClan;
			if (((ownerClan != null) ? ownerClan.Kingdom : null) != null)
			{
				Kingdom kingdom = encounterSettlement.OwnerClan.Kingdom;
				Clan clan = Hero.MainHero.Clan;
				if (kingdom == ((clan != null) ? clan.Kingdom : null))
				{
					return null;
				}
			}
		}
		return flag ? "quarantine_castle_entry_denied" : "quarantine_blocked_entry";
	}
}
