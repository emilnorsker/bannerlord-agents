using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

[ScriptComponentParams("ship_visual_only", "pulley_system")]
internal class PulleySystem : ScriptComponentBehavior
{
	private struct SegmentData
	{
		internal RopeSegment RopeSegment;

		internal GameEntity RopeEntity;
	}

	private const string PulleyTag = "pulley";

	private const string PulleyWheelTag = "pulley_wheel";

	private const string PulleyLeftPointTag = "pulley_left_point";

	private const string PulleyRightPointTag = "pulley_right_point";

	private const string EndPointRopeTag = "end_point_rope";

	private const string EndPointTargetTag = "end_point_target";

	private const string AttachedToYardTag = "attached_to_yard";

	private const string FreePileTag = "free_pile";

	[EditableScriptComponentVariable(true, "End Rope Length")]
	private float _endRopeLength;

	private GameEntity _pulleyEntity;

	private GameEntity _pulleyWheelEntity;

	private GameEntity _pulleyLeftRopeConnectionEntity;

	private GameEntity _pulleyRightRopeConnectionEntity;

	private List<RopeSegment> _tiedToYardSegments;

	private List<SegmentData> _fixedSegments;

	private List<SegmentData> _freeSegments;

	private SegmentData _endPointRope;

	private GameEntity _endTargetEntity;

	private Vec3 _targetPositionLocalPrevFrame;

	private float _endRopeConnectionOffset;

	private float _looseAmountMultiplier;

	private bool _firstTick;

	public WeakGameEntity FirstFixedEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<RopeSegment> TiedToYardSegments
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PulleySystem()
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
	protected override void OnTickParallel2(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputePulleyFrame(float move_amount, float total_rope_length)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float SetRopeParamsForSegment(WeakGameEntity pulleyRopeConnectPoint, SegmentData segmentData, bool isFixed, float pull_amount, bool moveUV, bool is_end_rope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEndTargetPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLinearMode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DeregisterRopeSegmentCosmetics(RopeSegmentCosmetics cosmetics)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FetchRopeSegmentsForSide(WeakGameEntity parentEntity, bool isFixed, ref List<SegmentData> output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRuntimeLooseMultiplier(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyBoundingBox(MatrixFrame parentFrame, ref BoundingBox bb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTiePointCenter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFirstFreeGlobalPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFirstFixedGlobalPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillBurningRecord(BurningSystem system)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlpha(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllRopeSegments(ref List<RopeSegment> segments, float maximumRopeThickness)
	{
		throw null;
	}
}
