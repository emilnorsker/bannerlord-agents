using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;

public class EncyclopediaListSelectorVM : SelectorVM<EncyclopediaListSelectorItemVM>
{
	private Action _onActivate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaListSelectorVM(int selectedIndex, Action<SelectorVM<EncyclopediaListSelectorItemVM>> onChange, Action onActivate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOnDropdownActivated()
	{
		throw null;
	}
}
