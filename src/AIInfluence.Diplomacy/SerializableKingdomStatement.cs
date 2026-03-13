using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

internal class SerializableKingdomStatement
{
	[JsonProperty("kingdom_id")]
	public string KingdomId { get; set; }

	[JsonProperty("statement_text")]
	public string StatementText { get; set; }

	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("actions")]
	public List<string> Actions { get; set; }

	[JsonProperty("target_kingdom_id")]
	public string TargetKingdomId { get; set; }

	[JsonProperty("target_kingdom_ids")]
	public List<string> TargetKingdomIds { get; set; }

	[JsonProperty("target_clan_id")]
	public string TargetClanId { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

	[JsonProperty("campaign_days")]
	public float CampaignDays { get; set; }

	[JsonProperty("event_id")]
	public string EventId { get; set; }

	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("daily_tribute_amount")]
	public int DailyTributeAmount { get; set; }

	[JsonProperty("tribute_duration_days")]
	public int TributeDurationDays { get; set; }

	[JsonProperty("reparations_amount")]
	public int ReparationsAmount { get; set; }

	[JsonProperty("trade_agreement_duration_years")]
	public float TradeAgreementDurationYears { get; set; } = 1f;
}
