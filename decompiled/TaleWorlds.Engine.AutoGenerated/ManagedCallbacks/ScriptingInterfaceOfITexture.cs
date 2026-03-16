using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfITexture : ITexture
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CheckAndGetFromResourceDelegate(byte[] textureName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateDepthTargetDelegate(byte[] name, int width, int height);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateFromByteArrayDelegate(ManagedArray data, int width, int height);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateFromMemoryDelegate(ManagedArray data);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateRenderTargetDelegate(byte[] name, int width, int height, [MarshalAs(UnmanagedType.U1)] bool autoMipmaps, [MarshalAs(UnmanagedType.U1)] bool isTableau, [MarshalAs(UnmanagedType.U1)] bool createUninitialized, [MarshalAs(UnmanagedType.U1)] bool always_valid);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateTextureFromPathDelegate(PlatformFilePath filePath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetCurObjectDelegate(UIntPtr texturePointer, [MarshalAs(UnmanagedType.U1)] bool blocking);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFromResourceDelegate(byte[] textureName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetHeightDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMemorySizeDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetPixelDataDelegate(UIntPtr texturePointer, ManagedArray bytes);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetRenderTargetComponentDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetSDFBoundingBoxDataDelegate(UIntPtr texturePointer, ref Vec3 min, ref Vec3 max);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetTableauViewDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetWidthDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsLoadedDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsRenderTargetDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer LoadTextureFromPathDelegate(byte[] fileName, byte[] folder);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseAfterNumberOfFramesDelegate(UIntPtr texturePointer, int numberOfFrames);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseGpuMemoriesDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseNextFrameDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveContinousTableauTextureDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SaveTextureAsAlwaysValidDelegate(UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SaveToFileDelegate(UIntPtr texturePointer, byte[] fileName, [MarshalAs(UnmanagedType.U1)] bool isRelativePath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNameDelegate(UIntPtr texturePointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTableauViewDelegate(UIntPtr texturePointer, UIntPtr tableauView);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TransformRenderTargetToResourceTextureDelegate(UIntPtr texturePointer, byte[] name);

	private static readonly Encoding _utf8;

	public static CheckAndGetFromResourceDelegate call_CheckAndGetFromResourceDelegate;

	public static CreateDepthTargetDelegate call_CreateDepthTargetDelegate;

	public static CreateFromByteArrayDelegate call_CreateFromByteArrayDelegate;

	public static CreateFromMemoryDelegate call_CreateFromMemoryDelegate;

	public static CreateRenderTargetDelegate call_CreateRenderTargetDelegate;

	public static CreateTextureFromPathDelegate call_CreateTextureFromPathDelegate;

	public static GetCurObjectDelegate call_GetCurObjectDelegate;

	public static GetFromResourceDelegate call_GetFromResourceDelegate;

	public static GetHeightDelegate call_GetHeightDelegate;

	public static GetMemorySizeDelegate call_GetMemorySizeDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetPixelDataDelegate call_GetPixelDataDelegate;

	public static GetRenderTargetComponentDelegate call_GetRenderTargetComponentDelegate;

	public static GetSDFBoundingBoxDataDelegate call_GetSDFBoundingBoxDataDelegate;

	public static GetTableauViewDelegate call_GetTableauViewDelegate;

	public static GetWidthDelegate call_GetWidthDelegate;

	public static IsLoadedDelegate call_IsLoadedDelegate;

	public static IsRenderTargetDelegate call_IsRenderTargetDelegate;

	public static LoadTextureFromPathDelegate call_LoadTextureFromPathDelegate;

	public static ReleaseDelegate call_ReleaseDelegate;

	public static ReleaseAfterNumberOfFramesDelegate call_ReleaseAfterNumberOfFramesDelegate;

	public static ReleaseGpuMemoriesDelegate call_ReleaseGpuMemoriesDelegate;

	public static ReleaseNextFrameDelegate call_ReleaseNextFrameDelegate;

	public static RemoveContinousTableauTextureDelegate call_RemoveContinousTableauTextureDelegate;

	public static SaveTextureAsAlwaysValidDelegate call_SaveTextureAsAlwaysValidDelegate;

	public static SaveToFileDelegate call_SaveToFileDelegate;

	public static SetNameDelegate call_SetNameDelegate;

	public static SetTableauViewDelegate call_SetTableauViewDelegate;

	public static TransformRenderTargetToResourceTextureDelegate call_TransformRenderTargetToResourceTextureDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture CheckAndGetFromResource(string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture CreateDepthTarget(string name, int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture CreateFromByteArray(byte[] data, int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture CreateFromMemory(byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture CreateRenderTarget(string name, int width, int height, bool autoMipmaps, bool isTableau, bool createUninitialized, bool always_valid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture CreateTextureFromPath(PlatformFilePath filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCurObject(UIntPtr texturePointer, bool blocking)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetFromResource(string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHeight(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMemorySize(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPixelData(UIntPtr texturePointer, byte[] bytes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RenderTargetComponent GetRenderTargetComponent(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSDFBoundingBoxData(UIntPtr texturePointer, ref Vec3 min, ref Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TableauView GetTableauView(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetWidth(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLoaded(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsRenderTarget(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture LoadTextureFromPath(string fileName, string folder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseAfterNumberOfFrames(UIntPtr texturePointer, int numberOfFrames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseGpuMemories()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseNextFrame(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveContinousTableauTexture(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveTextureAsAlwaysValid(UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveToFile(UIntPtr texturePointer, string fileName, bool isRelativePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetName(UIntPtr texturePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTableauView(UIntPtr texturePointer, UIntPtr tableauView)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransformRenderTargetToResourceTexture(UIntPtr texturePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfITexture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfITexture()
	{
		throw null;
	}
}
