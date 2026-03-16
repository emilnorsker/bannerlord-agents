using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NetworkMessages.FromClient;
using NetworkMessages.FromServer;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public class ChatBox : GameHandler
{
	private class QueuedMessageInfo
	{
		public readonly NetworkCommunicator SourcePeer;

		public readonly string Message;

		public readonly List<VirtualPlayer> ReceiverList;

		private const float _timeOutDuration = 3f;

		private DateTime _creationTime;

		public bool IsExpired
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public QueuedMessageInfo(NetworkCommunicator sourcePeer, string message, List<VirtualPlayer> receiverList)
		{
			throw null;
		}
	}

	private static ChatBox _chatBox;

	private bool _isNetworkInitialized;

	public const string AdminMessageSoundEvent = "event:/ui/notification/alert";

	private List<PlayerId> _mutedPlayers;

	private List<PlayerId> _platformMutedPlayers;

	private ProfanityChecker _profanityChecker;

	private static List<QueuedMessageInfo> _queuedTeamMessages;

	private static List<QueuedMessageInfo> _queuedEveryoneMessages;

	public Action<NetworkCommunicator, string> OnMessageReceivedAtDedicatedServer;

	public bool IsContentRestricted
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

	public bool NetworkReady
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event PlayerMessageReceivedDelegate PlayerMessageReceived
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

	public event WhisperMessageSentDelegate WhisperMessageSent
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

	public event WhisperMessageReceivedDelegate WhisperMessageReceived
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

	public event ErrorWhisperMessageReceivedDelegate ErrorWhisperMessageReceived
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

	public event ServerMessageDelegate ServerMessage
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

	public event ServerAdminMessageDelegate ServerAdminMessage
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

	public event PlayerMutedDelegate OnPlayerMuteChanged
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
	protected override void OnGameStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBeforeSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterSave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGameEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendMessageToAll(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendMessageToAll(string message, List<VirtualPlayer> receiverList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendMessageToTeam(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendMessageToTeam(string message, List<VirtualPlayer> receiverList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SendMessageToWhisperTarget(string message, string platformName, string whisperTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnServerMessage(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGameNetworkBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegisterer.RegisterMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnGameNetworkEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventPlayerMessageAll(NetworkMessages.FromServer.PlayerMessageAll message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventPlayerMessageTeam(NetworkMessages.FromServer.PlayerMessageTeam message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventServerMessage(ServerMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventServerAdminMessage(ServerAdminMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventPlayerMessageAll(NetworkCommunicator networkPeer, NetworkMessages.FromClient.PlayerMessageAll message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventPlayerMessageTeam(NetworkCommunicator networkPeer, NetworkMessages.FromClient.PlayerMessageTeam message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ServerSendServerMessageToEveryone(string message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ServerPrepareAndSendMessage(NetworkCommunicator fromPeer, bool toTeamOnly, string message, List<VirtualPlayer> receiverList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ServerSendMessageToTeam(NetworkCommunicator networkPeer, string message, List<VirtualPlayer> receiverList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ServerSendMessageToEveryone(NetworkCommunicator networkPeer, string message, List<VirtualPlayer> receiverList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetMuteList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddWhisperMessage(string fromUserName, string messageBody)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddErrorWhisperMessage(string toUserName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWhisperMessageReceived(string fromUserName, string messageBody)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnErrorWhisperMessageReceived(string toUserName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerMessageReceived(NetworkCommunicator networkPeer, string message, bool toTeamOnly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayerMuted(PlayerId playerID, bool isMuted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayerMutedFromPlatform(PlayerId playerID, bool isMuted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerMuted(PlayerId mutedPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerUnmuted(PlayerId unmutedPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerMuted(PlayerId player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerMutedFromPlatform(PlayerId player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerMutedFromGame(PlayerId player)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShouldShowPlayersMessage(PlayerId player, Action<bool> result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetChatFilterLists(string[] profanityList, string[] allowList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeForMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeForSinglePlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLogin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChatBox()
	{
		throw null;
	}
}
