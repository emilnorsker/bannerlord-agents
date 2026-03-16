using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects;

namespace SandBox;

public static class SandBoxHelpers
{
	public static class MissionHelper
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void FollowAgent(Agent agent, Agent target)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void UnfollowAgent(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void FadeOutAgents(IEnumerable<Agent> agents, bool hideInstantly, bool hideMount)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void DisableGenericMissionEventScript(string triggeringObjectTag, GenericMissionEvent missionEvent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnPlayer(bool civilianEquipment = false, bool noHorses = false, bool noWeapon = false, bool wieldInitialWeapons = false, string spawnTag = "")
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnPlayer(GameEntity spawnPosition, bool civilianEquipment = false, bool noHorses = false, bool noWeapon = false, bool wieldInitialWeapons = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<Agent> SpawnHorses()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnSheeps()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnCows()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnGeese()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnChicken()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void SpawnHogs()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void SimulateAnimalAnimations(Agent agent)
		{
			throw null;
		}
	}

	public static class MapSceneHelper
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool[] GetRegionMapping(PartyNavigationModel model)
		{
			throw null;
		}
	}
}
