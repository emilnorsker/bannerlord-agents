using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence.API;

/// <summary>
/// OpenRouter NPC chat: tools perform game actions; the final assistant message should deserialize to dialogue-only fields.
/// Strip keys here before <see cref="JsonConvert.DeserializeObject{T}"/> so Newtonsoft never binds tool-backed properties from the model JSON.
/// </summary>
public static class OpenRouterDialogueJson
{
	private static readonly string[] GameEffectRootKeys =
	{
		"money_transfer",
		"item_transfers",
		"item_transfers_opposed_attribute",
		"quest_action",
		"kingdom_action",
		"kingdom_action_reason",
		"workshop_action",
		"workshop_string_id",
		"workshop_price",
		"character_death",
		"technical_action",
		"settlement_id"
	};

	/// <summary>Removes tool-backed root keys from assistant JSON before deserializing to <c>AIResponse</c>; pair with <c>ApplyNpcContextToolDeferralsToAiResponse</c>.</summary>
	public static string StripGameEffectKeys(string cleanedJson)
	{
		JObject o = JObject.Parse(cleanedJson);
		foreach (string key in GameEffectRootKeys)
			o.Remove(key);
		return o.ToString(Formatting.None);
	}
}
