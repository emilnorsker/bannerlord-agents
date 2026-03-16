using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions;

public class AgentNavalAIComponent : AgentComponent
{
	public enum AgentNavalTaunts
	{
		Invite,
		Invite2,
		Point
	}

	private const float CheckBridgeAndTargetingAgentCooldown = 3f;

	private const float BarkCooldown = 1.5f;

	private const float MissionStartTauntWaitTime = 10f;

	private const float LowMoraleThreshold = 30f;

	private const float MediumMoraleThreshold = 70f;

	private const float HighMoraleThreshold = 100f;

	private float _tauntTimer;

	private float _barkTimer;

	private float _checkBridgesAndTargetingAgentTimer;

	private float _tauntCooldown;

	private float _tauntDelayTimer;

	private float _barkDelayTimer;

	private float _tauntDelay;

	private float _barkDelay;

	private bool _tauntFired;

	private bool _barkFired;

	private AgentNavalComponent _agentNavalComponent;

	private NavalShipsLogic _navalShipsLogic;

	private ActionIndexCache _currentActionIndexCache;

	private SkinVoiceType _currentVoiceType;

	private bool _isConnectedToEnemyWithoutBridges;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentNavalAIComponent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UnderMeleeAttack(float timeLimit = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UnderRangedAttack(float timeLimit = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RangeAttacking(float timeLimit = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool MeleeAttacking(float timeLimit = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DecideBoardingTaunts()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DecideTaunt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteTaunt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteBark()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToTriggerTaunt(AgentNavalTaunts navalTaunt, float delay, float chanceToTrigger = 1f, bool makeTimerZeroIfSuccessful = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToTriggerBark(SkinVoiceType voiceType, float delay, float chanceToTrigger = 1f, bool makeTimerZeroIfSuccessful = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ActionIndexCache SelectActionForTaunt(AgentNavalTaunts navalTaunt)
	{
		throw null;
	}
}
