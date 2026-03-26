using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class PlotTemplate
{
    [JsonProperty("template_id")]
    public string TemplateId { get; set; }

    [JsonProperty("steps")]
    public List<PlotStep> Steps { get; set; } = new List<PlotStep>();

    [JsonProperty("episodes")]
    public List<Episode> Episodes { get; set; } = new List<Episode>();

    [JsonProperty("pattern_library_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PatternLibraryId { get; set; }

    [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
    public string Version { get; set; }
}
