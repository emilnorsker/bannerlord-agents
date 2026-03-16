using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("GetSuppliesTutorialStep3")]
public class BuyingFoodStep3Tutorial : TutorialItemBase
{
	private int _purchasedFoodCount;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BuyingFoodStep3Tutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForActivation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerInventoryExchange(List<(ItemRosterElement, int)> purchasedItems, List<(ItemRosterElement, int)> soldItems, bool isTrading)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TutorialContexts GetTutorialsRelevantContext()
	{
		throw null;
	}
}
