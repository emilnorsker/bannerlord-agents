using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class Hook
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("target_hero_string_id")]
    public string TargetHeroStringId { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("basis", NullValueHandling = NullValueHandling.Ignore)]
    public HookBasis Basis { get; set; }

    [JsonProperty("strength")]
    public string Strength { get; set; }

    [JsonProperty("evidence_item", NullValueHandling = NullValueHandling.Ignore)]
    public string EvidenceItem { get; set; }
}
