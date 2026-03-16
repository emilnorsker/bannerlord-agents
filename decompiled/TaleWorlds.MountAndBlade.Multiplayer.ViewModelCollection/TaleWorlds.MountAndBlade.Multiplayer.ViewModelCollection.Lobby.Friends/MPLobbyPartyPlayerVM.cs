using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Friends;

public class MPLobbyPartyPlayerVM : MPLobbyPlayerBaseVM
{
	private Action<MPLobbyPartyPlayerVM> _onActivatePlayerActions;

	private bool _isWaitingConfirmation;

	private bool _isPartyLeader;

	[DataSourceProperty]
	public bool IsWaitingConfirmation
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
	public bool IsPartyLeader
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
	public MPLobbyPartyPlayerVM(PlayerId id, Action<MPLobbyPartyPlayerVM> onActivatePlayerActions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteActivatePlayerActions()
	{
		throw null;
	}
}
