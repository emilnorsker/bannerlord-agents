using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class RecallPhraseBinding
{
    [JsonProperty("kind")]
    public string Kind { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}
