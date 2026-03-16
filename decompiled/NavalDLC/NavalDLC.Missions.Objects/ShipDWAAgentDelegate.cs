using System.Runtime.CompilerServices;
using NavalDLC.DWA;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

public class ShipDWAAgentDelegate : IDWAAgentDelegate
{
	private DWAAgentState _state;

	private float _detectionRadius;

	private bool _hasTarget;

	private Vec2 _targetPos;

	private Vec2 _targetHeadingDir;

	private Vec2 _shipToTargetDir;

	private Vec2 _shipToTargetNormalDir;

	private Vec2 _shipToTargetTangentDir;

	private float _dotShipFwdToTargetHeading;

	private float _targetSpeed;

	private float _shipToTargetDistance;

	private float _timeHorizon;

	private (float dV, float dOmega) _selectedAction;

	public int Id
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

	public MissionShip OwnerShip
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

	public float ShapeOffsetY
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

	public float ShapeComOffsetY
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

	public ref readonly DWAAgentState State
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float NeighborDistance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxLinearSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxLinearAcceleration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxAngularSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxAngularAcceleration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IDWAAgentDelegate.AvoidAgentCollisions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IDWAAgentDelegate.AvoidObstacleCollisions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipDWAAgentDelegate(MissionShip ownerShip, in DWASimulatorParameters parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDWAAgentDelegate.Initialize(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDWAAgentDelegate.SetParameters(in DWASimulatorParameters parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDWAAgentDelegate.GetSafetyFactor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDWAAgentDelegate.CanPlanTrajectory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDWAAgentDelegate.HasArrivedAtTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDWAAgentDelegate.IsAgentEligibleNeighbor(int targetAgentId, IDWAAgentDelegate targetAgentDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDWAAgentDelegate.IsObstacleSegmentEligibleNeighbor(IDWAObstacleVertex obstacle1, IDWAObstacleVertex obstacle2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDWAAgentDelegate.OnStateUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDWAAgentDelegate.UpdateSelectedAction(float dV, float dOmega)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDWAAgentDelegate.GetGoalDirection(out Vec2 goalDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	(float dV, float dOmega) IDWAAgentDelegate.GetSelectedAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDWAAgentDelegate.ComputeGoalCost(int sampleIndex, in DWAAgentState sampleState, (float distance, float amount) targetOcclusion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDWAAgentDelegate.ComputeExternalAccelerationsOnState(float dt, in DWAAgentState state, out Vec2 extLinearAcc, out float extAngularAcc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheDynamicParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ComputeDetectionRadius(float halfLength, float timeHorizon, float maxLinearSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheShipTrajectoryData(in Vec2 targetPos, in Vec2 targetDir, float targetSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTimeHorizon(float timeHorizon)
	{
		throw null;
	}
}
