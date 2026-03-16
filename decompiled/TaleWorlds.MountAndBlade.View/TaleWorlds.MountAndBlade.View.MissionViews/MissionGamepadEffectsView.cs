using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine.Options;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

[DefaultView]
public class MissionGamepadEffectsView : MissionView
{
	private enum TriggerState
	{
		Off,
		SoftTriggerFeedbackLeft,
		SoftTriggerFeedbackRight,
		HardTriggerFeedbackLeft,
		HardTriggerFeedbackRight,
		WeaponEffect,
		Vibration
	}

	private TriggerState _triggerState;

	private readonly byte[] _triggerFeedback;

	private bool _isAdaptiveTriggerEnabled;

	private bool _usingAlternativeAiming;

	private RangedSiegeWeapon _currentlyUsedSiegeWeapon;

	private UsableMissionObject _currentlyUsedMissionObject;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGamepadActiveStateChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateDeactivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
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
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNativeOptionChanged(NativeOptionsType changedNativeOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMissionModeApplicableForAdaptiveTrigger(MissionMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleBowAdaptiveTriggers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCrossbowAdaptiveTriggers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleThrowableAdaptiveTriggers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleMeleeAdaptiveTriggers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleRangedSiegeEngineAdaptiveTriggers(RangedSiegeWeapon rangedSiegeWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private UsableMachine GetUsableMachineFromUsableMissionObject(UsableMissionObject usableMissionObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTriggerState(TriggerState triggerState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetTriggerFeedback()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTriggerFeedback(byte leftTriggerPosition, byte leftTriggerStrength, byte rightTriggerPosition, byte rightTriggerStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTriggerWeaponEffect(byte leftStartPosition, byte leftEnd_position, byte leftStrength, byte rightStartPosition, byte rightEndPosition, byte rightStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetTriggerVibration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTriggerVibration(float[] leftTriggerAmplitudes, float[] leftTriggerFrequencies, float[] leftTriggerDurations, int numLeftTriggerElements, float[] rightTriggerAmplitudes, float[] rightTriggerFrequencies, float[] rightTriggerDurations, int numRightTriggerElements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetLightbarColor(float red, float green, float blue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGamepadEffectsView()
	{
		throw null;
	}
}
