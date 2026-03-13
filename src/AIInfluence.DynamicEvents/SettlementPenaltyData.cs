using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class SettlementPenaltyData
{
	[JsonProperty("prosperity_penalty_per_day")]
	public float ProsperityPenaltyPerDay { get; set; }

	[JsonProperty("penalty_duration_days")]
	public int PenaltyDurationDays { get; set; }

	[JsonProperty("penalty_reason")]
	public string PenaltyReason { get; set; }
}
