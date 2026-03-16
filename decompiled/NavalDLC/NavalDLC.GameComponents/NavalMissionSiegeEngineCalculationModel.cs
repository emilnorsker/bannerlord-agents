using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace NavalDLC.GameComponents;

public class NavalMissionSiegeEngineCalculationModel : MissionSiegeEngineCalculationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateReloadSpeed(Agent userAgent, float baseSpeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateShipSiegeWeaponAmmoCount(IShipOrigin shipOrigin, Agent captain, RangedSiegeWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateDamage(Agent attackerAgent, float baseDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionSiegeEngineCalculationModel()
	{
		throw null;
	}
}
