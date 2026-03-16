using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class MangonelSpawner : SpawnerBase
{
	[SpawnerPermissionField]
	public MatrixFrame projectile_pile;

	[EditorVisibleScriptComponentVariable(true)]
	public string AddOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string RemoveOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_a_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_b_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_c_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_d_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_e_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_f_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_g_enabled;

	[EditorVisibleScriptComponentVariable(true)]
	public bool ammo_pos_h_enabled;

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
	public MangonelSpawner()
	{
		throw null;
	}
}
