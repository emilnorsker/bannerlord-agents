using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TaleWorlds.Network;

public abstract class ClientsideSession : NetworkSession
{
	private bool _connectionResultHandled;

	private Thread _thread;

	private ConcurrentQueue<MessageBuffer> _incomingMessages;

	private bool _useSessionThread;

	public int Port
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
	protected void SendMessagePeerAlive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ClientsideSession()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Connect(string ip, int port, bool useSessionThread = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSocketMessageReceived(MessageBuffer messageBuffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Process()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ProcessTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick()
	{
		throw null;
	}
}
