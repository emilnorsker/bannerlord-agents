using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class SiegeLadderSpawner : SpawnerBase
{
	[SpawnerPermissionField]
	public MatrixFrame fork_holder;

	[SpawnerPermissionField]
	public MatrixFrame initial_wait_pos;

	[SpawnerPermissionField]
	public MatrixFrame use_push;

	[SpawnerPermissionField]
	public MatrixFrame stand_position_wall_push;

	[SpawnerPermissionField]
	public MatrixFrame distance_holder;

	[SpawnerPermissionField]
	public MatrixFrame stand_position_ground_wait;

	[EditorVisibleScriptComponentVariable(true)]
	public string SideTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string TargetWallSegmentTag;

	[EditorVisibleScriptComponentVariable(true)]
	public int OnWallNavMeshId;

	[EditorVisibleScriptComponentVariable(true)]
	public string AddOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string RemoveOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public float UpperStateRotationDegree;

	[EditorVisibleScriptComponentVariable(true)]
	public float DownStateRotationDegree;

	public float TacticalPositionWidth;

	[EditorVisibleScriptComponentVariable(true)]
	public string BarrierTagToRemove;

	[EditorVisibleScriptComponentVariable(true)]
	public string IndestructibleMerlonsTag;

	public float UpperStateRotationRadian
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DownStateRotationRadian
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
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
	private void OnLadderUpStateChange(float rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLadderDownStateChange(float unusedArgument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnPreInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AssignParameters(SpawnerEntityMissionHelper _spawnerMissionHelper)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeLadderSpawner()
	{
		throw null;
	}
}
