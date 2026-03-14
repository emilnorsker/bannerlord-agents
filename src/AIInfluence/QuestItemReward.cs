using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class QuestItemReward
{
	[JsonProperty("item_id")]
	public string ItemId { get; set; }

	[JsonProperty("count")]
	public int Count { get; set; }
}
