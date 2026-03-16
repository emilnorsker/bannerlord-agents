using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.MountAndBlade.GauntletUI.TextureProviders.ImageIdentifiers;

public class PlayerAvatarImageTextureProvider : ImageIdentifierTextureProvider
{
	private const float AvatarFallbackWaitTime = 1f;

	private const float AvatarFailWaitTime = 5f;

	private AvatarData _receivedAvatarData;

	private bool _isUsingFallbackAvatar;

	private float _timeSinceAvatarFail;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerAvatarImageTextureProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCreateImageWithId(string id, string additionalArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool GetCanForceCheckTexture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCheckTexture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAvatarLoaded(string avatarID, AvatarData avatarData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TextureNeedsRefresh()
	{
		throw null;
	}
}
