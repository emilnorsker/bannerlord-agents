using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIThumbnailCreatorView : IThumbnailCreatorView
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CancelRequestDelegate(UIntPtr pointer, byte[] render_id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearRequestsDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateThumbnailCreatorViewDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumberOfPendingRequestsDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsMemoryClearedDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RegisterCachedEntityDelegate(UIntPtr pointer, UIntPtr scene, UIntPtr entity_ptr, byte[] cacheId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RegisterRenderRequestDelegate(UIntPtr pointer, ref ThumbnailRenderRequest request);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RegisterSceneDelegate(UIntPtr pointer, UIntPtr scene_ptr, [MarshalAs(UnmanagedType.U1)] bool use_postfx);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UnregisterCachedEntityDelegate(UIntPtr pointer, byte[] cacheId);

	private static readonly Encoding _utf8;

	public static CancelRequestDelegate call_CancelRequestDelegate;

	public static ClearRequestsDelegate call_ClearRequestsDelegate;

	public static CreateThumbnailCreatorViewDelegate call_CreateThumbnailCreatorViewDelegate;

	public static GetNumberOfPendingRequestsDelegate call_GetNumberOfPendingRequestsDelegate;

	public static IsMemoryClearedDelegate call_IsMemoryClearedDelegate;

	public static RegisterCachedEntityDelegate call_RegisterCachedEntityDelegate;

	public static RegisterRenderRequestDelegate call_RegisterRenderRequestDelegate;

	public static RegisterSceneDelegate call_RegisterSceneDelegate;

	public static UnregisterCachedEntityDelegate call_UnregisterCachedEntityDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CancelRequest(UIntPtr pointer, string render_id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearRequests(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThumbnailCreatorView CreateThumbnailCreatorView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPendingRequests(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMemoryCleared(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterCachedEntity(UIntPtr pointer, UIntPtr scene, UIntPtr entity_ptr, string cacheId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterRenderRequest(UIntPtr pointer, ref ThumbnailRenderRequest request)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterScene(UIntPtr pointer, UIntPtr scene_ptr, bool use_postfx)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterCachedEntity(UIntPtr pointer, string cacheId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIThumbnailCreatorView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIThumbnailCreatorView()
	{
		throw null;
	}
}
