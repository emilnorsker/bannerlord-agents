using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class WallSegment : SynchedMissionObject, IPointDefendable, ICastleKeyPosition
{
	private const string WaitPositionTag = "wait_pos";

	private const string MiddlePositionTag = "middle_pos";

	private const string AttackerWaitPositionTag = "attacker_wait_pos";

	private const string SolidChildTag = "solid_child";

	private const string BrokenChildTag = "broken_child";

	[EditableScriptComponentVariable(true, "")]
	private int _properGroundOutsideNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _properGroundInsideNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _underDebrisOutsideNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _underDebrisInsideNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _overDebrisOutsideNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _overDebrisInsideNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _underDebrisGenericNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _overDebrisGenericNavmeshID;

	[EditableScriptComponentVariable(true, "")]
	private int _onSolidWallGenericNavmeshID;

	public string SideTag;

	public TacticalPosition MiddlePosition
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

	public TacticalPosition WaitPosition
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

	public TacticalPosition AttackerWaitPosition
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

	public IPrimarySiegeWeapon AttackerSiegeWeapon
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

	public IEnumerable<DefencePoint> DefencePoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public bool IsBreachedWall
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

	public WorldFrame MiddleFrame
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

	public WorldFrame DefenseWaitFrame
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

	public WorldFrame AttackerWaitFrame
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

	public FormationAI.BehaviorSide DefenseSide
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
	public Vec3 GetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WallSegment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool MovesEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnChooseUsedWallSegment(bool isBroken)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool OnCheckForProblems()
	{
		throw null;
	}
}
