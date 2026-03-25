using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence;

/// <summary>Parses the final OpenRouter assistant message for NPC chat into <see cref="AIResponse"/> without relying on <see cref="JsonCleaner"/> unless the model returned malformed JSON.</summary>
public static class NpcOpenRouterAssistantParser
{
	public static AIResponse Parse(string rawAssistantContent, string npcNameForFallback)
	{
		if (string.IsNullOrWhiteSpace(rawAssistantContent))
			return NeutralWithResponse("");

		string trimmed = rawAssistantContent.Trim();
		string jsonForDeserialize = null;

		try
		{
			if (!trimmed.StartsWith("{", StringComparison.Ordinal))
			{
				return new AIResponse
				{
					Response = trimmed,
					SuspectedLie = false,
					Decision = "none",
					Tone = "neutral",
					ThreatLevel = "none",
					EscalationState = "neutral",
					DeescalationAttempt = false
				};
			}

			JObject.Parse(trimmed);
			jsonForDeserialize = trimmed;
		}
		catch (JsonException)
		{
			string cleaned = JsonCleaner.CleanJsonResponse(rawAssistantContent);
			if (!JsonCleaner.IsValidJson(cleaned))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[NpcOpenRouterAssistantParser] Malformed assistant JSON; using text fallback.");
				return new AIResponse
				{
					Response = JsonCleaner.ExtractFallbackResponse(rawAssistantContent, npcNameForFallback),
					SuspectedLie = false,
					Decision = "none",
					Tone = "neutral",
					ThreatLevel = "none",
					EscalationState = "neutral",
					DeescalationAttempt = false
				};
			}

			jsonForDeserialize = cleaned;
		}

		try
		{
			NpcOpenRouterDialogueEnvelope envelope = JsonConvert.DeserializeObject<NpcOpenRouterDialogueEnvelope>(jsonForDeserialize);
			if (envelope == null)
				return NeutralWithResponse("");
			return envelope.ToAIResponse();
		}
		catch (JsonException ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[NpcOpenRouterAssistantParser] Deserialize failed: " + ex.Message);
			return new AIResponse
			{
				Response = JsonCleaner.ExtractFallbackResponse(rawAssistantContent, npcNameForFallback),
				SuspectedLie = false,
				Decision = "none",
				Tone = "neutral",
				ThreatLevel = "none",
				EscalationState = "neutral",
				DeescalationAttempt = false
			};
		}
	}

	private static AIResponse NeutralWithResponse(string response) =>
		new AIResponse
		{
			Response = response,
			SuspectedLie = false,
			Decision = "none",
			Tone = "neutral",
			ThreatLevel = "none",
			EscalationState = "neutral",
			DeescalationAttempt = false
		};
}
