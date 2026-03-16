using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class SallyOutMissionNotificationsHandler
{
	private enum NotificationType
	{
		SallyOutObjective,
		BesiegerSideStrenghtening,
		BesiegerSideReinforcementsSpawned,
		BesiegedSideTacticalRetreat,
		BesiegedSidePlayerPullbackRequest,
		SiegeEnginesDestroyed
	}

	private const float NotificationCheckInterval = 5f;

	private MissionAgentSpawnLogic _spawnLogic;

	private SallyOutMissionController _sallyOutController;

	private bool _isPlayerBesieged;

	private MBReadOnlyList<SiegeWeapon> _besiegerSiegeEngines;

	private Queue<NotificationType> _notificationsQueue;

	private BasicMissionTimer _notificationTimer;

	private bool _notificationTimerEnabled;

	private bool _objectiveMessageSent;

	private bool _siegeEnginesDestroyedMessageSent;

	private bool _besiegersStrengtheningMessageSent;

	private int _besiegerSpawnedTroopCount;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SallyOutMissionNotificationsHandler(MissionAgentSpawnLogic spawnLogic, SallyOutMissionController sallyOutController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBesiegedSideFallsbackToKeep()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMissionEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNotificationTimerEnabled(bool value, bool resetTimer = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckPeriodicNotifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendNotification(NotificationType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayNotificationSound(int soundId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInitialTroopsSpawned(BattleSideEnum battleSide, int numberOfTroopsSpawned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnReinforcementsSpawned(BattleSideEnum battleSide, int numberOfTroopsSpawned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsSiegeEnginesDestroyed()
	{
		throw null;
	}
}
