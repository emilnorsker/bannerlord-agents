using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("CraftingOrdersTutorial")]
public class CraftingOrdersTutorial : TutorialItemBase
{
	private bool _craftingCategorySelectionOpened;

	private bool _craftingOrderSelectionOpened;

	private bool _craftingOrderResultOpened;

	private bool _craftingOrderTabOpened;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CraftingOrdersTutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TutorialContexts GetTutorialsRelevantContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCraftingWeaponClassSelectionOpened(CraftingWeaponClassSelectionOpenedEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCraftingOrderTabOpened(CraftingOrderTabOpenedEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCraftingOrderSelectionOpened(CraftingOrderSelectionOpenedEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCraftingOnWeaponResultPopupOpened(CraftingWeaponResultPopupToggledEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForActivation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}
}
