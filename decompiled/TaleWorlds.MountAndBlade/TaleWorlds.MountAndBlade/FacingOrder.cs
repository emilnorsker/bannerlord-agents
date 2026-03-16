using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct FacingOrder
{
	public enum FacingOrderEnum
	{
		LookAtDirection,
		LookAtEnemy
	}

	public readonly FacingOrderEnum OrderEnum;

	private readonly Vec2 _lookAtDirection;

	public static readonly FacingOrder FacingOrderLookAtEnemy;

	public OrderType OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FacingOrder FacingOrderLookAtDirection(Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FacingOrder(FacingOrderEnum orderEnum, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FacingOrder(FacingOrderEnum orderEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetDirectionAux(Formation f, Agent targetAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetDirection(Formation f, Agent targetAgent = null)
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
	public static bool operator !=(FacingOrder f1, FacingOrder f2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(FacingOrder f1, FacingOrder f2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FacingOrder()
	{
		throw null;
	}
}
