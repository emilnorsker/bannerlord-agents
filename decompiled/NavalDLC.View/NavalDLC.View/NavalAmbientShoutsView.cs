using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View;

internal class NavalAmbientShoutsView : MissionView
{
	private enum Shouts
	{
		AllySinking,
		EnemySinking,
		GettingRammed,
		HooksLaunched,
		HooksLost,
		SailsDead,
		AllyShipGotHooked,
		ShipLowHealth,
		PlayerShipSinking,
		BoardingOrder,
		CutLooseOrder,
		Engaging
	}

	private const float RammingShoutCooldown = 15f;

	private const float HooksTimer = 15f;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private readonly Dictionary<MissionShip, float> _shipRammingShoutCooldown;

	private MissionTimer _hooksLaunchedTimer;

	private MissionTimer _shipGotHookedTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalAmbientShoutsView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipSunk(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipHookThrow(MissionShip hookingShip, MissionShip hookedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSailsDead(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipLowHealth(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCutLooseOrder(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBoardingOrder(MissionShip boardingShip, MissionShip boardedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBridgeConnected(MissionShip sourceShip, MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipAboutToBeRammed(MissionShip rammingShip, MissionShip rammedShip, float distance, float speedInRamDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipAttachmentLost(MissionShip hookingShip, MissionShip hookedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMainAgentOnTheShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayShoutFromShip(Shouts shoutType, MissionShip ship, int numberOfAgentsToShout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetEventName(Shouts shoutType)
	{
		throw null;
	}
}
