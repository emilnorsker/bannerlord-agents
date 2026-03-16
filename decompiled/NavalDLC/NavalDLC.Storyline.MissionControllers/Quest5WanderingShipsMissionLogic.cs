using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline.MissionControllers;

public class Quest5WanderingShipsMissionLogic : MissionLogic
{
	private const string PropShip1StringId = "nord_medium_ship";

	private const string PropShip2StringId = "eastern_heavy_ship";

	private const string PropShipTroopStringId = "gangster_1";

	private const int WayPoint1Count = 6;

	private const int WayPoint2Count = 6;

	private const float WayPointSuccessDistance = 10f;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private MissionShip _propShip1;

	private MissionShip _propShip2;

	private List<GameEntity> _wayPoints1;

	private List<GameEntity> _wayPoints2;

	private int _currentWaypointIndex1;

	private int _currentWaypointIndex2;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupPropShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeWaypoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPropShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(string shipHullId, string spawnPointId, Formation formation, bool spawnAnchored = false, List<KeyValuePair<string, string>> additionalUpgradePieces = null, Figurehead figurehead = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPropShipAgents(MissionShip ship, string troopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePropShipOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPhase2Started()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quest5WanderingShipsMissionLogic()
	{
		throw null;
	}
}
