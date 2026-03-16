using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfITelemetry : ITelemetry
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BeginTelemetryScopeDelegate(TelemetryLevelMask levelMask, byte[] scopeName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EndTelemetryScopeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate TelemetryLevelMask GetTelemetryLevelMaskDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasTelemetryConnectionDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StartTelemetryConnectionDelegate([MarshalAs(UnmanagedType.U1)] bool showErrors);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StopTelemetryConnectionDelegate();

	private static readonly Encoding _utf8;

	public static BeginTelemetryScopeDelegate call_BeginTelemetryScopeDelegate;

	public static EndTelemetryScopeDelegate call_EndTelemetryScopeDelegate;

	public static GetTelemetryLevelMaskDelegate call_GetTelemetryLevelMaskDelegate;

	public static HasTelemetryConnectionDelegate call_HasTelemetryConnectionDelegate;

	public static StartTelemetryConnectionDelegate call_StartTelemetryConnectionDelegate;

	public static StopTelemetryConnectionDelegate call_StopTelemetryConnectionDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginTelemetryScope(TelemetryLevelMask levelMask, string scopeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndTelemetryScope()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TelemetryLevelMask GetTelemetryLevelMask()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasTelemetryConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartTelemetryConnection(bool showErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopTelemetryConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfITelemetry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfITelemetry()
	{
		throw null;
	}
}
