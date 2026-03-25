using Newtonsoft.Json;

namespace AIInfluence;

/// <summary>Subset of fields allowed in the OpenRouter NPC final assistant JSON. Gameplay effects must use tools — extra JSON keys are ignored on deserialize.</summary>
public sealed class NpcOpenRouterDialogueEnvelope
{
	[JsonProperty("internal_thoughts")]
	public string InternalThoughts { get; set; }

	[JsonProperty("response")]
	public string Response { get; set; }

	[JsonProperty("ai_error")]
	public bool? AiError { get; set; }

	[JsonProperty("suspected_lie")]
	public bool SuspectedLie { get; set; }

	[JsonProperty("claimed_name")]
	public string ClaimedName { get; set; }

	[JsonProperty("claimed_clan")]
	public string ClaimedClan { get; set; }

	[JsonProperty("claimed_age")]
	public int? ClaimedAge { get; set; }

	[JsonProperty("tone")]
	public string Tone { get; set; }

	[JsonProperty("threat_level")]
	public string ThreatLevel { get; set; }

	[JsonProperty("escalation_state")]
	public string EscalationState { get; set; }

	[JsonProperty("deescalation_attempt")]
	public bool DeescalationAttempt { get; set; }

	[JsonProperty("decision")]
	public string Decision { get; set; }

	[JsonProperty("romance_intent")]
	public string RomanceIntent { get; set; }

	[JsonProperty("claimed_gold")]
	public int ClaimedGold { get; set; }

	[JsonProperty("character_personality")]
	public string CharacterPersonality { get; set; }

	[JsonProperty("character_backstory")]
	public string CharacterBackstory { get; set; }

	[JsonProperty("character_speech_quirks")]
	public string CharacterSpeechQuirks { get; set; }

	[JsonProperty("allows_letters")]
	public bool? AllowsLettersFromNPC { get; set; }

	public AIResponse ToAIResponse()
	{
		return new AIResponse
		{
			InternalThoughts = InternalThoughts,
			Response = Response,
			AiError = AiError,
			SuspectedLie = SuspectedLie,
			ClaimedName = ClaimedName,
			ClaimedClan = ClaimedClan,
			ClaimedAge = ClaimedAge,
			Tone = Tone,
			ThreatLevel = ThreatLevel,
			EscalationState = EscalationState,
			DeescalationAttempt = DeescalationAttempt,
			Decision = Decision,
			RomanceIntent = RomanceIntent,
			ClaimedGold = ClaimedGold,
			CharacterPersonality = CharacterPersonality,
			CharacterBackstory = CharacterBackstory,
			CharacterSpeechQuirks = CharacterSpeechQuirks,
			AllowsLettersFromNPC = AllowsLettersFromNPC
		};
	}
}
