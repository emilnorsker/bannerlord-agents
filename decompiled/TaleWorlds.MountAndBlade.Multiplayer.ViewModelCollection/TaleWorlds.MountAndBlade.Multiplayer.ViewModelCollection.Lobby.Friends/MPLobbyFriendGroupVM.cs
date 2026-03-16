using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Friends;

public class MPLobbyFriendGroupVM : ViewModel
{
	private readonly struct FriendOperation
	{
		public enum OperationTypes
		{
			Add,
			Remove,
			Clear
		}

		public readonly MPLobbyFriendItemVM Friend;

		public readonly OperationTypes Type;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FriendOperation(OperationTypes type, MPLobbyFriendItemVM friend)
		{
			throw null;
		}
	}

	public enum FriendGroupType
	{
		InGame,
		Online,
		Offline,
		FriendRequests,
		PendingRequests
	}

	private List<FriendOperation> _friendOperationQueue;

	private string _title;

	private FriendGroupType _groupType;

	private MBBindingList<MPLobbyFriendItemVM> _friendList;

	[DataSourceProperty]
	public string Title
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
	public FriendGroupType GroupType
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
	public MBBindingList<MPLobbyFriendItemVM> FriendList
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
	public MPLobbyFriendGroupVM(FriendGroupType groupType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleFriendOperationAux(FriendOperation operation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearFriends()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFriend(MPLobbyFriendItemVM player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveFriend(MPLobbyFriendItemVM player)
	{
		throw null;
	}
}
