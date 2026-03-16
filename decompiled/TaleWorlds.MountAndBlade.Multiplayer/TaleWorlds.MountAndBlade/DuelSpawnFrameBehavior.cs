using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DuelSpawnFrameBehavior : SpawnFrameBehaviorBase
{
	private const string AreaSpawnPointTagExpression = "spawnpoint_area(_\\d+)*";

	private const string AreaSpawnPointTagPrefix = "spawnpoint_area_";

	private List<GameEntity>[] _duelAreaSpawnPoints;

	private bool[] _spawnPointSelectors;

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
	public DuelSpawnFrameBehavior()
	{
		throw null;
	}
}
