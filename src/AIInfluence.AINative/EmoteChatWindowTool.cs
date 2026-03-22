using System;
using System.Text;

namespace AIInfluence.NpcInteraction;

public sealed class EmoteChatWindowTool : IChatWindowTool
{
	public string Name => OpenRouterToolCallClient.EmoteTool;

	public void Execute(ToolInvocation invocation, StringBuilder output, Action<string> onPartialResponse)
	{
		if (output.Length > 0) output.Append("\n");
		output.Append("*");
		output.Append(invocation.Arguments["text"]?.ToString());
		output.Append("*");
		onPartialResponse?.Invoke(output.ToString());
	}
}
