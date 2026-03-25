using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

/// <summary>Model reply deserialized from JSON. OpenRouter NPC chat uses <see cref="NpcOpenRouterDialogueEnvelope"/> for the wire shape; <c>tts_instructions</c> is not in that schema and is not a property here (intentionally retired).</summary>
public class AIResponse
{
	[JsonProperty("internal_thoughts")]
	public string InternalThoughts { get; set; }

	[JsonProperty("response")]
	public string Response { get; set; }

	/// <summary>True only for dialogue error envelopes from <c>AIClient.GenerateErrorResponse</c> — not model output.</summary>
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

	[JsonProperty("kingdom_action")]
	public string KingdomAction { get; set; }

	[JsonProperty("kingdom_action_reason")]
	public string KingdomActionReason { get; set; }

	[JsonProperty("claimed_gold")]
	public int ClaimedGold { get; set; }

	[JsonProperty("workshop_action")]
	public string WorkshopAction { get; set; }

	[JsonProperty("workshop_string_id")]
	public string WorkshopStringId { get; set; }

	[JsonProperty("workshop_price")]
	public int WorkshopPrice { get; set; }

	[JsonProperty("character_death")]
	public CharacterDeathInfo CharacterDeath { get; set; }

	[JsonProperty("money_transfer")]
	public MoneyTransferInfo MoneyTransfer { get; set; }

	[JsonProperty("item_transfers")]
	public List<ItemTransferData> ItemTransfers { get; set; }

	/// <summary>When set with item_transfers, transfer is contested—run opposed check. Omit for agreements.</summary>
	[JsonProperty("item_transfers_opposed_attribute")]
	public string ItemTransfersOpposedAttribute { get; set; }

	[JsonProperty("character_personality")]
	public string CharacterPersonality { get; set; }

	[JsonProperty("character_backstory")]
	public string CharacterBackstory { get; set; }

	[JsonProperty("character_speech_quirks")]
	public string CharacterSpeechQuirks { get; set; }

	[JsonProperty("allows_letters")]
	public bool? AllowsLettersFromNPC { get; set; }

	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("quest_action")]
	public QuestActionData QuestAction { get; set; }
}
