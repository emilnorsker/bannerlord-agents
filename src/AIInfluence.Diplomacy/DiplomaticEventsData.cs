using System;
using System.Collections.Generic;
using AIInfluence.DynamicEvents;
using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

public class DiplomaticEventsData
{
	[JsonProperty("diplomatic_events")]
	public List<DynamicEvent> DiplomaticEvents { get; set; }

	[JsonProperty("save_time")]
	public DateTime SaveTime { get; set; }

	[JsonProperty("campaign_days")]
	public float CampaignDays { get; set; }

	[JsonProperty("statement_schedules")]
	public Dictionary<string, float> StatementSchedules { get; set; }

	[JsonProperty("analysis_schedules")]
	public Dictionary<string, float> AnalysisSchedules { get; set; }

	[JsonProperty("statement_queues")]
	public Dictionary<string, List<QueuedStatementData>> StatementQueues { get; set; }

	[JsonProperty("pending_statements")]
	public Dictionary<string, string> PendingStatements { get; set; }
}
