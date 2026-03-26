using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class RuntimeSecretRecord
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("access_level")]
    public string AccessLevel { get; set; }

    [JsonProperty("subjects")]
    public List<string> Subjects { get; set; } = new List<string>();

    [JsonProperty("origin", NullValueHandling = NullValueHandling.Ignore)]
    public SecretOrigin Origin { get; set; }

    [JsonProperty("created_campaign_day")]
    public int CreatedCampaignDay { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}
