using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class AIActionIntegration
{
	private static AIActionIntegration _instance;

	private const float WAIT_NEAR_TRAVEL_WAIT_DAYS = 0.05f;

	private readonly Dictionary<string, string> _actionStartOverrides = new Dictionary<string, string>();

	public static AIActionIntegration Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AIActionIntegration();
			}
			return _instance;
		}
	}

	private AIActionIntegration()
	{
	}

	public string ProcessAIResponse(string aiResponse, Hero npc)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		if (string.IsNullOrEmpty(aiResponse) || npc == null)
		{
			return aiResponse;
		}
		try
		{
			string text = JsonCleaner.CleanJsonResponse(aiResponse);
			JObject val = JObject.Parse(text);
			if (val["technical_action"] != null && (int)val["technical_action"].Type != 10)
			{
				string text2 = ((object)val["technical_action"]).ToString();
				if (!string.IsNullOrEmpty(text2))
				{
					string[] array = text2.Split(new char[1] { ':' }, 2);
					string text3 = array[0].Trim().ToLowerInvariant();
					string text4 = ((array.Length > 1) ? array[1].Trim() : string.Empty);
					if (text4.Equals("STOP", StringComparison.OrdinalIgnoreCase))
					{
						AIActionManager.Instance.StopAction(npc, text3, showMessage: true);
						try
						{
							TaskManager instance = TaskManager.Instance;
							if (instance != null)
							{
								instance.CancelTask(npc);
								LogMessage($"Cancelled task for {npc.Name} due to action stop");
							}
						}
						catch (Exception ex)
						{
							LogMessage("ERROR cancelling task: " + ex.Message);
						}
					}
					else
					{
						AIActionManager.Instance.StopAllActions(npc);
						_actionStartOverrides.Remove(((MBObjectBase)npc).StringId);
						LogMessage($"[AIActionIntegration] Processing technical_action '{text3}:{text4}' for {((npc != null) ? npc.Name : null)}");
						bool flag = TryPrepareActionParameter(npc, text3, text4);
						LogMessage($"[AIActionIntegration] TryPrepareActionParameter('{text3}') -> {flag}");
						if (flag)
						{
							string actionToStart = GetActionToStart(npc, text3);
							bool flag2 = AIActionManager.Instance.StartAction(npc, actionToStart, forceRestart: true);
							LogMessage($"[AIActionIntegration] StartAction('{actionToStart}') returned {flag2} for {((npc != null) ? npc.Name : null)}");
						}
					}
				}
			}
			if (val["response"] != null)
			{
				return ((object)val["response"]).ToString();
			}
			return aiResponse;
		}
		catch (Exception ex2)
		{
			LogMessage("ERROR parsing AI response for actions: " + ex2.Message);
			return aiResponse;
		}
	}

	public string GenerateActionsPrompt(Hero hero = null)
	{
		List<string> registeredActions = AIActionManager.Instance.GetRegisteredActions();
		if (registeredActions.Count == 0)
		{
			return "";
		}
		string text = "\n\n# ACTION SYSTEM\n## GENERAL RULES\n\n";
		text += "### Action format\n";
		text += "- `technical_action` is the field where you control your actions.\n";
		text += "- **Start an action**: Set `technical_action: \"action_name\"` or `technical_action: \"action_name:parameters\"`\n";
		text += "- **Stop an action**: Set `technical_action: \"action_name:STOP\"` (e.g., `\"follow_player:STOP\"`)\n";
		text += "- **No change**: Set `technical_action: null` if you're not starting or stopping any action\n\n";
		text += "### Critical requirements\n";
		text += "- **Always verify string_ids.** Actions referencing settlements or parties MUST include their string_id (e.g., `town_V1`, `party_bandits_123`). If you only know the spoken name and have no string_id, do NOT issue the action. Say that you don't know/see it, ask for clarification.\n";
		text += "- **`,then:return` modifier.** Append `,then:return` when you intend to return to the player immediately after completing the task (e.g., they say \"find me once you're done\").\n";
		text += "- **Active actions are marked (CURRENTLY ACTIVE).** If an action is active, you'll see instructions on how to stop it.\n\n";
		text += "## AVAILABLE ACTIONS\n\n";
		bool flag = hero != null && hero.PartyBelongedTo != null && hero.PartyBelongedTo != MobileParty.MainParty;
		bool flag2 = hero != null && hero.Clan != null && hero.Clan == Clan.PlayerClan && (((hero != null) ? hero.PartyBelongedTo : null) == null || hero.PartyBelongedTo == MobileParty.MainParty);
		foreach (string item in registeredActions)
		{
			bool flag3 = hero != null && AIActionManager.Instance.IsActionActive(hero, item);
			switch (item)
			{
			case "follow_player":
				if (flag3)
				{
					text += "### follow_player (CURRENTLY ACTIVE)\n";
					text += "**You are currently following the player.**\n";
					text += "**Stop with** `technical_action: \"follow_player:STOP\"` when:\n";
					text += "- The player dismisses you or says goodbye\n";
					text += "- You part ways or the conversation ends with you leaving\n";
					text += "- The player asks you to do something else independently\n";
					text += "- You need to leave for your own reasons (explain in character)\n\n";
				}
				else
				{
					text += "### follow_player\n";
					text += "**Purpose**: Escort the player and travel with them.\n";
					text += "**Use when** the player asks you to travel with them or you agree to accompany them.\n";
					text += "**Format**: Set `technical_action: \"follow_player\"` to start following.\n\n";
				}
				break;
			case "go_to_settlement":
				if (flag3)
				{
					text += "### go_to_settlement (CURRENTLY ACTIVE)\n";
					text += "**You are currently traveling to a settlement.**\n";
					text += "**Stop with** `technical_action: \"go_to_settlement:STOP\"` if:\n";
					text += "- The player asks you to cancel the journey\n";
					text += "- Plans change and you need to go elsewhere instead\n";
					text += "- You decide to abandon the mission (explain why)\n\n";
				}
				else
				{
					text += "### go_to_settlement:<settlement_id_or_name>[:wait_days]\n";
					text += "**Purpose**: Travel to a settlement for a specified reason.\n";
					text += "**Requirements**: Always include the settlement string_id (e.g., `town_V1`). If the string_id is unknown, role-play your uncertainty and skip the command. Check which settlement you're heading to. If it's hostile to you, refuse the player, but consider your character.\n";
					text += "**Formats**:\n";
					text += "- Single destination: `go_to_settlement:town_V1:5`\n";
					text += "- Route with return: `go_to_settlement:town_V1:3,town_V2:5,then:return`\n\n";
				}
				break;
			case "return_to_player":
				if (flag3)
				{
					text += "### return_to_player (CURRENTLY ACTIVE)\n";
					text += "**You are currently returning to the player.**\n";
					text += "**Stop with** `technical_action: \"return_to_player:STOP\"` if:\n";
					text += "- Plans change and you can't return now\n";
					text += "- Something urgent requires your attention elsewhere\n";
					text += "- The player tells you not to come back (explain in character)\n\n";
				}
				else
				{
					text += "### return_to_player\n";
					text += "**Purpose**: Rejoin the player after completing a task or when they explicitly request your return after completing an assignment.\n";
					text += "**Use when** you're away and need to come back to them.\n\n";
				}
				break;
			case "attack_party":
				if (flag)
				{
					if (flag3)
					{
						text += "### attack_party (CURRENTLY ACTIVE)\n";
						text += "**You are currently attacking a party.**\n";
						text += "**Stop with** `technical_action: \"attack_party:STOP\"` if:\n";
						text += "- The player orders you to retreat or cancel the attack\n";
						text += "- You need to abandon the mission for strategic reasons\n\n";
					}
					else
					{
						text += "### attack_party:<party_string_id>[,then:return]\n";
						text += "**Purpose**: Strike a specific party (bandits, deserters, enemies) on the player's orders or request. Make decisions based on your character's personality. Do not attack allies.\n";
						text += "**Requirements**: Always include the party string_id. No string_id → no action.\n";
						text += "Add `,then:return` if you plan to return immediately afterwards or they ask you to return.\n";
						text += "**Examples**:\n";
						text += "- `attack_party:party_bandits_123`\n";
						text += "- `attack_party:party_bandits_123,then:return`\n\n";
					}
				}
				break;
			case "patrol_settlement":
				if (flag3)
				{
					text += "### patrol_settlement (CURRENTLY ACTIVE)\n";
					text += "**You are currently patrolling a settlement.**\n";
					text += "**Stop with** `technical_action: \"patrol_settlement:STOP\"` if:\n";
					text += "- The player asks you to stop patrolling\n";
					text += "- You need to leave for another task\n";
					text += "- The situation changes and patrol is no longer needed\n\n";
				}
				else
				{
					text += "### patrol_settlement:<settlement_string_id>[:days][,then:return]\n";
					text += "**Purpose**: Patrol a settlement or its surroundings.\n";
					text += "**Requirements**: Provide the settlement string_id. No string_id → skip the action.\n";
					text += "**Examples**:\n";
					text += "- `patrol_settlement:town_V1:5`\n";
					text += "- `patrol_settlement:town_V1:5,then:return`\n";
					text += "- `patrol_settlement:town_V1,then:return`\n\n";
				}
				break;
			case "wait_near_settlement":
				if (flag3)
				{
					text += "### wait_near_settlement (CURRENTLY ACTIVE)\n";
					text += "**You are currently waiting near a settlement.**\n";
					text += "**Stop with** `technical_action: \"wait_near_settlement:STOP\"` if:\n";
					text += "- The player tells you to stop waiting\n";
					text += "- Plans change and you need to move\n";
					text += "- You decide waiting is no longer necessary\n\n";
				}
				else
				{
					text += "### wait_near_settlement:<settlement_string_id>[:days][:distance][,then:return]\n";
					text += "**Purpose**: Hold position outside a settlement without entering it.\n";
					text += "**Parameters**: duration defaults to 2 days, radius between 7 (close) and 18 (far). Missing string_id → skip.\n";
					text += "**Examples**:\n";
					text += "- `wait_near_settlement:town_V1`\n";
					text += "- `wait_near_settlement:town_V1:3:12`\n";
					text += "- `wait_near_settlement:town_V1:3:12,then:return`\n\n";
				}
				break;
			case "siege_settlement":
				if (flag)
				{
					if (flag3)
					{
						text += "### siege_settlement (CURRENTLY ACTIVE)\n";
						text += "**You are currently besieging a settlement.**\n";
						text += "**Stop with** `technical_action: \"siege_settlement:STOP\"` if:\n";
						text += "- The player orders or asks you to lift the siege\n";
						text += "- Strategic situation requires you to withdraw\n";
						text += "- Peace is made or situation changes\n\n";
					}
					else
					{
						text += "### siege_settlement:<settlement_string_id>[,then:return]\n";
						text += "**Purpose**: Lead a siege against the specified town/castle. Agree based on your character! Do not siege allied settlements!\n";
						text += "**Requirements**: Settlement string_id is mandatory. No string_id → skip.\n";
						text += "**Examples**:\n";
						text += "- `siege_settlement:town_V6`\n";
						text += "- `siege_settlement:town_V6,then:return`\n\n";
					}
				}
				break;
			case "raid_village":
				if (flag)
				{
					if (flag3)
					{
						text += "### raid_village (CURRENTLY ACTIVE)\n";
						text += "**You are currently raiding a village.**\n";
						text += "**Stop with** `technical_action: \"raid_village:STOP\"` if:\n";
						text += "- The player tells you to stop the raid\n";
						text += "- You need to abandon the raid for moral or strategic reasons\n\n";
					}
					else
					{
						text += "### raid_village:<village_string_id>[,then:return]\n";
						text += "**Purpose**: Raid (loot) an enemy village.\n";
						text += "**Restrictions**: Use ONLY with villages (not towns or castles). If the target is not a village, skip the action. Consider your character's personality, do not attack allied villages!\n";
						text += "**Behavior**: You will march to the village and raid it.\n";
						text += "**Examples**:\n";
						text += "- `raid_village:village_A1`\n";
						text += "- `raid_village:village_A1,then:return`\n\n";
					}
				}
				break;
			case "create_party":
				if (flag2)
				{
					text += "### create_party\n";
					text += "**Purpose**: Leave the player's party; command an independent party on the campaign map.\n";
					text += "**technical_action**:\n";
					text += "- `create_party` — If the hero's culture matches a bandit-type culture flag set, the mod uses Bannerlord.GameMaster `ClanGenerator.CreateMinorClan`: new minor clan, lord party, `DeclareWar` on the player's map faction and on the map faction of the nearest non-hideout settlement (bandit factions excluded). Otherwise `CreateNewClanMobileParty` in the player's clan.\n";
					text += "- `create_party:outlaw` — Force the minor-clan branch when the hero is in the player's clan and other preconditions pass.\n";
					text += "- `create_party:normal` — Force the player-clan lord party branch.\n\n";
				}
				break;
			case "create_rp_item":
				text += "### create_rp_item\n";
				text += "**Purpose**: Create any roleplay (RP) item for the player: letters, documents, notes, AND physical narrative objects (sacks, packages, sealed containers, trophies, proof or bounty material, quest props).\n";
				text += "**When**: You narrate handing something to the player, they pick it up, say they put it in inventory, or ask you to pass an object that exists in the scene — use this so it exists in inventory (not only for paper). **Only if** the player does not already have this item in the technical inventory list below (never duplicate an item they already hold).\n";
				text += "**Not when**: The player seizes or takes something by force, theft, or intimidation — use `item_transfers` with top-level `item_transfers_opposed_attribute` (skill check), not create_rp_item.\n";
				text += "**Usage**: `technical_action: \"create_rp_item:<name>|<description>\"`\n";
				text += "**Example**: `create_rp_item:Letter|Important message` or `create_rp_item:Sack of heads|Proof for the bounty`\n";
				text += "**Important**: Consensual handoff only — item is given automatically. Do not use `item_transfers` for voluntary RP handoffs; use `item_transfers` + opposed attribute only for contested takes of real inventory items.\n";
				text += "**CRITICAL**: Check \"CRITICAL - Player's Inventory (UNKNOWN TO YOU)\" section BEFORE creating. Do NOT create duplicate items.\n\n";
				break;
			case "transfer_troops_and_prisoners":
				if (flag)
				{
					text += "### transfer_troops_and_prisoners\n";
					text += "**Purpose**: Transfer troops/prisoners between you and the player.\n";
					text += "**Format**: `transfer_troops_and_prisoners:<direction>:troop:<string_id>:<count>,prisoner:<string_id>:<count>`\n";
					text += "**Direction - CRITICAL - Choose correctly based on WHERE the troops are:**\n";
					text += "- `to_player`: You GIVE troops FROM YOUR party TO the player's party. **Use ONLY if you have your own independent party with troops.** The troops must be in YOUR party roster.\n";
					text += "- `from_player`: You RECEIVE troops FROM the player's party TO your party. **Use when the player gives you troops or you take troops from player's party.** The troops must be in the PLAYER's party roster.\n";
					text += "**IMPORTANT**: Check \"Your Forces\" section. If troops are listed there, use `to_player`. If troops are in \"Player's Forces\" section, use `from_player`.\n";
					text += "**Examples**:\n";
					text += "- `transfer_troops_and_prisoners:from_player:troop:imperial_recruit:10` (taking troops from player's party)\n";
					text += "- `transfer_troops_and_prisoners:to_player:troop:imperial_recruit:10` (giving your troops to player - requires independent party)\n";
					text += "- `transfer_troops_and_prisoners:from_player:troop:imperial_recruit:10,prisoner:lord_empire_1:1`\n";
					text += "**Use string_ids from \"Your Forces\" (for to_player) or \"Player's Forces\" (for from_player) sections.**\n\n";
				}
				break;
			default:
				text = text + "- " + item + "\n";
				break;
			}
		}
		text += "### Rules for all actions\n";
		text += "- ALWAYS when performing actions, consider your character's personality, conversation history with the player, enemies/allies. Act realistically. Do not perform actions on your own that the player has not explicitly asked you to do. If you want to perform an action independently, ASK the player about it.\n\n";
		text += "### Rules for multi-step actions\n";
		text += "1. Add `,then:return` only at the end of the entire chain if the player expects you to return.\n";
		text += "2. Every settlement or party in the chain must have a known string_id.\n";
		return text + "3. Always double-check what the player actually requested and construct the actions accordingly.\n\n";
	}

	public string GenerateActiveActionsContext(Hero npc)
	{
		if (npc == null)
		{
			return "";
		}
		List<string> activeActions = AIActionManager.Instance.GetActiveActions(npc);
		if (activeActions.Count == 0)
		{
			return "";
		}
		string text = "\n\n## YOUR CURRENT ACTIONS:\n\n";
		text += "You are currently performing the following actions:\n";
		foreach (string item in activeActions)
		{
			text = item switch
			{
				"follow_player" => text + "- You are following the player\n", 
				"attack_party" => text + "- You are moving to attack your assigned target\n", 
				"siege_settlement" => text + "- You are besieging (or marching to besiege) the assigned settlement\n", 
				"go_to_settlement" => text + "- You are traveling to the assigned settlement\n", 
				"return_to_player" => text + "- You are returning to the player\n", 
				"patrol_settlement" => text + "- You are patrolling around the assigned settlement\n", 
				"wait_near_settlement" => text + "- You are holding position outside the assigned settlement\n", 
				"transfer_troops_and_prisoners" => text + "- You are transferring troops and/or prisoners\n", 
				_ => text + "- " + item + "\n", 
			};
		}
		return text + "\nRemember this when responding to the player.\n";
	}

	public void Update(float deltaTime)
	{
		AIActionManager.Instance.Update(deltaTime);
	}

	public void Clear()
	{
		AIActionManager.Instance.Clear();
	}

	public bool TryPrepareActionParameter(Hero npc, string actionName, string parameter)
	{
		if (npc == null)
		{
			return false;
		}
		if (string.Equals(actionName, "create_party", StringComparison.OrdinalIgnoreCase))
		{
			ApplyCreatePartyParameter(parameter);
			return true;
		}
		if (string.IsNullOrWhiteSpace(parameter))
		{
			return true;
		}
		switch (actionName)
		{
		case "go_to_settlement":
		{
			LogMessage($"Parsing go_to_settlement parameter for {npc.Name}: '{parameter}'");
			string[] array13 = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array13.Length == 0)
			{
				LogMessage($"ERROR: Empty parameter for go_to_settlement (NPC {npc.Name}).");
				return false;
			}
			if (array13.Length == 1)
			{
				string[] array14 = array13[0].Split(new char[1] { ':' }, 2);
				string text17 = array14[0].Trim();
				float num7 = 3f;
				if (array14.Length > 1 && float.TryParse(array14[1].Trim(), out var result5))
				{
					num7 = result5;
				}
				if (GoToSettlementAction.PrepareDestination(npc, text17, out var settlement3))
				{
					try
					{
						TaskManager instance6 = TaskManager.Instance;
						if (instance6 != null)
						{
							HeroTask heroTask6 = TaskBuilder.CreateGoToSettlementAndWait(npc, settlement3, num7, $"Go to {settlement3.Name} and wait {num7} days");
							if (heroTask6 != null)
							{
								LogMessage($"Created task {heroTask6.TaskId} for {npc.Name}: go to {settlement3.Name} and wait {num7} days");
							}
						}
					}
					catch (Exception ex6)
					{
						LogMessage("ERROR creating task for go_to_settlement: " + ex6.Message);
					}
					LogMessage($"Prepared go_to_settlement for {npc.Name} -> {settlement3.Name} (wait {num7} days)");
					return true;
				}
				LogMessage($"ERROR: Failed to find settlement '{text17}' for go_to_settlement (NPC {npc.Name}).");
				return false;
			}
			try
			{
				TaskManager instance7 = TaskManager.Instance;
				if (instance7 == null)
				{
					LogMessage("ERROR: TaskManager not available for multi-step task");
					return false;
				}
				TaskBuilder taskBuilder6 = new TaskBuilder(npc);
				bool flag7 = false;
				string[] array15 = array13;
				foreach (string text18 in array15)
				{
					string text19 = text18.Trim();
					if (text19.Equals("then:return", StringComparison.OrdinalIgnoreCase) || text19.Equals("return", StringComparison.OrdinalIgnoreCase))
					{
						taskBuilder6.ReturnToPlayer();
						flag7 = true;
						continue;
					}
					if (text19.StartsWith("attack", StringComparison.OrdinalIgnoreCase))
					{
						string[] array16 = text19.Split(new char[1] { ':' }, 2);
						if (array16.Length < 2)
						{
							LogMessage("ERROR: Invalid attack directive '" + text19 + "' in multi-step task");
							continue;
						}
						string text20 = array16[1].Trim();
						if (string.IsNullOrEmpty(text20))
						{
							LogMessage("ERROR: Empty attack target in '" + text19 + "'");
							continue;
						}
						taskBuilder6.AttackParty(text20);
						LogMessage($"Added attack step against '{text20}' to multi-step task for {npc.Name}");
						continue;
					}
					string[] array17 = text19.Split(new char[1] { ':' }, 2);
					string text21 = array17[0].Trim();
					float result6 = 3f;
					if (array17.Length > 1 && !float.TryParse(array17[1].Trim(), out result6))
					{
						result6 = 3f;
					}
					if (GoToSettlementAction.PrepareDestination(npc, text21, out var settlement4))
					{
						taskBuilder6.GoToSettlement(settlement4);
						if (result6 > 0f)
						{
							taskBuilder6.WaitInSettlement(settlement4, result6);
						}
					}
					else
					{
						LogMessage("ERROR: Failed to find settlement '" + text21 + "' in multi-step task");
					}
				}
				if (!flag7)
				{
					taskBuilder6.ReturnToPlayer();
				}
				HeroTask heroTask7 = taskBuilder6.Build();
				if (heroTask7 != null)
				{
					LogMessage($"Created multi-step task {heroTask7.TaskId} for {npc.Name} with {heroTask7.Steps.Count} steps");
					LogMessage($"Prepared go_to_settlement multi-step task for {npc.Name}");
					return true;
				}
				LogMessage($"ERROR: Failed to build multi-step task for {npc.Name}");
				return false;
			}
			catch (Exception ex7)
			{
				LogMessage("ERROR creating multi-step task: " + ex7.Message);
				return false;
			}
		}
		case "attack_party":
		{
			LogMessage($"Parsing attack_party parameter for {npc.Name}: '{parameter}'");
			string[] array10 = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array10.Length == 0)
			{
				LogMessage($"ERROR: Empty parameter for attack_party (NPC {npc.Name}).");
				return false;
			}
			string text13 = array10[0].Trim();
			if (text13.StartsWith("attack:", StringComparison.OrdinalIgnoreCase))
			{
				text13 = text13.Substring(text13.IndexOf(':') + 1).Trim();
			}
			if (string.IsNullOrEmpty(text13))
			{
				LogMessage($"ERROR: Missing target party id for attack_party (NPC {npc.Name}).");
				return false;
			}
			if (!AttackPartyAction.PrepareAttackTarget(npc, text13))
			{
				LogMessage($"ERROR: Failed to prepare attack target '{text13}' for {npc.Name}");
				return false;
			}
			bool flag5 = false;
			for (int num4 = 1; num4 < array10.Length; num4++)
			{
				string text14 = array10[num4].Trim();
				if (text14.Equals("then:return", StringComparison.OrdinalIgnoreCase) || text14.Equals("return", StringComparison.OrdinalIgnoreCase))
				{
					flag5 = true;
				}
			}
			try
			{
				TaskManager instance4 = TaskManager.Instance;
				if (instance4 != null)
				{
					TaskBuilder taskBuilder4 = new TaskBuilder(npc).WithDescription("Attack " + text13).AttackParty(text13);
					if (flag5)
					{
						taskBuilder4.ReturnToPlayer();
					}
					HeroTask heroTask4 = taskBuilder4.Build();
					if (heroTask4 != null)
					{
						LogMessage($"Created attack task {heroTask4.TaskId} for {npc.Name} (return after attack: {flag5})");
					}
				}
			}
			catch (Exception ex4)
			{
				LogMessage("ERROR creating attack task: " + ex4.Message);
			}
			LogMessage($"Prepared attack_party for {npc.Name} -> {text13}");
			return true;
		}
		case "raid_village":
		{
			LogMessage($"Parsing raid_village parameter for {npc.Name}: '{parameter}'");
			string[] array9 = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array9.Length == 0)
			{
				LogMessage($"ERROR: Empty parameter for raid_village (NPC {npc.Name}).");
				return false;
			}
			string raidPrimaryToken = array9[0].Trim();
			if (string.IsNullOrEmpty(raidPrimaryToken))
			{
				LogMessage($"ERROR: Missing village id for raid_village (NPC {npc.Name}).");
				return false;
			}
			Settlement val2 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == raidPrimaryToken));
			if (val2 == null || !val2.IsVillage)
			{
				LogMessage($"ERROR: Target '{raidPrimaryToken}' is not a valid village for raid_village (NPC {npc.Name}).");
				return false;
			}
			if (IsVillageOwnedByHero(val2, npc))
			{
				TextObject name = npc.Name;
				TextObject name2 = val2.Name;
				Clan clan = npc.Clan;
				LogMessage(string.Format("ERROR: {0} attempted to raid own village {1} (belongs to {2}). Action blocked.", name, name2, ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "their faction"));
				return false;
			}
			bool flag4 = false;
			for (int num3 = 1; num3 < array9.Length; num3++)
			{
				string text12 = array9[num3].Trim();
				if (text12.Equals("then:return", StringComparison.OrdinalIgnoreCase) || text12.Equals("return", StringComparison.OrdinalIgnoreCase))
				{
					flag4 = true;
				}
			}
			if (!RaidVillageAction.PrepareRaidTarget(npc, raidPrimaryToken))
			{
				LogMessage($"ERROR: Failed to prepare raid target '{raidPrimaryToken}' for {npc.Name}");
				return false;
			}
			try
			{
				TaskManager instance3 = TaskManager.Instance;
				if (instance3 != null)
				{
					TaskBuilder taskBuilder3 = new TaskBuilder(npc).WithDescription($"Raid village {val2.Name}").RaidVillage(val2);
					if (flag4)
					{
						taskBuilder3.ReturnToPlayer();
					}
					HeroTask heroTask3 = taskBuilder3.Build();
					if (heroTask3 != null)
					{
						LogMessage($"Created raid_village task {heroTask3.TaskId} for {npc.Name} (return after raid: {flag4})");
					}
				}
			}
			catch (Exception ex3)
			{
				LogMessage("ERROR creating raid_village task: " + ex3.Message);
			}
			LogMessage($"Prepared raid_village for {npc.Name} -> {val2.Name}");
			return true;
		}
		case "patrol_settlement":
		{
			LogMessage($"Parsing patrol_settlement parameter for {npc.Name}: '{parameter}'");
			string[] array11 = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array11.Length == 0)
			{
				LogMessage($"ERROR: Empty parameter for patrol_settlement (NPC {npc.Name}).");
				return false;
			}
			string patrolSettlementId;
			string text15 = (patrolSettlementId = array11[0].Trim());
			float num5 = 7f;
			if (text15.Contains(":"))
			{
				string[] array12 = text15.Split(new char[1] { ':' }, 2);
				patrolSettlementId = array12[0].Trim();
				if (array12.Length > 1 && float.TryParse(array12[1].Trim(), out var result4))
				{
					num5 = Math.Max(0.25f, result4);
				}
			}
			bool flag6 = false;
			for (int num6 = 1; num6 < array11.Length; num6++)
			{
				string text16 = array11[num6].Trim();
				if (text16.Equals("then:return", StringComparison.OrdinalIgnoreCase) || text16.Equals("return", StringComparison.OrdinalIgnoreCase))
				{
					flag6 = true;
				}
			}
			if (!PatrolSettlementAction.PreparePatrolRequest(npc, patrolSettlementId, num5, flag6))
			{
				LogMessage($"ERROR: Failed to prepare patrol request '{patrolSettlementId}' for {npc.Name}");
				return false;
			}
			try
			{
				TaskManager instance5 = TaskManager.Instance;
				if (instance5 != null)
				{
					Settlement settlement2 = ((List<Settlement>)(object)Settlement.All).Find((Predicate<Settlement>)((Settlement s) => ((MBObjectBase)s).StringId == patrolSettlementId));
					TaskBuilder taskBuilder5 = new TaskBuilder(npc).WithDescription("Patrol around " + patrolSettlementId).PatrolSettlement(settlement2, num5, flag6);
					if (flag6)
					{
						taskBuilder5.ReturnToPlayer();
					}
					HeroTask heroTask5 = taskBuilder5.Build();
					if (heroTask5 != null)
					{
						LogMessage($"Created patrol task {heroTask5.TaskId} for {npc.Name} at {patrolSettlementId} (return after patrol: {flag6})");
					}
				}
			}
			catch (Exception ex5)
			{
				LogMessage("ERROR creating patrol task: " + ex5.Message);
			}
			LogMessage($"Prepared patrol_settlement for {npc.Name} -> {patrolSettlementId} (duration {num5} days, return {flag6})");
			return true;
		}
		case "siege_settlement":
		{
			LogMessage($"Parsing siege_settlement parameter for {npc.Name}: '{parameter}'");
			string[] array6 = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array6.Length == 0)
			{
				LogMessage($"ERROR: Empty parameter for siege_settlement (NPC {npc.Name}).");
				return false;
			}
			string text8 = array6[0].Trim();
			bool flag2 = false;
			for (int j = 1; j < array6.Length; j++)
			{
				string text9 = array6[j].Trim();
				if (text9.Equals("then:return", StringComparison.OrdinalIgnoreCase) || text9.Equals("return", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = true;
				}
			}
			if (!GoToSettlementAction.PrepareDestination(npc, text8, out var settlement))
			{
				LogMessage("ERROR: Failed to find settlement '" + text8 + "' for siege_settlement.");
				return false;
			}
			SiegeSettlementAction.PrepareSiegeTarget(npc, ((MBObjectBase)settlement).StringId, flag2);
			try
			{
				TaskManager instance = TaskManager.Instance;
				if (instance != null)
				{
					TaskBuilder taskBuilder = new TaskBuilder(npc).WithDescription($"Siege {settlement.Name}").SiegeSettlement(settlement);
					if (flag2)
					{
						taskBuilder.ReturnToPlayer();
					}
					HeroTask heroTask = taskBuilder.Build();
					if (heroTask != null)
					{
						LogMessage($"Created siege task {heroTask.TaskId} for {npc.Name} (auto return: {flag2})");
					}
				}
			}
			catch (Exception ex)
			{
				LogMessage("ERROR creating siege task: " + ex.Message);
			}
			LogMessage($"Prepared siege_settlement for {npc.Name} -> {settlement.Name}");
			return true;
		}
		case "wait_near_settlement":
		{
			LogMessage($"Parsing wait_near_settlement parameter for {npc.Name}: '{parameter}'");
			string[] array7 = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array7.Length == 0)
			{
				LogMessage($"ERROR: Empty parameter for wait_near_settlement (NPC {npc.Name}).");
				return false;
			}
			string text10 = array7[0].Trim();
			if (string.IsNullOrWhiteSpace(text10))
			{
				LogMessage($"ERROR: Invalid wait_near_settlement parameter '{parameter}' (NPC {npc.Name}).");
				return false;
			}
			string[] array8 = text10.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			if (array8.Length == 0)
			{
				LogMessage($"ERROR: Invalid wait_near_settlement parameter '{parameter}' (NPC {npc.Name}).");
				return false;
			}
			string waitSettlementToken = array8[0].Trim();
			float num = 2f;
			float num2 = 10f;
			if (array8.Length > 1 && float.TryParse(array8[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
			{
				num = MathF.Max(0.25f, result2);
			}
			if (array8.Length > 2 && float.TryParse(array8[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result3))
			{
				num2 = MathF.Clamp(result3, 7f, 18f);
			}
			bool flag3 = false;
			for (int k = 1; k < array7.Length; k++)
			{
				string text11 = array7[k].Trim();
				if (text11.Equals("then:return", StringComparison.OrdinalIgnoreCase) || text11.Equals("return", StringComparison.OrdinalIgnoreCase))
				{
					flag3 = true;
				}
			}
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId.Equals(waitSettlementToken, StringComparison.OrdinalIgnoreCase) || (((object)s.Name)?.ToString().Equals(waitSettlementToken, StringComparison.OrdinalIgnoreCase) ?? false)));
			if (val == null)
			{
				LogMessage("ERROR: Failed to find settlement '" + waitSettlementToken + "' for wait_near_settlement.");
				return false;
			}
			if (!WaitNearSettlementAction.PrepareWaitRequest(npc, val, num, num2))
			{
				LogMessage($"ERROR: Failed to prepare wait_near_settlement for {npc.Name}.");
				return false;
			}
			try
			{
				TaskManager instance2 = TaskManager.Instance;
				if (instance2 != null)
				{
					TaskBuilder taskBuilder2 = new TaskBuilder(npc).WithDescription($"Wait near {val.Name}").GoToSettlement(val).WaitNearSettlement(val, num, num2);
					if (flag3)
					{
						taskBuilder2.ReturnToPlayer();
					}
					HeroTask heroTask2 = taskBuilder2.Build();
					if (heroTask2 != null)
					{
						LogMessage($"Created wait-near task {heroTask2.TaskId} for {npc.Name} (radius={num2}, return={flag3})");
					}
				}
			}
			catch (Exception ex2)
			{
				LogMessage("ERROR creating wait_near_settlement task: " + ex2.Message);
			}
			GoToSettlementAction.PrepareDestination(npc, val, 0.05f);
			SetActionStartOverride(npc, "go_to_settlement");
			LogMessage($"Prepared wait_near_settlement for {npc.Name} -> {val.Name} (days={num}, radius={num2}, return={flag3})");
			return true;
		}
		case "create_rp_item":
		{
			LogMessage($"Parsing create_rp_item parameter for {npc.Name}: '{parameter}'");
			if (string.IsNullOrWhiteSpace(parameter))
			{
				LogMessage($"ERROR: Empty parameter for create_rp_item (NPC {npc.Name}).");
				return false;
			}
			string[] array5 = parameter.Split(new char[1] { '|' }, 3);
			if (array5.Length < 2)
			{
				LogMessage($"ERROR: Invalid parameter format for create_rp_item. Expected: name|description|type (NPC {npc.Name}).");
				return false;
			}
			string text7 = array5[0].Trim();
			string itemDescription = array5[1].Trim();
			if (string.IsNullOrWhiteSpace(text7))
			{
				LogMessage($"ERROR: Item name is required for create_rp_item (NPC {npc.Name}).");
				return false;
			}
			if (!CreateRPItemAction.PrepareItemCreation(npc, text7, itemDescription))
			{
				LogMessage($"ERROR: Failed to prepare create_rp_item for {npc.Name}");
				return false;
			}
			LogMessage($"Prepared create_rp_item for {npc.Name}: {text7}");
			return true;
		}
		case "transfer_troops_and_prisoners":
		{
			LogMessage($"Parsing transfer_troops_and_prisoners parameter for {npc.Name}: '{parameter}'");
			if (string.IsNullOrWhiteSpace(parameter))
			{
				LogMessage($"ERROR: Empty parameter for transfer_troops_and_prisoners (NPC {npc.Name}).");
				return false;
			}
			string[] array = parameter.Split(new char[1] { ':' }, 2);
			if (array.Length < 2)
			{
				LogMessage($"ERROR: Invalid parameter format for transfer_troops_and_prisoners. Expected: direction:transfers (NPC {npc.Name}).");
				return false;
			}
			string text = array[0].Trim().ToLowerInvariant();
			bool flag = text == "to_player";
			if (!flag && text != "from_player")
			{
				LogMessage($"ERROR: Invalid direction '{text}' for transfer_troops_and_prisoners. Must be 'to_player' or 'from_player' (NPC {npc.Name}).");
				return false;
			}
			string text2 = array[1].Trim();
			string[] array2 = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			List<TransferTroopsAndPrisonersAction.TroopTransfer> list = new List<TransferTroopsAndPrisonersAction.TroopTransfer>();
			List<TransferTroopsAndPrisonersAction.PrisonerTransfer> list2 = new List<TransferTroopsAndPrisonersAction.PrisonerTransfer>();
			string[] array3 = array2;
			foreach (string text3 in array3)
			{
				string text4 = text3.Trim();
				string[] array4 = text4.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
				if (array4.Length < 3)
				{
					LogMessage($"ERROR: Invalid transfer item format '{text4}'. Expected: type:string_id:count (NPC {npc.Name}).");
					continue;
				}
				string text5 = array4[0].Trim().ToLowerInvariant();
				string text6 = array4[1].Trim();
				if (!int.TryParse(array4[2].Trim(), out var result) || result <= 0)
				{
					LogMessage($"ERROR: Invalid count '{array4[2]}' for transfer item '{text4}' (NPC {npc.Name}).");
				}
				else if (text5 == "troop")
				{
					list.Add(new TransferTroopsAndPrisonersAction.TroopTransfer
					{
						TroopStringId = text6,
						Count = result
					});
				}
				else if (text5 == "prisoner")
				{
					list2.Add(new TransferTroopsAndPrisonersAction.PrisonerTransfer
					{
						PrisonerStringId = text6,
						Count = result
					});
				}
				else
				{
					LogMessage($"ERROR: Unknown transfer type '{text5}'. Must be 'troop' or 'prisoner' (NPC {npc.Name}).");
				}
			}
			if (list.Count == 0 && list2.Count == 0)
			{
				LogMessage($"ERROR: No valid transfers specified for transfer_troops_and_prisoners (NPC {npc.Name}).");
				return false;
			}
			if (!TransferTroopsAndPrisonersAction.PrepareTransfer(npc, list, list2, flag))
			{
				LogMessage($"ERROR: Failed to prepare transfer_troops_and_prisoners for {npc.Name}");
				return false;
			}
			LogMessage($"Prepared transfer_troops_and_prisoners for {npc.Name}: {text}, {list.Count} troops, {list2.Count} prisoners");
			return true;
		}
		default:
			return true;
		}
	}

	private static void ApplyCreatePartyParameter(string parameter)
	{
		CreatePartyAction.NextForceOutlawBlgm = false;
		CreatePartyAction.NextSkipOutlawBlgm = false;
		if (string.IsNullOrWhiteSpace(parameter))
			return;
		foreach (string raw in parameter.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
		{
			string t = raw.Trim();
			if (t.Length == 0)
				continue;
			if (t.Equals("outlaw", StringComparison.OrdinalIgnoreCase) || t.Equals("bandit", StringComparison.OrdinalIgnoreCase))
				CreatePartyAction.NextForceOutlawBlgm = true;
			else if (t.StartsWith("outlaw:", StringComparison.OrdinalIgnoreCase) || t.StartsWith("bandit:", StringComparison.OrdinalIgnoreCase))
			{
				string[] kv = t.Split(new[] { ':' }, 2);
				if (kv.Length > 1 && (kv[1].Trim().Equals("true", StringComparison.OrdinalIgnoreCase) || kv[1].Trim() == "1"))
					CreatePartyAction.NextForceOutlawBlgm = true;
			}
			else if (t.Equals("normal", StringComparison.OrdinalIgnoreCase))
				CreatePartyAction.NextSkipOutlawBlgm = true;
			else if (t.StartsWith("normal:", StringComparison.OrdinalIgnoreCase))
			{
				string[] kv2 = t.Split(new[] { ':' }, 2);
				if (kv2.Length > 1 && (kv2[1].Trim().Equals("true", StringComparison.OrdinalIgnoreCase) || kv2[1].Trim() == "1"))
					CreatePartyAction.NextSkipOutlawBlgm = true;
			}
		}
		if (CreatePartyAction.NextSkipOutlawBlgm)
			CreatePartyAction.NextForceOutlawBlgm = false;
	}

	private void LogMessage(string message)
	{
		AIActionsLogger.Instance.Log("[AIActionIntegration] " + message);
	}

	private void SetActionStartOverride(Hero hero, string actionName)
	{
		if (hero != null && !string.IsNullOrEmpty(actionName))
		{
			_actionStartOverrides[((MBObjectBase)hero).StringId] = actionName;
		}
	}

	private string GetActionToStart(Hero hero, string requestedAction)
	{
		if (hero == null)
		{
			return requestedAction;
		}
		if (_actionStartOverrides.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			_actionStartOverrides.Remove(((MBObjectBase)hero).StringId);
			return value;
		}
		return requestedAction;
	}

	public static string EnhancePromptWithActions(string originalPrompt, Hero npc)
	{
		string text = Instance.GenerateActionsPrompt(npc);
		string text2 = Instance.GenerateActiveActionsContext(npc);
		return originalPrompt + text + text2;
	}

	public static string ProcessDialogResponse(string aiResponse, Hero npc)
	{
		return Instance.ProcessAIResponse(aiResponse, npc);
	}

	private bool IsVillageOwnedByHero(Settlement village, Hero hero)
	{
		if (village == null || hero == null || hero.Clan == null)
		{
			return false;
		}
		if (village.OwnerClan == hero.Clan)
		{
			return true;
		}
		if (hero.Clan.Kingdom != null && (object)village.MapFaction == hero.Clan.Kingdom)
		{
			return true;
		}
		if (hero.Clan.Kingdom == null && (object)village.MapFaction == hero.Clan)
		{
			return true;
		}
		Village village2 = village.Village;
		if (((village2 != null) ? village2.Bound : null) != null)
		{
			Settlement bound = village.Village.Bound;
			if (bound.OwnerClan == hero.Clan)
			{
				return true;
			}
			if (hero.Clan.Kingdom != null && (object)bound.MapFaction == hero.Clan.Kingdom)
			{
				return true;
			}
		}
		return false;
	}
}
