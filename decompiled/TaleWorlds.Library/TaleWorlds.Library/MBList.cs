using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class MBList<T> : MBReadOnlyList<T>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList(IEnumerable<T> collection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList(List<T> collection)
	{
		throw null;
	}
}
