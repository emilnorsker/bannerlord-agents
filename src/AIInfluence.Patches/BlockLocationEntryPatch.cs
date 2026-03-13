using System;
using System.Collections.Generic;
using AIInfluence.SettlementCombat;
using HarmonyLib;
using SandBox.Objects;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.Patches;

[HarmonyPatch(typeof(PassageUsePoint), "OnUse")]
public static class BlockLocationEntryPatch
{
	private static bool Prefix(PassageUsePoint __instance, Agent userAgent, sbyte agentBoneIndex)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		try
		{
			if (__instance == null || Campaign.Current == null || CampaignMission.Current == null)
			{
				return true;
			}
			if (__instance.IsMissionExit || __instance.ToLocation == null)
			{
				return true;
			}
			if (userAgent == null || !userAgent.IsMainAgent)
			{
				return true;
			}
			Location location = CampaignMission.Current.Location;
			Location toLocation = __instance.ToLocation;
			if (location == null || toLocation == null)
			{
				return true;
			}
			if (location.IsIndoor || !toLocation.IsIndoor)
			{
				return true;
			}
			object obj = Settlement.CurrentSettlement;
			if (obj == null)
			{
				LocationEncounter locationEncounter = PlayerEncounter.LocationEncounter;
				obj = ((locationEncounter != null) ? locationEncounter.Settlement : null);
				if (obj == null)
				{
					MobileParty mainParty = MobileParty.MainParty;
					obj = ((mainParty != null) ? mainParty.CurrentSettlement : null);
					if (obj == null)
					{
						Hero mainHero = Hero.MainHero;
						obj = ((mainHero != null) ? mainHero.CurrentSettlement : null);
						if (obj == null)
						{
							MobileParty mainParty2 = MobileParty.MainParty;
							obj = ((mainParty2 != null) ? mainParty2.LastVisitedSettlement : null);
						}
					}
				}
			}
			Settlement val = (Settlement)obj;
			if (val == null)
			{
				return true;
			}
			AIInfluenceBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<AIInfluenceBehavior>();
			if (campaignBehavior == null)
			{
				return true;
			}
			SettlementCombatManager settlementCombatManager = campaignBehavior.GetSettlementCombatManager();
			if (settlementCombatManager == null || !settlementCombatManager.IsActiveCombat())
			{
				return true;
			}
			Settlement activeCombatSettlement = settlementCombatManager.GetActiveCombatSettlement();
			if (activeCombatSettlement == null || activeCombatSettlement != val)
			{
				return true;
			}
			if (!activeCombatSettlement.IsTown && !activeCombatSettlement.IsCastle)
			{
				return true;
			}
			TextObject val2 = new TextObject("{=AIInfluence_CannotEnterLocationDuringCombat}You cannot enter locations during combat!", (Dictionary<string, object>)null);
			MBInformationManager.AddQuickInformation(val2, 3000, (BasicCharacterObject)null, (Equipment)null, "");
			SettlementCombatLogger.Instance?.Log($"Blocked location entry during combat: '{location.StringId}' -> '{toLocation.StringId}' at '{val.Name}'.");
			return false;
		}
		catch (Exception ex)
		{
			SettlementCombatLogger.Instance?.LogError("BlockLocationEntryPatch.Prefix", ex.Message, ex);
			return true;
		}
	}
}
