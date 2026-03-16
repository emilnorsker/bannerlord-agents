using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;

namespace TaleWorlds.MountAndBlade.View.VisualOrders.OrderSets;

public class GenericVisualOrderSet : VisualOrderSet
{
	private readonly TextObject _name;

	private readonly string _stringId;

	private readonly bool _useActiveOrderForIconId;

	private readonly bool _useActiveOrderForName;

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
	public GenericVisualOrderSet(string stringId, TextObject name, bool useActiveOrderForIconId, bool useActiveOrderForName)
	{
		throw null;
	}
}
