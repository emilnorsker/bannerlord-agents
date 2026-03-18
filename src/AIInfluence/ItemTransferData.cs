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

	/// <summary>Fallback when AI puts opposed_attribute inside item instead of top-level.</summary>
	[JsonProperty("opposed_attribute")]
	public string OpposedAttribute { get; set; }
}
