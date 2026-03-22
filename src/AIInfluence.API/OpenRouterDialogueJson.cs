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

	/// <summary>When AI backend is OpenRouter, remove tool-backed root keys from cleaned assistant JSON before deserializing to <c>AIResponse</c>.</summary>
	public static string PrepareForAiResponseDeserialize(string cleanedJson)
	{
		if (string.IsNullOrWhiteSpace(cleanedJson))
			return cleanedJson;
		return StripGameEffectKeys(cleanedJson);
	}

	/// <summary>Removes tool-backed root keys; pair with <c>ApplyNpcContextToolDeferralsToAiResponse</c> after deserialize when deferrals exist on <c>NPCContext</c>.</summary>
	public static string StripGameEffectKeys(string cleanedJson)
	{
		JObject o = JObject.Parse(cleanedJson);
		foreach (string key in GameEffectRootKeys)
			o.Remove(key);
		return o.ToString(Formatting.None);
	}
}
