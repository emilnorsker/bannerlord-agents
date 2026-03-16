using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public abstract class DeploymentMissionController : MissionLogic
{
	protected readonly bool IsPlayerAttacker;

	protected bool IsPlayerControllerSetToNone;

	protected BattleSideEnum PlayerSide;

	protected BattleSideEnum EnemySide;

	protected bool AfterSetupTeamsCalled;

	public bool TeamSetupOver
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

	public event Action OnAfterSetupTeams
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeploymentMissionController(bool isPlayerAttacker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinishDeployment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentControllerSetToPlayer(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetupAgentAIStatesForSide(BattleSideEnum battleSide)
	{
		throw null;
	}

	protected abstract void OnAfterStart();

	protected abstract void OnSetupTeamsOfSide(BattleSideEnum side);

	protected abstract void OnSetupTeamsFinished();

	protected abstract void BeforeDeploymentFinished();

	protected abstract void AfterDeploymentFinished();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetupAIOfEnemySide(BattleSideEnum enemySide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetupAIOfEnemyTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HideAgentsOfSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnhideAgentsOfSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreOrderGesturesEnabled_AdditionalCondition()
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
	private void SwapTeams()
	{
		throw null;
	}
}
