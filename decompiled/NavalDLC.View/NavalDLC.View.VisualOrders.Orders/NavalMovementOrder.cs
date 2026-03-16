using System.Runtime.CompilerServices;
using NavalDLC.Missions;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace NavalDLC.View.VisualOrders.Orders;

public class NavalMovementOrder : VisualOrder
{
	private OrderType _orderType;

	private bool _useWorldPosition;

	private bool _isTargeted;

	private TextObject _name;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMovementOrder(string stringId, OrderType order, TextObject name, bool useWorldPosition = false, bool isTargeted = false)
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
	private ShipOrder.ShipMovementOrderEnum GetMovementOrderEnum()
	{
		throw null;
	}
}
