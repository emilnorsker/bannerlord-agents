using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade;

public static class GameNetwork
{
	public class NetworkMessageHandlerRegisterer
	{
		public enum RegisterMode
		{
			Add,
			Remove
		}

		private readonly RegisterMode _registerMode;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NetworkMessageHandlerRegisterer(RegisterMode definitionMode)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Register<T>(GameNetworkMessage.ServerMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RegisterBaseHandler<T>(GameNetworkMessage.ServerMessageHandlerDelegate<GameNetworkMessage> handler) where T : GameNetworkMessage
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Register<T>(GameNetworkMessage.ClientMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RegisterBaseHandler<T>(GameNetworkMessage.ClientMessageHandlerDelegate<GameNetworkMessage> handler) where T : GameNetworkMessage
		{
			throw null;
		}
	}

	public class NetworkMessageHandlerRegistererContainer
	{
		private List<Delegate> _fromClientHandlers;

		private List<Delegate> _fromServerHandlers;

		private List<Tuple<GameNetworkMessage.ServerMessageHandlerDelegate<GameNetworkMessage>, Type>> _fromServerBaseHandlers;

		private List<Tuple<GameNetworkMessage.ClientMessageHandlerDelegate<GameNetworkMessage>, Type>> _fromClientBaseHandlers;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NetworkMessageHandlerRegistererContainer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RegisterBaseHandler<T>(GameNetworkMessage.ServerMessageHandlerDelegate<GameNetworkMessage> handler) where T : GameNetworkMessage
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Register<T>(GameNetworkMessage.ServerMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RegisterBaseHandler<T>(GameNetworkMessage.ClientMessageHandlerDelegate<GameNetworkMessage> handler)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Register<T>(GameNetworkMessage.ClientMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RegisterMessages()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void UnregisterMessages()
		{
			throw null;
		}
	}

	[Flags]
	public enum EventBroadcastFlags
	{
		None = 0,
		ExcludeTargetPlayer = 1,
		ExcludeNoBloodStainsOption = 2,
		ExcludeNoParticlesOption = 4,
		ExcludeNoSoundOption = 8,
		AddToMissionRecord = 0x10,
		IncludeUnsynchronizedClients = 0x20,
		ExcludeOtherTeamPlayers = 0x40,
		ExcludePeerTeamPlayers = 0x80,
		DontSendToPeers = 0x100
	}

	[EngineStruct("Debug_network_position_compression_statistics_struct", false, null)]
	public struct DebugNetworkPositionCompressionStatisticsStruct
	{
		public int totalPositionUpload;

		public int totalPositionPrecisionBitCount;

		public int totalPositionCoarseBitCountX;

		public int totalPositionCoarseBitCountY;

		public int totalPositionCoarseBitCountZ;
	}

	[EngineStruct("Debug_network_packet_statistics_struct", false, null)]
	public struct DebugNetworkPacketStatisticsStruct
	{
		public int TotalPackets;

		public int TotalUpload;

		public int TotalConstantsUpload;

		public int TotalReliableEventUpload;

		public int TotalReplicationUpload;

		public int TotalUnreliableEventUpload;

		public int TotalReplicationTableAdderCount;

		public int TotalReplicationTableAdderBitCount;

		public int TotalReplicationTableAdder;

		public double TotalCellPriority;

		public double TotalCellAgentPriority;

		public double TotalCellCellPriority;

		public int TotalCellPriorityChecks;

		public int TotalSentCellCount;

		public int TotalNotSentCellCount;

		public int TotalReplicationWriteCount;

		public int CurMaxPacketSizeInBytes;

		public double AveragePingTime;

		public double AverageDtToSendPacket;

		public double TimeOutPeriod;

		public double PacingRate;

		public double DeliveryRate;

		public double RoundTripTime;

		public int InflightBitCount;

		public int IsCongested;

		public int ProbeBwPhaseIndex;

		public double LostPercent;

		public int LostCount;

		public int TotalCountOnLostCheck;
	}

	public struct AddPlayersResult
	{
		public bool Success;

		public NetworkCommunicator[] NetworkPeers;
	}

	[CompilerGenerated]
	private sealed class _003Cget_NetworkPeersIncludingDisconnectedPeers_003Ed__27 : IEnumerable<NetworkCommunicator>, IEnumerable, IEnumerator<NetworkCommunicator>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private NetworkCommunicator _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<NetworkCommunicator>.Enumerator _003C_003E7__wrap1;

		private int _003Ci_003E5__3;

		NetworkCommunicator IEnumerator<NetworkCommunicator>.Current
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
		public _003Cget_NetworkPeersIncludingDisconnectedPeers_003Ed__27(int _003C_003E1__state)
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
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<NetworkCommunicator> IEnumerable<NetworkCommunicator>.GetEnumerator()
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

	public const int MaxAutomatedBattleIndex = 10;

	public const int MaxPlayerCount = 1023;

	private static IGameNetworkHandler _handler;

	public static int ClientPeerIndex;

	private static MultiplayerMessageFilter MultiplayerLogging;

	private static Dictionary<Type, int> _gameNetworkMessageTypesAll;

	private static Dictionary<Type, int> _gameNetworkMessageTypesFromClient;

	private static List<Type> _gameNetworkMessageIdsFromClient;

	private static Dictionary<Type, int> _gameNetworkMessageTypesFromServer;

	private static List<Type> _gameNetworkMessageIdsFromServer;

	private static Dictionary<int, List<object>> _fromClientMessageHandlers;

	private static Dictionary<int, List<object>> _fromServerMessageHandlers;

	private static Dictionary<int, List<GameNetworkMessage.ClientMessageHandlerDelegate<GameNetworkMessage>>> _fromClientBaseMessageHandlers;

	private static Dictionary<int, List<GameNetworkMessage.ServerMessageHandlerDelegate<GameNetworkMessage>>> _fromServerBaseMessageHandlers;

	private static List<Type> _synchedMissionObjectClassTypes;

	public static bool IsServer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsServerOrRecorder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsClient
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsReplay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsClientOrReplay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsDedicatedServer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool MultiplayerDisabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsMultiplayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsMultiplayerOrReplay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsSessionActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IEnumerable<NetworkCommunicator> NetworkPeersIncludingDisconnectedPeers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_NetworkPeersIncludingDisconnectedPeers_003Ed__27))]
		get
		{
			throw null;
		}
	}

	public static VirtualPlayer[] VirtualPlayers
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

	public static List<NetworkCommunicator> NetworkPeers
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

	public static List<NetworkCommunicator> DisconnectedNetworkPeers
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

	public static int NetworkPeerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool NetworkPeersValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static List<UdpNetworkComponent> NetworkComponents
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

	public static List<IUdpNetworkHandler> NetworkHandlers
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

	public static NetworkCommunicator MyPeer
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

	public static bool IsMyPeerReady
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddNetworkPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RemoveNetworkPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddToDisconnectedPeers(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearAllPeers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NetworkCommunicator FindNetworkPeer(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize(IGameNetworkHandler handler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void StartMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void HandleRemovePlayer(MBNetworkPeer peer, bool isTimedOut)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HandleRemovePlayerInternal(NetworkCommunicator networkPeer, bool isDisconnected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void HandleDisconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartReplay()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndReplay()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PreStartMultiplayerOnServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartMultiplayerOnServer(int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static bool HandleNetworkPacketAsServer(MBNetworkPeer networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool HandleNetworkPacketAsServer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	public static void HandleConsoleCommand(string command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeServerSide(int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TerminateServerSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PrepareNewUdpSession(int peerIndex, int sessionKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetActiveUdpSessionsIpAddress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ICommunicator AddNewPlayerOnServer(PlayerConnectionInfo playerConnectionInfo, bool serverPeer, bool isAdmin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AddPlayersResult AddNewPlayersOnServer(PlayerConnectionInfo[] playerConnectionInfos, bool serverPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClientFinishedLoading(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginModuleEventAsClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndModuleEventAsClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginModuleEventAsClientUnreliable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndModuleEventAsClientUnreliable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginModuleEventAsServer(NetworkCommunicator communicator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginModuleEventAsServerUnreliable(NetworkCommunicator communicator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginModuleEventAsServer(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndModuleEventAsServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginModuleEventAsServerUnreliable(VirtualPlayer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndModuleEventAsServerUnreliable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BeginBroadcastModuleEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndBroadcastModuleEvent(EventBroadcastFlags broadcastFlags, NetworkCommunicator targetPlayer = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double ElapsedTimeSinceLastUdpPacketArrived()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndBroadcastModuleEventUnreliable(EventBroadcastFlags broadcastFlags, NetworkCommunicator targetPlayer = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UnSynchronizeEveryone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddRemoveMessageHandlers(NetworkMessageHandlerRegisterer.RegisterMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartMultiplayerOnClient(string serverAddress, int port, int sessionKey, int playerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static bool HandleNetworkPacketAsClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetSessionKeyForPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NetworkCommunicator HandleNewClientConnect(PlayerConnectionInfo playerConnectionInfo, bool isAdmin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AddPlayersResult HandleNewClientsConnect(PlayerConnectionInfo[] playerConnectionInfos, bool isAdmin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddNetworkPeerToDisconnectAsServer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleServerEventCreatePlayer(CreatePlayer message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleServerEventDeletePlayer(DeletePlayer message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeClientSide(string serverAddress, int port, int sessionKey, int playerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TerminateClientSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Type GetSynchedMissionObjectReadableRecordTypeFromIndex(int typeIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetSynchedMissionObjectReadableRecordIndexFromType(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DestroyComponent(UdpNetworkComponent udpNetworkComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T AddNetworkComponent<T>() where T : UdpNetworkComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddNetworkHandler(IUdpNetworkHandler handler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveNetworkHandler(IUdpNetworkHandler handler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetNetworkComponent<T>() where T : UdpNetworkComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteMessage(GameNetworkMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddServerMessageHandler<T>(GameNetworkMessage.ServerMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddServerBaseMessageHandler(GameNetworkMessage.ServerMessageHandlerDelegate<GameNetworkMessage> handler, Type messageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddClientMessageHandler<T>(GameNetworkMessage.ClientMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddClientBaseMessageHandler(GameNetworkMessage.ClientMessageHandlerDelegate<GameNetworkMessage> handler, Type messageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RemoveServerMessageHandler<T>(GameNetworkMessage.ServerMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RemoveServerBaseMessageHandler(GameNetworkMessage.ServerMessageHandlerDelegate<GameNetworkMessage> handler, Type messageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RemoveClientMessageHandler<T>(GameNetworkMessage.ClientMessageHandlerDelegate<T> handler) where T : GameNetworkMessage
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FindGameNetworkMessages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FindSynchedMissionObjectTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void RemoveClientBaseMessageHandler(GameNetworkMessage.ClientMessageHandlerDelegate<GameNetworkMessage> handler, Type messageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckAssemblyForNetworkMessage(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetServerBandwidthLimitInMbps(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetServerTickRate(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetServerFrameRate(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetDebugVariables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PrintDebugStats()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAveragePacketLossRatio()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetDebugUploadsInBits(ref DebugNetworkPacketStatisticsStruct networkStatisticsStruct, ref DebugNetworkPositionCompressionStatisticsStruct posStatisticsStruct)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PrintReplicationTableStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearReplicationTableStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetDebugUploads()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ResetMissionData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddPeerToDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeCompressionInfos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void SyncRelevantGameOptionsToServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectGameNetworkMessagesFromAssembly(Assembly assembly, List<Type> gameNetworkMessagesFromClient, List<Type> gameNetworkMessagesFromServer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectSynchedMissionObjectTypesFromAssembly(Assembly assembly, List<Type> synchedMissionObjectClassTypes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GameNetwork()
	{
		throw null;
	}
}
