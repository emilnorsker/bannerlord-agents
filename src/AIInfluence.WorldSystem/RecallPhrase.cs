using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class RecallPhrase
{
    [JsonProperty("phrase_id")]
    public string PhraseId { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("binding")]
    public RecallPhraseBinding Binding { get; set; }
}
