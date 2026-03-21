using AIInfluence;
using Newtonsoft.Json.Linq;

namespace AIInfluence.API;

/// <summary>OpenRouter <c>response_format</c> for NPC chat: constrains the assistant message to <see cref="AIResponse"/> without duplicating the schema in prompts.</summary>
public static class OpenRouterNpcResponseSchema
{
	/// <summary>Returns <c>response_format</c> object to merge into chat/completions JSON body (<c>type: json_schema</c>).</summary>
	public static JObject GetResponseFormat()
	{
		return new JObject
		{
			["type"] = "json_schema",
			["json_schema"] = new JObject
			{
				["name"] = "npc_chat_response",
				["strict"] = false,
				["schema"] = BuildRootSchema()
			}
		};
	}

	private static JObject BuildRootSchema()
	{
		var props = new JObject
		{
			["internal_thoughts"] = new JObject { ["type"] = new JArray("string", "null") },
			["response"] = new JObject { ["type"] = "string" },
			["suspected_lie"] = new JObject { ["type"] = "boolean" },
			["claimed_name"] = new JObject { ["type"] = new JArray("string", "null") },
			["claimed_clan"] = new JObject { ["type"] = new JArray("string", "null") },
			["claimed_age"] = new JObject { ["type"] = new JArray("integer", "null") },
			["tone"] = new JObject { ["type"] = new JArray("string", "null") },
			["threat_level"] = new JObject { ["type"] = new JArray("string", "null") },
			["escalation_state"] = new JObject { ["type"] = new JArray("string", "null") },
			["deescalation_attempt"] = new JObject { ["type"] = "boolean" },
			["decision"] = new JObject { ["type"] = new JArray("string", "null") },
			["romance_intent"] = new JObject { ["type"] = new JArray("string", "null") },
			["kingdom_action"] = new JObject { ["type"] = new JArray("string", "null") },
			["kingdom_action_reason"] = new JObject { ["type"] = new JArray("string", "null") },
			["technical_action"] = new JObject { ["type"] = new JArray("string", "null") },
			["claimed_gold"] = new JObject { ["type"] = "integer" },
			["workshop_action"] = new JObject { ["type"] = new JArray("string", "null") },
			["workshop_string_id"] = new JObject { ["type"] = new JArray("string", "null") },
			["workshop_price"] = new JObject { ["type"] = "integer" },
			["character_death"] = new JObject { ["type"] = new JArray("object", "null"), ["additionalProperties"] = true },
			["money_transfer"] = new JObject { ["type"] = new JArray("object", "null"), ["additionalProperties"] = true },
			["item_transfers"] = new JObject
			{
				["type"] = new JArray("array", "null"),
				["items"] = new JObject { ["type"] = "object", ["additionalProperties"] = true }
			},
			["item_transfers_opposed_attribute"] = new JObject { ["type"] = new JArray("string", "null") },
			["character_personality"] = new JObject { ["type"] = new JArray("string", "null") },
			["character_backstory"] = new JObject { ["type"] = new JArray("string", "null") },
			["character_speech_quirks"] = new JObject { ["type"] = new JArray("string", "null") },
			["allows_letters"] = new JObject { ["type"] = new JArray("boolean", "null") },
			["tts_instructions"] = new JObject { ["type"] = new JArray("string", "null") },
			["settlement_id"] = new JObject { ["type"] = new JArray("string", "null") },
			["quest_action"] = new JObject { ["type"] = new JArray("object", "null"), ["additionalProperties"] = true }
		};
		return new JObject
		{
			["type"] = "object",
			["properties"] = props,
			["required"] = new JArray("response"),
			["additionalProperties"] = true
		};
	}
}
