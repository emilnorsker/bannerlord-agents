using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public abstract class SiegeWeapon : UsableMachine, ITargetable
{
	private const string TargetingEntityTag = "targeting_entity";

	[EditableScriptComponentVariable(true, "")]
	internal string RemoveOnDeployTag;

	[EditableScriptComponentVariable(true, "")]
	internal string AddOnDeployTag;

	private List<GameEntity> _addOnDeployEntities;

	protected bool _spawnedFromSpawner;

	private List<GameEntity> _removeOnDeployEntities;

	private List<Formation> _potentialUsingFormations;

	private List<Formation> _forcedUseFormations;

	private bool _needsSingleThreadTickOnce;

	private bool _areMovingAgentsProcessed;

	private bool _isValidated;

	private Vec3? _targetingPositionOffset;

	[EditorVisibleScriptComponentVariable(false)]
	public bool ForcedUse
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

	public bool IsUsed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual BattleSideEnum Side
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject HitObjectName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override bool HasWaitFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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
	public void SetForcedUse(bool value)
	{
		throw null;
	}

	public abstract SiegeEngineType GetSiegeEngineType();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool CalculateIsSufficientlyManned(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasNewMovingAgents()
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
	private void TickAux(bool isParallel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsAnyUserBelongsToFormation(Formation formation)
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
	public void TickAuxForInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void OnDeploymentStateChanged(bool isDeployed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ShouldAutoLeaveDetachmentWhenDisabled(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool AutoAttachUserToFormation(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool HasToBeDefendedByUser(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetUserMultiplierOfWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float GetDistanceMultiplierOfWeapon(Vec3 weaponPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float GetMinimumDistanceBetweenPositions(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected float GetHitPointMultiplierOfWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetTargetEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetingOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleSideEnum GetSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetGlobalVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDestructable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity Entity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (Vec3, Vec3) ComputeGlobalPhysicsBoundingBoxMinMax()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnShipCaptured(BattleSideEnum newDefaultSide)
	{
		throw null;
	}

	public abstract TargetFlags GetTargetFlags();

	public abstract float GetTargetValue(List<Vec3> weaponPos);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected SiegeWeapon()
	{
		throw null;
	}
}
