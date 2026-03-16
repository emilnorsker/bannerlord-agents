using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public sealed class Texture : Resource
{
	public bool IsReleased
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

	public int Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int MemorySize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRenderTarget
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public RenderTargetComponent RenderTargetComponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public TableauView TableauView
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public object UserData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Texture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Texture(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CreateTextureFromPath(PlatformFilePath filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPixelData(byte[] bytes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransformRenderTargetToResource(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture GetFromResource(string resourceName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLoaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSDFBoundingBoxData(ref Vec3 min, ref Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CheckAndGetFromResource(string resourceName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ScaleTextureWithRatio(ref int tableauSizeX, ref int tableauSizeY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadTexture(bool blocking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseImmediately()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseAfterNumberOfFrames(int frameCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture LoadTextureFromPath(string fileName, string folder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CreateDepthTarget(string name, int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CreateFromByteArray(byte[] data, int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveToFile(string path, bool isRelativePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTextureAsAlwaysValid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CreateFromMemory(byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReleaseGpuMemories()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTableauView(TableauView tableauView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CreateTableauTexture(string name, RenderTargetComponent.TextureUpdateEventHandler eventHandler, object objectRef, int tableauSizeX, int tableauSizeY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Texture CreateRenderTarget(string name, int width, int height, bool autoMipmaps, bool isTableau, bool createUninitialized = false, bool always_valid = false)
	{
		throw null;
	}
}
