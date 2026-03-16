using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Scoreboard;

public class SPScoreboardSortControllerVM : ViewModel
{
	private enum SortState
	{
		Default,
		Ascending,
		Descending
	}

	public abstract class ScoreboardUnitItemComparerBase : IComparer<SPScoreboardUnitVM>
	{
		protected bool _isAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAscending)
		{
			throw null;
		}

		public abstract int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ScoreboardUnitItemComparerBase()
		{
			throw null;
		}
	}

	public class ItemRemainingComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemRemainingComparer()
		{
			throw null;
		}
	}

	public class ItemKillComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemKillComparer()
		{
			throw null;
		}
	}

	public class ItemUpgradeComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemUpgradeComparer()
		{
			throw null;
		}
	}

	public class ItemDeadComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemDeadComparer()
		{
			throw null;
		}
	}

	public class ItemWoundedComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemWoundedComparer()
		{
			throw null;
		}
	}

	public class ItemRoutedComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemRoutedComparer()
		{
			throw null;
		}
	}

	public class ItemMemberComparer : ScoreboardUnitItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(SPScoreboardUnitVM x, SPScoreboardUnitVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemMemberComparer()
		{
			throw null;
		}
	}

	private readonly MBBindingList<SPScoreboardPartyVM> _listToControl;

	private readonly ItemRemainingComparer _remainingComparer;

	private readonly ItemKillComparer _killComparer;

	private readonly ItemUpgradeComparer _upgradeComparer;

	private readonly ItemDeadComparer _deadComparer;

	private readonly ItemWoundedComparer _woundedComparer;

	private readonly ItemRoutedComparer _routedComparer;

	private readonly ItemMemberComparer _memberComparer;

	private int _remainingState;

	private bool _isRemainingSelected;

	private int _killState;

	private bool _isKillSelected;

	private int _upgradeState;

	private bool _isUpgradeSelected;

	private int _deadState;

	private bool _isDeadSelected;

	private int _woundedState;

	private bool _isWoundedSelected;

	private int _routedState;

	private bool _isRoutedSelected;

	[DataSourceProperty]
	public int RemainingState
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
	public bool IsRemainingSelected
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
	public int KillState
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
	public bool IsKillSelected
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
	public int UpgradeState
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
	public bool IsUpgradeSelected
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
	public int DeadState
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
	public bool IsDeadSelected
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
	public int WoundedState
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
	public bool IsWoundedSelected
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
	public int RoutedState
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
	public bool IsRoutedSelected
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
	public SPScoreboardSortControllerVM(ref MBBindingList<SPScoreboardPartyVM> listToControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByRemaining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByKill()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByUpgrade()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByDead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByWounded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByRouted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllStates(SortState state)
	{
		throw null;
	}
}
