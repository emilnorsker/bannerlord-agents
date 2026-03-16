using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

public static class VisualOrderFactory
{
	private static List<VisualOrderProvider> _providers;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VisualOrderFactory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RegisterProvider(VisualOrderProvider provider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UnregisterProvider(VisualOrderProvider provider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBReadOnlyList<VisualOrderSet> GetOrders()
	{
		throw null;
	}
}
