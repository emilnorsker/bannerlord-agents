using System;
using System.Collections.Generic;
using System.Text;

namespace AIInfluence.NpcInteraction;

public sealed class NpcDialogueToolOrchestrator
{
	private readonly Dictionary<string, INpcDialogueTool> _tools;

	public NpcDialogueToolOrchestrator()
	{
		_tools = new Dictionary<string, INpcDialogueTool>
		{
			[NpcInteractionInferenceClient.SayTool] = new NpcSayTool(),
			[NpcInteractionInferenceClient.EmoteTool] = new NpcEmoteTool()
		};
	}

	public string BuildNpcReply(IReadOnlyList<NpcToolCall> toolCalls, Action<string> onPartialResponse = null)
	{
		var npcReply = new StringBuilder();
		foreach (NpcToolCall toolCall in toolCalls)
		{
			_tools[toolCall.ToolName].Apply(toolCall, npcReply, onPartialResponse);
		}
		return npcReply.ToString();
	}
}
