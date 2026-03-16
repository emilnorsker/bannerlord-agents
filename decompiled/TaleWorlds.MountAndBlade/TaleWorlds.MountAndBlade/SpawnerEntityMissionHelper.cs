using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class SpawnerEntityMissionHelper
{
	private const string EnabledSuffix = "_enabled";

	public GameEntity SpawnedEntity;

	private GameEntity _ownerEntity;

	private SpawnerBase _spawner;

	private string _gameEntityName;

	private bool _fireVersion;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnerEntityMissionHelper(SpawnerBase spawner, bool fireVersion = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity SpawnPrefab(GameEntity parent, string entityName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void InstantiateEntity(GameEntity parent, string entityName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveChildEntity(GameEntity child)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SyncMatrixFrames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CallSetSpawnedFromSpawnerOfScripts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPrefabName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object GetFieldValue(object src, string propName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool HasField(object obj, string propertyName)
	{
		throw null;
	}
}
