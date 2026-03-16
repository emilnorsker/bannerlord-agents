using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

public abstract class VisualOrder
{
	protected OrderState _lastActiveState;

	public string StringId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public string IconId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualOrder(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual string GetIconId()
	{
		throw null;
	}

	public abstract TextObject GetName(OrderController orderController);

	public abstract bool IsTargeted();

	public abstract void ExecuteOrder(OrderController orderController, VisualOrderExecutionParameters executionParameters);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void BeforeExecuteOrder(OrderController orderController, VisualOrderExecutionParameters executionParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void AfterExecuteOrder(OrderController orderController, VisualOrderExecutionParameters executionParameters)
	{
		throw null;
	}

	protected abstract bool? OnGetFormationHasOrder(Formation formation);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetFormationHasOrder(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OrderState GetActiveState(OrderController orderController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private OrderState GetActiveStateAux(OrderController orderController)
	{
		throw null;
	}
}
