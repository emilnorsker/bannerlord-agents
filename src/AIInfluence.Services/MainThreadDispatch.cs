using System;
using System.Collections.Concurrent;

namespace AIInfluence.Services;

/// <summary>Cross-thread dispatch to the game main thread (LLM stream UI, etc.).</summary>
public static class MainThreadDispatch
{
	public static readonly ConcurrentQueue<Action> MainThreadQueue = new ConcurrentQueue<Action>();
}
