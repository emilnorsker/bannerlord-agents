using System.Collections.Generic;

namespace AIInfluence.AINative;

public sealed class AINativeLlmCompletion
{
	public string Text { get; }

	public IReadOnlyList<AINativeLlmToolCall> ToolCalls { get; }

	public AINativeLlmCompletion(string text, IReadOnlyList<AINativeLlmToolCall> toolCalls)
	{
		Text = text;
		ToolCalls = toolCalls;
	}
}

public sealed class AINativeLlmToolCall
{
	public string Name { get; }

	public IReadOnlyDictionary<string, string> Arguments { get; }

	public AINativeLlmToolCall(string name, IReadOnlyDictionary<string, string> arguments)
	{
		Name = name;
		Arguments = arguments;
	}
}

