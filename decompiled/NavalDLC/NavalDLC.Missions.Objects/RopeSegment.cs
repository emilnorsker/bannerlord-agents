using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.Objects;

[ScriptComponentParams("ship_visual_only", "rope_segment")]
internal class RopeSegment : ScriptComponentBehavior
{
	private const int BridgeCurveLinearSampleCount = 8;

	private const string PhysicsEntityTag = "rope_physics_body";

	private static readonly Comparer<KeyValuePair<float, Vec3>> _cacheCompareDelegate;

	private static float[] _physicsCheckPoints;

	[EditableScriptComponentVariable(true, "Segment Index")]
	private int _segmentIndex;

	[EditableScriptComponentVariable(true, "Is Fixed")]
	private bool _isFixed;

	[EditableScriptComponentVariable(true, "Loose Amount")]
	private float _looseAmount;

	[EditableScriptComponentVariable(true, "Default Rope Length")]
	private float _defaultRopeLength;

	[EditableScriptComponentVariable(true, "Uses Physics Body")]
	private bool _usesPhysicsBody;

	[EditableScriptComponentVariable(true, "Swing Multiplier")]
	private float _swingMultiplier;

	private KeyValuePair<float, Vec3>[] _bridgeCurveLinearAccessCache;

	private bool _firstTick;

	private Vec3 _previousPosition;

	private Vec3 _previousVelocity;

	private MatrixFrame _prevParentFrame;

	private float _pendulumVelocity;

	private float _pendulumCurrentRotation;

	private int _tickRemainingForPhysics;

	private GameEntity _endEntity;

	private GameEntity _physicsEntity;

	private Mesh _ropeMesh;

	private bool _externalEndEntitySet;

	private float _cumulativeTime;

	private MatrixFrame _currentFrameSwingFrame;

	private Vec3 _previousChangeDueToShip;

	private List<RopeSegmentCosmetics> _ropeSegmentCosmetics;

	private bool _dynamicMode;

	private List<float> _ropeSegmentCosmeticsDxCached;

	public float RuntimeLooseMultiplier
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

	public bool UseDistanceAsRopeLength
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

	public float BurnedClipFactor
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

	public bool BurnedClipReverseMode
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

	public Mesh RopeMesh
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public float CurrentRopeLength
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

	public bool LinearMode
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

	public float LooseAmount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public bool IsFixed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public int SegmentIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public float DefaultRopeLength
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public WeakGameEntity EndEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RopeSegment()
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
	protected override void OnTickParallel3(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
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
	private void TickAux(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetRopeShaderParams(Vec3 startPosition, Vec3 endPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetCurveDxFromDt(Vec3 startPosition, float currentLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetCurvePositionFromLength(Vec3 startPosition, float currentLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillBridgeCurveAccessData(in Vec3 plankTargetOrigin, in Vec3 plankSourceOrigin, in float curvedLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickCosmetics(Vec3 startPoint, Vec3 endPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckPhysicsEntity(in Vec3 startPosition, in Vec3 endPosition, float currentRotation, float nextRotation, float ropeLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickSwingPhysics(float dt, Vec3 startPoint, Vec3 endPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ShiftRope(float meters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyBoundingBox(MatrixFrame parentFrame, ref BoundingBox bb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUseDistanceAsRopeLength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEndEntity(WeakGameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsFixedEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRope(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLinearMode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRuntimeLooseMultiplier(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillBurningRecordForSegment(BurningSystem system, string prefabName, float nodeLength, bool reversePlacement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DeregisterRopeSegmentCosmetics(RopeSegmentCosmetics cosmetics)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsDynamic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlpha(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 CalculateAutoCurvePosition(Vec3 startPos, Vec3 endPos, float ropeLength, float dx)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RopeSegment()
	{
		throw null;
	}
}
