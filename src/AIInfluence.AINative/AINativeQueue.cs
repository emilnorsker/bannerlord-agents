using System;
using System.Collections.Generic;

namespace AIInfluence.NpcInteraction;

public sealed class InteractionEventStream
{
	private sealed class Subscription : IDisposable
	{
		private readonly InteractionEventStream _queue;

		private readonly Action<InteractionEvent> _consumer;

		private bool _disposed;

		public Subscription(InteractionEventStream queue, Action<InteractionEvent> consumer)
		{
			_queue = queue;
			_consumer = consumer;
		}

		public void Dispose()
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			_queue.Unsubscribe(_consumer);
		}
	}

	private readonly object _sync = new object();

	private readonly Queue<InteractionEvent> _events = new Queue<InteractionEvent>();

	private readonly List<Action<InteractionEvent>> _subscribers = new List<Action<InteractionEvent>>();

	private long _sequence;

	public int Count
	{
		get
		{
			lock (_sync)
			{
				return _events.Count;
			}
		}
	}

	public IDisposable Subscribe(Action<InteractionEvent> consumer)
	{
		if (consumer == null)
		{
			throw new ArgumentNullException("consumer");
		}
		lock (_sync)
		{
			_subscribers.Add(consumer);
		}
		return new Subscription(this, consumer);
	}

	public long Enqueue(InteractionEvent item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		Action<InteractionEvent>[] subscribers;
		lock (_sync)
		{
			_sequence++;
			item.AssignSequence(_sequence);
			_events.Enqueue(item);
			subscribers = _subscribers.ToArray();
		}
		foreach (Action<InteractionEvent> subscriber in subscribers)
		{
			subscriber(item);
		}
		return item.Sequence;
	}

	public bool TryDequeue(out InteractionEvent item)
	{
		lock (_sync)
		{
			if (_events.Count == 0)
			{
				item = null;
				return false;
			}
			item = _events.Dequeue();
			return true;
		}
	}

	private void Unsubscribe(Action<InteractionEvent> consumer)
	{
		lock (_sync)
		{
			_subscribers.Remove(consumer);
		}
	}
}

