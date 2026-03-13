using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.Diplomacy;

public class WarStatisticsData
{
	[JsonProperty("kingdom_stats")]
	public Dictionary<string, KingdomWarStats> KingdomStats { get; set; }

	[JsonProperty("save_time")]
	public DateTime SaveTime { get; set; }

	[JsonProperty("campaign_days")]
	public float CampaignDays { get; set; }
}
