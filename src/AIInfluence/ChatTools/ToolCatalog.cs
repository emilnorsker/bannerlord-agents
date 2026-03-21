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
				"{\"items\":{\"type\":\"array\",\"items\":{\"type\":\"object\",\"properties\":{\"item_id\":{\"type\":\"string\"},\"amount\":{\"type\":\"integer\"},\"action\":{\"type\":\"string\"}}},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "items" }),
			Tool("workshop_sell", "Sell workshop to player.",
				"{\"workshop_string_id\":{\"type\":\"string\"},\"price\":{\"type\":\"integer\"}}", new[] { "workshop_string_id", "price" }),
			Tool("kingdom_action", "Diplomatic action. Pass raw action string.", "{\"action\":{\"type\":\"string\"}}", new[] { "action" }),
			Tool("quest_action", "Create/update quest. category: Combat|Negotiation|Intrigue|Escort|Gather|Other. Pass JSON object.", "{\"quest\":{\"type\":\"object\"},\"category\":{\"type\":\"string\",\"enum\":[\"Combat\",\"Negotiation\",\"Intrigue\",\"Escort\",\"Gather\",\"Other\"]}}", new[] { "quest", "category" })
		};
	}

	private static JObject Tool(string name, string desc, string propsJson, string[] required)
	{
		var props = JObject.Parse(propsJson);
		var req = new JArray();
		foreach (var r in required) req.Add(r);
		return new JObject
		{
			["type"] = "function",
			["function"] = new JObject
			{
				["name"] = name,
				["description"] = desc,
				["parameters"] = new JObject { ["type"] = "object", ["properties"] = props, ["required"] = req }
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
		var q = query.Trim().ToLowerInvariant();
		var filtered = filter != null ? store.Where(filter) : store;
		return filtered
			.Where(x => x != null)
			.Where(x =>
			{
				var id = getId(x)?.ToLowerInvariant() ?? "";
				var disp = getDisplayName(x)?.ToLowerInvariant() ?? "";
				return id.Contains(q) || disp.Contains(q);
			})
			.Take(limit)
			.Select(x => (getId(x) ?? "", getDisplayName(x) ?? getId(x) ?? ""))
			.ToList();
	}

	public static List<(string string_id, string name)> FindSettlements(string query, int limit = 8) =>
		FuzzySearch(query, Settlement.All ?? Enumerable.Empty<Settlement>(),
			s => ((MBObjectBase)s).StringId,
			s => s.Name?.ToString(),
			s => s != null,
			limit).Select(t => (t.id, t.name)).ToList();

	public static List<(string string_id, string name)> FindParties(Hero npc, string query, int limit = 8)
	{
		if (npc == null) return new List<(string, string)>();
		Vec2 pos = npc.PartyBelongedTo != null ? npc.PartyBelongedTo.GetPosition2D : (npc.CurrentSettlement != null ? npc.CurrentSettlement.GetPosition2D : default);
		return FuzzySearch(query, MobileParty.All ?? Enumerable.Empty<MobileParty>(),
			p => ((MBObjectBase)p).StringId,
			p => $"{p.Name} ({p.GetPosition2D.Distance(pos):F0})",
			p => p != null && !p.IsDisbanding && !p.IsGarrison && !p.IsMilitia,
			limit).Select(t => (t.id, t.name)).ToList();
	}

	public static List<(string item_id, string name)> FindItems(string query, int limit = 8) =>
		FuzzySearch(query, Items.All as IEnumerable<ItemObject> ?? Enumerable.Empty<ItemObject>(),
			i => i.StringId,
			i => i.Name?.ToString(),
			i => i != null,
			limit).Select(t => (t.id, t.name)).ToList();
}
