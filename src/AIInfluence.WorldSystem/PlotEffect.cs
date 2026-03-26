using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class PlotEffect
{
    [JsonProperty("effect_type")]
    public PlotEffectType EffectType { get; set; }

    [JsonProperty("target_id")]
    public string TargetId { get; set; }

    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Parameters { get; set; }
}
