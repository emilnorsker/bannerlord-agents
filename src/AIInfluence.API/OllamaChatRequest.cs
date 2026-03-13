using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.API;

public class OllamaChatRequest
{
	[JsonProperty("model")]
	public string Model { get; set; }

	[JsonProperty("messages")]
	public List<OllamaMessage> Messages { get; set; }

	[JsonProperty("stream")]
	public bool Stream { get; set; }

	[JsonProperty("options")]
	public OllamaOptions Options { get; set; }
}
