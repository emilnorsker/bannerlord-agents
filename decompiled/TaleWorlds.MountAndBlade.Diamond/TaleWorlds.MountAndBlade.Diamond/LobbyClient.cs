using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Messages.FromClient.ToLobbyServer;
using Messages.FromLobbyServer.ToClient;
using TaleWorlds.Core;
using TaleWorlds.Diamond;
using TaleWorlds.Diamond.ClientApplication;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Diamond.MultiplayerBadges;
using TaleWorlds.MountAndBlade.Diamond.Ranked;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

public class LobbyClient : Client<LobbyClient>
{
	public enum State
	{
		Idle,
		Working,
		Connected,
		SessionRequested,
		AtLobby,
		SearchingToRejoinBattle,
		RequestingToSearchBattle,
		RequestingToCancelSearchBattle,
		SearchingBattle,
		AtBattle,
		QuittingFromBattle,
		WaitingToCreatePremadeGame,
		WaitingToJoinPremadeGame,
		WaitingToRegisterCustomGame,
		HostingCustomGame,
		WaitingToJoinCustomGame,
		InCustomGame
	}

	private enum PendingRequest
	{
		RankInfo,
		PlayerData,
		BannerlordID
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetCustomGameServerList_003Ed__185 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AvailableCustomGames> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<CustomGameServerListResponse> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CRequestJoinCustomGame_003Ed__188 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public CustomBattleId serverId;

		public string password;

		public bool isJoinAsAdmin;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CRequestJoinPlayerParty_003Ed__189 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId targetPlayer;

		public bool inviteRequest;

		private TaskAwaiter<RequestJoinPlayerPartyMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFindCustomGame_003Ed__192 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public bool? hasCrossplayPrivilege;

		public string[] selectedCustomGameTypes;

		public string region;

		private int _003Ci_003E5__2;

		private TaskAwaiter<CustomGameServerListResponse> _003C_003Eu__1;

		private List<GameServerEntry>.Enumerator _003C_003E7__wrap2;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass193_0
	{
		public AccessObjectResult accessObjectResult;

		public LobbyClient _003C_003E4__this;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass193_0()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CConnect_003Eb__0()
		{
			throw null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CConnect_003Ed__193 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LobbyClientConnectResult> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public ILoginAccessProvider lobbyClientLoginAccessProvider;

		public string overridenUserName;

		public PlatformInitParams initParams;

		public ILobbyClientSessionHandler lobbyClientSessionHandler;

		public bool hasUserGeneratedContentPrivilege;

		private _003C_003Ec__DisplayClass193_0 _003C_003E8__1;

		public Func<Task<bool>> preLoginTask;

		private Task _003CgetAccessObjectTask_003E5__2;

		private InitializeSessionResponse _003CinitializeSessionResponse_003E5__3;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<LoginResult> _003C_003Eu__3;

		private TaskAwaiter _003C_003Eu__4;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnClanDisbandedMessage_003Ed__254 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<ClanHomeInfo> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnKickedFromClan_003Ed__257 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<ClanHomeInfo> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CClanNameExists_003Ed__271 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<CheckClanParameterValidResult> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string clanName;

		private TaskAwaiter<CheckClanParameterValidResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CClanTagExists_003Ed__272 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<CheckClanParameterValidResult> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string clanTag;

		private TaskAwaiter<CheckClanParameterValidResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetClanHomeInfo_003Ed__273 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ClanHomeInfo> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetClanHomeInfoResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetClanLeaderboardInfo_003Ed__279 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ClanLeaderboardInfo> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetClanLeaderboardResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPlayerClanInfo_003Ed__280 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ClanInfo> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerId;

		private TaskAwaiter<GetPlayerClanInfoResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPremadeGameList_003Ed__282 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PremadeGameList> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetPremadeGameListResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetAvailableScenes_003Ed__283 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AvailableScenes> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetAvailableScenesResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetLobbyNews_003Ed__284 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PublishedLobbyNewsArticle[]> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetPublishedLobbyNewsMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCreatePremadeGame_003Ed__293 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string password;

		public string name;

		public string gameType;

		public string mapName;

		public string factionA;

		public string factionB;

		public PremadeGameType premadeGameType;

		private TaskAwaiter<CreatePremadeGameMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CInviteToPlatformSession_003Ed__305 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerId;

		private TaskAwaiter<bool> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CEndCustomGame_003Ed__306 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<EndHostingCustomGameResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CRegisterCustomGame_003Ed__307 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string gameType;

		public string map;

		public string gameModule;

		public string serverName;

		public int maxPlayerCount;

		public string uniqueMapId;

		public string gamePassword;

		public string adminPassword;

		public int port;

		private TaskAwaiter<RegisterCustomGameResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CUpdateShownBadgeId_003Ed__315 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string shownBadgeId;

		private TaskAwaiter<UpdateShownBadgeIdMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetAnotherPlayerState_003Ed__316 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AnotherPlayerData> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerId;

		private TaskAwaiter<GetAnotherPlayerStateMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetAnotherPlayerData_003Ed__317 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerData> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerID;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<GetAnotherPlayerDataMessageResult> _003C_003Eu__2;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPlayerCountInQueue_003Ed__318 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<MatchmakingQueueStats> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetPlayerCountInQueueResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetOtherPlayersState_003Ed__319 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<(PlayerId, AnotherPlayerData)>> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public List<PlayerId> players;

		private TaskAwaiter<GetOtherPlayersStateMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetMatchmakingWaitTimes_003Ed__320 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<MatchmakingWaitTimeStats> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetAverageMatchmakingWaitTimesResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPlayerBadges_003Ed__321 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Badge[]> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetPlayerBadgesMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPlayerStats_003Ed__322 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerStatsBase[]> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerID;

		private TaskAwaiter<GetPlayerStatsMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetGameTypeRankInfo_003Ed__323 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GameTypeRankInfo[]> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerID;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<GetPlayerGameTypeRankInfoMessageResult> _003C_003Eu__2;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetRankedLeaderboardCount_003Ed__324 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string gameType;

		private TaskAwaiter<GetRankedLeaderboardCountMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetRankedLeaderboard_003Ed__325 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerLeaderboardData[]> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string gameType;

		public int startIndex;

		public int count;

		private TaskAwaiter<GetRankedLeaderboardMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCanLogin_003Ed__327 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDoesPlayerWithUsernameAndIdExist_003Ed__335 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string username;

		public int userId;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetPlayerByUsernameAndIdMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CUpdateUsedCosmeticItems_003Ed__338 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public Dictionary<string, List<(string cosmeticId, bool isEquipped)>> usedCosmetics;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<UpdateUsedCosmeticItemsMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CBuyCosmetic_003Ed__339 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<(bool isSuccessful, int finalGold)> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public string cosmeticId;

		private TaskAwaiter<BuyCosmeticMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetCosmeticsInfo_003Ed__340 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<(bool isSuccessful, List<string> ownedCosmetics, Dictionary<string, List<string>> usedCosmetics)> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetUserCosmeticsInfoMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetDedicatedCustomServerAuthToken_003Ed__341 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetDedicatedCustomServerAuthTokenMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetOfficialServerProviderName_003Ed__342 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<GetOfficialServerProviderNameResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPlayerBannerlordID_003Ed__343 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public LobbyClient _003C_003E4__this;

		public PlayerId playerId;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<GetBannerlordIDMessageResult> _003C_003Eu__2;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetPingToServer_003Ed__345 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<long> _003C_003Et__builder;

		public string IpAddress;

		private Ping _003Cping_003E5__2;

		private TaskAwaiter<PingReply> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSendPSPlayerJoinedToPlayerSessionMessage_003Ed__347 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public ulong inviterPlayerId;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<PSPlayerJoinedToPlayerSessionMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSendPlatformPlayerJoinedToPlayerSessionMessage_003Ed__348 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public PlayerId inviterPlayerId;

		public LobbyClient _003C_003E4__this;

		private TaskAwaiter<PSPlayerJoinedToPlayerSessionMessageResult> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCreatePendingRequest_003Ed__350<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

		public PendingRequest requestType;

		public PlayerId playerId;

		public LobbyClient _003C_003E4__this;

		public Task<T> requestTask;

		private (PendingRequest requestType, PlayerId playerId) _003Ckey_003E5__2;

		private TaskAwaiter<T> _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public const string TestRegionCode = "Test";

	private static readonly int ServerStatusCheckDelay;

	private static int _friendListCheckDelay;

	private static readonly int CheckForCustomGamesCount;

	private static readonly int CheckForCustomGamesDelay;

	private ILobbyClientSessionHandler _handler;

	private readonly Stopwatch _serverStatusTimer;

	private readonly Stopwatch _friendListTimer;

	private List<string> _ownedCosmetics;

	private Dictionary<string, List<string>> _usedCosmetics;

	private ServerStatus _serverStatus;

	private DateTime _matchmakerBlockedTime;

	private TextObject _logOutReason;

	private State _state;

	private string _userName;

	private PlayerId _playerId;

	private List<ModuleInfoModel> _loadedUnofficialModules;

	private TimedDictionaryCache<PlayerId, GameTypeRankInfo[]> _cachedRankInfos;

	private TimedDictionaryCache<PlayerId, PlayerStatsBase[]> _cachedPlayerStats;

	private TimedDictionaryCache<PlayerId, PlayerData> _cachedPlayerDatas;

	private TimedDictionaryCache<PlayerId, string> _cachedPlayerBannerlordIDs;

	private Dictionary<(PendingRequest, PlayerId), Task> _pendingPlayerRequests;

	private static int FriendListCheckDelay
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

	public PlayerData PlayerData
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

	public SupportedFeatures SupportedFeatures
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

	public ClanInfo ClanInfo
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

	public ClanHomeInfo ClanHomeInfo
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

	public IReadOnlyList<string> OwnedCosmetics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IReadOnlyDictionary<string, List<string>> UsedCosmetics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public AvailableScenes AvailableScenes
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

	public PlayerId PlayerID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRefreshingPlayerData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public State CurrentState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public override long AliveCheckTimeInMiliSeconds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AtLobby
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CanPerformLobbyActions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string LastBattleServerAddressForClient
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

	public ushort LastBattleServerPortForClient
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

	public bool LastBattleIsOfficial
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

	public bool Connected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsIdle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool LoggedIn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInGame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsHostingCustomGame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMatchmakingAvailable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAbleToSearchForGame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool PartySystemAvailable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsCustomBattleAvailable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IReadOnlyList<ModuleInfoModel> LoadedUnofficialModules
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasUnofficialModulesLoaded
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasUserGeneratedContentPrivilege
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

	public bool IsPartyLeader
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsClanLeader
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsClanOfficer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsEligibleToCreatePremadeGame
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

	public CustomBattleId CustomBattleId
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

	public string CustomGameType
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

	public string CustomGameScene
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

	public AvailableCustomGames AvailableCustomGames
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

	public PremadeGameList AvailablePremadeGames
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

	public List<PartyPlayerInLobbyClient> PlayersInParty
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

	public List<ClanPlayer> PlayersInClan
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

	public List<ClanPlayerInfo> PlayerInfosInClan
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

	public FriendInfo[] FriendInfos
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

	public bool IsInParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPartyFull
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string CurrentMatchId
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

	public bool IsInClan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPartyInvitationPopupActive
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

	public bool IsPartyJoinRequestPopupActive
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

	public bool CanInvitePlayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CanSuggestPlayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Guid ClanID
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

	public List<PlayerId> FriendIDs
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Logout(TextObject logOutReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LobbyClient(DiamondClientApplication diamondClientApplication, IClientSessionProvider<LobbyClient> sessionProvider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLoadedModules(string[] moduleIDs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetCustomGameServerList_003Ed__185))]
	public Task<AvailableCustomGames> GetCustomGameServerList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void QuitFromCustomGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void QuitFromMatchmakerGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CRequestJoinCustomGame_003Ed__188))]
	public Task<bool> RequestJoinCustomGame(CustomBattleId serverId, string password, bool isJoinAsAdmin = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CRequestJoinPlayerParty_003Ed__189))]
	public Task<bool> RequestJoinPlayerParty(PlayerId targetPlayer, bool inviteRequest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CancelFindGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FindGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CFindCustomGame_003Ed__192))]
	public Task<bool> FindCustomGame(string[] selectedCustomGameTypes, bool? hasCrossplayPrivilege, string region)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CConnect_003Ed__193))]
	public Task<LobbyClientConnectResult> Connect(ILobbyClientSessionHandler lobbyClientSessionHandler, ILoginAccessProvider lobbyClientLoginAccessProvider, string overridenUserName, bool hasUserGeneratedContentPrivilege, PlatformInitParams initParams, Func<Task<bool>> preLoginTask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void KickPlayer(PlayerId id, bool banPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeRegion(string region)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeGameTypes(string[] gameTypes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndSendMessage(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCantConnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveLobbyClientHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFindGameAnswerMessage(FindGameAnswerMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnJoinBattleMessage(JoinBattleMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBattleOverMessage(BattleOverMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBattleResultMessage(BattleResultMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBattleServerLostMessage(BattleServerLostMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCancelBattleResponseMessage(CancelBattleResponseMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRejoinRequestRejectedMessage(RejoinRequestRejectedMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCancelFindGameMessage(CancelFindGameMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWhisperMessageReceivedMessage(WhisperReceivedMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanMessageReceivedMessage(ClanMessageReceivedMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChannelMessageReceivedMessage(ChannelMessageReceivedMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyMessageReceivedMessage(PartyMessageReceivedMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerQuitFromMatchmakerGameResult(PlayerQuitFromMatchmakerGameResult message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnterBattleWithPartyAnswerMessage(EnterBattleWithPartyAnswer message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnJoinCustomGameResultMessage(JoinCustomGameResultMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClientWantsToConnectCustomGameMessage(ClientWantsToConnectCustomGameMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClientQuitFromCustomGameMessage(ClientQuitFromCustomGameMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnterCustomBattleWithPartyAnswerMessage(EnterCustomBattleWithPartyAnswer message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerRemovedFromMatchmakerGameMessage(PlayerRemovedFromMatchmakerGame message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerRemovedFromCustomGame(PlayerRemovedFromCustomGame message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSystemMessage(SystemMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAdminMessage(AdminMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInvitationToPartyMessage(InvitationToPartyMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyInvitationInvalidMessage(PartyInvitationInvalidMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRequestJoinPartyMessage(RequestJoinPartyMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerInvitedToPartyMessage(PlayerInvitedToPartyMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerAddedToPartyMessage(PlayersAddedToPartyMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerRemovedFromPartyMessage(PlayerRemovedFromPartyMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerAssignedPartyLeaderMessage(PlayerAssignedPartyLeaderMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerSuggestedToPartyMessage(PlayerSuggestedToPartyMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnUpdatePlayerDataMessage(UpdatePlayerDataMessage updatePlayerDataMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnServerStatusMessage(ServerStatusMessage serverStatusMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFriendListMessage(FriendListMessage friendListMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMatchmakerDisabledMessage(MatchmakerDisabledMessage matchmakerDisabledMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanCreationRequestMessage(ClanCreationRequestMessage clanCreationRequestMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanCreationRequestAnsweredMessage(ClanCreationRequestAnsweredMessage clanCreationRequestAnsweredMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanCreationSuccessfulMessage(ClanCreationSuccessfulMessage clanCreationSuccessfulMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanCreationFailedMessage(ClanCreationFailedMessage clanCreationFailedMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCreateClanAnswerMessage(CreateClanAnswerMessage createClanAnswerMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendWhisper(string playerName, string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRecentPlayerStatusesMessage(RecentPlayerStatusesMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FleeBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendPartyMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanInfoChangedMessage(ClanInfoChangedMessage clanInfoChangedMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInvitationToClanMessage(InvitationToClanMessage invitationToClanMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RejoinBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnJoinPremadeGameAnswerMessage(JoinPremadeGameAnswerMessage joinPremadeGameAnswerMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBattleResultsSeen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCreatePremadeGameAnswerMessage(CreatePremadeGameAnswerMessage createPremadeGameAnswerMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnJoinPremadeGameRequestMessage(JoinPremadeGameRequestMessage joinPremadeGameRequestMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnJoinPremadeGameRequestResultMessage(JoinPremadeGameRequestResultMessage joinPremadeGameRequestResultMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003COnClanDisbandedMessage_003Ed__254))]
	private void OnClanDisbandedMessage(ClanDisbandedMessage clanDisbandedMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanGameCreationCancelledMessage(ClanGameCreationCancelledMessage clanGameCreationCancelledMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPremadeGameEligibilityStatusMessage(PremadeGameEligibilityStatusMessage premadeGameEligibilityStatusMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003COnKickedFromClan_003Ed__257))]
	private void OnKickedFromClan(KickedFromClanMessage kickedFromClanMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCustomBattleOverMessage(CustomBattleOverMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AcceptClanInvitation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeclineClanInvitation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShowAnnouncementMessage(ShowAnnouncementMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MarkNotificationAsRead(int notificationID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRejoinBattleRequestAnswerMessage(RejoinBattleRequestAnswerMessage rejoinBattleRequestAnswerMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AcceptClanCreationRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPendingBattleRejoinMessage(PendingBattleRejoinMessage pendingBattleRejoinMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSigilChangeAnswerMessage(SigilChangeAnswerMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeclineClanCreationRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PromoteToClanLeader(PlayerId playerId, bool dontUseNameForUnknownPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLobbyNotificationsMessage(LobbyNotificationsMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void KickFromClan(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CClanNameExists_003Ed__271))]
	public Task<CheckClanParameterValidResult> ClanNameExists(string clanName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CClanTagExists_003Ed__272))]
	public Task<CheckClanParameterValidResult> ClanTagExists(string clanTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetClanHomeInfo_003Ed__273))]
	public Task<ClanHomeInfo> GetClanHomeInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void JoinChannel(ChatChannelType channel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssignAsClanOfficer(PlayerId playerId, bool dontUseNameForUnknownPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveClanOfficerRoleForPlayer(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeaveChannel(ChatChannelType channel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateClanInfo(ClanHomeInfo clanHomeInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetClanLeaderboardInfo_003Ed__279))]
	public Task<ClanLeaderboardInfo> GetClanLeaderboardInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPlayerClanInfo_003Ed__280))]
	public Task<ClanInfo> GetPlayerClanInfo(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendClanMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPremadeGameList_003Ed__282))]
	public Task<PremadeGameList> GetPremadeGameList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetAvailableScenes_003Ed__283))]
	public Task<AvailableScenes> GetAvailableScenes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetLobbyNews_003Ed__284))]
	public Task<PublishedLobbyNewsArticle[]> GetLobbyNews()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClanInformationText(string informationText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddClanAnnouncement(string announcement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EditClanAnnouncement(int announcementId, string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveClanAnnouncement(int announcementId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeClanFaction(string faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeClanSigil(string sigil)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DestroyClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InviteToClan(PlayerId invitedPlayerId, bool dontUseNameForUnknownPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCreatePremadeGame_003Ed__293))]
	public void CreatePremadeGame(string name, string gameType, string mapName, string factionA, string factionB, string password, PremadeGameType premadeGameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CancelCreatingPremadeGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestToJoinPremadeGame(Guid gameId, string password)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AcceptJoinPremadeGameRequest(Guid partyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeclineJoinPremadeGameRequest(Guid partyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InviteToParty(PlayerId playerId, bool dontUseNameForUnknownPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisbandParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void KickPlayerFromParty(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerNameUpdated(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleUseClanSigil(bool isUsed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PromotePlayerToPartyLeader(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeSigil(string sigilId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CInviteToPlatformSession_003Ed__305))]
	public Task<bool> InviteToPlatformSession(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CEndCustomGame_003Ed__306))]
	public void EndCustomGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CRegisterCustomGame_003Ed__307))]
	public void RegisterCustomGame(string gameModule, string gameType, string serverName, int maxPlayerCount, string map, string uniqueMapId, string gamePassword, string adminPassword, int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCustomGameData(string newGameType, string newMap, int newCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResponseCustomGameClientConnection(PlayerJoinGameResponseDataFromHost[] playerJoinData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AcceptPartyInvitation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeclinePartyInvitation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AcceptPartyJoinRequest(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeclinePartyJoinRequest(PlayerId playerId, PartyJoinDeclineReason reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCharacter(BodyProperties bodyProperties, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CUpdateShownBadgeId_003Ed__315))]
	public Task<bool> UpdateShownBadgeId(string shownBadgeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetAnotherPlayerState_003Ed__316))]
	public Task<AnotherPlayerData> GetAnotherPlayerState(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetAnotherPlayerData_003Ed__317))]
	public Task<PlayerData> GetAnotherPlayerData(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPlayerCountInQueue_003Ed__318))]
	public Task<MatchmakingQueueStats> GetPlayerCountInQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetOtherPlayersState_003Ed__319))]
	public Task<List<(PlayerId, AnotherPlayerData)>> GetOtherPlayersState(List<PlayerId> players)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetMatchmakingWaitTimes_003Ed__320))]
	public Task<MatchmakingWaitTimeStats> GetMatchmakingWaitTimes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPlayerBadges_003Ed__321))]
	public Task<Badge[]> GetPlayerBadges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPlayerStats_003Ed__322))]
	public Task<PlayerStatsBase[]> GetPlayerStats(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetGameTypeRankInfo_003Ed__323))]
	public Task<GameTypeRankInfo[]> GetGameTypeRankInfo(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetRankedLeaderboardCount_003Ed__324))]
	public Task<int> GetRankedLeaderboardCount(string gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetRankedLeaderboard_003Ed__325))]
	public Task<PlayerLeaderboardData[]> GetRankedLeaderboard(string gameType, int startIndex, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendCreateClanMessage(string clanName, string clanTag, string clanFaction, string clanSigil)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCanLogin_003Ed__327))]
	public Task<bool> CanLogin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetFriendList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFriend(PlayerId friendId, bool dontUseNameForUnknownPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveFriend(PlayerId friendId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RespondToFriendRequest(PlayerId playerId, bool dontUseNameForUnknownPlayer, bool isAccepted, bool isBlocked = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReportPlayer(string gameId, PlayerId player, string playerName, PlayerReportType type, string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeUsername(string username)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFriendByUsernameAndId(string username, int userId, bool dontUseNameForUnknownPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CDoesPlayerWithUsernameAndIdExist_003Ed__335))]
	public Task<bool> DoesPlayerWithUsernameAndIdExist(string username, int userId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerClanLeader(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerClanOfficer(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CUpdateUsedCosmeticItems_003Ed__338))]
	public Task<bool> UpdateUsedCosmeticItems(Dictionary<string, List<(string cosmeticId, bool isEquipped)>> usedCosmetics)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CBuyCosmetic_003Ed__339))]
	public Task<(bool isSuccessful, int finalGold)> BuyCosmetic(string cosmeticId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetCosmeticsInfo_003Ed__340))]
	public Task<(bool isSuccessful, List<string> ownedCosmetics, Dictionary<string, List<string>> usedCosmetics)> GetCosmeticsInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetDedicatedCustomServerAuthToken_003Ed__341))]
	public Task<string> GetDedicatedCustomServerAuthToken()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetOfficialServerProviderName_003Ed__342))]
	public Task<string> GetOfficialServerProviderName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPlayerBannerlordID_003Ed__343))]
	public Task<string> GetPlayerBannerlordID(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsKnownPlayer(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetPingToServer_003Ed__345))]
	public Task<long> GetPingToServer(string IpAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssertCanPerformLobbyActions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CSendPSPlayerJoinedToPlayerSessionMessage_003Ed__347))]
	public Task<bool> SendPSPlayerJoinedToPlayerSessionMessage(ulong inviterPlayerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CSendPlatformPlayerJoinedToPlayerSessionMessage_003Ed__348))]
	public Task<bool> SendPlatformPlayerJoinedToPlayerSessionMessage(PlayerId inviterPlayerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Task WaitForPendingRequestCompletion(PendingRequest requestType, PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCreatePendingRequest_003Ed__350<>))]
	private Task<T> CreatePendingRequest<T>(PendingRequest requestType, PlayerId playerId, Task<T> requestTask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LobbyClient()
	{
		throw null;
	}
}
