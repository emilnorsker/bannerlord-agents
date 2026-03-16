using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct TWSharedMutexWriteLock : IDisposable
{
	private readonly TWSharedMutex _mtx;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TWSharedMutexWriteLock(TWSharedMutex mtx)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}
}
