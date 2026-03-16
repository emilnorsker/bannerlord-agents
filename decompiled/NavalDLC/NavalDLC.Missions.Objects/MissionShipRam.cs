using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects;

public class MissionShipRam : MissionObject
{
	private struct RamCollisionData
	{
		public MissionShip TargetShip;

		public CapsuleData CapsuleData;

		public bool RamWillBeHandled;

		public Vec3 SelectedIntersectionPoint;

		public Vec3 AverageIntersectionPoint;

		public Vec3 RamDirection;

		public float PenetrationLength;

		public bool HasPoint;

		public float CalculatedDamage;

		public Vec3 PointVelocityOnOwner;

		public Vec3 PointVelocityOnTarget;

		public bool IsValid
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}
	}

	private const float SpeedFactorOnMagnitude = 0.03f;

	private const string ShipDebrisAndParticlePrefabName = "decal_ship_damaged_b_heap";

	private const string ShipBodyPhysicsEntityTag = "body_mesh";

	private const float RamHitDirectionThresholdPercentage = 0.3f;

	private const float RamStickThresholdPercentage = 0.33f;

	private const string PhysicsMaterialName = "wood_ship";

	private static readonly int RamCollisionSoundEffectSoundId;

	private const BodyFlags RamRaycastExcludeFlags = (BodyFlags)2147497729u;

	private static (float, float, float, float, bool)[] _ramQualityThresholds;

	private Intersection[] _intersectionsCache;

	private WeakGameEntity[] _entitiesCache;

	private UIntPtr[] _entityPointersCache;

	private Intersection[] _selectedIntersectionsCache;

	private MissionShip _ownerShip;

	private MissionShip _ramStuckTargetShip;

	private bool _ramCollisionBeingHandled;

	private RamCollisionData _ramDamageData;

	private RamCollisionData _ramCollisionData;

	private Scene _ownScene;

	private int _lastRamHitQuality;

	[EditableScriptComponentVariable(true, "")]
	private float _ramLength;

	[EditableScriptComponentVariable(true, "")]
	private float _ramRadius;

	[EditableScriptComponentVariable(true, "")]
	private Vec3 _ramAttachmentPointOffset;

	[EditableScriptComponentVariable(true, "")]
	private float _ramTierDamageMultiplier;

	private float _scaledRamRadius;

	private float _scaledRamLength;

	private static float ForwardSpeedThresholdToDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static float DistanceToShipCenterThresholdToDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float RamLength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CapsuleData GetRamCapsuleData(float fixedDt, bool getDataForNextFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerRamCollisionParticleAndSoundEffect(int targetShipIndex, WeakGameEntity targetEntity, CapsuleData shipRamCapsule, float damage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RamCollisionHandleFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RamCollisionCheckTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanPhysicsCollideBetweenTwoEntities(WeakGameEntity myEntity, WeakGameEntity otherEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShipRam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionShipRam()
	{
		throw null;
	}
}
