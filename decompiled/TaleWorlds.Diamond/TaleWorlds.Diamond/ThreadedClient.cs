using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Diamond;

public class ThreadedClient : IClient
{
	private IClient _client;

	private Queue<ThreadedClientTask> _tasks;

	public ILoginAccessProvider AccessProvider
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsInCriticalState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public long AliveCheckTimeInMiliSeconds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThreadedClient(IClient client)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClient.HandleMessage(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClient.OnConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClient.OnDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClient.OnCantConnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Task<bool> CheckConnection()
	{
		throw null;
	}
}
