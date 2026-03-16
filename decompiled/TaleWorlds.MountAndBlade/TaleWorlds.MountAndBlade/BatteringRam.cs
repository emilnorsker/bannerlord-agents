using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class BatteringRam : SiegeWeapon, IPathHolder, IPrimarySiegeWeapon, IMoveableSiegeWeapon, ISpawnable
{
	[DefineSynchedMissionObjectType(typeof(BatteringRam))]
	public struct BatteringRamRecord : ISynchedMissionObjectReadableRecord
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

	public enum RamState
	{
		Stable,
		Hitting,
		AfterHit,
		NumberOfStates
	}

	private string _pathEntityName;

	private const string PullStandingPointTag = "pull";

	private const string RightStandingPointTag = "right";

	private const string IdleAnimation = "batteringram_idle";

	private const string KnockAnimation = "batteringram_fire";

	private const string KnockSlowerAnimation = "batteringram_fire_weak";

	private const string KnockSlowestAnimation = "batteringram_fire_weakest";

	private const float KnockAnimationHitProgress = 0.5f;

	private const float KnockSlowerAnimationHitProgress = 0.56f;

	private const float KnockSlowestAnimationHitProgress = 0.58f;

	private string _gateTag;

	public bool GhostEntityMove;

	public float GhostEntitySpeedMultiplier;

	private string _sideTag;

	private FormationAI.BehaviorSide _weaponSide;

	public float WheelDiameter;

	public int GateNavMeshId;

	public int DisabledNavMeshID;

	private int _bridgeNavMeshID1;

	private int _bridgeNavMeshID2;

	private int _ditchNavMeshID1;

	private int _ditchNavMeshID2;

	private int _groundToBridgeNavMeshID1;

	private int _groundToBridgeNavMeshID2;

	public int NavMeshIdToDisableOnDestination;

	public float MinSpeed;

	public float MaxSpeed;

	public float DamageMultiplier;

	private int _usedPower;

	private float _storedPower;

	private List<StandingPoint> _pullStandingPoints;

	private List<MatrixFrame> _pullStandingPointLocalIKFrames;

	private GameEntity _ditchFillDebris;

	private GameEntity _batteringRamBody;

	private Skeleton _batteringRamBodySkeleton;

	private bool _isGhostMovementOn;

	private bool _isAllStandingPointsDisabled;

	private RamState _state;

	private CastleGate _gate;

	private bool _hasArrivedAtTarget;

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

	public FormationAI.BehaviorSide WeaponSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string PathEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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

	public RamState State
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

	public MissionObject TargetCastlePosition
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
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRegularMovementComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnDeploymentStateChanged(bool isDeployed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetInitialFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartHitAnimationWithProgress(int powerStage, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateHitAnimationWithProgress(int powerStage, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ActionIndexCache GetActionCodeForStandingPoint(StandingPoint standingPoint, int powerStage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void WriteToNetwork()
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
	private void SetUpGhostEntity()
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
	protected override float GetDistanceMultiplierOfWeapon(Vec3 weaponPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnedFromSpawner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssignParametersFromSpawner(string gateTag, string sideTag, int bridgeNavMeshID1, int bridgeNavMeshID2, int ditchNavMeshID1, int ditchNavMeshID2, int groundToBridgeNavMeshID1, int groundToBridgeNavMeshID2, string pathEntityName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterReadFromNetwork((BaseSynchedMissionObjectReadableRecord, ISynchedMissionObjectReadableRecord) synchedMissionObjectReadableRecord, bool allowVisibilityUpdate = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetNavmeshFaceIds(out List<int> navmeshFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BatteringRam()
	{
		throw null;
	}
}
