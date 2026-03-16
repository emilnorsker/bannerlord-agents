using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerAchievementComponent : MissionLogic
{
	private struct BoulderKillRecord
	{
		public readonly float Time;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BoulderKillRecord(float time)
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCacheAndInitializeAchievementVariables_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MultiplayerAchievementComponent _003C_003E4__this;

		private TaskAwaiter<int[]> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private const float SingleMangonelShotTimeout = 4f;

	private const string MaxMultiKillsWithSingleMangonelShotStatID = "MaxMultiKillsWithSingleMangonelShot";

	private const string KillsWithBoulderStatID = "KillsWithBoulder";

	private const string KillsWithChainAttackStatID = "KillsWithChainAttack";

	private const string KillsWithRangedHeadShotsStatID = "KillsWithRangedHeadshots";

	private const string KillsWithRangedMountedStatID = "KillsWithRangedMounted";

	private const string KillsWithCouchedLanceStatID = "KillsWithCouchedLance";

	private const string KillsWithHorseChargeStatID = "KillsWithHorseCharge";

	private const string KillCountCaptainStatID = "KillCountCaptain";

	private const string KillsWithStolenHorse = "KillsWithStolenHorse";

	private const string SatisfiedJackOfAllTradesStatID = "SatisfiedJackOfAllTrades";

	private const string PushedSomeoneOffLedgeStatID = "PushedSomeoneOffLedge";

	private int _cachedMaxMultiKillsWithSingleMangonelShot;

	private int _cachedKillsWithBoulder;

	private int _cachedKillsWithChainAttack;

	private int _cachedKillsWithRangedHeadShots;

	private int _cachedKillsWithRangedMounted;

	private int _cachedKillsWithCouchedLance;

	private int _cachedKillsWithHorseCharge;

	private int _cachedKillCountCaptain;

	private int _cachedKillsWithStolenHorse;

	private int _singleRoundKillsWithMeleeOnFoot;

	private int _singleRoundKillsWithMeleeMounted;

	private int _singleRoundKillsWithRangedOnFoot;

	private int _singleRoundKillsWithRangedMounted;

	private int _singleRoundKillsWithCouchedLance;

	private int _killsWithAStolenHorse;

	private bool _hasStolenMount;

	private MissionLobbyComponent _missionLobbyComponent;

	private MultiplayerRoundComponent _multiplayerRoundComponent;

	private Queue<BoulderKillRecord> _recentBoulderKills;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRoundStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentMount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentDismount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCacheAndInitializeAchievementVariables_003Ed__41))]
	private void CacheAndInitializeAchievementVariables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetStatInternal(string statId, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerAchievementComponent()
	{
		throw null;
	}
}
