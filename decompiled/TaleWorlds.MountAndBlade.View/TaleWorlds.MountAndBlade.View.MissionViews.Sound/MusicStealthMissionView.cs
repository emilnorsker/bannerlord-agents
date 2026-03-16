using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Sound;

public class MusicStealthMissionView : MissionView, IMusicHandler
{
	private enum WarningSoundState
	{
		None,
		Neutral,
		Cautious,
		PatrollingCautious,
		Alarmed
	}

	private const string StealthNotificationSoundEventId = "event:/ui/stealth/stealth_notification_b";

	private const string AgentStateParameterName = "agent_state";

	private static object _lockObject;

	private List<Agent> _cautiousAgents;

	private List<Agent> _patrollingCautiousAgents;

	private List<Agent> _detectedAgents;

	private List<Agent> _combatAgents;

	private Dictionary<Agent, SoundEvent> _stealthNotificationSoundEvents;

	private WarningSoundState _warningSoundState;

	bool IMusicHandler.IsPausable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMusicHandler.OnUpdated(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentAlarmedStateChanged(Agent agent, AIStateFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIntensityChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckWarningSoundStateChange(Agent relatedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WarningSoundState GetIntendedWarningSoundState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeWarningSoundState(WarningSoundState newState, Agent relatedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicStealthMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MusicStealthMissionView()
	{
		throw null;
	}
}
