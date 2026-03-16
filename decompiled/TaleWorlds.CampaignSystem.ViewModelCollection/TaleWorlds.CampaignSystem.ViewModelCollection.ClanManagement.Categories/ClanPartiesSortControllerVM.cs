using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;

public class ClanPartiesSortControllerVM : ViewModel
{
	public abstract class ItemComparerBase : IComparer<ClanPartyItemVM>
	{
		protected bool _isAcending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAcending)
		{
			throw null;
		}

		public abstract int Compare(ClanPartyItemVM x, ClanPartyItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ItemComparerBase()
		{
			throw null;
		}
	}

	public class ItemNameComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanPartyItemVM x, ClanPartyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemNameComparer()
		{
			throw null;
		}
	}

	public class ItemLocationComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanPartyItemVM x, ClanPartyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private float GetDistanceToMainParty(ClanPartyItemVM item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemLocationComparer()
		{
			throw null;
		}
	}

	public class ItemSizeComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanPartyItemVM x, ClanPartyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemSizeComparer()
		{
			throw null;
		}
	}

	public class ItemShipCountComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanPartyItemVM x, ClanPartyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemShipCountComparer()
		{
			throw null;
		}
	}

	private readonly MBBindingList<MBBindingList<ClanPartyItemVM>> _listsToControl;

	private readonly ItemNameComparer _nameComparer;

	private readonly ItemLocationComparer _locationComparer;

	private readonly ItemSizeComparer _sizeComparer;

	private readonly ItemShipCountComparer _shipCountComparer;

	private int _nameState;

	private int _locationState;

	private int _sizeState;

	private int _shipCountState;

	private bool _isNameSelected;

	private bool _isLocationSelected;

	private bool _isSizeSelected;

	private bool _isShipCountSelected;

	private string _nameText;

	private string _locationText;

	private string _sizeText;

	private string _shipCountText;

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
	public int LocationState
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
	public int SizeState
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
	public int ShipCountState
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
	public bool IsLocationSelected
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
	public bool IsSizeSelected
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
	public bool IsShipCountSelected
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
	public string NameText
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
	public string LocationText
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
	public string SizeText
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
	public string ShipCountText
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
	public ClanPartiesSortControllerVM(MBBindingList<MBBindingList<ClanPartyItemVM>> listsToControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByLocation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortBySize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByShipCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllStates(CampaignUIHelper.SortState state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetAllStates()
	{
		throw null;
	}
}
