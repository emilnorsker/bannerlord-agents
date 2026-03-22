namespace AIInfluence.NpcInteraction;

public interface IInteractionTool
{
	string Name { get; }

	bool IsLongRunning { get; }

	void Execute(InteractionToolContext context, InteractionEventStream stream);
}

