using Newtonsoft.Json;

namespace AIInfluence.API;

public class KoboldCppGenerateRequest
{
	[JsonProperty("prompt")]
	public string Prompt { get; set; }

	[JsonProperty("max_length")]
	public int? MaxLength { get; set; }

	[JsonProperty("max_context_length")]
	public int? MaxContextLength { get; set; }

	[JsonProperty("temperature")]
	public double? Temperature { get; set; }

	[JsonProperty("top_p")]
	public double? TopP { get; set; }

	[JsonProperty("stream")]
	public bool Stream { get; set; }

	[JsonProperty("stop_sequence")]
	public string[] StopSequence { get; set; }
}
