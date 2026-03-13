using Newtonsoft.Json;

namespace AIInfluence.API;

public class DeepSeekChatChoice
{
	[JsonProperty("message")]
	public DeepSeekMessage Message { get; set; }
}
