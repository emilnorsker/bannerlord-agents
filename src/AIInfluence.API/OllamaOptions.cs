using Newtonsoft.Json;

namespace AIInfluence.API;

public class OllamaOptions
{
	[JsonProperty("num_predict")]
	public int? NumPredict { get; set; }

	[JsonProperty("temperature")]
	public double? Temperature { get; set; }

	[JsonProperty("top_p")]
	public double? TopP { get; set; }
}
