using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;

public class ClanMembersSortControllerVM : ViewModel
{
	public abstract class ItemComparerBase : IComparer<ClanLordItemVM>
	{
		protected bool _isAcending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAcending)
		{
			throw null;
		}

		public abstract int Compare(ClanLordItemVM x, ClanLordItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ItemComparerBase()
		{
			throw null;
		}
	}

	public class ItemNameComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanLordItemVM x, ClanLordItemVM y)
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
		public override int Compare(ClanLordItemVM x, ClanLordItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private float GetDistanceToMainHero(ClanLordItemVM item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemLocationComparer()
		{
			throw null;
		}
	}

	private readonly MBBindingList<MBBindingList<ClanLordItemVM>> _listsToControl;

	private readonly ItemNameComparer _nameComparer;

	private readonly ItemLocationComparer _locationComparer;

	private int _nameState;

	private int _locationState;

	private bool _isNameSelected;

	private bool _isLocationSelected;

	private string _nameText;

	private string _locationText;

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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanMembersSortControllerVM(MBBindingList<MBBindingList<ClanLordItemVM>> listsToControl)
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
