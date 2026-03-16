using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public sealed class DefaultParallelDriver : IParallelDriver
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void For(int fromInclusive, int toExclusive, TWParallel.ParallelForAuxPredicate body, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForWithoutRenderThread(int fromInclusive, int toExclusive, TWParallel.ParallelForAuxPredicate body, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void For(int fromInclusive, int toExclusive, float deltaTime, TWParallel.ParallelForWithDtAuxPredicate body, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetMainThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetCurrentThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultParallelDriver()
	{
		throw null;
	}
}
