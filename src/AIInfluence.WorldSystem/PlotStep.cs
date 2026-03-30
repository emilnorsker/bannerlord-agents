using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class PlotStep
{
    [JsonProperty("step_id")]
    public string StepId { get; set; }

    [JsonProperty("requires")]
    public List<string> Requires { get; set; } = new List<string>();

    [JsonProperty("effects")]
    public List<PlotEffect> Effects { get; set; } = new List<PlotEffect>();

    [JsonProperty("triggers")]
    public List<string> Triggers { get; set; } = new List<string>();
}
