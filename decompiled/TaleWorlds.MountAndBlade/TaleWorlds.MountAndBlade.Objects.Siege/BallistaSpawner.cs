using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Objects.Siege;

public class BallistaSpawner : SpawnerBase
{
	[EditorVisibleScriptComponentVariable(true)]
	public string AddOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public string RemoveOnDeployTag;

	[EditorVisibleScriptComponentVariable(true)]
	public float DirectionRestrictionDegree;

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
	public BallistaSpawner()
	{
		throw null;
	}
}
