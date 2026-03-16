using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Network;

public abstract class MessageServiceConnection
{
	public delegate Task ClosedDelegate();

	public delegate void StateChangedDelegate(ConnectionState oldState, ConnectionState newState);

	public ConnectionState State;

	public ConnectionState OldState;

	public string Address
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public event ClosedDelegate Closed
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

	public event StateChangedDelegate StateChanged
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
	public MessageServiceConnection()
	{
		throw null;
	}

	public abstract Task SendAsync(string text);

	public abstract void Init(string address, string token);

	public abstract void RegisterProxyClient(string name, IMessageProxyClient playerClient);

	public abstract Task StartAsync();

	public abstract Task StopAsync();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void InvokeClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void InvokeStateChanged(ConnectionState oldState, ConnectionState newState)
	{
		throw null;
	}
}
