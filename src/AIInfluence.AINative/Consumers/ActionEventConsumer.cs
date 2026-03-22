using System.Collections.Generic;

namespace AIInfluence.AINative.Consumers;

public sealed class ActionEventConsumer
{
	private readonly List<AINativeEvent> _events = new List<AINativeEvent>();

	public IReadOnlyList<AINativeEvent> Events => _events;

	public void Consume(AINativeEvent item)
	{
		if (item.Type == AINativeEventType.ActionStarted || item.Type == AINativeEventType.ActionCompleted || item.Type == AINativeEventType.ActionFailed)
		{
			_events.Add(item);
		}
	}
}

