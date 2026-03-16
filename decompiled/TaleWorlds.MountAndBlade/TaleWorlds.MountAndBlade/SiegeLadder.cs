using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class SiegeLadder : SiegeWeapon, IPrimarySiegeWeapon, IOrderableWithInteractionArea, IOrderable, ISpawnable
{
	[DefineSynchedMissionObjectType(typeof(SiegeLadder))]
	public struct SiegeLadderRecord : ISynchedMissionObjectReadableRecord
	{
		public bool IsStateLand
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

		public int State
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

		public int AnimationState
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

		public float FallAngularSpeed
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

		public MatrixFrame LadderFrame
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

		public bool HasAnimation
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

		public int LadderAnimationIndex
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

		public float LadderAnimationProgress
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
		public bool ReadFromNetwork(ref bool bufferReadValid)
		{
			throw null;
		}
	}

	public enum LadderState
	{
		OnLand,
		FallToLand,
		BeingRaised,
		BeingRaisedStartFromGround,
		BeingRaisedStopped,
		OnWall,
		FallToWall,
		BeingPushedBack,
		BeingPushedBackStartFromWall,
		BeingPushedBackStopped,
		NumberOfStates
	}

	public enum LadderAnimationState
	{
		Static,
		Animated,
		PhysicallyDynamic,
		NumberOfStates
	}

	public const float ClimbingLimitRadian = -0.20135832f;

	public const float ClimbingLimitDegree = -11.536982f;

	public const float AutomaticUseActivationRange = 20f;

	public string AttackerTag;

	public string DefenderTag;

	public string downStateEntityTag;

	public string IdleAnimation;

	public int _idleAnimationIndex;

	public string RaiseAnimation;

	public string RaiseAnimationWithoutRootBone;

	public int _raiseAnimationWithoutRootBoneIndex;

	public string PushBackAnimation;

	public int _pushBackAnimationIndex;

	public string PushBackAnimationWithoutRootBone;

	public int _pushBackAnimationWithoutRootBoneIndex;

	public string TrembleWallHeavyAnimation;

	public string TrembleWallLightAnimation;

	public string TrembleGroundAnimation;

	public string RightStandingPointTag;

	public string LeftStandingPointTag;

	public string FrontStandingPointTag;

	public string PushForkItemID;

	public string upStateEntityTag;

	public string BodyTag;

	public string CollisionBodyTag;

	public string InitialWaitPositionTag;

	private string _targetWallSegmentTag;

	public float LadderPushTreshold;

	public float LadderPushTresholdForOneAgent;

	private WallSegment _targetWallSegment;

	private string _sideTag;

	private int _trembleWallLightAnimationIndex;

	public string BarrierTagToRemove;

	private int _trembleGroundAnimationIndex;

	public LadderState initialState;

	private int _trembleWallHeavyAnimationIndex;

	public string IndestructibleMerlonsTag;

	private int _raiseAnimationIndex;

	private bool _isNavigationMeshDisabled;

	private bool _isLadderPhysicsDisabled;

	private bool _isLadderCollisionPhysicsDisabled;

	private Timer _tickOccasionallyTimer;

	private float _upStateRotationRadian;

	private float _downStateRotationRadian;

	private float _fallAngularSpeed;

	private MatrixFrame _ladderDownFrame;

	private MatrixFrame _ladderUpFrame;

	private LadderAnimationState _animationState;

	private int _currentActionAgentCount;

	private LadderState _state;

	private List<GameEntity> _aiBarriers;

	private List<StandingPoint> _attackerStandingPoints;

	private StandingPointWithWeaponRequirement _pushingWithForkStandingPoint;

	private StandingPointWithWeaponRequirement _forkPickUpStandingPoint;

	private ItemObject _forkItem;

	private MatrixFrame[] _attackerStandingPointLocalIKFrames;

	private MatrixFrame _ladderInitialGlobalFrame;

	private SynchedMissionObject _ladderParticleObject;

	private SynchedMissionObject _ladderBodyObject;

	private SynchedMissionObject _ladderCollisionBodyObject;

	private SynchedMissionObject _ladderObject;

	private Skeleton _ladderSkeleton;

	private float _lastDotProductOfAnimationAndTargetRotation;

	private float _turningAngle;

	private LadderQueueManager _queueManagerForAttackers;

	private LadderQueueManager _queueManagerForDefenders;

	private Timer _forkReappearingTimer;

	private float _forkReappearingDelay;

	private SynchedMissionObject _forkEntity;

	public GameEntity InitialWaitPosition
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

	public int OnWallNavMeshId
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

	public MissionObject TargetCastlePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationAI.BehaviorSide WeaponSide
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

	public float SiegeWeaponPriority
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int OverTheWallNavMeshID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public LadderState State
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

	public bool HoldLadders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool SendLadders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override SiegeEngineType GetSiegeEngineType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCurrentLadderAngularSpeed(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLadderStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetVisibilityOfAIBarriers(bool visibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override OrderType GetOrder(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateNavigationAndPhysics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasCompletedAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ActionIndexCache GetActionCodeToUseForStandingPoint(StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForBattleSide(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickRare()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpStateVisibility(bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FlushQueueManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FlushNeighborQueueManagers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanLadderBePushed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InformNeighborQueueManagers(LadderQueueManager ladderQueueManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetAbilityOfFaces(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WriteToNetwork()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IOrderableWithInteractionArea.IsPointInsideInteractionArea(Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TargetFlags GetTargetFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTargetValue(List<Vec3> weaponPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDistanceMultiplierOfWeapon(Vec3 weaponPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override StandingPoint GetSuitableStandingPointFor(BattleSideEnum side, Agent agent = null, List<Agent> agents = null, List<(Agent, float)> agentValuePairs = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnedFromSpawner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterReadFromNetwork((BaseSynchedMissionObjectReadableRecord, ISynchedMissionObjectReadableRecord) synchedMissionObjectReadableRecord, bool allowVisibilityUpdate = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssignParametersFromSpawner(string sideTag, string targetWallSegment, int onWallNavMeshId, float downStateRotationRadian, float upperStateRotationRadian, string barrierTagToRemove, string indestructibleMerlonsTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetNavmeshFaceIds(out List<int> navmeshFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationFrameChanged(Agent agent, bool hasFrame, WorldPosition position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeLadder()
	{
		throw null;
	}
}
