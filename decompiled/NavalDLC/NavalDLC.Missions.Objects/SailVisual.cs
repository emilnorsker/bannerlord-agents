using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Objects;

namespace NavalDLC.Missions.Objects;

[ScriptComponentParams("ship_visual_only", "sail_visual")]
public class SailVisual : ScriptComponentBehavior
{
	internal struct BurningRecord
	{
		internal List<BurningSystem> SailFires;

		internal BurningSystem MastFire;

		internal float SailLengthZ;

		internal BurningSystem YardLeftFire;

		internal float FireDt;

		internal BurningSystem YardRightFire;

		internal float YardFireStartDt;

		internal List<BurningSystem> RotatorFires;

		internal float RotatorFireStartDt;

		internal Color InitialYardMastColor;

		internal List<BurningSystem> StabilizerFires;

		internal bool BurningFinished;

		internal List<BurningSystem> FoldFires;

		internal List<BurningSystem> StaticRopeFires;

		internal float SailLengthX;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal BurningRecord(bool _ = false)
		{
			throw null;
		}
	}

	internal struct SailFoldProgress
	{
		internal const float FoldUnfoldSoundEventAnimationDxStopThreshold = 0.875f;

		internal float CurrentProgress;

		internal float RealProgress;

		internal bool FoldIsOngoing;

		internal bool UnfoldIsOngoing;

		internal int NumberOfMorphKeys;

		internal Vec3[] LeftVertexPositions;

		internal Vec3[] RightVertexPositions;

		internal Vec3[] CenterVertexPositions;

		internal Vec3 CurrentLeftFreeBonePosition;

		internal Vec3 CurrentRightFreeBonePosition;

		internal Vec3 CurrentCenterFreeBonePosition;

		internal SoundEvent FoldUnfoldSoundEvent;

		internal bool ShouldMakeFoldUnfoldSound;

		internal bool ShouldStopFoldUnfoldSound;
	}

	internal struct LateenSailData
	{
		internal GameEntity RollRotationEntity;

		internal GameEntity YardShiftEntity;

		internal float LastYawSection;

		internal float RollRotationAnimProgress;

		internal float RollRotationRealDt;

		internal bool RollRotationInProgress;

		internal float RollRotationInitial;

		internal float RollRotationTarget;

		internal float YardShiftInitial;

		internal float YardShiftTarget;

		internal SoundEvent RollAnimationSoundEvent;
	}

	internal struct PulleyDataCache
	{
		internal GameEntity Entity;

		internal PulleySystem PulleySystem;
	}

	internal struct SimpleRopeRecord
	{
		internal GameEntity ParentEntity;

		internal GameEntity RopeEntity;

		internal GameEntity TargetEntity;

		internal RopeSegment RopeSegment;

		internal bool StartPointAttachedToYard;

		internal bool EndPointAttachedToYard;

		internal bool IsBigRope;
	}

	internal struct KnobConnectionPoint
	{
		internal Vec3 ShipLocalPosition;

		internal Vec3 GlobalPosition;

		internal bool IsFixed;

		internal bool RightOfYard;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void UpdateGlobalPosition(Vec3 pos)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void UpdateRightOfYard(bool value)
		{
			throw null;
		}
	}

	internal class FreeBoneRecord
	{
		internal MatrixFrame InitialLocalFrame;

		internal MatrixFrame CurrentLocalFrame;

		internal Vec3 CurrentFrameWithoutRandomWind;

		internal GameEntity Entity;

		internal PulleyDataCache FoldSailPulley;

		internal List<PulleyDataCache> RotatorPulleys;

		internal List<PulleyDataCache> StabilityPulleys;

		internal List<SimpleRopeRecord> StabilityRopes;

		internal sbyte BoneIndex;

		internal FreeBoneConnectionType ConnectionType;

		internal FreeBoneType BoneType;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FreeBoneRecord()
		{
			throw null;
		}
	}

	internal class FlagCaptureAnimation
	{
		internal bool AnimationInProgress;

		internal Texture NewBannerTexture;

		internal float DtTillStart;

		internal bool MaterialSet;

		internal float BannerWindFactor;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FlagCaptureAnimation()
		{
			throw null;
		}
	}

	internal enum FreeBoneConnectionType
	{
		All,
		Closest,
		ClosestTwo
	}

	public enum SailType
	{
		SquareSail,
		LateenSail
	}

	internal enum KnobTypeEnum
	{
		Bollard,
		Cleat,
		Belaying
	}

	internal enum FreeBoneType
	{
		Left,
		Right,
		Center
	}

	internal enum LevelForEditor
	{
		None,
		Lvl1,
		Lvl2,
		Lvl3
	}

	private const string SailMeshEntityTag = "sail_mesh_entity";

	private const string StaticFoldedSailMeshEntityTag = "folded_static_entity";

	private const string SailTopBannerTag = "bd_banner_b";

	private const string FreeBoneTag = "free_bone";

	private const string RollRotationEntityTag = "roll_rotation_entity";

	private const string YawRotationEntityTag = "yaw_rotation_entity";

	private const string YardShiftEntityTag = "yard_shift";

	private const string SailYardEntityTag = "sail_yard";

	private const string PulleySystemsParentTag = "pulley_systems_parent";

	private const string FoldPulleysParentTag = "sail_fold_pulleys";

	private const string RotatePulleysParentTag = "sail_rotate_pulleys";

	private const string StabilityRopesParentTag = "stability_ropes_parent";

	private const string StaticRopesParentTag = "static_ropes_parent";

	private const string MastEntityTag = "mast_entity";

	private const string SimpleRopeTag = "simple_rope";

	private const string SimpleRopeStartTag = "simple_rope_start";

	private const string SimpleRopeEndTag = "simple_rope_end";

	private const string AttachedToYardTag = "attached_to_yard";

	private const string KnobPointsParentTag = "knob_points_parent";

	private const string KnobPointTag = "knot_point";

	private const string KnobPointDynamicTag = "dynamic_knob";

	private const string YardMeshEntity = "yard_mesh";

	private const string SailMeshBurningEntity = "sail_mesh_free_entity";

	private const string SquareSailLvl3ShiftEntityTag = "lvl3_shift_entity";

	private const string SquareSailLvl3Visibilitytag = "lvl3_lateens";

	private const string SquareSailLvl3MeshHoldertag = "lvl3_lateens_entity";

	private const string SquareSailLvl3FoldedParentTag = "lvl3_lateens_folded";

	private const string BallistaVisibilityRopeTag = "ballista_visibility";

	private const string TopFlagRopeTag = "flag_capture_rope";

	private static readonly string[] ClothFragmentPrefabs;

	private const float InvisibleDistanceSquared = 22500f;

	private const float LinearDistanceSquared = 2025f;

	private static readonly int SailUnfoldSoundEventId;

	private static readonly int SailFoldSoundEventId;

	private static readonly int LateenSailRollSoundEventId;

	private List<KnobConnectionPoint> _knobConnectionPoints;

	[EditableScriptComponentVariable(true, "Fold Sail Duration")]
	private float _foldSailDuration;

	[EditableScriptComponentVariable(true, "Folded Sail Transition Duration")]
	private float _foldedSailTransitionDuration;

	[EditableScriptComponentVariable(true, "Fold Free Bone Reset Duration")]
	private float _foldFreeBoneResetDuration;

	[EditableScriptComponentVariable(true, "Unfold Sail Duration")]
	private float _unfoldSailDuration;

	[EditableScriptComponentVariable(true, "Fold Sail Step Multiplier")]
	private float _foldSailStepMultiplier;

	[EditableScriptComponentVariable(true, "Lateen Yard Shift")]
	private float _lateenYardShift;

	[EditableScriptComponentVariable(true, "Lateen Roll Change Degree Limit")]
	private float _lateenRollChangeDegreeLimit;

	[EditableScriptComponentVariable(true, "Lateen Roll Change Animation Duration")]
	private float _lateenRollChangeAnimationDuration;

	[EditableScriptComponentVariable(true, "Lateen Roll Change Animation Step Multiplier")]
	private float _lateenRollChangeAnimationStepMultiplier;

	[EditableScriptComponentVariable(true, "Lateen Roll Change Yard Shift Start")]
	private float _lateenRollChangeYardShiftStart;

	[EditableScriptComponentVariable(true, "Lateen Roll Change Yard Shift Duration")]
	private float _lateenRollChangeYardShiftDuration;

	[EditableScriptComponentVariable(true, "Lateen Roll Change Yard Shift Acceleration")]
	private float _lateenRollChangeYardShiftAcceleration;

	[EditableScriptComponentVariable(true, "Lateen Roll Degrees")]
	private float _lateenRollDegrees;

	[EditableScriptComponentVariable(true, "Rope Connection Max Distance")]
	private float _ropeConnectionMaxDistance;

	[EditableScriptComponentVariable(true, "Knob Type")]
	private KnobTypeEnum _knobType;

	[EditableScriptComponentVariable(true, "Place Knobs")]
	private SimpleButton _placeKnobButton;

	[EditableScriptComponentVariable(true, "Knob Color")]
	private Color _placeKnobColor;

	[EditableScriptComponentVariable(true, "Start Fire")]
	private SimpleButton _startFireButton;

	[EditableScriptComponentVariable(true, "Place Cloth Fragments")]
	private SimpleButton _placeClothFragments;

	[EditableScriptComponentVariable(true, "Sail Type")]
	private SailType _sailType;

	[EditableScriptComponentVariable(true, "Burning Animation Duration")]
	private float _burningAnimationDuration;

	private LateenSailData _lateenSailData;

	[EditableScriptComponentVariable(true, "Square Lvl3 Mast Shift")]
	private float _squareLvl3MastShift;

	[EditableScriptComponentVariable(true, "Editor Only Level Selection")]
	private LevelForEditor _editorOnlyLevelSelection;

	[EditableScriptComponentVariable(true, "Top Lateen Fire Material")]
	private Material _topLateenFireMaterial;

	[EditableScriptComponentVariable(true, "Editor Only Ship Health")]
	private float _editorOnlyShipHealth;

	[EditableScriptComponentVariable(true, "Top Flag Rope Position")]
	private float _topFlagRopePosition;

	[EditableScriptComponentVariable(true, "Capture Flag Bottom Rope Position")]
	private float _captureTheFlagBottomPosition;

	[EditableScriptComponentVariable(true, "Start Capture The Flag Animation")]
	private SimpleButton _startCaptureTheFlagAnimation;

	private SailFoldProgress _ongoingAnimationData;

	private readonly List<FreeBoneRecord> _freeBones;

	private readonly List<SimpleRopeRecord> _simpleRopes;

	private readonly List<SimpleRopeRecord> _mastRopes;

	private Skeleton _sailSkeleton;

	private float _totalFoldDuration;

	private float _totalUnfoldDuration;

	private float _mastClipDistanceFromOrigin;

	private GameEntity _mastEntity;

	private GameEntity _yardEntity;

	private Mesh _foldedStaticSailMesh;

	private GameEntity _foldedStaticSailEntity;

	private GameEntity _knobParent;

	private SimpleRopeRecord _topFlagRope;

	private GameEntity _burningSailEntity;

	private Mesh _burningSailMesh;

	private Vec3 _currentFrameGlobalWind;

	private Mesh _yardMesh;

	private MatrixFrame _previousYawEntityFrame;

	private MatrixFrame _previousSailYardFrame;

	private float _cumulativeDt;

	private int _resetClothMeshFrameCounter;

	private bool _ropesAreInvisibleThisFrame;

	private bool _ropesWereInvisibleLastFrame;

	private bool _ropesWereLinearLastFrame;

	private bool _lodCheckFirstFrame;

	private List<WeakGameEntity> _topLateenSails;

	private List<WeakGameEntity> _topLateenFoldedSails;

	private List<WeakGameEntity> _ballistaVisibilityRopes;

	private int _ballistaRopeEnableFrameCounter;

	private int _currentSailLevelUsed;

	private BurningRecord _burningRecord;

	private bool _isBurning;

	private float _sailEntityAlpha;

	private float _lastMorphAnimKeySet;

	private int _remainingFramesForAnimation;

	private float _foldAnimWindReductionFactor;

	private FlagCaptureAnimation _captureTheFlagAnimation;

	public float TotalFoldDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TotalUnfoldDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ClothSimulatorComponent SailClothComponent
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

	public GameEntity SailSkeletonEntity
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

	public GameEntity SailYawRotationEntity
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

	public ClothSimulatorComponent SailTopBannerClothComponent
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

	public GameEntity SailTopBannerEntity
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

	public SailType Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipVisual ShipVisual
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

	public bool SailEnabled
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

	public bool SoundsEnabled
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

	public bool FoldAnimationEnabled
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
	internal SailVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
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
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool SkeletonPostIntegrateCallback(AnimResult result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBoundingBoxValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSaveAsPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshSailVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateForcedWindOfSailsAndTopBanner(float dt, Vec3 globalBannerRelativeWindVelocity, in Vec3 sailRelativeGlobalWindVelocity, in Vec3 globalSailForce)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFoldSailDuration(float foldSailDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFoldSailStepMultiplier(float foldSailStepMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUnfoldSailDuration(float unfoldSailDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSailEntityAlpha(float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InstantCloseSails()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckForProblemsInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlaceKnobs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetKnobColors()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FetchSailLevel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckClothResetTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSailMaterialWrtLevel(Mesh mesh, int sailLevel, bool isEditorScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustSquareSailSpecificLevelData(int sailLevel, bool isEditorScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustLevelOfSail(int sailLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyRandomWindToRope(ref Vec3 position, float factor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetButtomRopePositions(float dt, bool disableWind)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FoldUnfoldSoundEventTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickRopesAndPulleys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FindClosestPointFallback(Vec3 position, List<KnobConnectionPoint> records)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FindClosestKnobPointWind(Vec3 position, Vec3 shipLocalPosition, List<KnobConnectionPoint> records, bool sideOfYard, Vec2 windDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (int, int) FindClosestTwoKnobPointWind(Vec3 position, Vec3 shipLocalPosition, List<KnobConnectionPoint> records, bool sideOfYard, Vec2 windDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FindClosestKnobPoint(Vec3 position, Vec3 shipLocalPosition, List<KnobConnectionPoint> records, bool sideOfYard)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (int, int) FindClosestTwoKnobPoint(Vec3 position, Vec3 shipLocalPosition, List<KnobConnectionPoint> records, bool sideOfYard)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckFoldAnimationState(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableMorphAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMorphAnimToCloth(float currentMorphKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickLateenSail(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetClothMeshMaxDistance(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFoldAnimation(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickUnfoldAnimation(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitSailFoldAnimationResources()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartFoldAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartUnfoldAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CancelAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasFoldFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasUnfoldFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTotalFoldDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTotalUnfoldDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleLOD()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float ComputeSquareSailProgressMultiplier(float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float EstimateSquareSailFoldAnimationDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SimpleRopeRecord FillSimpleRopeRecord(WeakGameEntity parentEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlaceClothFragmentsRandomly(int seed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitLateenSailData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePreviousYardFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFire(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PositionSailFireParticles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlaceTopFlag(float dx)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFlagCaptureAnimation(float dt)
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
	private void ComputeMastClipPlane()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMastClipPlane()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetDimensions(in MatrixFrame shipFrame, bool isLateen, out float width, out float height, out Vec3 center)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBallistaRopeVisibility(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartFlagCaptureAnimation(Texture newTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SailVisual()
	{
		throw null;
	}
}
