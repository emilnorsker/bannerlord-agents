using Newtonsoft.Json;

namespace AIInfluence;

public class KingdomCapitalInfo
{
	[JsonProperty("KingdomId")]
	public string KingdomId { get; set; }

	[JsonProperty("KingdomName")]
	public string KingdomName { get; set; }

	[JsonProperty("CapitalSettlementId")]
	public string CapitalSettlementId { get; set; }

	[JsonProperty("CapitalSettlementName")]
	public string CapitalSettlementName { get; set; }

	[JsonProperty("IsCity")]
	public bool IsCity { get; set; }
}
