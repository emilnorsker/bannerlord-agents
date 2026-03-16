using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

[DefaultView]
public class MissionMainAgentController : MissionView
{
	public enum OverrideMainAgentControlFlag
	{
		None = 0,
		Walk = 1,
		Run = 2,
		Crouch = 4,
		Stand = 8
	}

	public delegate void OnLockedAgentChangedDelegate(Agent newAgent);

	public delegate void OnPotentialLockedAgentChangedDelegate(Agent newPotentialAgent);

	private const float MinValueForAimStart = 0.2f;

	private const float MaxValueForAttackEnd = 0.6f;

	private float _lastForwardKeyPressTime;

	private float _lastBackwardKeyPressTime;

	private float _lastLeftKeyPressTime;

	private float _lastRightKeyPressTime;

	private float _lastWieldNextPrimaryWeaponTriggerTime;

	private float _lastWieldNextOffhandWeaponTriggerTime;

	private bool _activated;

	private bool _strafeModeActive;

	private bool _autoDismountModeActive;

	private bool _isPlayerAgentAdded;

	private bool _isPlayerAiming;

	private bool _isPlayerOrderOpen;

	private bool _isTargetLockEnabled;

	private MovementControlFlag _lastMovementKeyPressed;

	private Agent _lockedAgent;

	private Agent _potentialLockTargetAgent;

	private OverrideMainAgentControlFlag _overrideControlsThisFrame;

	private float _lastLockKeyPressTime;

	private float _lastLockedAgentHeightDifference;

	public readonly MissionMainAgentInteractionComponent InteractionComponent;

	public bool IsChatOpen;

	private bool _weaponUsageToggleRequested;

	public bool IsDisabled
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

	public Vec3 CustomLookDir
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

	public bool IsPlayerAiming
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent LockedAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public Agent PotentialLockTargetAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public event OnLockedAgentChangedDelegate OnLockedAgentChanged
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

	public event OnPotentialLockedAgentChangedDelegate OnPotentialLockedAgentChanged
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
	public MissionMainAgentController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsReady()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mission_OnMainAgentChanged(Agent oldAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentDeleted(Agent affectedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LookTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgentVisualsMovementCheck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BreakAgentVisualsInvulnerability()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RequestToSpawnAsBotCheck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent FindTargetedLockableAgent(Agent player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ControlTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleRangedWeaponAttackAlternativeAiming(Agent player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsThereAgentAction(Agent userAgent, Agent otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Disable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Enable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerToggleOrder(MissionPlayerToggledOrderViewEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWeaponUsageToggleRequested()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddOverrideControlsForFrame(OverrideMainAgentControlFlag overrideFlag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManagedOptionChanged(ManagedOptionsType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateLockTargetOption()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereAnyCustomCameraAddition()
	{
		throw null;
	}
}
