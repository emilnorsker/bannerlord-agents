using Newtonsoft.Json;

namespace AIInfluence.API;

public class OllamaGenerateRequest
{
	[JsonProperty("model")]
	public string Model { get; set; }

	[JsonProperty("prompt")]
	public string Prompt { get; set; }

	[JsonProperty("stream")]
	public bool Stream { get; set; }

	[JsonProperty("options")]
	public OllamaOptions Options { get; set; }
}
