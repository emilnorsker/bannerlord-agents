using System;
using System.Runtime.CompilerServices;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Profile;

public class MPLobbyAchievementBadgeGroupVM : ViewModel
{
	public readonly string GroupID;

	private readonly Action<MPLobbyAchievementBadgeGroupVM> _onBadgeProgressInfoRequested;

	private int _unlockedBadgeCount;

	private int _totalBadgeCount;

	private const string PlaytimeConditionID = "Playtime";

	private HotKey _inspectProgressKey;

	private bool _isProgressComplete;

	private string _progressCompletedText;

	private int _currentProgress;

	private int _totalProgress;

	private MPLobbyBadgeItemVM _shownBadgeItem;

	private MBBindingList<MPLobbyBadgeItemVM> _badges;

	[DataSourceProperty]
	public bool IsProgressComplete
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
	public string ProgressCompletedText
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
	public int CurrentProgress
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
	public int TotalProgress
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
	public MPLobbyBadgeItemVM ShownBadgeItem
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
	public MBBindingList<MPLobbyBadgeItemVM> Badges
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
	public MPLobbyAchievementBadgeGroupVM(string groupID, Action<MPLobbyAchievementBadgeGroupVM> onBadgeProgressInfoRequested)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshKeyBindings(HotKey inspectProgressKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGroupBadgeAdded(MPLobbyBadgeItemVM badgeItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetProgressAsCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateBadgeSelection()
	{
		throw null;
	}
}
