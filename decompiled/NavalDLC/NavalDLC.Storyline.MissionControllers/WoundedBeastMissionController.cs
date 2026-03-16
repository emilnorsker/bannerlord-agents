using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline.MissionControllers;

public class WoundedBeastMissionController : MissionLogic
{
	private struct StorylineTroop
	{
		public string TroopId
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public int TroopCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StorylineTroop(string troopId, int troopCount)
		{
			throw null;
		}
	}

	private const string WindDirection = "sp_wind_direction";

	private const string TargetEntityTag = "targeting_entity";

	private const string GangradirInitialDestination = "sp_gangradir_ship_destination";

	private const string LaharShipSpawnId = "sp_lahar_ship";

	private const string GangradirShipSpawnId = "sp_gangradir_ship";

	private const string LaharShipHullId = "ship_liburna_q2_storyline";

	private const string GangradirShipHullId = "northern_medium_ship";

	private const string LaharMeleeTroopId = "southern_pirates_raider";

	private const string LaharRangedTroopId = "aserai_marine_t5";

	private const string GangradirMeleeTroopId = "gangradirs_kin_melee";

	private const string GangradirRangedTroopId = "gangradirs_kin_ranged";

	private readonly List<StorylineTroop> _laharShipTroops;

	private readonly List<StorylineTroop> _gangradirShipTroops;

	private readonly List<Ship> _playerShips;

	private readonly MBList<MissionShip> _playerMissionShips;

	private Ship _gangradirShip;

	private Ship _laharShip;

	private MissionShip _laharMissionShip;

	private MissionShip _gangradirMissionShip;

	private static readonly Dictionary<string, string> LaharShipUpgradePieces;

	private static readonly Dictionary<string, string> GangradirShipUpgradePieces;

	private const string FahdaShipSpawnId = "sp_fahda_ship";

	private const string FahdaShipHullId = "ship_meditheavy_storyline";

	private const string MediumReinforcementShipHullId = "ship_liburna_storyline";

	private const string LightReinforcementShipHullId = "ship_meditlight_storyline";

	private const string EnemyMeleeTroopId1 = "southern_pirates_raider";

	private const string EnemyMeleeTroopId2 = "aserai_footman";

	private const string EnemyRangedTroopId = "southern_pirates_bandit";

	private readonly List<StorylineTroop> _fahdaShipTroops;

	private readonly List<StorylineTroop> _enemyReinforcementFirstShipTroops;

	private readonly List<StorylineTroop> _enemyReinforcementSecondShipTroops;

	private readonly List<StorylineTroop> _enemyReinforcementThirdShipTroops;

	private readonly MBList<Agent> _enemySideAgents;

	private readonly List<Formation> _availailableEnemyFormations;

	private readonly MBList<MissionShip> _enemyMissionShips;

	private readonly List<Ship> _enemyShips;

	private const string EnemyReinforcementFirstShipTargetEntityTag = "targeting_entity_1";

	private const string EnemyReinforcementSecondShipTargetEntityTag = "targeting_entity_2";

	private const string EnemyReinforcementThirdShipTargetEntityTag = "targeting_entity_3";

	private WeakGameEntity EnemyReinforcementFirstShipTargetEntity;

	private WeakGameEntity EnemyReinforcementSecondShipTargetEntity;

	private WeakGameEntity EnemyReinforcementThirdShipTargetEntity;

	private Ship _fahdaShip;

	private MissionShip _fahdaMissionShip;

	private MissionShip _enemyReinforcementFirstMissionShip;

	private MissionShip _enemyReinforcementSecondMissionShip;

	private MissionShip _enemyReinforcementThirdMissionShip;

	private static readonly Dictionary<string, string> FahdaShipUpgradePieces;

	private static readonly Dictionary<string, string> MediumReinforcementShipUpgradePieces;

	private static readonly Dictionary<string, string> FirstLightReinforcementShipUpgradePieces;

	private static readonly Dictionary<string, string> SecondLightReinforcementShipUpgradePieces;

	private float _drownCheckTimer;

	private float _drownCheckDuration;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private MissionObjectiveLogic _missionObjectiveLogic;

	private Vec2 _fleePoint;

	private Vec2 _gangradirInitialDestination;

	private bool _initialized;

	private bool _isMissionSuccessful;

	private bool _isMissionFailed;

	private bool _inPhase1;

	private MissionTimer _failingQuestTimer;

	private float _startDistanceToFleePoint;

	private bool _nearFleePoint;

	private bool _targetedSmallerVessels;

	private bool _targetedBySmallerVessels;

	private bool _targetedBiggerVessel;

	private readonly Dictionary<MissionShip, bool> _shipsToAlert;

	private readonly Dictionary<MissionShip, bool> _alertedShips;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WoundedBeastMissionController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckMissionEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickGangradirsShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsShipAlerted(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsShipActive(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPhase1Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDrowningAgents(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckDrowningAgents(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrownAgent(Agent agent, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickEnemyShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckTargetShipNearEscapePoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerTargetShipNotifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerSmallerShipNotifications(bool hasPlayerAttemptedToBoard)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTargetShipSunk()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveEscortShipsToTheirDefencePositions(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSuccess()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSceneWindDirectionAndWaterStrength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(IShipOrigin ship, Team team, Formation formation, WeakGameEntity spawnEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AlertShip(MissionShip missionShip, MissionShip target = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AlertAllEnemyShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AlertAllShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanAlertShip(MissionShip missionShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipRammed(MissionShip ship1, MissionShip ship2, float damagePercent, bool isFirstImpact, CapsuleData data, int ramQuality)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemySide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip SpawnReinforcementShip(WeakGameEntity targetEntity, List<StorylineTroop> troops, string shipHullId, Dictionary<string, string> upgradePieces)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnHero(CharacterObject character, MissionShip ship, PartyBase party, Banner customBanner = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnNonHeroAgents(MissionShip ship, List<StorylineTroop> troopTypes, PartyBase party, Banner customBanner = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetAgentCountOfSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetDefencePositionsForReinforcementShips(out Vec2 leftSide, out Vec2 rightSide, out Vec2 behind)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddShipUpgradePieces(Ship ship, Dictionary<string, string> upgradePieces)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static WoundedBeastMissionController()
	{
		throw null;
	}
}
