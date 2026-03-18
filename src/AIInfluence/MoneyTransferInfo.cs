using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class MoneyTransferInfo
{
	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("amount")]
	public int Amount { get; set; }

	/// <summary>When set, transfer is contested—run opposed check. Omit for agreements (e.g. quest reward).</summary>
	[JsonProperty("opposed_attribute")]
	public string OpposedAttribute { get; set; }
}
