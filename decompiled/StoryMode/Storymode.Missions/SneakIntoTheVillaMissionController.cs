using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions;
using StoryMode.Quests.TutorialPhase;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace Storymode.Missions;

public class SneakIntoTheVillaMissionController : MissionLogic
{
	public enum MissionState
	{
		Start,
		Crouch,
		WalkSlow,
		HideInBushes,
		HideInBushesEnd,
		Distraction,
		DarkZone,
		DarkZoneEnd,
		StealthKill,
		HideCorpse,
		End
	}

	private Dictionary<MissionState, VolumeBox> _volumeBoxes;

	private const string FirstDoorId = "doors_before_convo";

	private const string SecondDoorId = "doors_after_convo";

	private const string DistractionAgentSpawnPointId = "sp_agent_distraction";

	private const string StealthKillAgentSpawnPointId = "sp_agent_stealth_kill";

	private const string HeadmanSpawnPoint = "sp_captive";

	private VillagersInNeed _talkToVillagersQuest;

	private MissionTimer _missionEndTimer;

	private Agent _distractionTargetAgent;

	private Agent _stealthKillTargetAgent;

	private bool _isStealthAttackComplete;

	public bool AreVisualsDirty;

	public static SneakIntoTheVillaMissionController Instance
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

	public MissionState State
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

	public Agent HeadmanAgent
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
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsStealthTutorialReadyForActivation(MissionState missionState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsStealthTutorialReadyForCompletion(MissionState missionState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCaughtInStealthZone(OnStealthMissionCounterFailedEvent stealthFailedEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMainAgentIsWounded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowMissionFailedPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAfterTalkingToPrisoner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnHeadman()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnStealthAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckTriggers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTargetAgentDistracted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTargetAgentKilled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMainAgentDraggingTargetBody()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMeleeHit(Agent attacker, Agent victim, bool isCanceled, AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeVolumeBoxes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnAgent(CharacterObject character, GameEntity spawnPoint, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SneakIntoTheVillaMissionController()
	{
		throw null;
	}
}
