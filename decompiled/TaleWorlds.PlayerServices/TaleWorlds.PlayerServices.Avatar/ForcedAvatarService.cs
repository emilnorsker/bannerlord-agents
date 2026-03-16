using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.PlayerServices.Avatar;

internal class ForcedAvatarService : IAvatarService
{
	private readonly string _resourceFolder;

	private readonly List<byte[]> _avatarImagesAsByteArrays;

	private bool _isInitialized;

	public int AvatarCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AvatarData GetPlayerAvatar(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AvatarData GetForcedPlayerAvatar(int forcedIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ForcedAvatarService()
	{
		throw null;
	}
}
