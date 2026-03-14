using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class QuestItemReward
{
	[JsonProperty("item_name")]
	public string ItemName { get; set; }

	[JsonProperty("count")]
	public int Count { get; set; }
}
