using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

public class CampaignSnapshot
{
    [JsonProperty("active_plots")]
    public List<PlotInstance> ActivePlots { get; set; } = new List<PlotInstance>();

    [JsonProperty("recent_diary_events")]
    public List<EventDiaryEntry> RecentDiaryEvents { get; set; } = new List<EventDiaryEntry>();

    [JsonProperty("runtime_secret_count")]
    public int RuntimeSecretCount { get; set; }
}
