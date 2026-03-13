using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DiplomaticAnalysisResult
{
	[JsonProperty("should_continue_event")]
	public bool ShouldContinueEvent { get; set; }

	[JsonProperty("should_end_event")]
	public bool ShouldEndEvent { get; set; }

	[JsonProperty("kingdoms_to_add")]
	public List<string> KingdomsToAdd { get; set; } = new List<string>();

	[JsonProperty("kingdoms_to_remove")]
	public List<string> KingdomsToRemove { get; set; } = new List<string>();

	[JsonProperty("event_update")]
	public string EventUpdate { get; set; }

	[JsonProperty("actions_to_execute")]
	public List<DiplomaticActionInfo> ActionsToExecute { get; set; } = new List<DiplomaticActionInfo>();

	[JsonProperty("relation_changes")]
	public List<RelationChangeInfo> RelationChanges { get; set; } = new List<RelationChangeInfo>();

	[JsonProperty("applicable_npcs")]
	public List<string> ApplicableNPCs { get; set; } = new List<string>();

	[JsonProperty("economic_effects")]
	public List<EconomicEffect> EconomicEffects { get; set; } = new List<EconomicEffect>();

	[JsonProperty("disease_data")]
	public object DiseaseData { get; set; }

	[JsonProperty("retry_delay_days")]
	public int RetryDelayDays { get; set; } = 0;
}
