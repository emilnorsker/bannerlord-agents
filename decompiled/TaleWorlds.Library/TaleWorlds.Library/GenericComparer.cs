using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class GenericComparer<T> : Comparer<T> where T : IComparable<T>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int Compare(T x, T y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericComparer()
	{
		throw null;
	}
}
