using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.DWA;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.NavalPhysics;
using NavalDLC.Missions.Objects.UsableMachines;
using NavalDLC.Missions.ShipActuators;
using NavalDLC.Missions.ShipControl;
using NavalDLC.Missions.ShipInput;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects.Usables;

namespace NavalDLC.Missions.Objects;

public class MissionShip : MissionObject
{
	public enum ShipInstanceType
	{
		None,
		MissionShip,
		EditorShip
	}

	public enum SailState : byte
	{
		Intact,
		Burning,
		Destroyed
	}

	public struct ShipCollisionData
	{
		public MissionShip CollidingShip;

		public Vec3 ContactPosAvg;

		public float Damage;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipCollisionData(MissionShip collidingShip, Vec3 contactPosAvg, float damage)
		{
			throw null;
		}
	}

	private const float DamageCooldownForShipInSeconds = 2f;

	private const float CollisionDirectionSpeedThresholdToDamage = 3f;

	private const float MaxSoundPositionUpdateDistanceSquared = 10000f;

	public const string OuterDeckTroopSpTag = "sp_troop_outer_deck";

	public const string InnerDeckTroopSpTag = "sp_troop_inner_deck";

	public const string CaptainTroopSpTag = "sp_troop_captain";

	public const string CrewTroopSpTag = "sp_troop_crew_spawn";

	public const string RallyPointTag = "rally_point";

	public const string BannerTag = "banner_with_faction_color";

	public const string SailMeshTag = "sail_mesh_entity";

	public const float NavmeshDisableLimit = 0.35f;

	private static TextObject PlayerSideShipSinkingText;

	private static TextObject EnemySideShipSinkingText;

	private readonly MBList<MissionShip> _temporaryMissionShipContainer;

	private readonly MBList<MissionShip> _temporaryMissionShipContainer2;

	private readonly MBQueue<MissionShip> _temporaryMissionShipQueue;

	private static readonly int _scrapeSoundEventID;

	private readonly QueryData<bool> _anyActiveFormationTroopOnShip;

	private MBList<(int, SoundEvent)> _scrapeSoundEvents;

	public bool ShouldUpdateSoundPos;

	private SailInput _customSailSetting;

	private MissionShipObject _missionShipObject;

	private NavalAgentMoraleInteractionLogic _moraleInteractionLogic;

	private MBList<MatrixFrame> _outerDeckLocalFrames;

	private MBList<MatrixFrame> _innerDeckLocalFrames;

	private MBList<MatrixFrame> _crewSpawnLocalFrames;

	private int _nextDeckSpawnFrameIndex;

	private bool _autoUpdateController;

	private int _nextCrewSpawnFrameIndex;

	private MBList<ShipAttachmentMachine> _attachmentMachines;

	private MBList<IShipEventListener> _shipEventListeners;

	private bool _isCapsized;

	private MBList<ShipAttachmentPointMachine> _attachmentPointMachines;

	private bool _postponeOnUnitAttached;

	private Timer _postponeOnUnitAttachedTimer;

	private MBList<ShipShieldComponent> _shields;

	private Timer _capsizeDamageTimer;

	private MBList<GameEntity> _bannerEntities;

	private MBList<GameEntity> _sailMeshEntities;

	private WorldPosition _cachedWorldPositionOnDeck;

	private bool _isCachedWorldPositionOnDeckDirty;

	private bool _isShipNavmeshDisabled;

	private bool _isRemoved;

	private float _nextFireHitPointRestoreTime;

	private float _nextPermanentBurnDamageTime;

	private bool _foldSailsOnBridgeConnection;

	private HashSet<MissionShip> _visitedMissionShips;

	private Vec2[] _localPhysicsBoundingBoxXYPlaneVertices;

	private Vec2[] _scaledLocalPhysicsBoundingBoxXYPlaneVertices;

	private Vec2[] _physicsBoundingBoxXYPlaneVertices;

	private Vec2[] _criticalZoneVertices;

	private ShipInputProcessor _inputProcessor;

	private NavalDLC.Missions.ShipActuators.ShipActuators _actuators;

	private ShipInputRecord _inputRecord;

	private NavalDLC.Missions.NavalPhysics.NavalPhysics _physics;

	private float[] _partialHitPoints;

	private MBList<ShipAttachmentMachine> _shipAttachmentMachines;

	private MBList<ShipOarMachine> _leftSideShipOarMachines;

	private MBList<ShipOarMachine> _rightSideShipOarMachines;

	private MBList<ShipOarMachine> _shipOarMachines;

	private MBList<ShipUnmannedOar> _shipUnmannedOars;

	private MBList<ClimbingMachine> _climbingMachines;

	private MBList<DestructableComponent> _allDestructibleComponents;

	private ShipDWAAgentDelegate _dwaAgentDelegate;

	private MissionShipRam _ram;

	private MBList<AmmoBarrelBase> _ammoBarrels;

	private float _connectionBlockedShipTime;

	private float _disconnectionBlockedShipTime;

	private MBList<SailVisual> _sailVisuals;

	private BoundingBox _localBoundingBoxCached;

	private bool _localBoundingBoxCacheInvalid;

	private List<(GameEntity, PhysicsEventType)> _currentCollisionStatesToShips;

	private PhysicsEventType _currentCollisionState;

	private readonly Dictionary<MissionShip, float> _shipDamageCooldowns;

	private readonly ConcurrentQueue<ShipCollisionData> _shipCollisionData;

	private static uint _missionShipScriptNameHash;

	public static int MaxShipIndex
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

	public bool AnyActiveFormationTroopOnShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Index
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

	public bool IsRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame GlobalFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MatrixFrame> OuterDeckLocalFrames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MatrixFrame> InnerDeckLocalFrames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MatrixFrame> CrewSpawnLocalFrames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int DeckFrameCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<GameEntity> BannerEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<GameEntity> SailMeshEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Banner Banner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public (uint sailColor1, uint sailColor2) SailColors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public NavalDLC.Missions.NavalPhysics.NavalPhysics Physics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxHealth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxFireHealth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxPartialHealth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int TotalCrewCapacity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int CrewSizeOnMainDeck
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

	public int CrewSizeOnLowerDeck
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AIShipController AIController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAIControlled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPlayerControlled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsFormationAndShipAIControlled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public PlayerShipController PlayerController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FormationClass FormationIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public BattleSideEnum BattleSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MissionShipObject MissionShipObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public NavalShipsLogic ShipsLogic
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

	public Team Team
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Formation Formation
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

	public Agent Captain
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInitialized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRetreating
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SailState ShipSailState
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

	public bool HasCustomSailSetting
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

	public bool IsSinking
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipOrder ShipOrder
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

	public IShipOrigin ShipOrigin
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

	public bool IsPlayerShip
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame RallyFrame
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

	public float HitPoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float FireHitPoints
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

	public float VisualRudderRotationPercentage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float VisualRudderRotation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float SailTargetSetting
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MissionSail> Sails
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ulong ShipUniqueBitwiseID
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

	public ulong ShipIslandCombinedID
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

	public bool IsShipOrderActive
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

	public bool IsClimbingMachineStandAloneTickingActive
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

	public MBReadOnlyList<ShipAttachmentMachine> AttachmentMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipAttachmentPointMachine> AttachmentPointMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipShieldComponent> Shields
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ClimbingMachineDetachment ClimbingMachineDetachment
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

	public MBReadOnlyList<ShipAttachmentMachine> ShipAttachmentMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipOarMachine> LeftSideShipOarMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipOarMachine> RightSideShipOarMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipOarMachine> ShipOarMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ClimbingMachine> ClimbingMachines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipUnmannedOar> ShipUnmannedOars
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<DestructableComponent> AllDestructableComponents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipControllerMachine ShipControllerMachine
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

	public ShipInputRecord InputRecord
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxSailHitPoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SoundEvent SailBurningSoundEvent
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

	public float SailHitPoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDeployed
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

	public bool CanBeTakenOver
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

	public Agent SailBurnerAgent
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

	public ShipController Controller
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

	public RangedSiegeWeapon ShipSiegeWeapon
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

	public bool HasDWAAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int DWAAgentId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ref readonly DWAAgentState DWAAgentState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ShipPlacementDetachment ShipPlacementDetachment
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

	public override TextObject HitObjectName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static uint MissionShipScriptNameHash
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BreakAllExistingConnections()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsConnectionBlocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsConnectionPermanentlyBlocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDisconnectionBlocked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BlockConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetDisconnectionBlock()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetConnectionBlock()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipOrderActive(bool isOrderActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShipClimbingOrderStandAloneTickingActive(bool isShipClimbingMachineStandaloneTickingActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFoldSailsOnBridgeConnection(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipConnected(ShipAttachmentMachine.ShipAttachment currentAttachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipDisconnected(ShipAttachmentMachine.ShipAttachment currentAttachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSiegeWeaponsInitialAmmoCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetAbilityOfFaces(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentOnShipNavmesh(int testedNavmeshID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPartialHitPoints(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetController(ShipControllerType controllerType, bool autoUpdateController = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanBeTakenOver(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MissionShip> GetShipsConnectedWithBridges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInputRecord(in ShipInputRecord record)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOarAppliedForceMultiplierForStoryMission(float forceMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SearchShipConnection(MissionShip soughtShip, bool isDirect, bool findEnemy, bool enforceActive, bool acceptNotBridgedConnections)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormation(Formation newFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeLocalPhysicsBoundingXYPlane()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2[] CalculateBoundingXYGlobalPlaneFromLocal(in MatrixFrame shipFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2[] GetLocalPhysicsBoundingBoxXYPlaneVertices(float scale = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSinkingState(NavalDLC.Missions.NavalPhysics.NavalPhysics.SinkingState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnchor(bool isAnchored, bool anchorInPlace = false, float forceMultiplier = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnchorFrame(in Vec2 position, in Vec2 direction, float forceMultiplier = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DealCollisionDamage(MissionShip hitterShip, bool isRamDamage, Vec3 point, float damage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetFormationPositioning()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DealDamage(float rawDamage, MissionShip rammingShip, out int inflictedDamage, out int modifiedDamage, out DamageTypes damageType, out bool isFatalDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DealDamageToSails(Agent attackerAgent, float damage, MissionSail sailHit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsConnectedToEnemyWithoutBridges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasThrownOrActiveBridgeConnections()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasMachine(UsableMachine usableMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsShipInCriticalZoneBetween(MissionShip ship2, MBReadOnlyList<MissionShip> allShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2[] GetCriticalZoneVerticesBetween(MissionShip otherShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsConnectedToEnemy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsConnectedToEnemy(out MissionShip connectedEnemyShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsConnectedToEnemyWithSide(out Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipObjectUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MissionShip> GetConnectedShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDynamicNavmeshIdStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetBridgeWithEnemyActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsAnyBridgeActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetWorldPositionOnDeck(out WorldPosition worldPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalState GetNavalState(in NavalVec localOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FacingOrder GetFacingOrderToRallyPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementOrder GetMovementOrderToRallyPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositioningOrdersToRallyPoint(bool applyToPlayerFormation, bool playersOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MissionShip> GetNavmeshConnectedShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ComputeActiveShipAttachmentCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSailBurningSoundPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPostponeOnUnitAttached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSaveAsPrefab()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionShip GetOutermostConnectedShipFromSide(bool rightSide, out bool effectiveSideOfOutermostShip, ulong aggregateShipUniqueID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBoundingBoxValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsAgentOnShip(Agent agent, bool bypassSteppedShipCheck = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetNextCrewSpawnGlobalFrame(out MatrixFrame crewSpawnGlobalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetNextOuterInnerSpawnGlobalFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetMiddleInnerSpawnGlobalFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetCaptainSpawnGlobalFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalState GetNavalState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsThereActiveBridgeTo(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MissionShip> GetFullyConnectedShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AttachDynamicNavmeshToEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity CheckHitSails(Agent attackerAgent, GameEntity alreadyHitEntityToIgnore, int missileIndex, in Vec3 missileOldPosition, in Vec3 missilePosition, in MissionWeapon missileWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnHit(Agent attackerAgent, int inflictedDamage, Vec3 impactPosition, Vec3 impactDirection, in MissionWeapon weapon, int affectorWeaponSlotOrMissileIndex, ScriptComponentBehavior attackerScriptComponentBehavior, out bool reportDamage, out float finalDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float DealFireDamage(float fireDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParallelFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPhysicsCollision(ref PhysicsContact contactPairList, WeakGameEntity entity0, WeakGameEntity entity1, bool isFirstShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleQueuedShipCollisions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QueueShipCollision(MissionShip collidingShip, Vec3 contactPosAvg, float damage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanDealDamage(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateDamageCooldown(MissionShip targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitForMission(int shipIndex, ulong shipUniqueBitwiseID, ShipAssignment shipAssignment, NavalShipsLogic shipsLogic)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFormationUnitRemoved(Formation formation, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeNavalPhysics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipSpawned(MissionShip spawnedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipRemoved(MissionShip removedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearFloaterVolumes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetRemoved(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnShipTransferred(MissionShip ship, Formation oldFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IDWAAgentDelegate CreateDWAAgent(in DWASimulatorParameters parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MoveShipToTheTargetWithDirection(MatrixFrame currentFrame, Vec2 targetPosition, Vec2 targetDirection, float maxAcceleration, float maxAngularAcceleration, float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleCapsizing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ValidateShipAndDescendantEntitiesAndBoundingBoxes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUnitAttached(Formation formation, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeStaticLocalBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePartialDurabilities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeShipBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RecalculateShipIsland()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetPostponeOnUnitAttachedTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsShipUpsideDown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAbilityOfShipNavmeshFaces(bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachDynamicNavmeshFromMachines(MBList<ShipAttachmentMachine> shipAttachmentMachines, MBList<ShipAttachmentPointMachine> shipAttachmentPointMachines)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckAttachedNavmeshSanity(bool isEditorMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckPhysicsOfChildren()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckSpawnPoints(bool fromEditor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckOarCount(bool fromEditor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckSpawnPointsNavMeshSanityAux(bool fromEditor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckAttachedNavmeshSanityAux(MBList<ShipAttachmentMachine> shipAttachmentMachines, MBList<ShipAttachmentPointMachine> shipAttachmentPointMachines, bool fromEditor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int DeckSpawnFrameSortingFunction(MatrixFrame deckFrame1, MatrixFrame deckFrame2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeLists(bool isForCheckingForProblems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadSpawnPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanPhysicsCollideBetweenTwoEntities(WeakGameEntity myEntity, WeakGameEntity otherEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadShipBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AreShipsConnected(MissionShip ship1, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSetRangedWeaponControlMode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentUsingSiegeWeapon(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomSailSetting(bool enableCustomSailSetting, SailInput customSailSetting)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ShootBallista()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToMaintainConnectionToAnotherShip(MissionShip otherShip, bool forceBridge = true, bool unbreakableBridge = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToConnectionToAttachmentMachine(ShipAttachmentMachine otherAttachmentMachine, bool forceBridge = true, bool unbreakableBridge = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisconnectedWithShip(MissionShip otherShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateLocalBoundingBoxCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateActiveFormationTroopOnShipCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SeparateShipIslands(MissionShip ship1, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void MergeShipIslands(MissionShip ship1, MissionShip ship2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionShip()
	{
		throw null;
	}
}
