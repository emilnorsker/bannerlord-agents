using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class AgentVictoryLogic : MissionLogic
{
	public enum CheerActionGroupEnum
	{
		None,
		LowCheerActions,
		MidCheerActions,
		HighCheerActions
	}

	public struct CheerReactionTimeSettings
	{
		public readonly float MinDuration;

		public readonly float MaxDuration;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CheerReactionTimeSettings(float minDuration, float maxDuration)
		{
			throw null;
		}
	}

	private class CheeringAgent
	{
		public readonly Agent Agent;

		public readonly bool IsCheeringOnRetreat;

		public bool GotOrderRecently
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

		public bool IsCheeringPaused
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
		public CheeringAgent(Agent agent, bool isCheeringOnRetreat)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OrderReceived()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void UpdatePauseState(bool shouldCheeringBePaused)
		{
			throw null;
		}
	}

	private const float HighCheerThreshold = 0.25f;

	private const float MidCheerThreshold = 0.75f;

	private const float YellIfOrderedInRetreatProbability = 0.25f;

	private CheerActionGroupEnum _cheerActionGroup;

	private CheerReactionTimeSettings _cheerReactionTimerData;

	private readonly ActionIndexCache[] _lowCheerActions;

	private readonly ActionIndexCache[] _midCheerActions;

	private readonly ActionIndexCache[] _highCheerActions;

	private ActionIndexCache[] _selectedCheerActions;

	private List<CheeringAgent> _cheeringAgents;

	private bool _isInRetreat;

	public CheerActionGroupEnum CheerActionGroup
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CheerReactionTimeSettings CheerReactionTimerData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MasterOrderControllerOnOrderIssued(OrderType orderType, IEnumerable<Formation> appliedFormations, OrderController orderController, object[] delegateparams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCheerActionGroup(CheerActionGroupEnum cheerActionGroup = CheerActionGroupEnum.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCheerReactionTimerSettings(float minDuration = 1f, float maxDuration = 8f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
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
	private void CheckAnimationAndVoice()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectVictoryCondition(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTimersOfVictoryReactionsOnBattleEnd(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterAgentForCheerCheck(Agent agent, bool isCheeringOnRetreat, float minReactionTime, float maxReactionTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTimersOfVictoryReactionsOnRetreat(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTimersOfVictoryReactionsOnTournamentVictoryForAgent(Agent agent, float minStartTime, float maxStartTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTimersOfVictoryReactionsForSingleAgent(Agent agent, float minStartTime, float maxStartTime, bool isCheeringOnRetreat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChooseWeaponToCheerWithCheerAndUpdateTimer(Agent cheerAgent, out bool resetTimer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfIsInRetreat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentVictoryLogic()
	{
		throw null;
	}
}
