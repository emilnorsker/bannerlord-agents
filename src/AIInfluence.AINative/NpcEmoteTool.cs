using System;
using System.Text;

namespace AIInfluence.NpcInteraction;

public sealed class NpcEmoteTool : INpcDialogueTool
{
	public string Name => NpcInteractionInferenceClient.EmoteTool;

	public void Apply(NpcToolCall toolCall, StringBuilder npcReply, Action<string> onPartialResponse)
	{
		if (npcReply.Length > 0) npcReply.Append("\n");
		npcReply.Append("*");
		npcReply.Append(toolCall.ToolArguments["text"]?.ToString());
		npcReply.Append("*");
		onPartialResponse?.Invoke(npcReply.ToString());
	}
}
