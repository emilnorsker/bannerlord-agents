using Newtonsoft.Json;

namespace AIInfluence.API;

public class KoboldCppResult
{
	[JsonProperty("text")]
	public string Text { get; set; } = "";

	[JsonProperty("finish_reason")]
	public string FinishReason { get; set; } = "";

	[JsonProperty("prompt_tokens")]
	public int PromptTokens { get; set; }

	[JsonProperty("completion_tokens")]
	public int CompletionTokens { get; set; }
}
