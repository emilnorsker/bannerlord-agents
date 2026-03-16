using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class NetworkCommunication : INetworkCommunication
{
	VirtualPlayer INetworkCommunication.MyPeer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NetworkCommunication()
	{
		throw null;
	}
}
