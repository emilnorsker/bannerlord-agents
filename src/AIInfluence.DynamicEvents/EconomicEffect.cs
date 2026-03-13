using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class EconomicEffect
{
	[JsonProperty("target_type")]
	public string TargetType { get; set; }

	[JsonProperty("target_id")]
	public string TargetId { get; set; }

	[JsonProperty("target_ids")]
	public List<string> TargetIds { get; set; }

	[JsonProperty("target_scope")]
	public string TargetScope { get; set; }

	[JsonProperty("prosperity_delta")]
	public float ProsperityDelta { get; set; }

	[JsonProperty("prosperity_delta_per_day")]
	public float ProsperityDeltaPerDay { get; set; }

	[JsonProperty("food_delta")]
	public float FoodDelta { get; set; }

	[JsonProperty("food_delta_per_day")]
	public float FoodDeltaPerDay { get; set; }

	[JsonProperty("security_delta")]
	public float SecurityDelta { get; set; }

	[JsonProperty("loyalty_delta")]
	public float LoyaltyDelta { get; set; }

	[JsonProperty("security_delta_per_day")]
	public float SecurityDeltaPerDay { get; set; }

	[JsonProperty("loyalty_delta_per_day")]
	public float LoyaltyDeltaPerDay { get; set; }

	[JsonProperty("income_multiplier")]
	public float IncomeMultiplier { get; set; } = 1f;

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }
}
