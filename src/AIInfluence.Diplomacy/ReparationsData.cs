using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

internal class ReparationsData
{
	[JsonProperty("history")]
	public List<ReparationRecord> history { get; set; }

	[JsonProperty("pending_demands")]
	public Dictionary<string, ReparationDemand> pending_demands { get; set; }
}
