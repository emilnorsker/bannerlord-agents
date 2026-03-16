using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIView : IView
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAutoDepthTargetCreationDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClearColorDelegate(UIntPtr ptr, uint rgba);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDebugRenderFunctionalityDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDepthTargetDelegate(UIntPtr ptr, UIntPtr texture_ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEnableDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFileNameToSaveResultDelegate(UIntPtr ptr, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFilePathToSaveResultDelegate(UIntPtr ptr, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFileTypeToSaveDelegate(UIntPtr ptr, int type);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetOffsetDelegate(UIntPtr ptr, float x, float y);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderOnDemandDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderOptionDelegate(UIntPtr ptr, int optionEnum, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderOrderDelegate(UIntPtr ptr, int value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderTargetDelegate(UIntPtr ptr, UIntPtr texture_ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSaveFinalResultToDiskDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetScaleDelegate(UIntPtr ptr, float x, float y);

	private static readonly Encoding _utf8;

	public static SetAutoDepthTargetCreationDelegate call_SetAutoDepthTargetCreationDelegate;

	public static SetClearColorDelegate call_SetClearColorDelegate;

	public static SetDebugRenderFunctionalityDelegate call_SetDebugRenderFunctionalityDelegate;

	public static SetDepthTargetDelegate call_SetDepthTargetDelegate;

	public static SetEnableDelegate call_SetEnableDelegate;

	public static SetFileNameToSaveResultDelegate call_SetFileNameToSaveResultDelegate;

	public static SetFilePathToSaveResultDelegate call_SetFilePathToSaveResultDelegate;

	public static SetFileTypeToSaveDelegate call_SetFileTypeToSaveDelegate;

	public static SetOffsetDelegate call_SetOffsetDelegate;

	public static SetRenderOnDemandDelegate call_SetRenderOnDemandDelegate;

	public static SetRenderOptionDelegate call_SetRenderOptionDelegate;

	public static SetRenderOrderDelegate call_SetRenderOrderDelegate;

	public static SetRenderTargetDelegate call_SetRenderTargetDelegate;

	public static SetSaveFinalResultToDiskDelegate call_SetSaveFinalResultToDiskDelegate;

	public static SetScaleDelegate call_SetScaleDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAutoDepthTargetCreation(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClearColor(UIntPtr ptr, uint rgba)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDebugRenderFunctionality(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDepthTarget(UIntPtr ptr, UIntPtr texture_ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnable(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFileNameToSaveResult(UIntPtr ptr, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFilePathToSaveResult(UIntPtr ptr, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFileTypeToSave(UIntPtr ptr, int type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOffset(UIntPtr ptr, float x, float y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderOnDemand(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderOption(UIntPtr ptr, int optionEnum, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderOrder(UIntPtr ptr, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderTarget(UIntPtr ptr, UIntPtr texture_ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSaveFinalResultToDisk(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScale(UIntPtr ptr, float x, float y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIView()
	{
		throw null;
	}
}
