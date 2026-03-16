using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class FormationQuerySystem
{
	public readonly Formation Formation;

	private readonly QueryData<float> _formationPower;

	private readonly QueryData<float> _formationMeleeFightingPower;

	private readonly QueryData<Vec2> _estimatedDirection;

	private readonly QueryData<float> _estimatedInterval;

	private readonly QueryData<Vec2> _averageAllyPosition;

	private readonly QueryData<float> _idealAverageDisplacement;

	private readonly QueryData<MBList<Agent>> _localAllyUnits;

	private readonly QueryData<MBList<Agent>> _localEnemyUnits;

	private readonly QueryData<FormationClass> _mainClass;

	private readonly QueryData<float> _infantryUnitRatio;

	private readonly QueryData<float> _hasShieldUnitRatio;

	private readonly QueryData<float> _hasThrowingUnitRatio;

	private readonly QueryData<float> _rangedUnitRatio;

	private readonly QueryData<int> _insideCastleUnitCountIncludingUnpositioned;

	private readonly QueryData<int> _insideCastleUnitCountPositioned;

	private readonly QueryData<float> _cavalryUnitRatio;

	private readonly QueryData<float> _rangedCavalryUnitRatio;

	private readonly QueryData<bool> _isMeleeFormation;

	private readonly QueryData<bool> _isInfantryFormation;

	private readonly QueryData<bool> _hasShield;

	private readonly QueryData<bool> _hasThrowing;

	private readonly QueryData<bool> _isRangedFormation;

	private readonly QueryData<bool> _isCavalryFormation;

	private readonly QueryData<bool> _isRangedCavalryFormation;

	private readonly QueryData<float> _movementSpeedMaximum;

	private readonly QueryData<float> _maximumMissileRange;

	private readonly QueryData<float> _missileRangeAdjusted;

	private readonly QueryData<float> _localInfantryUnitRatio;

	private readonly QueryData<float> _localRangedUnitRatio;

	private readonly QueryData<float> _localCavalryUnitRatio;

	private readonly QueryData<float> _localRangedCavalryUnitRatio;

	private readonly QueryData<float> _localAllyPower;

	private readonly QueryData<float> _localEnemyPower;

	private readonly QueryData<float> _localPowerRatio;

	private readonly QueryData<float> _casualtyRatio;

	private readonly QueryData<bool> _isUnderRangedAttack;

	private readonly QueryData<float> _underRangedAttackRatio;

	private readonly QueryData<float> _makingRangedAttackRatio;

	private readonly QueryData<Formation> _mainFormation;

	private readonly QueryData<float> _mainFormationReliabilityFactor;

	private readonly QueryData<Vec2> _weightedAverageEnemyPosition;

	private readonly QueryData<Agent> _closestEnemyAgent;

	private readonly QueryData<Formation> _closestSignificantlyLargeEnemyFormation;

	private readonly QueryData<Formation> _fastestSignificantlyLargeEnemyFormation;

	private readonly QueryData<Vec2> _highGroundCloseToForeseenBattleGround;

	public TeamQuerySystem Team
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FormationPower
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FormationPowerReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FormationMeleeFightingPower
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FormationMeleeFightingPowerReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 EstimatedDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 EstimatedDirectionReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float EstimatedInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float EstimatedIntervalReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 AverageAllyPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 AverageAllyPositionReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float IdealAverageDisplacement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float IdealAverageDisplacementReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBList<Agent> LocalAllyUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBList<Agent> LocalAllyUnitsReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBList<Agent> LocalEnemyUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBList<Agent> LocalEnemyUnitsReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationClass MainClass
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationClass MainClassReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float InfantryUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float InfantryUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float HasShieldUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float HasShieldUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float HasThrowingUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float HasThrowingUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RangedUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RangedUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int InsideCastleUnitCountIncludingUnpositioned
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int InsideCastleUnitCountIncludingUnpositionedReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int InsideCastleUnitCountPositioned
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int InsideCastleUnitCountPositionedReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CavalryUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CavalryUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RangedCavalryUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RangedCavalryUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMeleeFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMeleeFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInfantryFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInfantryFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasShield
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasShieldReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasThrowing
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasThrowingReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRangedFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRangedFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsCavalryFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsCavalryFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRangedCavalryFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRangedCavalryFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MovementSpeedMaximum
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MovementSpeedMaximumReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumMissileRange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumMissileRangeReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MissileRangeAdjusted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MissileRangeAdjustedReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalInfantryUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalInfantryUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalRangedUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalRangedUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalCavalryUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalCavalryUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalRangedCavalryUnitRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalRangedCavalryUnitRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalAllyPower
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalAllyPowerReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalEnemyPower
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalEnemyPowerReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalPowerRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalPowerRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CasualtyRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CasualtyRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUnderRangedAttack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUnderRangedAttackReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float UnderRangedAttackRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float UnderRangedAttackRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MakingRangedAttackRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MakingRangedAttackRatioReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Formation MainFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Formation MainFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MainFormationReliabilityFactor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MainFormationReliabilityFactorReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 WeightedAverageEnemyPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 WeightedAverageEnemyPositionReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent ClosestEnemyAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent ClosestEnemyAgentReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationQuerySystem ClosestSignificantlyLargeEnemyFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationQuerySystem ClosestSignificantlyLargeEnemyFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationQuerySystem FastestSignificantlyLargeEnemyFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationQuerySystem FastestSignificantlyLargeEnemyFormationReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 HighGroundCloseToForeseenBattleGround
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 HighGroundCloseToForeseenBattleGroundReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationQuerySystem(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EvaluateAllPreliminaryQueryData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceExpireCavalryUnitRatio()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Expire()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExpireAfterUnitAddRemove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTelemetryScopeNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetClassWeightedFactor(float infantryWeight, float rangedWeight, float cavalryWeight, float rangedCavalryWeight)
	{
		throw null;
	}
}
