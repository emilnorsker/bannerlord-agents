using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBSortedMultiList<TKey, TValue> : IReadOnlyList<TValue>, IEnumerable<TValue>, IEnumerable, IReadOnlyCollection<TValue>, IMBCollection where TKey : IComparable<TKey>
{
	public enum ComparerType
	{
		None,
		Custom,
		Ascending,
		Descending
	}

	private struct SMLValueEnumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		private readonly List<KeyValuePair<TKey, TValue>> _list;

		private int _index;

		private TValue _current;

		public TValue Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SMLValueEnumerator(List<KeyValuePair<TKey, TValue>> list)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool MoveNext()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Reset()
		{
			throw null;
		}
	}

	private struct SMLKeyValueEnumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		private readonly List<KeyValuePair<TKey, TValue>> _list;

		private readonly TKey _key;

		private int _index;

		private TValue _current;

		public TValue Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SMLKeyValueEnumerator(List<KeyValuePair<TKey, TValue>> list, TKey key, int startIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool MoveNext()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Reset()
		{
			throw null;
		}
	}

	private readonly List<KeyValuePair<TKey, TValue>> _items;

	private ComparerType _comparerType;

	private IComparer<TKey> _keyComparer;

	private IComparer<KeyValuePair<TKey, TValue>> _pairComparer;

	public ComparerType Comparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsAscending
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsDescending
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TValue this[int index]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TValue FirstValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TValue LastValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static IComparer<TKey> DefaultAscendingKeyComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static IComparer<TKey> DefaultDescendingKeyComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBSortedMultiList(IComparer<TKey> customComparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBSortedMultiList(bool isAscending = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(TKey key, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KeyValuePair<TKey, TValue> Get(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int FirstIndexOf(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int FirstIndexOf(TKey key, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int LastIndexOf(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int LastIndexOf(TKey key, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool All(Predicate<KeyValuePair<TKey, TValue>> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Any(Predicate<KeyValuePair<TKey, TValue>> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerator<TValue> GetValues(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Find(Predicate<KeyValuePair<TKey, TValue>> predicate, out KeyValuePair<TKey, TValue> found, bool searchForward = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int FindIndex(Predicate<KeyValuePair<TKey, TValue>> predicate, bool searchForward = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<KeyValuePair<TKey, TValue>> FindAll(Predicate<KeyValuePair<TKey, TValue>> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(TKey key, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Remove(TKey key, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Remove(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RemoveAll(Predicate<KeyValuePair<TKey, TValue>> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAt(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveLast()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomComparer(IComparer<TKey> customComparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDefaultComparer(bool isAscending = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reverse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerator<TValue> GetEnumerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int LowerBound(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int UpperBound(TKey key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IComparer<KeyValuePair<TKey, TValue>> GetPairComparerFromKeyComparer()
	{
		throw null;
	}
}
