using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class SettlementCombatHandler
{
	public enum SettlementCombatType
	{
		Tavern,
		Village,
		Castle,
		Town,
		Port
	}

	private readonly AIInfluenceBehavior _behavior;

	private readonly Random _random = new Random();

	private bool _combatInitiated = false;

	private Settlement _currentCombatSettlement;

	private SettlementCombatType _currentCombatType;

	public SettlementCombatHandler(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
	}

	public void InitiateSettlementCombat(Hero npc, NPCContext context, string npcResponse)
	{
		if (((npc != null) ? npc.CurrentSettlement : null) == null)
		{
			_behavior.LogMessage("[ERROR] InitiateSettlementCombat called but NPC is not in settlement");
			return;
		}
		Settlement currentSettlement = npc.CurrentSettlement;
		SettlementCombatType settlementCombatType = DetermineSettlementCombatType(currentSettlement);
		_behavior.LogMessage($"[DEBUG] Initiating settlement combat with {npc.Name} in {currentSettlement.Name} (Type: {settlementCombatType})");
		PrepareCombatScenario(npc, context, currentSettlement, settlementCombatType, npcResponse);
		StartSettlementBattle(npc, currentSettlement, settlementCombatType);
	}

	private SettlementCombatType DetermineSettlementCombatType(Settlement settlement)
	{
		if (settlement.IsTown)
		{
			ICampaignMission current = CampaignMission.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				Location location = current.Location;
				obj = ((location != null) ? location.StringId : null);
			}
			string text = (string)obj;
			if (text == "tavern")
			{
				return SettlementCombatType.Tavern;
			}
			if (text == "port")
			{
				return SettlementCombatType.Port;
			}
			return SettlementCombatType.Town;
		}
		if (settlement.IsCastle)
		{
			return SettlementCombatType.Castle;
		}
		if (settlement.IsVillage)
		{
			return SettlementCombatType.Village;
		}
		return SettlementCombatType.Town;
	}

	private void PrepareCombatScenario(Hero npc, NPCContext context, Settlement settlement, SettlementCombatType combatType, string npcResponse)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		string text = ((object)new TextObject("{=AIInfluence_SettlementCombatStart}Conflict in {settlementName}! {npcName} prepares for battle!", new Dictionary<string, object>
		{
			{ "settlementName", settlement.Name },
			{ "npcName", npc.Name }
		})).ToString();
		InformationManager.DisplayMessage(new InformationMessage(text, ExtraColors.RedAIInfluence));
		context.SettlementCombatInfo = new SettlementCombatInfo
		{
			SettlementName = ((object)settlement.Name).ToString(),
			CombatType = combatType,
			StartTime = CampaignTime.Now
		};
		_behavior.LogMessage($"[DEBUG] Combat scenario prepared for {settlement.Name}");
	}

	private void StartSettlementBattle(Hero npc, Settlement settlement, SettlementCombatType combatType)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		try
		{
			if (Mission.Current != null)
			{
				StartInLocationCombat(npc, settlement, combatType);
				return;
			}
			_behavior.LogMessage("[ERROR] No active mission found for settlement combat");
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_SettlementCombatError}Cannot start combat - no active mission!", (Dictionary<string, object>)null)).ToString(), ExtraColors.RedAIInfluence));
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] Failed to start settlement battle: " + ex.Message + "\n" + ex.StackTrace);
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_SettlementCombatGenericError}Something went wrong when starting settlement combat!", (Dictionary<string, object>)null)).ToString(), ExtraColors.RedAIInfluence));
		}
	}

	private void StartInLocationCombat(Hero npc, Settlement settlement, SettlementCombatType combatType)
	{
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Invalid comparison between Unknown and I4
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		Mission current = Mission.Current;
		Agent main = Agent.Main;
		if (main == null)
		{
			_behavior.LogMessage("[ERROR] Player agent not found in mission");
			return;
		}
		IEnumerable<Agent> source = GameVersionCompatibility.EnumerateMissionAgentsSafe(current);
		Agent val = source.FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsHuman && a.Character != null && ((MBObjectBase)a.Character).StringId == ((MBObjectBase)npc).StringId));
		if (val == null)
		{
			_behavior.LogMessage($"[ERROR] NPC agent {npc.Name} not found in current mission");
			return;
		}
		val.SetTeam(Mission.Current.DefenderTeam, false);
		main.SetTeam(Mission.Current.AttackerTeam, false);
		val.SetWatchState((WatchState)2);
		if (val.IsAIControlled)
		{
			val.SetLookAgent(main);
			if ((int)val.GetWieldedItemIndex((HandIndex)0) == -1)
			{
				for (EquipmentIndex val2 = (EquipmentIndex)0; (int)val2 < 5; val2 = (EquipmentIndex)(val2 + 1))
				{
					MissionWeapon val3 = val.Equipment[val2];
					if (!((MissionWeapon)(ref val3)).IsEmpty)
					{
						val.TryToWieldWeaponInSlot(val2, (WeaponWieldActionType)2, false);
						break;
					}
				}
			}
		}
		_behavior.LogMessage($"[DEBUG] Settlement combat initiated - {npc.Name} is now hostile to player in {settlement.Name}");
		InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAttacks}{npcName} attacks you!", new Dictionary<string, object> { { "npcName", npc.Name } })).ToString(), ExtraColors.RedAIInfluence));
	}
}
