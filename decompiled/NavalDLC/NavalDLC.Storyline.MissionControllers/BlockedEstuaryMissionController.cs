using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.Storyline.Objects;
using NavalDLC.Storyline.Quests;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline.MissionControllers;

public class BlockedEstuaryMissionController : MissionLogic
{
	public enum BattlePhase
	{
		Phase1,
		Phase2,
		Phase3
	}

	private class BurningProjectile
	{
		private const string ProjectileFireParticleId = "fire_obstacle";

		private float _minLifeTime;

		private float _timer;

		private float _spawnTime;

		private Vec3 _position;

		private Func<bool> _endCondition;

		public bool Initialized
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

		public GameEntity GameEntity
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
		public BurningProjectile(Vec3 position, float minLifeTime = 10f, float spawnAfterTime = 1f, Func<bool> enderFunction = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(float dt, out bool shouldBeRemoved)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SpawnEntity(Vec3 position)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Clear()
		{
			throw null;
		}
	}

	private class EnemySpawnPoint
	{
		private const float GroupRadius = 20f;

		private GameEntity _entity;

		private AgentNavigator _navigator;

		public bool IsAlerted
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

		public Vec3 Position
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public Agent Agent
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
		public EnemySpawnPoint(string spawnId, CharacterObject character, bool isNight)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EnemySpawnPoint(GameEntity spawnEntity, CharacterObject character, bool isNight)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalmDown()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool CanSeeAgent(Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Alert()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Clear()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SpawnAgent(CharacterObject character, bool isNight)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Agent SpawnAgentAux(Vec3 position, Vec2 direction, CharacterObject character, bool isNight, string patrolTag = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsDepleted()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(float dt, BlockedEstuaryMissionController controller)
		{
			throw null;
		}
	}

	private class EnemyShipTrigger
	{
		private VolumeBox _trigger;

		private IShipOrigin _shipOrigin;

		private GameEntity _spawnEntity;

		private GameEntity _destination;

		private bool _isTriggered;

		public MissionShip Ship
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
		public EnemyShipTrigger(GameEntity spawnPoint, VolumeBox volumeBox, IShipOrigin shipOrigin, string destinationId = null)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(MissionShip target, float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SpawnShip()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AnchorShip()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SendToDestination()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void TriggerShip()
		{
			throw null;
		}
	}

	private const string EscapeZoneId = "escape_zone";

	private const string JumpingZoneId = "jumping_zone";

	private const string Fire2ZoneId = "fire_2_zone";

	private const string InitialTriggerZoneId = "burning_zone";

	private const string FireSystemId = "fire_particles";

	private const string Fire3ZoneId = "fire_3_zone";

	private const string CheckPointZoneId = "dismount_zone";

	private const string RampHolderId = "ramp_holder";

	private const string EnemyShipSpawnIdBase = "sp_enemy_ship_";

	private const string EnemyShipTriggerSpawnIdBase = "sp_enemy_trigger_";

	private const string EnemyShipDestinationIdBase = "sp_enemy_ship_destination_";

	private const string TargetShipSpawnId = "sp_enemy_ship_1";

	private const string PlayerBurningShipSpawnId = "sp_player_burning_ship";

	private const string PlayerBurningShipCheckpointSpawnId = "sp_player_burning_ship_checkpoint";

	private const string PlayerShipSpawnId = "sp_player_ship";

	private const string PlayerWaterSpawnPointAfterFadeToBlackId = "sp_player_mount";

	private const string PlayerCheckPointSpawnPointId = "sp_player_checkpoint";

	private const string GangradirBurningShipSpawnId = "sp_gangradir_burning_ship";

	private const string HorseSpawnPointId = "sp_horse";

	private const string HorseItemId = "sturgia_horse_tournament";

	private const string EnemyAgentPatrolPointBaseId = "sp_guard_patrol";

	private const string EnemyAgentSpawnPointBaseId = "enemy_group_parent";

	private const float WindStrength = 4f;

	private const float BurningSpreadRateMultiplier = 20f;

	private static readonly int BurningSoundEventId;

	private const float FirePatchFireDamage = 600f;

	private const float DefaultSpreadRate = 0.5f;

	private const float EscapePhaseNotificationCooldown = 15f;

	private static MBList<string> _enemyAgentCharacterIds;

	private MissionObjectiveLogic _missionObjectiveLogic;

	public Action OnCheckPointReachedEvent;

	public Action OnLastExitZoneReachedEvent;

	public Action OnPhaseEnd;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private ShipAgentSpawnLogic _shipAgentSpawnLogic;

	private AgentNavalComponent _mainAgentNavalComponent;

	private VolumeBox _escapeZone;

	private VolumeBox _jumpingZone;

	private VolumeBox _fire2Zone;

	private VolumeBox _initialTriggerZone;

	private VolumeBox _fire3Zone;

	private VolumeBox _checkPointZone;

	private MBList<EnemyShipTrigger> _triggers;

	private Dictionary<BurnShipObject, (BurningSystem, float)> _playerShipBurningSystems;

	private BurningSystem _enemyShipBurningSystem;

	private List<BurningProjectile> _projectileParticles;

	private float _shipDamageCheckTimer;

	private float _shipBurnProgress;

	private List<Agent> _burntShipAgents;

	private MBList<BurnShipObject> _burningMachines;

	private bool _initializeGangradirBurningShip;

	private bool _showedLastWarning;

	private SoundEvent _burningShipSoundEvent;

	private bool _sightedEnemies;

	private bool _firstCollisionFirePatch;

	private bool _firePatchSpawned;

	private float _boardedNotificationTimer;

	private float _incomingShotNotificationTimer;

	private float _shipHitNotificationTimer;

	private bool _playerShipHasLowHealth;

	private bool _enemyGotClose;

	private BattlePhase _currentPhase;

	private MissionTimer _gunnarHorsePhaseCheckTimer;

	private bool _enemyAreaReached;

	private bool _playerLeftBehind;

	private IShipOrigin _playerBurningShipOrigin;

	private IShipOrigin _enemyBurningShipOrigin;

	private IShipOrigin _playerShipOrigin;

	private MBList<IShipOrigin> _enemyShipOrigins;

	private bool _isShipBurning;

	private MissionShip _playerShip;

	private bool _initialized;

	private bool _enemiesPanicked;

	private bool _shipsCollided;

	private MissionTimer _missionEndTimer;

	private MissionTimer _missionPhaseEndTimer;

	private MissionTimer _collisionTimer;

	private bool _talkedToGangradir;

	private Agent _playerHorse;

	private Agent _horse;

	private Agent _gangradir;

	private bool _gangradirShouldEscape;

	private Vec3 _escapePosition;

	private readonly MobileParty _enemyParty;

	private readonly bool _startFromCheckPoint;

	private bool _checkPointReached;

	private MBList<EnemySpawnPoint> _enemyAgentSpawnPoints;

	public bool CanEndBattleNatively
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public BattlePhase CurrentPhase
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

	public MissionShip BurningShip
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

	public bool IsShipBurning
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

	public bool ShipsCollided
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsEnding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CollisionImminent
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

	public bool LastExitZoneReached
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

	private MissionShip TargetShip
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockedEstuaryMissionController(MobileParty enemyParty, bool startFromCheckPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickMissionPhase1(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickShipHealth(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnableRamp(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeEnemiesPanic(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickParticlesAndBurningSystems(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BurnSails(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ToggleShipBallistas(MissionShip ship, bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableShip(MissionShip ship, bool burnSails = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetWindStrengthAndDirection(Vec2 direction, float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProceedToPhase2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Agent> GetAgentsOfInterest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrepareGangradirForSecondPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyAgentsOnRoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FadeoutEnemyAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TeleportMainAgent(string spawnPointId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ShowNotification(TextObject text, bool isAnnouncedByGunnar, NotificationPriority priority = (NotificationPriority)2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyCollidingShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBurningMachineUsed(BurnShipObject burnShipObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeGangradirEscapeShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowGangradirEscapeNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetEscapePosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetEscapePosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetEscapePosition(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateAllBurningSystems(float spreadRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateBurningSystem(BurnShipObject burnShipObject, float spreadRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickMissionPhase2(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickGunnar(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProceedToRideWithoutTalkingToGangradir()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnGangradirOnShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckEnemyGroups(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProceedToPhase3()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateEnemyShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeShipTriggers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearEnemyGroups()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentMount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTalkedToGangradirPhase2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetRandomPositionAroundCheckPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissileHit(Agent attacker, Agent victim, bool isCanceled, AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentDismount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickHorse(Agent rider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCheckPointReached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickMissionPhase3(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickEnemyShips(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipCaptured(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetTroopCountOfShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerShipReachedDestination()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBridgeConnected(MissionShip source, MissionShip target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipHit(MissionShip ship, Agent attackerAgent, int damage, Vec3 impactPosition, Vec3 impactDirection, MissionWeapon weapon, int affectorWeaponSlotOrMissileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBallistaShot(Missile missile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipSunk(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsShipActive(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CacheParticleEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<BurnShipObject, (BurningSystem, float)> CreateBurningSystemForPlayerShip(MissionShip burningShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BurningSystem CreateBurningSystem(WeakGameEntity parent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateBurningNode(BurningSystem system, GameEntity newNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipCollision(MissionShip ship1, WeakGameEntity targetEntity, Vec3 averageContactPoint, Vec3 totalImpulseOnShip, bool isFirstImpact)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStateFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerOnShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGangradirActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFail(TextObject notification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSuccess(TextObject notification = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerBurningShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeBurningMachines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerTradeShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTargetPoint(MissionShip playerShip, Vec3 localOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableTargetShipObject(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerTeamAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnGangradir(string spawnId, bool noHorses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnGangradir(Vec3 position, bool noHorses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerEnemyShip(MissionShip ship, MissionShip target = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeEnemyShip(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyTargetShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip SpawnEnemyChaserShip(GameEntity spawnPoint, IShipOrigin shipOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SpeakToTheSailorsQuest GetQuest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanSeeShip(Agent agent, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(IShipOrigin ship, Team team, Formation formation, GameEntity spawnEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnPlayerHorse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnHorse(Vec3 position, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool WillHitBoundingBox(Vec3 origin, Vec2 velocity2D, Vec3 boxMin, Vec3 boxMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec2[] GetShipPhysicsBox(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoesShipCollideWithProjectile(MissionShip ship, BurningProjectile projectile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoesShipCollideWithSphere(MissionShip ship, Vec2 origin, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool PlaneIntersectsCircle(Vec2[] corners, Vec2 circleOrigin, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPointInPolygon(Vec2 point, Vec2[] polygonCorners)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BlockedEstuaryMissionController()
	{
		throw null;
	}
}
