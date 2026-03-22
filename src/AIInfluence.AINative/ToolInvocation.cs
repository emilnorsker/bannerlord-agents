using Newtonsoft.Json.Linq;

namespace AIInfluence.NpcInteraction;

public sealed class ToolInvocation
{
	public string Name { get; set; }
	public JObject Arguments { get; set; }
}
