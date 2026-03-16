using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class TacticBreachWalls : TacticComponent
{
	private class BreachWallsProgressIndicators
	{
		public float StartingPowerRatio;

		public int InitialLaneCount;

		public int InitialUnitCount;

		private readonly float _insideFormationEffect;

		private readonly float _openLaneEffect;

		private readonly float _existingLaneEffect;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BreachWallsProgressIndicators(Team team, List<SiegeLane> lanes)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetRetreatThresholdRatio(List<SiegeLane> lanes, int insideFormationCount)
		{
			throw null;
		}
	}

	private enum TacticState
	{
		Unset,
		AssaultUnderRangedCover,
		TotalAttack,
		Retreating
	}

	public const float SameBehaviorFactor = 3f;

	public const float SameSideFactor = 5f;

	private const int ShockAssaultThresholdCount = 100;

	private readonly TeamAISiegeAttacker _teamAISiegeAttacker;

	private BreachWallsProgressIndicators _indicators;

	private List<Formation> _meleeFormations;

	private List<Formation> _rangedFormations;

	private int _laneCount;

	private List<SiegeLane> _cachedUsedSiegeLanes;

	private int _lanesInUse;

	private List<ArcherPosition> _cachedUsedArcherPositions;

	private TacticState _tacticState;

	private bool _isShockAssault;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticBreachWalls(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BalanceAssaultLanes(List<Formation> attackerFormations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldRetreat(List<SiegeLane> lanes, int insideFormationCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignMeleeFormationsToLanes(List<Formation> meleeFormationsSource, List<SiegeLane> currentLanes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WellRoundedAssault(ref List<SiegeLane> currentLanes, ref List<ArcherPosition> archerPositions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AllInAssault()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartTacticalRetreat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CheckAndSetAvailableFormationsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MergeFormationsIfLanesBecameUnavailable(ref List<SiegeLane> currentLanes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MergeFormationsIfArcherPositionsBecameUnavailable(ref List<ArcherPosition> currentArcherPositions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ManageFormationCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndChangeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<SiegeLane> DetermineCurrentLanes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<ArcherPosition> DetermineCurrentArcherPositions(List<SiegeLane> currentLanes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override float GetTacticWeight()
	{
		throw null;
	}
}
