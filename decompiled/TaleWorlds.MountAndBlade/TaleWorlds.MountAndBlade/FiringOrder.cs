using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public struct FiringOrder
{
	public enum RangedWeaponUsageOrderEnum
	{
		FireAtWill,
		HoldYourFire
	}

	public readonly RangedWeaponUsageOrderEnum OrderEnum;

	public static readonly FiringOrder FiringOrderFireAtWill;

	public static readonly FiringOrder FiringOrderHoldYourFire;

	public OrderType OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FiringOrder(RangedWeaponUsageOrderEnum orderEnum)
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
	public static bool operator !=(FiringOrder f1, FiringOrder f2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(FiringOrder f1, FiringOrder f2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FiringOrder()
	{
		throw null;
	}
}
