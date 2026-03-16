using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMouseManager : IMouseManager
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ActivateMouseCursorDelegate(int id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LockCursorAtCurrentPositionDelegate([MarshalAs(UnmanagedType.U1)] bool lockCursor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LockCursorAtPositionDelegate(float x, float y);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMouseCursorDelegate(int id, byte[] mousePath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ShowCursorDelegate([MarshalAs(UnmanagedType.U1)] bool show);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UnlockCursorDelegate();

	private static readonly Encoding _utf8;

	public static ActivateMouseCursorDelegate call_ActivateMouseCursorDelegate;

	public static LockCursorAtCurrentPositionDelegate call_LockCursorAtCurrentPositionDelegate;

	public static LockCursorAtPositionDelegate call_LockCursorAtPositionDelegate;

	public static SetMouseCursorDelegate call_SetMouseCursorDelegate;

	public static ShowCursorDelegate call_ShowCursorDelegate;

	public static UnlockCursorDelegate call_UnlockCursorDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateMouseCursor(int id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LockCursorAtCurrentPosition(bool lockCursor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LockCursorAtPosition(float x, float y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMouseCursor(int id, string mousePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ShowCursor(bool show)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnlockCursor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMouseManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMouseManager()
	{
		throw null;
	}
}
