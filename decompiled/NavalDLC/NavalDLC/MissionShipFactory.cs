using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC;

public class MissionShipFactory
{
	private static ulong _shipUniqueBitwiseIDNext;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionObject CreateMissionShip(int shipIndex, ShipAssignment shipAssignment, NavalShipsLogic shipsLogic, in MatrixFrame initialFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetShipUniqueBitwiseIDNext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CleanNonExistingUpgrades(WeakGameEntity shipEntity, List<ShipVisualSlotInfo> upgrades)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShipFactory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionShipFactory()
	{
		throw null;
	}
}
