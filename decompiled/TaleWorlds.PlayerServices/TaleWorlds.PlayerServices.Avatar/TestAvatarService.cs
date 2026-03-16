using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.PlayerServices.Avatar;

public class TestAvatarService : IAvatarService
{
	private readonly Dictionary<ulong, AvatarData> _avatarImageCache;

	private readonly string _resourceFolder;

	private readonly List<byte[]> _avatarImagesAsByteArrays;

	private bool _isInitialized;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TestAvatarService()
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
	public void Tick(float dt)
	{
		throw null;
	}
}
