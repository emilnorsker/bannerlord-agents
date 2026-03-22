using System;

namespace AIInfluence.AINative.Tools;

public sealed class NpcSayTool : IAINativeTool
{
	public string Name => "npc_say";

	public bool IsLongRunning => false;

	public void Execute(AINativeToolContext context, AINativeQueue queue)
	{
		if (!context.Arguments.TryGetValue("text", out var text) || string.IsNullOrWhiteSpace(text))
		{
			throw new InvalidOperationException("npc_say requires non-empty argument 'text'.");
		}
		queue.Enqueue(new AINativeEvent(AINativeEventType.DialogueSpoken, context.CorrelationId, context.NpcId, Name, text));
	}
}

