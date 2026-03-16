using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.MountAndBlade.Diamond.Lobby.LocalData;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Friends;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Profile;

public class MPLobbyLeaderboardPlayerItemVM : MPLobbyPlayerBaseVM
{
	public readonly MatchHistoryData MatchOfThePlayer;

	private readonly Action<MPLobbyLeaderboardPlayerItemVM> _onActivatePlayerActions;

	private int _rank;

	[DataSourceProperty]
	public int Rank
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
	public MPLobbyLeaderboardPlayerItemVM(int rank, PlayerLeaderboardData playerLeaderboardData, Action<MPLobbyLeaderboardPlayerItemVM> onActivatePlayerActions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteActivatePlayerActions()
	{
		throw null;
	}
}
