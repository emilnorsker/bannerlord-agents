using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

public sealed class ActionVisualOrder : VisualOrder
{
	public delegate void OrderActionDelegate(OrderController orderController, VisualOrderExecutionParameters executionParameters);

	private readonly OrderActionDelegate _orderAction;

	private readonly TextObject _name;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionVisualOrder(string iconId, OrderActionDelegate orderAction, TextObject name)
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
	public override void ExecuteOrder(OrderController orderController, VisualOrderExecutionParameters executionParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool? OnGetFormationHasOrder(Formation formation)
	{
		throw null;
	}
}
