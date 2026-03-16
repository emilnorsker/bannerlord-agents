using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class BattleEndLogic : MissionLogic, IBattleEndLogic
{
	public enum ExitResult
	{
		False,
		NeedsPlayerConfirmation,
		SurrenderSiege,
		True
	}

	private IMissionAgentSpawnLogic _missionAgentSpawnLogic;

	private MissionTime _enemySideNotYetRetreatingTime;

	private MissionTime _playerSideNotYetRetreatingTime;

	private BasicMissionTimer _checkRetreatingTimer;

	private bool _isEnemySideRetreating;

	private bool _isPlayerSideRetreating;

	private bool _isEnemySideDepleted;

	private bool _isPlayerSideDepleted;

	private bool _isEnemyDefenderPulledBack;

	private bool _canCheckForEndCondition;

	private bool _canCheckForEndConditionSiege;

	private bool _enemyDefenderPullbackEnabled;

	private int _troopNumberNeededForEnemyDefenderPullBack;

	private bool _missionEndedMessageShown;

	private bool _victoryReactionsActivated;

	private bool _victoryReactionsActivatedForRetreating;

	private bool _scoreBoardOpenedOnceOnMissionEnd;

	public bool PlayerVictory
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool EnemyVictory
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEnemySideRetreating
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool _notificationsDisabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeCanCheckForEndCondition(bool canCheckForEndCondition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ExitResult TryExit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableEnemyDefenderPullBack(int neededTroopNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNotificationDisabled(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIsEnemySideRetreatingOrOneSideDepleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleEndLogic()
	{
		throw null;
	}
}
