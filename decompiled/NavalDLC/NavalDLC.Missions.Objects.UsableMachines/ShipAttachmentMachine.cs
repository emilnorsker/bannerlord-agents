using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Objects.UsableMachines;

public class ShipAttachmentMachine : UsableMachine
{
	public class ShipBridgeNavmeshHolder : MissionObject
	{
		private const float StepWidth = 0.8f;

		private Vec3 _startLeftPosition;

		private Vec3 _startRightPosition;

		private Vec3 _endLeftPosition;

		private Vec3 _endRightPosition;

		private int[] _customVertexIndices;

		private Vec3[] _bridgeCustomVertexPositionsArray;

		private PathFaceRecord _face1PathFaceRecord;

		private PathFaceRecord _face2PathFaceRecord;

		private Vec3 _rightVector;

		private Vec3 _leftVector;

		private int _attachedFaceCount;

		private ShipAttachment _currentAttachment;

		public int BridgeNavmeshId
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
		public int GetFace1GroupIndex()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetFace2GroupIndex()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize(int bridgeNavmeshId, ShipAttachmentMachine attachmentSource)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetCustomNavmeshVertexIndices(int v1, int v2, int v3, int v4, int v5, int v6)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetShipBridgeStartEndPositions(Vec3 startLeftPosition, Vec3 startRightPosition, Vec3 endLeftPosition, Vec3 endRightPosition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnDynamicNavmeshVertexUpdate()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipBridgeNavmeshHolder()
		{
			throw null;
		}
	}

	public class ShipBridge : MissionObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipBridge()
		{
			throw null;
		}
	}

	public class ShipAttachmentJoint
	{
		private const string RopeSnapSoundEvent = "event:/mission/movement/vessel/rope_snap";

		private const float LeftoverImpulseDecay = 0.9f;

		private readonly int RopeStressSoundEventId;

		private readonly GameEntity _shipSource;

		private readonly GameEntity _shipTarget;

		private readonly MissionShip _shipSourceScript;

		private readonly MissionShip _shipTargetScript;

		private readonly ShipAttachmentMachine _attachmentEntitySource;

		private readonly ShipAttachmentPointMachine _attachmentEntityTarget;

		private float _age;

		private float _stiffness;

		private bool _unbreakableJoint;

		private Vec3 _ropeLeftoverImpulse;

		private Vec3 _bridgeDirectionLeftoverImpulse;

		private Vec3 _bridgeAlignmentLeftoverImpulse;

		private Vec3 _bridgeXYLeftoverImpulse;

		private ShipAttachment.ShipAttachmentState _currentAttachmentState;

		private float _currentPullSpeed;

		private float _prevDistanceLambda;

		private float _ropesPullDt;

		private NavalShipsLogic _navalShipsLogic;

		private SoundEvent _ropeStressSoundEvent;

		public float AccumulatedDistanceError
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

		public float AccumulatedXYError
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

		public float AccumulatedAlignmentError
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

		public float CurrentXYError
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

		public float CurrentAlignmentError
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

		public bool IsBroken
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

		public float CurrentDistanceError
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
		public ShipAttachmentJoint(ShipAttachmentMachine attachmentSource, ShipAttachmentPointMachine attachmentTarget, bool unbreakableJoint = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnBreak()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnFixedTick(float fixedDt, ShipAttachment currentAttachment, ref float currentRopeLength)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StabilizeShipUps(float correctionTorqueCoefficient)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UpdateRopeMinLength()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static float CalculatePossibleBridgeConnectionLengthSquared(ShipAttachmentMachine attachmentMachine, ShipAttachmentPointMachine attachmentPointMachine)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static float CalculatePossibleRopeMinLength(ShipAttachmentMachine attachmentMachine, ShipAttachmentPointMachine attachmentPointMachine)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InitializeJointParameters()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SmoothApproachRopeLength(float dt, ref float currentLength, float target)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateRopeLength(float fixedDt, ref float currentRopeLength, ShipAttachment currentAttachment)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Update(float fixedDt, ref float currentRopeLength, ShipAttachment currentAttachment)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AlignShips()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateRopeConstraint(float fixedDt, float currentRopeLength, MatrixFrame shipSourceGlobalFrame, MatrixFrame shipTargetGlobalFrame, Vec3 sourceAttachmentPosition, Vec3 targetAttachmentPosition, float sourceShipMass, float targetShipMass, Vec3 relativeVelocityVector)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float SolveSpringMassSystemFromTargetPeriod(float dt, float reducedMass, float targetPeriod, float dampingRatio, float distance, float relativeSpeed)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateBridgeConstraints(float dt, float currentRopeLength, MatrixFrame shipSourceGlobalFrame, MatrixFrame shipTargetGlobalFrame, Vec3 sourceAttachmentPosition, Vec3 targetAttachmentPosition, float sourceShipMass, float targetShipMass, Vec3 relativeVelocityVector)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private float SolveImpulseConstraint(float relativeVelocity, float positionError, float reducedMass, float beta, float damping, float fixedDt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ApplyConstraintImpulse(Vec3 impulse, MatrixFrame shipSourceGlobalFrame, MatrixFrame shipTargetGlobalFrame, Vec3 attachmentSourceGlobalPosition, Vec3 attachmentTargetGlobalPosition, float maxAcceleration, float sourceShipMass, float targetShipMass, float fixedDt, ref Vec3 leftoverImpulse)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CheckBreaking(float dt, ShipAttachment currentAttachment)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ReduceRelativeDrift(float linearDamping, float angularDamping)
		{
			throw null;
		}
	}

	public class ShipAttachment
	{
		public struct FlightData
		{
			public Vec3 SourceGlobalPosition;

			public Vec3 TargetGlobalPosition;

			public Vec3 GlobalPositionError;

			public Vec3 GlobalVelocity;

			public float AngleDegree;

			public float Time;

			public bool IsUnderWater;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public FlightData(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition, in Vec3 globalVelocity, float angleDegree, float time)
			{
				throw null;
			}
		}

		internal struct BridgeFlightData
		{
			internal float DtSinceFlightStart;

			internal float CurveLerpVelocity;

			internal float CurveLerpValue;

			internal float ThrowFinishValue;

			internal float CurrentFrameTotalLightTime;

			internal Vec3 CurrentFrameInitialVelocity;
		}

		internal struct RopeSegment
		{
			internal GameEntity ParentEntity;

			internal GameEntity RopeStart;

			internal GameEntity RopeEnd;

			internal int StartSegmentIndex;

			internal int EndSegmentIndex;

			internal float SideStartShift;

			internal float SideEndShift;
		}

		public enum ShipAttachmentState
		{
			RopeThrown,
			RopesPulling,
			BridgeThrown,
			BridgeConnected,
			BrokenAndWaitingForRemoval,
			RopeFailedAndReloading
		}

		private const string NavMeshHolderTag = "navmesh_holder";

		private const string HookImpactWater = "event:/mission/movement/vessel/hook_impact_fail_water_splash";

		private const string HookImpactAttachSuccess = "event:/mission/movement/vessel/hook_impact_attach";

		private const string HookImpactAttachFail = "event:/mission/movement/vessel/hook_impact_fail_to_attach";

		private const string HookThrowingSoundEvent = "event:/mission/movement/vessel/hook_throw";

		private const string BridgeThrownSoundEvent = "event:/mission/movement/vessel/bridge_connect";

		private const string BridgeBrokenSoundEvent = "event:/mission/movement/vessel/bridge_fall";

		private const string HookBeforeAttachmentSoundEvent = "event:/mission/movement/vessel/hook_attach_point_snap";

		private const float ForwardRotationLimitAngleCos = 0.17364818f;

		private const float RopesPullingInteractionDistanceSquared = 2500f;

		private const float BridgeConnectedInteractionDistanceSquared = 100f;

		private const float BridgeConnectedAngleCosLimit = 0.18f;

		private const int BridgeCurveLinearSampleCount = 16;

		private const int MaximumPlankCount = 80;

		private static readonly Comparer<KeyValuePair<float, Vec3>> _cacheCompareDelegate;

		private bool _attachmentInitializedByPlayer;

		private static List<string> _shipConnectionPlankVariations;

		private static List<string> _ropeClothFragmentPrefabList;

		private float _shipBetweenAttachmentsCheckTimer;

		private MissionTimer _ropesPullingTimer;

		private GameEntity _bridge;

		private GameEntity _navMeshBridge;

		private GameEntity _navMeshBridgeNavMeshHolder;

		private ShipBridgeNavmeshHolder _shipBridgeNavmeshHolder;

		private int _bridgeNavmeshId;

		private List<GameEntity> _planks;

		private List<GameEntity> _targetSafetyPlanks;

		private List<GameEntity> _sourceSafetyPlanks;

		private KeyValuePair<float, Vec3>[] _bridgeCurveLinearAccessCache;

		private int _previousNumberOfPlanksNeeded;

		private int _numberOfPlanksNeeded;

		private List<RopeSegment> _ropes;

		private BridgeFlightData _bridgeFlightData;

		private bool _isNavmeshBridgeDisabled;

		private float _plankVerticalSize;

		private float _plankHorizontalSize;

		private ShipAttachmentState _state;

		private PhysicsMaterial _woodPhysicsMaterialCached;

		private PhysicsMaterial _defaultPhysicsMaterialCached;

		private Vec3[] _sideBarrierQuadsCached;

		private UIntPtr _sideBarriersQuadPinnedPointer;

		private GCHandle _sideBarriersQuadPinnedGCHandler;

		private UIntPtr _sideBarriersIndicesPinnedPointer;

		private GCHandle _sideBarriersIndicesPinnedGCHandler;

		private int[] _sideBarrierIndicesCached;

		private Vec3[] _vFoldQuadsCached;

		private UIntPtr _vFoldQuadPinnedPointer;

		private GCHandle _vFoldQuadPinnedGCHandler;

		private UIntPtr _vFoldIndicesPinnedPointer;

		private GCHandle _vFoldIndicesPinnedGCHandler;

		private int[] _vFoldQuadsIndicesCached;

		private int[] _alreadyAddedVertexDataForPhysicsClipPlaneIntersection;

		private Vec3[] _registeredVerticesAfterPhysicsClipPlaneIntersection;

		private Vec3[] _quadVerticesCCWCached;

		private Vec3[] _currentFramePlankPhysicsVertices;

		private UIntPtr _currentFramePlankPhysicsVerticesPinnedPointer;

		private GCHandle _currentFramePlankPhysicsVerticesPinnedGCHandler;

		private int _currentFramePlankPhysicsVertexCount;

		private int[] _currentFramePlankPhysicsIndices;

		private int _currentFramePlankPhysicsIndexCount;

		private UIntPtr _currentFramePlankPhysicsIndicesPinnedPointer;

		private GCHandle _currentFramePlankPhysicsIndicesPinnedGCHandler;

		private bool _faceSwapSideOneDone;

		private bool _faceSwapSideTwoDone;

		private bool _bridgeCreated;

		private bool _hookAttachSoundAlreadyTriggered;

		private Timer _bridgeSwapTimer;

		private float _ropeThrownTimer;

		private MatrixFrame _hookGlobalFrame;

		private FlightData _launchFlightData;

		private bool _currentRopeLengthFirstReachedFinalValue;

		private float _currentRopeLength;

		public ShipAttachmentMachine AttachmentSource
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

		public ShipAttachmentPointMachine AttachmentTarget
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

		public Vec3 CommittedWeightedPosition
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

		public float CommittedTotalMass
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

		public float CommittedAgentCount
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

		public bool BridgeConnectionInteractionDistanceCheck
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

		public ShipAttachmentState State
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public MatrixFrame HookGlobalFrame
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool IsNavmeshConnected
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool ShipIslandsConnected
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

		public ShipAttachmentJoint ShipAttachmentJoint
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
		public void ClearCommittedAgentInformation()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetAttachmentState(ShipAttachmentState state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipAttachment(ShipAttachmentMachine attachmentSource, ShipAttachmentPointMachine attachmentTarget, in Vec3 globalPosition, in Vec3 globalDirection, bool bridgeConnectionInteractionDistanceCheck = true, bool attachmentInitializedByPlayer = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateAttachmentMachineEntityVisibilities(ShipAttachmentState oldState)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ShouldLookForBetterConnections()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnParallelTick(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnTick(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void CheckAndBreakAttachment(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InitializeRopeFlightDataAccordingToTargetPoint(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InitializeRopeFlightDataAccordingToTargetDirection(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalDirection)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Vec3 CalculateRelativeVelocityBetweenAttachments()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateRopeMeshVisualAccordingToTargetPoint(in Vec3 sourceGlobalPosition, in Vec3 targetGlobalPosition, float throwingAngleDegree)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CheckAndConnectBridge(bool forceBridge = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void InitializeShipAttachmentJoint(Vec3 attachmentSourceGlobalPosition, Vec3 attachmentTargetGlobalPosition, bool unbreakableJoint = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateRopeThrowingBehavior(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnFixedTick(float fixedDt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangeBarrier(GameEntity barrier, Vec3 startPosition, Vec3 endPosition, float height)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ConnectBridge()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetShieldsVisibility(bool visible)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangeNavmeshBridgeSideBarriersAndVFoldQuads()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangeVFoldQuads(Vec3 leftSource, Vec3 rightSource, Vec3 rightTarget, Vec3 leftTarget)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StartBridgeThrowAnimation()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void TickThrownBridge(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetOarsAvailability(bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddRopesToBridge()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangeNavMeshBridge(Vec3 leftSource, Vec3 rightSource, Vec3 leftTarget, Vec3 rightTarget)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Destroy()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Vec3 GetCurvePositionFromLength(float currentLength)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetRopeMeshParams(Mesh ropeMesh, Vec3 start, Vec3 end, float length)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Vec3 GetPositionAtProjectileCurveProgress(in Vec3 globalVelocity, in Vec3 sourceGlobalPosition, float time, float progressInterval)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetAbilityOfNavmeshBridgeFaces(bool enable)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsNavmeshBridgeEntityUpsideDown()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddNewClipPlaneIntersectionPoint(ref int numberOfValidVertices, in Vec3 currentCorner)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangePlankPhysicsWithClipPlanes(Vec3[] quadVerticesCCW, MatrixFrame firstClipFrame, MatrixFrame secondClipFrame)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int AddNewVertexToPlankPhysics(Vec3 vertex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddNewIndexToPlankPhysics(int index)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void TransformCurrentFramePlankPhysicsVerticesToPhysicsEntityLocal(Vec3 physicsEntityGlobalPosition)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SpawnPlankEntities()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void FillBridgeCurveAccessData(in Vec3 plankTargetOrigin, in Vec3 plankSourceOrigin, in float curvedLength)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangePlanksMT()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ArrangePlanks()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Vec3 GetLaunchProjectileCurrentGlobalPosition(float time)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static (Vec3, float) CalculateInitialVelocityAndTime(Vec3 initialPosition, Vec3 destination, float verticalLaunchAngleDegree)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float CalculateLaunchAngleDegree(Vec3 initialPosition, Vec3 targetPosition, float launchSpeed)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float CalculateInitialVelocityMagnitude(float distanceXY, float deltaZ, float thetaZ)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float CalculateDifferenceVectorAngle(in Vec3 initialPosition, in Vec3 destination)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ShipAttachment()
		{
			throw null;
		}
	}

	public const float AgentOarLeaveAttachmentLengthSquared = 64f;

	public const float AgentOarLeaveRelativeSpeedThreshold = 4f;

	public const float MaximumRopeLength = 40f;

	public const float MinimumBridgeDistanceToKeep = 2.2f;

	public const float MaximumRopesPullingDuration = 30f;

	public const float BridgeConnectionRelativeSpeedThreshold = 4f;

	public const float RopesPullingFrequency = 1f;

	public const float RopesPullingRelaxSpeed = 0.05f;

	public const float RopesPullingRelaxThresholdRatio = 0.75f;

	public const float RopesPullingPullSpeed = 0.65f;

	public const float RopesPullingPullAcceleration = 0.25f;

	public const float RopesPullingWaveAmp = 0.6f;

	public const float StiffnessRampTime = 5f;

	public const float MaxDistanceError = 10f;

	public const float MaxDistanceErrorBridge = 5f;

	public const float MaxXYError = 2.75f;

	public const float MaxAlignmentError = 0.95f;

	public const float MaxAccumulatedAlignmentError = 20f;

	public const float InteractionDistance = 40f;

	public const float FatigueRate = 4f;

	public const float RopeBeta = 0.1f;

	public const float StretchLimit = 2f;

	public const float Damping = 0.1f;

	public const float RopeMaxAccelerationLowTension = 1.2f;

	public const float RopeMaxAccelerationHighTension = 5f;

	public const float BridgeDirectionDampingRatio = 0.3f;

	public const float BridgeDirectionTargetPeriod = 2f;

	public const float BridgeDirectionMaxAcceleration = 5f;

	public const float AlignmentDampingRatio = 0.8f;

	private const bool CanConnectToFriends = false;

	public const float AlignmentTargetPeriod = 2f;

	public const float AlignmentMaxAcceleration = 5f;

	public const float XYDampingRatio = 0.5f;

	public const float XYTargetPeriod = 1f;

	public const float XYMaxAcceleration = 15f;

	public const float MaxInclineAngle = MathF.PI * 13f / 36f;

	private const string HookItemID = "hook";

	private const string HookGrabSoundEvent = "event:/mission/movement/vessel/hook_grab";

	public const string ConnectionClipPointTag = "connection_point";

	public const string RampBarrierTag = "connection_barrier";

	public const string RampCapsulePhysicsTag = "step_capsule";

	public const string RampSourceVisualTag = "bridge_source";

	public const string RampTargetVisualTag = "bridge_target";

	public const string PileHangedStaticVisualTag = "pile_hanged_static";

	public const string PileFloorStaticVisualTag = "pile_floor_static";

	[EditableScriptComponentVariable(true, "")]
	public int RelatedShipNavmeshOffset;

	private MissionShip _preferredTargetShip;

	private bool _checkedInitialConnections;

	private WeakGameEntity _staticRopeVisual;

	private ItemObject _hookItem;

	private GameEntity _focusObject;

	private MatrixFrame _initialHookLocalFrame;

	private MBList<GameEntity> _rampPhysicsList;

	private bool _physicsEntitiesVisibility;

	private Vec3[] _defaultPhysicsQuad;

	private int[] _defaultIndicesCached;

	private NavalShipsLogic _navalShipsLogicCached;

	public float BridgeConnectionLengthSquared
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

	public ShipAttachment CurrentAttachment
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

	public RopePileBaked RopeVisual
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

	public ShipAttachmentPointMachine LinkedAttachmentPointMachine
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

	public GameEntity ConnectionClipPlaneEntity
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

	public GameEntity RampBarrier
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

	public float RopeMinLength
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

	internal MBReadOnlyList<GameEntity> RampPhysicsList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal GameEntity RampVisualEntity
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

	public GameEntity BarrierSource
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

	public GameEntity BarrierTarget
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

	public GameEntity VFoldSource
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

	public GameEntity Hook
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

	public GameEntity VFoldTarget
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

	public GameEntity PlankBridgePhysicsEntity
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

	public PlankBridgeSteppedAgentManager SteppedAgentManager
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

	public bool IsShipAttachmentJointPhysicsEnabled
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

	public NavalShipsLogic NavalShipsLogicCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipAttachmentJointPhysicsEnabled(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsShipAttachmentMachineBridged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsShipAttachmentMachineBridgeWithEnemy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsShipAttachmentMachineConnectedToEnemy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DoesShipAttachmentMachineSatisfyOarsmenGetUpCondition(ShipAttachment currentAttachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool ShouldAutoLeaveDetachmentWhenDisabled(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Disable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetConnectionPhysicsEntitiesVisibility(bool visible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveConnectionPhysicsEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeConnectionPhysicsEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckAttachmentMachineFlags(bool editMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckCurrentAttachmentAndInitializeRopeBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPreferredTargetShip(MissionShip newTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShip GetPreferredTargetShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CalculateCanConnectToTargetShip(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOnCorrectSide(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanConnectToFriends(bool canConnectToFriends)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasCheckedInitialConnections()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConnectWithAttachmentPointMachine(ShipAttachmentPointMachine attachmentPointMachine, bool forceBridge = false, bool unbreakableBridge = false, bool connectionInitializedByPlayer = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipAttachmentPointMachine GetBestEnemyAttachment(bool checkAttachmentAlreadyExists = false, bool checkInteractionDistance = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisconnectAttachment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIntersectionsBetweenConnectionsAux(Vec2 attachmentMachineSourcePosition, Vec2 attachmentMachineTargetPosition, ShipAttachment testAttachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIntersectionsBetweenConnectionsWithState(ShipAttachmentMachine attachmentMachine, ShipAttachmentPointMachine attachmentPointMachine, ShipAttachment.ShipAttachmentState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckAttachmentsFacingEachOther(ShipAttachmentMachine attachmentMachine, ShipAttachmentPointMachine attachmentPointMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckIntersectionsBetweenConnections(ShipAttachmentMachine attachmentMachine, ShipAttachmentPointMachine attachmentPointMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsShipNearAttachmentMachines(MissionShip ship, MatrixFrame shipFrame, Vec2 sourceGlobalPos, Vec2 targetGlobalPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsShipBetweenAttachments(ShipAttachmentMachine attachmentMachineSource, ShipAttachmentPointMachine attachmentMachineTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool EarlyCrossCheckForShipIntersectingAttachmentMachine(Vec2[] physicsBoundingBoxPointsOfShip, Vec2 attachmentSourceGlobalPosition, Vec2 attachmentTargetGlobalPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsLineSegmentIntersectingShipBoundingXYPlane(Vec2[] physicsBoundingBoxPointsOfShip, Vec2 attachment0Position, Vec2 attachment1Position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ComputePotentialAttachmentValue(ShipAttachmentMachine attachmentSource, ShipAttachmentPointMachine attachmentTarget, bool checkInteractionDistance, bool checkConnectionBlock, bool allowWiderAngleBetweenConnections)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFixedTick(float fixedDt)
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
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipAttachmentMachine()
	{
		throw null;
	}
}
