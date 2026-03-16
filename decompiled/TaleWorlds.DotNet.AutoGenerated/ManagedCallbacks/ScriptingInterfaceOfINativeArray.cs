using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfINativeArray : INativeArray
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddElementDelegate(UIntPtr pointer, IntPtr element, int elementSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddFloatElementDelegate(UIntPtr pointer, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddIntegerElementDelegate(UIntPtr pointer, int value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetDataPointerDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetDataPointerOffsetDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetDataSizeDelegate(UIntPtr pointer);

	private static readonly Encoding _utf8;

	public static AddElementDelegate call_AddElementDelegate;

	public static AddFloatElementDelegate call_AddFloatElementDelegate;

	public static AddIntegerElementDelegate call_AddIntegerElementDelegate;

	public static ClearDelegate call_ClearDelegate;

	public static CreateDelegate call_CreateDelegate;

	public static GetDataPointerDelegate call_GetDataPointerDelegate;

	public static GetDataPointerOffsetDelegate call_GetDataPointerOffsetDelegate;

	public static GetDataSizeDelegate call_GetDataSizeDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddElement(UIntPtr pointer, IntPtr element, int elementSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddFloatElement(UIntPtr pointer, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddIntegerElement(UIntPtr pointer, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeArray Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetDataPointer(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDataPointerOffset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDataSize(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfINativeArray()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfINativeArray()
	{
		throw null;
	}
}
