using System.Runtime.CompilerServices;
using Galaxy.Api;

namespace TaleWorlds.PlatformService.GOG;

public class GogServicesConnectionStateListener : GlobalGogServicesConnectionStateListener
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnConnectionStateChange(GogServicesConnectionState connected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GogServicesConnectionStateListener()
	{
		throw null;
	}
}
