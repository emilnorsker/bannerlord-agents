using AIInfluence;
using Newtonsoft.Json.Linq;

namespace AIInfluence.API;

/// <summary>OpenRouter <c>response_format</c> for NPC chat: constrains the assistant message to <see cref="AIResponse"/> fields appropriate for each path.</summary>
public static class OpenRouterNpcResponseSchema
{
	private static readonly string[] ToolBackedRootKeys =
	{
		"money_transfer",
		"item_transfers",
		"item_transfers_opposed_attribute",
		"quest_action",
		"kingdom_action",
		"kingdom_action_reason",
		"workshop_action",
		"workshop_string_id",
		"workshop_price"
	};

	/// <summary>Full envelope (non–tool-call OpenRouter completions, legacy analysis paths).</summary>
	public static JObject GetResponseFormat()
	{
		return WrapSchema("npc_chat_response", BuildRootSchema(includeToolBackedFields: true));
	}

	/// <summary>Final assistant JSON when <c>tools</c> are on the request: mechanical effects must use tools per OpenRouter tool-calling flow.</summary>
	public static JObject GetToolsPathResponseFormat()
	{
		return WrapSchema("npc_dialogue_after_tools", BuildRootSchema(includeToolBackedFields: false));
	}

	private static JObject WrapSchema(string name, JObject rootSchema)
	{
		return new JObject
		{
			["type"] = "json_schema",
			["json_schema"] = new JObject
			{
				["name"] = name,
				["strict"] = false,
				["schema"] = rootSchema
			}
		};
	}

	private static JObject BuildRootSchema(bool includeToolBackedFields)
	{
		JObject props = BuildAllProperties();
		if (!includeToolBackedFields)
		{
			foreach (string key in ToolBackedRootKeys)
				props.Remove(key);
		}
		return new JObject
		{
			["type"] = "object",
			["properties"] = props,
			["required"] = new JArray("response"),
			["additionalProperties"] = true
		};
	}

	private static JObject BuildAllProperties()
	{
		return new JObject
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
	}
}
