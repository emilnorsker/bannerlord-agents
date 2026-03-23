using System;
using Newtonsoft.Json.Linq;

namespace AIInfluence.ChatTools;

/// <summary>Typed tool params - single source of truth for schemas and deserialization.</summary>
public static class ToolParams
{
	public record GoToSettlement(string settlement_id, float wait_days = 3f);
	public record AttackParty(string party_id, bool then_return = false);
	public record StopAction(string action_name);
	public record TransferMoney(string action, int amount, string opposed_attribute = null);
	public record TransferItem(string item_id, int amount, string action);
	public record TransferItems(List<TransferItem> items, string opposed_attribute = null);
	public record WorkshopSell(string workshop_string_id, int price);
}

public static class ToolCatalog
{
	public static JArray GetToolsForApi()
	{
		return new JArray
		{
			Tool("follow_player", "Start following the player.", "{}", System.Array.Empty<string>()),
			Tool("stop_action", "Stop an active action.", "{\"action_name\":{\"type\":\"string\"}}", new[] { "action_name" }),
			Tool("go_to_settlement", "Travel to settlement. settlement_id must be the game's StringId (e.g. town_V1).",
				"{\"settlement_id\":{\"type\":\"string\"},\"wait_days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("attack_party", "Attack a party. party_id must be the mobile party StringId.",
				"{\"party_id\":{\"type\":\"string\"},\"then_return\":{\"type\":\"boolean\"}}", new[] { "party_id" }),
			Tool("raid_village", "Raid a village. village_id must be a village settlement StringId.",
				"{\"village_id\":{\"type\":\"string\"}}", new[] { "village_id" }),
			Tool("patrol_settlement", "Patrol a settlement.",
				"{\"settlement_id\":{\"type\":\"string\"},\"days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("wait_near_settlement", "Wait near a settlement.",
				"{\"settlement_id\":{\"type\":\"string\"},\"days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("siege_settlement", "Siege a town/castle.",
				"{\"settlement_id\":{\"type\":\"string\"}}", new[] { "settlement_id" }),
			Tool("create_party", "Create your own party.", "{}", System.Array.Empty<string>()),
			Tool("create_rp_item", "Create RP item for player.", "{\"name\":{\"type\":\"string\"},\"description\":{\"type\":\"string\"}}", new[] { "name", "description" }),
			Tool("transfer_money", "Give or receive gold.",
				"{\"action\":{\"type\":\"string\",\"enum\":[\"give\",\"receive\"]},\"amount\":{\"type\":\"integer\"},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "action", "amount" }),
			Tool("transfer_items", "Give or take items.",
				"{\"items\":{\"type\":\"array\",\"items\":{\"type\":\"object\",\"properties\":{\"item_id\":{\"type\":\"string\"},\"amount\":{\"type\":\"integer\"},\"action\":{\"type\":\"string\"}}}},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "items" }),
			Tool("workshop_sell", "Sell workshop to player.",
				"{\"workshop_string_id\":{\"type\":\"string\"},\"price\":{\"type\":\"integer\"}}", new[] { "workshop_string_id", "price" }),
			Tool("kingdom_action", "Diplomatic/kingdom action. For grant_fief, receive_fief, demand_territory, transfer_territory include settlement StringId in settlement_id when required.",
				"{\"action\":{\"type\":\"string\"},\"reason\":{\"type\":\"string\"},\"settlement_id\":{\"type\":\"string\"}}", new[] { "action" }),
			Tool("quest_action", "Create/update quest. category: Combat|Negotiation|Intrigue|Escort|Gather|Other. Pass JSON object.", "{\"quest\":{\"type\":\"object\"},\"category\":{\"type\":\"string\",\"enum\":[\"Combat\",\"Negotiation\",\"Intrigue\",\"Escort\",\"Gather\",\"Other\"]}}", new[] { "quest", "category" }),
			Tool("character_death", "Roleplay death for this NPC when game rules allow. Set should_die true to schedule death handling.",
				"{\"should_die\":{\"type\":\"boolean\"},\"death_reason\":{\"type\":\"string\"},\"killer_string_id\":{\"type\":\"string\"},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "should_die" }),
			Tool("technical_action", "Legacy: one string for map AI. Prefer map_command.",
				"{\"value\":{\"type\":\"string\"}}", new[] { "value" }),
			Tool("map_command", "Campaign map behavior: action name plus optional payload (typed; replaces stringly technical_action).",
				"{\"action\":{\"type\":\"string\"},\"payload\":{\"type\":\"string\"}}", new[] { "action" }),
			Tool("suspected_lie", "Set whether you believe the player's last statement is a lie (lie detection).",
				"{\"suspected\":{\"type\":\"boolean\"}}", new[] { "suspected" }),
			Tool("dialogue_decision", "Conversation flow: release, attack, surrender, accept_surrender, propose_marriage, accept_marriage, reject_marriage, intimate, or none.",
				"{\"decision\":{\"type\":\"string\"}}", new[] { "decision" }),
			Tool("romance_intent", "Romance stance: none, flirt, romance, proposal.",
				"{\"intent\":{\"type\":\"string\"}}", new[] { "intent" }),
			Tool("escalation_update", "Conflict/tension: optional threat_level, escalation_state, deescalation_attempt.",
				"{\"threat_level\":{\"type\":\"string\"},\"escalation_state\":{\"type\":\"string\"},\"deescalation_attempt\":{\"type\":\"boolean\"}}", System.Array.Empty<string>()),
			Tool("allows_letters", "Whether this NPC will send messengers/letters to the player.",
				"{\"allows\":{\"type\":\"boolean\"}}", new[] { "allows" })
		};
	}

	private static JObject Tool(string name, string desc, string propsJson, string[] required)
	{
		var props = JObject.Parse(propsJson);
		var requiredArray = new JArray();
		foreach (string requiredPropertyName in required)
			requiredArray.Add(requiredPropertyName);
		return new JObject
		{
			["type"] = "function",
			["function"] = new JObject
			{
				["name"] = name,
				["description"] = desc,
				["parameters"] = new JObject { ["type"] = "object", ["properties"] = props, ["required"] = requiredArray }
			}
		};
	}
}
