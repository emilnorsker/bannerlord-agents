using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NetworkMessages.FromServer;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Missions;

namespace TaleWorlds.MountAndBlade;

public sealed class Mission : DotNetObject, IMission
{
	public class MBBoundaryCollection : IDictionary<string, ICollection<Vec2>>, ICollection<KeyValuePair<string, ICollection<Vec2>>>, IEnumerable<KeyValuePair<string, ICollection<Vec2>>>, IEnumerable, INotifyCollectionChanged
	{
		[CompilerGenerated]
		private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MBBoundaryCollection _003C_003E4__this;

			private int _003Ccount_003E5__2;

			private int _003Ci_003E5__3;

			object IEnumerator<object>.Current
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[DebuggerHidden]
				get
				{
					throw null;
				}
			}

			object IEnumerator.Current
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[DebuggerHidden]
				get
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__0(int _003C_003E1__state)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool MoveNext()
			{
				throw null;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__1 : IEnumerator<KeyValuePair<string, ICollection<Vec2>>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private KeyValuePair<string, ICollection<Vec2>> _003C_003E2__current;

			public MBBoundaryCollection _003C_003E4__this;

			private int _003Ccount_003E5__2;

			private int _003Ci_003E5__3;

			KeyValuePair<string, ICollection<Vec2>> IEnumerator<KeyValuePair<string, ICollection<Vec2>>>.Current
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[DebuggerHidden]
				get
				{
					throw null;
				}
			}

			object IEnumerator.Current
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				[DebuggerHidden]
				get
				{
					throw null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			public _003CGetEnumerator_003Ed__1(int _003C_003E1__state)
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				throw null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool MoveNext()
			{
				throw null;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw null;
			}
		}

		private readonly Mission _mission;

		public int Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public bool IsReadOnly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public ICollection<string> Keys
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public ICollection<ICollection<Vec2>> Values
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public ICollection<Vec2> this[string name]
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

		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			add
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			remove
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__0))]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__1))]
		public IEnumerator<KeyValuePair<string, ICollection<Vec2>>> GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetBoundaryRadius(string name)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void GetOrientedBoundariesBox(out Vec2 boxMinimum, out Vec2 boxMaximum, float rotationInRadians = 0f)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal MBBoundaryCollection(Mission mission)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Add(KeyValuePair<string, ICollection<Vec2>> item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Clear()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Contains(KeyValuePair<string, ICollection<Vec2>> item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CopyTo(KeyValuePair<string, ICollection<Vec2>>[] array, int arrayIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Remove(KeyValuePair<string, ICollection<Vec2>> item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Add(string name, ICollection<Vec2> points)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Add(string name, ICollection<Vec2> points, bool isAllowanceInside)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ContainsKey(string name)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Remove(string name)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool TryGetValue(string name, out ICollection<Vec2> points)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<Vec2> GetBoundaryPoints(string name)
		{
			throw null;
		}
	}

	public class DynamicallyCreatedEntity
	{
		public string Prefab;

		public MissionObjectId ObjectId;

		public MatrixFrame Frame;

		public List<MissionObjectId> ChildObjectIds;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicallyCreatedEntity(string prefab, MissionObjectId objectId, MatrixFrame frame, ref List<MissionObjectId> childObjectIds)
		{
			throw null;
		}
	}

	[Flags]
	[EngineStruct("Weapon_spawn_flag", true, "wsf", false)]
	public enum WeaponSpawnFlags : uint
	{
		None = 0u,
		WithHolster = 1u,
		WithoutHolster = 2u,
		AsMissile = 4u,
		WithPhysics = 8u,
		WithStaticPhysics = 0x10u,
		UseAnimationSpeed = 0x20u,
		CannotBePickedUp = 0x40u
	}

	[EngineStruct("Mission_combat_type", false, null)]
	public enum MissionCombatType
	{
		Combat,
		ArenaCombat,
		NoCombat
	}

	public enum BattleSizeType
	{
		Battle,
		Siege,
		SallyOut
	}

	[EngineStruct("Agent_creation_result", false, null)]
	internal struct AgentCreationResult
	{
		internal int Index;

		internal UIntPtr AgentPtr;

		internal UIntPtr PositionPtr;

		internal UIntPtr IndexPtr;

		internal UIntPtr FlagsPtr;

		internal UIntPtr StatePtr;

		internal UIntPtr MovementModePointer;

		internal UIntPtr ControllerPointer;

		internal UIntPtr MovementDirectionPointer;

		internal UIntPtr PrimaryWieldedItemIndexPointer;

		internal UIntPtr OffHandWieldedItemIndexPointer;

		internal UIntPtr Channel0CurrentActionPointer;

		internal UIntPtr Channel1CurrentActionPointer;

		internal UIntPtr MaximumForwardUnlimitedSpeed;
	}

	public struct TimeSpeedRequest
	{
		public float RequestedTimeSpeed
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

		public int RequestID
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
		public TimeSpeedRequest(float requestedTime, int requestID)
		{
			throw null;
		}
	}

	private enum GetNearbyAgentsAuxType
	{
		Friend = 1,
		Enemy,
		All
	}

	public static class MissionNetworkHelper
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Agent GetAgentFromIndex(int agentIndex, bool canBeNull = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MBTeam GetMBTeamFromTeamIndex(int teamIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Team GetTeamFromTeamIndex(int teamIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MissionObject GetMissionObjectFromMissionObjectId(MissionObjectId missionObjectId)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static CombatLogData GetCombatLogDataForCombatLogNetworkMessage(CombatLogNetworkMessage message)
		{
			throw null;
		}
	}

	public class Missile : MBMissile
	{
		public GameEntity Entity
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

		public MissionWeapon Weapon
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

		public Agent ShooterAgent
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

		public MissionObject MissionObjectToIgnore
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

		public GameEntity AlreadyHitEntityToIgnore
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
		public Missile(Mission mission, int index, GameEntity entity, Agent shooterAgent, MissionWeapon weapon, MissionObject missionObjectToIgnore)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalculatePassbySoundParametersMT(ref SoundEventParameter soundEventParameter)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalculateBounceBackVelocity(Vec3 rotationSpeed, AttackCollisionData collisionData, out Vec3 velocity, out Vec3 angularVelocity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void PassThroughEntity(GameEntity entity)
		{
			throw null;
		}
	}

	public struct SpectatorData
	{
		public Agent AgentToFollow
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

		public IAgentVisual AgentVisualToFollow
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

		public SpectatorCameraTypes CameraType
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
		public SpectatorData(Agent agentToFollow, IAgentVisual agentVisualToFollow, SpectatorCameraTypes cameraType)
		{
			throw null;
		}
	}

	private class DynamicEntityInfo
	{
		public GameEntity Entity;

		public Timer TimerToDisable;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicEntityInfo()
		{
			throw null;
		}
	}

	public enum State
	{
		NewlyCreated,
		Initializing,
		Continuing,
		EndingNextFrame,
		Over
	}

	public enum BattleSizeQualifier
	{
		Small,
		Medium
	}

	public enum MissionTeamAITypeEnum
	{
		NoTeamAI,
		FieldBattle,
		Siege,
		SallyOut,
		NavalBattle
	}

	public enum MissileCollisionReaction
	{
		Invalid = -1,
		Stick,
		PassThrough,
		BounceBack,
		BecomeInvisible,
		Count
	}

	public enum MissionTickAction
	{
		TryToSheathWeaponInHand,
		RemoveEquippedWeapon,
		TryToWieldWeaponInSlot,
		DropItem,
		RegisterDrownBlow
	}

	public delegate void OnBeforeAgentRemovedDelegate(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow);

	public delegate void OnAddSoundAlarmFactorToAgentsDelegate(Agent alarmCreatorAgent, in Vec3 soundPosition, float soundLevelSquareRoot);

	public delegate void OnMainAgentChangedDelegate(Agent oldAgent);

	public delegate BodyProperties ComputeTroopBodyPropertiesDelegate(AgentBuildData agentBuildData, BasicCharacterObject characterObject, Equipment equipment, int seed);

	public sealed class TeamCollection : List<Team>
	{
		private Mission _mission;

		private Team _playerTeam;

		public Team Attacker
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

		public Team Defender
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

		public Team AttackerAlly
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

		public Team DefenderAlly
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

		public Team Player
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

		public Team PlayerEnemy
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

		public Team PlayerAlly
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

		private int TeamCountNative
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public event Action<Team, Team> OnPlayerTeamChanged
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			add
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			remove
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TeamCollection(Mission mission)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private MBTeam AddNative()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public new void Add(Team t)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Team Add(BattleSideEnum side, uint color = uint.MaxValue, uint color2 = uint.MaxValue, Banner banner = null, bool isPlayerGeneral = true, bool isPlayerSergeant = false, bool isSettingRelations = true)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Team Find(MBTeam mbTeam)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ClearResources()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public new void Clear()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetRelations(Team team)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetPlayerTeamAux(int index)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AdjustPlayerTeams()
		{
			throw null;
		}
	}

	public const int MaxRuntimeMissionObjects = 8191;

	private int _lastSceneMissionObjectIdCount;

	private int _lastRuntimeMissionObjectIdCount;

	private bool _isMainAgentObjectInteractionEnabled;

	private List<TimeSpeedRequest> _timeSpeedRequests;

	private bool _isMainAgentItemInteractionEnabled;

	private readonly MBList<MissionObject> _activeMissionObjects;

	private readonly MBList<MissionObject> _missionObjects;

	private readonly List<SpawnedItemEntity> _spawnedItemEntitiesCreatedAtRuntime;

	private readonly MBList<DynamicallyCreatedEntity> _addedEntitiesInfo;

	private readonly Stack<(int, float)> _emptyRuntimeMissionObjectIds;

	private static bool _isCameraFirstPerson;

	private MissionMode _missionMode;

	private float _cachedMissionTime;

	private static readonly object GetNearbyAgentsAuxLock;

	public const int MaxNavMeshId = 1000000;

	private const float NavigationMeshHeightLimit = 1.5f;

	private const float SpeedBonusFactorForSwing = 0.7f;

	private const float SpeedBonusFactorForThrust = 0.5f;

	private const float _exitTimeInSeconds = 0.6f;

	private const int MaxNavMeshPerDynamicObject = 10;

	private bool? _doesMissionAllowChargeDamageOnFriendly;

	private bool _missionEnded;

	private Dictionary<int, Missile> _missilesDictionary;

	private MBList<Missile> _missilesList;

	private readonly List<DynamicEntityInfo> _dynamicEntities;

	public bool DisableDying;

	public bool ForceNoFriendlyFire;

	public const int MaxDamage = 2000;

	public bool IsFriendlyMission;

	public BasicCultureObject MusicCulture;

	private int _nextDynamicNavMeshIdStart;

	private MissionState _missionState;

	private List<IMissionListener> _listeners;

	private BasicMissionTimer _leaveMissionTimer;

	private MBReadOnlyList<MBSubModuleBase> _cachedSubModuleList;

	private readonly MBList<KeyValuePair<Agent, MissionTime>> _mountsWithoutRiders;

	private List<MissionBehavior> _otherMissionBehaviors;

	private readonly object _lockHelper;

	private AgentList _activeAgents;

	private IMissionDeploymentPlan _deploymentPlan;

	public bool IsOrderMenuOpen;

	public bool IsTransferMenuOpen;

	public bool IsInPhotoMode;

	private Agent _mainAgent;

	private Action _onLoadingEndedAction;

	private Timer _inMissionLoadingScreenTimer;

	public bool AllowAiTicking;

	private int _agentCreationIndex;

	private readonly MBList<FleePosition>[] _fleePositions;

	private bool _doesMissionRequireCivilianEquipment;

	public IAgentVisualCreator AgentVisualCreator;

	private readonly int[] _initialAgentCountPerSide;

	private readonly int[] _removedAgentCountPerSide;

	private ConcurrentQueue<CombatLogData> _combatLogsCreated;

	private AgentList _allAgents;

	private MBList<(MissionTickAction Action, Agent Agent, int Param1, int Param2)> _tickActions;

	private readonly object _tickActionsLock;

	private List<SiegeWeapon> _attackerWeaponsForFriendlyFirePreventing;

	private bool _isFastForward;

	private float _missionEndTime;

	public float MissionCloseTimeAfterFinish;

	private static Mission _current;

	public float NextCheckTimeEndMission;

	public int NumOfFormationsSpawnedTeamOne;

	private SoundEvent _ambientSoundEvent;

	private readonly BattleSpawnPathSelector _battleSpawnPathSelector;

	private int _agentCount;

	public int NumOfFormationsSpawnedTeamTwo;

	private bool _canPlayerTakeControlOfAnotherAgentWhenDead;

	private bool tickCompleted;

	internal UIntPtr Pointer
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

	public bool IsFinalized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static Mission Current
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

	private MissionInitializerRecord InitializerRecord
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

	public string SceneName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string SceneLevels
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DamageToPlayerMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DamageToFriendsMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float DamageFromPlayerToFriendsMultiplier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasValidTerrainType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TerrainType TerrainType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Scene Scene
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

	public Vec3 CustomCameraTargetLocalOffset
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

	public Vec3 CustomCameraLocalOffset
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

	public Vec3 CustomCameraLocalOffset2
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

	public Vec3 CustomCameraGlobalOffset
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

	public Vec3 CustomCameraLocalRotationalOffset
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

	public bool CustomCameraIgnoreCollision
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

	public float CustomCameraFovMultiplier
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

	public float CustomCameraFixedDistance
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

	public float ListenerAndAttenuationPosBlendFactor
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

	public GameEntity IgnoredEntityForCamera
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

	public MBReadOnlyList<MissionObject> ActiveMissionObjects
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<MissionObject> MissionObjects
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<DynamicallyCreatedEntity> AddedEntitiesInfo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBBoundaryCollection Boundaries
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

	public bool IsMainAgentObjectInteractionEnabled
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

	public bool IsMainAgentItemInteractionEnabled
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

	public bool IsTeleportingAgents
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

	public bool ForceTickOccasionally
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

	public MissionCombatType CombatType
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

	public MissionMode Mode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CurrentTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool PauseAITick
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

	public bool IsLoadingFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CameraIsFirstPerson
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

	public static float CameraAddedDistance
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

	public float ClearSceneTimerElapsedTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Missile> MissilesList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MissionEnded
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

	public MBReadOnlyList<KeyValuePair<Agent, MissionTime>> MountsWithoutRiders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MissionIsEnding
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

	public bool IsDeploymentFinished
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

	public BattleSideEnum RetreatSide
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

	public bool IsFastForward
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

	public bool FixedDeltaTimeMode
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

	public float FixedDeltaTime
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

	public State CurrentState
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

	public TeamCollection Teams
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

	public Team AttackerTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Team DefenderTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Team AttackerAllyTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Team DefenderAllyTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Team PlayerTeam
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

	public Team PlayerEnemyTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Team PlayerAllyTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Team SpectatorTeam
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

	IMissionTeam IMission.PlayerTeam
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMissionEnding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<MissionLogic> MissionLogics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public List<MissionBehavior> MissionBehaviors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public IInputContext InputManager
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

	public bool NeedsMemoryCleanup
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

	public Agent MainAgent
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

	public IMissionDeploymentPlan DeploymentPlan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsBattleSpawnPathSelectorInitialized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent MainAgentServer
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

	public bool HasSpawnPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsFieldBattle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsSiegeBattle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsSallyOutBattle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsNavalBattle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AgentReadOnlyList AllAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AgentReadOnlyList Agents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInventoryAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInventoryAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public MissionResult MissionResult
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

	public MissionFocusableObjectInformationProvider FocusableObjectInformationProvider
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

	public bool IsQuestScreenAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	private bool _isScreenAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsQuestScreenAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsCharacterWindowAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public bool IsCharacterWindowAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPartyWindowAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public bool IsPartyWindowAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsKingdomWindowAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public bool IsKingdomWindowAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsClanWindowAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public bool IsClanWindowAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEncyclopediaWindowAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public bool IsEncyclopediaWindowAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsBannerWindowAccessible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private get
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

	public bool IsBannerWindowAccessAllowed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool DoesMissionRequireCivilianEquipment
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

	public MissionTeamAITypeEnum MissionTeamAIType
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

	private Lazy<MissionRecorder> _recorder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MissionRecorder Recorder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CanPlayerTakeControlOfAnotherAgentWhenDead
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MissionTimeTracker MissionTimeTracker
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

	public event PropertyChangedEventHandler OnMissionReset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event OnBeforeAgentRemovedDelegate OnBeforeAgentRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<WorldPosition, Team, bool> IsFormationUnitPositionAvailable_AdditionalCondition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<Agent, bool> CanAgentRout_AdditionalCondition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event OnAddSoundAlarmFactorToAgentsDelegate OnAddSoundAlarmFactorToAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<bool> IsAgentInteractionAllowed_AdditionalCondition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event OnMainAgentChangedDelegate OnMainAgentChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event ComputeTroopBodyPropertiesDelegate OnComputeTroopBodyProperties
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<BattleSideEnum, BasicCharacterObject, FormationClass> GetAgentTroopClass_Override
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Agent, SpawnedItemEntity> OnItemPickUp
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Agent, SpawnedItemEntity> OnItemDrop
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Formation> FormationCaptainChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<Agent, WorldPosition?> GetOverriddenFleePositionForAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<bool> AreOrderGesturesEnabled_AdditionalCondition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Func<bool> IsBattleInRetreatEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<int> OnMissileRemovedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<WeakGameEntity> GetActiveEntitiesWithScriptComponentOfType<T>()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddActiveMissionObject(MissionObject missionObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateMissionObject(MissionObject missionObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateMissionObject(MissionObject missionObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMissionCombatType(MissionCombatType missionCombatType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConversationCharacterChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMissionMode(MissionMode newMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AgentCreationResult CreateAgentInternal(AgentFlag agentFlags, int forcedAgentIndex, bool isFemale, ref AgentSpawnData spawnData, ref AgentCapsuleData capsuleData, ref AnimationSystemData animationSystemData, int instanceNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void UpdateMissionTimeCache(float curTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAverageFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetFallAvoidSystemActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFallAvoidSystemActive(bool fallAvoidActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideBoundaries(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideHardBoundaries(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInsideAnyBlockerNavMeshFace2D(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionOnAnyBlockerNavMeshFace(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsFormationUnitPositionAvailableAuxMT(ref WorldPosition formationPosition, ref WorldPosition unitPosition, ref WorldPosition nearestAvailableUnitPosition, float manhattanDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent RayCastForClosestAgent(Vec3 sourcePoint, Vec3 targetPoint, int excludedAgentIndex, float rayThickness, out float collisionDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent RayCastForClosestAgentsLimbs(Vec3 sourcePoint, Vec3 targetPoint, int excludedAgentIndex, float rayThickness, out float collisionDistance, out sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForGivenAgentsLimbs(Vec3 sourcePoint, Vec3 rayFinishPoint, int givenAgentIndex, float rayThickness, out float collisionDistance, out sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal AgentProximityMap.ProximityMapSearchStructInternal ProximityMapBeginSearch(Vec2 searchPos, float searchRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal float ProximityMapMaxSearchRadius()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBiggestAgentCollisionPadding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMissionCorpseFadeOutTimeInSeconds(float corpseFadeOutTimeInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOverrideCorpseCount(int overrideCorpseCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReportStuckAgentsMode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BatchFormationUnitPositions(MBArrayList<Vec2i> orderedPositionIndices, MBArrayList<Vec2> orderedLocalPositions, MBList2D<int> availabilityTable, MBList2D<WorldPosition> globalPositionTable, WorldPosition orderPosition, Vec2 direction, int fileCount, int rankCount, bool fastCheckWithSameFaceGroupIdDigit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ProximityMapFindNext(ref AgentProximityMap.ProximityMapSearchStructInternal searchStruct)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	public void ResetMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnSceneCreated(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void TickAgentsAndTeams(float dt, bool tickPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAgentsAndTeamsAsync(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void IdleTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeSound(int soundIndex, Vec3 position, bool soundCanBePredicted, bool isReliable, int relatedAgent1, int relatedAgent2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeSound(int soundIndex, Vec3 position, bool soundCanBePredicted, bool isReliable, int relatedAgent1, int relatedAgent2, ref SoundEventParameter parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeSoundOnlyOnRelatedPeer(int soundIndex, Vec3 position, int relatedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDynamicallySpawnedMissionObjectInfo(DynamicallyCreatedEntity entityInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveDynamicallySpawnedMissionObjectInfo(MissionObjectId id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int AddMissileAux(int forcedMissileIndex, bool isPrediction, Agent shooterAgent, in WeaponData weaponData, WeaponStatsData[] weaponStatsData, float damageBonus, ref Vec3 position, ref Vec3 direction, ref Mat3 orientation, float baseSpeed, float speed, bool addRigidBody, WeakGameEntity gameEntityToIgnore, bool isPrimaryWeaponShot, out GameEntity missileEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int AddMissileSingleUsageAux(int forcedMissileIndex, bool isPrediction, Agent shooterAgent, in WeaponData weaponData, in WeaponStatsData weaponStatsData, float damageBonus, ref Vec3 position, ref Vec3 direction, ref Mat3 orientation, float baseSpeed, float speed, bool addRigidBody, WeakGameEntity gameEntityToIgnore, bool isPrimaryWeaponShot, out GameEntity missileEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetMissileCollisionPoint(Vec3 missileStartingPosition, Vec3 missileDirection, float missileSpeed, in WeaponData weaponData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMissileAsClient(int missileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetMissileVerticalAimCorrection(Vec3 vecToTarget, float missileStartingSpeed, ref WeaponStatsData weaponStatsData, float airFrictionConstant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetMissileRange(float missileStartingSpeed, float heightDifference)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrepareMissileWeaponForDrop(int missileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParticleSystemBurstByName(string particleSystem, MatrixFrame frame, bool synchThroughNetwork)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetClosestBoundaryPosition(Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetMissionObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveSpawnedMissionObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFreeRuntimeMissionObjectId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReturnRuntimeMissionObjectId(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFreeSceneMissionObjectId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCameraFrame(ref MatrixFrame cameraFrame, float zoomFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCameraFrame(ref MatrixFrame cameraFrame, float zoomFactor, ref Vec3 attenuationPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetCameraFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetFirstThirdPersonView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraLocalOffset(Vec3 newCameraOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraTargetLocalOffset(Vec3 newTargetLocalOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraLocalOffset2(Vec3 newCameraOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraLocalRotationalOffset(Vec3 newCameraRotationalOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraGlobalOffset(Vec3 newCameraOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraFovMultiplier(float newFovMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraFixedDistance(float distance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIgnoredEntityForCamera(GameEntity ignoredEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomCameraIgnoreCollision(bool ignoreCollision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetListenerAndAttenuationPosBlendFactor(float factor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void UpdateSceneTimeSpeed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTimeSpeedRequest(TimeSpeedRequest request)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	private void AssertTimeSpeedRequestDoesntExist(TimeSpeedRequest request)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveTimeSpeedRequest(int timeSpeedRequestID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetRequestedTimeSpeed(int timeSpeedRequestID, out float requestedTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAgentActions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMissiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCorpses(bool isMissionReset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent FindAgentWithIndexAux(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetClosestEnemyAgent(MBTeam team, Vec3 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetClosestAllyAgent(MBTeam team, Vec3 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetNearbyEnemyAgentCount(MBTeam team, Vec2 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentInProximityMap(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMissionStateActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMissionStateDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMissionStateFinalize(bool forceClearGPUResources)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearUnreferencedResources(bool forceClearGPUResources)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnEntityHit(WeakGameEntity entity, Agent attackerAgent, int inflictedDamage, DamageTypes damageType, Vec3 impactPosition, Vec3 impactDirection, in MissionWeapon weapon, int affectorWeaponSlotOrMissileIndex, ref CombatLogData combatLog)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMainAgentMaxCameraZoom()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetBestSlopeTowardsDirection(ref WorldPosition centerPosition, float halfSize, ref WorldPosition referencePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetBestSlopeAngleHeightPosForDefending(WorldPosition enemyPosition, WorldPosition defendingPosition, int sampleSize, float distanceRatioAllowedFromDefendedPos, float distanceSqrdAllowedFromBoundary, float cosinusOfBestSlope, float cosinusOfMaxAcceptedSlope, float minSlopeScore, float maxSlopeScore, float excessiveSlopePenalty, float nearConeCenterRatio, float nearConeCenterBonus, float heightDifferenceCeiling, float maxDisplacementPenalty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetAveragePositionOfAgents(List<Agent> agents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetNearbyAgentsAux(Vec2 center, float radius, MBTeam team, GetNearbyAgentsAuxType type, MBList<Agent> resultList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetNearbyAgentsCountAux(Vec2 center, float radius, MBTeam team, GetNearbyAgentsAuxType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRandomDecideTimeOfAgentsWithIndices(int[] agentIndices, float? minAIReactionTime = null, float? maxAIReactionTime = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBowMissileSpeedModifier(float modifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCrossbowMissileSpeedModifier(float modifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetThrowingMissileSpeedModifier(float modifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMissileRangeModifier(float modifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastMovementKeyPressed(Agent.MovementControlFlag lastMovementKeyPressed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetWeightedPointOfEnemies(Agent agent, Vec2 basePoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenPositions(ref NavigationData navData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNavigationFaceCostWithIdAroundPosition(int navigationFaceId, Vec3 position, float cost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetStraightPathToTarget(Vec2 targetPosition, WorldPosition startingPosition, float samplingDistance = 1f, bool stopAtObstacle = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SkipForwardMissionReplay(float startTime, float endTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDebugAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAiDebugText(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDebugAgent(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetFirstPersonFov()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevelAtPosition(Vec2 position, bool useWaterRenderer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevelAtPositionMT(Vec2 position, bool useWaterRenderer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, true)]
	public bool CanPhysicsCollideBetweenTwoEntities(UIntPtr entity0Ptr, UIntPtr entity1Ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetDeploymentPlan<T>(out T deploymentPlan) where T : IMissionDeploymentPlan
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRemovedAgentRatioForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ref readonly List<SiegeWeapon> GetAttackerWeaponsForFriendlyFirePreventing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentPlanMade(Team team, bool isFirstPlan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetAlternatePositionForNavmeshlessOrOutOfBoundsPosition(Vec2 directionTowards, WorldPosition originalPosition, ref float positionPenalty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNextDynamicNavMeshIdStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationClass GetAgentTroopClass(BattleSideEnum battleSide, BasicCharacterObject agentCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	public WorldPosition GetClosestFleePositionForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetClosestFleePositionForFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition GetClosestFleePosition(MBReadOnlyList<FleePosition> availableFleePositions, WorldPosition runnerPosition, float runnerSpeed, bool runnerHasMount, MBReadOnlyList<(float, WorldPosition, int, Vec2, Vec2, bool)> chaserData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<FleePosition> GetFleePositionsForSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddToWeaponListForFriendlyFirePreventing(SiegeWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mission(MissionInitializerRecord rec, MissionState missionState, bool needsMemoryCleanup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCloseProximityWaveSoundsEnabled(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceDisableOcclusion(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFleePosition(FleePosition fleePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FreeResources()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RetreatMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SurrenderMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasMissionBehavior<T>() where T : MissionBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnAgentAddedAsCorpse(Agent affectedAgent, int corpsesToFadeIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnedItemEntity SpawnAttachedWeaponOnCorpse(Agent agent, int attachedWeaponIndex, int forcedSpawnIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMountWithoutRider(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMountWithoutRider(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateMountReservationsAfterRiderMounts(Agent rider, Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnAgentDeleted(Agent affectedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnObjectDisabled(DestructableComponent destructionComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionObjectId SpawnWeaponAsDropFromMissile(int missileIndex, MissionObject attachedMissionObject, in MatrixFrame attachLocalFrame, WeaponSpawnFlags spawnFlags, in Vec3 velocity, in Vec3 angularVelocity, int forcedSpawnIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void SpawnWeaponAsDropFromAgent(Agent agent, EquipmentIndex equipmentIndex, ref Vec3 globalVelocity, ref Vec3 globalAngularVelocity, WeaponSpawnFlags spawnFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnWeaponAsDropFromAgentAux(Agent agent, EquipmentIndex equipmentIndex, ref Vec3 globalVelocity, ref Vec3 globalAngularVelocity, WeaponSpawnFlags spawnFlags, int forcedSpawnIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnAttachedWeaponOnSpawnedWeapon(SpawnedItemEntity spawnedWeapon, int attachmentIndex, int forcedSpawnIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity SpawnWeaponWithNewEntity(ref MissionWeapon weapon, WeaponSpawnFlags spawnFlags, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity SpawnWeaponWithNewEntityAux(MissionWeapon weapon, WeaponSpawnFlags spawnFlags, MatrixFrame frame, int forcedSpawnIndex, MissionObject attachedMissionObject, bool hasLifeTime, bool spawnedOnACorpse = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachWeaponWithNewEntityToSpawnedWeapon(MissionWeapon weapon, SpawnedItemEntity spawnedItem, MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SpawnedItemEntity SpawnWeaponAux(WeakGameEntity weaponEntity, MissionWeapon weapon, WeaponSpawnFlags spawnFlags, Vec3 globalVelocity, Vec3 globalAngularVelocity, bool hasLifeTime, bool spawnedOnACorpse = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEquipItemsFromSpawnEquipmentBegin(Agent agent, Agent.CreationType creationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEquipItemsFromSpawnEquipment(Agent agent, Agent.CreationType creationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetCurrentVolumeGeneratorVersion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("flee_enemies", "mission")]
	public static string MakeEnemiesFleeCheat(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("flee_team", "mission")]
	public static string MakeTeamFleeCheat(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecalculateBody(ref WeaponData weaponData, ItemComponent itemComponent, WeaponDesign craftedWeaponData, ref WeaponSpawnFlags spawnFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, true)]
	internal void OnFixedTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnPreTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void ApplySkeletonScaleToAllEquippedItems(string itemName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_facial_anim_to_agent", "mission")]
	public static string SetFacialAnimToAgent(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WaitTickCompletion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AgentTickMT(int startInclusive, int endExclusive, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAgentsAndTeamsImp(float dt, bool tickPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("formation_speed_adjustment_enabled", "ai")]
	public static string EnableSpeedAdjustmentCommand(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt, float realDt, bool updateCamera, bool doAsyncAITick)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTickAction(MissionTickAction action, Agent agent, int param1, int param2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTickActionMT(MissionTickAction action, Agent agent, int param1, int param2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveSpawnedItemsAndMissiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEndMissionRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMissionEndTimeInSeconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMissionEndTimerValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyGeneratedCombatLogs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMemberCountOfSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Path GetInitialSpawnPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SpawnPathData GetInitialSpawnPathData(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<SpawnPathData> GetReinforcementPathsDataOfSide(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTroopSpawnFrameWithIndex(AgentBuildData buildData, int troopSpawnIndex, int troopSpawnCount, out Vec3 troopSpawnPosition, out Vec2 troopSpawnDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetFormationSpawnFrame(Team team, FormationClass formationClass, bool isReinforcement, out WorldPosition spawnPosition, out Vec2 spawnDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldFrame GetSpawnPathFrame(BattleSideEnum battleSide, float pathOffset = 0f, float targetOffset = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BuildAgent(Agent agent, AgentBuildData agentBuildData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent CreateAgent(Monster monster, bool isFemale, int instanceNo, Agent.CreationType creationType, float stepSize, int forcedAgentIndex, int weight, BasicCharacterObject characterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBattleAgentCount(int agentCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetFormationSpawnPosition(Team team, FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationClass GetFormationSpawnClass(Team team, FormationClass formationClass, bool isReinforcement = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnAgent(AgentBuildData agentBuildData, bool spawnFromAgentVisuals = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialAgentCountForSide(BattleSideEnum side, int agentCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationPositioningFromDeploymentPlan(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnMonster(ItemRosterElement rosterElement, ItemRosterElement harnessRosterElement, in Vec3 initialPosition, in Vec2 initialDirection, int forcedAgentIndex = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnMonster(EquipmentElement equipmentElement, EquipmentElement harnessRosterElement, in Vec3 initialPosition, in Vec2 initialDirection, int forcedAgentIndex = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnTroop(IAgentOriginBase troopOrigin, bool isPlayerSide, bool hasFormation, bool spawnWithHorse, bool isReinforcement, int formationTroopCount, int formationTroopIndex, bool isAlarmed, bool wieldInitialWeapons, bool forceDismounted, Vec3? initialPosition, Vec2? initialDirection, string specialActionSetSuffix = null, ItemObject bannerItem = null, FormationClass formationIndex = FormationClass.NumberOfAllFormations, bool useTroopClassForSpawn = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent ReplaceBotWithPlayer(Agent botAgent, MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent CreateHorseAgentFromRosterElements(EquipmentElement mount, EquipmentElement mountHarness, in Vec3 initialPosition, in Vec2 initialDirection, int forcedAgentMountIndex, string horseCreationKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentInteraction(Agent requesterAgent, Agent targetAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	public void EndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndMissionInternal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopSoundEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMissionBehavior(MissionBehavior missionBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetMissionBehavior<T>() where T : class, IMissionBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMissionBehavior(MissionBehavior missionBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void JoinEnemyTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEndMissionResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentInteractionAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOrderGesturesEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<EquipmentElement> GetExtraEquipmentElementsForCharacter(BasicCharacterObject character, bool getAllEquipments = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckMissionEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MissionResultReady(MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckMissionEnd(float currentTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerCloseToAnEnemy(float distance = 5f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetRandomPositionAroundPoint(Vec3 center, float minDistance, float maxDistance, bool nearFirst = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition FindBestDefendingPosition(WorldPosition enemyPosition, WorldPosition defendedPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition FindPositionWithBiggestSlopeTowardsDirectionInSquare(ref WorldPosition center, float halfSize, ref WorldPosition referencePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Missile AddCustomMissile(Agent shooterAgent, MissionWeapon missileWeapon, Vec3 position, Vec3 direction, Mat3 orientation, float baseSpeed, float speed, bool addRigidBody, MissionObject missionObjectToIgnore, int forcedMissileIndex = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnAgentShootMissile(Agent shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, bool hasRigidBody, bool isPrimaryWeaponShot, int forcedMissileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal AgentState GetAgentState(Agent affectorAgent, Agent agent, DamageTypes damageType, WeaponFlags weaponFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentMount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentDismount(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnObjectUsed(Agent userAgent, UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnObjectStoppedBeingUsed(Agent userAgent, UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeStartingBehaviors(MissionLogic[] logicBehaviors, MissionBehavior[] otherBehaviors, MissionNetwork[] networkBehaviors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetClosestEnemyAgent(Team team, Vec3 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetClosestAllyAgent(Team team, Vec3 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNearbyEnemyAgentCount(Team team, Vec2 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyAgentsOfSideInRange(Vec3 origin, float radius, BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSoundAlarmFactorToAgents(Agent alarmCreatorAgent, in Vec3 soundPosition, float soundLevelSquareRoot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSpawnedItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool OnMissionObjectRemoved(MissionObject missionObject, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AgentLookingAtAgent(Agent agent1, Agent agent2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent FindAgentWithIndex(int agentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent.UnderAttackType GetUnderAttackTypeOfAgents(IEnumerable<Agent> agents, float timeLimit = 3f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Team GetAgentTeam(IAgentOriginBase troopOrigin, bool isPlayerSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Team GetTeam(TeamSideEnum teamSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Team> GetTeamsOfSide(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetBattleSizeOffset(int battleSize, Path path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetPathOffsetFromDistance(float distance, Path path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetBattleSizeFactor(int battleSize, float normalizationFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent.MovementBehaviorType GetMovementTypeOfAgents(IEnumerable<Agent> agents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ShowInMissionLoadingScreen(int durationInSecond, Action onLoadingEndedAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanAgentRout(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool CanGiveDamageToAgentShield(Agent attacker, WeaponComponentData attackerWeapon, Agent defender)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void MeleeHitCallback(ref AttackCollisionData collisionData, Agent attacker, Agent victim, GameEntity realHitEntity, ref float inOutMomentumRemaining, ref MeleeCollisionReaction colReaction, CrushThroughState crushThroughState, Vec3 blowDir, Vec3 swingDir, ref HitParticleResultData hitParticleResultData, bool crushedThroughWithoutAgentCollision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DecideAgentHitParticles(Agent attacker, Agent victim, in Blow blow, in AttackCollisionData collisionData, ref HitParticleResultData hprd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterBlow(Agent attacker, Agent victim, WeakGameEntity realHitEntity, Blow b, ref AttackCollisionData collisionData, in MissionWeapon attackerWeapon, ref CombatLogData combatLogData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Blow CreateMissileBlow(Agent attackerAgent, in AttackCollisionData collisionData, in MissionWeapon attackerWeapon, Vec3 missilePosition, Vec3 missileStartingPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal float OnAgentHitBlocked(Agent affectedAgent, Agent affectorAgent, ref AttackCollisionData collisionData, Vec3 blowDirection, Vec3 swingDirection, bool isMissile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Blow CreateMeleeBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, in MissionWeapon attackerWeapon, CrushThroughState crushThroughState, Vec3 blowDirection, Vec3 swingDirection, bool cancelDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal float OnAgentHit(Agent affectedAgent, Agent affectorAgent, in Blow b, in AttackCollisionData collisionData, bool isBlocked, float damagedHp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void MissileAreaDamageCallback(ref AttackCollisionData collisionDataInput, ref Blow blowInput, Agent alreadyDamagedAgent, Agent shooterAgent, bool isBigExplosion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void OnMissileRemoved(int missileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal bool MissileHitCallback(out int extraHitParticleIndex, ref AttackCollisionData collisionData, Vec3 missileStartingPosition, Vec3 missilePosition, Vec3 missileAngularVelocity, Vec3 movementVelocity, MatrixFrame attachGlobalFrame, MatrixFrame affectedShieldGlobalFrame, int numDamagedAgents, Agent attacker, Agent victim, GameEntity hitEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleMissileCollisionReaction(int missileIndex, MissileCollisionReaction collisionReaction, MatrixFrame attachLocalFrame, bool isAttachedFrameLocal, Agent attackerAgent, Agent attachedAgent, bool attachedToShield, sbyte attachedBoneIndex, MissionObject attachedMissionObject, Vec3 bounceBackVelocity, Vec3 bounceBackAngularVelocity, int forcedSpawnIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, true)]
	internal void MissileCalculatePassbySoundParametersCallbackMT(int missileIndex, ref SoundEventParameter soundEventParameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void ChargeDamageCallback(ref AttackCollisionData collisionData, Blow blow, Agent attacker, Agent victim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void FallDamageCallback(ref AttackCollisionData collisionData, Blow b, Agent attacker, Agent victim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void KillAgentsOnEntity(GameEntity entity, Agent destroyerAgent, bool burnAgents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void KillAgentCheat(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool KillCheats(bool killAll, bool killEnemy, bool killHorse, bool killYourself)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CancelsDamageAndBlocksAttackBecauseOfNonEnemyCase(Agent attacker, Agent victim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsFriendlyFireAllowedForChargeDamage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanTakeControlOfAgent(Agent agentToTakeControlOf)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayerCanTakeControlOfAnotherAgentWhenDead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TakeControlOfAgent(Agent agentToTakeControlOf)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDamageMultiplierOfCombatDifficulty(Agent victimAgent, Agent attackerAgent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetShootDifficulty(Agent affectedAgent, Agent affectorAgent, bool isHeadShot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame CalculateAttachedLocalFrame(in MatrixFrame attachedGlobalFrame, AttackCollisionData collisionData, WeaponComponentData missileWeapon, Agent affectedAgent, WeakGameEntity hitEntity, Vec3 missileMovementVelocity, Vec3 missileRotationSpeed, MatrixFrame shieldGlobalFrame, bool shouldMissilePenetrate, out bool isAttachedFrameLocal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, true)]
	internal void GetDefendCollisionResults(Agent attackerAgent, Agent defenderAgent, CombatCollisionResult collisionResult, int attackerWeaponSlotIndex, bool isAlternativeAttack, StrikeType strikeType, Agent.UsageDirection attackDirection, float collisionDistanceOnWeapon, float attackProgress, bool attackIsParried, bool isPassiveUsageHit, bool isHeavyAttack, ref float defenderStunPeriod, ref float attackerStunPeriod, ref bool crushedThrough)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CombatLogData GetAttackCollisionResults(Agent attackerAgent, Agent victimAgent, WeakGameEntity hitObject, float momentumRemaining, in MissionWeapon attackerWeapon, bool crushedThrough, bool cancelDamage, bool crushedThroughWithoutAgentCollision, ref AttackCollisionData attackCollisionData, out WeaponComponentData shieldOnBack, out CombatLogData combatLog)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrintAttackCollisionResults(Agent attackerAgent, Agent victimAgent, MissionObject missionObjectHit, ref AttackCollisionData attackCollisionData, ref CombatLogData combatLog)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCombatLogSafe(Agent attackerAgent, Agent victimAgent, CombatLogData combatLog)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionObject CreateMissionObjectFromPrefab(string prefab, MatrixFrame frame, Action<GameEntity> actionAppliedBeforeScriptInitialization)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNearbyAllyAgentsCount(Vec2 center, float radius, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<Agent> GetNearbyAllyAgents(Vec2 center, float radius, Team team, MBList<Agent> agents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<Agent> GetNearbyEnemyAgents(Vec2 center, float radius, Team team, MBList<Agent> agents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBList<Agent> GetNearbyAgents(Vec2 center, float radius, MBList<Agent> agents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFormationUnitPositionAvailableMT(ref WorldPosition formationPosition, ref WorldPosition unitPosition, ref WorldPosition nearestAvailableUnitPosition, float manhattanDistance, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOrderPositionAvailable(in WorldPosition orderPosition, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFormationUnitPositionAvailable(ref WorldPosition unitPosition, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasSceneMapPatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPatchSceneEncounterPosition(out Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPatchSceneEncounterDirection(out Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickDebugAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTimerToDynamicEntity(GameEntity gameEntity, float timeToKill = 10f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddListener(IMissionListener listener)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveListener(IMissionListener listener)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentFleeing(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentPanicked(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTeamDeployed(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBattleSideDeployed(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAfterDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationCaptainChanged(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFastForwardingFromUI(bool fastForwarding)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfBattleInRetreat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSpawnedItemEntityCreatedAtRuntime(SpawnedItemEntity spawnedItemEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerOnItemPickUpEvent(Agent agent, SpawnedItemEntity spawnedItemEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal static void DebugLogNativeMissionNetworkEvent(int eventEnum, string eventName, int bitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	[MBCallback(null, false)]
	internal void PauseMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("kill_n_allies", "mission")]
	public static string KillNAllies(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("kill_all_allies", "mission")]
	public static string KillAllAllies(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("toggleDisableDying", "mission")]
	public static string ToggleDisableDying(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("toggleDisableDyingTeam", "mission")]
	public static string ToggleDisableDyingTeam(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("killAgent", "mission")]
	public static string KillAgent(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_battering_ram_speed", "mission")]
	public static string IncreaseBatteringRamSpeeds(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("set_siege_tower_speed", "mission")]
	public static string IncreaseSiegeTowerSpeed(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("reload_managed_core_params", "game")]
	public static string LoadParamsDebug(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Mission()
	{
		throw null;
	}
}
