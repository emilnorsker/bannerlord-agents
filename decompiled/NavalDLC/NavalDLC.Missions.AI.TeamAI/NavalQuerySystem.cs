using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.TeamAI;

public class NavalQuerySystem
{
	private readonly MBList<Tuple<Formation, Vec2>> _temporaryFormationPositionTupleContainer;

	private readonly MBList<MissionShip> _temporaryMissionShipContainer;

	private readonly Dictionary<(MissionShip, MissionShip), bool> _shipsInCriticalZoneContainer;

	private readonly QueryData<Vec2> _averageShipPosition;

	private readonly QueryData<Vec2> _averageEnemyShipPosition;

	private readonly QueryData<MBReadOnlyList<Formation>> _formationsInShipsInLeftToRightOrder;

	private readonly QueryData<MBReadOnlyList<MissionShip>> _enemyShipsInLeftToRightOrder;

	private readonly QueryData<MBReadOnlyList<MissionShip>> _enemyShipsWithFormationsInLeftToRightOrder;

	private readonly QueryData<MBReadOnlyList<MissionShip>> _teamShipsWithFormationsInLeftToRightOrder;

	private readonly QueryData<Dictionary<(MissionShip, MissionShip), bool>> _shipInCriticalZoneDictionary;

	private readonly QueryData<float> _closestDistanceSquaredToEnemyShip;

	private NavalShipsLogic _navalShipsLogic;

	private Team _team;

	public Vec2 AverageShipPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 AverageEnemyShipPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Formation> FormationsInShipsInLeftToRightOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MissionShip> EnemyShipsInLeftToRightOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MissionShip> EnemyShipsWithFormationsInLeftToRightOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MissionShip> TeamShipsWithFormationsInLeftToRightOrder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float ClosestDistanceSquaredToEnemyShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalQuerySystem(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceExpireSameSideShipLists()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceExpireAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyShipInCriticalZoneBetween(MissionShip ship1, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTelemetryScopeNames()
	{
		throw null;
	}
}
