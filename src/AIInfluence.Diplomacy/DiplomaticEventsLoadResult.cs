using System.Collections.Generic;
using AIInfluence.DynamicEvents;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class DiplomaticEventsLoadResult
{
	public List<DynamicEvent> Events { get; set; }

	public Dictionary<string, CampaignTime> StatementSchedules { get; set; }

	public Dictionary<string, CampaignTime> AnalysisSchedules { get; set; }

	public Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> StatementQueues { get; set; }

	public Dictionary<string, Kingdom> PendingStatements { get; set; }
}
