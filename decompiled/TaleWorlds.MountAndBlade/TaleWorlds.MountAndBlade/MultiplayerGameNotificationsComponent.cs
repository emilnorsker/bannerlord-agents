using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Network.Messages;
using TaleWorlds.MountAndBlade.Objects;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerGameNotificationsComponent : MissionNetwork
{
	private enum MultiplayerNotificationEnum
	{
		[NotificationProperty("str_battle_warmup_ending_in_x_seconds", "event:/ui/mission/multiplayer/lastmanstanding", "")]
		BattleWarmupEnding,
		[NotificationProperty("str_battle_preparation_start", "event:/ui/mission/multiplayer/roundstart", "")]
		BattlePreparationStart,
		[NotificationProperty("str_round_result_win_lose", "event:/ui/mission/multiplayer/victory", "event:/ui/mission/multiplayer/defeat")]
		BattleYouHaveXTheRound,
		[NotificationProperty("str_mp_mission_game_over_draw", "", "")]
		GameOverDraw,
		[NotificationProperty("str_mp_mission_game_over_victory", "", "")]
		GameOverVictory,
		[NotificationProperty("str_mp_mission_game_over_defeat", "", "")]
		GameOverDefeat,
		[NotificationProperty("str_mp_flag_removed", "event:/ui/mission/multiplayer/pointsremoved", "")]
		FlagXRemoved,
		[NotificationProperty("str_sergeant_a_one_flag_remaining", "event:/ui/mission/multiplayer/pointsremoved", "")]
		FlagXRemaining,
		[NotificationProperty("str_sergeant_a_flags_will_be_removed", "event:/ui/mission/multiplayer/pointwarning", "")]
		FlagsWillBeRemoved,
		[NotificationProperty("str_sergeant_a_flag_captured_by_your_team", "event:/ui/mission/multiplayer/pointcapture", "event:/ui/mission/multiplayer/pointlost")]
		FlagXCapturedByYourTeam,
		[NotificationProperty("str_sergeant_a_flag_captured_by_other_team", "event:/ui/mission/multiplayer/pointcapture", "event:/ui/mission/multiplayer/pointlost")]
		FlagXCapturedByOtherTeam,
		[NotificationProperty("str_gold_carried_from_previous_round", "", "")]
		GoldCarriedFromPreviousRound,
		[NotificationProperty("str_player_is_inactive", "", "")]
		PlayerIsInactive,
		[NotificationProperty("str_has_ongoing_poll", "", "")]
		HasOngoingPoll,
		[NotificationProperty("str_too_many_poll_requests", "", "")]
		TooManyPollRequests,
		[NotificationProperty("str_kick_poll_target_not_synced", "", "")]
		KickPollTargetNotSynced,
		[NotificationProperty("str_not_enough_players_to_open_poll", "", "")]
		NotEnoughPlayersToOpenPoll,
		[NotificationProperty("str_player_is_kicked", "", "")]
		PlayerIsKicked,
		[NotificationProperty("str_formation_autofollow_enforced", "", "")]
		FormationAutoFollowEnforced,
		Count
	}

	public static int NotificationCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WarmupEnding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GameOver(Team winnerTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreparationStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlagsXRemoved(FlagCapturePoint removedFlag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlagXRemaining(FlagCapturePoint remainingFlag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlagsWillBeRemovedInXSeconds(int timeLeft)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlagXCapturedByTeamX(SynchedMissionObject flag, Team capturingTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GoldCarriedFromPreviousRound(int carriedGoldAmount, NetworkCommunicator syncToPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayerIsInactive(NetworkCommunicator peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FormationAutoFollowEnforced(NetworkCommunicator peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PollRejected(MultiplayerPollRejectReason reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayerKicked(NetworkCommunicator kickedPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleNewNotification(MultiplayerNotificationEnum notification, int param1 = -1, int param2 = -1, Team syncToTeam = null, NetworkCommunicator syncToPeer = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowNotification(MultiplayerNotificationEnum notification, params int[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendNotificationToEveryone(MultiplayerNotificationEnum message, int param1 = -1, int param2 = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendNotificationToPeer(NetworkCommunicator peer, MultiplayerNotificationEnum message, int param1 = -1, int param2 = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendNotificationToTeam(Team team, MultiplayerNotificationEnum message, int param1 = -1, int param2 = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string ToSoundString(MultiplayerNotificationEnum value, NotificationProperty attribute, params int[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject ToNotificationString(MultiplayerNotificationEnum value, NotificationProperty attribute, params int[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGameTextVariables(MultiplayerNotificationEnum message, params int[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventServerMessage(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleNewClientConnect(PlayerConnectionInfo clientConnectionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandlePlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerGameNotificationsComponent()
	{
		throw null;
	}
}
