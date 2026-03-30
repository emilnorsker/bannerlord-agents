using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class PatternLibrary
{
    [JsonProperty("library_id")]
    public string LibraryId { get; set; }

    [JsonProperty("template_id")]
    public string TemplateId { get; set; }

    [JsonProperty("patterns")]
    public List<EventPattern> Patterns { get; set; } = new List<EventPattern>();

    public static PatternLibrary FromJson(string json)
    {
        return JsonConvert.DeserializeObject<PatternLibrary>(json);
    }
}
