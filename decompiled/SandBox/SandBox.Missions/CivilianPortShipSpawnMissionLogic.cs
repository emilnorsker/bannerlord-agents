using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions;

public class CivilianPortShipSpawnMissionLogic : MissionLogic
{
	private const string ShipyardShipSpawnPointTag = "shipyard_ship";

	private Queue<GameEntity> _shipyardShipSpawnPoints;

	private List<Ship> _mainPartyShips;

	private List<Ship> _townLordShips;

	private Dictionary<GameEntity, MatrixFrame> _spawnedShipVisuals;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CivilianPortShipSpawnMissionLogic(List<Ship> mainPartyShips, List<Ship> townLordShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickShipAnimation(float dt, GameEntity shipVisualEntity, in MatrixFrame initialFrame)
	{
		throw null;
	}
}
