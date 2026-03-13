using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.API;

public class DeepSeekChatRequest
{
	[JsonProperty("model")]
	public string Model { get; set; } = string.Empty;

	[JsonProperty("messages")]
	public List<DeepSeekMessage> Messages { get; set; } = new List<DeepSeekMessage>();
}
