using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class NavalAgentsLogic : MissionLogic
{
	public const float MinReinforcementsDuration = 0.5f;

	public const float MaxReinforcementsDuration = 3f;

	private readonly bool[] _ignoreTroopCapacities;

	private readonly MBList<NavalTeamAgents> _teamAgentsData;

	private bool _isDeploymentMode;

	public NavalShipsLogic NavalShipsLogic
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

	public bool IsDeploymentMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDeploymentFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMissionEnding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<IAgentOriginBase, MissionShip> TroopAddedToReserves
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<IAgentOriginBase, MissionShip> TroopRemovedFromReserves
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Agent, MissionShip> AgentAddedToShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Agent, MissionShip> AgentRemovedFromShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalAgentsLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentCreated(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTeamAgentsData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnReinforcementsOnTick(bool value, bool resetShips = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnReinforcementsOnTick(TeamSideEnum teamSide, bool value, bool resetShips = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetSpawnReinforcementsOnTick(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIgnoreTroopCapacities(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIgnoreTroopCapacities(MissionShip ship, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRestrictRecentlySwappedAgentTransfers(TeamSideEnum teamSide, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetRestrictRecentlySwappedAgentTransfers(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearRecentlySwappedAgentsData(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IAgentOriginBase FindTroopOrigin(TeamSideEnum teamSide, Predicate<IAgentOriginBase> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int FindTroopOrigins(TeamSideEnum teamSide, Predicate<IAgentOriginBase> predicate, ref MBList<IAgentOriginBase> foundOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IReadOnlyCollection<IAgentOriginBase> GetTeamTroopOrigins(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IReadOnlyCollection<IAgentOriginBase> GetTeamHeroOrigins(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfSpawnedAgents(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfActiveAgents(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<Agent> GetActiveAgentsOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetReservedTroopsCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationClass GetNavalMissionTroopClass(BattleSideEnum battleSide, BasicCharacterObject agentCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillReservedTroopsOfShip(MissionShip ship, MBList<IAgentOriginBase> reservedTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<Agent> GetActiveHeroesOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentOnAnyShip(Agent agent, out MissionShip onShip, TeamSideEnum teamSide = (TeamSideEnum)(-1))
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetActiveHeroCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTroopOriginInShipReserves(TeamSideEnum teamSide, IAgentOriginBase troopOrigin, out MissionShip onShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentToShip(Agent agent, MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgentFromShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AddReservedTroopToShip(IAgentOriginBase troopOrigin, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentOnAnyShip(IAgentOriginBase agentOrigin, out Agent foundAgent, out MissionShip onShip, TeamSideEnum teamSide = (TeamSideEnum)(-1))
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetActiveAgentCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAllReservedTroopsFromShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TransferAgentToShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SpawnNextBatch(TeamSideEnum teamSide, bool isReinforcement = false, MBList<Agent> spawnedAgents = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CheckSpawnReinforcements(TeamSideEnum teamSide, MBList<Agent> spawnedAgents = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeReinforcementTimers(TeamSideEnum teamSide, bool randomizeTimers = true, bool autoComputeDurations = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignCaptainToShip(Agent agent, MissionShip ship, MissionShip captainsCurrentShip = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignCaptainToShipForDeploymentMode(Agent agent, MissionShip targetShip, MissionShip captainsCurrentShip = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnassignCaptainOfShip(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UnassignCaptainOfShipForDeploymentMode(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDeploymentMode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTroopOrigin(TeamSideEnum teamSide, IAgentOriginBase troopOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTroopOrigins(TeamSideEnum teamSide, MBList<IAgentOriginBase> troopOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnassignTroops(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SpawnExistingHero(IAgentOriginBase heroOrigin, MissionShip ship, out Agent spawnedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AutoComputeDesiredTroopCountsPerShip(TeamSideEnum teamSide, bool loadBalanceShips = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssignTroops(TeamSideEnum teamSide, bool useDynamicTroopTraits = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InvokeAgentRemovedFromShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentUnassigned(Agent agent, TeamSideEnum teamSide = (TeamSideEnum)(-1))
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ComputeTeamTroopLimitAccordingToBattleSize(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDesiredTroopCountOfShip(MissionShip ship, int desiredTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTroopClassFilter(MissionShip ship, TroopTraitsMask troopClassFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InvokeAgentAddedToShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTroopTraitsFilter(MissionShip ship, TroopTraitsMask troopTraitsFilter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignAndTeleportCrewToShipMachines(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AssignAndTeleportCrewToShipMachines(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetTeamAgents(TeamSideEnum teamSide, out NavalTeamAgents teamAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InvokeTroopRemovedFromReserves(IAgentOriginBase troop, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InvokeTroopAddedToReserves(IAgentOriginBase troop, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnAgentSteppedShipChanged(Agent agent, MissionShip newShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipSpawned(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ComputeReinforcementSpawnDuration(int reservedTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipRemoved(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipTransferredToFormation(MissionShip ship, Formation oldFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipTransferredToTeam(MissionShip ship, Team oldTeam, Formation oldFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipCaptured(MissionShip ship, MissionShip ship2, Formation formation, Formation formation2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipTeleported(MissionShip ship, MatrixFrame oldFrame, MatrixFrame targetFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float GetAgentPriority(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TeleportAgentToFrame(Agent agent, in MatrixFrame teleportFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TeleportAndAssignAgentToMachine(Agent agent, NavalShipAgents agentShip, UsableMachine shipMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TryStopMachineUseAndReattachAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool TryUseMachineAndDetachAgent(Agent agent, NavalShipAgents ownerShipAgents, UsableMachine machine, bool teleportAndUseInstantly, out bool isDetached)
	{
		throw null;
	}
}
