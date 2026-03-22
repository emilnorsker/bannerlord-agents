using System;
using System.Collections.Generic;

namespace AIInfluence.AINative;

public sealed class AINativeQueue
{
	private sealed class Subscription : IDisposable
	{
		private readonly AINativeQueue _queue;

		private readonly Action<AINativeEvent> _consumer;

		private bool _disposed;

		public Subscription(AINativeQueue queue, Action<AINativeEvent> consumer)
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

	private readonly Queue<AINativeEvent> _events = new Queue<AINativeEvent>();

	private readonly List<Action<AINativeEvent>> _subscribers = new List<Action<AINativeEvent>>();

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

	public IDisposable Subscribe(Action<AINativeEvent> consumer)
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

	public long Enqueue(AINativeEvent item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		Action<AINativeEvent>[] subscribers;
		lock (_sync)
		{
			_sequence++;
			item.AssignSequence(_sequence);
			_events.Enqueue(item);
			subscribers = _subscribers.ToArray();
		}
		foreach (Action<AINativeEvent> subscriber in subscribers)
		{
			subscriber(item);
		}
		return item.Sequence;
	}

	public bool TryDequeue(out AINativeEvent item)
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

	private void Unsubscribe(Action<AINativeEvent> consumer)
	{
		lock (_sync)
		{
			_subscribers.Remove(consumer);
		}
	}
}

