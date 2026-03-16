using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class BannerPersistentTextureCache : ThumbnailCache<BannerTextureCreationData>
{
	public static BannerPersistentTextureCache Current
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
	public BannerPersistentTextureCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextureCreationInfo OnCreateTexture(BannerTextureCreationData textureCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnReleaseTexture(BannerTextureCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlushCache()
	{
		throw null;
	}
}
