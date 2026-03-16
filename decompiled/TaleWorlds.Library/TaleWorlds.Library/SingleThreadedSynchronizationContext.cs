using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TaleWorlds.Library;

public sealed class SingleThreadedSynchronizationContext : SynchronizationContext
{
	private struct WorkRequest
	{
		private readonly SendOrPostCallback _callback;

		private readonly object _state;

		private readonly ManualResetEvent _waitHandle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WorkRequest(SendOrPostCallback callback, object state, ManualResetEvent waitHandle = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Invoke()
		{
			throw null;
		}
	}

	private List<WorkRequest> _futureWorks;

	private List<WorkRequest> _currentWorks;

	private readonly object _worksLock;

	private readonly int _mainThreadId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SingleThreadedSynchronizationContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Send(SendOrPostCallback callback, object state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Post(SendOrPostCallback callback, object state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}
}
