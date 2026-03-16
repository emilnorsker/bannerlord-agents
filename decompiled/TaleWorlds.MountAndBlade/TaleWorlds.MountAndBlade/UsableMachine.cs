using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public abstract class UsableMachine : SynchedMissionObject, IFocusable, IOrderable, IDetachment
{
	public const string UsableMachineParentTag = "machine_parent";

	public string PilotStandingPointTag;

	public string AmmoPickUpTag;

	public string WaitStandingPointTag;

	protected GameEntity ActiveWaitStandingPoint;

	private readonly List<UsableMissionObjectComponent> _components;

	private DestructableComponent _destructionComponent;

	protected bool _areUsableStandingPointsVacant;

	protected List<(int, StandingPoint)> _usableStandingPoints;

	protected bool _isDetachmentRecentlyEvaluated;

	private int _reevaluatedCount;

	private bool _isEvaluated;

	private float _cachedDetachmentWeight;

	protected float EnemyRangeToStopUsing;

	protected Vec2 MachinePositionOffsetToStopUsingLocal;

	protected bool MakeVisibilityCheck;

	private UsableMachineAIBase _ai;

	private StandingPoint _currentlyUsedAmmoPickUpPoint;

	protected QueryData<bool> IsDisabledForAttackerAIDueToEnemyInRange;

	protected QueryData<bool> IsDisabledForDefenderAIDueToEnemyInRange;

	protected MBList<Formation> _userFormations;

	private bool _isMachineDeactivated;

	public MBList<StandingPoint> StandingPoints
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

	public StandingPoint PilotStandingPoint
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

	public int PilotStandingPointSlotIndex
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

	protected internal List<StandingPoint> AmmoPickUpPoints
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

	protected List<GameEntity> WaitStandingPoints
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

	public DestructableComponent DestructionComponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDestructible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDestroyed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Agent PilotAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLoose
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual float SinkingReferenceOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public UsableMachineAIBase Ai
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual FocusableObjectType FocusableObjectType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual bool IsFocusable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public StandingPoint CurrentlyUsedAmmoPickUpPoint
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

	public bool HasAIPickingUpAmmo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsDisabledForAI
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

	public MBReadOnlyList<Formation> UserFormations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int UserCountNotInStruckAction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int UserCountIncludingInStruckAction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual int MaxUserCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual bool HasWaitFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame WaitFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GameEntity WaitEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual bool IsDeactivated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected UsableMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponent(UsableMissionObjectComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent(UsableMissionObjectComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetComponent<T>() where T : UsableMissionObjectComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual OrderType GetOrder(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetValidStandingPointForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAI(UsableMachineAIBase ai)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakGameEntity GetValidStandingPointForAgentWithoutDistanceCheck(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandingPoint GetVacantStandingPointForAI(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StandingPoint GetTargetStandingPointOfAIAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetVisibleSynched(bool value, bool forceChildrenVisible = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetPhysicsStateSynched(bool value, bool setChildren = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectAndSetStandingPoints()
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
	private static string DebugGetMemberNameOf<T>(object instance, T sp) where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	protected virtual void DebugTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorValidate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnFocusGain(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnFocusLose(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPilotAssignedDuringSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual TextObject GetInfoTextForBeingNotInteractable(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnMissionReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Activate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsDisabledForBattleSide(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsDisabledForBattleSideAI(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool ShouldAutoLeaveDetachmentWhenDisabled(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool IsDisabledDueToEnemyInRange(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool AutoAttachUserToFormation(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool HasToBeDefendedByUser(BattleSideEnum sideEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Disable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	public abstract TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual StandingPoint GetBestPointAlternativeTo(StandingPoint standingPoint, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsInRangeToCheckAlternativePoints(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.OnFormationLeave(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFormationLeaveHelper(Formation formation, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsAgentUsingOrInterested(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float GetWeightOfStandingPoint(StandingPoint sp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetDetachmentWeight(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual float GetDetachmentWeightAux(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.GetSlotIndexWeightTuples(List<(int, float)> slotIndexWeightTuples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsSlotAtIndexAvailableForAgent(int slotIndex, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool IsAgentOnInconvenientNavmesh(Agent agent, StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsAgentEligible(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentAtSlotIndex(Agent agent, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsDisabledForAI(bool isDisabledForAI)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Agent IDetachment.GetMovingAgentAtSlotIndex(int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsDetachmentRecentlyEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.UnmarkDetachment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.MarkSlotAtIndex(int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float? IDetachment.GetWeightOfNextSlot(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetExactCostOfAgentAtSlot(Agent candidate, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	List<float> IDetachment.GetTemplateCostsOfAgent(Agent candidate, List<float> oldValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetTemplateWeightOfAgent(Agent candidate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetWeightOfOccupiedSlot(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	WorldFrame? IDetachment.GetAgentFrame(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.RemoveAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfUsableSlots()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsStandingPointAvailableForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float? IDetachment.GetWeightOfAgentAtNextSlot(List<Agent> candidates, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float? IDetachment.GetWeightOfAgentAtNextSlot(List<(Agent, float)> candidates, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float? IDetachment.GetWeightOfAgentAtOccupiedSlot(Agent detachedAgent, List<Agent> candidates, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.AddAgent(Agent agent, int slotIndex, Agent.AIScriptedFrameFlags customFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.FormationStartUsing(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.FormationStopUsing(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUsedByFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.ResetEvaluation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.SetAsEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetDetachmentWeightFromCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.ComputeAndCacheDetachmentWeight(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual bool IsStandingPointNotUsedOnAccountOfBeingAmmoLoad(StandingPoint standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual StandingPoint GetSuitableStandingPointFor(BattleSideEnum side, Agent agent = null, List<Agent> agents = null, List<(Agent, float)> agentValuePairs = null)
	{
		throw null;
	}

	public abstract TextObject GetDescriptionText(WeakGameEntity gameEntity);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool ShouldDisableTickIfMachineDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnemyRangeToStopUsing(float value)
	{
		throw null;
	}
}
