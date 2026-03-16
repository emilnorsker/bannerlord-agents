using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public struct RidingOrder
{
	public enum RidingOrderEnum
	{
		Free,
		Mount,
		Dismount
	}

	public readonly RidingOrderEnum OrderEnum;

	public static readonly RidingOrder RidingOrderFree;

	public static readonly RidingOrder RidingOrderMount;

	public static readonly RidingOrder RidingOrderDismount;

	public OrderType OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RidingOrder(RidingOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(RidingOrder r1, RidingOrder r2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(RidingOrder r1, RidingOrder r2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RidingOrder()
	{
		throw null;
	}
}
