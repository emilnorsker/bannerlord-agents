using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class SpawnedItemEntity : UsableMissionObject
{
	private class ClientSyncData
	{
		public MatrixFrame Frame;

		public GameEntity Parent;

		public Timer Timer;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ClientSyncData()
		{
			throw null;
		}
	}

	private MissionWeapon _weapon;

	private bool _hasLifeTime;

	public string WeaponName;

	private const float LongLifeTime = 180f;

	private const float DisablePhysicsTime = 10f;

	private const float QuickFadeoutLifeTime = 5f;

	private const float TotalFadeOutInDuration = 0.5f;

	private const float PreventStationaryCheckTime = 1f;

	private Timer _disablePhysicsTimer;

	private bool _physicsStopped;

	private bool _readyToBeDeleted;

	private Timer _deletionTimer;

	private int _usedChannelIndex;

	private ActionIndexCache _progressActionIndex;

	private ActionIndexCache _successActionIndex;

	private float _lastSoundPlayTime;

	private const float MinSoundDelay = 0.333f;

	private SoundEvent _rollingSoundEvent;

	private ClientSyncData _clientSyncData;

	private GameEntity _ownerGameEntity;

	private Vec3 _fakeSimulationVelocity;

	private bool _alreadyMadeWaterDropSound;

	private bool _disableDynamicPhysicsNextFrame;

	private GameEntity _groundEntityWhenDisabled;

	public MissionWeapon WeaponCopy
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasLifeTime
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

	private bool PhysicsStopped
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

	public bool IsRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool SpawnedOnACorpse
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

	public override bool LockUserFrames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Mission.WeaponSpawnFlags SpawnFlags
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
	public TextObject GetActionMessage(ItemObject weaponToReplaceWith, bool fillUp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetDescriptionMessage(bool fillUp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(MissionWeapon weapon, bool hasLifeTime, Mission.WeaponSpawnFlags spawnFlags, in Vec3 fakeSimulationVelocity, bool spawnedOnACorpse = false)
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
	protected internal override void OnTickParallel2(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableDynamicBody()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity TryFindProperGroundEntityForSpawnedEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTickOccasionally(float currentFrameDeltaTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClampEntityPositionForStoppingIfNeeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnPreInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachWeaponToWeapon(MissionWeapon attachedWeapon, ref MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReadyToBeDeleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnPhysicsCollision(ref PhysicsContact contact, WeakGameEntity entity0, WeakGameEntity entity1, bool isFirstShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayPhysicsCollisionSound(Vec3 impulse, PhysicsMaterial collidedMat, Vec3 collisionPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayPhysicsRollSound(Vec3 impulse, Vec3 collisionPoint, PhysicsMaterial collidedMat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsStuckMissile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsQuiverAndNotEmpty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBanner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetInfoTextForBeingNotInteractable(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopPhysicsAndSetFrameForClient(MatrixFrame frame, GameEntity parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConsumeWeaponAmount(short consumedAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestDeletionOnNextTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterReadFromNetwork((BaseSynchedMissionObjectReadableRecord, ISynchedMissionObjectReadableRecord) synchedMissionObjectReadableRecord, bool allowVisibilityUpdate = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnedItemEntity()
	{
		throw null;
	}
}
