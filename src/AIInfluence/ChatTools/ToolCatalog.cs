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

public static class ToolCatalog
{
	public static JArray GetToolsForApi()
	{
		return new JArray
		{
			Tool("find_settlements", "Search settlements by name fragment. Returns settlement string_ids.",
				"{\"query\":{\"type\":\"string\"},\"limit\":{\"type\":\"integer\"}}", new[] { "query" }),
			Tool("find_parties", "Search mobile parties by name fragment. Returns party string_ids.",
				"{\"query\":{\"type\":\"string\"},\"limit\":{\"type\":\"integer\"}}", new[] { "query" }),
			Tool("find_items", "Search items by name fragment. Returns item string_ids.",
				"{\"query\":{\"type\":\"string\"},\"limit\":{\"type\":\"integer\"}}", new[] { "query" }),
			Tool("follow_player", "This character's party follows the player.", "{}", System.Array.Empty<string>()),
			Tool("stop_action", "Stops the named active action for this character.", "{\"action_name\":{\"type\":\"string\"}}", new[] { "action_name" }),
			Tool("go_to_settlement", "Travel order to a settlement. settlement_id is the game string_id (from find_settlements). wait_days is stay duration.",
				"{\"settlement_id\":{\"type\":\"string\"},\"wait_days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("attack_party", "Attack order against a party. party_id from find_parties. then_return requests return to the player after the engagement.",
				"{\"party_id\":{\"type\":\"string\"},\"then_return\":{\"type\":\"boolean\"}}", new[] { "party_id" }),
			Tool("raid_village", "Raid order for a village. village_id is a village settlement string_id (from find_settlements).",
				"{\"village_id\":{\"type\":\"string\"}}", new[] { "village_id" }),
			Tool("patrol_settlement", "Patrol order around a settlement for the given days.",
				"{\"settlement_id\":{\"type\":\"string\"},\"days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("wait_near_settlement", "Hold position outside a settlement for the given days.",
				"{\"settlement_id\":{\"type\":\"string\"},\"days\":{\"type\":\"number\"}}", new[] { "settlement_id" }),
			Tool("siege_settlement", "Siege order against a fortification. settlement_id is town or castle string_id.",
				"{\"settlement_id\":{\"type\":\"string\"}}", new[] { "settlement_id" }),
			Tool("return_to_player", "Travel order to rejoin the player.", "{}", System.Array.Empty<string>()),
			Tool("transfer_troops", "Transfers troops or prisoners. direction is to_player or from_player. transfers is a comma-separated list: troop:string_id:count or prisoner:string_id:count.",
				"{\"direction\":{\"type\":\"string\",\"enum\":[\"to_player\",\"from_player\"]},\"transfers\":{\"type\":\"string\"}}", new[] { "direction", "transfers" }),
			Tool("create_party", "Creates a new map party led by this character. Optional mode outlaw selects an alternate creation path for some cultures and clans.",
				"{\"mode\":{\"type\":\"string\",\"enum\":[\"outlaw\"]}}", System.Array.Empty<string>()),
			Tool("create_rp_item", "Creates a narrative inventory item with the given name and description and adds it to the player's inventory.",
				"{\"name\":{\"type\":\"string\"},\"description\":{\"type\":\"string\"}}", new[] { "name", "description" }),
			Tool("create_rp_weapon", "Creates a weapon from text and inventory rules. Adds one copy to this character's party; optionally transfers one copy to the player.",
				"{\"query\":{\"type\":\"string\",\"description\":\"Text used to select which weapon to create.\"},\"display_name\":{\"type\":\"string\",\"description\":\"Name shown for the created weapon.\"},\"description\":{\"type\":\"string\",\"description\":\"Optional stored note text for the item record.\"},\"item_types\":{\"type\":\"string\",\"description\":\"Weapon category filter: Weapon, OneHanded, TwoHanded, Polearm, Ranged, Thrown, Bow, Crossbow, Shield, or None. Default when omitted: Weapon.\"},\"culture\":{\"type\":\"string\",\"description\":\"Plain culture name or phrase for fuzzy matching, or empty for any culture.\"},\"tier\":{\"type\":\"integer\",\"description\":\"Item tier 0–6. 0–2 substandard for military issue; 3–4 standard; 5 exceptional; 6 mythic. Default 3.\"},\"modifier\":{\"type\":\"string\",\"description\":\"Optional quality label, or empty for none.\"},\"give_to_player\":{\"type\":\"boolean\",\"description\":\"If true, one copy is moved to the player's inventory after creation.\"}}",
				new[] { "query", "display_name", "give_to_player" }),
			Tool("transfer_money", "Transfers denars. action is give (NPC to player) or receive (player to NPC). opposed_attribute is optional for a contested transfer.",
				"{\"action\":{\"type\":\"string\",\"enum\":[\"give\",\"receive\"]},\"amount\":{\"type\":\"integer\"},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "action", "amount" }),
			Tool("transfer_items", "Transfers items between this character and the player. Each row: item_id, amount, action give or take. opposed_attribute at top level is optional for a contested transfer.",
				"{\"items\":{\"type\":\"array\",\"items\":{\"type\":\"object\",\"properties\":{\"item_id\":{\"type\":\"string\"},\"amount\":{\"type\":\"integer\"},\"action\":{\"type\":\"string\"}}}},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "items" }),
			Tool("workshop_sell", "Records sale of a workshop to the player at the given price.",
				"{\"workshop_string_id\":{\"type\":\"string\"},\"price\":{\"type\":\"integer\"}}", new[] { "workshop_string_id", "price" }),
			Tool("kingdom_action", "Kingdom-level diplomatic action. Some action values require settlement_id from find_settlements.",
				"{\"action\":{\"type\":\"string\"},\"reason\":{\"type\":\"string\"},\"settlement_id\":{\"type\":\"string\"}}", new[] { "action" }),
			Tool("quest_action", "Creates, updates, completes, or fails a quest. action inside quest selects the operation. category classifies the quest theme.",
				"{\"quest\":{\"type\":\"object\",\"properties\":{\"action\":{\"type\":\"string\",\"enum\":[\"create_quest\",\"update_quest\",\"complete_quest\",\"fail_quest\"]},\"title\":{\"type\":\"string\"},\"description\":{\"type\":\"string\"},\"reward_gold\":{\"type\":\"integer\"},\"duration_days\":{\"type\":\"integer\"},\"quest_id\":{\"type\":\"string\"},\"target_npc_id\":{\"type\":\"string\"},\"target_npc_ids\":{\"type\":\"array\",\"items\":{\"type\":\"string\"}},\"completer_npc_id\":{\"type\":\"string\"},\"ai_verification_notes\":{\"type\":\"string\"},\"progress_target\":{\"type\":\"integer\"},\"progress_label\":{\"type\":\"string\"},\"update_log\":{\"type\":\"string\"},\"set_progress\":{\"type\":\"integer\"},\"completion_reason\":{\"type\":\"string\"},\"reward_items\":{\"type\":\"array\",\"items\":{\"type\":\"object\",\"properties\":{\"item_name\":{\"type\":\"string\"},\"count\":{\"type\":\"integer\"}}}},\"reward_skill\":{\"type\":\"string\"},\"reward_skill_xp\":{\"type\":\"integer\"},\"crime_rating_change\":{\"type\":\"integer\"},\"influence_change\":{\"type\":\"integer\"},\"spawn_party\":{\"type\":\"object\"}},\"required\":[\"action\",\"title\",\"description\"]},\"category\":{\"type\":\"string\",\"enum\":[\"Combat\",\"Negotiation\",\"Intrigue\",\"Escort\",\"Gather\",\"Other\"]}}", new[] { "quest", "category" }),
			Tool("character_death", "Schedules roleplay death handling for this NPC when rules allow. should_die true triggers the flow.",
				"{\"should_die\":{\"type\":\"boolean\"},\"death_reason\":{\"type\":\"string\"},\"killer_string_id\":{\"type\":\"string\"},\"opposed_attribute\":{\"type\":\"string\"}}", new[] { "should_die" }),
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
