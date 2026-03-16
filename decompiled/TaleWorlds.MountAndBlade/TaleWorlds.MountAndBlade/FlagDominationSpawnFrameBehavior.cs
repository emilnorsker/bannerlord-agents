using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class FlagDominationSpawnFrameBehavior : SpawnFrameBehaviorBase
{
	private List<GameEntity>[] _spawnPointsByTeam;

	private List<GameEntity>[] _spawnZonesByTeam;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MatrixFrame GetSpawnFrame(Team team, bool hasMount, bool isInitialSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity GetBestZone(Team team, bool isInitialSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetBestSpawnPoint(List<GameEntity> spawnPointList, bool hasMount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FlagDominationSpawnFrameBehavior()
	{
		throw null;
	}
}
