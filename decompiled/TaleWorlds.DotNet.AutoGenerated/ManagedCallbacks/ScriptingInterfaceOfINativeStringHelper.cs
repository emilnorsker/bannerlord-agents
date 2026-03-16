using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfINativeStringHelper : INativeStringHelper
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr CreateRglVarStringDelegate(byte[] text);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeleteRglVarStringDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetThreadLocalCachedRglVarStringDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRglVarStringDelegate(UIntPtr pointer, byte[] text);

	private static readonly Encoding _utf8;

	public static CreateRglVarStringDelegate call_CreateRglVarStringDelegate;

	public static DeleteRglVarStringDelegate call_DeleteRglVarStringDelegate;

	public static GetThreadLocalCachedRglVarStringDelegate call_GetThreadLocalCachedRglVarStringDelegate;

	public static SetRglVarStringDelegate call_SetRglVarStringDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr CreateRglVarString(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteRglVarString(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetThreadLocalCachedRglVarString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRglVarString(UIntPtr pointer, string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfINativeStringHelper()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfINativeStringHelper()
	{
		throw null;
	}
}
