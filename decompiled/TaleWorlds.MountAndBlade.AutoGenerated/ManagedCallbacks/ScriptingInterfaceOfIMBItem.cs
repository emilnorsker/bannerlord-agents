using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBItem : IMBItem
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetHolsterFrameByIndexDelegate(int index, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetItemHolsterIndexDelegate(byte[] itemholstername);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetItemIsPassiveUsageDelegate(byte[] itemUsageName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetItemUsageIndexDelegate(byte[] itemusagename);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetItemUsageReloadActionCodeDelegate(byte[] itemUsageName, int usageDirection, [MarshalAs(UnmanagedType.U1)] bool isMounted, int leftHandUsageSetIndex, [MarshalAs(UnmanagedType.U1)] bool isLeftStance, [MarshalAs(UnmanagedType.U1)] bool isLowLookDirection);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetItemUsageSetFlagsDelegate(byte[] ItemUsageName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetItemUsageStrikeTypeDelegate(byte[] itemUsageName, int usageDirection, [MarshalAs(UnmanagedType.U1)] bool isMounted, int leftHandUsageSetIndex, [MarshalAs(UnmanagedType.U1)] bool isLeftStance, [MarshalAs(UnmanagedType.U1)] bool isLowLookDirection);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetMissileRangeDelegate(float shootSpeed, float zDiff);

	private static readonly Encoding _utf8;

	public static GetHolsterFrameByIndexDelegate call_GetHolsterFrameByIndexDelegate;

	public static GetItemHolsterIndexDelegate call_GetItemHolsterIndexDelegate;

	public static GetItemIsPassiveUsageDelegate call_GetItemIsPassiveUsageDelegate;

	public static GetItemUsageIndexDelegate call_GetItemUsageIndexDelegate;

	public static GetItemUsageReloadActionCodeDelegate call_GetItemUsageReloadActionCodeDelegate;

	public static GetItemUsageSetFlagsDelegate call_GetItemUsageSetFlagsDelegate;

	public static GetItemUsageStrikeTypeDelegate call_GetItemUsageStrikeTypeDelegate;

	public static GetMissileRangeDelegate call_GetMissileRangeDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetHolsterFrameByIndex(int index, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemHolsterIndex(string itemholstername)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetItemIsPassiveUsage(string itemUsageName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemUsageIndex(string itemusagename)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemUsageReloadActionCode(string itemUsageName, int usageDirection, bool isMounted, int leftHandUsageSetIndex, bool isLeftStance, bool isLowLookDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemUsageSetFlags(string ItemUsageName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetItemUsageStrikeType(string itemUsageName, int usageDirection, bool isMounted, int leftHandUsageSetIndex, bool isLeftStance, bool isLowLookDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMissileRange(float shootSpeed, float zDiff)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBItem()
	{
		throw null;
	}
}
