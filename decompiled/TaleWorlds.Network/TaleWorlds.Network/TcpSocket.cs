using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

internal class TcpSocket
{
	public const int MaxMessageSize = 16777216;

	internal const int PeerAliveCode = -1234;

	internal const int DisconnectCode = -9999;

	private int _uniqueSocketId;

	private static int _socketCount;

	private Socket _dotNetSocket;

	private SocketAsyncEventArgs _socketAsyncEventArgsWrite;

	private SocketAsyncEventArgs _socketAsyncEventArgsListener;

	private SocketAsyncEventArgs _socketAsyncEventArgsRead;

	internal MessageBuffer LastReadMessage;

	private ConcurrentQueue<MessageBuffer> _writeNetworkMessageQueue;

	private MessageBuffer _currentlySendingMessage;

	private bool _currentlyAcceptingClients;

	private ConcurrentQueue<TcpSocket> _incomingConnections;

	private int _lastMessageTotalRead;

	private TcpStatus _status;

	private bool _processingReceive;

	private string _remoteEndComputerName;

	private readonly MessageBuffer _peerAliveMessageBuffer;

	private readonly MessageBuffer _disconnectMessageBuffer;

	internal int LastMessageSentTime
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

	internal int LastMessageArrivalTime
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

	internal TcpStatus Status
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

	internal string RemoteEndComputerName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal string IPAddress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal bool IsConnected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal event TcpMessageReceiverDelegate MessageReceived
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

	internal event TcpCloseDelegate Closed
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
	internal TcpSocket()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TcpSocket GetLastIncomingConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Connect(string address, int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CheckAcceptClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Listen(int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ProcessRead()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ProcessWrite()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessIO(object sender, SocketAsyncEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIncomingConnection(SocketAsyncEventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnqueueMessage(MessageBuffer messageBuffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SendDisconnectMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SendPeerAliveMessage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SendMessage(MessageBuffer messageBuffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Close()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TcpSocket()
	{
		throw null;
	}
}
