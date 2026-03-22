using System;

namespace AIInfluence.NpcInteraction.Tools;

public sealed class NpcSayTool : IInteractionTool
{
	public string Name => "npc_say";

	public bool IsLongRunning => false;

	public void Execute(InteractionToolContext context, InteractionEventStream stream)
	{
		if (!context.Arguments.TryGetValue("text", out var text) || string.IsNullOrWhiteSpace(text))
		{
			throw new InvalidOperationException("npc_say requires non-empty argument 'text'.");
		}
		stream.Enqueue(new InteractionEvent(InteractionEventType.DialogueSpoken, context.CorrelationId, context.NpcId, Name, text));
	}
}

