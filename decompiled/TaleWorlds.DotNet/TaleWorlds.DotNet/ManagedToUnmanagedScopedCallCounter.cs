using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TaleWorlds.DotNet;

public class ManagedToUnmanagedScopedCallCounter : IDisposable
{
	private static ThreadLocal<Dictionary<int, List<StackTrace>>> _table;

	private static ThreadLocal<int> _depth;

	private static int _depthThreshold;

	private StackTrace _st;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedToUnmanagedScopedCallCounter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ManagedToUnmanagedScopedCallCounter()
	{
		throw null;
	}
}
