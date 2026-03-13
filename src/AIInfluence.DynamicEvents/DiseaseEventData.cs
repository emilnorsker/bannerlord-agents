using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DiseaseEventData
{
	[JsonProperty("disease_id")]
	public string DiseaseId { get; set; }

	[JsonProperty("disease_name")]
	public string DiseaseName { get; set; }

	[JsonProperty("disease_description")]
	public string DiseaseDescription { get; set; }

	[JsonProperty("severity")]
	public int Severity { get; set; }

	[JsonProperty("settlement_id")]
	public string SettlementId { get; set; }

	[JsonProperty("disease_effects")]
	public DiseaseEffectsData DiseaseEffects { get; set; }

	[JsonProperty("spread_rate")]
	public float SpreadRate { get; set; }

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }
}
