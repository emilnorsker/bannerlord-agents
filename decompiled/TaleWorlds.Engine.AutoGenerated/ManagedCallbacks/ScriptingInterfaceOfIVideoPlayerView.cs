using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIVideoPlayerView : IVideoPlayerView
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateVideoPlayerViewDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FinalizeDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsVideoFinishedDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PlayVideoDelegate(UIntPtr pointer, byte[] videoFileName, byte[] soundFileName, float framerate, [MarshalAs(UnmanagedType.U1)] bool looping);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StopVideoDelegate(UIntPtr pointer);

	private static readonly Encoding _utf8;

	public static CreateVideoPlayerViewDelegate call_CreateVideoPlayerViewDelegate;

	public static FinalizeDelegate call_FinalizeDelegate;

	public static IsVideoFinishedDelegate call_IsVideoFinishedDelegate;

	public static PlayVideoDelegate call_PlayVideoDelegate;

	public static StopVideoDelegate call_StopVideoDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VideoPlayerView CreateVideoPlayerView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Finalize(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsVideoFinished(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PlayVideo(UIntPtr pointer, string videoFileName, string soundFileName, float framerate, bool looping)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopVideo(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIVideoPlayerView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIVideoPlayerView()
	{
		throw null;
	}
}
