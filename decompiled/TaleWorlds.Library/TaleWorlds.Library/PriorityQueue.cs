using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>, IEnumerable<KeyValuePair<TPriority, TValue>>, IEnumerable
{
	private readonly List<KeyValuePair<TPriority, TValue>> _baseHeap;

	private readonly IComparer<TPriority> _customComparer;

	private IComparer<TPriority> Comparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEmpty
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

	public bool IsReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriorityQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriorityQueue(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriorityQueue(int capacity, IComparer<TPriority> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriorityQueue(IComparer<TPriority> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2, IComparer<TPriority> comparer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Enqueue(TPriority priority, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KeyValuePair<TPriority, TValue> Dequeue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TValue DequeueValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KeyValuePair<TPriority, TValue> Peek()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TValue PeekValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExchangeElements(int pos1, int pos2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Insert(TPriority priority, TValue value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int HeapifyFromEndToBeginning(int pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeleteRoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HeapifyFromBeginningToEnd(int pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(KeyValuePair<TPriority, TValue> item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(KeyValuePair<TPriority, TValue> item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Remove(KeyValuePair<TPriority, TValue> item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw null;
	}
}
