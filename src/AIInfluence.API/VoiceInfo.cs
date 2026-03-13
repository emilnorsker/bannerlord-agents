using Newtonsoft.Json;

namespace AIInfluence.API;

public class VoiceInfo
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("gender")]
	public string Gender { get; set; }

	[JsonProperty("language")]
	public string Language { get; set; }
}
