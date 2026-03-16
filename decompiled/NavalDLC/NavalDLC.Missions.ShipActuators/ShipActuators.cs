using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.NavalPhysics;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.ShipActuators;

public class ShipActuators
{
	private struct RowingSoundEventData
	{
		internal float SoundEventRowingPowerParam;

		internal int NumberOfActiveOars;

		internal bool ShouldTriggerOarSound;

		internal bool IsOarsInWater;

		internal Vec3 RowingSoundEventPositions;

		internal int FurthestOarIndex;

		internal int ClosestOarIndex;

		internal SoundEvent OarsSoundEvents;
	}

	public struct OarPhaseData
	{
		public float CurPhase;

		public float LastNonZeroRevolutionRate;

		public bool LockedToTargetPhase;

		public float CycleArcSizeMult;
	}

	public struct OarAnimKeyFrame
	{
		public float KeyProgress;

		public float Speed;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OarAnimKeyFrame(float keyProgress, float speed)
		{
			throw null;
		}
	}

	private static class OarRowSpeedAnimationManager
	{
		public static OarAnimKeyFrame[] ForwardPhaseSpeedAnim;

		public static OarAnimKeyFrame[] PartialPhaseSpeedAnim;

		public static OarAnimKeyFrame[] OnPointTurnPhaseSpeedAnim;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static OarRowSpeedAnimationManager()
		{
			throw null;
		}
	}

	private static readonly int[] _rowingSoundEventIds;

	public const string SailTagPrefix = "sail_center_";

	public const string RudderStockPositionTag = "rudder_stock";

	private const float MinSpeedToUseBothOarsToTurn = 2f;

	private static readonly int _rudderSoundEventId;

	private static readonly int _shipPresenceSoundEventId;

	private float _rudderLocalRotation;

	private float _lastRudderLocalRotation;

	private float _lastAddedFromInputRudderLocalRotation;

	private float _lastTargetRudderStabilityLocalRotation;

	private Vec3 _rudderStockLocalPosition;

	private readonly MissionShip _ownerMissionShip;

	private readonly Scene _cachedOwnerScene;

	private float _rowersPhase;

	private float _lastFramePhaseRate;

	private bool _evenCycle;

	private OarPhaseData _leftPhaseData;

	private OarPhaseData _rightPhaseData;

	private readonly MBList<MissionSail> _sails;

	private readonly MBList<(GameEntity entity, MissionOar oar)> _leftSideOars;

	private readonly MBList<(GameEntity entity, MissionOar oar)> _rightSideOars;

	private MBList<ShipForce> _leftOarForces;

	private MBList<ShipForce> _rightOarForces;

	private MBList<ShipForce> _sailForces;

	private ShipForce _rudderShipForce;

	private OarSidePhaseController _leftOarsPhaseController;

	private OarSidePhaseController _rightOarsPhaseController;

	private float _oarsmenForceMultiplier;

	private float _oarsmenSpeedMultiplier;

	private float _oarsTipSpeedReferenceMultiplier;

	private float _oarFrictionMultiplier;

	private float _oarAppliedForceMultiplierForStoryMission;

	private float _maxOarLength;

	private readonly MBList<(MissionShip ship, OarSidePhaseController.OarSide shipSide)> _nearbyShips;

	private float _timeLeftToUpdateNearbyShips;

	private readonly NavalShipsLogic _navalShipsLogic;

	private Vec3 _leftSideAverageOarLocalPos;

	private Vec3 _rightSideAverageOarLocalPos;

	private SoundEvent _rudderSoundEvent;

	private SoundEvent _shipPresenceSoundEvent;

	private RowingSoundEventData[] _rowingSoundEventData;

	private float _rudderStressSoundParam;

	private float _shipPresenceSoundParam;

	public float VisualRudderLocalRotation
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

	public MBReadOnlyList<MissionSail> Sails
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipActuators(MissionShip ownerShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipObjectUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipForceRecord OnParallelFixedTick(float fixedDt, in ShipActuatorRecord actuatorInput)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateOarSoundPositionsAndParams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Update(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedUpdateSails(float fixedDt, in ShipActuatorRecord actuatorInput, in Vec3 shipLinearVelocityGlobal, in Vec3 shipAngularVelocityGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSoundEventPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 CalculateRowingSoundPosition(in Vec3 closestOarGlobalPos, in Vec3 furthestOarGlobalPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateOarRowingPowerSoundParameter(OarSidePhaseController.OarSide oarSide, in Vec3 soundPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadOars()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipRemoved(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static OarDeckParameters GenerateAverageSideDeckParametersAux(MBList<(GameEntity entity, MissionOar oar)> sideOars)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GenerateAverageSideDeckParameters(out OarDeckParameters leftSideAverageDeckParameters, out OarDeckParameters rightSideAverageDeckParameters, MBList<(GameEntity entity, MissionOar oar)> leftSideOars, MBList<(GameEntity entity, MissionOar oar)> rightSideOars)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadSails()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadRudder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTickRowers(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BlendPhaseTo(ref OarPhaseData phaseData, float targetPhase, float alphaInRadOverSeconds, float maxAlphaInRadOverSeconds, float fixedDt, bool toFullStop, bool isPartialStop, bool playerShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetRowSpeedAccordingToPhase(float phase, bool forwards, bool partialTurn, bool onPointTurn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedUpdateRowers(float fixedDt, in ShipActuatorRecord actuatorInput, in MatrixFrame shipEntityGlobalFrame, float shipForwardSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopRovers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedUpdateRudder(float fixedDt, in ShipActuatorRecord actuatorInput, in MatrixFrame shipEntityGlobalFrame, in Vec3 shipLinearVelocityGlobal, float shipForwardSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTickRudder(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ComputeExtractedOarCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ComputeUsedOarCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (float, float) ComputeAverageOarTipPointForwardVelocities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FixedUpdateSideOars(float fixedDt, in MatrixFrame shipGlobalFrame, MBList<(MissionShip ship, OarSidePhaseController.OarSide shipSide)> nearbyShips, MBList<(GameEntity entity, MissionOar oar)> shipOars, ref float maxForceMultiplierFromUser)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateRowerParameters(float rowersThrustRate, float rowersRotationRate, float shipForwardSpeed, out float leftRowersNeededRevolutionRate, out float rightRowersNeededRevolutionRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IShipOarScriptComponent GetOarScriptFromEntity(WeakGameEntity oarEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float ComputeActuatorParameter(float value, float target, float dt, float incrementRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static (Vec3, Vec3) ComputeRudderDeflectionForce(float totalTargetRot, in Vec3 unClampedRudderStabilityDirectionLocal, in Vec3 rudderStockLocalVelocity, in Vec3 rudderStockLocalVelocityDirection, float rudderSurfaceArea)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOarAppliedForceMultiplierForStoryMission(float newOarAppliedForceMultiplierForStoryMission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShipActuators()
	{
		throw null;
	}
}
