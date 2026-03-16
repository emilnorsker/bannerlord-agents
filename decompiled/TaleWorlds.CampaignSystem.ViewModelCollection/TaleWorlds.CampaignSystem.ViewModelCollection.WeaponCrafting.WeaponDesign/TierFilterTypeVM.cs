using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;

public class TierFilterTypeVM : ViewModel
{
	private readonly Action<WeaponDesignVM.CraftingPieceTierFilter> _onSelect;

	private bool _isSelected;

	private string _tierName;

	public WeaponDesignVM.CraftingPieceTierFilter FilterType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

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
	public string TierName
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
	public TierFilterTypeVM(WeaponDesignVM.CraftingPieceTierFilter filterType, Action<WeaponDesignVM.CraftingPieceTierFilter> onSelect, string tierName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSelectTier()
	{
		throw null;
	}
}
