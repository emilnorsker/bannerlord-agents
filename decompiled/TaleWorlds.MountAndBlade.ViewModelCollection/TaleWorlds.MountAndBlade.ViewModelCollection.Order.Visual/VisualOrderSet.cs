using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

public abstract class VisualOrderSet
{
	private MBList<VisualOrder> _orders;

	public MBReadOnlyList<VisualOrder> Orders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public VisualOrder SoloOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract bool IsSoloOrder { get; }

	public abstract string StringId { get; }

	public abstract string IconId { get; }

	public abstract TextObject GetName(OrderController orderController);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualOrderSet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddOrder(VisualOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveOrder(VisualOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearOrders()
	{
		throw null;
	}
}
