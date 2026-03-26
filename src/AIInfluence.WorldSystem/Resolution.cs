using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class Resolution
{
    [JsonProperty("rstate_literals")]
    public List<string> RStateLiterals { get; set; } = new List<string>();

    [JsonProperty("rgoals")]
    public List<ResolutionGoal> RGoals { get; set; } = new List<ResolutionGoal>();
}
