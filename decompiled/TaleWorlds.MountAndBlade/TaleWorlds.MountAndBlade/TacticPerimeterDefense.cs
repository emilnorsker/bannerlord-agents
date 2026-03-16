using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TacticPerimeterDefense : TacticComponent
{
	private class DefenseFront
	{
		public Formation MeleeFormation;

		public Formation RangedFormation;

		public EnemyCluster MatchedEnemyCluster;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DefenseFront(EnemyCluster matchedEnemyCluster, Formation meleeFormation)
		{
			throw null;
		}
	}

	private class EnemyCluster
	{
		private readonly MBList<Formation> _enemyFormations;

		private float _totalPower;

		public Vec2 AggregatePosition
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

		public WorldPosition MedianAggregatePosition
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

		public MBReadOnlyList<Formation> EnemyFormations
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateClusterData()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddToCluster(Formation formation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveFromCluster(Formation formation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateMedianPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EnemyCluster()
		{
			throw null;
		}
	}

	private WorldPosition _defendPosition;

	private readonly List<EnemyCluster> _enemyClusters;

	private readonly List<DefenseFront> _defenseFronts;

	private const float RetreatThresholdValue = 2f;

	private List<Formation> _meleeFormations;

	private List<Formation> _rangedFormations;

	private bool _isRetreatingToKeep;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticPerimeterDefense(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineEnemyClusters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MustRetreatToCastle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartRetreatToKeep()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndChangeState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangeDefenseFronts()
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
