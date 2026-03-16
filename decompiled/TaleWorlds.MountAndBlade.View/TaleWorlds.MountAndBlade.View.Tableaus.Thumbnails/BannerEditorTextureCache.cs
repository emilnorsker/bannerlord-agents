using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class BannerEditorTextureCache : ThumbnailCache<BannerEditorTextureCreationData>
{
	public static BannerEditorTextureCache Current
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
	public BannerEditorTextureCache(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextureCreationInfo OnCreateTexture(BannerEditorTextureCreationData textureCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnReleaseTexture(BannerEditorTextureCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlushCache()
	{
		throw null;
	}
}
