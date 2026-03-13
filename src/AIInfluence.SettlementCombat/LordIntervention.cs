using Newtonsoft.Json;

namespace AIInfluence.SettlementCombat;

[JsonSerializable]
public class LordIntervention
{
	[JsonProperty("string_id")]
	public string StringId { get; set; }

	[JsonProperty("side")]
	public string Side { get; set; }

	[JsonProperty("intervention_reason")]
	public string InterventionReason { get; set; }

	[JsonProperty("arrival_phrase")]
	public string ArrivalPhrase { get; set; }
}
