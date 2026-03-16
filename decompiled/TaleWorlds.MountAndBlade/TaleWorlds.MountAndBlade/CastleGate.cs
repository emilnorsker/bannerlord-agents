using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Source.Objects.Siege;

namespace TaleWorlds.MountAndBlade;

public class CastleGate : UsableMachine, IPointDefendable, ICastleKeyPosition, ITargetable
{
	public enum DoorOwnership
	{
		Defenders,
		Attackers
	}

	public enum GateState
	{
		Open,
		Closed
	}

	public const string OuterGateTag = "outer_gate";

	public const string InnerGateTag = "inner_gate";

	private const float ExtraColliderScaleFactor = 1.1f;

	private const string LeftDoorBodyTag = "collider_l";

	private const string RightDoorBodyTag = "collider_r";

	private const string RightDoorAgentOnlyBodyTag = "collider_agent_r";

	private const string OpenTag = "open";

	private const string CloseTag = "close";

	private const string MiddlePositionTag = "middle_pos";

	private const string WaitPositionTag = "wait_pos";

	private const string LeftDoorAgentOnlyBodyTag = "collider_agent_l";

	private const int HeavyBlowDamageLimit = 200;

	private static int _batteringRamHitSoundId;

	public DoorOwnership OwningTeam;

	public string OpeningAnimationName;

	public string ClosingAnimationName;

	public string HitAnimationName;

	public string PlankHitAnimationName;

	public string HitMeleeAnimationName;

	public string DestroyAnimationName;

	public int NavigationMeshId;

	public int NavigationMeshIdToDisableOnOpen;

	public string LeftDoorBoneName;

	public string RightDoorBoneName;

	public string ExtraCollisionObjectTagRight;

	public string ExtraCollisionObjectTagLeft;

	private int _openingAnimationIndex;

	private int _closingAnimationIndex;

	private bool _leftExtraColliderDisabled;

	private bool _rightExtraColliderDisabled;

	private bool _civilianMission;

	public bool ActivateExtraColliders;

	public string SideTag;

	private bool _openNavMeshIdDisabled;

	private SynchedMissionObject _door;

	private Skeleton _doorSkeleton;

	private GameEntity _extraColliderRight;

	private GameEntity _extraColliderLeft;

	private readonly List<GameEntity> _attackOnlyDoorColliders;

	private float _previousAnimationProgress;

	private GameEntity _agentColliderRight;

	private GameEntity _agentColliderLeft;

	private LadderQueueManager _queueManager;

	private bool _afterMissionStartTriggered;

	private sbyte _rightDoorBoneIndex;

	private sbyte _leftDoorBoneIndex;

	private AgentPathNavMeshChecker _pathChecker;

	public bool AutoOpen;

	private SynchedMissionObject _plank;

	private WorldFrame _middleFrame;

	private WorldFrame _defenseWaitFrame;

	private Action DestructibleComponentOnMissionReset;

	public TacticalPosition MiddlePosition
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

	private static int BatteringRamHitSoundIdCache
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TacticalPosition WaitPosition
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

	public override FocusableObjectType FocusableObjectType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GateState State
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

	public bool IsGateOpen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IPrimarySiegeWeapon AttackerSiegeWeapon
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

	public IEnumerable<DefencePoint> DefencePoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public FormationAI.BehaviorSide DefenseSide
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

	public WorldFrame MiddleFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public WorldFrame DefenseWaitFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CastleGate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override OrderType GetOrder(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsableTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetInitialStateOfGate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenDoorAndDisableGateForCivilianMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenDoor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseDoor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateDoorBodies(bool updateAnyway)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGateNavMeshState(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGateNavMeshStateForEnemies(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAutoOpenState(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsAgentOnInconvenientNavmesh(Agent agent, StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ServerTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TargetFlags GetTargetFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTargetValue(List<Vec3> weaponPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetTargetEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleSideEnum GetSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetGlobalVelocity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDestructable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity Entity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public (Vec3, Vec3) ComputeGlobalPhysicsBoundingBoxMinMax()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CollectGameEntities(bool calledFromOnInit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnNextDestructionState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CollectDynamicGameEntities(bool calledFromOnInit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeExtraColliderPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHitTaken(DestructableComponent hitComponent, Agent hitterAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDestroyed(DestructableComponent destroyedComponent, Agent destroyerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int OnCalculateDestructionStateIndex(int destructionStateIndex, int inflictedDamage, int destructionStateCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override bool OnCheckForProblems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetTargetingOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CastleGate()
	{
		throw null;
	}
}
