using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Armies;

public class KingdomArmySortControllerVM : ViewModel
{
	public abstract class ItemComparerBase : IComparer<KingdomArmyItemVM>
	{
		protected bool _isAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAscending)
		{
			throw null;
		}

		public abstract int Compare(KingdomArmyItemVM x, KingdomArmyItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int ResolveEquality(KingdomArmyItemVM x, KingdomArmyItemVM y)
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
		public override int Compare(KingdomArmyItemVM x, KingdomArmyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemNameComparer()
		{
			throw null;
		}
	}

	public class ItemOwnerComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(KingdomArmyItemVM x, KingdomArmyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemOwnerComparer()
		{
			throw null;
		}
	}

	public class ItemStrengthComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(KingdomArmyItemVM x, KingdomArmyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemStrengthComparer()
		{
			throw null;
		}
	}

	public class ItemPartiesComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(KingdomArmyItemVM x, KingdomArmyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemPartiesComparer()
		{
			throw null;
		}
	}

	public class ItemDistanceComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(KingdomArmyItemVM x, KingdomArmyItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemDistanceComparer()
		{
			throw null;
		}
	}

	private readonly MBBindingList<KingdomArmyItemVM> _listToControl;

	private readonly ItemNameComparer _nameComparer;

	private readonly ItemOwnerComparer _ownerComparer;

	private readonly ItemStrengthComparer _strengthComparer;

	private readonly ItemPartiesComparer _partiesComparer;

	private readonly ItemDistanceComparer _distanceComparer;

	private int _nameState;

	private int _ownerState;

	private int _strengthState;

	private int _partiesState;

	private int _distanceState;

	private bool _isNameSelected;

	private bool _isOwnerSelected;

	private bool _isStrengthSelected;

	private bool _isPartiesSelected;

	private bool _isDistanceSelected;

	[DataSourceProperty]
	public int OwnerState
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
	public int PartiesState
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
	public int StrengthState
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
	public int DistanceState
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
	public bool IsPartiesSelected
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
	public bool IsStrengthSelected
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
	public bool IsOwnerSelected
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
	public bool IsDistanceSelected
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
	public KingdomArmySortControllerVM(ref MBBindingList<KingdomArmyItemVM> listToControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByOwner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByStrength()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByParties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByDistance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllStates(CampaignUIHelper.SortState state)
	{
		throw null;
	}
}
