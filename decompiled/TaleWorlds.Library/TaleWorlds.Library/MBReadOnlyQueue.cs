using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBReadOnlyQueue<T> : Queue<T>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyQueue(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyQueue(Queue<T> queue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyQueue(IEnumerable<T> collection)
	{
		throw null;
	}
}
