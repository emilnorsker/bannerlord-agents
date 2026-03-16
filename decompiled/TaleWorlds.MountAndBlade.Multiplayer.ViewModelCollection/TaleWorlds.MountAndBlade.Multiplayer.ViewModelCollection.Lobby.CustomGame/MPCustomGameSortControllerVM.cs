using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.CustomGame;

public class MPCustomGameSortControllerVM : ViewModel
{
	public enum SortState
	{
		Default,
		Ascending,
		Descending
	}

	public enum CustomServerSortOption
	{
		SortOptionsBeginExclusive = -1,
		Name,
		GameType,
		PlayerCount,
		PasswordProtection,
		FirstFaction,
		SecondFaction,
		Region,
		PremadeMatchType,
		Host,
		Ping,
		Favorite,
		SortOptionsEndExclusive
	}

	private abstract class ItemComparer : IComparer<MPCustomGameItemVM>
	{
		protected bool _isAscending;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetSortMode(bool isAscending)
		{
			throw null;
		}

		public abstract int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ItemComparer()
		{
			throw null;
		}
	}

	private class ServerNameComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ServerNameComparer()
		{
			throw null;
		}
	}

	private class GameTypeComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GameTypeComparer()
		{
			throw null;
		}
	}

	private class PlayerCountComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PlayerCountComparer()
		{
			throw null;
		}
	}

	private class PasswordComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PasswordComparer()
		{
			throw null;
		}
	}

	private class FirstFactionComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FirstFactionComparer()
		{
			throw null;
		}
	}

	private class SecondFactionComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SecondFactionComparer()
		{
			throw null;
		}
	}

	private class RegionComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RegionComparer()
		{
			throw null;
		}
	}

	private class PremadeMatchTypeComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PremadeMatchTypeComparer()
		{
			throw null;
		}
	}

	private class HostComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public HostComparer()
		{
			throw null;
		}
	}

	private class PingComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PingComparer()
		{
			throw null;
		}
	}

	private class FavoriteComparer : ItemComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(MPCustomGameItemVM x, MPCustomGameItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FavoriteComparer()
		{
			throw null;
		}
	}

	private MBBindingList<MPCustomGameItemVM> _listToControl;

	private readonly ItemComparer[] _sortComparers;

	private readonly int _numberOfSortOptions;

	private bool _isPremadeMatchesList;

	private bool _isPingInfoAvailable;

	private int _currentSortState;

	private bool _isFavoritesSelected;

	private bool _isServerNameSelected;

	private bool _isGameTypeSelected;

	private bool _isPlayerCountSelected;

	private bool _isPasswordSelected;

	private bool _isFirstFactionSelected;

	private bool _isSecondFactionSelected;

	private bool _isRegionSelected;

	private bool _isPremadeMatchTypeSelected;

	private bool _isHostSelected;

	private bool _isPingSelected;

	public CustomServerSortOption? CurrentSortOption
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
	public bool IsPremadeMatchesList
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
	public bool IsPingInfoAvailable
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
	public int CurrentSortState
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
	public bool IsFavoritesSelected
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
	public bool IsServerNameSelected
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
	public bool IsPasswordSelected
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
	public bool IsPlayerCountSelected
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
	public bool IsFirstFactionSelected
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
	public bool IsGameTypeSelected
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
	public bool IsSecondFactionSelected
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
	public bool IsRegionSelected
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
	public bool IsPremadeMatchTypeSelected
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
	public bool IsHostSelected
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
	public bool IsPingSelected
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
	public MPCustomGameSortControllerVM(ref MBBindingList<MPCustomGameItemVM> listToControl, MPCustomGameVM.CustomGameMode customGameMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ItemComparer GetSortComparer(CustomServerSortOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeWithSortState(CustomServerSortOption? sortOption, SortState sortState = SortState.Default)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSortOption(CustomServerSortOption? sortOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortByCurrentState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SortWithOptionAux(CustomServerSortOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByFavorites()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByServerName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByGameType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByPlayerCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByPassword()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByFirstFaction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortBySecondFaction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByRegion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByPremadeMatchType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByHost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSortByPing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshSelectedStates()
	{
		throw null;
	}
}
