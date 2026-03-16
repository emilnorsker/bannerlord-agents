using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class BatteringRamSpawner : SpawnerBase
{
	private const float _modifierFactorUpperLimit = 1.2f;

	private const float _modifierFactorLowerLimit = 0.8f;

	[SpawnerPermissionField]
	public MatrixFrame wait_pos_ground;

	[EditorVisibleScriptComponentVariable(true)]
	public string SideTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string GateTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string PathEntityName;

	[EditorVisibleScriptComponentVariable(true)]
	public int BridgeNavMeshID_1;

	[EditorVisibleScriptComponentVariable(true)]
	public int BridgeNavMeshID_2;

	[EditorVisibleScriptComponentVariable(true)]
	public int DitchNavMeshID_1;

	[EditorVisibleScriptComponentVariable(true)]
	public int DitchNavMeshID_2;

	[EditorVisibleScriptComponentVariable(true)]
	public int GroundToBridgeNavMeshID_1;

	[EditorVisibleScriptComponentVariable(true)]
	public int GroundToBridgeNavMeshID_2;

	[EditorVisibleScriptComponentVariable(true)]
	public string AddOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string RemoveOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public float SpeedModifierFactor;

	public bool EnableAutoGhostMovement;

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
	public BatteringRamSpawner()
	{
		throw null;
	}
}
