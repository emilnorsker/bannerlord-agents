using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public abstract class ThumbnailCache<T> : IThumbnailCache where T : ThumbnailCreationData
{
	protected int _capacity;

	protected ThumbnailCreatorView _thumbnailCreatorView;

	protected Dictionary<string, ThumbnailCacheNode> _map;

	protected NodeComparer _nodeComparer;

	protected Dictionary<string, RenderCallbackCollection> _renderCallbacks;

	public int Count
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

	public int RenderCallbackCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThumbnailCache(int capacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnClear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnImguiTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRequestCancelled(string renderId)
	{
		throw null;
	}

	protected abstract TextureCreationInfo OnCreateTexture(T thumbnailCreationData);

	protected abstract bool OnReleaseTexture(T thumbnailCreationData);

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IThumbnailCache.OnThumbnailRenderCompleted(string renderId, Texture renderTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextureCreationInfo CreateTexture(ThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReleaseTexture(ThumbnailCreationData thumbnailCreationData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.Initialize(ThumbnailCreatorView thumbnailCreatorView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.Clear(bool releaseImmediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IThumbnailCache.GetValue(string key, out Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.Add(string key, Texture value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IThumbnailCache.AddReference(string key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IThumbnailCache.RemoveReference(string key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.ClearUnusedCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void RemoveThumbnailCacheNode(ThumbnailCacheNode node, bool releaseTexture = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveRenderCallbacksForKey(string renderId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IThumbnailCache.PrintToImgui()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static Camera CreateCamera(float left, float right, float bottom, float top, float near, float far)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static string CreateDebugIdFrom(string renderId, string typeId, string additionalInfo = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected int GetTotalMemorySize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected static string ByteWidthToString(int bytes)
	{
		throw null;
	}
}
