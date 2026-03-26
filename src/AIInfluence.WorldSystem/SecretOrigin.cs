using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class SecretOrigin
{
    [JsonProperty("plot_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PlotId { get; set; }

    [JsonProperty("step_id", NullValueHandling = NullValueHandling.Ignore)]
    public string StepId { get; set; }

    [JsonProperty("cause", NullValueHandling = NullValueHandling.Ignore)]
    public string Cause { get; set; }
}
