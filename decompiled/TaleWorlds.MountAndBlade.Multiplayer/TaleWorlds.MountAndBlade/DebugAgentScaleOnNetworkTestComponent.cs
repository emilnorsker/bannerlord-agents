using System.Runtime.CompilerServices;
using NetworkMessages.FromServer;

namespace TaleWorlds.MountAndBlade;

internal sealed class DebugAgentScaleOnNetworkTestComponent : UdpNetworkComponent
{
	private float _lastTestSendTime;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DebugAgentScaleOnNetworkTestComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HandleServerMessageDebugAgentScaleOnNetworkTest(DebugAgentScaleOnNetworkTest message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddRemoveMessageHandlers(RegisterMode mode)
	{
		throw null;
	}
}
