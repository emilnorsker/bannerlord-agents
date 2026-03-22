using System;
using System.Collections.Concurrent;

namespace AIInfluence.Services;

/// <summary>
/// Queues actions to run on the game main thread (processed from <see cref="AIInfluenceBehavior" /> tick).
/// </summary>
public static class MainThreadDispatcher
{
	public static readonly ConcurrentQueue<Action> Queue = new ConcurrentQueue<Action>();
}
