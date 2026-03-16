using System.Runtime.CompilerServices;
using Steamworks;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.PlatformService.Steam;

public static class SteamPlayerIdExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlayerId ToPlayerId(this CSteamID steamId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CSteamID ToSteamId(this PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsValidSteamId(this PlayerId playerId)
	{
		throw null;
	}
}
