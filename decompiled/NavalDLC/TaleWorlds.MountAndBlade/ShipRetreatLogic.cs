using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class ShipRetreatLogic : MissionLogic
{
	private const float RetreatCheckInterval = 5f;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private NavalBattleEndLogic _navalBattleEndLogic;

	private BasicMissionTimer _checkRetreatingTimer;

	private MBList<MissionShip> _tempRetreatedShips;

	private MBList<Agent> _tempOffShipAgents;

	private MBList<IAgentOriginBase> _tempRoutedReservedTroops;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipRetreatLogic()
	{
		throw null;
	}
}
