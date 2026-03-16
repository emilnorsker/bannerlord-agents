using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class SquareFormation : LineFormation
{
	private enum Side
	{
		Front,
		Right,
		Rear,
		Left
	}

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

	private int UnitCountOfOuterSide
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

	private new float Distance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SquareFormation(IFormation owner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IFormationArrangement Clone(IFormation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DeepCopyFrom(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormFromBorderSideWidth(float borderSideWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormFromBorderUnitCountPerSide(int unitCountPerSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUnitsPerSideFromRankCount(int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static int GetMaximumRankCount(int unitCount, out int minimumFlankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormFromRankCount(int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Side GetSideOfUnitPosition(int fileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Side? GetSideOfUnitPosition(int fileIndex, int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2 GetLocalPositionOfUnitAux(int fileIndex, int rankIndex, float usedInterval)
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
	private Side GetSideOfLocalPosition(Vec2 localPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool TryGetUnitPositionIndexFromLocalPosition(Vec2 localPosition, out int fileIndex, out int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ShiftFileIndex(int fileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int UnshiftFileIndex(int shiftedFileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static float GetSideWidthFromUnitCount(int sideUnitCount, float interval, float unitDiameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TurnBackwards()
	{
		throw null;
	}
}
