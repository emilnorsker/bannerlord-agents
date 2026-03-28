using AIInfluence;
using Newtonsoft.Json.Linq;

namespace AIInfluence.API;

/// <summary>OpenRouter <c>response_format</c>: final assistant JSON is dialogue/narrative fields only. Mechanical effects use tools, not envelope keys.</summary>
public static class OpenRouterNpcResponseSchema
{
	/// <summary>Structured output for every OpenRouter chat completion: dialogue-shaped fields only (tools carry world actions).</summary>
	public static JObject GetResponseFormat()
	{
		return new JObject
		{
			["type"] = "json_schema",
			["json_schema"] = new JObject
			{
				["name"] = "npc_openrouter_dialogue",
				["strict"] = false,
				["schema"] = BuildDialogueRootSchema()
			}
		};
	}

	private static JObject BuildDialogueRootSchema()
	{
		return new JObject
		{
			["type"] = "object",
			["properties"] = BuildDialogueProperties(),
			["required"] = new JArray(),
			["additionalProperties"] = false
		};
	}

	private static JObject BuildDialogueProperties()
	{
		return new JObject
		{
			["internal_thoughts"] = new JObject { ["type"] = new JArray("string", "null") },
			["response"] = new JObject { ["type"] = "string" },
			["suspected_lie"] = new JObject { ["type"] = "boolean" },
			["claimed_name"] = new JObject { ["type"] = new JArray("string", "null") },
			["claimed_clan"] = new JObject { ["type"] = new JArray("string", "null") },
			["claimed_age"] = new JObject { ["type"] = new JArray("integer", "null") },
			["tone"] = new JObject { ["type"] = new JArray("string", "null"), ["enum"] = new JArray("positive", "negative", "neutral", null) },
			["threat_level"] = new JObject { ["type"] = new JArray("string", "null"), ["enum"] = new JArray("none", "low", "medium", "high", null) },
			["escalation_state"] = new JObject { ["type"] = new JArray("string", "null"), ["enum"] = new JArray("neutral", "tense", "critical", null) },
			["deescalation_attempt"] = new JObject { ["type"] = "boolean" },
			["decision"] = new JObject { ["type"] = new JArray("string", "null"), ["enum"] = new JArray("none", "attack", "surrender", "accept_surrender", "release", "propose_marriage", "accept_marriage", "reject_marriage", "intimate", null) },
			["romance_intent"] = new JObject { ["type"] = new JArray("string", "null"), ["enum"] = new JArray("none", "flirt", "romance", "proposal", null) },
			["claimed_gold"] = new JObject { ["type"] = "integer" },
			["character_personality"] = new JObject { ["type"] = new JArray("string", "null") },
			["character_backstory"] = new JObject { ["type"] = new JArray("string", "null") },
			["character_speech_quirks"] = new JObject { ["type"] = new JArray("string", "null") },
			["allows_letters"] = new JObject { ["type"] = new JArray("boolean", "null") }
		};
	}
}

