using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class Mangonel : RangedSiegeWeapon, ISpawnable
{
	private const string BodyTag = "body";

	private const string RopeTag = "rope";

	private const string RotateTag = "rotate";

	private const string LeftTag = "left";

	private const string VerticalAdjusterTag = "vertical_adjuster";

	private string _missileBoneName;

	private List<StandingPoint> _rotateStandingPoints;

	private SynchedMissionObject _body;

	private SynchedMissionObject _rope;

	private GameEntity _verticalAdjuster;

	private MatrixFrame _verticalAdjusterStartingLocalFrame;

	private Skeleton _verticalAdjusterSkeleton;

	private Skeleton _bodySkeleton;

	private float _timeElapsedAfterLoading;

	private MatrixFrame[] _standingPointLocalIKFrames;

	private StandingPoint _reloadWithoutPilot;

	public string MangonelBodySkeleton;

	public string MangonelBodyFire;

	public string MangonelBodyReload;

	public string MangonelRopeFire;

	public string MangonelRopeReload;

	public string MangonelAimAnimation;

	public string ProjectileBoneName;

	public string IdleActionName;

	public string ShootActionName;

	public string Reload1ActionName;

	public string Reload2ActionName;

	public string RotateLeftActionName;

	public string RotateRightActionName;

	public string LoadAmmoBeginActionName;

	public string LoadAmmoEndActionName;

	public string Reload2IdleActionName;

	public float ProjectileSpeed;

	private ActionIndexCache _idleAnimationActionIndex;

	private ActionIndexCache _shootAnimationActionIndex;

	private ActionIndexCache _reload1AnimationActionIndex;

	private ActionIndexCache _reload2AnimationActionIndex;

	private ActionIndexCache _rotateLeftAnimationActionIndex;

	private ActionIndexCache _rotateRightAnimationActionIndex;

	private ActionIndexCache _loadAmmoBeginAnimationActionIndex;

	private ActionIndexCache _loadAmmoEndAnimationActionIndex;

	private ActionIndexCache _reload2IdleActionIndex;

	private sbyte _missileBoneIndex;

	protected override float MaximumBallisticError
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override float ShootingSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override float HorizontalAimSensitivity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override float VerticalAimSensitivity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override Vec3 ShootingDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override bool HasAmmo
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterAnimationParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
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
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPilotAssignedDuringSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanRotate()
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
	protected override void SetActivationLoadAmmoPoint(bool activate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void UpdateProjectilePosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRangedSiegeWeaponStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void GetSoundEventIndices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ApplyAimChange()
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
	public override float ProcessTargetValue(float baseValue, TargetFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnedFromSpawner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mangonel()
	{
		throw null;
	}
}
