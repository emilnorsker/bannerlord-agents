using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Engine;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class LocationCharacterAgentSpawnedMissionEvent : EventBase
{
	public readonly LocationCharacter LocationCharacter;

	public readonly Agent Agent;

	public readonly WeakGameEntity SpawnedOnGameEntity;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LocationCharacterAgentSpawnedMissionEvent(LocationCharacter locationCharacter, Agent agent, WeakGameEntity spawnedOnGameEntity)
	{
		throw null;
	}
}
