using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class CircularFormation : LineFormation
{
	public override float Width
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

	public override float Depth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float Diameter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float Radius
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float MinimumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float MaximumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int MaxRank
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CircularFormation(IFormation owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IFormationArrangement Clone(IFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDistanceFromCenterOfRank(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsDeepenApplicable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsNarrowApplicable(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetUnitCountOfRank(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsUnitPositionRestrained(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void MakeRestrainedPositionsUnavailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Vec2 GetLocalDirectionOfUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec2? GetLocalDirectionOfUnitOrDefault(IFormationUnit unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Vec2 GetLocalPositionOfUnit(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Vec2 GetLocalPositionOfUnitWithAdjustment(int fileIndex, int rankIndex, float distanceBetweenAgentsAdjustment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool TryGetUnitPositionIndexFromLocalPosition(Vec2 localPosition, out int fileIndex, out int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected int GetCurrentMaximumRankCount(int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCircumferenceFromRankCount(int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormFromCircumference(float circumference)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetCircumferenceAux(int unitCount, int rankCount, float radialInterval, float distanceInterval)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetUnitCountAux(float circumference, int rankCount, float radialInterval, float distanceInterval)
	{
		throw null;
	}
}
