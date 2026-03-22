using System.Collections.Generic;

namespace AIInfluence.NpcInteraction.Consumers;

public sealed class ActionEventConsumer
{
	private readonly List<InteractionEvent> _events = new List<InteractionEvent>();

	public IReadOnlyList<InteractionEvent> Events => _events;

	public void Consume(InteractionEvent item)
	{
		if (item.Type == InteractionEventType.ActionStarted || item.Type == InteractionEventType.ActionCompleted || item.Type == InteractionEventType.ActionFailed)
		{
			_events.Add(item);
		}
	}
}

