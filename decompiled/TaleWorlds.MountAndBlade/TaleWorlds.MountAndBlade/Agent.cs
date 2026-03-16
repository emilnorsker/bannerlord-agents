using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public sealed class Agent : DotNetObject, IAgent, IFocusable, IUsable, IFormationUnit, ITrackableBase
{
	public class Hitter
	{
		public const float AssistMinDamage = 35f;

		public readonly MissionPeer HitterPeer;

		public readonly bool IsFriendlyHit;

		public float Damage
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
		public Hitter(MissionPeer peer, float damage, bool isFriendlyHit)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void IncreaseDamage(float amount)
		{
			throw null;
		}
	}

	public struct AgentLastHitInfo
	{
		private BasicMissionTimer _lastBlowTimer;

		public int LastBlowOwnerId
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

		public AgentAttackType LastBlowAttackType
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

		public bool CanOverrideBlow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RegisterLastBlow(int ownerId, AgentAttackType attackType)
		{
			throw null;
		}
	}

	public struct AgentPropertiesModifiers
	{
		public bool resetAiWaitBeforeShootFactor;
	}

	public struct StackArray8Agent
	{
		private Agent _element0;

		private Agent _element1;

		private Agent _element2;

		private Agent _element3;

		private Agent _element4;

		private Agent _element5;

		private Agent _element6;

		private Agent _element7;

		public const int Length = 8;

		public Agent this[int index]
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
	}

	public enum ActionStage
	{
		None = -1,
		AttackReady,
		AttackQuickReady,
		AttackRelease,
		ReloadMidPhase,
		ReloadLastPhase,
		Defend,
		DefendParry,
		NumActionStages
	}

	[Flags]
	public enum AIScriptedFrameFlags
	{
		None = 0,
		GoToPosition = 1,
		NoAttack = 2,
		ConsiderRotation = 4,
		NeverSlowDown = 8,
		DoNotRun = 0x10,
		GoWithoutMount = 0x20,
		RangerCanMoveForClearTarget = 0x80,
		InConversation = 0x100,
		Crouch = 0x200,
		Drag = 0x400
	}

	[Flags]
	public enum AISpecialCombatModeFlags
	{
		None = 0,
		AttackEntity = 1,
		SurroundAttackEntity = 2,
		IgnoreAmmoLimitForRangeCalculation = 0x400
	}

	[Flags]
	[EngineStruct("Ai_state_flag", true, "aisf", false)]
	public enum AIStateFlag : uint
	{
		None = 0u,
		Cautious = 1u,
		PatrollingCautious = 2u,
		Alarmed = 3u,
		Paused = 8u,
		UseObjectMoving = 0x10u,
		UseObjectUsing = 0x20u,
		UseObjectWaiting = 0x40u,
		ColumnwiseFollow = 0x100u,
		AlarmStateMask = 3u
	}

	public enum WatchState
	{
		Patrolling,
		Cautious,
		Alarmed
	}

	public enum MortalityState
	{
		Mortal,
		Invulnerable,
		Immortal
	}

	public enum CreationType
	{
		Invalid,
		FromRoster,
		FromHorseObj,
		FromCharacterObj
	}

	[Flags]
	[EngineStruct("Agent_event_control_flags", true, "agce", false)]
	public enum EventControlFlag : uint
	{
		None = 0u,
		Dismount = 1u,
		Mount = 2u,
		Rear = 4u,
		Jump = 8u,
		Wield0 = 0x10u,
		Wield1 = 0x20u,
		Wield2 = 0x40u,
		Wield3 = 0x80u,
		Sheath0 = 0x100u,
		Sheath1 = 0x200u,
		ToggleAlternativeWeapon = 0x400u,
		Walk = 0x800u,
		Run = 0x1000u,
		Crouch = 0x2000u,
		Stand = 0x4000u,
		Kick = 0x8000u,
		DoubleTapToDirectionUp = 0x10000u,
		DoubleTapToDirectionDown = 0x20000u,
		DoubleTapToDirectionLeft = 0x30000u,
		DoubleTapToDirectionRight = 0x40000u,
		DoubleTapToDirectionMask = 0x70000u
	}

	public enum FacialAnimChannel
	{
		High,
		Mid,
		Low,
		num_facial_anim_channels
	}

	[EngineStruct("Action_code_type", true, "actt", false)]
	public enum ActionCodeType
	{
		Other = 0,
		DefendFist = 1,
		DefendShield = 2,
		DefendForward2h = 3,
		DefendUp2h = 4,
		DefendRight2h = 5,
		DefendLeft2h = 6,
		DefendForward1h = 7,
		DefendUp1h = 8,
		DefendRight1h = 9,
		DefendLeft1h = 10,
		DefendForwardStaff = 11,
		DefendUpStaff = 12,
		DefendRightStaff = 13,
		DefendLeftStaff = 14,
		ReadyRanged = 15,
		ReleaseRanged = 16,
		ReleaseThrowing = 17,
		Reload = 18,
		ReadyMelee = 19,
		ReleaseMelee = 20,
		ParriedMelee = 21,
		BlockedMelee = 22,
		Fall = 23,
		JumpStart = 24,
		Jump = 25,
		JumpEnd = 26,
		JumpEndHard = 27,
		Kick = 28,
		KickContinue = 29,
		KickHit = 30,
		WeaponBash = 31,
		PassiveUsage = 32,
		EquipUnequip = 33,
		SwitchAlternative = 34,
		Idle = 35,
		Guard = 36,
		Mount = 37,
		Dismount = 38,
		Dash = 39,
		MountQuickStop = 40,
		HitObject = 41,
		Sit = 42,
		SitOnTheFloor = 43,
		SitOnAThrone = 44,
		LadderRaise = 45,
		LadderRaiseEnd = 46,
		Rear = 47,
		StrikeLight = 48,
		StrikeMedium = 49,
		StrikeHeavy = 50,
		StrikeKnockBack = 51,
		MountStrike = 52,
		Count = 53,
		StrikeBegin = 48,
		StrikeEnd = 52,
		DefendAllBegin = 1,
		DefendAllEnd = 15,
		AttackMeleeAllBegin = 19,
		AttackMeleeAllEnd = 23,
		AttackMeleeAndRangedAllBegin = 15,
		AttackMeleeAndRangedAllEnd = 23,
		CombatAllBegin = 1,
		CombatAllEnd = 23,
		JumpAllBegin = 24,
		JumpAllEnd = 28,
		FallAllBegin = 25,
		FallAllEnd = 28,
		KickAllBegin = 28,
		KickAllEnd = 31,
		AlternativeAttackAllBegin = 28,
		AlternativeAttackAllEnd = 32
	}

	[EngineStruct("Agent_guard_mode", true, "guard_mode", false)]
	public enum GuardMode
	{
		MarkForDeletion = -2,
		None,
		Up,
		Down,
		Left,
		Right
	}

	public enum HandIndex
	{
		MainHand,
		OffHand
	}

	[EngineStruct("rglInt8", false, null)]
	public enum KillInfo : sbyte
	{
		Invalid = -1,
		Headshot,
		CouchedLance,
		Punch,
		MountHit,
		Bow,
		Crossbow,
		ThrowingAxe,
		ThrowingKnife,
		Javelin,
		Stone,
		Pistol,
		Musket,
		OneHandedSword,
		TwoHandedSword,
		OneHandedAxe,
		TwoHandedAxe,
		Mace,
		Spear,
		Morningstar,
		Maul,
		Backstabbed,
		Gravity,
		ShieldBash,
		WeaponBash,
		Kick,
		TeamSwitch
	}

	public enum MovementBehaviorType
	{
		Engaged,
		Idle,
		Flee
	}

	[Flags]
	[EngineStruct("Agent_movement_control_flags", true, "agcm", false)]
	public enum MovementControlFlag : uint
	{
		None = 0u,
		Forward = 1u,
		Backward = 2u,
		StrafeRight = 4u,
		StrafeLeft = 8u,
		TurnRight = 0x10u,
		TurnLeft = 0x20u,
		AttackLeft = 0x40u,
		AttackRight = 0x80u,
		AttackUp = 0x100u,
		AttackDown = 0x200u,
		DefendLeft = 0x400u,
		DefendRight = 0x800u,
		DefendUp = 0x1000u,
		DefendDown = 0x2000u,
		DefendAuto = 0x4000u,
		DefendBlock = 0x8000u,
		Action = 0x10000u,
		AttackMask = 0x3C0u,
		DefendMask = 0x7C00u,
		DefendDirMask = 0x3C00u,
		MoveMask = 0x3Fu,
		MaxValue = 0x1FFFFu
	}

	public enum UnderAttackType
	{
		NotUnderAttack,
		UnderMeleeAttack,
		UnderRangedAttack
	}

	[EngineStruct("Usage_direction", true, "ud", false)]
	public enum UsageDirection
	{
		None = -1,
		AttackUp = 0,
		AttackDown = 1,
		AttackLeft = 2,
		AttackRight = 3,
		AttackBegin = 0,
		AttackEnd = 4,
		DefendUp = 4,
		DefendDown = 5,
		DefendLeft = 6,
		DefendRight = 7,
		DefendBegin = 4,
		DefendAny = 8,
		DefendEnd = 9,
		AttackAny = 9
	}

	[EngineStruct("Weapon_wield_action_type", false, null)]
	public enum WeaponWieldActionType
	{
		WithAnimation,
		Instant,
		InstantAfterPickUp,
		WithAnimationUninterruptible
	}

	[Flags]
	public enum StopUsingGameObjectFlags : byte
	{
		None = 0,
		AutoAttachAfterStoppingUsingGameObject = 1,
		DoNotWieldWeaponAfterStoppingUsingGameObject = 2,
		DefendAfterStoppingUsingGameObject = 4
	}

	public delegate void OnAgentHealthChangedDelegate(Agent agent, float oldHealth, float newHealth);

	public delegate void OnMountHealthChangedDelegate(Agent agent, Agent mount, float oldHealth, float newHealth);

	public delegate void OnMainAgentWieldedItemChangeDelegate();

	public const float BecomeTeenagerAge = 14f;

	public const float MaxMountInteractionDistance = 1.75f;

	public const float DismountVelocityLimit = 0.5f;

	public const float HealthDyingThreshold = 1f;

	public const float CachedAndFormationValuesUpdateTime = 0.5f;

	public const float MaxInteractionDistance = 3f;

	public const float MaxFocusDistance = 10f;

	private const float ChainAttackDetectionTimeout = 0.75f;

	public static readonly ActionIndexCache[] DefaultTauntActions;

	private static readonly object _stopUsingGameObjectLock;

	private static readonly object _pathCheckObjectLock;

	public OnMainAgentWieldedItemChangeDelegate OnMainAgentWieldedItemChange;

	public Action OnAgentMountedStateChanged;

	public Action OnAgentWieldedItemChange;

	private readonly MBList<AgentComponent> _components;

	private readonly CreationType _creationType;

	private readonly List<AgentController> _agentControllers;

	private readonly Timer _cachedAndFormationValuesUpdateTimer;

	private Agent _cachedMountAgent;

	private Agent _cachedRiderAgent;

	private BasicCharacterObject _character;

	private uint? _clothingColor1;

	private uint? _clothingColor2;

	private EquipmentIndex _equipmentOnMainHandBeforeUsingObject;

	private EquipmentIndex _equipmentOnOffHandBeforeUsingObject;

	private float _defensiveness;

	private UIntPtr _positionPointer;

	private UIntPtr _pointer;

	private UIntPtr _flagsPointer;

	private UIntPtr _indexPointer;

	private UIntPtr _statePointer;

	private UIntPtr _movementModePointer;

	private UIntPtr _controllerTypePointer;

	private UIntPtr _movementDirectionPointer;

	private UIntPtr _primaryWieldedItemIndexPointer;

	private float _lastMultiplayerQuickReadyDetectedTime;

	private UIntPtr _offHandWieldedItemIndexPointer;

	private UIntPtr _channel0CurrentActionPointer;

	private UIntPtr _channel1CurrentActionPointer;

	private UIntPtr _maximumForwardUnlimitedSpeed;

	private Agent _lookAgentCache;

	private IDetachment _detachment;

	private readonly MBList<Hitter> _hitterList;

	private List<(MissionWeapon, MatrixFrame, sbyte)> _attachedWeapons;

	private float _health;

	private MissionPeer _missionPeer;

	private TextObject _name;

	private float _removalTime;

	private List<CompositeComponent> _synchedBodyComponents;

	private Formation _formation;

	private bool _checkIfTargetFrameIsChanged;

	private AgentPropertiesModifiers _propertyModifiers;

	private int _usedObjectPreferenceIndex;

	private bool _isDeleted;

	private bool _wantsToYell;

	private float _yellTimer;

	private Vec3 _lastSynchedTargetDirection;

	private Vec2 _lastSynchedTargetPosition;

	private AgentLastHitInfo _lastHitInfo;

	private ClothSimulatorComponent _capeClothSimulator;

	private bool _isRemoved;

	private WeakReference<MBAgentVisuals> _visualsWeakRef;

	private readonly int _creationIndex;

	private bool _canLeadFormationsRemotely;

	private bool _isDetachableFromFormation;

	private ItemObject _formationBanner;

	private bool _isLadderQueueUsing;

	private WorldPosition _changedFormationPosition;

	private Vec2 _localPositionError;

	public static Agent Main
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

	public bool IsMine
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMainAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsHuman
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMount
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

	public bool IsPlayerTroop
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsUsingGameObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CanLeadFormationsRemotely
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDetachableFromFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float AgentScale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CrouchMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool WalkMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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

	public AgentMovementMode MovementMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 VisualPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 MovementVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 AverageVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MovementDirectionAsAngle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLookRotationInSlowMotion
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AgentPropertiesModifiers PropertyModifiers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBActionSet ActionSet
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<AgentComponent> Components
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Hitter> HitterList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GuardMode CurrentGuardMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent ImmediateEnemy
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDoingPassiveAttack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPassiveUsageConditionsAreMet
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CurrentAimingError
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CurrentAimingTurbulance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public UsageDirection AttackDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float WalkingSpeedLimitOfMountable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent RiderAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasMount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CanLogCombatFor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MissileRangeAdjusted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaximumMissileRange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	FocusableObjectType IFocusable.FocusableObjectType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IFocusable.IsFocusable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TextObject NameTextObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AgentMovementLockedState MovementLockedState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Monster Monster
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool IsRunningAway
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

	public BodyProperties BodyPropertiesValue
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

	public CommonAIComponent CommonAIComponent
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

	public HumanAIComponent HumanAIComponent
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

	public int BodyPropertiesSeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		internal set
		{
			throw null;
		}
	}

	public float LastRangedHitTime
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

	public float LastMeleeHitTime
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

	public float LastRangedAttackTime
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

	public float LastMeleeAttackTime
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

	public bool IsFemale
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

	public ItemObject Banner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ItemObject FormationBanner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MissionWeapon WieldedWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsItemUseDisabled
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

	public bool SyncHealthToAllClients
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

	public UsableMissionObject CurrentlyUsedGameObject
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

	public bool CombatActionsEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Mission Mission
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

	public bool IsHero
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
	}

	public MissionEquipment Equipment
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

	public TextObject AgentRole
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

	public bool HasBeenBuilt
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

	public MortalityState CurrentMortalityState
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

	public Equipment SpawnEquipment
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

	public FormationPositionPreference FormationPositionPreference
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

	public bool RandomizeColors
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

	public float CharacterPowerCached
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

	public float WalkSpeedCached
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

	public IAgentOriginBase Origin
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

	public Team Team
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

	public int KillCount
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

	public AgentDrivenProperties AgentDrivenProperties
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

	public float BaseHealthLimit
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

	public string HorseCreationKey
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

	public float HealthLimit
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

	public bool IsRangedCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasAnyRangedWeaponCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasMeleeWeaponCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasShieldCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasSpearCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasThrownCached
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AIStateFlag AIStateFlags
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

	public MatrixFrame Frame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MovementControlFlag MovementFlags
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

	public Vec2 MovementInputVector
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

	public CapsuleData CollisionCapsule
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 CollisionCapsuleCenter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBAgentVisuals AgentVisuals
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HeadCameraMode
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

	public Agent MountAgent
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

	public IDetachment Detachment
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

	public bool IsPaused
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

	public bool IsDetachedFromFormation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WatchState CurrentWatchState
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

	public float Defensiveness
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

	public Formation Formation
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

	IFormationUnit IFormationUnit.FollowedUnit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsShieldUsageEncouraged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPlayerUnit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AgentControllerType Controller
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

	public uint ClothingColor1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public uint ClothingColor2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame LookFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LookDirectionAsAngle
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

	public Mat3 LookRotation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLookDirectionLocked
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

	public bool IsCheering
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInBeingStruckAction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MissionPeer MissionPeer
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

	public BasicCharacterObject Character
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

	public float LastDetachmentTickAgentTime
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

	public MissionPeer OwningAgentMissionPeer
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

	public MissionRepresentativeBase MissionRepresentative
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

	public bool IsInLadderQueue
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

	IMissionTeam IAgent.Team
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	IFormationArrangement IFormationUnit.Formation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	int IFormationUnit.FormationFileIndex
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

	int IFormationUnit.FormationRankIndex
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

	public Vec2 LocalPositionError
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

	public float DetachmentWeight
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

	public int DetachmentIndex
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

	public bool IsFormationFrameEnabled
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

	private UIntPtr Pointer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private UIntPtr FlagsPointer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private UIntPtr PositionPointer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 LookDirection
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

	public bool IsLookDirectionLow
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float Health
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

	public float Age
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

	public Vec3 Velocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public EventControlFlag EventControlFlags
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

	public AgentState State
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

	public MissionWeapon WieldedOffhandWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event OnAgentHealthChangedDelegate OnAgentHealthChanged
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

	public event OnMountHealthChangedDelegate OnMountHealthChanged
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
	internal Agent(Mission mission, Mission.AgentCreationResult creationResult, CreationType creationType, Monster monster, int creationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAgent.IsEnemyOf(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAgent.IsFriendOf(IAgent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void SetAgentAIPerformingRetreatBehavior(bool isAgentAIPerformingRetreatBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetHasOnAiInputSetCallback()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHasOnAiInputSetCallback(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnAIInputSet(ref EventControlFlag eventFlag, ref MovementControlFlag movementFlag, ref Vec2 inputVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public float GetMissileRangeWithHeightDifferenceAux(float targetZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal int GetFormationUnitSpacing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public string GetSoundAndCollisionInfoClassName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal bool IsInSameFormationWith(Agent otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponSwitchingToAlternativeStart(EquipmentIndex slotIndex, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponReloadPhaseChange(EquipmentIndex slotIndex, short reloadPhase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponAmmoReload(EquipmentIndex slotIndex, EquipmentIndex ammoSlotIndex, short totalAmmo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponAmmoConsume(EquipmentIndex slotIndex, short totalAmmo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnShieldDamaged(EquipmentIndex slotIndex, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponAmmoRemoved(EquipmentIndex slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnMount(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnDismount(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnAgentAlarmedStateChanged(AIStateFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnRetreating()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal void UpdateMountAgentCache(Agent newMountAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void UpdateRiderAgentCache(Agent newRiderAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public void UpdateAgentStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	public float GetWeaponInaccuracy(EquipmentIndex weaponSlotIndex, int weaponUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public float DebugGetHealth()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetPosition(Vec2 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetZ(float targetZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetUp(in Vec3 targetUp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanLeadFormationsRemotely(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAveragePingInMilliseconds(double averagePingInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetPositionAndDirection(in Vec2 targetPosition, in Vec3 targetDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAcceleration(in Vec3 acceleration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWeaponGuard(UsageDirection direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWatchState(WatchState watchState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAlarmStateNormal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCautious()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPatrollingCautious()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAlarmed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetAlarmState(AIStateFlag alarmStateFlag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetFormationIndex(int targetFormationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWieldedItemIndexChange(bool isOffHand, bool isWieldedInstantly, bool isWieldedOnSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartRagdollAsCorpse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndRagdollAsCorpse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAddedAsCorpse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAsCorpse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOverridenStrikeAndDeathAction(in ActionIndexCache strikeAction, in ActionIndexCache deathAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyForceOnRagdoll(sbyte boneIndex, in Vec3 force)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVelocityLimitsOnRagdoll(float linearVelocityLimit, float angularVelocityLimit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetAILastSuspiciousPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAILastSuspiciousPosition(WorldPosition lastSuspiciousPosition, bool checkNavMeshForCorrection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetAIMoveDestination()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 FindLongestDirectMoveToPosition(Vec2 targetPosition, bool checkBoundaries, bool checkFriendlyAgents, out bool isCollidedWithAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAIMoveStartTolerance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAIMoveStopTolerance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAIAtMoveDestination()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationBanner(ItemObject banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsAIPaused(bool isPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetEnemyCaches()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetPositionSynched(ref Vec2 targetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetPositionAndDirectionSynched(ref Vec2 targetPosition, ref Vec3 targetDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBodyArmorMaterialType(ArmorComponent.ArmorMaterialTypes bodyArmorMaterialType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsedGameObjectForClient(UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTeam(Team team, bool sync)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothingColor1(uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothingColor2(uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWieldedItemIndexAsClient(HandIndex handIndex, EquipmentIndex equipmentIndex, bool isWieldedInstantly, bool isWieldedOnSpawn, int mainHandCurrentUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPreciseRangedAimingEnabled(bool set)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsConversationAgent(bool set)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCrouchMode(bool set)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWeaponAmountInSlot(EquipmentIndex equipmentSlot, short amount, bool enforcePrimaryItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDraggingMode(bool set)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWeaponAmmoAsClient(EquipmentIndex equipmentIndex, EquipmentIndex ammoEquipmentIndex, short ammo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWeaponReloadPhaseAsClient(EquipmentIndex equipmentIndex, short reloadState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReloadAmmoInSlot(EquipmentIndex equipmentIndex, EquipmentIndex ammoSlotIndex, short reloadedAmmo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsageIndexOfWeaponInSlotAsClient(EquipmentIndex slotIndex, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRandomizeColors(bool shouldRandomize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnRemoveWeapon(EquipmentIndex slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationFrameDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationFrameEnabled(WorldPosition position, Vec2 direction, Vec2 positionVelocity, float formationDirectionEnforcingFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShouldCatchUpWithFormation(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationIntegrityData(Vec2 position, Vec2 currentFormationDirection, Vec2 averageVelocityOfCloseAgents, float averageMaxUnlimitedSpeedOfCloseAgents, float deviationOfPositions, bool shouldKeepWithFormationInsteadOfMovingToAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCrouchingAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponUsageIndexChange(EquipmentIndex slotIndex, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentActionProgress(int channelNo, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentActionSpeed(int channelNo, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetActionChannel(int channelNo, in ActionIndexCache actionIndexCache, bool ignorePriority = false, AnimFlags additionalFlags = (AnimFlags)0uL, float blendWithNextActionFactor = 0f, float actionSpeed = 1f, float blendInPeriod = -0.2f, float blendOutPeriodToNoAnim = 0.4f, float startProgress = 0f, bool useLinearSmoothing = false, float blendOutPeriod = -0.2f, int actionShift = 0, bool forceFaceMorphRestart = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnWeaponAmountChange(EquipmentIndex slotIndex, short amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAttackState(int attackState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAIBehaviorParams(HumanAIComponent.AISimpleBehaviorKind behavior, float y1, float x2, float y2, float x3, float y3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAllBehaviorParams(HumanAIComponent.BehaviorValues[] behaviorParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMovementDirection(in Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptedFlags(AIScriptedFrameFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptedCombatFlags(AISpecialCombatModeFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptedPositionAndDirection(ref WorldPosition scriptedPosition, float scriptedDirection, bool addHumanLikeDelay, AIScriptedFrameFlags additionalFlags = AIScriptedFrameFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptedPosition(ref WorldPosition position, bool addHumanLikeDelay, AIScriptedFrameFlags additionalFlags = AIScriptedFrameFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScriptedTargetEntity(WeakGameEntity target, AISpecialCombatModeFlags additionalFlags = AISpecialCombatModeFlags.None, bool ignoreIfAlreadyAttacking = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentExcludeStateForFaceGroupId(int faceGroupId, bool isExcluded)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLookAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInteractionAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLookToPointOfInterest(Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentFlags(AgentFlag agentFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSelectedMountIndex(int mountIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFiringOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRidingOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSelectedMountIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTargetFormationIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFiringOrder(FiringOrder.RangedWeaponUsageOrderEnum order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRidingOrder(RidingOrder.RidingOrderEnum order)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentFacialAnimation(FacialAnimChannel channel, string animationName, bool loop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SetHandInverseKinematicsFrame(in MatrixFrame leftGlobalFrame, in MatrixFrame rightGlobalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNativeFormationNo(int formationNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDirectionChangeTendency(float tendency)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBattleImportance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TroopTraitsMask GetTraitsMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSynchedPrefabComponentVisibility(int componentIndex, bool visibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActionSet(ref AnimationSystemData animationSystemData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColumnwiseFollowAgent(Agent followAgent, ref Vec2 followPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHandInverseKinematicsFrameForMissionObjectUsage(in MatrixFrame localIKFrame, in MatrixFrame boundEntityGlobalFrame, float animationHeightDifference = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWantsToYell()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCapeClothSimulator(GameEntityComponent clothSimulatorComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetTargetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAimingTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetInteractionDistanceToUsable(IUsable usable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetInfoTextForBeingNotInteractable(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetController<T>() where T : AgentController
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EquipmentIndex GetPrimaryWieldedItemIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EquipmentIndex GetOffhandWieldedItemIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMaximumForwardUnlimitedSpeed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetWeaponEntityFromEquipmentSlot(EquipmentIndex slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetRetreatPos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AIScriptedFrameFlags GetScriptedFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AISpecialCombatModeFlags GetScriptedCombatFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetSteppedEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetSteppedRootEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BodyFlags GetSteppedBodyFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AnimFlags GetCurrentAnimationFlag(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionIndexCache GetCurrentAction(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionCodeType GetCurrentActionType(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ActionStage GetCurrentActionStage(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsageDirection GetCurrentActionDirection(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentActionPriority(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCurrentActionProgress(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetActionChannelWeight(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetActionChannelCurrentActionWeight(int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldFrame GetWorldFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLookDownLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetEyeGlobalHeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMaximumSpeedLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetCurrentVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTurnSpeed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCurrentSpeedLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetRealGlobalVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetAverageRealGlobalVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetMovementDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetCurWeaponOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetIsLeftStance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPathDistanceToPoint(ref Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentNavigationFaceId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetWorldPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGroundMaterialForCollisionEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetLookAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetTargetAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAutomaticTargetSelection(bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentFlag GetAgentFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAgentFacialAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAgentVoiceDefinition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetEyeGlobalPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetChestGlobalPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementControlFlag GetDefendMovementFlag()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsageDirection GetAttackDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeaponInfo GetWieldedWeaponInfo(HandIndex handIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetBodyRotationConstraint(int channelIndex = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTotalEncumbrance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTotalMass()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetComponent<T>() where T : AgentComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAgentDrivenPropertyValue(DrivenProperty type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsableMachine GetSteppedMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAttachedWeaponsCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionWeapon GetAttachedWeapon(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetAttachedWeaponFrame(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetAttachedWeaponBoneIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteAttachedWeapon(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasRangedWeapon(bool checkHasAmmo = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBoneEntitialFrameAtAnimationProgress(sbyte boneIndex, int animationIndex, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetFormationFileAndRankInfo(out int fileIndex, out int rankIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetFormationFileAndRankInfo(out int fileIndex, out int rankIndex, out int fileCount, out int rankCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Vec2 GetWallDirectionOfRelativeFormationLocation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMortalityState(MortalityState newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleInvulnerable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetArmLength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetArmWeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetRunningSimulationDataUntilMaximumSpeedReached(ref float combatAccelerationTime, ref float maxSpeed, float[] speedValues)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaximumSpeedLimit(float maximumSpeedLimit, bool isMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBaseArmorEffectivenessForBodyPart(BoneBodyPartType bodyPart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AITargetVisibilityState GetLastTargetVisibilityState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMissileRange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentIdleAnimationStatus(bool idleEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemObject GetWeaponToReplaceOnQuickAction(SpawnedItemEntity spawnedItem, out EquipmentIndex possibleSlotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Hitter GetAssistingHitter(MissionPeer killerPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanReachAgent(Agent otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanInteractWithAgent(Agent otherAgent, float userAgentCameraElevation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanBeAssignedForScriptedMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanReachAndUseObject(UsableMissionObject gameObject, float distanceSq)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanReachObject(UsableMissionObject gameObject, float distanceSq)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanReachObjectFromPosition(UsableMissionObject gameObject, float distanceSq, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanUseObject(UsableMissionObject gameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanMoveDirectlyToPosition(in Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanInteractableWeaponBePickedUp(SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanQuickPickUp(SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanTeleport()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsRetreating()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFadingOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentDrivenPropertyValueFromConsole(DrivenProperty type, float val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsOnLand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInWater()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAbleToUseMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAgentParentEntitySameAs(GameEntity toBeChecked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExcludedFromGravity(bool exclude, bool applyAverageGlobalVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForceAttachedEntity(WeakGameEntity willBeAttached)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSliding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSitting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReleasingChainAttackInMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCameraAttachable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSynchedPrefabComponentVisible(int componentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEnemyOf(Agent otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFriendOf(Agent otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFocusGain(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFocusLose(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnItemRemovedFromScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnWeaponDrop(EquipmentIndex equipmentSlot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnItemPickup(SpawnedItemEntity spawnedItemEntity, EquipmentIndex weaponPickUpSlotIndex, out bool removeWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDistanceTo(Agent other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckPathToAITargetAgentPassesThroughNavigationFaceIdFromDirection(int navigationFaceId, in Vec3 direction, float overridenCostForFaceId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTargetNavigationFaceIdBetween(int navigationFaceIdStart, int navigationFaceIdEnd)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec3 ITrackableBase.GetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	TextObject ITrackableBase.GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckEquipmentForCapeClothSimulationStateChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckToDropFlaggedItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckSkillForMounting(Agent mountAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeSpawnEquipment(Equipment spawnEquipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeMissionEquipment(MissionEquipment missionEquipment, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeAgentProperties(Equipment spawnEquipment, AgentBuildData agentBuildData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateFormationOrders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateAgentProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCustomDrivenProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateBodyProperties(BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSyncHealthToAllClients(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSpawnEquipmentAndRefreshVisuals(Equipment newSpawnEquipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceUpdateCachedAndFormationValues(bool updateOnlyMovement, bool arrangementChangeAllowed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCachedAndFormationValues(bool updateOnlyMovement, bool arrangementChangeAllowed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ParallelUpdateCachedAndFormationValues(bool updateOnlyMovement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateLastRangedAttackTimeDueToAnAttack(float newTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateTargetAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateAIWeaponSelections()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetLookAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetGuard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetAgentProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetAiWaitBeforeShootFactor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearTargetFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearEquipment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearHandInverseKinematics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAttachedWeapons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDetachableFromFormation(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryAttachToFormation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryRemoveAllDetachmentScores()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnforceShieldUsage(UsageDirection shieldDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ObjectHasVacantPosition(UsableMissionObject gameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool InteractingWithAnyGameObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopUsingGameObjectAux(bool isSuccessful, StopUsingGameObjectFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopUsingGameObjectMT(bool isSuccessful = true, StopUsingGameObjectFlags flags = StopUsingGameObjectFlags.AutoAttachAfterStoppingUsingGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopUsingGameObject(bool isSuccessful = true, StopUsingGameObjectFlags flags = StopUsingGameObjectFlags.AutoAttachAfterStoppingUsingGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleStopUsingAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleStartUsingAction(UsableMissionObject targetObject, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentController AddController(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentController RemoveController(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanThrustAttackStickToBone(BoneBodyPartType bodyPart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetOldWieldedItemInfo(out int rightHandSlotIndex, out int rightHandUsageIndex, out int leftHandSlotIndex, out int leftHandUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartSwitchingWeaponUsageIndexAsClient(EquipmentIndex equipmentIndex, int usageIndex, UsageDirection currentMovementFlagUsageDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToWieldWeaponInSlot(EquipmentIndex slotIndex, WeaponWieldActionType type, bool isWieldedOnSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrepareWeaponForDropInEquipmentSlot(EquipmentIndex slotIndex, bool dropWithHolster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddHitter(MissionPeer peer, float damage, bool isFriendlyHit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TryToSheathWeaponInHand(HandIndex handIndex, WeaponWieldActionType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveHitter(MissionPeer peer, bool isFriendlyHit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Retreat(WorldPosition retreatPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopRetreating()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UseGameObject(UsableMissionObject usedObject, int preferenceIndex = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveEquipmentsOnHand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartFadingOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsWandering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderCheckEnabled(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetRenderCheckEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 ComputeAnimationDisplacement(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickActionChannels(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsPhysicsForceClosed(bool isPhysicsForceClosed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LockAgentReplicationTableDataWithCurrentReliableSequenceNo(NetworkCommunicator peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TeleportToPosition(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FadeOut(bool hideInstantly, bool hideMount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FadeIn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableScriptedMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableScriptedCombatMovement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceAiBehaviorSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPathThroughNavigationFaceIdFromDirectionMT(int navigationFaceId, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPathThroughNavigationFaceIdFromDirection(int navigationFaceId, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableLookToPointOfInterest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompositeComponent AddPrefabComponentToBone(string prefabName, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeVoice(SkinVoiceManager.SkinVoiceType voiceType, SkinVoiceManager.CombatVoiceNetworkPredictionType predictionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void YellAfterDelay(float delayTimeInSecond)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WieldNextWeapon(HandIndex weaponIndex, WeaponWieldActionType wieldActionType = WeaponWieldActionType.WithAnimation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementControlFlag AttackDirectionToMovementFlag(UsageDirection direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementControlFlag DefendDirectionToMovementFlag(UsageDirection direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool KickClear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsageDirection PlayerAttackDirection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (sbyte, sbyte) GetRandomPairOfRealBloodBurstBoneIndices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateBloodBurstAtLimb(sbyte realBoneIndex, float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponent(AgentComponent agentComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveComponent(AgentComponent agentComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleTaunt(int tauntIndex, bool isDefaultTaunt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleBark(int indexOfBark)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleDropWeapon(bool isDefendPressed, EquipmentIndex forcedSlotIndexToDropWeaponFrom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DropItem(EquipmentIndex itemIndex, WeaponClass pickedUpItemType = WeaponClass.Undefined)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EquipItemsFromSpawnEquipment(bool neededBatchedItems, bool prepareImmediately, bool useFaceCache, int faceCacheID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WieldInitialWeapons(WeaponWieldActionType wieldActionType = WeaponWieldActionType.InstantAfterPickUp, Equipment.InitialWeaponEquipPreference initialWeaponEquipPreference = TaleWorlds.Core.Equipment.InitialWeaponEquipPreference.Any)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeWeaponHitPoints(EquipmentIndex slotIndex, short hitPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachWeaponToWeapon(EquipmentIndex slotIndex, MissionWeapon weapon, GameEntity weaponEntity, ref MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachWeaponToBone(MissionWeapon weapon, GameEntity weaponEntity, sbyte boneIndex, ref MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RestoreShieldHitPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Die(Blow b, KillInfo overrideKillInfo = KillInfo.Invalid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDead(bool isKilled, ActionIndexCache actionIndex, int corpsesToFadeIndex = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterBlow(Blow blow, in AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateBlowFromBlowAsReflection(in Blow blow, in AttackCollisionData collisionData, out Blow outBlow, out AttackCollisionData outCollisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public void DebugMore()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Mount(Agent mountAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EquipWeaponToExtraSlotAndWield(ref MissionWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEquippedWeapon(EquipmentIndex slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EquipWeaponWithNewEntity(EquipmentIndex slotIndex, ref MissionWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EquipWeaponFromSpawnedItemEntity(EquipmentIndex slotIndex, SpawnedItemEntity spawnedItemEntity, bool removeWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadForRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddSynchedPrefabComponentToBone(string prefabName, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool WillDropWieldedShield(SpawnedItemEntity spawnedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HadSameTypeOfConsumableOrShieldOnSpawn(WeaponClass weaponClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetImmediateEnemyAgentMovementData(out float maximumForwardUnlimitedSpeed, out Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasLostShield()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastDetachmentTickAgentTime(float lastDetachmentTickAgentTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDetachmentWeight(float newDetachmentWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDetachmentIndex(int newDetachmentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOwningAgentMissionPeer(MissionPeer owningAgentMissionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMissionRepresentative(MissionRepresentativeBase missionRepresentative)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsLadderQueueUsing(bool isLadderQueueUsing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsInLadderQueue(bool isInLadderQueue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateLocalPositionError()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void YellingBehaviour()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetMountAgentBeforeBuild(Agent mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetMountInitialValues(TextObject name, string horseCreationKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetInitialAgentScale(float initialScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeAgentRecord()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnDelete()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnFleeing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnRemove()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void InitializeComponents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Build(AgentBuildData agentBuildData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PreloadForRenderingAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPathThroughNavigationFacesIDFromDirection(int navigationFaceID_1, int navigationFaceID_2, int navigationFaceID_3, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPathThroughNavigationFacesIDFromDirectionMT(int navigationFaceID_1, int navigationFaceID_2, int navigationFaceID_3, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AfterStoppedUsingMissionObject(UsableMachine usableMachine, UsableMissionObject usedObject, UsableMissionObject movingToOrDefendingObject, bool isSuccessful, StopUsingGameObjectFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private UIntPtr GetPtr()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetWeaponHitPointsInSlot(EquipmentIndex equipmentIndex, short hitPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AgentMovementLockedState GetMovementLockedState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachWeaponToBoneAux(ref MissionWeapon weapon, GameEntity weaponEntity, sbyte boneIndex, ref MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetRiderAgentAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachWeaponToWeaponAux(EquipmentIndex slotIndex, ref MissionWeapon weapon, GameEntity weaponEntity, ref MatrixFrame attachLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetMountAgentAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMountAgent(Agent mountAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RelieveFromCaptaincy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTeamInternal(MBTeam team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WeaponEquipped(EquipmentIndex equipmentSlot, in WeaponData weaponData, WeaponStatsData[] weaponStatsData, in WeaponData ammoWeaponData, WeaponStatsData[] ammoWeaponStatsData, WeakGameEntity weaponEntity, bool removeOldWeaponFromScene, bool isWieldedOnSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent GetRiderAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialFrame(in Vec3 initialPosition, in Vec2 initialDirection, bool canSpawnOutsideOfMissionBoundary = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDrivenProperties(float[] values)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateLastAttackAndHitTimes(Agent attackerAgent, bool isMissile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNetworkPeer(NetworkCommunicator newPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearTargetFrameAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	private void CheckUnmanagedAgentValid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BuildAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearTargetZ()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetMissileRangeWithHeightDifference()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSkinMeshes(bool prepareImmediately, bool useFaceCache, int faceCacheID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleBlow(ref Blow b, in AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleBlowAux(ref Blow b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ArmorComponent.ArmorMaterialTypes GetProtectorArmorMaterialOfBone(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickAsAI()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SyncHealthToClients()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static UsageDirection MovementFlagToDirection(MovementControlFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static UsageDirection GetActionDirection(int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMonsterUsageIndex(string monsterUsage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetSoundParameterForArmorType(ArmorComponent.ArmorMaterialTypes armorMaterialType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Agent()
	{
		throw null;
	}
}
