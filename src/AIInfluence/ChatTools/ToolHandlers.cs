using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
using AIInfluence;
using AIInfluence.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace AIInfluence.ChatTools;

/// <summary>Each handler owns its parsing. Dispatched by name from ExecuteChatTool.</summary>
public static class ToolHandlers
{
	public static string Run(string name, string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		string result = name switch
		{
			"find_settlements" => RunFindSettlements(argsJson),
			"find_parties" => RunFindParties(argsJson, npc),
			"find_items" => RunFindItems(argsJson),
			"follow_player" => RunFollowPlayer(npc, context),
			"stop_action" => RunStopAction(argsJson, npc, context),
			"go_to_settlement" => RunGoToSettlement(argsJson, npc, context),
			"attack_party" => RunAttackParty(argsJson, npc, context),
			"raid_village" => RunRaidVillage(argsJson, npc, context),
			"patrol_settlement" => RunPatrolSettlement(argsJson, npc, context),
			"wait_near_settlement" => RunWaitNearSettlement(argsJson, npc, context),
			"siege_settlement" => RunSiegeSettlement(argsJson, npc, context),
			"create_party" => RunCreateParty(argsJson, npc, context),
			"create_rp_item" => RunCreateRPItem(argsJson, npc, context),
			"create_rp_weapon" => RunCreateRPWeapon(argsJson, npc, context),
			"transfer_money" => RunTransferMoney(argsJson, npc, context, behavior),
			"transfer_items" => RunTransferItems(argsJson, npc, context, behavior),
			"workshop_sell" => RunWorkshopSell(argsJson, npc, context, behavior),
			"kingdom_action" => RunKingdomAction(argsJson, npc, context, behavior),
			"create_quest" => RunCreateQuest(argsJson, npc, context, behavior),
			"update_quest" => RunUpdateQuest(argsJson, npc, context, behavior),
			"complete_quest" => RunCompleteOrFailQuest(argsJson, "complete_quest", npc, context, behavior),
			"fail_quest" => RunCompleteOrFailQuest(argsJson, "fail_quest", npc, context, behavior),
			"character_death" => RunCharacterDeath(argsJson, context),
			"return_to_player" => RunReturnToPlayer(npc, context),
			"transfer_troops" => RunTransferTroops(argsJson, npc, context),
			_ => "unknown"
		};
		ToolCallTelemetry.RaiseCompleted("npc_chat", name, argsJson, result, null);
		return result;
	}

	private static string RunFindSettlements(string argsJson)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindSettlements(parsedArgs["query"]?.ToString(), parsedArgs["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(searchResult => new { searchResult.string_id, searchResult.name }));
	}

	private static string RunFindParties(string argsJson, Hero npc)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindParties(npc, parsedArgs["query"]?.ToString(), parsedArgs["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(searchResult => new { searchResult.string_id, searchResult.name }));
	}

	private static string RunFindItems(string argsJson)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindItems(parsedArgs["query"]?.ToString(), parsedArgs["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(searchResult => new { searchResult.item_id, searchResult.name }));
	}

	private static string RunFollowPlayer(Hero npc, NPCContext context)
	{
		if (npc.IsPrisoner) return "prisoner";
		AIActionManager.Instance?.StopAction(npc, "follow_player");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "follow_player", "") != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "follow_player");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "follow_player");
		return "ok";
	}

	private static string RunStopAction(string argsJson, Hero npc, NPCContext context)
	{
		string actionName = ParseOrEmpty(argsJson)["action_name"]?.ToString();
		if (string.IsNullOrEmpty(actionName)) return "missing";
		AIActionManager.Instance?.StopAction(npc, actionName, showMessage: true);
		ChatToolPillBuilder.AppendMapToolPill(context, npc, actionName + ":STOP");
		return "stopped";
	}

	private static string RunGoToSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "use find_settlements first";
		float waitDays = parsedArgs["wait_days"]?.Value<float>() ?? 3f;
		string param = settlementStringId + ":" + waitDays; // legacy API expects this format
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "go_to_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "go_to_settlement");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "go_to_settlement:" + param);
		return "ok";
	}

	private static string RunAttackParty(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string partyStringId = parsedArgs["party_id"]?.ToString();
		if (string.IsNullOrEmpty(partyStringId)) return "use find_parties first";
		string param = parsedArgs["then_return"]?.Value<bool>() == true ? partyStringId + ",then:return" : partyStringId;
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "attack_party", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "attack_party");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "attack_party:" + param);
		return "ok";
	}

	private static string RunRaidVillage(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string villageStringId = parsedArgs["village_id"]?.ToString();
		if (string.IsNullOrEmpty(villageStringId)) return "use find_settlements first";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "raid_village", villageStringId) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "raid_village");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "raid_village:" + villageStringId);
		return "ok";
	}

	private static string RunPatrolSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "use find_settlements first";
		string param = settlementStringId + ":" + (parsedArgs["days"]?.Value<float>() ?? 5f);
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "patrol_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "patrol_settlement");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "patrol_settlement:" + param);
		return "ok";
	}

	private static string RunWaitNearSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "use find_settlements first";
		string param = settlementStringId + ":" + (parsedArgs["days"]?.Value<float>() ?? 2f);
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "wait_near_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "wait_near_settlement");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "wait_near_settlement:" + param);
		return "ok";
	}

	private static string RunSiegeSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "use find_settlements first";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "siege_settlement", settlementStringId) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "siege_settlement");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "siege_settlement:" + settlementStringId);
		return "ok";
	}

	private static string RunReturnToPlayer(Hero npc, NPCContext context)
	{
		if (npc.IsPrisoner) return "prisoner";
		AIActionManager.Instance?.StopAction(npc, "return_to_player");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "return_to_player", "") != true) return "failed";
		if (AIActionManager.Instance?.StartAction(npc, "return_to_player") != true) return "failed";
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "return_to_player");
		return "ok";
	}

	private static string RunCreateParty(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsed = ParseOrEmpty(argsJson);
		string mode = parsed["mode"]?.ToString();
		string param = mode != null && mode.Equals("outlaw", StringComparison.OrdinalIgnoreCase) ? "outlaw:true" : "";
		bool prepared = AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_party", param) == true;
		bool started = AIActionManager.Instance?.StartAction(npc, "create_party") == true;
		if (prepared && started)
		{
			ChatToolPillBuilder.AppendMapToolPill(context, npc, "create_party");
			return JsonConvert.SerializeObject(new { status = "ok" });
		}
		string err = "create_party failed (prepare or start returned false).";
		InformationManager.DisplayMessage(new InformationMessage("[AI Influence] " + err, ExtraColors.RedAIInfluence));
		return JsonConvert.SerializeObject(new { status = "failed", error = err });
	}

	private static string RunCreateRPItem(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string itemName = parsedArgs["name"]?.ToString();
		if (string.IsNullOrEmpty(itemName)) return "missing name";
		string param = itemName + "|" + (parsedArgs["description"]?.ToString() ?? "");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_rp_item", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "create_rp_item");
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "create_rp_item:" + param);
		return "ok";
	}

	private static string RunCreateRPWeapon(string argsJson, Hero npc, NPCContext context)
	{
		JObject p = ParseOrEmpty(argsJson);
		string query = p["query"]?.ToString()?.Trim();
		string displayName = p["display_name"]?.ToString()?.Trim();
		if (string.IsNullOrEmpty(query) || string.IsNullOrEmpty(displayName))
			return "missing query or display_name";
		string description = p["description"]?.ToString() ?? "";
		string itemTypes = p["item_types"]?.ToString() ?? "";
		string culture = p["culture"]?.ToString() ?? "";
		int tier = p["tier"]?.Value<int?>() ?? 3;
		string modifier = p["modifier"]?.ToString() ?? "";
		if (!p.TryGetValue("give_to_player", out JToken gt))
			return "missing give_to_player";
		bool giveToPlayer = gt.Type == JTokenType.Boolean ? gt.Value<bool>() : string.Equals(gt.ToString(), "true", StringComparison.OrdinalIgnoreCase);
		string param = query + "|" + displayName + "|" + description + "|" + itemTypes + "|" + culture + "|" + tier + "|" + modifier + "|" + (giveToPlayer ? "true" : "false");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_rp_weapon", param) != true)
			return "failed";
		if (AIActionManager.Instance?.StartAction(npc, "create_rp_weapon") != true)
			return "failed";
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "create_rp_weapon:" + displayName);
		return JsonConvert.SerializeObject(new { status = "ok", item_display_name = displayName });
	}

	private static string RunTransferTroops(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string direction = parsedArgs["direction"]?.ToString();
		string transfers = parsedArgs["transfers"]?.ToString();
		if (string.IsNullOrEmpty(direction) || string.IsNullOrEmpty(transfers)) return "missing";
		string malformed = ValidateTransferTroopsSegments(transfers);
		if (malformed != null) return malformed;
		string param = direction + ":" + transfers;
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "transfer_troops_and_prisoners", param) != true) return "failed";
		if (AIActionManager.Instance?.StartAction(npc, "transfer_troops_and_prisoners") != true) return "failed";
		ChatToolPillBuilder.AppendMapToolPill(context, npc, "transfer_troops_and_prisoners:" + param);
		return "ok";
	}

	private static string RunTransferMoney(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var moneyTransfer = new MoneyTransferInfo { Action = parsedArgs["action"]?.ToString(), Amount = parsedArgs["amount"]?.Value<int>() ?? 0, OpposedAttribute = parsedArgs["opposed_attribute"]?.ToString() };
		if (moneyTransfer.Amount > 0) behavior.ProcessMoneyTransfer(npc, context, moneyTransfer, context);
		return "ok";
	}

	private static string RunTransferItems(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var arr = parsedArgs["items"] as JArray;
		if (arr == null || arr.Count == 0) return "ok";
		var list = new List<ItemTransferData>();
		foreach (JToken itemRow in arr)
			list.Add(new ItemTransferData { ItemId = itemRow["item_id"]?.ToString(), Amount = itemRow["amount"]?.Value<int>() ?? 1, Action = itemRow["action"]?.ToString() });
		context.PendingItemTransfersOpposedAttribute = parsedArgs["opposed_attribute"]?.ToString();
		behavior.ProcessItemTransfers(npc, context, list, context);
		return "ok";
	}

	private static string RunWorkshopSell(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		behavior.ProcessWorkshopSale(npc, context, parsedArgs["workshop_string_id"]?.ToString(), parsedArgs["price"]?.Value<int>() ?? 0);
		return "ok";
	}

	private static string RunKingdomAction(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string kingdomAction = parsedArgs["action"]?.ToString();
		if (string.IsNullOrEmpty(kingdomAction) || kingdomAction.Equals("none", StringComparison.OrdinalIgnoreCase)) return "ok";
		string reason = parsedArgs["reason"]?.ToString() ?? "";
		context.PendingKingdomActionFromTools = new AIResponse
		{
			KingdomAction = kingdomAction,
			KingdomActionReason = reason,
			SettlementId = parsedArgs["settlement_id"]?.ToString()
		};
		return "ok";
	}

	private static string RunCharacterDeath(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		bool shouldDie = parsedArgs["should_die"]?.Value<bool>() ?? false;
		if (!shouldDie)
		{
			context.DeferredCharacterDeathFromTools = null;
			return "ok";
		}
		context.DeferredCharacterDeathFromTools = new CharacterDeathInfo
		{
			ShouldDie = true,
			DeathReason = parsedArgs["death_reason"]?.ToString(),
			KillerStringId = parsedArgs["killer_string_id"]?.ToString(),
			OpposedAttribute = parsedArgs["opposed_attribute"]?.ToString()
		};
		context.AppendToolPill("Roleplay death", ChatToolPillBuilder.ActionColor);
		return "ok";
	}

	private static string RunCreateQuest(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string title = parsedArgs["title"]?.ToString();
		string description = parsedArgs["description"]?.ToString();
		if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
		{
			behavior?.LogMessage("[QUEST_TOOL] create_quest missing title or description");
			return "error: create_quest requires non-empty title and description";
		}
		if (context.ActiveAIQuests != null && context.ActiveAIQuests.Count > 0)
		{
			string existingTitle = context.ActiveAIQuests[context.ActiveAIQuests.Count - 1].Title;
			behavior?.LogMessage("[QUEST_TOOL] create_quest rejected: NPC already has active quest '" + existingTitle + "'");
			return "error: this NPC already has an active quest ('" + existingTitle + "'). Use update_quest to modify it, or complete_quest/fail_quest first.";
		}
		QuestActionData questAction = JsonConvert.DeserializeObject<QuestActionData>(parsedArgs.ToString());
		if (questAction == null)
		{
			behavior?.LogMessage("[QUEST_TOOL] create_quest failed to deserialize QuestActionData from args");
			return "error: create_quest failed to parse quest data";
		}
		questAction.Action = "create_quest";
		context.PendingQuestActionFromTools = questAction;
		context.AppendToolPill("Quest: create_quest", ChatToolPillBuilder.QuestActionColor);
		behavior?.LogMessage("[QUEST_TOOL] Staged create_quest (title: " + title + ")");
		return "ok";
	}

	private static string RunUpdateQuest(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string questId = parsedArgs["quest_id"]?.ToString();
		if (string.IsNullOrEmpty(questId))
		{
			behavior?.LogMessage("[QUEST_TOOL] update_quest missing quest_id");
			return "error: update_quest requires quest_id";
		}
		QuestActionData questAction = JsonConvert.DeserializeObject<QuestActionData>(parsedArgs.ToString());
		if (questAction == null)
		{
			behavior?.LogMessage("[QUEST_TOOL] update_quest failed to deserialize QuestActionData from args");
			return "error: update_quest failed to parse quest data";
		}
		questAction.Action = "update_quest";
		questAction.QuestId = questId;
		context.PendingQuestActionFromTools = questAction;
		context.AppendToolPill("Quest: update_quest", ChatToolPillBuilder.QuestActionColor);
		behavior?.LogMessage("[QUEST_TOOL] Staged update_quest (quest_id: " + questId + ")");
		return "ok";
	}

	private static string RunCompleteOrFailQuest(string argsJson, string action, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string questId = parsedArgs["quest_id"]?.ToString();
		if (string.IsNullOrEmpty(questId))
		{
			behavior?.LogMessage("[QUEST_TOOL] " + action + " missing quest_id");
			return "error: " + action + " requires quest_id";
		}
		QuestActionData questAction = new QuestActionData
		{
			Action = action,
			QuestId = questId,
			CompletionReason = parsedArgs["completion_reason"]?.ToString() ?? ""
		};
		context.PendingQuestActionFromTools = questAction;
		context.AppendToolPill("Quest: " + action, ChatToolPillBuilder.QuestActionColor);
		behavior?.LogMessage("[QUEST_TOOL] Staged " + action + " (quest_id: " + questId + ")");
		return "ok";
	}

	private static string ValidateTransferTroopsSegments(string transfersBody)
	{
		if (string.IsNullOrWhiteSpace(transfersBody))
			return "malformed_transfers_empty";
		foreach (string seg in transfersBody.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
		{
			string s = seg.Trim();
			if (s.Length == 0)
				continue;
			string[] p = s.Split(new[] { ':' }, StringSplitOptions.None);
			if (p.Length != 3)
				return "malformed_transfer_segment:" + s;
			string kind = p[0].Trim().ToLowerInvariant();
			if (kind != "troop" && kind != "prisoner")
				return "malformed_transfer_type:" + s;
			if (p[1].Trim().Length == 0)
				return "malformed_transfer_segment:" + s;
			if (!int.TryParse(p[2].Trim(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int n) || n <= 0)
				return "malformed_transfer_count:" + s;
		}
		return null;
	}

	private static JObject ParseOrEmpty(string argsJson) =>
		string.IsNullOrEmpty(argsJson) ? new JObject() : JObject.Parse(argsJson);
}
