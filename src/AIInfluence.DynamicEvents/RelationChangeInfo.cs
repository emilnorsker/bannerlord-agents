using Newtonsoft.Json;

namespace AIInfluence.DynamicEvents;

[JsonSerializable]
public class RelationChangeInfo
{
	[JsonProperty("kingdom1_id")]
	public string Kingdom1Id { get; set; }

	[JsonProperty("kingdom2_id")]
	public string Kingdom2Id { get; set; }

	[JsonProperty("change")]
	public int Change { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }
}
