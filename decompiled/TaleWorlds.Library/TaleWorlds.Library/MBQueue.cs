using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBQueue<T> : MBReadOnlyQueue<T>, IMBCollection
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBQueue(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBQueue(Queue<T> queue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBQueue(IEnumerable<T> collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Remove(T item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMBCollection.Clear()
	{
		throw null;
	}
}
