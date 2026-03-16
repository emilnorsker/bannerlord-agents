using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Smelting;

public class SmeltingSortControllerVM : ViewModel
{
	public abstract class ItemComparerBase : IComparer<SmeltingItemVM>
	{
		protected bool _isAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAscending)
		{
			throw null;
		}

		public abstract int Compare(SmeltingItemVM x, SmeltingItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int ResolveEquality(SmeltingItemVM x, SmeltingItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ItemComparerBase()
		{
			throw null;
		}
	}

	public class ItemNameComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SmeltingItemVM x, SmeltingItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemNameComparer()
		{
			throw null;
		}
	}

	public class ItemYieldComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SmeltingItemVM x, SmeltingItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemYieldComparer()
		{
			throw null;
		}
	}

	public class ItemTypeComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SmeltingItemVM x, SmeltingItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemTypeComparer()
		{
			throw null;
		}
	}

	private MBBindingList<SmeltingItemVM> _listToControl;

	private readonly ItemNameComparer _nameComparer;

	private readonly ItemYieldComparer _yieldComparer;

	private readonly ItemTypeComparer _typeComparer;

	private int _nameState;

	private int _yieldState;

	private int _typeState;

	private bool _isNameSelected;

	private bool _isYieldSelected;

	private bool _isTypeSelected;

	private string _sortTypeText;

	private string _sortNameText;

	private string _sortYieldText;

	[DataSourceProperty]
	public int NameState
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
	public int TypeState
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
	public int YieldState
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
	public bool IsNameSelected
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
	public bool IsTypeSelected
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
	public bool IsYieldSelected
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
	public string SortTypeText
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
	public string SortNameText
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
	public string SortYieldText
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
	public SmeltingSortControllerVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetListToControl(MBBindingList<SmeltingItemVM> listToControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortByCurrentState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByYield()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllStates(CampaignUIHelper.SortState state)
	{
		throw null;
	}
}
