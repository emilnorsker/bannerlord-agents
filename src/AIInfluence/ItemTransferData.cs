using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class ItemTransferData
{
	[JsonProperty("item_id")]
	public string ItemId { get; set; }

	[JsonProperty("amount")]
	public int Amount { get; set; }

	[JsonProperty("action")]
	public string Action { get; set; }
}
