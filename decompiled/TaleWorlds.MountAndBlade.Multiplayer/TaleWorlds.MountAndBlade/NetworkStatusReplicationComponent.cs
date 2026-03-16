using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NetworkMessages.FromServer;

namespace TaleWorlds.MountAndBlade;

internal sealed class NetworkStatusReplicationComponent : UdpNetworkComponent
{
	private class NetworkStatusData
	{
		public float NextPingForceSendTime;

		public float NextPingTrySendTime;

		public int LastSentPingValue;

		public float NextLossTrySendTime;

		public int LastSentLossValue;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NetworkStatusData()
		{
			throw null;
		}
	}

	private List<NetworkStatusData> _peerData;

	private float _nextPerformanceStateTrySendTime;

	private ServerPerformanceState _lastSentPerformanceState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NetworkStatusReplicationComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleServerMessagePingReplication(PingReplication message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleServerMessageLossReplication(LossReplicationMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleServerMessageServerPerformanceStateReplication(ServerPerformanceStateReplicationMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddRemoveMessageHandlers(RegisterMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ServerPerformanceState GetServerPerformanceState()
	{
		throw null;
	}
}
