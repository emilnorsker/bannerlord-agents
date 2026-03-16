using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBReadOnlyList<T> : List<T>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList(IEnumerable<T> collection)
	{
		throw null;
	}
}
