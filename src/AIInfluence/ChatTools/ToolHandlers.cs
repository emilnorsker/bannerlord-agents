using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
using AIInfluence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace AIInfluence.ChatTools;

/// <summary>Each handler owns its parsing. Dispatched by name from ExecuteChatTool.</summary>
public static class ToolHandlers
{
	public static string Run(string name, string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		return name switch
		{
			"find_settlements" => RunFindSettlements(argsJson),
			"find_parties" => RunFindParties(argsJson, npc),
			"find_items" => RunFindItems(argsJson),
			"follow_player" => RunFollowPlayer(npc, context),
			"stop_action" => RunStopAction(argsJson, npc),
			"go_to_settlement" => RunGoToSettlement(argsJson, npc, context),
			"attack_party" => RunAttackParty(argsJson, npc, context),
			"raid_village" => RunRaidVillage(argsJson, npc, context),
			"patrol_settlement" => RunPatrolSettlement(argsJson, npc, context),
			"wait_near_settlement" => RunWaitNearSettlement(argsJson, npc, context),
			"siege_settlement" => RunSiegeSettlement(argsJson, npc, context),
			"create_party" => RunCreateParty(npc),
			"create_rp_item" => RunCreateRPItem(argsJson, npc, context),
			"transfer_money" => RunTransferMoney(argsJson, npc, context, behavior),
			"transfer_items" => RunTransferItems(argsJson, npc, context, behavior),
			"workshop_sell" => RunWorkshopSell(argsJson, npc, context, behavior),
			"kingdom_action" => RunKingdomAction(argsJson, npc, context, behavior),
			"quest_action" => RunQuestAction(argsJson, npc, context, behavior),
			"character_death" => RunCharacterDeath(argsJson, context),
			"technical_action" => RunTechnicalAction(argsJson, context),
			_ => "unknown"
		};
	}

	private static string RunFindSettlements(string argsJson)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindSettlements(parsedArgs["query"]?.ToString(), parsedArgs["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(r => new { r.string_id, r.name }));
	}

	private static string RunFindParties(string argsJson, Hero npc)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindParties(npc, parsedArgs["query"]?.ToString(), parsedArgs["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(r => new { r.string_id, r.name }));
	}

	private static string RunFindItems(string argsJson)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindItems(parsedArgs["query"]?.ToString(), parsedArgs["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(r => new { r.item_id, r.name }));
	}

	private static string RunFollowPlayer(Hero npc, NPCContext context)
	{
		if (npc.IsPrisoner) return "prisoner";
		AIActionManager.Instance?.StopAction(npc, "follow_player");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "follow_player", "") != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "follow_player");
		context.LastTechnicalActionForDisplay = "follow_player";
		return "ok";
	}

	private static string RunStopAction(string argsJson, Hero npc)
	{
		string actionName = ParseOrEmpty(argsJson)["action_name"]?.ToString();
		if (string.IsNullOrEmpty(actionName)) return "missing";
		AIActionManager.Instance?.StopAction(npc, actionName, showMessage: true);
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
		context.LastTechnicalActionForDisplay = param;
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
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunRaidVillage(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string villageStringId = parsedArgs["village_id"]?.ToString();
		if (string.IsNullOrEmpty(villageStringId)) return "use find_settlements first";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "raid_village", villageStringId) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "raid_village");
		context.LastTechnicalActionForDisplay = villageStringId;
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
		context.LastTechnicalActionForDisplay = param;
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
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunSiegeSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "use find_settlements first";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "siege_settlement", settlementStringId) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "siege_settlement");
		context.LastTechnicalActionForDisplay = settlementStringId;
		return "ok";
	}

	private static string RunCreateParty(Hero npc)
	{
		return AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_party", "") == true
			&& AIActionManager.Instance?.StartAction(npc, "create_party") == true ? "ok" : "failed";
	}

	private static string RunCreateRPItem(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string itemName = parsedArgs["name"]?.ToString();
		if (string.IsNullOrEmpty(itemName)) return "missing name";
		string param = itemName + "|" + (parsedArgs["description"]?.ToString() ?? "");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_rp_item", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "create_rp_item");
		context.LastTechnicalActionForDisplay = itemName;
		return "ok";
	}

	private static string RunTransferMoney(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var moneyTransfer = new MoneyTransferInfo { Action = parsedArgs["action"]?.ToString(), Amount = parsedArgs["amount"]?.Value<int>() ?? 0, OpposedAttribute = parsedArgs["opposed_attribute"]?.ToString() };
		if (moneyTransfer.Amount > 0) behavior.ProcessMoneyTransfer(npc, context, moneyTransfer);
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
		behavior.ProcessItemTransfers(npc, context, list);
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
		if (string.IsNullOrEmpty(kingdomAction)) return "ok";
		behavior.ProcessKingdomAction(npc, new AIResponse
		{
			KingdomAction = kingdomAction,
			KingdomActionReason = parsedArgs["reason"]?.ToString() ?? "",
			SettlementId = parsedArgs["settlement_id"]?.ToString()
		}, context);
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
		return "ok";
	}

	private static string RunTechnicalAction(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string npcMapCommandLine = parsedArgs["value"]?.ToString();
		if (string.IsNullOrEmpty(npcMapCommandLine))
			return "ok";
		context.DeferredTechnicalActionFromTools = npcMapCommandLine;
		return "ok";
	}

	private static string RunQuestAction(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		JToken questToken = parsedArgs["quest"];
		if (questToken == null) return "ok";
		QuestActionData questAction = JsonConvert.DeserializeObject<QuestActionData>(questToken.ToString());
		if (questAction != null)
		{
			questAction.Category = parsedArgs["category"]?.ToString();
			behavior.ProcessQuestAction(npc, context, questAction);
		}
		return "ok";
	}

	private static JObject ParseOrEmpty(string argsJson) =>
		string.IsNullOrEmpty(argsJson) ? new JObject() : JObject.Parse(argsJson);
}
