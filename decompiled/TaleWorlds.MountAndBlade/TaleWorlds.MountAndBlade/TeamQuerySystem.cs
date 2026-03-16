using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TeamQuerySystem
{
	public readonly Team Team;

	private readonly Mission _mission;

	private readonly QueryData<int> _memberCount;

	private readonly QueryData<WorldPosition> _medianPosition;

	private readonly QueryData<Vec2> _averagePosition;

	private readonly QueryData<Vec2> _averageEnemyPosition;

	private readonly QueryData<FormationQuerySystem> _medianTargetFormation;

	private readonly QueryData<WorldPosition> _medianTargetFormationPosition;

	private readonly QueryData<WorldPosition> _leftFlankEdgePosition;

	private readonly QueryData<WorldPosition> _rightFlankEdgePosition;

	private readonly QueryData<float> _infantryRatio;

	private readonly QueryData<float> _rangedRatio;

	private readonly QueryData<float> _cavalryRatio;

	private readonly QueryData<float> _rangedCavalryRatio;

	private readonly QueryData<int> _allyMemberCount;

	private readonly QueryData<int> _enemyMemberCount;

	private readonly QueryData<float> _allyInfantryRatio;

	private readonly QueryData<float> _allyRangedRatio;

	private readonly QueryData<float> _allyCavalryRatio;

	private readonly QueryData<float> _allyRangedCavalryRatio;

	private readonly QueryData<float> _enemyInfantryRatio;

	private readonly QueryData<float> _enemyRangedRatio;

	private readonly QueryData<float> _enemyCavalryRatio;

	private readonly QueryData<float> _enemyRangedCavalryRatio;

	private readonly QueryData<float> _remainingPowerRatio;

	private readonly QueryData<float> _teamPower;

	private readonly QueryData<float> _totalPowerRatio;

	private readonly QueryData<float> _insideWallsRatio;

	private IBattlePowerCalculationLogic _battlePowerLogic;

	private CasualtyHandler _casualtyHandler;

	private readonly QueryData<float> _maxUnderRangedAttackRatio;

	public int MemberCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WorldPosition MedianPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 AveragePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 AverageEnemyPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationQuerySystem MedianTargetFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WorldPosition MedianTargetFormationPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WorldPosition LeftFlankEdgePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WorldPosition RightFlankEdgePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float InfantryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RangedRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CavalryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RangedCavalryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int AllyUnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int EnemyUnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AllyInfantryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AllyRangedRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AllyCavalryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AllyRangedCavalryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float EnemyInfantryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float EnemyRangedRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float EnemyCavalryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float EnemyRangedCavalryRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RemainingPowerRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TeamPower
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TotalPowerRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float InsideWallsRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IBattlePowerCalculationLogic BattlePowerLogic
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CasualtyHandler CasualtyHandler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxUnderRangedAttackRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int DeathCount
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

	public int DeathByRangedCount
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

	public int AllyRangedUnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int AllCavalryUnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int EnemyRangedUnitCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
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
	public TeamQuerySystem(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterDeath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterDeathByRanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLocalAllyPower(Vec2 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLocalEnemyPower(Vec2 target)
	{
		throw null;
	}
}
