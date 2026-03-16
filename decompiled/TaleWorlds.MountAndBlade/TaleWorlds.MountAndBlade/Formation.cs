using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public sealed class Formation : IFormation
{
	private class AgentArrangementData : IFormationUnit
	{
		public IFormationArrangement Formation
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

		public int FormationFileIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public int FormationRankIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public IFormationUnit FollowedUnit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public bool IsShieldUsageEncouraged
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool IsPlayerUnit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AgentArrangementData(int index, IFormationArrangement arrangement)
		{
			throw null;
		}
	}

	public struct FormationIntegrityDataGroup
	{
		public Vec2 AverageVelocityExcludeFarAgents;

		public float DeviationOfPositionsExcludeFarAgents;

		public float MaxDeviationOfPositionExcludeFarAgents;

		public float AverageMaxUnlimitedSpeedExcludeFarAgents;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FormationIntegrityDataGroup(Vec2 averageVelocityExcludeFarAgents, float deviationOfPositionsExcludeFarAgents, float maxDeviationOfPositionExcludeFarAgents, float averageMaxUnlimitedSpeedExcludeFarAgents)
		{
			throw null;
		}
	}

	public class RetreatPositionCacheSystem
	{
		private List<(Vec2, WorldPosition)> _retreatPositionDistance;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RetreatPositionCacheSystem(int cacheCount)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WorldPosition GetRetreatPositionFromCache(Vec2 agentPosition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddNewPositionToCache(Vec2 agentPostion, WorldPosition retreatingPosition)
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_SecondaryLogicalClasses_003Ed__247 : IEnumerable<FormationClass>, IEnumerable, IEnumerator<FormationClass>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private FormationClass _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Formation _003C_003E4__this;

		private FormationClass _003CprimaryLogicalClass_003E5__2;

		private List<(FormationClass fClass, int count)>.Enumerator _003C_003E7__wrap2;

		FormationClass IEnumerator<FormationClass>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003Cget_SecondaryLogicalClasses_003Ed__247(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<FormationClass> IEnumerable<FormationClass>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_SecondaryPhysicalClasses_003Ed__254 : IEnumerable<FormationClass>, IEnumerable, IEnumerator<FormationClass>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private FormationClass _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Formation _003C_003E4__this;

		private FormationClass _003CprimaryPhysicalClass_003E5__2;

		FormationClass IEnumerator<FormationClass>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003Cget_SecondaryPhysicalClasses_003Ed__254(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<FormationClass> IEnumerable<FormationClass>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetUnitsWithoutDetachedOnes_003Ed__311 : IEnumerable<Agent>, IEnumerable, IEnumerator<Agent>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Agent _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Formation _003C_003E4__this;

		private List<IFormationUnit>.Enumerator _003C_003E7__wrap1;

		private int _003Ci_003E5__3;

		Agent IEnumerator<Agent>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetUnitsWithoutDetachedOnes_003Ed__311(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Agent> IEnumerable<Agent>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetUnavailableUnitPositionsAccordingToNewOrder_003Ed__420 : IEnumerable<(WorldPosition, Vec2)>, IEnumerable, IEnumerator<(WorldPosition, Vec2)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (WorldPosition, Vec2) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Formation simulationFormation;

		public Formation _003C_003E3__simulationFormation;

		private Formation formation;

		public Formation _003C_003E3__formation;

		private int unitSpacing;

		public int _003C_003E3__unitSpacing;

		private float width;

		public float _003C_003E3__width;

		private WorldPosition position;

		public WorldPosition _003C_003E3__position;

		private Vec2 direction;

		public Vec2 _003C_003E3__direction;

		private IFormationArrangement arrangement;

		public IFormationArrangement _003C_003E3__arrangement;

		private IEnumerator<Vec2> _003C_003E7__wrap1;

		(WorldPosition, Vec2) IEnumerator<(WorldPosition, Vec2)>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetUnavailableUnitPositionsAccordingToNewOrder_003Ed__420(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<(WorldPosition, Vec2)> IEnumerable<(WorldPosition, Vec2)>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	public const float AveragePositionCalculatePeriod = 0.1f;

	public const int MinimumUnitSpacing = 0;

	public const int RetreatPositionDistanceCacheCount = 2;

	public const float RetreatPositionCacheUseDistanceSquared = 400f;

	private static Formation _simulationFormationTemp;

	private static int _simulationFormationUniqueIdentifier;

	public readonly Team Team;

	public readonly int Index;

	public readonly FormationClass FormationIndex;

	public Banner Banner;

	public bool HasBeenPositioned;

	public Vec2? ReferencePosition;

	private bool _logicalClassNeedsUpdate;

	private FormationClass _logicalClass;

	private readonly int[] _logicalClassCounts;

	private Agent _playerOwner;

	private string _bannerCode;

	private bool _enforceNotSplittableByAI;

	private WorldPosition _orderPosition;

	private Vec2 _orderLocalAveragePosition;

	private bool _orderLocalAveragePositionIsDirty;

	private int _formationOrderDefensivenessFactor;

	private MovementOrder _movementOrder;

	private Timer _arrangementOrderTickOccasionallyTimer;

	private Agent _captain;

	private Vec2 _smoothedAverageUnitPosition;

	private MBList<IDetachment> _detachments;

	private IFormationArrangement _arrangement;

	private int[] _agentIndicesCache;

	private MBList<Agent> _detachedUnits;

	private int _undetachableNonPlayerUnitCount;

	private MBList<Agent> _looseDetachedUnits;

	private bool? _overridenHasAnyMountedUnit;

	private bool _isArrangementShapeChanged;

	private bool _hasPendingUnitPositions;

	private int _currentSpawnIndex;

	private int _desiredFileCount;

	private Formation _targetFormation;

	private Timer _cachedFormationIntegrityDataUpdateTimer;

	private Timer _cachedPositionAndVelocityUpdateTimer;

	private float _lastAveragePositionCacheTime;

	private Timer _cachedMovementSpeedUpdateTimer;

	private Formation _cachedClosestEnemyFormation;

	private Timer _cachedClosestEnemyFormationUpdateTimer;

	public RetreatPositionCacheSystem RetreatPositionCache
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

	public FormationClass RepresentativeClass
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

	public bool IsAIControlled
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

	public Vec2 Direction
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

	public int UnitSpacing
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

	public object OrderPositionLock
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

	public int CountOfUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CountOfDetachedUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CountOfUndetachableNonPlayerUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CountOfUnitsWithoutDetachedOnes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<IFormationUnit> UnitsWithoutLooseDetachedOnes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CountOfUnitsWithoutLooseDetachedOnes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CountOfDetachableNonPlayerUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 OrderPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 OrderGroundPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool OrderPositionIsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Depth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MinimumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float UnitDiameter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 CurrentDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 SmoothedAverageUnitPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Agent> LooseDetachedUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Agent> DetachedUnits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AttackEntityOrderSecondaryDetachment AttackEntityOrderSecondaryDetachment
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

	public FormationAI AI
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

	public Formation TargetFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public FormationQuerySystem QuerySystem
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

	public FormationIntegrityDataGroup CachedFormationIntegrityData
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

	public Vec2 CachedAveragePosition
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

	public WorldPosition CachedMedianPosition
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

	public Vec2 CachedCurrentVelocity
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

	public float CachedMovementSpeed
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

	public float CachedClosestEnemyFormationDistanceSquared
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

	public FormationQuerySystem CachedClosestEnemyFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<IDetachment> Detachments
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int? OverridenUnitCount
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

	public bool IsSpawning
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

	public bool IsAITickedAfterSplit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public bool HasPlayerControlledTroop
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

	public bool IsPlayerTroopInFormation
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

	public bool ContainsAgentVisuals
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public Agent PlayerOwner
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

	public string BannerCode
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

	public bool IsSplittableByAI
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAIOwned
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsConvenientForTransfer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 OrderLocalAveragePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FacingOrder FacingOrder
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

	public ArrangementOrder ArrangementOrder
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

	public FormOrder FormOrder
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

	public RidingOrder RidingOrder
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

	public FiringOrder FiringOrder
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

	private bool IsSimulationFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasAnyMountedUnit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public bool IsDeployment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationClass LogicalClass
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<FormationClass> SecondaryLogicalClasses
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_SecondaryLogicalClasses_003Ed__247))]
		get
		{
			throw null;
		}
	}

	public IFormationArrangement Arrangement
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

	public FormationClass PhysicalClass
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<FormationClass> SecondaryPhysicalClasses
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_SecondaryPhysicalClasses_003Ed__254))]
		get
		{
			throw null;
		}
	}

	public float Interval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CalculateHasSignificantNumberOfMounted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Distance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 CurrentPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent Captain
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

	public float MinimumDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLoose
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MinimumInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumInterval
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool PostponeCostlyOperations
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

	public event Action<Formation, Agent> OnUnitAdded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation, Agent> OnUnitRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation, Agent> OnUnitAttached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation> OnUnitCountChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation> OnUnitSpacingChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation> OnTick
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation> OnWidthChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation, MovementOrder.MovementOrderEnum> OnBeforeMovementOrderApplied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation, ArrangementOrder.ArrangementOrderEnum> OnAfterArrangementOrderApplied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Formation(Team team, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~Formation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IFormation.GetIsLocalPositionAvailable(Vec2 localPosition, Vec2? nearestAvailableUnitPositionLocal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IFormationUnit IFormation.GetClosestUnitTo(Vec2 localPosition, MBList<IFormationUnit> unitsWithSpaces, float? maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IFormationUnit IFormation.GetClosestUnitTo(IFormationUnit targetUnit, MBList<IFormationUnit> unitsWithSpaces, float? maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFormation.SetUnitToFollow(IFormationUnit unit, IFormationUnit toFollow, Vec2 vector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IFormation.BatchUnitPositions(MBArrayList<Vec2i> orderedPositionIndices, MBArrayList<Vec2> orderedLocalPositions, MBList2D<int> availabilityTable, MBList2D<WorldPosition> globalPositionTable, int fileCount, int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition CreateNewOrderWorldPosition(WorldPosition.WorldPositionEnforcedCache worldPositionEnforcedCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMovementOrder(MovementOrder input)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFacingOrder(FacingOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetArrangementOrder(ArrangementOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormOrder(FormOrder order, bool updateDesiredFileCount = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRidingOrder(RidingOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFiringOrder(FiringOrder order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetControlledByAI(bool isControlledByAI, bool enforceNotSplittableByAI = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetFormation(Formation targetFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetArrangementOrderTickTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositioning(WorldPosition? position = null, Vec2? direction = null, int? unitSpacing = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCountOfUnitsWithCondition(Func<Agent, bool> function)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ref readonly MovementOrder GetReadonlyMovementOrderReference()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetFirstUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCountOfUnitsBelongingToLogicalClass(FormationClass logicalClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCountOfUnitsBelongingToPhysicalClass(FormationClass physicalClass, bool excludeBannerBearers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnIndex(int value = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNextSpawnIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetUnitWithIndex(int unitIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetAveragePositionOfUnits(bool excludeDetachedUnits, bool excludePlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetMedianAgent(bool excludeDetachedUnits, bool excludePlayer, Vec2 averagePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent.UnderAttackType GetUnderAttackTypeOfUnits(float timeLimit = 3f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent.MovementBehaviorType GetMovementTypeOfUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetUnitsWithoutDetachedOnes_003Ed__311))]
	public IEnumerable<Agent> GetUnitsWithoutDetachedOnes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetWallDirectionOfRelativeFormationLocation(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetDirectionOfUnit(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition GetOrderPositionOfUnitAux(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementOrder.MovementStateEnum GetMovementState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetOrderPositionOfUnit(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetCurrentGlobalPositionOfUnit(Agent unit, bool blendWithOrderDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAverageMaximumMovementSpeedOfUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheMovementSpeedOfUnits()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheClosestEnemyFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheFormationIntegrityData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheAverageAndMedianPositionAndVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFormationPower()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFormationMeleeFightingPower()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal IDetachment GetDetachmentForDebug(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDetachment GetDetachmentOrDefault(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldFrame? GetDetachmentFrame(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetMiddleFrontUnitPositionOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<IFormationUnit> GetUnitsToPopWithReferencePosition(int count, Vec3 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<IFormationUnit> GetUnitsToPop(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<(WorldPosition, Vec2)> GetUnavailableUnitPositionsAccordingToNewOrder(Formation simulationFormation, in WorldPosition position, in Vec2 direction, float width, int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetUnitSpawnFrameWithIndex(int unitIndex, in WorldPosition formationPosition, in Vec2 formationDirection, float width, int unitCount, int unitSpacing, bool isMountedFormation, out WorldPosition? unitSpawnPosition, out Vec2? unitSpawnDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetUnitPositionWithIndexAccordingToNewOrder(Formation simulationFormation, int unitIndex, in WorldPosition formationPosition, in Vec2 formationDirection, float width, int unitSpacing, out WorldPosition? unitSpawnPosition, out Vec2? unitSpawnDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetUnitPositionWithIndexAccordingToNewOrder(Formation simulationFormation, int unitIndex, in WorldPosition formationPosition, in Vec2 formationDirection, float width, int unitSpacing, int overridenUnitCount, out WorldPosition? unitPosition, out Vec2? unitDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetUnitPositionWithIndexAccordingToNewOrder(Formation simulationFormation, int unitIndex, in WorldPosition formationPosition, in Vec2 formationDirection, float width, int unitSpacing, out WorldPosition? unitSpawnPosition, out Vec2? unitSpawnDirection, out float actualWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasUnitsWithCondition(Func<Agent, bool> function)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasUnitsWithCondition(Func<Agent, bool> function, out Agent result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyEnemyFormationsThatIsNotEmpty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasUnitWithConditionLimitedRandom(Func<Agent, bool> function, int startingIndex, int willBeCheckedUnitCount, out Agent resultAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int[] CollectUnitIndices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyActionOnEachUnit(Action<Agent> action, Agent ignoreAgent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyActionOnEachAttachedUnit(Action<Agent> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyActionOnEachDetachedUnit(Action<Agent> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyActionOnEachUnitViaBackupList(Action<Agent> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyActionOnEachUnit(Action<Agent, List<WorldPosition>> action, List<WorldPosition> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CountUnitsOnNavMeshIDMod10(int navMeshID, bool includeOnlyPositionedUnits)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentControllerChanged(Agent agent, AgentControllerType oldController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMassUnitTransferStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMassUnitTransferEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBatchUnitRemovalStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBatchUnitRemovalEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUnitAddedOrRemoved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentLostMount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationDispersed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUnitDetachmentChanged(Agent unit, bool isOldDetachmentLoose, bool isNewDetachmentLoose)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUndetachableNonPlayerUnitAdded(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUndetachableNonPlayerUnitRemoved(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetMovementOrderPositionCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<Formation> Split(int count = 2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransferUnits(Formation target, int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransferUnitsAux(Formation target, int unitCount, bool isPlayerOrder, bool useSelectivePop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public void DebugArrangements()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddUnit(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveUnit(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DetachUnit(Agent unit, bool isLoose)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachUnit(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchUnitLocations(Agent firstUnit, Agent secondUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceCalculateCaches()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHasPendingUnitPositions(bool hasPendingUnitPositions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void JoinDetachment(IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormAttackEntityDetachment(GameEntity targetEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeaveDetachment(IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisbandAttackEntityDetachment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Rearrange(IFormationArrangement arrangement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickForColumnArrangementInitialPositioning(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float CalculateFormationDirectionEnforcingFactorForRank(int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginSpawn(int unitCount, bool isMounted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsUnitDetachedForDebug(Agent unit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal IEnumerable<IFormationUnit> GetUnitsToPopWithPriorityFunction(int count, Func<Agent, int> priorityFunction, List<Agent> excludedHeroes, bool excludeBannerman)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void TransferUnitsWithPriorityFunction(Formation target, int unitCount, Func<Agent, int> priorityFunction, bool excludeBannerman, List<Agent> excludedAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IFormationUnit GetClosestUnitToAux(Vec2 position, MBReadOnlyList<IFormationUnit> unitsWithSpaces, float? maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CopyOrdersFrom(Formation target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickDetachments(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void TickOrderDebug()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void TickDebug(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUnitAttachedOrDetached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void DebugAssertDetachments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetOrderPosition(WorldPosition pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetHeroPointForCaptainSelection(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCaptainChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAgentDrivenPropertiesBasedOnOrderDefensiveness()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetForSimulation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryRelocatePlayerUnit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReapplyFormOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateDesiredWidth()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateLogicalClass()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SmoothAverageUnitPosition(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Arrangement_OnWidthChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Arrangement_OnShapeChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetLastSimulatedFormationsOccupationWidthIfLesserThanActualWidth(Formation simulationFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<WorldFrame> GetFormationFramesForBeforeFormationCreation(float width, int manCount, bool areMounted, WorldPosition spawnOrigin, Mat3 spawnRotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultUnitDiameter(bool isMounted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultMinimumUnitInterval(bool isMounted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultUnitInterval(bool isMounted, int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultMinimumUnitDistance(bool isMounted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultUnitDistance(bool isMounted, int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultFileWidth(int fileUnitCount, int unitSpacing, bool isMounted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultRankDepth(int rankUnitCount, int unitSpacing, bool isMounted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float InfantryInterval(int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CavalryInterval(int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float InfantryDistance(int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CavalryDistance(int unitSpacing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsDefenseRelatedAIDrivenComponent(DrivenProperty drivenProperty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetUnitPositionWithIndexAccordingToNewOrder(Formation simulationFormation, int unitIndex, in WorldPosition formationPosition, in Vec2 formationDirection, IFormationArrangement arrangement, float width, int unitSpacing, int unitCount, bool isMounted, int index, out WorldPosition? unitPosition, out Vec2? unitDirection, out float actualWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetUnavailableUnitPositionsAccordingToNewOrder_003Ed__420))]
	private static IEnumerable<(WorldPosition, Vec2)> GetUnavailableUnitPositionsAccordingToNewOrder(Formation formation, Formation simulationFormation, WorldPosition position, Vec2 direction, IFormationArrangement arrangement, float width, int unitSpacing)
	{
		throw null;
	}
}
