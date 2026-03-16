using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.MountAndBlade.Diamond.Ranked;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public class LobbyGameClientHandler : ILobbyClientSessionHandler
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CHandleGameClientStateChange_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public State oldState;

		public LobbyGameClientHandler _003C_003E4__this;

		private LobbyClient _003CgameClient_003E5__2;

		private MissionState _003CmissionSystem_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private int _003Ci_003E5__4;

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
	private struct _003CHandleBattleJoining_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LobbyGameClientHandler _003C_003E4__this;

		public BattleServerInformationForClient battleServerInformation;

		private TaskAwaiter _003C_003Eu__1;

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
	private struct _003CTaleWorlds_002DMountAndBlade_002DDiamond_002DILobbyClientSessionHandler_002DOnInviteToPlatformSession_003Ed__62 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbyGameClientHandler _003C_003E4__this;

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

	public IChatHandler ChatHandler;

	public LobbyState LobbyState
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

	public LobbyClient GameClient
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnCantConnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnDisconnected(TextObject feedback)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPlayerDataReceived(PlayerData playerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPendingRejoin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnBattleResultReceived()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnCancelJoiningBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnRejoinRequestRejected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnFindGameAnswer(bool successful, string[] selectedAndEnabledGameTypes, bool isRejoin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnEnterBattleWithPartyAnswer(string[] selectedGameTypes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnWhisperMessageReceived(string fromPlayer, string toPlayer, string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanMessageReceived(string playerName, string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnChannelMessageReceived(ChatChannelType channel, string playerName, string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPartyMessageReceived(string playerName, string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnSystemMessageReceived(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnAdminMessageReceived(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPartyInvitationReceived(string inviterPlayerName, PlayerId inviterPlayerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPartyJoinRequestReceived(PlayerId joiningPlayerId, PlayerId viaPlayerId, string viaFriendName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPartyInvitationInvalidated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPlayerInvitedToParty(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPlayersAddedToParty(List<(PlayerId PlayerId, string PlayerName, bool IsPartyLeader)> addedPlayers, List<(PlayerId PlayerId, string PlayerName)> invitedPlayers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPlayerRemovedFromParty(PlayerId playerId, PartyRemoveReason reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPlayerAssignedPartyLeader(PlayerId partyLeaderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPlayerSuggestedToParty(PlayerId playerId, string playerName, PlayerId suggestingPlayerId, string suggestingPlayerName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnServerStatusReceived(ServerStatus serverStatus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnFriendListReceived(FriendInfo[] friends)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnRecentPlayerStatusesReceived(FriendInfo[] friends)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanInvitationReceived(string clanName, string clanTag, bool isCreation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanInvitationAnswered(PlayerId playerId, ClanCreationAnswer answer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanCreationSuccessful()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanCreationFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanCreationStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClanInfoChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPremadeGameEligibilityStatusReceived(bool isEligible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPremadeGameCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPremadeGameListReceived()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnPremadeGameCreationCancelled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnJoinPremadeGameRequested(string clanName, string clanSigilCode, Guid partyId, PlayerId[] challengerPlayerIDs, PlayerId challengerPartyLeaderID, PremadeGameType premadeGameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnJoinPremadeGameRequestSuccessful()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnSigilChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnNotificationsReceived(LobbyNotification[] notifications)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnGameClientStateChange(State oldState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CHandleGameClientStateChange_003Ed__43))]
	private void HandleGameClientStateChange(State oldState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnCustomGameServerListReceived(AvailableCustomGames customGameServerList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnMatchmakerGameOver(int oldExperience, int newExperience, List<string> badgesEarned, int lootGained, RankBarInfo oldRankBarInfo, RankBarInfo newRankBarInfo, BattleCancelReason battleCancelReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnQuitFromMatchmakerGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnBattleServerInformationReceived(BattleServerInformationForClient battleServerInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CHandleBattleJoining_003Ed__48))]
	private void HandleBattleJoining(BattleServerInformationForClient battleServerInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnBattleServerLost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnRemovedFromMatchmakerGame(DisconnectType disconnectType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnRejoinBattleRequestAnswered(bool isSuccessful)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnRegisterCustomGameServerResponse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnCustomGameEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	PlayerJoinGameResponseDataFromHost[] ILobbyClientSessionHandler.OnClientWantsToConnectCustomGame(PlayerJoinGameData[] playerJoinData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnJoinCustomGameResponse(bool success, JoinGameData joinGameData, CustomGameJoinResponse failureReason, bool isAdmin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnJoinCustomGameFailureResponse(CustomGameJoinResponse response)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnQuitFromCustomGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnRemovedFromCustomGame(DisconnectType disconnectType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnEnterCustomBattleWithPartyAnswer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnClientQuitFromCustomGame(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyClientSessionHandler.OnAnnouncementReceived(Announcement announcement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DMountAndBlade_002DDiamond_002DILobbyClientSessionHandler_002DOnInviteToPlatformSession_003Ed__62))]
	Task<bool> ILobbyClientSessionHandler.OnInviteToPlatformSession(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LobbyGameClientHandler()
	{
		throw null;
	}
}
