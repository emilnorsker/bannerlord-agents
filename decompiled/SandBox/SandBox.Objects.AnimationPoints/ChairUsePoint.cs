using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.AnimationPoints;

public class ChairUsePoint : AnimationPoint
{
	private enum ChairAction
	{
		None,
		LeanOnTable,
		Drink,
		Eat
	}

	public bool NearTable;

	public string NearTableLoopAction;

	public string NearTablePairLoopAction;

	public bool Drink;

	public string DrinkLoopAction;

	public string DrinkPairLoopAction;

	public string DrinkRightHandItem;

	public string DrinkLeftHandItem;

	public bool Eat;

	public string EatLoopAction;

	public string EatPairLoopAction;

	public string EatRightHandItem;

	public string EatLeftHandItem;

	private ActionIndexCache _loopAction;

	private ActionIndexCache _pairLoopAction;

	private ActionIndexCache _nearTableLoopAction;

	private ActionIndexCache _nearTablePairLoopAction;

	private ActionIndexCache _drinkLoopAction;

	private ActionIndexCache _drinkPairLoopAction;

	private ActionIndexCache _eatLoopAction;

	private ActionIndexCache _eatPairLoopAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetActionCodes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ShouldUpdateOnEditorVariableChanged(string variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUse(Agent userAgent, sbyte agentBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChairAction GetRandomChairAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetChairAction(ChairAction chairAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChairUsePoint()
	{
		throw null;
	}
}
