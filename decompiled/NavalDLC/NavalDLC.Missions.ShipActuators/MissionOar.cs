using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.ShipActuators;

public class MissionOar
{
	private class OarFoamDecal
	{
		internal Decal _splashFoamDecal;

		internal MatrixFrame _currentFrame;

		internal Mat3 _baseRotation;

		internal Vec3 _sideVectorStart;

		internal Vec3 _sideVectorEnd;

		internal float _cumulativeDtTillStart;

		internal float _randomScale;

		internal Vec3 _currentSpeed;

		internal float _lifeTimeRandomness;

		internal bool _isLeft;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal OarFoamDecal()
		{
			throw null;
		}
	}

	private struct OarRollAnimKeyFrame
	{
		public float KeyProgress;

		public float RollAngleInRad;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OarRollAnimKeyFrame(float keyProgress, float rollAngleInRad)
		{
			throw null;
		}
	}

	private static class OarRollAnimManager
	{
		private static readonly OarRollAnimKeyFrame[] rollAnim;

		private static readonly OarRollAnimKeyFrame[] rollAnim2;

		private static readonly OarRollAnimKeyFrame[] rollAnim3;

		private static readonly OarRollAnimKeyFrame[] rollAnim4;

		private static readonly OarRollAnimKeyFrame[] rollAnim5;

		private static readonly OarRollAnimKeyFrame[] rollAnim6;

		private static readonly OarRollAnimKeyFrame[] rollAnim7;

		public static readonly OarRollAnimKeyFrame[][] RollAnimations;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static OarRollAnimManager()
		{
			throw null;
		}
	}

	private const int numberOfFoamDecals = 4;

	private float _phaseDelayForSlowDown;

	private float _phaseDelayOffset;

	private float _phaseDelayOffsetTimeScale;

	private float _visualVerticalBaseAngleOffset;

	private float _visualVerticalAngleMultiplier;

	private float _visualLateralAngleMultiplier;

	private float _visualOarConstantRollAngle;

	private float _visualOarRollAnimationAngleFactor;

	private int _visualOarRollAnimationIndex;

	private float _slowDownPhaseMultiplier;

	private float _slowDownPhaseDuration;

	private OarFoamDecal[] _splashFoamDecals;

	private int _nextDecalIndexToUse;

	private Vec3 _bladeContact;

	private readonly Vec3 _oarGateOffset;

	private OarSidePhaseController _sidePhaseData;

	private float _timeLeftToCheckForCloseShipsForRetraction;

	private Vec3 _lastGlobalBladeContact;

	private ParticleSystem _oarWaterParticleSmall;

	private bool _wakeActive;

	private bool _decalSpawned;

	private MBFastRandom _oarEffectsRandom;

	private Scene _ownerSceneCached;

	public MissionShip OwnerShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float VisualPhase
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

	public Vec3 GateOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Extraction
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

	public bool IsRetracted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsExtracted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUsed
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

	public bool IsRetracting
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

	public Vec3 BladeContact
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public OarDeckParameters DeckParameters
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

	public float ForceMultiplierFromUserAgent
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
	private MissionOar(MissionShip ownerShip, GameEntity entity, OarDeckParameters deckParameters, OarSidePhaseController phaseData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReRandomizeVisualParameters(int userAgentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsed(bool newIsUsed, int userAgentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRetractOars(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSlowDownPhaseForDuration(float slowDownMultiplier, float slowDownDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnNewDecal(Vec3 spawnPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFoamDecals(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FixedUpdate(float fixedDt, in MatrixFrame shipGlobalFrame, MBList<(MissionShip ship, OarSidePhaseController.OarSide shipSide)> nearbyShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ComputeBladeContactPosition(bool ignoreRetraction = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ComputeBladeVisualContactPosition(bool ignoreRetraction = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 ComputeBladeContactPositionAux(in Vec3 gateOffset, OarDeckParameters deckParameters, float phase = 0f, float retraction = 1f, float verticalBaseAngleOffset = 0f, float verticalAngleMultiplier = 1f, float lateralAngleMultiplier = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ComputeBladeContactVelocity(bool ignoreRetraction = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 ComputeBladeContactVelocityAux(OarDeckParameters deckParameters, float phase, float phaseRate, float retraction = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetVerticalAngle(float phase, float verticalBaseAngle, float verticalRotationAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetLateralAngle(float phase, float lateralBaseAngle, float lateralRotationAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionOar CreateShipOar(MissionShip ownerShip, GameEntity entity, OarDeckParameters deckParameters, OarSidePhaseController sidePhase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame ComputeOarEntityFrame(float dt, in MatrixFrame oarMachineLocalFrame, in MatrixFrame oarEntityLocalFrame, in MatrixFrame _oarExtractedEntitialFrame, in MatrixFrame _oarRetractedEntitialFrame, float _lastIdleTime, bool forUnmanned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float ComputeOarRollAccordingToPhase(float phase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOarForceMultiplierFromUserAgent(float forceMultiplierFromUserAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPilotAssignedDuringSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInRowingMotion()
	{
		throw null;
	}
}
