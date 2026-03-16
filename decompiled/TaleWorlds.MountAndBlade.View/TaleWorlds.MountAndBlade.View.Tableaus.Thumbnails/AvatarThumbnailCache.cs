using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class AvatarThumbnailCache : ThumbnailCache<AvatarThumbnailCreationData>
{
	public static AvatarThumbnailCache Current
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
	public AvatarThumbnailCache(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextureCreationInfo OnCreateTexture(AvatarThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnReleaseTexture(AvatarThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlushCache()
	{
		throw null;
	}
}
