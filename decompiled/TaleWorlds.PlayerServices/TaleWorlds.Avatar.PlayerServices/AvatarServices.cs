using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.Avatar.PlayerServices;

public static class AvatarServices
{
	private static Dictionary<PlayerIdProvidedTypes, IAvatarService> _allAvatarServices;

	private static ForcedAvatarService _forcedAvatarService;

	public static int ForcedAvatarCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetForcedAvatarIndexOfPlayer(PlayerId playerID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static AvatarServices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UpdateAvatarServices(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AvatarDataResponse GetPlayerAvatar(PlayerId playerId, int forcedIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void InitializeFallbackAvatarService()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddAvatarService(PlayerIdProvidedTypes type, IAvatarService avatarService)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearAvatarCaches()
	{
		throw null;
	}
}
