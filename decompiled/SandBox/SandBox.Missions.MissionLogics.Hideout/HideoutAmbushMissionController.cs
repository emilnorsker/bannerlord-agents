using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AreaMarkers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics.Hideout;

public class HideoutAmbushMissionController : MissionLogic
{
	public class TroopData
	{
		public CharacterObject Troop;

		public int Number;

		public int Level;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopData(CharacterObject troop, int number)
		{
			throw null;
		}
	}

	private enum HideoutMissionState
	{
		NotDecided,
		StealthState,
		CallTroopsCutSceneState,
		BattleBeforeBossFight,
		CutSceneBeforeBossFight,
		ConversationBetweenLeaders,
		BossFightWithDuel,
		BossFightWithAll
	}

	private const int FirstPhaseEndInSeconds = 4;

	private int _initialHideoutPopulation;

	private bool _troopsInitialized;

	private bool _isMissionInitialized;

	private bool _battleResolved;

	private readonly BattleSideEnum _playerSide;

	private HideoutMissionState _currentHideoutMissionState;

	private List<Agent> _duelPhaseAllyAgents;

	private List<Agent> _duelPhaseBanditAgents;

	private List<IAgentOriginBase> _allEnemyTroops;

	private List<IAgentOriginBase> _priorAllyTroops;

	private List<StealthAreaMissionLogic.StealthAreaData> _stealthAreaData;

	private Timer _waitTimerToChangeStealthModeIntoBattle;

	private Timer _firstPhaseEndTimer;

	private int _sentryCount;

	private int _remainingSentryCount;

	private BattleAgentLogic _battleAgentLogic;

	private BattleEndLogic _battleEndLogic;

	private HideoutAmbushBossFightCinematicController _hideoutAmbushBossFightCinematicController;

	private StealthAreaMissionLogic _stealthAreaMissionLogic;

	private Agent _bossAgent;

	private Team _enemyTeam;

	private CharacterObject _overriddenHideoutBossCharacterObject;

	public bool IsReadyForCallTroopsCinematic
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HideoutAmbushMissionController(BattleSideEnum playerSide, FlattenedTroopRoster priorAllyTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTroops(FlattenedTroopRoster priorAllyTroops)
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
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<IAgentOriginBase> GetReinforcementAllyTroops(StealthAreaMissionLogic.StealthAreaData triggeredStealthAreaData, StealthAreaMarker stealthAreaMarker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOverriddenHideoutBossCharacterObject(CharacterObject characterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IAgentOriginBase GetOneEnemyTroopToSpawnInFirstPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnRemainingTroopsForBossFight(List<MatrixFrame> spawnFrames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyAgent(IAgentOriginBase troopOrigin, GameEntity spawnPoint, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateForcedSentry(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateSentry(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeHideoutMissionModeToBattle()
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
	public void OnStealthMissionCounterFailed(OnStealthMissionCounterFailedEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckBattleResolved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideDepleted(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentsShouldBeEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnBossAndBodyguards()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SelectBossAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInitialFadeOutOver(ref Agent playerAgent, ref List<Agent> playerCompanions, ref Agent bossAgent, ref List<Agent> bossCompanions, ref float placementPerturbation, ref float placementAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCutSceneOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelOver(BattleSideEnum winnerSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartBossFightDuelMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBossFightDuelModeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartBossFightBattleMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBossFightBattleModeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KillAllSentries()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("kill_all_sentries", "mission")]
	public static string KillAllSentries(List<string> strings)
	{
		throw null;
	}
}
