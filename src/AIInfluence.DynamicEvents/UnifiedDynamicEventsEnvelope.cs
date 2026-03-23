using System;
using System.Collections.Generic;
using AIInfluence.Diplomacy;
using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

/// <summary>
/// Single-file save format (v1) for all <see cref="DynamicEvent"/> rows plus diplomacy postscript metadata
/// (previously in <c>diplomatic_events.json</c> alongside <c>dynamic_events.json</c>).
/// </summary>
public class UnifiedDynamicEventsEnvelope
{
	public const int CurrentFormatVersion = 1;

	[JsonProperty("format_version")]
	public int FormatVersion { get; set; } = CurrentFormatVersion;

	[JsonProperty("events")]
	public List<DynamicEvent> Events { get; set; } = new List<DynamicEvent>();

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
