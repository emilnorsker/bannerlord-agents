using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

internal class PlayerStatementAnalysisResponse
{
	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("target_kingdom_id")]
	public string TargetKingdomId { get; set; }

	[JsonProperty("target_kingdom_ids")]
	public List<string> TargetKingdomIds { get; set; }

	[JsonProperty("tone")]
	public string Tone { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

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
