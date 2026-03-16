using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public abstract class UdpNetworkComponent : IUdpNetworkHandler
{
	private GameNetwork.NetworkMessageHandlerRegistererContainer _missionNetworkMessageHandlerRegisterer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected UdpNetworkComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnUdpNetworkHandlerClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnUdpNetworkHandlerTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleNewClientConnect(PlayerConnectionInfo clientConnectionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleEarlyNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleLateNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleNewClientAfterSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandleLateNewClientAfterSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnEveryoneUnSynchronized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HandleEarlyPlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void HandlePlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPlayerDisconnectedFromServer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnDisconnectedFromServer()
	{
		throw null;
	}
}
