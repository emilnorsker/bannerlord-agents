using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Clan;

public class MPLobbyClanLeaderboardSortControllerVM : ViewModel
{
	private enum SortState
	{
		Default,
		Ascending,
		Descending
	}

	private abstract class ItemComparerBase : IComparer<ClanLeaderboardEntry>
	{
		protected bool _isAcending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAcending)
		{
			throw null;
		}

		public abstract int Compare(ClanLeaderboardEntry x, ClanLeaderboardEntry y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ItemComparerBase()
		{
			throw null;
		}
	}

	private class ItemNameComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanLeaderboardEntry x, ClanLeaderboardEntry y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemNameComparer()
		{
			throw null;
		}
	}

	private class ItemWinComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanLeaderboardEntry x, ClanLeaderboardEntry y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemWinComparer()
		{
			throw null;
		}
	}

	private class ItemLossComparer : ItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(ClanLeaderboardEntry x, ClanLeaderboardEntry y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ItemLossComparer()
		{
			throw null;
		}
	}

	private readonly ClanLeaderboardEntry[] _listToControl;

	private readonly ItemNameComparer _nameComparer;

	private readonly ItemWinComparer _winComparer;

	private readonly ItemLossComparer _lossComparer;

	private Action _onSorted;

	private int _nameState;

	private int _winState;

	private int _lossState;

	private bool _isNameSelected;

	private bool _isWinSelected;

	private bool _isLossSelected;

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
	public int WinState
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
	public int LossState
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
	public bool IsWinSelected
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
	public bool IsLossSelected
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
	public MPLobbyClanLeaderboardSortControllerVM(ref ClanLeaderboardEntry[] listToControl, Action onSorted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByWin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByLoss()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAllStates(SortState state)
	{
		throw null;
	}
}
