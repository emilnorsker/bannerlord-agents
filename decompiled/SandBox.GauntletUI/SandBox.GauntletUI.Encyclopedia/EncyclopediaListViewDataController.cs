using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;
using TaleWorlds.Library;

namespace SandBox.GauntletUI.Encyclopedia;

public class EncyclopediaListViewDataController
{
	private readonly struct EncyclopediaListViewData
	{
		public readonly Dictionary<EncyclopediaFilterItem, bool> Filters;

		public readonly int SelectedSortIndex;

		public readonly string LastSelectedItemId;

		public readonly bool IsAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListViewData(MBBindingList<EncyclopediaFilterGroupVM> filters, int selectedSortIndex, string lastSelectedItemId, bool isAscending)
		{
			throw null;
		}
	}

	private Dictionary<EncyclopediaPage, EncyclopediaListViewData> _listData;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaListViewDataController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveListData(EncyclopediaListVM list, string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadListData(EncyclopediaListVM list)
	{
		throw null;
	}
}
