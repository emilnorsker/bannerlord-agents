using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline;

public class NavalStorylineCaptivityMissionController : MissionLogic
{
	private const int ScatteredCrewCountPerArea = 2;

	private const string PlayerEquipmentId = "item_set_player_captivity";

	private const string GangradirEquipmentId = "item_set_gangradir_captivity";

	private const float InitialOarForceMultiplier = 0.01f;

	private const float FinalOarForceMultiplier = 0.95f;

	private const float CloseSailsDistanceToFinalHighlight = 90f;

	private const float WindStrength = 1.1f;

	private const float FadeInDuration = 0.75f;

	private const float BlackDuration = 1f;

	private const float FadeOutDuration = 0.75f;

	private int _missionInitializationPeriod;

	private MissionObjectiveLogic _missionObjectiveLogic;

	private Agent _gangradirAgent;

	private readonly List<Agent> _crewAgents;

	private readonly CharacterObject _allyCharacterObject;

	private readonly BasicCharacterObject _enemyCharacterObject;

	private readonly CharacterObject _crewCharacterObject;

	private ShipOarMachine _oarUsedByPlayer;

	private ShipOarMachine _oarUsedByAlly;

	private List<GameEntity> _entities;

	private readonly List<(Agent, bool)> _scatteredCrew;

	private readonly List<Agent> _savedScatteredAgents;

	private bool _allScatteredCrewMembersAreSaved;

	private bool _hasTalkedToGangradirOutro;

	private float _outroSpeechDelayTimer;

	private SpawnedItemEntity _weaponEntity;

	private GameEntity _spawnZone1;

	private GameEntity _spawnZone2;

	private bool _isFinalized;

	private SoundEvent _spawnZone1HelpSoundEvent;

	private SoundEvent _spawnZone2HelpSoundEvent;

	private bool _hasSavedOarsmen;

	private int _savedOarsmenCount;

	private bool _hasTalkedToGangradir;

	private bool _isConversationSetupInProgress;

	private int _spawnedOarsmenCount;

	private float _speechDelayTimer;

	private int _saveTargetAgentCount;

	private ActionIndexCache _tinkeringAction;

	private bool _isPlayerTinkeringWithTheBindsMachine;

	private int _previousOarsmenLevel;

	private List<AgentBindsMachine> _agentBindMachines;

	private List<ShipOarMachine> _leftOars;

	private List<ShipOarMachine> _rightOars;

	private Dictionary<Agent, ShipOarMachine> _oarAssignments;

	private Agent _crewConversationAgent;

	public Action OnMarkedObjectStatusChangedEvent;

	public Action OnPlayerStartedEscapeEvent;

	public Action<Vec3> OnConversationSetupEvent;

	public Action<int> OnOarsmenLevelChanged;

	public Action<float, float, float> OnStartFadeOutEvent;

	public Action OnFirstHighlightClearedEvent;

	public MissionShip MissionShip
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

	public bool IsPlayerFree
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

	public bool HasTalkedToGangradir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool WasPlayerKnockedOut
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
	public NavalStorylineCaptivityMissionController(CharacterObject allyCharacter, BasicCharacterObject enemyCharacter, CharacterObject crewCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeAgentUseAssignedOarMachine(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfCrewmenAreNearby()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateEntityReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckEnemyAlarmedState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canLeave)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnAllyCrewAgent(Vec3 globalPosition, Vec2 globalDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCrewAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgentAssignedToOarOnSpawn(Agent agent, ShipOarMachine oarMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectStoppedBeingUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleChainVisualsAfterDialogue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerStartedEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfPlayerIsReleasedFromOar()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerEnemies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgentEntersFight(Agent agent, Agent targetAgent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnEarlyAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnScatteredCrew()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCrewAroundPosition(Vec3 spawnGlobalPosition, Vec2 spawnGlobalDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupPostFightConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartPostFightConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetOarForceMultipliers(float forceMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CategorizeOars()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ShipOarMachine GetOarMachineToUse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RespawnMainAgent(GameEntity respawnPositionEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReenableAllOars()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeUsableMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentAlarmedStateChanged(Agent agent, AIStateFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipCaptured()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSavedCrew(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAllCrewSaved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupSavedCrewConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerReachedFirstZone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFirstHighlightCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartSavedCrewConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTutorialCompleted(string completedTutorialIdentifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCameraTutorialFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipControllerMachine GetMarkedShipControllerMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<AgentBindsMachine> GetMarkedAgentBinds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Agent> GetScatteredCrewmen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Agent> GetCaptorAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFirstHighlightCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReadyToCloseSails()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetStoppedShipSpeedThreshold()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerInShipControls()
	{
		throw null;
	}
}
