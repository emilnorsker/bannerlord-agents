using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.NavalPhysics;

[ScriptComponentParams("ship_visual_only", "")]
public class NavalPhysics : ScriptComponentBehavior
{
	public struct NavalPhysicsParameters
	{
		public float OverrideMass;

		public float MassMultiplier;

		public Vec3 MomentOfInertiaMultiplier;

		public float FloatingForceMultiplier;

		public float MaximumSubmergedVolumeRatio;

		public float ForwardDragMultiplier;

		public LinearFrictionTerm LinearFrictionMultiplier;

		public Vec3 AngularFrictionMultiplier;

		public float TorqueMultiplierOfLateralBuoyantForces;

		public Vec3 TorqueMultiplierOfVerticalBuoyantForces;

		public float UpSideDownFrictionMultiplier;

		public float MaxLinearSpeedForLateralDragCenterShift;

		public float MaxLateralDragShift;

		public float LateralDragShiftCriticalAngle;

		public float StepAgentWeightMultiplier;

		public bool MakeAgentsStepToEntityEvenUnderWater;
	}

	public struct BuoyancyComputationResult
	{
		public float PitchSubmergedAreaFactor;

		public float RollSubmergedAreaFactor;

		public float SubmergedHeightFactor;

		public float SubmergedFloaterCountFactor;

		public Vec3 AvgLocalBuoyancyApplyPosition;

		public Vec3 NetGlobalBuoyancyForce;

		public Vec3 NetBuoyancyTorque;

		public bool SimulatingAirFriction;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Reset()
		{
			throw null;
		}
	}

	public struct DragForceComputationResult
	{
		public Vec3 CenterOfLateralDragLocal;

		public Vec3 LateralDragForceGlobal;

		public Vec3 CenterOfVerticalDragLocal;

		public Vec3 VerticalDragForceGlobal;

		public Vec3 CenterOfLongitudinalDragLocal;

		public Vec3 LongitudinalDragForceGlobal;

		public Vec3 AngularDragTorqueGlobal;

		public Vec3 DriftForceFromAngularDragGlobal;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Reset()
		{
			throw null;
		}
	}

	public struct WaterDriftForceData
	{
		public float DriftSpeed;

		public float DriftForceTimer;

		public MBFastRandom DriftRandom;

		public Vec3 ResultForce;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize()
		{
			throw null;
		}
	}

	public enum ShipPart : byte
	{
		LeftBack,
		RightBack,
		LeftMid,
		RightMid,
		LeftFront,
		RightFront,
		Count
	}

	public enum SinkingState : byte
	{
		Floating,
		Sinking,
		Sunk
	}

	public const byte VerticalPartitionCount = 3;

	public const byte HorizontalPartitionCount = 2;

	private NavalPhysicsParameters _physicsParameters;

	private float _stabilityAvgSubmergedHeight;

	private int _stabilitySubmergedFloaterCount;

	private float _minFloaterEntitialBottomPos;

	private Scene _ownScene;

	private float _maxFloaterEntitialTopPos;

	private float _minimumFloaterDurabilityToFloatWhileNotSinking;

	[EditableScriptComponentVariable(false, "")]
	public Vec3 AngularDragTerm;

	[EditableScriptComponentVariable(true, "Sink")]
	private SimpleButton _sinkButton;

	private float _angularDragYSideComponentTerm;

	[EditableScriptComponentVariable(false, "")]
	public Vec3 AngularDampingTerm;

	private float _angularDampingYSideComponentTerm;

	private float _cachedMass;

	private float[] _shipPartsDurabilities;

	private ShipPart[] _floaterVolumesShipPartMap;

	private float[] _shipPartsTargetDurabilities;

	private VolumeDataForSubmergeComputation[] _floaterVolumeData;

	private UIntPtr _floaterVolumeDataPinnedPointer;

	private GCHandle _floaterVolumeDataPinnedGCHandler;

	private float _totalFloaterVolumeCached;

	private ShipForceRecord _shipForceRecord;

	private BuoyancyComputationResult _buoyancyComputationResult;

	private DragForceComputationResult _dragComputationResult;

	private MatrixFrame _anchorGlobalFrame;

	private float _anchorForceMultiplier;

	private Vec3 _weightedAgentsPosition;

	private float _totalMass;

	private Vec3 _committedWeightedAgentsPosition;

	private float _committedTotalMass;

	private WaterDriftForceData _continuousDriftForceData;

	public bool IsInitialized
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

	public Vec3 PhysicsBoundingBoxWithChildrenSize
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

	public Vec3 PhysicsBoundingBoxSizeWithoutChildren
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

	public BoundingBox PhysicsBoundingBoxWithChildren
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

	public BoundingBox PhysicsBoundingBoxWithoutChildren
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

	public float Mass
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 LocalCenterOfMass
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 MassSpaceInertia
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ref readonly NavalPhysicsParameters PhysicsParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SinkingState NavalSinkingState
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

	private float StabilitySubmergedVolume
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FloatingForceMultiplierWhenDamaged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float StabilitySubmergedHeightOfShip
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

	public float LastSubmergedHeightFactorForActuators
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

	public LinearFrictionTerm LinearDragTerm
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

	public LinearFrictionTerm LinearDampingTerm
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

	public float MinFloaterEntitialBottomPos
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxFloaterEntitialTopPos
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AngularDragYSideComponentTerm
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public LinearFrictionTerm ConstantLinearDampingTerm
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

	public float AngularDampingYSideComponentTerm
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 LinearVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 AngularVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAnchored
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

	public MatrixFrame AnchorGlobalFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalPhysics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPreInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(NavalPhysicsParameters physicsParameters, ShipPhysicsReference basePhysicsRef)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSaveAsPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAirDensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetWaterDensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipObjectUpdated(NavalPhysicsParameters physicsParameters, ShipPhysicsReference basePhysicsRef)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipForceRecord(in ShipForceRecord record)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetContinuousDriftSpeed(float driftSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnchor(bool isAnchored, bool anchorInPlace = false, float forceMultiplier = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnchorFrame(in Vec2 position, in Vec2 direction, float forceMultiplier = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyGlobalForceAtLocalPos(in Vec3 localPos, in Vec3 globalForceVec, ForceMode forceMode = (ForceMode)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyLocalForceAtLocalPos(in Vec3 localPos, in Vec3 localForceVec, ForceMode forceMode = (ForceMode)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyForceToDynamicBody(in Vec3 forceVec, ForceMode forceMode = (ForceMode)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyTorque(in Vec3 torqueVec, ForceMode forceMode = (ForceMode)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetGlobalMassFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetClosestPointToBoundingBox(in Vec3 localPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetDurabilityOfPart(int part, float targetDurability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetDurabilityToAdjacentParts(int part, float targetDurability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFloaterDurabilities(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillWaterHeightQueryResultsIterative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static (float, float) RungeKuttaIntegrationStepForBuoyancyAndGravity(float prevIterationUpSpeed, float prevIterationUpAcceleration, float baseShipUpSpeed, float fixedDt, float baseSubmergedHeight, float volumeHeight, float volumeWidthMultDepth, float waterDensity, float durabilityMultiplier, float curInvVolumeMass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeBuoyancyForces(float fixedDt, in Vec3 globalLinearVelocity, in Vec3 globalAngularVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PreComputeAngularDragTerms(out Vec3 angularDampingTerm, out Vec3 angularDragTerm, out float angularDampingYSideComponentTerm, out float angularDragYSideComponentTerm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeDragForces(float fixedDt, in Vec3 globalLinearVelocity, in Vec3 globalAngularVelocity, in Vec3 massSpaceLocalInertia)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeDriftFromAngularFriction(float fixedDt, in MatrixFrame entityGlobalFrame, in MatrixFrame centerOfMassGlobalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyDragForces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyAgentForces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearAgentWeightAndPositionInformation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyBuoyancyForces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentWeightAndPositionInformation(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyActuatorForces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyAnchorForces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Oriented2DArea GetGlobalMaximal2DArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPartIndexAtPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadFloaterVolumes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateFloaterVolumeData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeAndCacheStabilityAvgSubmergedHeight(float minimumEntitialFloaterZ, float maximumEntitialFloaterZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateShipPhysics(NavalPhysicsParameters physicsParameters, ShipPhysicsReference basePhysicsRef)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeContinuousDriftForce(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyContinuousDriftForce()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ComputeLateralDragShift(in Vec3 localVelocity, float maxLateralDragShift, float lateralDragShiftCriticalAngle, float maxLateralShiftSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSinkingState(SinkingState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec3 SubStepIntegrationStepForLinearFriction(Vec3 absLinearVelocityLocal, float subStepFixedDt, float mass, Vec3 submergedLinearDragTerm, Vec3 submergedLinearDampingTerm, Vec3 submergedConstantLinearDampingTerm, Vec3 submergedFactorLinear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec3 SubStepIntegrationStepForAngularFriction(Vec3 absMassLocalAngularVelocity, float subStepFixedDt, Vec3 massLocalInertia, Vec3 angularDragTerm, Vec3 angularDampingTerm, float angularDragYSideComponentTerm, float angularDampingYSideComponentTerm, in BuoyancyComputationResult buoyancyComputationResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ComputeLinearDrag(float fixedDt, int substepCount, in Vec3 globalLinearVelocity, in MatrixFrame globalFrame, in float mass, in Vec3 localCenterOfMass, in NavalPhysicsParameters physicsParameters, in BuoyancyComputationResult buoyancyComputationResult, in LinearFrictionTerm linearDragTerm, in LinearFrictionTerm linearDampingTerm, in LinearFrictionTerm constantLinearDampingTerm, float minFloaterEntitialBottomPos, float maxFloaterEntitialTopPos, ref DragForceComputationResult dragComputationResult, out float lateralDragForwardShift)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ComputeAngularDrag(float fixedDt, int substepCount, in Vec3 globalAngularVelocity, in MatrixFrame centerOfMassGlobalFrame, in Vec3 massSpaceLocalInertia, in NavalPhysicsParameters physicsParameters, in BuoyancyComputationResult buoyancyComputationResult, in Vec3 angularDragTerm, in Vec3 angularDampingTerm, float angularDragYSideComponentTerm, float angularDampingYSideComponentTerm, ref DragForceComputationResult dragComputationResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec3 ComputeVelocityFactorForClampingDrag(Vec3 absLinearVelocityLocal)
	{
		throw null;
	}
}
