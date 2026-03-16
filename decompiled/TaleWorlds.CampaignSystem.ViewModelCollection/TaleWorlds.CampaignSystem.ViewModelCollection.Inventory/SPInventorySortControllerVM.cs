using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;

public class SPInventorySortControllerVM : ViewModel
{
	public enum InventoryItemSortState
	{
		Default,
		Ascending,
		Descending
	}

	public enum InventoryItemSortOption
	{
		Type,
		Name,
		Quantity,
		Cost
	}

	public abstract class ItemComparer : IComparer<SPItemVM>
	{
		protected bool _isAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAscending)
		{
			throw null;
		}

		public abstract int Compare(SPItemVM x, SPItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int ResolveEquality(SPItemVM x, SPItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ItemComparer()
		{
			throw null;
		}
	}

	public class ItemTypeComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPItemVM x, SPItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemTypeComparer()
		{
			throw null;
		}
	}

	public class ItemNameComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPItemVM x, SPItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemNameComparer()
		{
			throw null;
		}
	}

	public class ItemQuantityComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPItemVM x, SPItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemQuantityComparer()
		{
			throw null;
		}
	}

	public class ItemCostComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPItemVM x, SPItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemCostComparer()
		{
			throw null;
		}
	}

	private MBBindingList<SPItemVM> _listToControl;

	private ItemTypeComparer _typeComparer;

	private ItemNameComparer _nameComparer;

	private ItemQuantityComparer _quantityComparer;

	private ItemCostComparer _costComparer;

	private int _typeState;

	private int _nameState;

	private int _quantityState;

	private int _costState;

	private bool _isTypeSelected;

	private bool _isNameSelected;

	private bool _isQuantitySelected;

	private bool _isCostSelected;

	public InventoryItemSortOption? CurrentSortOption
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public InventoryItemSortState? CurrentSortState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
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
	public int QuantityState
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
	public int CostState
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
	public bool IsQuantitySelected
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
	public bool IsCostSelected
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
	public SPInventorySortControllerVM(ref MBBindingList<SPItemVM> listToControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortByOption(InventoryItemSortOption sortOption, InventoryItemSortState sortState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortByDefaultState()
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
	public void ExecuteSortByType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByQuantity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByCost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllStates(InventoryItemSortState state)
	{
		throw null;
	}
}
