using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Missions;

public class MissionSiegeWeaponsController : IMissionSiegeWeaponsController
{
	private readonly List<MissionSiegeWeapon> _weapons;

	private readonly List<MissionSiegeWeapon> _undeployedWeapons;

	private readonly Dictionary<DestructableComponent, MissionSiegeWeapon> _deployedWeapons;

	private BattleSideEnum _side;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionSiegeWeaponsController(BattleSideEnum side, List<MissionSiegeWeapon> weapons)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMaxDeployableWeaponCount(Type t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<IMissionSiegeWeapon> GetSiegeWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWeaponDeployed(SiegeWeapon missionWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWeaponUndeployed(SiegeWeapon missionWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWeaponHit(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWeaponDestroyed(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Type GetWeaponType(ScriptComponentBehavior weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Type GetSiegeWeaponBaseType(SiegeEngineType siegeWeaponType)
	{
		throw null;
	}
}
