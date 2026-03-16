using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using SandBox.Missions.AgentBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class DisguiseMissionLogic : MissionLogic, IPlayerInputEffector, IMissionBehavior
{
	public class ShadowingAgentOffenseInfo
	{
		public Agent Agent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public bool CanPlayerCameraSeeTheAgent
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

		public StealthOffenseTypes OffenseType
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
		public ShadowingAgentOffenseInfo(Agent agent, StealthOffenseTypes offenseType)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetCanPlayerCameraSeeTheAgent(bool value)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void SetOffenseType(StealthOffenseTypes offenseType)
		{
			throw null;
		}
	}

	public const float PlayerSuspiciousLevelMin = 0f;

	public const float PlayerSuspiciousLevelMax = 1f;

	public const float ToggleStealthModeSuspiciousThreshold = 0.95f;

	public const float MissionFailDistanceToTargetAgent = 5000f;

	private const float StartSuspiciousDecayAfterSeconds = 2f;

	private const float OfficerAgentPersonalZoneRadius = 3.5f;

	private const float DefaultAgentPersonalZoneRadius = 0f;

	private const float InConsistentMovementToleranceFactor = 0.2f;

	private const float MaximumWorstMovementRotationFactor = 1f;

	private const float InconsistentMovementDecayFactor = 2f;

	private const float CircularMovementDetectRadiusSquared = 4f;

	private const float DefaultDecayFactor = -0.01f;

	private const float DefaultSuspiciousFactor = 0.1f;

	private const float GuardSpawnDistanceThreshold = 20f;

	private const float MaximumContactAgentDistance = 250f;

	private const float StaticGuardSpawnPercentage = 0.3f;

	private readonly List<CharacterObject> _troopPool;

	private Dictionary<Agent, ShadowingAgentOffenseInfo> _disguiseAgentOffenseInfos;

	private Agent _contactAgent;

	private Timer _isAgentDeadTimer;

	private readonly List<GameEntity> _customPoints;

	private readonly List<GameEntity> _dynamicPoints;

	public float PlayerSuspiciousLevel;

	private Vec2 _lastFramePlayerPosition;

	private int _disabledFaceId;

	private readonly CharacterObject _defaultContractorCharacter;

	private readonly List<Agent> _officerAgents;

	private readonly List<Agent> _defaultDisguiseAgents;

	private readonly List<Agent> _agentsToBeRemoved;

	private readonly bool _willSetUpContact;

	private readonly Location _fromLocation;

	private Dictionary<Agent, AlarmedBehaviorGroup> _agentAlarmedBehaviorCache;

	private List<Agent> _suspiciousAgentsThisFrame;

	private MBList<GameEntity> _stealthIndoorLightingAreas;

	private bool _isBehaviorInitialized;

	private bool _firstTickPassed;

	private bool _firstEventControlTickPassed;

	private bool _disguiseAgentsStealthModeIsOn;

	private float _angleDifferenceBetweenCurrentAndLastPositionOfPlayer;

	private float _cumulativePositionAndRotationDifference;

	private Vec3 _averagePlayerPosition;

	private MissionTimer _lastSuspiciousTimer;

	private bool _contactSet;

	private int _staticGuardsCount;

	private bool _playerWillBeTakenPrisoner;

	public bool IsInStealthMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ReadOnlyDictionary<Agent, ShadowingAgentOffenseInfo> ThreatAgentInfos
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DisguiseMissionLogic(CharacterObject contractorCharacter, Location fromLocation, bool willSetUpContact)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBeforePlayerAgentSpawn(ref MatrixFrame matrixFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetSpawnFrameOfPassage(Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsContactAgentTracked(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanCommonAreaFightBeTriggered()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanPlayerMeetWithHeroAfterConversation(Hero hero, ref bool result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ContactAlreadySetCommonCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOnLeftSide(Vec2 lineA, Vec2 lineB, Vec2 point)
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
	private void SetStealthModeToDisguiseAgents(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetStealthModeInternal(Agent agent, bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMissionBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TogglePassages(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCustomGuards()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GuardAgentOnTargetReachDelegate(Agent agent, ref Agent targetAgent, ref UsableMachine targetUsableMachine, ref WorldFrame targetFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GuardAgentWaitDelegate(Agent agent, ref float waitTimeInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ScriptBehavior.SelectTargetDelegate GuardAgentSelectTargetDelegate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TurnGuardsToDisguiseAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnDisguiseMissionAgentInternal(CharacterObject agentCharacter, Vec3 initialPosition, Vec2 initialDirection, string actionSetId, bool isEnemy = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBehaviorGroups(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnContactAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetNotableDialogFlow1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetNotableDialogFlow2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetNotableDialogFlow3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetNotableDialogFlow4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DialogCondition2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DialogCondition3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DialogCondition4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GeneralNotableDialogCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BlackSmithCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetThugDialogFlow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ThugConversationCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow FailedDialogFlow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mission_failed_through_dialog_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DialogFlow GetContactDialogFlow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLocationCharacterAgentSpawned(LocationCharacterAgentSpawnedMissionEvent eventData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckCaughtConversationActivation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShadowingAgentOffenseInfo GetAgentOffenseInfo(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPlayerSuspiciousFactor(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateCircularMovementSuspiciousValue(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentInDetectionRadius(Agent offenderAgent, Agent detectorAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CalculateErraticMovementSuspiciousValue(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canPlayerLeave)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsInOfficerPersonalZone(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsInDefaultAgentPersonalZone(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanAgentSeeAgent(Agent agent1, Agent agent2, MBReadOnlyList<GameEntity> stealthIndoorLightingAreas, out bool hasVisualOnCorpse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EventControlFlag OnCollectPlayerEventControlFlags()
	{
		throw null;
	}
}
