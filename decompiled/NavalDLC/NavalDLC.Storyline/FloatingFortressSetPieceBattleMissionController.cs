using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using NavalDLC.Storyline.Objectives.Quest4;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline;

public class FloatingFortressSetPieceBattleMissionController : MissionLogic
{
	private abstract class ConversationLine
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void TryPlayLine()
		{
			throw null;
		}

		protected abstract void Play();

		public abstract void Stop();

		public abstract bool IsPlaying();

		protected abstract bool CanBePlayed();

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ConversationLine()
		{
			throw null;
		}
	}

	private class SimpleConversationLine : ConversationLine
	{
		private readonly TextObject _line;

		private readonly CharacterObject _speaker;

		private readonly float _cooldown;

		private readonly NotificationPriority _priority;

		private DialogNotificationHandle _handle;

		private float _blockedTime;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SimpleConversationLine(CharacterObject speaker, string line, float cooldown, NotificationPriority priority)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Play()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void Stop()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsPlaying()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override bool CanBePlayed()
		{
			throw null;
		}
	}

	private class VariantConversationLine : ConversationLine
	{
		public enum VariationType
		{
			Ordered,
			Random
		}

		private int _current;

		private ConversationLine _active;

		private float _blockedTime;

		private readonly List<ConversationLine> _lines;

		private readonly float _cooldown;

		private readonly VariationType _variationType;

		private readonly bool _canShowEachLineOnce;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public VariantConversationLine(ConversationLine[] lines, VariationType variationType, float cooldown, bool canShowEachLineOnce = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Play()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void Stop()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsPlaying()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override bool CanBePlayed()
		{
			throw null;
		}
	}

	private class SequencedConversationLine : ConversationLine
	{
		private float _blockedTime;

		private readonly float _cooldown;

		private readonly ConversationLine[] _lines;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SequencedConversationLine(ConversationLine[] lines, float cooldown)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Play()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void Stop()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsPlaying()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override bool CanBePlayed()
		{
			throw null;
		}
	}

	private class CircularBuffer<T>
	{
		private readonly T[] _buffer;

		private int _head;

		private int _tail;

		private readonly int _capacity;

		public int Count
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

		public T this[int index]
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CircularBuffer(int capacity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Add(T item)
		{
			throw null;
		}
	}

	private class TrailController
	{
		private readonly CircularBuffer<Vec3> _positions;

		private readonly CircularBuffer<float> _timestamps;

		private readonly float _trailDelay;

		private readonly float _recordInterval;

		private float _lastRecordTime;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TrailController(float trailDelay, float recordInterval)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RecordPosition(Vec3 position, float currentTime)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Vec3 GetTrailEndPosition(float currentTime)
		{
			throw null;
		}
	}

	private const float PlayerShipTargetingWarningDistance = 15f;

	private const float TimeToLoseAfterLastBallistaShot = 5f;

	private const float BallistaRandomAttackRadius = 15f;

	private const float BallistaRandomAttackPointSelectionTime = 1f;

	private const string PlayerPhaseOneSpawnPointTag = "sp_player_ship";

	private const string PlayerPhaseTwoSpawnPointTag = "sp_player_phase_two_start";

	private const float PlayerShipTooCloseThresholdDistanceSquared = 10000f;

	private const float PlayerShipLowHpThresholdRatio = 0.65f;

	private const float PlayerRemainingAmmoThresholdRatio = 3f;

	private const float AllyShipAnchorFrameConnectionDistanceSquared = 900f;

	private const string PlayerStartingShipHull = "naval_storyline_quest_4_player_medit_ship";

	private const float AllyShipDistanceToSelfAnchor = 200f;

	private const int PlayerBallistaStartingAmmo = 30;

	private static readonly List<(string, string)[]> AllyShipUpgrades;

	private const int BridgesBetweenEnemyShips = 1;

	private readonly List<Figurehead> _allyShipFigureheads;

	private readonly Dictionary<string, string> _playerShipUpgradePieces;

	private readonly List<string> _allyShipHulls;

	private readonly List<(string, int)> _playerShipTroops;

	private readonly List<(string, int)[]> _allyShipAgents;

	private readonly (string, string)[] _enemyShipHulls;

	private readonly List<(string, int)[]> _initialEnemyShipAgents;

	private readonly List<(string, int)[]> _reinforcementEnemyShipAgents;

	private readonly Dictionary<int, string> _enemyShipsToAddBallista;

	private MissionShip _playerShip;

	private GameEntity _trailingTargetObject;

	private ShipTargetMissionObject _playerShipTargetObject;

	private readonly TrailController _playerShipTargetObjectTrailController;

	private MBList<MissionShip> _enemyMissionShipsOrdered;

	private bool _isPhaseOneInitialized;

	private int _currentPhaseOneInitializationTick;

	private float _playerLoseRemainingTime;

	private float _lastRandomAttackPointPickTime;

	private Vec3 _randomAttackPoint;

	private bool _shouldStartPhaseTwo;

	private bool _isPhaseTwoInitialized;

	private int _currentPhaseTwoInitializationTick;

	private bool _isMissionSuccessful;

	private bool _isMissionFailed;

	private List<GameEntity> _entities;

	private readonly MBList<MissionShip> _playerAllyMissionShips;

	private readonly MBList<(MissionShip, bool)> _playerAllyShipAnchorState;

	private readonly MBList<DestructableComponent> _enemySiegeWeaponDestructables;

	private readonly Dictionary<DestructableComponent, DestructableComponent> _enemySiegeWeaponByCover;

	private readonly Dictionary<RangedSiegeWeapon, Agent> _cachedMangonelAgents;

	private NavalAgentsLogic _navalAgentsLogic;

	private NavalShipsLogic _navalShipsLogic;

	private readonly ConversationLine _playerShipTooCloseLine;

	private readonly ConversationLine _playerShipLowHpLine;

	private readonly ConversationLine _playerShipRemainingAmmoLine;

	private readonly ConversationLine _playerShipStandingStillLine;

	private readonly ConversationLine _playerShipHitLine;

	private readonly ConversationLine _playerShipSailDestroyedLine;

	private readonly ConversationLine _playerTookMangonelDownLine;

	private readonly ConversationLine _playerTookAllMangonelsDownLine;

	private MissionObjectiveLogic _missionObjectiveLogic;

	private BoardFloatingFortressObjective _boardFloatingFortressObjective;

	private DefeatTheEnemyCrewObjective _defeatTheEnemyCrewObjective;

	public bool IsPhaseOneCompleted
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

	public bool IsStartedFromCheckpoint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MissionShip> EnemyShipsOrdered
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FloatingFortressSetPieceBattleMissionController(bool startFromCheckpoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickPhaseOneInitialization()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickPhaseOneLogic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickPhaseTwoLogic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickPhaseTwoInitialization()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnemyShipBallistaDestroyed(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnemyShipBallistaCoverDestroyed(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
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
	private MissionShip CreateMissionShip(Ship ship, string spawnPointId, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConnectEnemyShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryMaintainConnection(MissionShip ship, MissionShip otherShip)
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
	private void SetWindStrengthAndDirection(Vec2 direction, float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyShipAgents(MissionShip ship, (string, int)[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyShipAgents(MissionShip ship, (string, int)[] source)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMainAgentHealthChanged(Agent agent, float oldHealth, float newHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionSucceeded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMissionFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnViewFadeOut(int reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRetreatMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipHit(MissionShip ship, Agent attackerAgent, int damage, Vec3 impactPosition, Vec3 impactDirection, MissionWeapon weapon, int affectorWeaponSlotOrMissileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyEnemyBallistas()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetAllySpawnPoint(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vec3 GetRandomPointOnCircle(Vec3 center, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FloatingFortressSetPieceBattleMissionController()
	{
		throw null;
	}
}
