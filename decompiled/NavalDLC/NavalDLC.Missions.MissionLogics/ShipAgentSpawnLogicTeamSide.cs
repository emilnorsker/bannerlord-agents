using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

internal class ShipAgentSpawnLogicTeamSide
{
	private readonly ShipAgentSpawnLogic _agentSpawnLogic;

	private readonly NavalShipsLogic _shipsLogic;

	private readonly NavalAgentsLogic _agentsLogic;

	private readonly MBQueue<(Formation formation, IAgentOriginBase captainOrigin)> _pendingCaptainAssignments;

	private bool _updateShipsOnNextTick;

	private bool _troopSpawningActive;

	public BattleSideEnum BattleSide
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

	public TeamSideEnum TeamSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool TroopSpawningActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipAgentSpawnLogicTeamSide(ShipAgentSpawnLogic spawnLogic, BattleSideEnum battleSide, TeamSideEnum teamSide, MBList<IAgentOriginBase> troopOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentTick(float dt, Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AllocateAndDeployInitialTroops(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSpawnTroops(bool spawnTroops, bool enforceSpawn = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPendingCaptainAssignment(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReassignPendingCaptains()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBeforeShipRemoved(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AllocateAndDeployInitialTroopsOfPlayerTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AllocateAndDeployInitialTroopsOfTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CheckSpawnNextBatch()
	{
		throw null;
	}
}
