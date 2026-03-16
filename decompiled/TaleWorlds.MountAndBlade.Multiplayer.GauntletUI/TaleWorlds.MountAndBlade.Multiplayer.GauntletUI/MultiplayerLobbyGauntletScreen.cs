using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.MountAndBlade.Diamond.Ranked;
using TaleWorlds.MountAndBlade.GauntletUI;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.CustomGame;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;
using TaleWorlds.PlayerServices;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI;

[GameStateScreen(typeof(LobbyState))]
public class MultiplayerLobbyGauntletScreen : ScreenBase, IGameStateListener, ILobbyStateHandler, IChatLogHandlerScreen
{
	private List<KeyValuePair<string, InquiryData>> _feedbackInquiries;

	private string _activeFeedbackId;

	private KeybindingPopup _keybindingPopup;

	private KeyOptionVM _currentKey;

	private SpriteCategory _optionsSpriteCategory;

	private SpriteCategory _multiplayerSpriteCategory;

	private GauntletLayer _gauntletBrightnessLayer;

	private BrightnessOptionVM _brightnessOptionDataSource;

	private GauntletMovieIdentifier _brightnessOptionMovie;

	private LobbyState _lobbyState;

	private BasicCharacterObject _playerCharacter;

	private bool _isFacegenOpen;

	private SoundEvent _musicSoundEvent;

	private bool _isNavigationRestricted;

	private MPCustomGameSortControllerVM.CustomServerSortOption? _cachedCustomServerSortOption;

	private MPCustomGameSortControllerVM.SortState _cachedCustomServerSortState;

	private MPCustomGameSortControllerVM.CustomServerSortOption? _cachedPremadeGameSortOption;

	private MPCustomGameSortControllerVM.SortState _cachedPremadeGameSortState;

	private bool _isLobbyActive;

	private GauntletLayer _lobbyLayer;

	private MPLobbyVM _lobbyDataSource;

	private SpriteCategory _mplobbyCategory;

	private SpriteCategory _bannerIconsCategory;

	private SpriteCategory _badgesCategory;

	public MPLobbyVM.LobbyPage CurrentPage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MPLobbyVM DataSource
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public GauntletLayer LobbyLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerLobbyGauntletScreen(LobbyState lobbyState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManagedOptionChanged(ManagedOptionsType changedManagedOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IChatLogHandlerScreen.TryUpdateChatLogLayerParameters(ref bool isTeamChatAvailable, ref bool inputEnabled, ref bool isToggleChatHintAvailable, ref bool isMouseVisible, ref InputContext inputContext)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCloseBrightness(bool isConfirm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOpenFacegen(BasicCharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnForceCloseFacegen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFacegenClosed(bool updateCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetContinueKeyText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLogout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNavigationRestriction(bool isRestricted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickInternal(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowNextFeedback()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void TickDebug(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.SetConnectionState(bool isAuthenticated)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnRequestedToSearchBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnUpdateFindingGame(MatchmakingWaitTimeStats matchmakingWaitTimeStats, string[] gameTypeInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnRequestedToCancelSearchBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnSearchBattleCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPause()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnResume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerDataReceived(PlayerData playerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPendingRejoin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnEnterBattleWithParty(string[] selectedGameTypes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPartyInvitationReceived(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPartyJoinRequestReceived(PlayerId joingPlayerId, PlayerId viaPlayerId, string viaPlayerName, bool newParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPartyInvitationInvalidated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerInvitedToParty(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerAddedToParty(PlayerId playerId, string playerName, bool isPartyLeader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerRemovedFromParty(PlayerId playerId, PartyRemoveReason reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnGameClientStateChange(State state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnAdminMessageReceived(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBattleServerInformationReceived(BattleServerInformationForClient battleServerInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string ILobbyStateHandler.ShowFeedback(string title, string feedbackText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	string ILobbyStateHandler.ShowFeedback(InquiryData inquiryData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.DismissFeedback(string feedbackId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectPreviousPage(MPLobbyVM.LobbyPage currentPage = MPLobbyVM.LobbyPage.NotAssigned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectNextPage(MPLobbyVM.LobbyPage currentPage = MPLobbyVM.LobbyPage.NotAssigned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnActivateCustomServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnActivateHome()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnActivateMatchmaking()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnActivateArmory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnActivateProfile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnClanInvitationReceived(string clanName, string clanTag, bool isCreation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnClanInvitationAnswered(PlayerId playerId, ClanCreationAnswer answer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnClanCreationSuccessful()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnClanCreationFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnClanCreationStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnClanInfoChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPremadeGameEligibilityStatusReceived(bool isEligible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPremadeGameCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPremadeGameListReceived()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPremadeGameCreationCancelled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnJoinPremadeGameRequested(string clanName, string clanSigilCode, Guid partyId, PlayerId[] challengerPlayerIDs, PlayerId challengerPartyLeaderID, PremadeGameType premadeGameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnJoinPremadeGameRequestSuccessful()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnSigilChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnActivateOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnDeactivateOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnCustomGameServerListReceived(AvailableCustomGames customGameServerList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnMatchmakerGameOver(int oldExperience, int newExperience, List<string> badgesEarned, int lootGained, RankBarInfo oldRankBarInfo, RankBarInfo newRankBarInfo, BattleCancelReason battleCancelReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnBattleServerLost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnRemovedFromMatchmakerGame(DisconnectType disconnectType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnRemovedFromCustomGame(DisconnectType disconnectType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerAssignedPartyLeader(PlayerId partyLeaderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerSuggestedToParty(PlayerId playerId, string playerName, PlayerId suggestingPlayerId, string suggestingPlayerName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnNotificationsReceived(LobbyNotification[] notifications)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnJoinCustomGameFailureResponse(CustomGameJoinResponse response)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnServerStatusReceived(ServerStatus serverStatus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnRejoinBattleRequestAnswered(bool isSuccessful)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnFriendListUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILobbyStateHandler.OnPlayerNameUpdated(string playerName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowDisconnectMessage(DisconnectType disconnectType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableLobby()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKeybindRequest(KeyOptionVM requestedHotKeyToChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetHotKey(Key key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}
}
