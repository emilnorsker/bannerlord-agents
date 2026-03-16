using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class SpawnerBase : ScriptComponentBehavior
{
	public class SpawnerPermissionField : EditorVisibleScriptComponentVariable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public SpawnerPermissionField()
		{
			throw null;
		}
	}

	[EditorVisibleScriptComponentVariable(true)]
	public string ToBeSpawnedOverrideName;

	[EditorVisibleScriptComponentVariable(true)]
	public string ToBeSpawnedOverrideNameForFireVersion;

	protected SpawnerEntityEditorHelper _spawnerEditorHelper;

	protected SpawnerEntityMissionHelper _spawnerMissionHelper;

	protected SpawnerEntityMissionHelper _spawnerMissionHelperFire;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void AssignParameters(SpawnerEntityMissionHelper _spawnerMissionHelper)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnerBase()
	{
		throw null;
	}
}
