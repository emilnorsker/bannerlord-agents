using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class EventTemplate
{
    [JsonProperty("event_code")]
    public string EventCode { get; set; }

    public bool IsWildcard => EventCode == "*";
}
