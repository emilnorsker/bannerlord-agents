using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Source.Missions;

public abstract class BaseBattleMissionController : MissionLogic
{
	protected readonly Game game;

	protected bool IsPlayerAttacker
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	protected int DeployedAttackerTroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	protected int DeployedDefenderTroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BaseBattleMissionController(bool isPlayerAttacker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetupTeam(Team team)
	{
		throw null;
	}

	protected abstract void CreateDefenderTroops();

	protected abstract void CreateAttackerTroops();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual TeamAIComponent GetTeamAI(Team team, float thinkTimerTime = 5f, float applyTimerTime = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void DebugTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool IsPlayerDead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canPlayerLeave)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void IncrementDeploymedTroops(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void CreatePlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void BecomeEnemy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void BecomePlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SwapTeams()
	{
		throw null;
	}
}
