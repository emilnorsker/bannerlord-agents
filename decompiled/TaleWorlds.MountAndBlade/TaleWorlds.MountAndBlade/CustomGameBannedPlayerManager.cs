using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public static class CustomGameBannedPlayerManager
{
	private struct BannedPlayer
	{
		public PlayerId PlayerId
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public int BanDueTime
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}
	}

	private static Dictionary<PlayerId, BannedPlayer> _bannedPlayersInternal;

	private static Dictionary<PlayerId, BannedPlayer> _bannedPlayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddBannedPlayer(PlayerId playerId, int banDueTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsUserBanned(PlayerId playerId)
	{
		throw null;
	}
}
