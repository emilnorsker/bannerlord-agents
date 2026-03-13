using Newtonsoft.Json;

namespace AIInfluence.API;

public class DeepSeekMessage
{
	[JsonProperty("role")]
	public string Role { get; set; } = string.Empty;

	[JsonProperty("content")]
	public string Content { get; set; } = string.Empty;
}
