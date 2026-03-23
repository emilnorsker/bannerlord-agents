using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

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
	public record FindQuery(string query, int limit = 8);
}

public static class ToolCatalog
{
	public static JArray GetToolsForApi()
	{
		return new JArray
		{
			Tool("find_settlements", "Fuzzy search settlements by name. Use before go_to_settlement, patrol, siege, raid. Returns string_ids.",
				"{\"query\":{\"type\":\"string\"},\"limit\":{\"type\":\"integer\"}}", new[] { "query" }),
			Tool("find_parties", "Fuzzy search parties by name. Use before attack_party. Returns string_ids.",
				"{\"query\":{\"type\":\"string\"},\"limit\":{\"type\":\"integer\"}}", new[] { "query" }),
			Tool("find_items", "Fuzzy search items by name for transfers.",
				"{\"query\":{\"type\":\"string\"},\"limit\":{\"type\":\"integer\"}}", new[] { "query" }),
			Tool("follow_player", "Start following the player.", "{}", System.Array.Empty<string>()),
			Tool("stop_action", "Stop an active action.", "{\"action_name\":{\"type\":\"string\"}}", new[] { "action_name" }),
			Tool("go_to_settlement", "Travel to settlement. Use settlement_id from find_settlements.",
				"{\"settlement_id\":{\"type\":\"string\"},\"wait_days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("attack_party", "Attack a party. Use party_id from find_parties.",
				"{\"party_id\":{\"type\":\"string\"},\"then_return\":{\"type\":\"boolean\"}}", new[] { "party_id" }),
			Tool("raid_village", "Raid a village. Use village_id from find_settlements (village only).",
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
			Tool("kingdom_action", "Diplomatic/kingdom action. For grant_fief, receive_fief, demand_territory, transfer_territory include settlement_id from find_settlements.",
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

	/// <summary>One fuzzy searcher: query + store + selectors. Returns [(id, displayName)].</summary>
	public static List<(string id, string name)> FuzzySearch<T>(
		string query,
		IEnumerable<T> store,
		Func<T, string> getId,
		Func<T, string> getDisplayName,
		Func<T, bool> filter = null,
		int limit = 8)
	{
		if (string.IsNullOrWhiteSpace(query) || store == null) return new List<(string, string)>();
		var queryNormalized = query.Trim().ToLowerInvariant();
		var filtered = filter != null ? store.Where(filter) : store;
		return filtered
			.Where(candidate => candidate != null)
			.Where(candidate =>
			{
				var candidateId = getId(candidate)?.ToLowerInvariant() ?? "";
				var displayText = getDisplayName(candidate)?.ToLowerInvariant() ?? "";
				return candidateId.Contains(queryNormalized) || displayText.Contains(queryNormalized);
			})
			.Take(limit)
			.Select(candidate => (getId(candidate) ?? "", getDisplayName(candidate) ?? getId(candidate) ?? ""))
			.ToList();
	}

	public static List<(string string_id, string name)> FindSettlements(string query, int limit = 8) =>
		FuzzySearch(query, Settlement.All ?? Enumerable.Empty<Settlement>(),
			settlement => ((MBObjectBase)settlement).StringId,
			settlement => settlement.Name?.ToString(),
			settlement => settlement != null,
			limit).Select(result => (result.id, result.name)).ToList();

	public static List<(string string_id, string name)> FindParties(Hero npc, string query, int limit = 8)
	{
		if (npc == null) return new List<(string, string)>();
		Vec2 referencePosition = npc.PartyBelongedTo != null ? npc.PartyBelongedTo.GetPosition2D : (npc.CurrentSettlement != null ? npc.CurrentSettlement.GetPosition2D : default);
		return FuzzySearch(query, MobileParty.All ?? Enumerable.Empty<MobileParty>(),
			party => ((MBObjectBase)party).StringId,
			party => $"{party.Name} ({party.GetPosition2D.Distance(referencePosition):F0})",
			party => party != null && !party.IsDisbanding && !party.IsGarrison && !party.IsMilitia,
			limit).Select(result => (result.id, result.name)).ToList();
	}

	public static List<(string item_id, string name)> FindItems(string query, int limit = 8) =>
		FuzzySearch(query, Items.All as IEnumerable<ItemObject> ?? Enumerable.Empty<ItemObject>(),
			item => item.StringId,
			item => item.Name?.ToString(),
			item => item != null,
			limit).Select(result => (result.id, result.name)).ToList();
}
