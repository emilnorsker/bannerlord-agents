using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

[Serializable]
public struct ManagedArray
{
	internal IntPtr Array;

	internal int Length;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedArray(IntPtr array, int length)
	{
		throw null;
	}
}
