using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

[JsonSerializable]
internal class DiplomaticStatementResponse
{
	[JsonProperty("statement")]
	public string Statement { get; set; }

	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("target_kingdom_id")]
	public string TargetKingdomId { get; set; }

	[JsonProperty("target_clan_id")]
	public string TargetClanId { get; set; }

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

	[JsonProperty("quarantine_duration_days")]
	public int QuarantineDurationDays { get; set; }
}
