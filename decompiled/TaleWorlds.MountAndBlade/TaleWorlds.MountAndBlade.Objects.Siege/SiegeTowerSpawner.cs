using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class SiegeTowerSpawner : SpawnerBase
{
	private const float _modifierFactorUpperLimit = 1.2f;

	private const float _modifierFactorLowerLimit = 0.8f;

	[SpawnerPermissionField]
	public MatrixFrame wait_pos_ground;

	[EditorVisibleScriptComponentVariable(true)]
	public string SideTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string TargetWallSegmentTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string PathEntityName;

	[EditorVisibleScriptComponentVariable(true)]
	public int SoilNavMeshID1;

	[EditorVisibleScriptComponentVariable(true)]
	public int SoilNavMeshID2;

	[EditorVisibleScriptComponentVariable(true)]
	public int DitchNavMeshID1;

	[EditorVisibleScriptComponentVariable(true)]
	public int DitchNavMeshID2;

	[EditorVisibleScriptComponentVariable(true)]
	public int GroundToSoilNavMeshID1;

	[EditorVisibleScriptComponentVariable(true)]
	public int GroundToSoilNavMeshID2;

	[EditorVisibleScriptComponentVariable(true)]
	public int SoilGenericNavMeshID;

	[EditorVisibleScriptComponentVariable(true)]
	public int GroundGenericNavMeshID;

	[EditorVisibleScriptComponentVariable(true)]
	public string AddOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string RemoveOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public float RampRotationDegree;

	[EditorVisibleScriptComponentVariable(true)]
	public float BarrierLength;

	[EditorVisibleScriptComponentVariable(true)]
	public float SpeedModifierFactor;

	public bool EnableAutoGhostMovement;

	[SpawnerPermissionField]
	[RestrictedAccess]
	public MatrixFrame ai_barrier_l;

	[SpawnerPermissionField]
	[RestrictedAccess]
	public MatrixFrame ai_barrier_r;

	[EditorVisibleScriptComponentVariable(true)]
	public string BarrierTagToRemove;

	public float RampRotationRadian
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
	private void SetRampRotation(float unusedArgument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAIBarrierRight(float barrierScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAIBarrierLeft(float barrierScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorVariableChanged(string variableName)
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
	public SiegeTowerSpawner()
	{
		throw null;
	}
}
