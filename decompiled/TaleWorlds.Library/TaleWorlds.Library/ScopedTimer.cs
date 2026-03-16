using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class ScopedTimer : IDisposable
{
	private readonly Stopwatch watch_;

	private readonly string scopeName_;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScopedTimer(string scopeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}
}
