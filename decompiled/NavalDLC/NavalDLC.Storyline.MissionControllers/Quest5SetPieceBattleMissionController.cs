using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.Objects.UsableMachines;
using NavalDLC.Storyline.Objectives.Quest5;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;
using TaleWorlds.MountAndBlade.Missions.Objectives;
using TaleWorlds.MountAndBlade.Objects.Usables;

namespace NavalDLC.Storyline.MissionControllers;

public class Quest5SetPieceBattleMissionController : MissionLogic, IMissionAgentSpawnLogic, IMissionBehavior
{
	public class ConversationSound
	{
		public TextObject Line;

		public NotificationPriority Priority;

		public CharacterObject Character;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConversationSound(TextObject line, NotificationPriority priority, CharacterObject character)
		{
			throw null;
		}
	}

	public enum Quest5SetPieceBattleMissionState
	{
		None,
		InitializePhase1Part1,
		InitializePhase1Part2,
		Phase1GoToEnemyShip,
		Phase1SwimmingPhase,
		InitializeStealthPhasePart1,
		InitializeStealthPhasePart2,
		Phase1StealthPhase,
		Phase1GoToShipInteriorFadeOut,
		Phase1InitializeShipInteriorPhase,
		Phase1GoToShipInteriorFadeIn,
		Phase1ShipInteriorPhase,
		Phase1GoBackToShipFadeOut,
		Phase1InitializeGoBackToShip,
		Phase1GoBackToShipFadeIn,
		Phase1EscapePhase,
		Phase1ToPhase2FadeOut,
		InitializePhase2Part1,
		InitializePhase2Part2,
		InitializePhase2Part3,
		InitializePhase2Part4,
		Phase1ToPhase2FadeIn,
		Phase2InProgress,
		Phase2ToPhase3FadeOut,
		InitializePhase3Part1,
		InitializePhase3Part2,
		InitializePhase3Part3,
		Phase2ToPhase3FadeIn,
		Phase3InProgress,
		Phase3ToPhase4FadeOut,
		InitializePhase4Part1,
		InitializePhase4Part2,
		Phase3ToPhase4FadeIn,
		Phase4InProgress,
		Phase4ToBossFightFadeOut,
		InitializeBossFightPart1,
		InitializeBossFightPart2,
		Phase4ToBossFightFadeIn,
		StartBossFightConversation,
		BossFightConversationInProgress,
		BossFightInProgressAsDuel,
		BossFightInProgressAsAll,
		End,
		Exit
	}

	private enum Quest5InstructionState
	{
		None,
		Approach,
		WaitForJump,
		Jump,
		WaitForSwim,
		Swim,
		WaitForClearGuards,
		ClearGuards,
		WaitForCheckInterior,
		CheckInterior,
		WaitForTalkSister,
		TalkSister,
		WaitForReturnToDeck,
		ReturnToDeck,
		WaitForCutLoose,
		CutLoose,
		WaitForGunnarUsesShip,
		GunnarUsesShip,
		WaitForEscapeQuietly,
		EscapeQuietly,
		WaitForReachAllies,
		ReachAllies,
		WaitForDefeatEnemies,
		DefeatEnemies,
		WaitForDefeatPurigsShip,
		DefeatPurigsShip,
		WaitForDefeatPurig,
		DefeatPurig,
		WaitForEnd,
		End
	}

	private enum GunnarMovementState
	{
		None,
		GoToInitialJumpingPosition,
		WaitForReachingInitialJumpingPosition,
		GoToJumpingTargetPosition,
		WaitForReachingJumpingTargetPosition,
		SwimToTheHidingSpot,
		WaitForTeleportingToTheHidingSpot,
		TeleportToTargetPosition,
		WaitAtTheHidingSpot,
		GoToTheEscapeShip,
		WaitForReachingToTheEscapeShip,
		UseTheEscapeShip,
		End
	}

	private enum GunnarMovementStateForClimbingShip
	{
		None,
		Start,
		GoingToTheTargetClimbingMachine,
		TargetReached,
		UsingClimbingMachine,
		OnDeck,
		GoToFinalTargetPoint,
		End
	}

	public enum BossFightOutComeEnum
	{
		None,
		PlayerRefusedTheDuel,
		PlayerAcceptedAndWonTheDuel,
		PlayerDefeatedWaitingForConversation,
		PlayerAcceptedTheDuelLostItAndLetPurigGo,
		PlayerAcceptedTheDuelLostItAndHadPurigKilledAnyway
	}

	private enum BossFightStateEnum
	{
		None,
		Duel,
		All
	}

	private const string SceneStealthPhaseAtmosphereName = "TOD_02_00_SemiCloudy";

	private const string SceneInteriorAtmosphereName = "TOD_01_00_SemiCloudy";

	private const string ScenePhase2AtmosphereName = "TOD_naval_03_00_sunset";

	private const string ScenePhase3AtmosphereName = "TOD_naval_05_30_sunset";

	private const string MainOarPrefabName = "oars_holder";

	private const float GunnarFellIntoTheWaterTimer = 10f;

	private const string RampHolderId = "ramp_holder";

	private const string GunnarInitialJumpOffPositionTag = "gangradir_jump_off_initial";

	private const string GunnarJumpOffTargetPositionTag = "gangradir_jump_off_target";

	private const string Phase1EnemyShip4GunnarHidingSpotStringId = "sp_gangradir_hiding_spot";

	private const float MaximumAllowedReachDistanceToPhase1EnemyShip1 = 25f;

	private const float AllowedSwimRadius = 200f;

	private const float AllowedSwimRadiusCheckFrequencyAsSeconds = 5f;

	private const string Phase1CustomStealthEquipmentId = "naval_storyline_quest5_stealth_set";

	private const string Phase1ApproachPointTag = "phase_1_approach_point";

	private const float Phase1ApproachDistance = 30f;

	private const float Phase1EscapePhaseAutoCutLooseTimer = 300f;

	private const string Phase1SlaveTraderAgentCharacterStringId = "sea_hounds";

	private const string Phase1StealthAgentCharacterStringId = "sea_hound_captivity";

	private const string Phase1PlayerShipStringId = "crusas_roundship_nested_q5";

	private const string Phase1PlayerShipSpawnPointTag = "phase_1_player_ship_sp";

	private const string Phase1EnemyShip1StringId = "sturgia_heavy_ship";

	private const string Phase1EnemyShip1SpawnPointTag = "phase_1_enemy_ship_1_sp_initial";

	private const string Phase1EnemyShip1TargetPointTag = "phase_1_enemy_ship_1_sp";

	private const int Phase1EnemyShip1TroopCount = 7;

	private const string Phase1EnemyShip2StringId = "ship_lodya_storyline";

	private const string Phase1EnemyShip2SpawnPointTag = "phase_1_enemy_ship_2_sp";

	private const int Phase1EnemyShip2TroopCount = 6;

	private const string Phase1EnemyShip2AttachmentPoint1Tag = "bridge_a";

	private const string Phase1EnemyShip2AttachmentPoint2Tag = "bridge_b";

	private const string Phase1EnemyShip2AttachmentPoint3Tag = "bridge_c";

	private const string Phase1EnemyShip3StringId = "ship_dromon_storyline";

	private const string Phase1EnemyShip3SpawnPointTag = "phase_1_enemy_ship_3_sp";

	private const int Phase1EnemyShip3TroopCount = 100;

	private const string Phase1EnemyShip3AttachmentPoint1Tag = "bridge_a";

	private const string Phase1EnemyShip3AttachmentPoint2Tag = "bridge_b";

	private const string Phase1EnemyShip3ToInteriorDoorTag = "phase_1_enemy_ship_3_to_interior_door_tag";

	private const string Phase1EnemyShip4StringId = "ship_birlinn_storyline";

	private const string Phase1EnemyShip4AttachmentPoint1Tag = "bridge_d";

	private const string Phase1EnemyShip4SpawnPointTag = "phase_1_enemy_ship_4_sp";

	private const int Phase1EnemyShip4TroopCount = 6;

	private const string Phase1EnemyShip4StealthCheckpointSpawnPointStringId = "sp_player_stealth_checkpoint";

	private const string Phase1InteriorMissionPlayerSpawnPointTag = "phase_1_interior_player_sp";

	private const string Phase1InteriorMissionSisterSpawnPointTag = "phase_1_interior_sister_sp";

	private const string Phase1InteriorToEnemyShip3DoorTag = "phase_1_interior_to_enemy_ship_3_door_tag";

	private const string CrusasPhase1EquipmentStringId = "npc_merchant_equipment_empire";

	private const string EscapeShipRoofUpgradeId = "roof_5";

	private const string EscapeShipDeckUpgradeId = "deck_large_arrow_and_javelin_crates_lvl3";

	private const string SlaveTraderShipOarsmanActionId = "act_sit_2";

	private const string SisterWoundedActionId = "act_conversation_weary2_loop";

	private const string Phase1InteriorCameraSisterTag = "phase_1_interior_camera_sister";

	private const string Phase2EscapeShipPirateTargetFrame1Tag = "phase_2_anchor_1";

	private const string Phase2EscapeShipPirateTargetFrame2Tag = "phase_2_anchor_2";

	private const string Phase2EscapeShipPirateTargetFrame3Tag = "phase_2_anchor_3";

	private const string Phase2EscapeShipPirateTargetFrame4Tag = "phase_2_anchor_4";

	private const string Phase2EscapeShipPirateTargetFrame5Tag = "phase_2_anchor_5";

	private const string Phase2EnemyShip1SpawnPointTag = "phase_2_enemy_ship_1_sp";

	private const string Phase2EnemyShip2SpawnPointTag = "phase_2_enemy_ship_2_sp";

	private const string Phase2EnemyShip3SpawnPointTag = "phase_2_enemy_ship_3_sp";

	private const string Phase2EnemyShip4SpawnPointTag = "phase_2_enemy_ship_4_sp";

	private const string Phase2EnemyShip5SpawnPointTag = "phase_2_enemy_ship_5_sp";

	private const string Phase2EnemyShipStationary1SpawnPointTag = "phase_2_enemy_ship_stationary_1";

	private const string Phase2EnemyShip1TargetPointTag = "phase_2_enemy_ship_1_target";

	private const string Phase2EnemyShip2TargetPointTag = "phase_2_enemy_ship_2_target";

	private const string Phase2EnemyShip3TargetPointTag = "phase_2_enemy_ship_3_target";

	private const string Phase2EnemyShip4TargetPointTag = "phase_2_enemy_ship_4_target";

	private const string Phase2EnemyShip5TargetPointTag = "phase_2_enemy_ship_5_target";

	private const string Phase2EnemyShip1StringId = "ship_meditlight_storyline_q5";

	private const string Phase2EnemyShip2StringId = "ship_meditlight_storyline_q5";

	private const string Phase2EnemyShip3StringId = "ship_meditlight_storyline_q5";

	private const string Phase2EnemyShip4StringId = "ship_meditlight_storyline_q5";

	private const string Phase2EnemyShip5StringId = "ship_meditlight_storyline_q5";

	private const string Phase2EnemyShipStationary1StringId = "western_medium_ship";

	private const string Phase2AllyShip1SpawnPointTag = "phase_2_ally_ship_1_sp";

	private const string Phase2AllyShip2SpawnPointTag = "phase_2_ally_ship_2_sp";

	private const string Phase2AllyShip3SpawnPointTag = "phase_2_ally_ship_3_sp";

	private const string Phase2AllyShip4SpawnPointTag = "phase_2_ally_ship_4_sp";

	private const string Phase2AllyShip5SpawnPointTag = "phase_2_ally_ship_5_sp";

	private const string Phase2AllyShip1StringId = "aserai_heavy_ship";

	private const string Phase2AllyShip2StringId = "nord_medium_ship";

	private const string Phase2AllyShip3StringId = "northern_medium_ship";

	private const string Phase2AllyShip4StringId = "sturgia_heavy_ship";

	private const string Phase2AllyShip5StringId = "northern_medium_ship";

	private const float AutoCutLoosePirateShipTimer = 25f;

	private const float AutoEstablishConnectionsForPirateShipsTimer = 7f;

	private const string Phase2EscapeShipTargetPointPrefix = "phase_2_escape_ship_target";

	private const string Phase2EscapeShipTargetPointExpression = "phase_2_escape_ship_target(_\\d+)*";

	private const string Phase2EscapeShipBarrierTag = "phase_2_barricade";

	private const string Phase3TriggerVolumeBoxTag = "phase_3_trigger_volume_box_tag";

	private const string Phase3EnemyShip1StringId = "eastern_heavy_ship";

	private const string Phase3EnemyShip2StringId = "aserai_heavy_ship";

	private const string Phase3EnemyShip3StringId = "nord_medium_ship";

	private const string Phase3EnemyShip4StringId = "nord_medium_ship";

	private const string Phase3EnemyShip5StringId = "khuzait_heavy_ship";

	private const string Phase3EnemyShip1SpawnPointTag = "phase_3_enemy_ship_1_sp";

	private const string Phase3EnemyShip2SpawnPointTag = "phase_3_enemy_ship_2_sp";

	private const string Phase3EnemyShip3SpawnPointTag = "phase_3_enemy_ship_3_sp";

	private const string Phase3EnemyShip4SpawnPointTag = "phase_3_enemy_ship_4_sp";

	private const string Phase3EnemyShip5SpawnPointTag = "phase_3_enemy_ship_5_sp";

	private const string Phase3EnemyShipReinforcementSpawnPoint1Tag = "phase_3_enemy_reinforcement_1_sp";

	private const string Phase3EnemyShipReinforcementSpawnPoint2Tag = "phase_3_enemy_reinforcement_2_sp";

	private const string Phase3EnemyReinforcementShip1StringId = "empire_medium_ship";

	private const string Phase3EnemyReinforcementShip2StringId = "nord_medium_ship";

	private const string Phase3EnemyReinforcementShip3StringId = "sturgia_heavy_ship";

	private const string Phase3AllyShip1SpawnPointTag = "phase_3_ally_ship_1_sp";

	private const string Phase3AllyShip2SpawnPointTag = "phase_3_ally_ship_2_sp";

	private const string Phase3AllyShip3SpawnPointTag = "phase_3_ally_ship_3_sp";

	private const string Phase3AllyShip4SpawnPointTag = "phase_3_ally_ship_4_sp";

	private const string Phase3AllyShip5SpawnPointTag = "phase_3_ally_ship_5_sp";

	private const string Phase3PlayerShipSpawnPointTag = "phase_3_player_ship_sp";

	private const string Phase3PlayerShipStringId = "empire_heavy_ship";

	private const string Phase3PlayerShipUsePointStringId = "sp_troop_captain";

	private const string PurigsEnterenceTriggerBoxTag = "phase_4_purigs_entrance_trigger_box";

	private const string PurigImmortalShipSpawnPointTag = "sp_immortal_purig";

	private const string PurigBodyguard1ImmortalShipSpawnPointTag = "sp_immortal_bodyguard_1";

	private const string PurigBodyguard2ImmortalShipSpawnPointTag = "sp_immortal_bodyguard_2";

	private const string PurigShipSpawnPointTag = "phase_4_purig_ship_sp";

	private const string PurigShipStringId = "purigs_roundship_storyline";

	private const string PurigShipTroopStringId = "sea_hounds";

	private const int PurigShipTroopCount = 40;

	private const string NavalBossFightPlayerSpawnPointTag = "naval_boss_fight_player_sp";

	private const string NavalBossFightPlayerAllySpawnPointTagPrefix = "naval_boss_fight_player_ally_sp_";

	private const string NavalBossFightEnemyBossSpawnPointTag = "naval_boss_fight_enemy_boss_sp";

	private const string NavalBossFightEnemyTroopSpawnPointTagPrefix = "naval_boss_fight_player_enemy_sp_";

	private const int NavalBossFightAllyTroopCount = 2;

	private const int NavalBossFightEnemyTroopCount = 2;

	private const string NavalBossFightPlayerBodyguardTroopStringId = "gangradirs_kin_melee";

	private const string NavalBossFightEnemyBodyguardTroopStringId = "sea_hounds";

	private const string BossFightConversationCameraTag = "sp_boss_fight_camera";

	private readonly List<KeyValuePair<string, string>> _phase1EnemyShip2UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _escapeShipUpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase2AllyShip1UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase2AllyShip2UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase2AllyShip3UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase2AllyShip4UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase2AllyShip5UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyShip1UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyShip2UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyShip3UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyShip4UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyShip5UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyReinforcementShip1UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyReinforcementShip2UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase3EnemyReinforcementShip3UpgradePieceList;

	private readonly List<KeyValuePair<string, string>> _phase4PurigsShipUpgradePieceList;

	private Quest5InstructionState _instructionState;

	private Quest5ApproachObjective _approachObjective;

	private Quest5JumpObjective _jumpObjective;

	private Quest5SwimObjective _swimObjective;

	private Quest5ClearGuardsObjective _clearGuardsObjective;

	private Quest5CheckInteriorObjective _checkInteriorObjective;

	private Quest5TalkWithYourSisterObjective _talkWithYourSisterObjective;

	private Quest5ReturnToDeckObjective _returnToDeckObjective;

	private Quest5CutLooseObjective _cutLooseObjective;

	private Quest5GunnarUsesShipObjective _gunnarUsesShipObjective;

	private Quest5EscapeObjective _escapeObjective;

	private Quest5ReachAlliesObjective _reachAlliesObjective;

	private Quest5DefeatEnemiesObjective _defeatEnemiesObjective;

	private Quest5DefeatPurigsShipObjective _defeatPurigsShipObjective;

	private Quest5DefeatPurigObjective _defeatPurigObjective;

	private GunnarMovementState _gunnarMovementState;

	private GunnarMovementStateForClimbingShip _gunnarMovementStateForClimbingShip;

	private ClimbingMachine _targetClimbingMachine;

	private MissionTimer _gunnarFellIntoTheWaterTimer;

	private GameEntity _jumpOffInitialPositionGameEntity;

	private GameEntity _jumpOffTargetPositionGameEntity;

	private GameEntity _hidingSpot1PositionGameEntity;

	private MissionShip _phase1EnemyShip1;

	private MissionShip _phase1EnemyShip2;

	private MissionShip _phase1EnemyShip3;

	private MissionShip _phase1EnemyShip4;

	private Figurehead EscapeShipFigurehead;

	private bool _talkedWithSister;

	private bool _crusasAndSeaHoundMovedToTheConversationPoints;

	private List<GameEntity> _dynamicPatrolAreas;

	private List<Agent> _stealthAgents;

	private WeakGameEntity _crusasConversationPointFrame;

	private WeakGameEntity _slaveTraderConversationPointFrame;

	private GameEntity _approachPointEntity;

	private GameEntity _phase1EnemyShipToInteriorShipDoorEntity;

	private GameEntity _phase1InteriorToEnemyShip3ShipDoorEntity;

	private GameEntity _phase1EnemyShip1InitialSpawnEntity;

	private GameEntity _phase1EnemyShip1TargetEntity;

	private Queue<ConversationSound> _conversationSounds;

	private List<DialogNotificationHandle> _dialogNotificationHandleCache;

	private float _lastCachedPlayerShipDistanceToTargetApproachPoint;

	private MissionTimer _playerShipsTargetApproachPointDistanceCheckTimer;

	private MissionTimer _escapeShipCutLooseTimer;

	private MissionTimer _allowedSwimRadiusCheckTimer;

	private ActionIndexCache _sisterWoundedAnimationActionIndexCache;

	private ActionIndexCache _slaveTraderShipOarsmanActionIndexCache;

	private Vec3 _phase1PlayerShipSpawnPosition;

	private Equipment _mainAgentEquipmentCopyForInteriorMission;

	private MissionShip _phase2EnemyShip1;

	private MissionShip _phase2EnemyShip2;

	private MissionShip _phase2EnemyShip3;

	private MissionShip _phase2EnemyShip4;

	private MissionShip _phase2EnemyShip5;

	private MissionShip _phase2EnemyShipStationary1;

	private GameEntity _phase2EscapeShipPirateTargetFrame1;

	private GameEntity _phase2EscapeShipPirateTargetFrame2;

	private GameEntity _phase2EscapeShipPirateTargetFrame3;

	private GameEntity _phase2EscapeShipPirateTargetFrame4;

	private GameEntity _phase2EscapeShipPirateTargetFrame5;

	private GameEntity _currentPhase2EscapeShipTargetPoint;

	private MissionShip _phase2AllyShip1;

	private MissionShip _phase2AllyShip2;

	private MissionShip _phase2AllyShip3;

	private MissionShip _phase2AllyShip4;

	private MissionShip _phase2AllyShip5;

	private Dictionary<MissionShip, GameEntity> _pirateShipTriggerPoints;

	private Dictionary<MissionShip, bool> _isPirateShipMovementDisabled;

	private Dictionary<MissionShip, ShipAttachmentMachine> _pirateShipEnabledAttachmentMachine;

	private Dictionary<MissionShip, bool> _isPirateShipTriggered;

	private Dictionary<MissionShip, bool> _isPirateShipMovingToTheEscapeShip;

	private Dictionary<MissionShip, bool> _isPirateShipLostItsCrew;

	private Dictionary<MissionShip, bool> _limitPirateShipChasingSpeed;

	private Dictionary<MissionShip, MissionTimer> _autoCutLooseTimersForPirateShips;

	private Dictionary<MissionShip, MissionTimer> _autoEstablishConnectionsForPirateShips;

	private Dictionary<MissionShip, bool> _isMissionShipBoardedToTheEscapeShip;

	private List<GameEntity> _phase2EscapeShipTargetPointEntities;

	private Queue<GameEntity> _phase2EscapeShipTargetPoints;

	private MissionTimer _playerLeftTheEscapeShipTimer;

	private MissionTimer _phase2EscapeShipStuckTimer;

	private Vec3 _phase2EscapeShipStuckCheckPosition;

	private float _escapeShipTargetSpeed;

	private float _escapeShipSpeed;

	private Vec2 _escapeShipTargetDirection;

	private Vec2 _escapeShipDirection;

	private readonly List<KeyValuePair<string, int>> _phase2AllyShip1Troops;

	private readonly List<KeyValuePair<string, int>> _phase2AllyShip2Troops;

	private readonly List<KeyValuePair<string, int>> _phase2AllyShip3Troops;

	private readonly List<KeyValuePair<string, int>> _phase2AllyShip4Troops;

	private readonly List<KeyValuePair<string, int>> _phase2AllyShip5Troops;

	private readonly List<KeyValuePair<string, int>> _phase2EnemyShip1Troops;

	private readonly List<KeyValuePair<string, int>> _phase2EnemyShip2Troops;

	private readonly List<KeyValuePair<string, int>> _phase2EnemyShip3Troops;

	private readonly List<KeyValuePair<string, int>> _phase2EnemyShip4Troops;

	private readonly List<KeyValuePair<string, int>> _phase2EnemyShip5Troops;

	private readonly List<KeyValuePair<string, int>> _phase2EnemyShipStationary1Troops;

	private MissionShip _phase3EnemyShip1;

	private MissionShip _phase3EnemyShip2;

	private MissionShip _phase3EnemyShip3;

	private MissionShip _phase3EnemyShip4;

	private MissionShip _phase3EnemyShip5;

	private MissionShip _phase3EnemyReinforcementShip1;

	private MissionShip _phase3EnemyReinforcementShip2;

	private VolumeBox _phase3TriggerVolumeBox;

	private readonly List<MissionShip> _allyShipTargetKeysBuffer;

	private readonly HashSet<MissionShip> _assignedEnemyShips;

	private bool _isReinforcementCalled;

	private bool _isReinforcementInitialized;

	private readonly List<KeyValuePair<string, int>> _phase3PlayerShipTroops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyShip1Troops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyShip2Troops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyShip3Troops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyShip4Troops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyShip5Troops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyReinforcementShip1Troops;

	private readonly List<KeyValuePair<string, int>> _phase3EnemyReinforcementShip2Troops;

	private int _phase3TotalEnemyCount;

	private BossFightStateEnum BossFightState;

	private List<Agent> _purigShipAgents;

	private List<Agent> _duelPhaseAllyAgents;

	private List<Agent> _duelPhaseEnemyAgents;

	private Queue<ConversationSound> _purigNotifications;

	private Agent _purigBodyguard1;

	private Agent _purigBodyguard2;

	private bool _isPurigCutsceneStarted;

	private bool _isPlayerUsingShipAtTheStartOfThePurigCutscene;

	private StandingPoint _playerStandingPointAtTheStartOfThePurigCutscene;

	private VolumeBox _phase4TriggerVolumeBox;

	private GameEntity _playerSpawnPointEntity;

	private GameEntity _enemyBossSpawnPointEntity;

	private BattleSideEnum _winnerSide;

	private NavalAgentsLogic _navalAgentsLogic;

	private NavalShipsLogic _navalShipsLogic;

	private NavalTrajectoryPlanningLogic _navalTrajectoryPlanningLogic;

	private MissionObjectiveLogic _missionObjectiveLogic;

	private LightScriptedFiresMissionController _lightScriptedFiresMissionController;

	private List<Formation> _availableAllyFormations;

	private List<Formation> _availableEnemyFormations;

	private MissionTimer _endMissionTimer;

	private Formation _playerFormation;

	private MissionShip _playerShip;

	private readonly MobileParty _enemyParty;

	private Agent _laharAgent;

	private Agent _bjolgurAgent;

	private Agent _crusasAgent;

	private Agent _gunnarAgent;

	private Agent _purigAgent;

	private Agent _slaveTraderAgent;

	private CharacterObject _slaveTraderCharacter;

	private Agent[] _slaveTraderShipOarsmen;

	private AgentNavalComponent _gunnarAgentNavalComponent;

	private bool _isCheckpointInitialize;

	private bool _isMissionFailPopUpTriggered;

	private GameEntity JumpOffInitialPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private GameEntity JumpOffTargetPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private GameEntity HidingSpot1Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private MatrixFrame GunnarShipUsePosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameEntity Phase1InteriorCameraSisterEntity
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

	private MissionShip EscapeShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEscapeShipStuck
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

	private int Phase2AllyShip1TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2AllyShip2TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2AllyShip3TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2AllyShip4TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2AllyShip5TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2EnemyShip1TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2EnemyShip2TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2EnemyShip3TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2EnemyShip4TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2EnemyShip5TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase2EnemyShipStationary1TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3PlayerShipTroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyShip1TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyShip2TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyShip3TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyShip4TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyShip5TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyReinforcementShip1TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int Phase3EnemyReinforcementShip2TroopCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public BossFightOutComeEnum BossFightOutCome
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

	public GameEntity BossFightConversationCameraGameEntity
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

	public MissionShip Phase4PurigShip
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

	public Agent SisterAgent
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

	public Quest5SetPieceBattleMissionState LastHitCheckpoint
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

	public Quest5SetPieceBattleMissionState State
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

	public bool ShouldMissionContinueFromCheckpoint
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
	public Quest5SetPieceBattleMissionController(Quest5SetPieceBattleMissionState lastHitCheckpoint, MobileParty enemyParty)
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
	public override void OnFixedMissionTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentTeamChanged(Team prevTeam, Team newTeam, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnEarlyAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canLeave)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRetreatMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnSurrenderMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateObjectiveIfItIsActive(MissionObjective objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndPrintInstructionNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetCurrentGunnarInstructionText(Quest5InstructionState instructionState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisplayCurrentInstructionNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleGunnarMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnableRamp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleIfGunnarFallsIntoTheWater()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeGunnarClimbToDeck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase1Part1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfAnEnemyIsAttackingGunnar()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase1Part2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase1AllyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase1EnemyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableSlaveTraderShipAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip GetShipOfDynamicPartolArea(GameEntity dynamicPatrolArea)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleStealthShipsBridgeConnections()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEscapeShipInteriorDoorUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerShipReachedApproachDistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeStealthPhasePart1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeStealthPhasePart2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MovePhase1EnemyShip1ToItsTargetPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeShipInteriorPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeGoBackToShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetIntendedMainAgentDirectionForPhase1InteriorTeleport(out Vec3 mainAgentDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetIntendedMainAgentDirectionForPhase1EscapeShipTeleport(out Vec3 mainAgentDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerPhase1InitializeShipInteriorPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompletePhase1GoToShipInteriorTransition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerPhase1InitializeGoBackToShipPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompletePhase1InitializeGoBackToShipTransition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTalkedWithSister()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateBuySlaveConversationPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddConversationSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndPlayCrusasAndSlaveTraderConversationSound()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Equipment GetScriptedStealthEquipment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEscapeShipCutLoose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShouldTeleportPlayerBetweenTargetPositionAndHidingSpot()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TeleportPlayerBetweenTargetPositionAndHidingSpot(out Vec3 mainAgentDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShouldTeleportPlayerShipToStartingPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TeleportPlayerShipToStartingPosition(out Vec3 mainAgentDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 CalculateMissionStartDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePlayersBridgeAndControlPointUsagesForPhase1GoToEnemyShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePlayersBridgeAndControlPointUsagesForPhase1SwimmingAndStealthPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePlayersBridgeAndControlPointUsagesForPhase1EscapePhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearPhase1OnPhaseTransition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerInitializePhase2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompletePhase1ToPhase2Transition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase2Part1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase2Part2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase2Part3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase2Part4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTriggerPointForPirateShip(MissionShip ship, GameEntity triggerPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase2AllyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase2EnemyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEscapeShipMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEscapeShipSpeed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePirateShipGettingCloseToEscapeShip(MissionShip pirateShip, GameEntity finalTargetFrameEntity, float gettingCloseSpeed, float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePirateShipMovement(MissionShip pirateShip, GameEntity finalTargetFrameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePirateShipSailModeAccordingToTheGlobalWindVelocity(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIsThereActiveBridgeToBetweenEscapeShipAndAnyPirateShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleStationaryShipMovement(MissionShip stationaryShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AutoEstablishConnectionsForPirateShips(MissionShip ship, GameEntity finalTargetFrameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AutoCutLooseEmptyPirateShipIfPlayerDoesNotForALongTime(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetShipAttachmentJointPhysicsEnabledForShip(MissionShip ship, bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetDisableShipAttachmentMachinesForPlayer(MissionShip ship, bool isDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAttachmentBroken(ShipAttachmentMachine attachmentMachine, ShipAttachmentPointMachine attachmentPointMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleAllyShipMovementDuringPhase2(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePirateShipBridgeConnectionCount(MissionShip pirateShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreAllPhase2PirateShipsEliminated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePlayersBridgeAndControlPointUsagesForPhase2InProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForEscapeShipStuck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfThereIsAnActiveAgentOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleEscapeShipStuck()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MoveEscapeShipAlongTheTrack(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePhase2MovingShipParameters(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ModifyMainAgentEquipmentForPhase2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerInitializePhase3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompletePhase2ToPhase3Transition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearPhase2OnPhaseTransition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase3Part1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase3Part2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase3Part3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase3EnemyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase3AllyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CallReinforcement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeReinforcement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanProceedToPhase4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerInitializePhase4()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompletePhase3ToPhase4Transition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearPhase4OnPhaseTransition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowStartNotifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandlePlayersBridgeAndControlPointUsagesForPhase3InProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerInitializeBossFight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompletePhase4ToBossFightTransition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfEnemyAgentFallIntoTheWater()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPurigCutsceneStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPurigShipCutsceneEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetIntendedMainAgentDirectionForBossFight(out Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectPurigCutsceneNotifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndPlayPurigCutsceneNotifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase4Part1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePhase4Part2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPhase4EnemyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnImmortalAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeNavalBossFightPart1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeNavalBossFightPart2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveAllAgentsExcept(List<Agent> exceptionAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartBossFight(bool isDuel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBossFightDuelModeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBossFightBattleModeInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetAgentForBossFight(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartBossFightConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAllyFrames(out List<GameEntity> allyFrames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetEnemyFrames(out List<GameEntity> enemyFrames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelOver(BattleSideEnum winnerSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(string shipHullId, string spawnPointId, Formation formation, bool spawnAnchored = false, List<KeyValuePair<string, string>> additionalUpgradePieces = null, Figurehead figurehead = null, bool checkForFreeArea = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Formation GetAvailableAllyFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnGunnarOnShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCrusasOnShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnLaharOnShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnBjolgurOnShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAvailableAllyFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Formation GetAvailableEnemyFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAvailableEnemyFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustWindDirectionAccordingToTargetFrame(MatrixFrame frame, float windPowerMultiplier, bool addRandomRotation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerMissionFailPopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIfMainAgentLeftTheEscapeShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndMissionWithAutoContinueFromCheckpoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveGunnarsHelmet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMissionShipTroops(List<KeyValuePair<string, int>> troops, MissionShip ship, PartyBase party = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HealMainHero()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveShipInternal(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CutLooseAllBridgesOfTheShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeGunnarStopUsingGameObjectBeforeMissionEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetLastCheckpoint(Quest5SetPieceBattleMissionState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerPurigsDeadPopUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeShipOarsInvisible(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableAllShipOrderControllers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableShipOrderController(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveShipControlPointDescriptionOfAllEnemyShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveShipControlPointDescriptionOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereAnyShipBoardedToThePlayerShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereAnyEnemyShipsWithinRange(MissionShip missionShip, float range)
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
	public bool GetSpawnHorses(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPlayerControllableTroops()
	{
		throw null;
	}
}
