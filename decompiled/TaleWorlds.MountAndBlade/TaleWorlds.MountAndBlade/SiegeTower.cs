using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class SiegeTower : SiegeWeapon, IPathHolder, IPrimarySiegeWeapon, IMoveableSiegeWeapon, ISpawnable
{
	[DefineSynchedMissionObjectType(typeof(SiegeTower))]
	public struct SiegeTowerRecord : ISynchedMissionObjectReadableRecord
	{
		public bool HasArrivedAtTarget
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

		public float TotalDistanceTraveled
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

	public enum GateState
	{
		Closed,
		Open,
		GateFalling,
		GateFallingWallDestroyed,
		NumberOfStates
	}

	private const int LeftLadderNavMeshIdLocal = 5;

	private const int MiddleLadderNavMeshIdLocal = 6;

	private const int RightLadderNavMeshIdLocal = 7;

	private const string BreakableWallTag = "breakable_wall";

	private const string DestroyedWallTag = "destroyed";

	private const string NonDestroyedWallTag = "non_destroyed";

	private const string LadderTag = "ladder";

	private const string BattlementDestroyedParticleTag = "particle_spawnpoint";

	public string GateTag;

	public string GateOpenTag;

	public string HandleTag;

	public string GateHandleIdleAnimation;

	private int _gateHandleIdleAnimationIndex;

	public string GateTrembleAnimation;

	private int _gateTrembleAnimationIndex;

	public string BattlementDestroyedParticle;

	private string _targetWallSegmentTag;

	public bool GhostEntityMove;

	public float GhostEntitySpeedMultiplier;

	private string _sideTag;

	private bool _hasLadders;

	public float WheelDiameter;

	public float MinSpeed;

	public float MaxSpeed;

	public int GateNavMeshId;

	public int NavMeshIdToDisableOnDestination;

	private int _soilNavMeshID1;

	private int _soilNavMeshID2;

	private int _ditchNavMeshID1;

	private int _ditchNavMeshID2;

	private int _groundToSoilNavMeshID1;

	private int _groundToSoilNavMeshID2;

	private int _soilGenericNavMeshID;

	private int _groundGenericNavMeshID;

	public string BarrierTagToRemove;

	private List<GameEntity> _aiBarriers;

	private bool _isGhostMovementOn;

	private bool _hasArrivedAtTarget;

	private GateState _state;

	private SynchedMissionObject _gateObject;

	private SynchedMissionObject _handleObject;

	private SoundEvent _gateOpenSound;

	private int _gateOpenSoundIndex;

	private Mat3 _openStateRotation;

	private Mat3 _closedStateRotation;

	private float _fallAngularSpeed;

	private GameEntity _cleanState;

	private GameEntity _destroyedWallEntity;

	private GameEntity _nonDestroyedWallEntity;

	private GameEntity _battlementDestroyedParticle;

	private StandingPoint _gateStandingPoint;

	private MatrixFrame _gateStandingPointLocalIKFrame;

	private SynchedMissionObject _ditchFillDebris;

	private List<LadderQueueManager> _queueManagers;

	private WallSegment _targetWallSegment;

	private List<SiegeLadder> _sameSideSiegeLadders;

	public MissionObject TargetCastlePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private WeakGameEntity CleanState
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

	public string PathEntity
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

	public bool EditorGhostEntityMove
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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

	public SiegeWeaponMovementComponent MovementComponent
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

	public bool HasArrivedAtTarget
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

	public GateState State
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

	public override bool IsDeactivated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasCompletedAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGateNavMeshId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<int> CollectGetDifficultNavmeshIDs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<int> CollectGetDifficultNavmeshIDsForAttackers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<int> CollectGetDifficultNavmeshIDsForDefenders()
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
	public override OrderType GetOrder(BattleSideEnum side)
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
	public override void Disable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override SiegeEngineType GetSiegeEngineType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnDeploymentStateChanged(bool isDeployed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AttachDynamicNavmeshToEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override WeakGameEntity GetEntityToAttachNavMeshFaces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetAbilityOfFaces(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDistanceMultiplierOfWeapon(Vec3 weaponPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsNavmeshOnThisTowerAttackerDifficultNavmeshIDs(int testedNavmeshID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsAgentOnInconvenientNavmesh(Agent agent, StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
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
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDestroyed(DestructableComponent destroyedComponent, Agent destroyerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HighlightPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchGhostEntityMovementMode(bool isGhostEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetInitialFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSiegeTowerGateStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRegularMovementComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetUpGhostEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateGhostEntity()
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
	public void AssignParametersFromSpawner(string pathEntityName, string targetWallSegment, string sideTag, int soilNavMeshID1, int soilNavMeshID2, int ditchNavMeshID1, int ditchNavMeshID2, int groundToSoilNavMeshID1, int groundToSoilNavMeshID2, int soilGenericNavMeshID, int groundGenericNavMeshID, Mat3 openStateRotation, string barrierTagToRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetNavmeshFaceIds(out List<int> navmeshFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationFrameChanged(Agent agent, bool hasFrame, WorldPosition frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeTower()
	{
		throw null;
	}
}
