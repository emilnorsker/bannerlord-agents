namespace AIInfluence.NpcInteraction.Tools;

public abstract class LongRunningActionTool : IInteractionTool
{
	public abstract string Name { get; }

	public bool IsLongRunning => true;

	public void Execute(InteractionToolContext context, InteractionEventStream stream)
	{
		stream.Enqueue(new InteractionEvent(InteractionEventType.ActionStarted, context.CorrelationId, context.NpcId, Name, string.Empty));
	}
}

