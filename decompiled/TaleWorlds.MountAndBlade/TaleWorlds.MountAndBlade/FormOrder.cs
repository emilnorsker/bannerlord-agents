using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public struct FormOrder
{
	public enum FormOrderEnum
	{
		Deep,
		Wide,
		Wider,
		Custom
	}

	private float _customFlankWidth;

	public readonly FormOrderEnum OrderEnum;

	public static readonly FormOrder FormOrderDeep;

	public static readonly FormOrder FormOrderWide;

	public static readonly FormOrder FormOrderWider;

	public float CustomFlankWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public OrderType OrderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FormOrder(FormOrderEnum orderEnum, float customFlankWidth = -1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FormOrder FormOrderCustom(float customWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnApply(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetUnitCountOf(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool OnApplyToCustomArrangement(Formation formation, IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnApplyToArrangement(Formation formation, IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int? GetMaxFileCount(int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int? GetMaxFileCountStatic(FormOrderEnum order, int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetRankVerticalFormFileCount(IFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int? GetMaxFileCountAux(FormOrderEnum order, int unitCount)
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
	public static bool operator !=(FormOrder f1, FormOrder f2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(FormOrder f1, FormOrder f2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FormOrder()
	{
		throw null;
	}
}
