using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Library;

public struct MBStringBuilder
{
	private static class CachedStringBuilder
	{
		private const int MaxBuilderSize = 4096;

		[ThreadStatic]
		private static StringBuilder _cachedStringBuilder;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static StringBuilder Acquire(int capacity = 16)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Release(StringBuilder sb)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetStringAndReleaseBuilder(StringBuilder sb)
		{
			throw null;
		}
	}

	private StringBuilder _cachedStringBuilder;

	public int Length
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(int capacity = 16, [CallerMemberName] string callerMemberName = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ToStringAndRelease()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder Append(char value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder Append(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder Append(uint value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder Append(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder Append(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder Append<T>(T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder AppendLine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBStringBuilder AppendLine<T>(T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
