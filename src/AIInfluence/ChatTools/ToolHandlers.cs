using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
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
			_ => "unknown"
		};
	}

	private static string RunFindSettlements(string argsJson)
	{
		var a = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindSettlements(a["query"]?.ToString(), a["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(r => new { r.string_id, r.name }));
	}

	private static string RunFindParties(string argsJson, Hero npc)
	{
		var a = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindParties(npc, a["query"]?.ToString(), a["limit"]?.Value<int>() ?? 8);
		return JsonConvert.SerializeObject(results.Select(r => new { r.string_id, r.name }));
	}

	private static string RunFindItems(string argsJson)
	{
		var a = ParseOrEmpty(argsJson);
		var results = ToolCatalog.FindItems(a["query"]?.ToString(), a["limit"]?.Value<int>() ?? 8);
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
		var an = ParseOrEmpty(argsJson)["action_name"]?.ToString();
		if (string.IsNullOrEmpty(an)) return "missing";
		AIActionManager.Instance?.StopAction(npc, an, showMessage: true);
		return "stopped";
	}

	private static string RunGoToSettlement(string argsJson, Hero npc, NPCContext context)
	{
		var a = ParseOrEmpty(argsJson);
		var sid = a["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(sid)) return "use find_settlements first";
		var days = a["wait_days"]?.Value<float>() ?? 3f;
		var param = sid + ":" + days; // legacy API expects this format
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "go_to_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "go_to_settlement");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunAttackParty(string argsJson, Hero npc, NPCContext context)
	{
		var a = ParseOrEmpty(argsJson);
		var pid = a["party_id"]?.ToString();
		if (string.IsNullOrEmpty(pid)) return "use find_parties first";
		var param = a["then_return"]?.Value<bool>() == true ? pid + ",then:return" : pid;
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "attack_party", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "attack_party");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunRaidVillage(string argsJson, Hero npc, NPCContext context)
	{
		var vid = ParseOrEmpty(argsJson)["village_id"]?.ToString();
		if (string.IsNullOrEmpty(vid)) return "use find_settlements first";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "raid_village", vid) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "raid_village");
		context.LastTechnicalActionForDisplay = vid;
		return "ok";
	}

	private static string RunPatrolSettlement(string argsJson, Hero npc, NPCContext context)
	{
		var a = ParseOrEmpty(argsJson);
		var sid = a["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(sid)) return "use find_settlements first";
		var param = sid + ":" + (a["days"]?.Value<float>() ?? 5f);
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "patrol_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "patrol_settlement");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunWaitNearSettlement(string argsJson, Hero npc, NPCContext context)
	{
		var a = ParseOrEmpty(argsJson);
		var sid = a["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(sid)) return "use find_settlements first";
		var param = sid + ":" + (a["days"]?.Value<float>() ?? 2f);
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "wait_near_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "wait_near_settlement");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunSiegeSettlement(string argsJson, Hero npc, NPCContext context)
	{
		var sid = ParseOrEmpty(argsJson)["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(sid)) return "use find_settlements first";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "siege_settlement", sid) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "siege_settlement");
		context.LastTechnicalActionForDisplay = sid;
		return "ok";
	}

	private static string RunCreateParty(Hero npc)
	{
		return AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_party", "") == true
			&& AIActionManager.Instance?.StartAction(npc, "create_party") == true ? "ok" : "failed";
	}

	private static string RunCreateRPItem(string argsJson, Hero npc, NPCContext context)
	{
		var a = ParseOrEmpty(argsJson);
		var name = a["name"]?.ToString();
		if (string.IsNullOrEmpty(name)) return "missing name";
		var param = name + "|" + (a["description"]?.ToString() ?? "");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_rp_item", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "create_rp_item");
		context.LastTechnicalActionForDisplay = name;
		return "ok";
	}

	private static string RunTransferMoney(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		var a = ParseOrEmpty(argsJson);
		var m = new MoneyTransferInfo { Action = a["action"]?.ToString(), Amount = a["amount"]?.Value<int>() ?? 0, OpposedAttribute = a["opposed_attribute"]?.ToString() };
		if (m.Amount > 0) behavior.ProcessMoneyTransfer(npc, context, m);
		return "ok";
	}

	private static string RunTransferItems(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		var a = ParseOrEmpty(argsJson);
		var arr = a["items"] as JArray;
		if (arr == null || arr.Count == 0) return "ok";
		var list = new List<ItemTransferData>();
		foreach (var i in arr)
			list.Add(new ItemTransferData { ItemId = i["item_id"]?.ToString(), Amount = i["amount"]?.Value<int>() ?? 1, Action = i["action"]?.ToString() });
		context.PendingItemTransfersOpposedAttribute = a["opposed_attribute"]?.ToString();
		behavior.ProcessItemTransfers(npc, context, list);
		return "ok";
	}

	private static string RunWorkshopSell(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		var a = ParseOrEmpty(argsJson);
		behavior.ProcessWorkshopSale(npc, context, a["workshop_string_id"]?.ToString(), a["price"]?.Value<int>() ?? 0);
		return "ok";
	}

	private static string RunKingdomAction(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		var action = ParseOrEmpty(argsJson)["action"]?.ToString();
		if (string.IsNullOrEmpty(action)) return "ok";
		behavior.ProcessKingdomAction(npc, new AIResponse { KingdomAction = action, KingdomActionReason = "" }, context);
		return "ok";
	}

	private static string RunQuestAction(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		var a = ParseOrEmpty(argsJson);
		var q = a["quest"];
		if (q == null) return "ok";
		var qa = JsonConvert.DeserializeObject<QuestActionData>(q.ToString());
		if (qa != null)
		{
			qa.Category = a["category"]?.ToString();
			behavior.ProcessQuestAction(npc, context, qa);
		}
		return "ok";
	}

	private static JObject ParseOrEmpty(string argsJson) =>
		string.IsNullOrEmpty(argsJson) ? new JObject() : JObject.Parse(argsJson);
}
