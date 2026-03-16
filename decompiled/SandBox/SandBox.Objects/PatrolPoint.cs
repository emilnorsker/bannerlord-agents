using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AnimationPoints;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects;

public class PatrolPoint : StandingPoint
{
	public readonly int WaitDuration;

	public readonly int WaitDeviation;

	public readonly int Index;

	public readonly string SpawnGroupTag;

	public readonly bool IsInfiniteWaitPoint;

	public readonly float PatrollingSpeed;

	public string LoopAction;

	private ActionIndexCache _loopAction;

	public string RightHandItem;

	public HumanBone RightHandItemBone;

	public string LeftHandItem;

	public HumanBone LeftHandItemBone;

	private List<AnimationPoint.ItemForBone> _itemsForBones;

	private string _selectedRightHandItem;

	private string _selectedLeftHandItem;

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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AssignItemToBone(AnimationPoint.ItemForBone newItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentItemsVisibility(bool isVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PatrolPoint()
	{
		throw null;
	}
}
