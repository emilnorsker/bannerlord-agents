using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public struct TWSharedMutexReadLock : IDisposable
{
	private readonly TWSharedMutex _mtx;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TWSharedMutexReadLock(TWSharedMutex mtx)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}
}
