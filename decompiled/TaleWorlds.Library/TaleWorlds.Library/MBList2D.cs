using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBList2D<T> : IMBCollection
{
	private T[] _data;

	public int Count1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public int Count2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	private int Capacity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public T[] RawArray
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public T this[int index1, int index2]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList2D(int count1, int count2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetWithNewCount(int newCount1, int newCount2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyRowTo(int sourceIndex1, int sourceIndex2, MBList2D<T> destination, int destinationIndex1, int destinationIndex2, int copyCount)
	{
		throw null;
	}
}
