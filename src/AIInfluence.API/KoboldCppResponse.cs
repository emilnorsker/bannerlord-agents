using Newtonsoft.Json;

namespace AIInfluence.API;

public class KoboldCppResponse
{
	[JsonProperty("results")]
	public KoboldCppResult[] Results { get; set; } = new KoboldCppResult[0];
}
