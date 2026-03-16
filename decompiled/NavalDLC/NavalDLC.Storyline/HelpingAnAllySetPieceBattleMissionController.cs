using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline;

public class HelpingAnAllySetPieceBattleMissionController : MissionLogic, IMissionAgentSpawnLogic, IMissionBehavior
{
	private const string PlayerShipId = "longship_storyline_q1";

	private const string AllyShipId = "ship_trade_cog_q1";

	private const string EnemyShip1Id = "northern_medium_ship";

	private const string EnemyShip2Id = "ship_lightlongship_q1";

	private const string AllyShipTroopType = "vlandian_fortune_seekers";

	private const int AllyShipTroopCount = 12;

	private const int PlayerShipTroopType1Count = 32;

	private const int PlayerShipTroopType2Count = 1;

	private const int EnemyShip1TroopType1Count = 28;

	private const string EnemyShip1TroopType2 = "sea_hounds";

	private const int EnemyShip1TroopType2Count = 2;

	private const int EnemyShip2TroopType1Count = 16;

	private const int EnemyShip2TroopType2Count = 2;

	private const string PlayerShipTroopType1 = "gangradirs_kin_melee";

	private const string PlayerShipTroopType2 = "gangradirs_kin_ranged";

	private const string EnemyShip1TroopType1 = "sea_hounds_pups";

	private MissionShip _playerShip;

	private const string EnemyShip2TroopType1 = "sea_hounds_pups";

	private MissionShip _allyShip;

	private const string EnemyShip2TroopType2 = "sea_hounds";

	private MissionShip _pursuerShip1;

	private const float WindStrength = 2f;

	private const int WayPointCount = 6;

	private const float AiPlayerEngagementDistance = 10f;

	private MissionObjectiveLogic _missionObjectiveLogic;

	private NavalAgentsLogic _agentsLogic;

	private const float ShipAgentsAlarmDistance = 30f;

	private const float DefeatFadeOutDelayDuration = 2f;

	private const float DefeatFadeOutDuration = 1f;

	private const float DefeatBlackScreenDuration = 2f;

	private static readonly Dictionary<string, string> PlayerShipUpgradePieces;

	private static readonly Dictionary<string, string> AllyShipUpgradePieces;

	private static readonly Dictionary<string, string> Enemy1ShipUpgradePieces;

	private static readonly Dictionary<string, string> Enemy2ShipUpgradePieces;

	private List<GameEntity> _entities;

	private MobileParty _merchantParty;

	private MobileParty _seaHoundsParty;

	private MissionShip _pursuerShip2;

	private List<GameEntity> _waypoints;

	private bool _isAllyBoardedNotificationGiven;

	private int _currentWaypointIndex;

	private bool _isMissionInitialized;

	private bool _isMissionSuccessful;

	private bool _isAllyAboutToBeBoardedNotificationGiven;

	private bool _hasPlayerEngagedEnemyNotificationGiven;

	private bool _hasPlayerClearedFirstEnemyNotificationGiven;

	private bool _hasPlayerClearedSecondEnemyNotificationGiven;

	private bool _isPursuer1ShipEngaged;

	private bool _isMissionFailed;

	private bool _isPursuer2ShipEngaged;

	private float _drownCheckTimer;

	private float _drownCheckDuration;

	private bool _isVictoryQueued;

	private float _victoryPopUpTimer;

	private float _victoryPopUpDelay;

	private bool _isDefeatQueued;

	private bool _isFadeOutTriggered;

	private float _defeatTimer;

	private float _notificationTimer;

	public Action OnShipsInitializedEvent;

	public Action<float> OnDefeatedEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HelpingAnAllySetPieceBattleMissionController(MobileParty merchantParty, MobileParty seaHoundsParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateEntityReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(string shipHullId, string spawnPointId, Formation formation, PartyBase owner, string materialName, Figurehead figurehead = null, Dictionary<string, string> upgradePieces = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeShipColors(MissionShip missionShip, uint color1, uint color2, string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSailColors(GameEntity sailEntity, uint sailColor1, uint sailColor2, string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipsEngaged(MissionShip ship1, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMerchantsAboutToBeBoarded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateMissionShip(Ship ship, string spawnPointId, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerShipAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyAgents(MissionShip ship, string troopType1, int troopType1Count, string troopType2, int troopType2Count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyShipAgents(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDrowningAgents(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalmAgentsOfShip(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreShipsWithinDistance(MissionShip ship1, MissionShip ship2, float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAllPursuingShipsDefeated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenVictoryPopUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnVictoryPopUpClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartDefeatSequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartDefeatFadeOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddFightBehaviors(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasSailThrust()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartSpawner(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopSpawner(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideSpawnEnabled(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetReinforcementInterval()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSideDepleted(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<IAgentOriginBase> GetAllTroopsForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPlayerControllableTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetSpawnHorses(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static HelpingAnAllySetPieceBattleMissionController()
	{
		throw null;
	}
}
