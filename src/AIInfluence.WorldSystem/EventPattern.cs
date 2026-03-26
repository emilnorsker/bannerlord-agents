using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class EventPattern
{
    [JsonProperty("pattern_id")]
    public string PatternId { get; set; }

    [JsonProperty("match_type")]
    public PatternMatchType MatchType { get; set; }

    [JsonProperty("events")]
    public List<EventTemplate> Events { get; set; } = new List<EventTemplate>();

    [JsonProperty("negated")]
    public bool Negated { get; set; }
}
