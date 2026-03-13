using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

public class QueuedStatementData
{
	[JsonProperty("kingdom_id")]
	public string KingdomId { get; set; }

	[JsonProperty("scheduled_time_days")]
	public float ScheduledTimeDays { get; set; }
}
