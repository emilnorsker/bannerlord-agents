using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class PlotInstance
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("template_id")]
    public string TemplateId { get; set; }

    [JsonProperty("status")]
    public PlotStatus Status { get; set; }

    [JsonProperty("phase")]
    public string Phase { get; set; }

    [JsonProperty("started_campaign_day")]
    public int StartedCampaignDay { get; set; }

    [JsonProperty("deadline_campaign_day", NullValueHandling = NullValueHandling.Ignore)]
    public int? DeadlineCampaignDay { get; set; }

    [JsonProperty("pattern_library_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PatternLibraryId { get; set; }

    [JsonProperty("completed_step_ids")]
    public List<string> CompletedStepIds { get; set; } = new List<string>();

    [JsonProperty("linked_plot_point_ids")]
    public List<string> LinkedPlotPointIds { get; set; } = new List<string>();

    [JsonProperty("linked_secret_ids")]
    public List<string> LinkedSecretIds { get; set; } = new List<string>();

    [JsonProperty("context")]
    public Dictionary<string, string> Context { get; set; } = new Dictionary<string, string>();
}
