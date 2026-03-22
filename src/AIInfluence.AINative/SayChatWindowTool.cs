using System;
using System.Text;

namespace AIInfluence.NpcInteraction;

public sealed class SayChatWindowTool : IChatWindowTool
{
	public string Name => OpenRouterToolCallClient.SayTool;

	public void Execute(ToolInvocation invocation, StringBuilder output, Action<string> onPartialResponse)
	{
		if (output.Length > 0) output.Append("\n");
		output.Append(invocation.Arguments["text"]?.ToString());
		onPartialResponse?.Invoke(output.ToString());
	}
}
