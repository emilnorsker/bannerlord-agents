using System;
using System.Text;

namespace AIInfluence.NpcInteraction;

public interface IChatWindowTool
{
	string Name { get; }
	void Execute(ToolInvocation invocation, StringBuilder output, Action<string> onPartialResponse);
}
