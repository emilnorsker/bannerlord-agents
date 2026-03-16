using System;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.NavalPhysics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.ShipActuators;

public class MissionSail : MissionObject
{
	public enum SailTurningState : sbyte
	{
		Stationary,
		TurningLeft,
		TurningRight
	}

	public const float OptimalDirectionSearchInterval = 1f;

	private const int PhysicsPointCountPerAxis = 9;

	private const float BlowSoundEventCooldown = 10f;

	private static readonly int _sailContinuousSoundEventId;

	private static readonly int _sailRotationSoundEventId;

	private const float MinSearchSpaceForTargetSailRotationInRadians = MathF.PI / 30f;

	private ShipSail _sailObject;

	private MissionShip _ownerShip;

	private SailVisual _sailVisual;

	private float _localSailRotation;

	private float _currentSailRotationSpeed;

	private Vec3 _centerOfSailForceShipLocal;

	private float _width;

	private float _height;

	private float _sailRotationStateTimer;

	private float _fullSailWeight;

	private bool _fullSailMode;

	private ShipForce _force;

	private bool _gustMode;

	private SailTurningState _currentSailTurningState;

	private float _targetSailRotation;

	private SoundEvent _sailContinuousSoundEvent;

	private SoundEvent _sailRotationSoundEvent;

	private float _blowSoundEventCooldown;

	private float _sailSoundEventRotationParam;

	private bool _shouldMakeBlowingSound;

	public override TextObject HitObjectName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Index
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipSail SailObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipForce Force
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LocalSailRotation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Setting
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

	public float TargetSailSetting
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

	public Vec3 CenterOfSailForceShipLocal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FoldDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float UnfoldDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameEntity SailEntity
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

	public float Area
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionSail()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitWithVariables(ShipSail sailObject, MissionShip ownerShip, SailVisual sailVisual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitSailRotationAccordingToWindDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckSailFlags(bool editMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateForcedWindOfSailsAndTopBanner(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetSailSetting(in ShipActuatorRecord actuatorInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedUpdateSailForce(Vec3 windVelocityGlobal, Vec3 sailLinearVelocityGlobal, Vec3 sailLinearVelocityFromAngularGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FixedUpdate(float fixedDt, in ShipActuatorRecord actuatorInput, in Vec3 shipLinearVelocityGlobal, in Vec3 shipAngularVelocityGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSailRotationVisual(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSailSetting(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSailVisuals(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSoundPos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 ComputeSailForce(in Vec2 sailDirection2DShip, in Vec2 relWindDirection2DShip, float relWindSpeed2DShip, in MatrixFrame shipFrame, float effectiveSailArea, SailType sailType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float ComputeMaximumForceMagnitudeSailCanApply()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 ComputeWindVectorForSailVisuals(in Vec3 sailForceGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetVisualSailEnabled(bool visualSailEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedTickFullSailInputWeight(float fixedDt, in ShipActuatorRecord actuatorInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVisualSailEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedTickTargetSailRotation(Vec2 relWindDirection2DShip, bool forceFindTheBestAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedTickSailGustMode(float thrustDirection, float curSailThrustValue, float maxThrustValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 Compute3DSailDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCenterOfSailForceLocal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedUpdateSailRotation(float fixedDt, in ShipActuatorRecord actuatorInput, in Vec3 relWindVelocityGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 ComputeCenterOfSailForceGlobal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceFold()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateSailSoundEventRotationParamAndShouldUpdateSoundPos(float dt, float rotationDiff)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeSailSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BoundingBox GetPhysicsBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBurningFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBurning()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartFire()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IntersectLineSegmentWithSail(in Vec3 lineSegmentStart, in Vec3 lineSegmentEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetGlobalSailPoint(Vec3 point, in MatrixFrame sailGlobalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSailHit(Agent attackerAgent, float rawDamage, out float inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartShipCaptureAnimation(Texture newTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnHit(Agent attackerAgent, int damage, Vec3 impactPosition, Vec3 impactDirection, in MissionWeapon weapon, int affectorWeaponSlotOrMissileIndex, ScriptComponentBehavior attackerScriptComponentBehavior, out bool reportDamage, out float finalDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionSail()
	{
		throw null;
	}
}
