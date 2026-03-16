using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.AnimationPoints;

public class AnimationPoint : StandingPoint
{
	public struct ItemForBone
	{
		public HumanBone HumanBone;

		public string ItemPrefabName;

		public bool IsVisible;

		public bool OldVisibility;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemForBone(HumanBone bone, string name, bool isVisible)
		{
			throw null;
		}
	}

	private enum State
	{
		NotUsing,
		StartToUse,
		Using
	}

	private enum PairState
	{
		NoPair,
		BecomePair,
		Greeting,
		StartPairAnimation,
		Pair
	}

	private const string AlternativeTag = "alternative";

	private const float RangeThreshold = 0.2f;

	private const float RotationScoreThreshold = 0.99f;

	private const float ActionSpeedRandomMinValue = 0.8f;

	private const float AnimationRandomProgressMaxValue = 0.5f;

	private static readonly ActionIndexCache[] _greetingFrontActions;

	private static readonly ActionIndexCache[] _greetingRightActions;

	private static readonly ActionIndexCache[] _greetingLeftActions;

	public string ArriveAction;

	public string LoopStartAction;

	public string PairLoopStartAction;

	public string LeaveAction;

	public int GroupId;

	public string RightHandItem;

	public HumanBone RightHandItemBone;

	public string LeftHandItem;

	public HumanBone LeftHandItemBone;

	public GameEntity PairEntity;

	public int MinUserToStartInteraction;

	public bool ActivatePairs;

	public float MinWaitinSeconds;

	public float MaxWaitInSeconds;

	public float ForwardDistanceToPivotPoint;

	public float SideDistanceToPivotPoint;

	private bool _startPairAnimationWithGreeting;

	protected float ActionSpeed;

	public bool KeepOldVisibility;

	private ActionIndexCache ArriveActionCode;

	protected ActionIndexCache LoopStartActionCode;

	protected ActionIndexCache PairLoopStartActionCode;

	private ActionIndexCache LeaveActionCode;

	protected ActionIndexCache DefaultActionCode;

	private bool _resyncAnimations;

	private string _selectedRightHandItem;

	private string _selectedLeftHandItem;

	private State _state;

	private PairState _pairState;

	private Vec3 _pointRotation;

	private List<AnimationPoint> _pairPoints;

	private List<ItemForBone> _itemsForBones;

	private ActionIndexCache _lastAction;

	private Timer _greetingTimer;

	private GameEntity _animatedEntity;

	private Vec3 _animatedEntityDisplacement;

	private EquipmentIndex _equipmentIndexMainHand;

	private EquipmentIndex _equipmentIndexOffHand;

	public override bool PlayerStopsUsingWhenInteractsWithOther
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsArriveActionFinished
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

	protected string SelectedRightHandItem
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

	protected string SelectedLeftHandItem
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

	public bool IsActive
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

	public override bool DisableCombatActionsOnUse
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AnimationPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateVisualizer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAnimatedEntityFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditModeVisibilityChanged(bool currentVisibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnRemoved(int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ResetAnimations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestResync()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool ShouldUpdateOnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void ClearAssignedItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AssignItemToBone(ItemForBone newItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SetActionCodes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool DoesActionTypeStopUsingGameObject(ActionCodeType actionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<AnimationPoint> GetPairs(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override WorldFrame GetUserFrameForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt, bool isSimulation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PairTick(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ActionIndexCache GetGreetingActionId(Vec3 userAgentGlobalEyePoint, Vec3 lookTarget, Mat3 userAgentRot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBList<Agent> GetPairEntityUsers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPairsActivity(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsUsableByAgent(Agent userAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RevertWeaponWieldSheathState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SimulateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool HasAlternative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRandomWaitInSeconds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<AnimationPoint> GetAlternatives()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SimulateAnimations(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsTargetReached()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsRotationCorrectDuringUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool CanAgentUseItem(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddItemsToAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUserConversationStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUserConversationEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentItemsVisibility(bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAgentItemVisibility(ItemForBone item, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EquipmentIndex FindProperSlot(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static AnimationPoint()
	{
		throw null;
	}
}
