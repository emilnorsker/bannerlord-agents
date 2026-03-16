using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public static class TWParallel
{
	public delegate void ParallelForAuxPredicate(int localStartIndex, int localEndIndex);

	public delegate void ParallelForWithDtAuxPredicate(int localStartIndex, int localEndIndex, float dt);

	private static IParallelDriver _parallelDriver;

	private static ulong _mainThreadId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeAndSetImplementation(IParallelDriver parallelDriver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Obsolete("Please use For() not ForEach() for better Parallel Performance.", true)]
	public static void ForEach<TSource>(IList<TSource> source, Action<TSource> body)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void For(int fromInclusive, int toExclusive, ParallelForAuxPredicate body, int grainSize = 16)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ForWithoutRenderThread(int fromInclusive, int toExclusive, ParallelForAuxPredicate body, int grainSize = 16)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void For(int fromInclusive, int toExclusive, float deltaTime, ParallelForWithDtAuxPredicate body, int grainSize = 16)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	public static void AssertIsMainThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMainThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ulong GetMainThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ulong GetCurrentThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TWParallel()
	{
		throw null;
	}
}
