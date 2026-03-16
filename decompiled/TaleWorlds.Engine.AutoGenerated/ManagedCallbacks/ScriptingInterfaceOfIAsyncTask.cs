using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIAsyncTask : IAsyncTask
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateWithDelegateDelegate(int function, [MarshalAs(UnmanagedType.U1)] bool isBackground);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InvokeDelegate(UIntPtr Pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WaitDelegate(UIntPtr Pointer);

	private static readonly Encoding _utf8;

	public static CreateWithDelegateDelegate call_CreateWithDelegateDelegate;

	public static InvokeDelegate call_InvokeDelegate;

	public static WaitDelegate call_WaitDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AsyncTask CreateWithDelegate(ManagedDelegate function, bool isBackground)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(UIntPtr Pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Wait(UIntPtr Pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIAsyncTask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIAsyncTask()
	{
		throw null;
	}
}
