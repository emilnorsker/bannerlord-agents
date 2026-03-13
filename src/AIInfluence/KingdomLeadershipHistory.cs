using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

public class KingdomLeadershipHistory
{
	[JsonProperty("KingdomId")]
	public string KingdomId { get; set; }

	[JsonProperty("KingdomName")]
	public string KingdomName { get; set; }

	[JsonProperty("CurrentLeaderId")]
	public string CurrentLeaderId { get; set; }

	[JsonProperty("CurrentLeaderName")]
	public string CurrentLeaderName { get; set; }

	[JsonProperty("CurrentLeaderClanId")]
	public string CurrentLeaderClanId { get; set; }

	[JsonProperty("CurrentLeaderClanName")]
	public string CurrentLeaderClanName { get; set; }

	[JsonProperty("LeadershipChanges")]
	public List<LeadershipChange> LeadershipChanges { get; set; } = new List<LeadershipChange>();
}
