using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace TaleWorlds.MountAndBlade.View.VisualOrders.OrderSets;

public class SingleVisualOrderSet : VisualOrderSet
{
	public readonly VisualOrder Order;

	private bool _isInitializing;

	public override bool IsSoloOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override string StringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override string IconId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetName(OrderController orderController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SingleVisualOrderSet(VisualOrder order)
	{
		throw null;
	}
}
