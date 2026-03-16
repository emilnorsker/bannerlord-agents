using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace NavalDLC.View.VisualOrders.Orders;

public class NavalToggleVisualOrder : VisualOrder
{
	private OrderType _positiveOrder;

	private OrderType _negativeOrder;

	private TextObject _positiveOrderName;

	private TextObject _negativeOrderName;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalToggleVisualOrder(string stringId, OrderType positiveOrder, OrderType negativeOrder, TextObject positiveOrderName, TextObject negativeOrderName)
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override string GetIconId()
	{
		throw null;
	}
}
