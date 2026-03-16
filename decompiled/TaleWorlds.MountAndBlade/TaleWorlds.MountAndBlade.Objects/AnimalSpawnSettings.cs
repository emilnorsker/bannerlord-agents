using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Objects;

public class AnimalSpawnSettings : ScriptComponentBehavior
{
	public bool DisableWandering;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckAndSetAnimalAgentFlags(GameEntity spawnEntity, Agent animalAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AnimalSpawnSettings()
	{
		throw null;
	}
}
