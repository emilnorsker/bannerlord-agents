using System.Collections.Generic;
using AIInfluence;
using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class DynamicEventsResponse
{
	[JsonProperty("events")]
	public List<DynamicEvent> Events { get; set; }

	[JsonProperty("blgm_plan")]
	public BlgmPlanDto BlgmPlan { get; set; }

	public DynamicEventsResponse()
	{
		Events = new List<DynamicEvent>();
	}
}
