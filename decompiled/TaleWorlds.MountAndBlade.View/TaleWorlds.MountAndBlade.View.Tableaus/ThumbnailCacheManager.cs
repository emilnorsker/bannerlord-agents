using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

namespace TaleWorlds.MountAndBlade.View.Tableaus;

public class ThumbnailCacheManager
{
	private ThumbnailCreatorView _thumbnailCreatorView;

	private Scene _inventoryScene;

	private bool _inventorySceneBeingUsed;

	private MBAgentRendererSceneController _inventorySceneAgentRenderer;

	private Scene _mapConversationScene;

	private bool _mapConversationSceneBeingUsed;

	private MBAgentRendererSceneController _mapConversationSceneAgentRenderer;

	private List<IThumbnailCache> _thumbnailCaches;

	private Texture _heroSilhouetteTexture;

	public static ThumbnailCacheManager Current
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

	public MatrixFrame InventorySceneCameraFrame
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
	private void InitializeThumbnailCreator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCachedInventoryTableauSceneUsed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Scene GetCachedInventoryTableauScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReturnCachedInventoryTableauScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsCachedMapConversationTableauSceneUsed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Scene GetCachedMapConversationTableauScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReturnCachedMapConversationTableauScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfPendingRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNativeMemoryCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterThumbnailCache(IThumbnailCache thumbnailCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterThumbnailCache(IThumbnailCache thumbnailCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeSandboxValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReleaseSandboxValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnThumbnailRenderComplete(string renderId, Texture renderTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextureCreationInfo CreateTexture(ThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DestroyTexture(ThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceClearAllCache(bool releaseImmediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetCachedHeroSilhouetteTexture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearUnusedCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThumbnailCacheManager()
	{
		throw null;
	}
}
