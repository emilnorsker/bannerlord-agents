using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIHighlights : IHighlights
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddHighlightDelegate(byte[] id, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CloseGroupDelegate(byte[] id, [MarshalAs(UnmanagedType.U1)] bool destroy);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitializeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OpenGroupDelegate(byte[] id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OpenSummaryDelegate(byte[] groups);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveHighlightDelegate(byte[] id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SaveScreenshotDelegate(byte[] highlightId, byte[] groupId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SaveVideoDelegate(byte[] highlightId, byte[] groupId, int startDelta, int endDelta);

	private static readonly Encoding _utf8;

	public static AddHighlightDelegate call_AddHighlightDelegate;

	public static CloseGroupDelegate call_CloseGroupDelegate;

	public static InitializeDelegate call_InitializeDelegate;

	public static OpenGroupDelegate call_OpenGroupDelegate;

	public static OpenSummaryDelegate call_OpenSummaryDelegate;

	public static RemoveHighlightDelegate call_RemoveHighlightDelegate;

	public static SaveScreenshotDelegate call_SaveScreenshotDelegate;

	public static SaveVideoDelegate call_SaveVideoDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddHighlight(string id, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseGroup(string id, bool destroy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenGroup(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenSummary(string groups)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveHighlight(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveScreenshot(string highlightId, string groupId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveVideo(string highlightId, string groupId, int startDelta, int endDelta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIHighlights()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIHighlights()
	{
		throw null;
	}
}
