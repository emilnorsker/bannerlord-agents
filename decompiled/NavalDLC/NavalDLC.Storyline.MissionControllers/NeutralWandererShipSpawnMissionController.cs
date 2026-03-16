using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline.MissionControllers;

public class NeutralWandererShipSpawnMissionController : MissionLogic
{
	private class WandererShipData
	{
		public readonly int TagNumber;

		public readonly GameEntity SpawnPointEntity;

		private readonly List<GameEntity> _targetPoints;

		private bool _isTargetReversed;

		public MissionShip WandererShip
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

		public GameEntity CurrentTarget
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
		public WandererShipData(int tagNumber, GameEntity spawnPointEntity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddTargetPoint(GameEntity targetPoint)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetWandererShip(MissionShip ship)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ChangeToNextTarget()
		{
			throw null;
		}
	}

	private enum WandererShipControllerState
	{
		None,
		SpawnShips,
		SpawnTroops,
		MoveShips,
		End
	}

	private const string WandererShipSpawnPointTagExpression = "wanderer_ship(_\\d+)*_spawnpoint";

	private const string WandererShipTargetPointTagExpression = "wanderer_ship(_\\d+)*_target(_\\d+)*";

	private readonly List<string> _wandererShipIdList;

	private readonly List<string> _wandererShipTroopIdList;

	private readonly List<WandererShipData> _wandererShipData;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private Queue<Formation> _availableNeutralFormations;

	private WandererShipControllerState _currentState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NeutralWandererShipSpawnMissionController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterMissionCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectWandererShipData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnWandererShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(string shipHullId, GameEntity spawnPoint, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnWandererShipTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleWandererShipMovements()
	{
		throw null;
	}
}
