using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class Ballista : RangedSiegeWeapon, ISpawnable
{
	public string NavelTag;

	public string BodyTag;

	public string SkeletonTag;

	public float AnimationHeightDifference;

	private MatrixFrame _ballistaBodyInitialLocalFrame;

	private MatrixFrame _ballistaNavelInitialFrame;

	private MatrixFrame _pilotInitialLocalFrame;

	private MatrixFrame _pilotInitialLocalIKFrame;

	private MatrixFrame _missileInitialLocalFrame;

	[EditableScriptComponentVariable(true, "")]
	protected string IdleActionName;

	[EditableScriptComponentVariable(true, "")]
	protected string ReloadActionName;

	[EditableScriptComponentVariable(true, "")]
	protected string PlaceAmmoStartActionName;

	[EditableScriptComponentVariable(true, "")]
	protected string PlaceAmmoEndActionName;

	[EditableScriptComponentVariable(true, "")]
	protected string PickUpAmmoStartActionName;

	[EditableScriptComponentVariable(true, "")]
	protected string PickUpAmmoEndActionName;

	private ActionIndexCache _idleAnimationActionIndex;

	private ActionIndexCache _reloadAnimationActionIndex;

	private ActionIndexCache _placeAmmoStartAnimationActionIndex;

	private ActionIndexCache _placeAmmoEndAnimationActionIndex;

	private ActionIndexCache _pickUpAmmoStartAnimationActionIndex;

	private ActionIndexCache _pickUpAmmoEndAnimationActionIndex;

	[EditableScriptComponentVariable(true, "")]
	public float HorizontalDirectionRestriction;

	public float BallistaShootingSpeed;

	private WeaponState _changeToState;

	protected SynchedMissionObject ballistaBody
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

	protected SynchedMissionObject ballistaNavel
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

	public override float DirectionRestriction
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

	public override Vec3 CanShootAtPointCheckingOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override bool WeaponMovesDownToReload
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override string MultipleProjectileId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override string MultipleProjectileFlyingId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	protected override float MaximumBallisticError
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void RegisterAnimationParameters()
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
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRangedSiegeWeaponStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleUserAiming(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ApplyAimChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ApplyCurrentDirectionToEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void GetSoundEventIndices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool IsTargetValid(ITargetable target)
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
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void UpdateAmmoMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float ProcessTargetValue(float baseValue, TargetFlags flags)
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
	public void SetSpawnedFromSpawner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Ballista()
	{
		throw null;
	}
}
