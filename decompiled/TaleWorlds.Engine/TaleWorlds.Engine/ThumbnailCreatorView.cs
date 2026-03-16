using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglThumbnail_creator_view")]
public sealed class ThumbnailCreatorView : View
{
	public delegate void OnThumbnailRenderCompleteDelegate(string renderId, Texture renderTarget);

	public static OnThumbnailRenderCompleteDelegate renderCallback;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ThumbnailCreatorView(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[EngineCallback(null, false)]
	internal static void OnThumbnailRenderComplete(string renderId, Texture renderTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ThumbnailCreatorView CreateThumbnailCreatorView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterScene(Scene scene, bool usePostFx = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterCachedEntity(Scene scene, GameEntity entity, string cacheId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterCachedEntity(string cacheId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterRenderRequest(ref ThumbnailRenderRequest request)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CancelRequest(string renderID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPendingRequests()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMemoryCleared()
	{
		throw null;
	}
}
