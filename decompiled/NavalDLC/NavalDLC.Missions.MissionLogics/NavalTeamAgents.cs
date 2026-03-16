using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

internal class NavalTeamAgents
{
	private struct TroopCountData
	{
		private int _nonHeroOriginsCount;

		private int _heroOriginsCount;

		private int _nonHeroAgentsCount;

		private int _heroAgentsCount;

		public int NonHeroOriginsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int HeroOriginsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int NonHeroAgentsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int HeroAgentsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int OriginsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public int AgentsCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Add(in NavalTroopAssignment troop)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Remove(in NavalTroopAssignment troop)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Equals(in TroopCountData other)
		{
			throw null;
		}
	}

	internal readonly BattleSideEnum BattleSide;

	internal readonly TeamSideEnum TeamSide;

	internal readonly NavalAgentsLogic AgentsLogic;

	private readonly HashSet<IAgentOriginBase> _allTroopOrigins;

	private readonly HashSet<IAgentOriginBase> _allHeroOrigins;

	private readonly MBList<NavalShipAgents> _allShipAgents;

	private readonly Dictionary<IAgentOriginBase, NavalTroopAssignment> _unassignedTroops;

	private readonly Dictionary<Agent, NavalShipAgents> _agentToShipAgents;

	private readonly MBSortedMultiList<int, NavalTroopAssignment> _unassignedOrderedTroops;

	private TroopCountData _unassignedTroopCountData;

	private readonly Dictionary<Agent, MissionShip> _unassignedReservedAgents;

	private MBList<Agent> _tempSpawnedAgentsList;

	private MBList<NavalTroopAssignment> _tempUnassignedTroops;

	private MBList<NavalShipAgents> _tempShipsWithMissingTroops;

	private MBList<Agent> _tempIncompatibleAgentsList;

	private MBList<IAgentOriginBase> _tempIncompatibleReservesList;

	private MBList<Agent> _tempAgentsNotUsingMachines;

	private MBList<Agent> _recentlySwappedAgents;

	internal IReadOnlyCollection<IAgentOriginBase> AllTroopOrigins
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal IReadOnlyCollection<IAgentOriginBase> AllHeroOrigins
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int NumberOfSpawnedAgents
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

	internal int NumberOfActiveTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal int NumberOfUnassignedTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool SpawnReinforcementsOnTick
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

	public bool RestrictRecentlySwappedAgentTransfers
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal NavalTeamAgents(NavalAgentsLogic agentsLogic, BattleSideEnum battleSide, TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddAgentToShip(Agent agent, MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveAgentFromShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool AddReservedTroopToShip(IAgentOriginBase troopOrigin, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int AddReservedTroopsToShip(MBList<IAgentOriginBase> troopOrigins, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveReservedTroopFromShip(IAgentOriginBase troopOrigin, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveReservedTroopsFromShip(MBList<IAgentOriginBase> troopOrigins, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int RemoveReservedTroopsFromShip(MissionShip ship, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void RemoveAllReservedTroopsFromShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool TransferAgentToShip(Agent agent, MissionShip targetShip, bool swapAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignCaptainToShip(Agent captainAgent, MissionShip targetShip, bool swapOnTransfer, MissionShip captainsCurrentShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnassignCaptainOfShip(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal IAgentOriginBase FindTroopOrigin(Predicate<IAgentOriginBase> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int FindTroopOrigins(Predicate<IAgentOriginBase> predicate, ref MBList<IAgentOriginBase> foundOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsTroopUnassigned(IAgentOriginBase troopOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsTroopInShipReserves(IAgentOriginBase origin, out MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsAgentOnAnyShip(IAgentOriginBase origin, out Agent agent, out MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsAgentOnAnyShip(Agent agent, out MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool IsAgentOnShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBReadOnlyList<Agent> GetActiveAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetActiveTroopsCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBReadOnlyList<Agent> GetActiveAgentsOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetReservedTroopsCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void FillReservedTroopsOfShip(MissionShip ship, MBList<IAgentOriginBase> reservedTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBReadOnlyList<Agent> GetActiveHeroesOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AutoComputeDesiredTroopCountsPerShip(bool loadBalanceShips, int troopLimitFromBattleSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetDesiredTroopCountOfShip(MissionShip ship, int desiredTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetDesiredTroopCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetIgnoreTroopCapacities(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetIgnoreTroopCapacities(MissionShip ship, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int SpawnNextBatch(bool isReinforcement, MBList<Agent> spawnedAgents = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetSpawnReinforcementsOnTick(bool value, bool resetShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetSpawnReinforcementsForShip(MissionShip ship, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool GetSpawnReinforcementsForShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int CheckSpawnReinforcements(MBList<Agent> spawnedAgents = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeReinforcementTimers(bool randomizeTimers, bool autoComputeDurations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetReinforcementSpawnDurationOfShip(MissionShip ship, float duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AutoComputeReinforcementSpawnDurations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ClearRecentlySwappedAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnAgentRemoved(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipSpawned(MissionShip ship, bool ignoreTroopCapacities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipRemoved(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipCaptured(MissionShip ship, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipTransferredToFormation(MissionShip ship, Formation oldFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnEndDeploymentMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetManagedAgentFormation(Agent agent, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetManagedCaptainOfFormation(Agent captain, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddTroopOrigin(IAgentOriginBase origin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool SpawnExistingHero(IAgentOriginBase heroOrigin, MissionShip ship, out Agent spawnedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignAndTeleportCrewToShipMachines(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignAndTeleportCrewToShipMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnassignTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetTroopTraitsFilter(MissionShip ship, TroopTraitsMask troopTraitsFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnassignIncompatibleTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnassignExcessTroopsFromShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetTroopClassFilter(MissionShip ship, TroopTraitsMask troopClassFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTroopOriginAux(IAgentOriginBase troopOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveTroopOriginAux(IAgentOriginBase troopOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AddReservedTroopToShipAux(IAgentOriginBase agentOrigin, NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RemoveReservedTroopFromShipAux(NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTemporaryShipsWithMissingTroopsAux(int shipIndex, NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TryGetShipAgents(MissionShip ship, out NavalShipAgents shipAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnqueueUnassignedTroop(in NavalTroopAssignment troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DequeueUnassignedTroop(IAgentOriginBase troopOrigin, out NavalTroopAssignment dequeuedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DequeueUnassignedTroop(out NavalTroopAssignment dequeuedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignTroops(bool useDynamicTroopTraits = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DequeueUnassignedAgent(out NavalTroopAssignment dequeuedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnqueueReservedTroop(in NavalTroopAssignment troop, NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool RemoveReservedTroopFromShipAux(IAgentOriginBase troopOrigin, NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NavalTroopAssignment DequeueReservedTroop(NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DequeueReservedTroop(IAgentOriginBase troopOrigin, NavalShipAgents shipAgentsData, out NavalTroopAssignment dequeuedTroop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TransferReservedTroop(NavalShipAgents fromShipAgentsData, NavalShipAgents toShipAgentsData, IAgentOriginBase troopOrigin = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnassignAgentAux(NavalShipAgents shipAgentsData, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Agent ReassignAgentAux(NavalShipAgents shipAgentsData, Agent agent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetRestrictRecentlySwappedAgentTransfers(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAgentAux(Agent agent, NavalShipAgents shipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveAgentAux(Agent agent, NavalShipAgents targetShipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TransferAgentAux(Agent agent, NavalShipAgents originShipAgentsData, NavalShipAgents targetShipAgentsData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeSpaceForOneAgent(NavalShipAgents shipAgentsData, bool ignorePlayerTroop = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeSpaceInReserves(NavalShipAgents shipAgentsData)
	{
		throw null;
	}
}
