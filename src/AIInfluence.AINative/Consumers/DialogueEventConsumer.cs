using System.Collections.Generic;

namespace AIInfluence.NpcInteraction.Consumers;

public sealed class DialogueEventConsumer
{
	private readonly List<InteractionEvent> _events = new List<InteractionEvent>();

	public IReadOnlyList<InteractionEvent> Events => _events;

	public void Consume(InteractionEvent item)
	{
		if (item.Type == InteractionEventType.DialogueSpoken)
		{
			_events.Add(item);
		}
	}
}

