using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class ResolutionGoal
{
    [JsonProperty("hero_id")]
    public string HeroId { get; set; }

    [JsonProperty("goal_id")]
    public string GoalId { get; set; }
}
