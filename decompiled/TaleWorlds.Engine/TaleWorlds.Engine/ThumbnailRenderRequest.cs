using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineStruct("rglThumbnail_render_request", false, null)]
public struct ThumbnailRenderRequest
{
	public UIntPtr ScenePointer;

	public UIntPtr CameraPointer;

	public UIntPtr TexturePointer;

	public string CachedEntityId;

	public UIntPtr EntityPointer;

	public int Width;

	public int Height;

	public string RenderId;

	public string DebugName;

	public int AllocationGroupIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ThumbnailRenderRequest CreateWithTexture(Scene scene, Camera camera, Texture texture, GameEntity entity, string renderId, string debugName, int allocationGroupIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ThumbnailRenderRequest CreateWithoutTexture(Scene scene, Camera camera, GameEntity entity, string renderId, int width, int height, string debugName, int allocationGroupIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ThumbnailRenderRequest CreateForCachedEntity(Scene scene, Camera camera, Texture texture, string cachedEntityId, string renderId, string debugName, int allocationGroupIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ThumbnailRenderRequest CreateForCachedEntityWithoutTexture(Scene scene, Camera camera, string cachedEntityId, string renderId, int width, int height, string debugName, int allocationGroupIndex)
	{
		throw null;
	}
}
