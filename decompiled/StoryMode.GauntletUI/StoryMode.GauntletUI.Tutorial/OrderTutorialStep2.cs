using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("OrderTutorial1TutorialStep2")]
public class OrderTutorialStep2 : TutorialItemBase
{
	private bool _hasPlayerOrderedCharge;

	private bool _registeredToOrderEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OrderTutorialStep2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerOrdered(OrderType orderType, IEnumerable<Formation> appliedFormations, OrderController orderController, params object[] delegateParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TutorialContexts GetTutorialsRelevantContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForActivation()
	{
		throw null;
	}
}
