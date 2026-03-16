using System;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.ShipInput;
using TaleWorlds.Library;

namespace NavalDLC.Missions.ShipControl;

public class AIShipController : ShipController
{
	public enum TargetMode
	{
		None,
		Position,
		State,
		Ship,
		ShipOffset
	}

	public const float ProportionalControllerSamplingPeriod = 1f / 30f;

	private const float LateralInputAccelerationThreshold = 0.01f;

	private const float LongitudinalInputAccelerationThreshold = 0.01f;

	private const float RaisedSailInputThresholdMultiplier = 0.2f;

	private const float FullSailInputThresholdMultiplier = 0.6f;

	private TargetMode _targetMode;

	private NavalState _targetState;

	private NavalVec _targetOffset;

	private bool _stopOnArrival;

	private bool _ignoreTargetShipCollision;

	private uint _rowerLateralDebounceCounter;

	private uint _rowerLongitudinalDebounceCounter;

	private uint _rudderLateralDebounceCounter;

	private uint _sailDebounceCounter;

	private ShipInputRecord _inputRecord;

	private NavalShipsLogic _navalShipsLogic;

	private NavigationPath _navigationPath;

	private int _lastNavPathPointIndex;

	private UIntPtr _lastNavPathStartFace;

	private UIntPtr _lastNavPathTargetFace;

	private Vec2 _lastNavPathTargetPosition;

	private float _navPathTargetDriftAccumulator;

	private float _lastNavPathHardRecomputeTime;

	private bool _collisionChecksActive;

	private bool _avoidShipCollisions;

	private bool _avoidObstacleCollisions;

	private MBList<MissionShip> _shipCollisionIgnoreList;

	public MissionShip TargetShip
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

	internal MBReadOnlyList<MissionShip> ShipCollisionIgnoreList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CanAvoidCollisions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool CollisionChecksActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool AvoidShipCollisions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool AvoidObstacleCollisions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal float DesiredLinearAcceleration
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

	internal float DesiredAngularAcceleration
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

	public bool HasTarget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasNavigationPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AIShipController(MissionShip ownerShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ShipInputRecord Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetPosition(in Vec2 targetPosition, bool stopOnArrival = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetState(in Vec2 targetPosition, in Vec2 targetDirection, bool stopOnArrival = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetState(in NavalState targetState, bool stopOnArrival = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetShip(in MissionShip targetShip, bool stopOnArrival = false, bool ignoreTargetShipCollision = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetShipWithOffset(in MissionShip targetShip, in NavalVec localOffset, bool stopOnArrival = false, bool ignoreTargetShipCollision = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddShipToCollisionIgnoreListOnAccountOfRamming(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddShipToCollisionIgnoreList(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetAvoidShipCollisions(bool value = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveShipFromCollisionIgnoreListOnAccountOfRamming(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveShipFromCollisionIgnoreList(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetAvoidObstacleCollisions(bool value = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetCollisionChecksActive(bool value = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ClearShipCollisionIgnoreList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool CheckShipInCollisionIgnoreList(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetRawTargetState(out Vec2 targetPosition, out Vec2 targetDirection, out float targetSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetNextTarget(out Vec2 targetPosition, out Vec2 targetDirection, out float targetSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasArrivedAtTarget(out float postionErrorSquared, out float rotationError)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateTrajectory(float desiredLinearAcceleration, float desiredAngularAcceleration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UpdateTargetState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTargetStateZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ShipInputRecord StabilizeInput(ShipInputRecord inputRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetShipAux(MissionShip targetShip, bool ignoreCollision = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void DecideControl(in ShipInputRecord oldInputRecord, in Vec2 shipForward2D, in Vec2 globalWindVelocity, float desiredAngularAcceleration, in float desiredLinearAcceleration, float maxLinearAcceleration, float maxAngularAcceleration, out ShipInputRecord inputRecord, Vec3 shipLocalVelocity, bool enforceSailUsage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReComputeNavigationPath(in NavalState currentState, in NavalState newTargetState, bool forceRecompute = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldRecomputePath(in NavalState currentState, in NavalState newTargetState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool NavPathStartOrGoalFaceChanged(in Vec2 currentPos, in Vec2 newTargetPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateNavigationPath(in NavalState currentState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NavalState GetNextTargetStateOverPath()
	{
		throw null;
	}
}
