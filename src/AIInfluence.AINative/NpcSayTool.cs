using System;
using System.Text;

namespace AIInfluence.NpcInteraction;

public sealed class NpcSayTool : INpcDialogueTool
{
	public string Name => NpcInteractionInferenceClient.SayTool;

	public void Apply(NpcToolCall toolCall, StringBuilder npcReply, Action<string> onPartialResponse)
	{
		if (npcReply.Length > 0) npcReply.Append("\n");
		npcReply.Append(toolCall.ToolArguments["text"]?.ToString());
		onPartialResponse?.Invoke(npcReply.ToString());
	}
}
