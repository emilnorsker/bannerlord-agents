using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerPollComponent : MissionNetwork
{
	private abstract class MultiplayerPoll
	{
		public enum Type
		{
			KickPlayer,
			BanPlayer,
			ChangeGame
		}

		private const int TimeoutInSeconds = 30;

		public Action<MultiplayerPoll> OnClosedOnServer;

		public Action<MultiplayerPoll> OnCancelledOnServer;

		public int AcceptedCount;

		public int RejectedCount;

		private readonly List<NetworkCommunicator> _participantsToVote;

		private readonly MultiplayerGameType _gameType;

		public Type PollType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public bool IsOpen
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

		private int OpenTime
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		private int CloseTime
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

		public List<NetworkCommunicator> ParticipantsToVote
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MultiplayerPoll(MultiplayerGameType gameType, Type pollType, List<NetworkCommunicator> participantsToVote)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual bool IsCancelled()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual List<NetworkCommunicator> GetPollProgressReceivers()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Close()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Cancel()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ApplyVote(NetworkCommunicator peer, bool accepted)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool GotEnoughAcceptVotesToEnd()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool GotEnoughRejectVotesToEnd()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool AcceptedByAllParticipants()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool AcceptedByMajority()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool RejectedByAtLeastOneParticipant()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool RejectedByMajority()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int GetPollParticipantCount()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool ResultsFinalized()
		{
			throw null;
		}
	}

	private class KickPlayerPoll : MultiplayerPoll
	{
		public const int RequestLimitPerPeer = 2;

		private readonly Team _team;

		public NetworkCommunicator TargetPeer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public KickPlayerPoll(MultiplayerGameType gameType, List<NetworkCommunicator> participantsToVote, NetworkCommunicator targetPeer, Team team)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsCancelled()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override List<NetworkCommunicator> GetPollProgressReceivers()
		{
			throw null;
		}
	}

	private class BanPlayerPoll : MultiplayerPoll
	{
		public NetworkCommunicator TargetPeer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public BanPlayerPoll(MultiplayerGameType gameType, List<NetworkCommunicator> participantsToVote, NetworkCommunicator targetPeer)
		{
			throw null;
		}
	}

	private class ChangeGamePoll : MultiplayerPoll
	{
		public string GameType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public string MapName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ChangeGamePoll(MultiplayerGameType currentGameType, List<NetworkCommunicator> participantsToVote, string gameType, string scene)
		{
			throw null;
		}
	}

	public const int MinimumParticipantCountRequired = 3;

	public Action<MissionPeer, MissionPeer, bool> OnKickPollOpened;

	public Action<MultiplayerPollRejectReason> OnPollRejected;

	public Action<int, int> OnPollUpdated;

	public Action OnPollClosed;

	public Action OnPollCancelled;

	private MissionLobbyComponent _missionLobbyComponent;

	private MultiplayerGameNotificationsComponent _notificationsComponent;

	private MultiplayerPoll _ongoingPoll;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Vote(bool accepted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyVote(NetworkCommunicator peer, bool accepted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RejectPollOnServer(NetworkCommunicator pollCreatorPeer, MultiplayerPollRejectReason rejectReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RejectPoll(MultiplayerPollRejectReason rejectReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePollProgress(int votesAccepted, int votesRejected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CancelPoll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPollCancelledOnServer(MultiplayerPoll multiplayerPoll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RequestKickPlayerPoll(NetworkCommunicator peer, bool banPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenKickPlayerPollOnServer(NetworkCommunicator pollCreatorPeer, NetworkCommunicator targetPeer, bool banPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenKickPlayerPoll(NetworkCommunicator targetPeer, NetworkCommunicator pollCreatorPeer, bool banPlayer, List<NetworkCommunicator> participantsToVote)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKickPlayerPollClosedOnServer(MultiplayerPoll multiplayerPoll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CloseKickPlayerPoll(bool accepted, NetworkCommunicator targetPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBanPlayerPollClosedOnServer(MultiplayerPoll multiplayerPoll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartChangeGamePollOnServer(NetworkCommunicator pollCreatorPeer, string gameType, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartChangeGamePoll(string gameType, string map)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowChangeGamePoll(string gameType, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChangeGamePollClosedOnServer(MultiplayerPoll multiplayerPoll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventChangeGamePoll(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventKickPlayerPollRequested(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventPollResponse(NetworkCommunicator peer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventChangeGamePoll(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventKickPlayerPollOpened(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventUpdatePollProgress(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventPollCancelled(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventKickPlayerPollClosed(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventPollRequestRejected(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerPollComponent()
	{
		throw null;
	}
}
