using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ComponentInterfaces;

public class DefaultSiegeEngineCalculationModel : MissionSiegeEngineCalculationModel
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
	public DefaultSiegeEngineCalculationModel()
	{
		throw null;
	}
}
