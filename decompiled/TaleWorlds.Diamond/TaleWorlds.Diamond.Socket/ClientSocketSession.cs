using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TaleWorlds.Network;

namespace TaleWorlds.Diamond.Socket;

public abstract class ClientSocketSession : ClientsideSession, IClientSession
{
	private string _address;

	private int _port;

	private IClient _client;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ClientSocketSession(IClient client, string address, int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSocketMessage(SocketMessage socketMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCantConnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.Connect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.Disconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<TReturn> IClientSession.CallFunction<TReturn>(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.SendMessage(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<LoginResult> IClientSession.Login(LoginMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IClientSession.CheckConnection()
	{
		throw null;
	}
}
