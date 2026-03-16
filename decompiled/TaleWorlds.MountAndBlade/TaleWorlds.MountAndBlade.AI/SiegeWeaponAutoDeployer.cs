using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.Missions;

namespace TaleWorlds.MountAndBlade.AI;

public class SiegeWeaponAutoDeployer
{
	private IMissionSiegeWeaponsController siegeWeaponsController;

	private List<DeploymentPoint> deploymentPoints;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeWeaponAutoDeployer(List<DeploymentPoint> deploymentPoints, IMissionSiegeWeaponsController weaponsController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeployAll(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DeployWeaponFrom(DeploymentPoint dp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeployAllForAttackers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeployAllForDefenders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float GetWeaponValue(Type weaponType)
	{
		throw null;
	}
}
