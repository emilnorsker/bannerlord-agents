using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TacticalPosition : MissionObject
{
	public enum TacticalPositionTypeEnum
	{
		Regional,
		HighGround,
		ChokePoint,
		Cliff,
		SpecialMissionPosition
	}

	private WorldPosition _position;

	private Vec2 _direction;

	private float _oldWidth;

	[EditableScriptComponentVariable(true, "")]
	private float _width;

	[EditableScriptComponentVariable(true, "")]
	private float _slope;

	[EditableScriptComponentVariable(true, "")]
	private bool _isInsurmountable;

	[EditableScriptComponentVariable(true, "")]
	private bool _isOuterEdge;

	private List<TacticalPosition> _linkedTacticalPositions;

	[EditableScriptComponentVariable(true, "")]
	private TacticalPositionTypeEnum _tacticalPositionType;

	[EditableScriptComponentVariable(true, "")]
	private TacticalRegion.TacticalRegionTypeEnum _tacticalRegionMembership;

	[EditableScriptComponentVariable(true, "")]
	private FormationAI.BehaviorSide _tacticalPositionSide;

	public WorldPosition Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public Vec2 Direction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Slope
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInsurmountable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsOuterEdge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<TacticalPosition> LinkedTacticalPositions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public TacticalPositionTypeEnum TacticalPositionType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TacticalRegion.TacticalRegionTypeEnum TacticalRegionMembership
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationAI.BehaviorSide TacticalPositionSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticalPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticalPosition(WorldPosition position, Vec2 direction, float width, float slope = 0f, bool isInsurmountable = false, TacticalPositionTypeEnum tacticalPositionType = TacticalPositionTypeEnum.Regional, TacticalRegion.TacticalRegionTypeEnum tacticalRegionMembership = TacticalRegion.TacticalRegionTypeEnum.Opening)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyChangesFromEditor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWidth(float width)
	{
		throw null;
	}
}
