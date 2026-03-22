using System;
using System.Collections.Generic;
using System.Text;

namespace AIInfluence.NpcInteraction;

public sealed class ChatWindowToolExecutor
{
	private readonly Dictionary<string, IChatWindowTool> _tools;

	public ChatWindowToolExecutor()
	{
		_tools = new Dictionary<string, IChatWindowTool>
		{
			[OpenRouterToolCallClient.SayTool] = new SayChatWindowTool(),
			[OpenRouterToolCallClient.EmoteTool] = new EmoteChatWindowTool()
		};
	}

	public string ExecuteForChat(IReadOnlyList<ToolInvocation> invocations, Action<string> onPartialResponse = null)
	{
		var output = new StringBuilder();
		foreach (ToolInvocation invocation in invocations)
		{
			_tools[invocation.Name].Execute(invocation, output, onPartialResponse);
		}
		return output.ToString();
	}
}
