using Newtonsoft.Json;

namespace AIInfluence.API;

public class OllamaMessage
{
	[JsonProperty("role")]
	public string Role { get; set; }

	[JsonProperty("content")]
	public string Content { get; set; }
}
