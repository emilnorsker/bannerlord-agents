using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TaleWorlds.Network;

public abstract class ServersideSessionManager
{
	public enum ThreadType
	{
		Single,
		MultipleIOAndListener,
		MultipleSeperateIOAndListener
	}

	private int _readWriteThreadCount;

	private ThreadType _threadType;

	private ushort _listenPort;

	private TcpSocket _serverSocket;

	private int _lastUniqueClientId;

	private Thread _serverThread;

	private long _lastPeerAliveCheck;

	private List<ConcurrentQueue<IncomingServerSessionMessage>> _incomingMessages;

	private List<ConcurrentDictionary<int, ServersideSession>> _peers;

	private List<ConcurrentDictionary<int, ServersideSession>> _disconnectedPeers;

	private List<Thread> _readerThreads;

	private List<Thread> _writerThreads;

	private List<Thread> _singleThreads;

	public float PeerAliveCoeff
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ServersideSessionManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Activate(ushort port, ThreadType threadType = ThreadType.Single, int readWriteThreadCount = 1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessRead(object indexObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessWriter(object indexObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessReaderWriter(object indexObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessListener()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessSingle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemovePeer(int peerNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ServersideSession GetPeer(int peerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IncomingConnectionsTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MessagingTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PeerAliveCheckTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleRemovedPeersTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddIncomingMessage(IncomingServerSessionMessage incomingMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddDisconnectedPeer(ServersideSession peer)
	{
		throw null;
	}

	protected abstract ServersideSession OnNewConnection();

	protected abstract void OnRemoveConnection(ServersideSession peer);
}
