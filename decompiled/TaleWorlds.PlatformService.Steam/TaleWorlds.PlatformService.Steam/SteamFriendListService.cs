using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.Localization;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.PlatformService.Steam;

public class SteamFriendListService : IFriendListService
{
	[CompilerGenerated]
	private sealed class _003CTaleWorlds_002DPlatformService_002DIFriendListService_002DGetAllFriends_003Ed__22 : IEnumerable<PlayerId>, IEnumerable, IEnumerator<PlayerId>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private PlayerId _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SteamFriendListService _003C_003E4__this;

		private int _003CfriendCount_003E5__2;

		private int _003Ci_003E5__3;

		PlayerId IEnumerator<PlayerId>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CTaleWorlds_002DPlatformService_002DIFriendListService_002DGetAllFriends_003Ed__22(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<PlayerId> IEnumerable<PlayerId>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	private SteamPlatformServices _steamPlatformServices;

	bool IFriendListService.InGameStatusFetchable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IFriendListService.AllowsFriendOperations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IFriendListService.CanInvitePlayersToPlatformSession
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IFriendListService.IncludeInAllFriends
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<PlayerId> OnUserStatusChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<PlayerId> OnFriendRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnFriendListChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SteamFriendListService(SteamPlatformServices steamPlatformServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string IFriendListService.GetServiceCodeName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	TextObject IFriendListService.GetServiceLocalizedName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	FriendListServiceType IFriendListService.GetFriendListServiceType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CTaleWorlds_002DPlatformService_002DIFriendListService_002DGetAllFriends_003Ed__22))]
	IEnumerable<PlayerId> IFriendListService.GetAllFriends()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IFriendListService.GetUserOnlineStatus(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IFriendListService.IsPlayingThisGame(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<string> IFriendListService.GetUserName(PlayerId providedId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<PlayerId> IFriendListService.GetUserWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void HandleOnUserStatusChanged(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dummy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerable<PlayerId> IFriendListService.GetPendingRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerable<PlayerId> IFriendListService.GetReceivedRequests()
	{
		throw null;
	}
}
