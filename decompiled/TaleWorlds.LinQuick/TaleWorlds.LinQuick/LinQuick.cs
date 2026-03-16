using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TaleWorlds.LinQuick;

public static class LinQuick
{
	[CompilerGenerated]
	private sealed class _003CSelectQ_003Ed__68<T, R> : IEnumerable<R>, IEnumerable, IEnumerator<R>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private R _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private T[] source;

		public T[] _003C_003E3__source;

		private Func<T, R> selector;

		public Func<T, R> _003C_003E3__selector;

		private int _003Clen_003E5__2;

		private int _003Ci_003E5__3;

		R IEnumerator<R>.Current
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
		public _003CSelectQ_003Ed__68(int _003C_003E1__state)
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
		IEnumerator<R> IEnumerable<R>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CSelectQ_003Ed__69<T, R> : IEnumerable<R>, IEnumerable, IEnumerator<R>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private R _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<T> source;

		public List<T> _003C_003E3__source;

		private Func<T, R> selector;

		public Func<T, R> _003C_003E3__selector;

		private int _003Clen_003E5__2;

		private int _003Ci_003E5__3;

		R IEnumerator<R>.Current
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
		public _003CSelectQ_003Ed__69(int _003C_003E1__state)
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
		IEnumerator<R> IEnumerable<R>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CSelectQ_003Ed__70<T, R> : IEnumerable<R>, IEnumerable, IEnumerator<R>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private R _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IReadOnlyList<T> source;

		public IReadOnlyList<T> _003C_003E3__source;

		private Func<T, R> selector;

		public Func<T, R> _003C_003E3__selector;

		private int _003Clen_003E5__2;

		private int _003Ci_003E5__3;

		R IEnumerator<R>.Current
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
		public _003CSelectQ_003Ed__70(int _003C_003E1__state)
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
		IEnumerator<R> IEnumerable<R>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CSelectQ_003Ed__71<T, R> : IEnumerable<R>, IEnumerable, IEnumerator<R>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private R _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private Func<T, R> selector;

		public Func<T, R> _003C_003E3__selector;

		private IEnumerator<T> _003C_003E7__wrap1;

		R IEnumerator<R>.Current
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
		public _003CSelectQ_003Ed__71(int _003C_003E1__state)
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
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<R> IEnumerable<R>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CWhereQ_003Ed__88<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private T[] source;

		public T[] _003C_003E3__source;

		private Func<T, bool> predicate;

		public Func<T, bool> _003C_003E3__predicate;

		private int _003Clength_003E5__2;

		private int _003Ci_003E5__3;

		T IEnumerator<T>.Current
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
		public _003CWhereQ_003Ed__88(int _003C_003E1__state)
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
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CWhereQ_003Ed__89<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<T> source;

		public List<T> _003C_003E3__source;

		private Func<T, bool> predicate;

		public Func<T, bool> _003C_003E3__predicate;

		private int _003Clength_003E5__2;

		private int _003Ci_003E5__3;

		T IEnumerator<T>.Current
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
		public _003CWhereQ_003Ed__89(int _003C_003E1__state)
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
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CWhereQImp_003Ed__91<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IReadOnlyList<T> source;

		public IReadOnlyList<T> _003C_003E3__source;

		private Func<T, bool> predicate;

		public Func<T, bool> _003C_003E3__predicate;

		private int _003Clength_003E5__2;

		private int _003Ci_003E5__3;

		T IEnumerator<T>.Current
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
		public _003CWhereQImp_003Ed__91(int _003C_003E1__state)
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
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003CWhereQImp_003Ed__93<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private Func<T, bool> predicate;

		public Func<T, bool> _003C_003E3__predicate;

		private IEnumerator<T> _003C_003E7__wrap1;

		T IEnumerator<T>.Current
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
		public _003CWhereQImp_003Ed__93(int _003C_003E1__state)
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
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
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
	public static bool AllQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AllQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AllQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AllQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this List<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this IReadOnlyList<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this IEnumerable<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AnyQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AverageQ(this float[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AverageQ(this IEnumerable<float> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AverageQ<T>(this T[] source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AverageQ<T>(this List<T> source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AverageQ<T>(this IReadOnlyList<T> source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float AverageQ<T>(this IEnumerable<T> source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this T[] source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this List<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this IReadOnlyList<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this IEnumerable<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this Queue<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ContainsQ<T>(this Queue<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this T[] source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this List<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this IReadOnlyList<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int CountQ<T>(this IEnumerable<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this T[] source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this List<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this IReadOnlyList<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this IEnumerable<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int FindIndexQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int FindIndexComparableQ<T>(this IEnumerable<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int FindIndexNonComparableQ<T>(this IEnumerable<T> source, T value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T FirstOrDefaultQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T FirstOrDefaultQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T FirstOrDefaultQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T FirstOrDefaultQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ(this int[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ(this List<int> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T MaxQ<T>(this T[] source) where T : IComparable<T>
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T MaxQ<T>(this List<T> source) where T : IComparable<T>
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ(this IReadOnlyList<int> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T MaxQ<T>(this IReadOnlyList<T> source) where T : IComparable<T>
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float MaxQ<T>(this T[] source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ<T>(this T[] source, Func<T, int> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float MaxQ<T>(this List<T> source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ<T>(this List<T> source, Func<T, int> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float MaxQ<T>(this IReadOnlyList<T> source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ<T>(this IReadOnlyList<T> source, Func<T, int> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float MaxQ<T>(this IEnumerable<T> source, Func<T, float> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int MaxQ<T>(this IEnumerable<T> source, Func<T, int> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (T, T, T) MaxElements3<T>(this IEnumerable<T> collection, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IOrderedEnumerable<T> OrderByQ<T, S>(this IEnumerable<T> source, Func<T, S> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] OrderByQ<T, TKey>(this T[] source, Func<T, TKey> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] OrderByQ<T, TKey>(this List<T> source, Func<T, TKey> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] OrderByQ<T, TKey>(this IReadOnlyList<T> source, Func<T, TKey> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSelectQ_003Ed__68<, >))]
	public static IEnumerable<R> SelectQ<T, R>(this T[] source, Func<T, R> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSelectQ_003Ed__69<, >))]
	public static IEnumerable<R> SelectQ<T, R>(this List<T> source, Func<T, R> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSelectQ_003Ed__70<, >))]
	public static IEnumerable<R> SelectQ<T, R>(this IReadOnlyList<T> source, Func<T, R> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSelectQ_003Ed__71<, >))]
	public static IEnumerable<R> SelectQ<T, R>(this IEnumerable<T> source, Func<T, R> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int SumQ<T>(this T[] source, Func<T, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SumQ<T>(this T[] source, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int SumQ<T>(this List<T> source, Func<T, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SumQ<T>(this List<T> source, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int SumQ<T>(this IReadOnlyList<T> source, Func<T, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SumQ<T>(this IReadOnlyList<T> source, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SumQ<T>(this IEnumerable<T> source, Func<T, float> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int SumQ<T>(this IEnumerable<T> source, Func<T, int> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] ToArrayQ<T>(this T[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] ToArrayQ<T>(this List<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] ToArrayQ<T>(this IReadOnlyList<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] ToArrayQ<T>(this IEnumerable<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> ToListQ<T>(this T[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> ToListQ<T>(this List<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> ToListQ<T>(this IReadOnlyList<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> ToListQ<T>(this IEnumerable<T> source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CWhereQ_003Ed__88<>))]
	public static IEnumerable<T> WhereQ<T>(this T[] source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CWhereQ_003Ed__89<>))]
	public static IEnumerable<T> WhereQ<T>(this List<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<T> WhereQ<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CWhereQImp_003Ed__91<>))]
	private static IEnumerable<T> WhereQImp<T>(IReadOnlyList<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<T> WhereQ<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CWhereQImp_003Ed__93<>))]
	private static IEnumerable<T> WhereQImp<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		throw null;
	}
}
