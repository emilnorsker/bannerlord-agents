using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.API;

public class DeepSeekChatResponse
{
	[JsonProperty("choices")]
	public List<DeepSeekChatChoice> Choices { get; set; } = new List<DeepSeekChatChoice>();
}
