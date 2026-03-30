using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class EventDiaryEntry
{
    [JsonProperty("event_id")]
    public string EventId { get; set; }

    [JsonProperty("campaign_day")]
    public int CampaignDay { get; set; }

    [JsonProperty("sequence")]
    public long Sequence { get; set; }

    [JsonProperty("event_code")]
    public string EventCode { get; set; }

    [JsonProperty("hero_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> HeroIds { get; set; } = new List<string>();

    [JsonProperty("dynamic_event_id", NullValueHandling = NullValueHandling.Ignore)]
    public string DynamicEventId { get; set; }

    [JsonProperty("plot_point_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PlotPointId { get; set; }

    [JsonProperty("plot_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PlotId { get; set; }

    [JsonProperty("correlation_id", NullValueHandling = NullValueHandling.Ignore)]
    public string CorrelationId { get; set; }
}
