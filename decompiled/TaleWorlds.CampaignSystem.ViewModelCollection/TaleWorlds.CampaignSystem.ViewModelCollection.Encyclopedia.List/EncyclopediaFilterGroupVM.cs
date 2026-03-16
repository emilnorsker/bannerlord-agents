using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;

public class EncyclopediaFilterGroupVM : ViewModel
{
	public readonly EncyclopediaFilterGroup FilterGroup;

	private MBBindingList<EncyclopediaListFilterVM> _filters;

	private string _filterName;

	[DataSourceProperty]
	public string FilterName
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

	[DataSourceProperty]
	public MBBindingList<EncyclopediaListFilterVM> Filters
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
	public EncyclopediaFilterGroupVM(EncyclopediaFilterGroup filterGroup, Action<EncyclopediaListFilterVM> UpdateFilters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyFiltersFrom(Dictionary<EncyclopediaFilterItem, bool> filters)
	{
		throw null;
	}
}
