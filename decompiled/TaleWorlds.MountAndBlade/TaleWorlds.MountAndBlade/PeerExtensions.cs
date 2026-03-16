using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public static class PeerExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SendExistingObjects(this NetworkCommunicator peer, Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VirtualPlayer GetPeer(this PeerComponent peerComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NetworkCommunicator GetNetworkPeer(this PeerComponent peerComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetComponent<T>(this NetworkCommunicator networkPeer) where T : PeerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveComponent<T>(this NetworkCommunicator networkPeer, bool synched = true) where T : PeerComponent
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveComponent(this NetworkCommunicator networkPeer, PeerComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PeerComponent GetComponent(this NetworkCommunicator networkPeer, uint componentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddComponent(this NetworkCommunicator networkPeer, Type peerComponentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddComponent(this NetworkCommunicator networkPeer, uint componentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T AddComponent<T>(this NetworkCommunicator networkPeer) where T : PeerComponent, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T TellClientToAddComponent<T>(this NetworkCommunicator networkPeer) where T : PeerComponent, new()
	{
		throw null;
	}
}
