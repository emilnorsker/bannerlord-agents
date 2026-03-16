using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.Missions;

namespace TaleWorlds.MountAndBlade;

public class MissionSiegeEnginesLogic : MissionLogic
{
	private readonly MissionSiegeWeaponsController _defenderSiegeWeaponsController;

	private readonly MissionSiegeWeaponsController _attackerSiegeWeaponsController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionSiegeEnginesLogic(List<MissionSiegeWeapon> defenderSiegeWeapons, List<MissionSiegeWeapon> attackerSiegeWeapons)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMissionSiegeWeaponsController GetSiegeWeaponsController(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMissionSiegeWeapons(out IEnumerable<IMissionSiegeWeapon> defenderSiegeWeapons, out IEnumerable<IMissionSiegeWeapon> attackerSiegeWeapons)
	{
		throw null;
	}
}
