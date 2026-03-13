using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

internal class SettlementOwnershipTrackerData
{
	[JsonProperty("ownershipHistory")]
	public Dictionary<string, SettlementOwnershipHistory> ownershipHistory { get; set; }

	[JsonProperty("isInitialized")]
	public bool isInitialized { get; set; }

	[JsonProperty("kingdomCapitals")]
	public Dictionary<string, KingdomCapitalInfo> kingdomCapitals { get; set; }
}
