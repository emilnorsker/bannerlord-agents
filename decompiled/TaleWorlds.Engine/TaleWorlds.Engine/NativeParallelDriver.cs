using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public sealed class NativeParallelDriver : IParallelDriver
{
	private struct LoopBodyHolder
	{
		public static long UniqueLoopBodyKeySeed;

		public TWParallel.ParallelForAuxPredicate LoopBody;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static LoopBodyHolder()
		{
			throw null;
		}
	}

	private struct LoopBodyWithDtHolder
	{
		public static long UniqueLoopBodyKeySeed;

		public TWParallel.ParallelForWithDtAuxPredicate LoopBody;

		public float DeltaTime;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static LoopBodyWithDtHolder()
		{
			throw null;
		}
	}

	private const int K = 256;

	private static readonly LoopBodyHolder[] _loopBodyCache;

	private static readonly LoopBodyWithDtHolder[] _loopBodyWithDtCache;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void For(int fromInclusive, int toExclusive, TWParallel.ParallelForAuxPredicate loopBody, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForWithoutRenderThread(int fromInclusive, int toExclusive, TWParallel.ParallelForAuxPredicate loopBody, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void ParalelForLoopBodyCaller(long loopBodyKey, int localStartIndex, int localEndIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void For(int fromInclusive, int toExclusive, float deltaTime, TWParallel.ParallelForWithDtAuxPredicate loopBody, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void ParalelForLoopBodyWithDtCaller(long loopBodyKey, int localStartIndex, int localEndIndex)
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
	public NativeParallelDriver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NativeParallelDriver()
	{
		throw null;
	}
}
