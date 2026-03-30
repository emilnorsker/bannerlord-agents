using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class WorldProposal
{
    [JsonProperty("correlation_id")]
    public string CorrelationId { get; set; }

    [JsonProperty("operations")]
    public List<ProposalOperation> Operations { get; set; } = new List<ProposalOperation>();
}
