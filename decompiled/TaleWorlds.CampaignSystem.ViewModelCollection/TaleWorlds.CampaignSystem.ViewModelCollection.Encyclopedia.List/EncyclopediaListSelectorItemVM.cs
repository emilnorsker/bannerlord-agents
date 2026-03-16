using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;

public class EncyclopediaListSelectorItemVM : SelectorItemVM
{
	public EncyclopediaListItemComparer Comparer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaListSelectorItemVM(EncyclopediaListItemComparer comparer)
	{
		throw null;
	}
}
