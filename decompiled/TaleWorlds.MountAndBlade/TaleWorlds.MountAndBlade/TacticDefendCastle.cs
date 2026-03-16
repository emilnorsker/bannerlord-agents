using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class TacticDefendCastle : TacticComponent
{
	public enum TacticState
	{
		ProperDefense,
		DesperateDefense,
		RetreatToKeep,
		SallyOut
	}

	private const float InfantrySallyOutEffectiveness = 1f;

	private const float RangedSallyOutEffectiveness = 0.3f;

	private const float CavalrySallyOutEffectiveness = 2f;

	private const float SallyOutDecisionPenalty = 3f;

	private readonly TeamAISiegeDefender _teamAISiegeDefender;

	private readonly List<MissionObject> _castleKeyPositions;

	private readonly List<SiegeLane> _lanes;

	private float _startingPowerRatio;

	private float _meleeDefenderPower;

	private float _laneThreatCapacity;

	private float _initialLaneDefensePowerRatio;

	private bool _isSallyingOut;

	private bool _areRangedNeededForLaneDefense;

	private bool _isTacticFailing;

	private bool _areSiegeWeaponsAbandoned;

	private Formation _invadingEnemyFormation;

	private Formation _emergencyFormation;

	private List<Formation> _meleeFormations;

	private List<Formation> _laneDefendingFormations;

	private List<Formation> _rangedFormations;

	private int _laneCount;

	public TacticState CurrentTacticState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticDefendCastle(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetFormationSallyOutPower(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Formation GetStrongestSallyOutFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MustRetreatToCastle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsSallyOutApplicable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BalanceLaneDefenders(List<Formation> defenderFormations, out bool transferOccurred)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArcherShiftAround(List<Formation> p_RangedFormations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CheckAndSetAvailableFormationsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetRequiredMeleeDefenderCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ManageFormationCounts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void StopUsingAllMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopUsingStrategicAreas()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartRetreatToKeep()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DistributeRangedFormations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ManageGatesForSallyingOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartSallyOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CarryOutDefense(List<SiegeLane> defendedLanes, List<SiegeLane> lanesToBeRetaken, bool isEnemyInside, bool doRangedJoinMelee, out bool hasTransferOccurred)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndChangeState()
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
