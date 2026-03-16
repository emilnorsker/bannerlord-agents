using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.AnimationPoints;

public class DynamicObjectAnimationPoint : StandingPoint
{
	private enum State
	{
		NotUsing,
		StartToUse,
		Using
	}

	private const float RangeThreshold = 0.2f;

	private const float RotationScoreThreshold = 0.99f;

	private const float ActionSpeedRandomMinValue = 0.8f;

	private const float AnimationRandomProgressMaxValue = 0.5f;

	private const string AlternativeTag = "alternative";

	private ActionIndexCache _lastAction;

	public string ArriveAction;

	public string LoopStartAction;

	public string LeaveAction;

	public float ActionSpeed;

	public bool KeepOldVisibility;

	private Vec3 _pointRotation;

	private ActionIndexCache ArriveActionCode;

	protected ActionIndexCache LoopStartActionCode;

	private ActionIndexCache LeaveActionCode;

	protected ActionIndexCache DefaultActionCode;

	private State _state;

	public float ForwardDistanceToPivotPoint;

	public float SideDistanceToPivotPoint;

	private List<AnimationPoint.ItemForBone> _itemsForBones;

	public string RightHandItem;

	public HumanBone RightHandItemBone;

	public string LeftHandItem;

	public HumanBone LeftHandItemBone;

	private EquipmentIndex _equipmentIndexMainHand;

	private EquipmentIndex _equipmentIndexOffHand;

	public int GroupId;

	private string _selectedRightHandItem;

	private string _selectedLeftHandItem;

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

	public override bool PlayerStopsUsingWhenInteractsWithOther
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool DoesActionTypeStopUsingGameObject(ActionCodeType actionType)
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
	public override WorldFrame GetUserFrameForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsDisabledForAgent(Agent agent)
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
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorInit()
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
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RevertWeaponWieldSheathState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentItemsVisibility(bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAgentItemVisibility(AnimationPoint.ItemForBone item, bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt, bool isSimulation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetActionCodes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AssignItemToBone(AnimationPoint.ItemForBone newItem)
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
	private EquipmentIndex FindProperSlot(ItemObject item)
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
	public DynamicObjectAnimationPoint()
	{
		throw null;
	}
}
