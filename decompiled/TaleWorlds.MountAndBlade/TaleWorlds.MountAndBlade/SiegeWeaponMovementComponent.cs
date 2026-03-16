using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class SiegeWeaponMovementComponent : UsableMissionObjectComponent
{
	public const string GhostObjectTag = "ghost_object";

	private const string WheelTag = "wheel";

	public const string MoveStandingPointTag = "move";

	public float AxleLength;

	public int NavMeshIdToDisableOnDestination;

	private float _ghostObjectPos;

	private List<GameEntity> _wheels;

	private List<StandingPoint> _standingPoints;

	private MatrixFrame[] _standingPointLocalIKFrames;

	private SoundEvent _movementSound;

	private float _wheelCircumference;

	private bool _isMoveSoundPlaying;

	private float _wheelDiameter;

	private Path _path;

	private PathTracker _pathTracker;

	private PathTracker _ghostEntityPathTracker;

	private float _advancementError;

	private float _lastSynchronizedDistance;

	public bool HasApproachedTarget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 Velocity
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

	public bool HasArrivedAtTarget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CurrentSpeed
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

	public int MovementSoundCodeID
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

	public float MinSpeed
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

	public float MaxSpeed
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

	public string PathEntityName
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

	public float GhostEntitySpeedMultiplier
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

	public float WheelDiameter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public SynchedMissionObject MainObject
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnAdded(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HighlightPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupGhostEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGhostVisibility(bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateGhostObject(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RotateWheels(float angleInRadian)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame LinearInterpolatedIK(ref PathTracker pathTracker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDistanceTraveledAsClient(float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsOnTickRequired()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickParallelManually(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetInitialFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetTargetFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDestinationNavMeshIdState(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MoveToTargetAsClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayMovementSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopMovementSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTotalDistanceTraveledForPathTracker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame FindGroundFrameForWheels(ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTotalDistanceTraveledForPathTracker(float distanceTraveled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetFrameForPathTracker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame FindGroundFrameForWheelsStatic(ref MatrixFrame frame, float axleLength, float wheelDiameter, WeakGameEntity gameEntity, List<GameEntity> wheels, Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeWeaponMovementComponent()
	{
		throw null;
	}
}
