using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class MoneyTransferInfo
{
	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("amount")]
	public int Amount { get; set; }
}
