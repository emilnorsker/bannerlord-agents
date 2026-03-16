using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public struct FormationSceneSpawnEntry
{
	public readonly FormationClass FormationClass;

	public readonly GameEntity SpawnEntity;

	public readonly GameEntity ReinforcementSpawnEntity;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationSceneSpawnEntry(FormationClass formationClass, GameEntity spawnEntity, GameEntity reinforcementSpawnEntity)
	{
		throw null;
	}
}
