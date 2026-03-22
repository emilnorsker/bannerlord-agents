using System.Collections.Generic;

namespace AIInfluence.AINative.Consumers;

public sealed class DialogueEventConsumer
{
	private readonly List<AINativeEvent> _events = new List<AINativeEvent>();

	public IReadOnlyList<AINativeEvent> Events => _events;

	public void Consume(AINativeEvent item)
	{
		if (item.Type == AINativeEventType.DialogueSpoken)
		{
			_events.Add(item);
		}
	}
}

