using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.Library;

internal static class GCHandleFactory
{
	private static List<GCHandle> _handles;

	private static object _locker;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GCHandleFactory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GCHandle GetHandle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReturnHandle(GCHandle handle)
	{
		throw null;
	}
}
