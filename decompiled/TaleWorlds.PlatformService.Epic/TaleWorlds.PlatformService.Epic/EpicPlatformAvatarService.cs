using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.PlatformService.Epic;

public class EpicPlatformAvatarService : IAvatarService
{
	private readonly string _resourceFolder;

	private readonly List<byte[]> _avatarImagesAsByteArrays;

	private bool _isInitialized;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EpicPlatformAvatarService()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AvatarData GetPlayerAvatar(PlayerId playerId)
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
}
