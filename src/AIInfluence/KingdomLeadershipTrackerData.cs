using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

internal class KingdomLeadershipTrackerData
{
	[JsonProperty("leadershipHistory")]
	public Dictionary<string, KingdomLeadershipHistory> leadershipHistory { get; set; }

	[JsonProperty("isInitialized")]
	public bool isInitialized { get; set; }
}
