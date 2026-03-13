using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.Diplomacy;

public class AllianceData
{
	[JsonProperty("alliances")]
	public Dictionary<string, List<string>> Alliances { get; set; }

	[JsonProperty("alliance_times")]
	public Dictionary<string, CampaignTime> AllianceTimes { get; set; }

	[JsonProperty("save_time")]
	public DateTime SaveTime { get; set; }

	[JsonProperty("campaign_days")]
	public float CampaignDays { get; set; }
}
