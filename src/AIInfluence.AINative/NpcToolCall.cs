using Newtonsoft.Json.Linq;

namespace AIInfluence.NpcInteraction;

public sealed class NpcToolCall
{
	public string ToolName { get; set; }
	public JObject ToolArguments { get; set; }
}
