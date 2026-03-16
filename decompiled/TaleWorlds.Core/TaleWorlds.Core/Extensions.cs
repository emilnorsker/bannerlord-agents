using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core;

public static class Extensions
{
	[CompilerGenerated]
	private sealed class _003CSplit_003Ed__12 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string str;

		public string _003C_003E3__str;

		private int maxChunkSize;

		public int _003C_003E3__maxChunkSize;

		private int _003Ci_003E5__2;

		string IEnumerator<string>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CSplit_003Ed__12(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ToHexadecimalString(this uint number)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string Description(this Enum value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float NextFloat(this Random random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, out TKey maxKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer, out TKey maxKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string Add(this string str, string appendant, bool newLine = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSplit_003Ed__12))]
	public static IEnumerable<string> Split(this string str, int maxChunkSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BattleSideEnum GetOppositeSide(this BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int splitItemCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsEmpty<T>(this IEnumerable<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Shuffle<T>(this IList<T> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElement<T>(this IReadOnlyList<T> e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElement<T>(this MBReadOnlyList<T> e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElement<T>(this MBList<T> e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElement<T>(this T[] e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElementInefficiently<T>(this IEnumerable<T> e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElementWithPredicate<T>(this T[] e, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElementWithPredicate<T>(this MBReadOnlyList<T> e, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElementWithPredicate<T>(this MBList<T> e, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetRandomElementWithPredicate<T>(this IReadOnlyList<T> e, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<Tuple<T1, T2>> CombineWith<T1, T2>(this IEnumerable<T1> list1, IEnumerable<T2> list2)
	{
		throw null;
	}
}
