using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Network.Messages;
using TaleWorlds.PlatformService;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerPermissionHandler : UdpNetworkComponent
{
	private ChatBox _chatBox;

	private ConcurrentDictionary<(PlayerId PlayerId, Permission Permission), bool> _registeredEvents;

	public event Action<PlayerId, bool> OnPlayerPlatformMuteChanged
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
	public MultiplayerPermissionHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleClientDisconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventInitializeLobbyPeer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerDisconnectedFromServer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TextPermissionChanged(PlayerId targetPlayerId, Permission permission, bool hasPermission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VoicePermissionChanged(PlayerId targetPlayerId, Permission permission, bool hasPermission)
	{
		throw null;
	}
}
