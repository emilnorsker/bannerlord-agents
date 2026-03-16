using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.PlayerServices.Avatar;

public class GOGAvatarService : IAvatarService
{
	private readonly Dictionary<ulong, AvatarData> _avatarImageCache;

	private readonly string _resourceFolder;

	private readonly List<byte[]> _avatarImagesAsByteArrays;

	private bool _isInitalized;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AvatarData GetPlayerAvatar(PlayerId playerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GOGAvatarService()
	{
		throw null;
	}
}
