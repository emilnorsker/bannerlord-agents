using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.ClanFinance;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Supporters;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;

public class ClanIncomeSortControllerVM : ViewModel
{
	public abstract class WorkshopItemComparerBase : IComparer<ClanFinanceWorkshopItemVM>
	{
		protected bool _isAcending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAcending)
		{
			throw null;
		}

		public abstract int Compare(ClanFinanceWorkshopItemVM x, ClanFinanceWorkshopItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected WorkshopItemComparerBase()
		{
			throw null;
		}
	}

	public abstract class SupporterItemComparerBase : IComparer<ClanSupporterGroupVM>
	{
		protected bool _isAcending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAcending)
		{
			throw null;
		}

		public abstract int Compare(ClanSupporterGroupVM x, ClanSupporterGroupVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected SupporterItemComparerBase()
		{
			throw null;
		}
	}

	public abstract class AlleyItemComparerBase : IComparer<ClanFinanceAlleyItemVM>
	{
		protected bool _isAcending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAcending)
		{
			throw null;
		}

		public abstract int Compare(ClanFinanceAlleyItemVM x, ClanFinanceAlleyItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected AlleyItemComparerBase()
		{
			throw null;
		}
	}

	public class WorkshopItemNameComparer : WorkshopItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanFinanceWorkshopItemVM x, ClanFinanceWorkshopItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WorkshopItemNameComparer()
		{
			throw null;
		}
	}

	public class SupporterItemNameComparer : SupporterItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanSupporterGroupVM x, ClanSupporterGroupVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SupporterItemNameComparer()
		{
			throw null;
		}
	}

	public class AlleyItemNameComparer : AlleyItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanFinanceAlleyItemVM x, ClanFinanceAlleyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AlleyItemNameComparer()
		{
			throw null;
		}
	}

	public class WorkshopItemLocationComparer : WorkshopItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanFinanceWorkshopItemVM x, ClanFinanceWorkshopItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private float GetDistanceToMainParty(ClanFinanceWorkshopItemVM item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WorkshopItemLocationComparer()
		{
			throw null;
		}
	}

	public class AlleyItemLocationComparer : AlleyItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanFinanceAlleyItemVM x, ClanFinanceAlleyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private float GetDistanceToMainParty(ClanFinanceAlleyItemVM item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AlleyItemLocationComparer()
		{
			throw null;
		}
	}

	public class WorkshopItemIncomeComparer : WorkshopItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanFinanceWorkshopItemVM x, ClanFinanceWorkshopItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WorkshopItemIncomeComparer()
		{
			throw null;
		}
	}

	public class SupporterItemIncomeComparer : SupporterItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanSupporterGroupVM x, ClanSupporterGroupVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SupporterItemIncomeComparer()
		{
			throw null;
		}
	}

	public class AlleyItemIncomeComparer : AlleyItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanFinanceAlleyItemVM x, ClanFinanceAlleyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AlleyItemIncomeComparer()
		{
			throw null;
		}
	}

	private readonly MBBindingList<ClanFinanceWorkshopItemVM> _workshopList;

	private readonly MBBindingList<ClanSupporterGroupVM> _supporterList;

	private readonly MBBindingList<ClanFinanceAlleyItemVM> _alleyList;

	private readonly WorkshopItemNameComparer _workshopNameComparer;

	private readonly SupporterItemNameComparer _supporterNameComparer;

	private readonly AlleyItemNameComparer _alleyNameComparer;

	private readonly WorkshopItemLocationComparer _workshopLocationComparer;

	private readonly AlleyItemLocationComparer _alleyLocationComparer;

	private readonly WorkshopItemIncomeComparer _workshopIncomeComparer;

	private readonly SupporterItemIncomeComparer _supporterIncomeComparer;

	private readonly AlleyItemIncomeComparer _alleyIncomeComparer;

	private int _nameState;

	private int _locationState;

	private int _incomeState;

	private bool _isNameSelected;

	private bool _isLocationSelected;

	private bool _isIncomeSelected;

	private string _nameText;

	private string _locationText;

	private string _incomeText;

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
	public int IncomeState
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
	public bool IsIncomeSelected
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
	public string IncomeText
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
	public ClanIncomeSortControllerVM(MBBindingList<ClanFinanceWorkshopItemVM> workshopList, MBBindingList<ClanSupporterGroupVM> supporterList, MBBindingList<ClanFinanceAlleyItemVM> alleyList)
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
	public void ExecuteSortByIncome()
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
