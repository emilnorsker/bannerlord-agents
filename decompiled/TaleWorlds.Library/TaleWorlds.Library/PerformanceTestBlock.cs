using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class PerformanceTestBlock : IDisposable
{
	private readonly string _name;

	private readonly Stopwatch _stopwatch;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PerformanceTestBlock(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDisposable.Dispose()
	{
		throw null;
	}
}
