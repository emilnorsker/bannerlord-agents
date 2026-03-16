using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public abstract class RangedSiegeWeapon : SiegeWeapon
{
	[DefineSynchedMissionObjectType(typeof(RangedSiegeWeapon))]
	public struct RangedSiegeWeaponRecord : ISynchedMissionObjectReadableRecord
	{
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

		public float TargetDirection
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

		public float TargetReleaseAngle
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

		public int AmmoCount
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

		public int ProjectileIndex
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

	public enum WeaponState
	{
		Invalid = -1,
		Idle,
		WaitingBeforeProjectileLeaving,
		Shooting,
		WaitingAfterShooting,
		WaitingBeforeReloading,
		LoadingAmmo,
		WaitingBeforeIdle,
		Reloading,
		ReloadingPaused,
		NumberOfStates
	}

	public enum FiringFocus
	{
		Troops,
		Walls,
		RangedSiegeWeapons,
		PrimarySiegeWeapons
	}

	public enum CameraState
	{
		StickToWeapon,
		DontMove,
		MoveDownToReload,
		RememberLastShotDirection,
		FreeMove,
		ApproachToCamera
	}

	public enum ForceUseState
	{
		NotForced,
		ForcefullyWatched,
		ForcefullyUsed
	}

	public delegate void OnSiegeWeaponReloadDone();

	private const float DefaultMissileRadius = 0.01f;

	public const float DefaultDirectionRestriction = System.MathF.PI * 2f / 3f;

	public const string CanGoAmmoPickupTag = "can_pick_up_ammo";

	public const string DontApplySidePenaltyTag = "no_ammo_pick_up_penalty";

	public const string ReloadTag = "reload";

	public const string AmmoLoadTag = "ammoload";

	public const string CameraHolderTag = "cameraHolder";

	public const string ProjectileTag = "projectile";

	public string MissileItemID;

	protected bool UsesMouseForAiming;

	[EditableScriptComponentVariable(true, "")]
	protected int MultipleProjectileCount;

	private WeaponState _state;

	public FiringFocus Focus;

	private int _projectileIndex;

	protected GameEntity MissileStartingPositionEntityForSimulation;

	protected Skeleton[] Skeletons;

	protected SynchedMissionObject[] SkeletonOwnerObjects;

	protected string[] SkeletonNames;

	protected string[] FireAnimations;

	protected string[] SetUpAnimations;

	protected int[] FireAnimationIndices;

	protected int[] SetUpAnimationIndices;

	protected SynchedMissionObject RotationObject;

	private MatrixFrame _rotationObjectInitialFrame;

	protected SoundEvent MoveSound;

	protected SoundEvent ReloadSound;

	protected int MoveSoundIndex;

	protected int ReloadSoundIndex;

	protected int FireSoundIndex;

	protected ItemObject OriginalMissileItem;

	protected WeaponStatsData OriginalMissileWeaponStatsDataForTargeting;

	private ItemObject _loadedMissileItem;

	protected List<StandingPoint> CanPickUpAmmoStandingPoints;

	protected List<StandingPoint> ReloadStandingPoints;

	protected StandingPointWithWeaponRequirement LoadAmmoStandingPoint;

	protected Dictionary<StandingPoint, float> PilotReservePriorityValues;

	protected Agent ReloaderAgent;

	protected StandingPoint ReloaderAgentOriginalPoint;

	protected bool AttackClickWillReload;

	protected bool WeaponNeedsClickToReload;

	protected float FinalReloadSpeed;

	protected float BaseReloadSpeed;

	public int StartingAmmoCount;

	protected int CurrentAmmo;

	protected float TargetDirection;

	protected float TargetReleaseAngle;

	protected float CameraDirection;

	protected float CameraReleaseAngle;

	protected float ReloadTargetReleaseAngle;

	private MatrixFrame _cameraHolderInitialFrame;

	protected float MaxRotateSpeed;

	private CameraState _cameraState;

	private bool _inputGiven;

	protected float DontMoveTimer;

	private float _inputX;

	private float _inputY;

	private bool _exactInputGiven;

	private float _inputTargetX;

	private float _inputTargetY;

	private Vec3 _ammoPickupCenter;

	private float _lastSyncedDirection;

	private float _lastSyncedReleaseAngle;

	private float _syncTimer;

	public float TopReleaseAngleRestriction;

	public float BottomReleaseAngleRestriction;

	protected float CurrentDirection;

	protected float CurrentReleaseAngle;

	protected float ReleaseAngleRestrictionCenter;

	protected float ReleaseAngleRestrictionAngle;

	private float _animationTimeElapsed;

	protected float TimeGapBetweenShootingEndAndReloadingStart;

	protected float TimeGapBetweenShootActionAndProjectileLeaving;

	private int _currentReloaderCount;

	protected Agent LastShooterAgent;

	private float _lastCanPickUpAmmoStandingPointsSortedAngle;

	protected BattleSideEnum DefaultSide;

	private bool _aiRequestsShoot;

	private bool _aiRequestsManualReload;

	private bool _hasFrameChangedInPreviousFrame;

	private string _lastLoadedMissileItemId;

	private float _projectileRadiusCached;

	public virtual string MultipleFireProjectileId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string MultipleFireProjectileFlyingId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string MultipleProjectileId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string MultipleProjectileFlyingId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string SingleFireProjectileId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string SingleFireProjectileFlyingId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string SingleProjectileId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual string SingleProjectileFlyingId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WeaponState State
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

	protected virtual float MaximumBallisticError
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected abstract float ShootingSpeed { get; }

	public virtual Vec3 CanShootAtPointCheckingOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameEntity CameraHolder
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

	protected SynchedMissionObject Projectile
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

	protected Vec3 MissileStartingGlobalPositionForSimulation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected string SkeletonName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	protected string FireAnimation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	protected string SetUpAnimation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	protected int FireAnimationIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	protected int SetUpAnimationIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	protected ItemObject LoadedMissileItem
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

	protected virtual bool WeaponMovesDownToReload
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int AmmoCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected set
		{
			throw null;
		}
	}

	protected virtual bool HasAmmo
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

	public virtual float DirectionRestriction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual float HorizontalAimSensitivity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual float VerticalAimSensitivity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected virtual float ReloadSpeedMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool PlayerForceUse
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

	protected virtual Vec3 ShootingDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual Vec3 ProjectileEntityCurrentGlobalPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override BattleSideEnum Side
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<RangedSiegeWeapon, Agent> OnAgentLoadsMachine
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

	public event OnSiegeWeaponReloadDone OnReloadDone
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

	protected abstract void RegisterAnimationParameters();

	protected abstract void GetSoundEventIndices();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void ConsumeAmmo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetAmmo(int ammoLeft)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void SetStartAmmo(int ammoLeft)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void CheckAmmo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ChangeProjectileEntityServer(Agent loadingAgent, string missileItemID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeProjectileEntityClient(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DetermineDefaultBattleSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SortCanPickUpAmmoStandingPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitAnimations()
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
	protected virtual void UpdateProjectilePosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsInRangeToCheckAlternativePoints(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override StandingPoint GetBestPointAlternativeTo(StandingPoint standingPoint, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRangedSiegeWeaponStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetActivationLoadAmmoPoint(bool activate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetDetachmentWeightAuxForExternalAmmoWeapons(BattleSideEnum side)
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
	protected static bool ApproachToAngle(ref float angle, float angleToApproach, bool isMouse, float speed_limit, float dt, float sensitivity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void HandleUserAiming(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GiveInput(float inputX, float inputY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GiveExactInput(float targetX, float targetY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool CanRotate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void ApplyAimChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void ApplyCurrentDirectionToEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual float GetTargetReleaseAngle(Vec3 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateLocalAnglesFromGlobalDirection(Vec3 globalDirection, out float localTargetDirection, out float localTargetAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateLocalDirectionAndLocalAngleToShootTarget(Vec3 target, out float localTargetDirection, out float localTargetAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool AimAtThreat(Threat threat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AimAtTarget(Vec3 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool CheckIsTargetReached(Vec3 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetEstimatedTargetGlobalPoint(Threat threat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetEstimatedTargetGlobalPointForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void AimAtRotation(float horizontalRotation, float verticalRotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnLoadingAmmoPointUsingCancelled(Agent agent, bool isCanceledBecauseOfAnimation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnAmmoPickupUsingCancelled(Agent agent, bool isCanceledBecauseOfAnimation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SendAgentToAmmoPickup(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SendReloaderAgentToOriginalPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateState(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Shoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManualReload()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AiRequestsShoot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AiRequestsManualReload()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetBallisticErrorAppliedDirection(float BallisticErrorAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ShootProjectile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Mission.Missile ShootProjectileAux(ItemObject missileItem, bool randomizeMissileSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetupProjectileToShoot(bool randomizeMissileSpeed, out Vec3 direction, out Mat3 orientation, out float missileBaseSpeed, out float missileShootingSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnRotationStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnRotationStopped()
	{
		throw null;
	}

	public abstract override SiegeEngineType GetSiegeEngineType();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanShootAtBox(Vec3 boxMin, Vec3 boxMax, uint attempts = 5u)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanShootAtThreat(Threat threat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual Vec3 GetEstimatedTargetMovementVector(Vec3 targetCurrentPosition, Vec3 targetVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanShootAtAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanShootAtPoint(Vec3 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanSeePointBallistic(Vec3 startGlobalPos, float verticalAngle, float shootingSpeed, Vec3 targetGlobalPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool CheckFriendlyFireForObjects(Vec3 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool IsTargetValid(ITargetable target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override OrderType GetOrder(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override WeakGameEntity GetEntityToAttachNavMeshFaces()
	{
		throw null;
	}

	public abstract float ProcessTargetValue(float baseValue, TargetFlags flags);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterReadFromNetwork((BaseSynchedMissionObjectReadableRecord, ISynchedMissionObjectReadableRecord) synchedMissionObjectReadableRecord, bool allowVisibilityUpdate = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdateAmmoMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsAnyUserBelongsToFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual Vec3 GetGlobalVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float ComputeProjectileCapsuleRadius()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLoadedMissileItemChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayerForceUse(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ShouldDisableTickIfMachineDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnShipCaptured(BattleSideEnum newDefaultSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RangedSiegeWeapon()
	{
		throw null;
	}
}
