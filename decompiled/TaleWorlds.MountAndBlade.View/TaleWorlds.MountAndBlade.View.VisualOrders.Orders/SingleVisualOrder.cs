using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace TaleWorlds.MountAndBlade.View.VisualOrders.Orders;

public class SingleVisualOrder : VisualOrder
{
	private TextObject _name;

	private OrderType _orderType;

	private bool _useFormationTarget;

	private bool _useWorldPositionTarget;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SingleVisualOrder(string stringId, TextObject name, OrderType orderType, bool useFormationTarget, bool useWorldPositionTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteOrder(OrderController orderController, VisualOrderExecutionParameters executionParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetName(OrderController orderController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsTargeted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool? OnGetFormationHasOrder(Formation formation)
	{
		throw null;
	}
}
