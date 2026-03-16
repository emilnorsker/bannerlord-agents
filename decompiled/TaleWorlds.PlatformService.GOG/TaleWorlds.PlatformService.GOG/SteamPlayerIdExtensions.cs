using System.Runtime.CompilerServices;
using Galaxy.Api;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.PlatformService.GOG;

public static class SteamPlayerIdExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlayerId ToPlayerId(this GalaxyID galaxyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GalaxyID ToGOGID(this PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsValidGOGId(this PlayerId playerId)
	{
		throw null;
	}
}
