using System.Collections.Generic;

namespace AIInfluence.NpcInteraction;

public sealed class ModelTurnResult
{
	public string Text { get; }

	public IReadOnlyList<ModelToolCall> ToolCalls { get; }

	public ModelTurnResult(string text, IReadOnlyList<ModelToolCall> toolCalls)
	{
		Text = text;
		ToolCalls = toolCalls;
	}
}

public sealed class ModelToolCall
{
	public string Name { get; }

	public IReadOnlyDictionary<string, string> Arguments { get; }

	public ModelToolCall(string name, IReadOnlyDictionary<string, string> arguments)
	{
		Name = name;
		Arguments = arguments;
	}
}

