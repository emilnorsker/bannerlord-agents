using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class ProposalOperation
{
    [JsonProperty("operation_type")]
    public string OperationType { get; set; }

    [JsonProperty("target_id")]
    public string TargetId { get; set; }

    [JsonProperty("plot_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PlotId { get; set; }

    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Parameters { get; set; }
}
