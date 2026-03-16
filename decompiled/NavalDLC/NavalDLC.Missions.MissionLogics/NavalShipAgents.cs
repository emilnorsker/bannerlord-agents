using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

internal class NavalShipAgents
{
	private readonly MBList<Agent> _activeAgents;

	private readonly MBList<Agent> _activeHeroAgents;

	private readonly MBList<Agent> _activeNonHeroAgents;

	private readonly MBSortedMultiList<int, NavalTroopAssignment> _reservedOrderedTroops;

	private readonly Dictionary<IAgentOriginBase, NavalTroopAssignment> _reservedTroops;

	private readonly MissionTimer _reinforcementTimer;

	private readonly NavalTeamAgents _teamAgents;

	private TroopTraitsMask _compatibilityTraitsFilter;

	public TroopTraitsMask TroopClassFilter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public TroopTraitsMask TroopTraitsFilter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal MBReadOnlyList<Agent> ActiveAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MBReadOnlyList<Agent> ActiveHeroAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MBReadOnlyList<Agent> ActiveNonHeroAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MBSortedMultiList<int, NavalTroopAssignment> ReservedTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int ReservedHeroesCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal int ReservedNonHeroesCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int ReservedTroopsCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int AllTroopsCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal MissionShip Ship
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal bool CanAddMoreReserves
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool CanAddMoreAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool SpawnReinforcements
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal bool IgnoreCapacityChecks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal bool HasPlayerAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int DesiredTroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	internal bool HasMissingTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int MissingTroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int MissingAgentCountOnMainDeck
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool HasMissingAgentsOnMainDeck
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal float TroopFillRatio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal NavalShipAgents(MissionShip ship, NavalTeamAgents teamAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeReinforcementTimer(bool randomizeTimers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetReinforcementSpawnDuration(float duration = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetIgnoreCapacityChecks(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetSpawnReinforcements(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetTroopClassFilter(TroopTraitsMask troopClassFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetTroopTraitsFilter(TroopTraitsMask troopTraitsFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsAgentCompatibleWithShip(Agent agent, bool checkDynamicCompatibility = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsTroopCompatibleWithShip(IAgentOriginBase troopOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetTraitsFilterPriority(NavalTroopAssignment troopAssignment, bool checkDynamicCompatibility = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsTroopCompatibleWithClassFilter(TroopTraitsMask troopClassMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsTroopCompatibleWithTraitsFilter(TroopTraitsMask troopTraitsMask, int troopBattleTier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipCaptured(MissionShip newShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetDesiredTroopCount(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsOriginInReserves(IAgentOriginBase origin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void EnqueueReservedTroop(in NavalTroopAssignment troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool DequeueReservedTroop(out NavalTroopAssignment dequeuedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool DequeueReservedTroop(IAgentOriginBase origin, out NavalTroopAssignment dequeuedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void FillReservedTroops(MBList<IAgentOriginBase> reservedTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal (int spawnedCount, int reassignedCount) SpawnNextBatch(bool isReinforcement, MBList<Agent> spawnedAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int CheckSpawnReinforcements(MBList<Agent> spawnedAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Agent SpawnHeroFromReserve(IAgentOriginBase heroOrigin, out bool isReassigned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignAndTeleportCrewToShipMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnEndDeploymentMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnAgentAux(IAgentOriginBase agentOrigin, bool isReinforcement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent ReassignFromUnassignedReserves(NavalTroopAssignment suppliedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Agent GetMinimumPriorityActiveAgent(MBList<Agent> agentsToIgnore = null)
	{
		throw null;
	}
}
