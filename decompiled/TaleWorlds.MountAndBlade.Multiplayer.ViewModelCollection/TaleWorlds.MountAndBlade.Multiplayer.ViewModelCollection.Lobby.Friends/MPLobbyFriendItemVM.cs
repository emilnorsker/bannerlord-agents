using System;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Friends;

public class MPLobbyFriendItemVM : MPLobbyPlayerBaseVM
{
	private Action<MPLobbyPlayerBaseVM> _onActivatePlayerActions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPLobbyFriendItemVM(PlayerId ID, Action<MPLobbyPlayerBaseVM> onActivatePlayerActions, Action<PlayerId> onInviteToClan = null, Action<PlayerId> onFriendRequestAnswered = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteActivatePlayerActions()
	{
		throw null;
	}
}
