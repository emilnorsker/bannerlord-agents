using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.TwoDimension.Standalone.Native;

internal class AutoPinner : IDisposable
{
	private GCHandle _pinnedObject;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AutoPinner(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static implicit operator IntPtr(AutoPinner autoPinner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}
}
