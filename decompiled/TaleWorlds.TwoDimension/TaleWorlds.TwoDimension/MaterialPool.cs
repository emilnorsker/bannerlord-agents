using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public class MaterialPool<T> where T : Material, new()
{
	private List<T> _materialList;

	private int _nextAvailableIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MaterialPool(int initialBufferSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T New()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetAll()
	{
		throw null;
	}
}
