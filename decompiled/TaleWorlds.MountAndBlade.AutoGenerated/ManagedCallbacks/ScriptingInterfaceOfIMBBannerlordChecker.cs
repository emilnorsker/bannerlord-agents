using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBBannerlordChecker : IMBBannerlordChecker
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate IntPtr GetEngineStructMemberOffsetDelegate(byte[] className, byte[] memberName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetEngineStructSizeDelegate(byte[] str);

	private static readonly Encoding _utf8;

	public static GetEngineStructMemberOffsetDelegate call_GetEngineStructMemberOffsetDelegate;

	public static GetEngineStructSizeDelegate call_GetEngineStructSizeDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IntPtr GetEngineStructMemberOffset(string className, string memberName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEngineStructSize(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBBannerlordChecker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBBannerlordChecker()
	{
		throw null;
	}
}
