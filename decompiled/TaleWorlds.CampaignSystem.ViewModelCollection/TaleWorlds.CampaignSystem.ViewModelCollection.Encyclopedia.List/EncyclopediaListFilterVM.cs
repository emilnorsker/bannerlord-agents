using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;

public class EncyclopediaListFilterVM : ViewModel
{
	public readonly EncyclopediaFilterItem Filter;

	private readonly Action<EncyclopediaListFilterVM> _updateFilters;

	private string _name;

	private bool _isSelected;

	[DataSourceProperty]
	public bool IsSelected
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
	public string Name
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
	public EncyclopediaListFilterVM(EncyclopediaFilterItem filter, Action<EncyclopediaListFilterVM> UpdateFilters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyFilterFrom(Dictionary<EncyclopediaFilterItem, bool> filters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOnFilterActivated()
	{
		throw null;
	}
}
