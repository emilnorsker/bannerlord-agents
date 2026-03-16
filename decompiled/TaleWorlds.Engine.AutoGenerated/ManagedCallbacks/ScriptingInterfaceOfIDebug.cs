using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIDebug : IDebug
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AbortGameDelegate(int ExitCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AssertMemoryUsageDelegate(int memoryMB);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearAllDebugRenderObjectsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ContentWarningDelegate(byte[] MessageString);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EchoCommandWindowDelegate(byte[] content);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ErrorDelegate(byte[] MessageString);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool FailedAssertDelegate(byte[] messageString, byte[] callerFile, byte[] callerMethod, int callerLine);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetDebugVectorDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetShowDebugInfoDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsErrorReportModeActiveDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsErrorReportModePauseMissionDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsTestModeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int MessageBoxDelegate(byte[] lpText, byte[] lpCaption, uint uType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PostWarningLineDelegate(byte[] line);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugBoxObjectDelegate(Vec3 min, Vec3 max, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugBoxObjectWithFrameDelegate(Vec3 min, Vec3 max, ref MatrixFrame frame, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugCapsuleDelegate(Vec3 p0, Vec3 p1, float radius, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugDirectionArrowDelegate(Vec3 position, Vec3 direction, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugFrameDelegate(ref MatrixFrame frame, float lineLength, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugLineDelegate(Vec3 position, Vec3 direction, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugRectDelegate(float left, float bottom, float right, float top);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugRectWithColorDelegate(float left, float bottom, float right, float top, uint color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugSphereDelegate(Vec3 position, float radius, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugTextDelegate(float screenX, float screenY, byte[] str, uint color, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugText3dDelegate(Vec3 worldPosition, byte[] str, uint color, int screenPosOffsetX, int screenPosOffsetY, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDebugVectorDelegate(Vec3 debugVector);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDumpGenerationDisabledDelegate([MarshalAs(UnmanagedType.U1)] bool Disabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetErrorReportSceneDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetShowDebugInfoDelegate(int value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SilentAssertDelegate(byte[] messageString, byte[] callerFile, byte[] callerMethod, int callerLine, [MarshalAs(UnmanagedType.U1)] bool getDump);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool WarningDelegate(byte[] MessageString);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteDebugLineOnScreenDelegate(byte[] line);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WriteLineDelegate(int logLevel, byte[] line, int color, ulong filter);

	private static readonly Encoding _utf8;

	public static AbortGameDelegate call_AbortGameDelegate;

	public static AssertMemoryUsageDelegate call_AssertMemoryUsageDelegate;

	public static ClearAllDebugRenderObjectsDelegate call_ClearAllDebugRenderObjectsDelegate;

	public static ContentWarningDelegate call_ContentWarningDelegate;

	public static EchoCommandWindowDelegate call_EchoCommandWindowDelegate;

	public static ErrorDelegate call_ErrorDelegate;

	public static FailedAssertDelegate call_FailedAssertDelegate;

	public static GetDebugVectorDelegate call_GetDebugVectorDelegate;

	public static GetShowDebugInfoDelegate call_GetShowDebugInfoDelegate;

	public static IsErrorReportModeActiveDelegate call_IsErrorReportModeActiveDelegate;

	public static IsErrorReportModePauseMissionDelegate call_IsErrorReportModePauseMissionDelegate;

	public static IsTestModeDelegate call_IsTestModeDelegate;

	public static MessageBoxDelegate call_MessageBoxDelegate;

	public static PostWarningLineDelegate call_PostWarningLineDelegate;

	public static RenderDebugBoxObjectDelegate call_RenderDebugBoxObjectDelegate;

	public static RenderDebugBoxObjectWithFrameDelegate call_RenderDebugBoxObjectWithFrameDelegate;

	public static RenderDebugCapsuleDelegate call_RenderDebugCapsuleDelegate;

	public static RenderDebugDirectionArrowDelegate call_RenderDebugDirectionArrowDelegate;

	public static RenderDebugFrameDelegate call_RenderDebugFrameDelegate;

	public static RenderDebugLineDelegate call_RenderDebugLineDelegate;

	public static RenderDebugRectDelegate call_RenderDebugRectDelegate;

	public static RenderDebugRectWithColorDelegate call_RenderDebugRectWithColorDelegate;

	public static RenderDebugSphereDelegate call_RenderDebugSphereDelegate;

	public static RenderDebugTextDelegate call_RenderDebugTextDelegate;

	public static RenderDebugText3dDelegate call_RenderDebugText3dDelegate;

	public static SetDebugVectorDelegate call_SetDebugVectorDelegate;

	public static SetDumpGenerationDisabledDelegate call_SetDumpGenerationDisabledDelegate;

	public static SetErrorReportSceneDelegate call_SetErrorReportSceneDelegate;

	public static SetShowDebugInfoDelegate call_SetShowDebugInfoDelegate;

	public static SilentAssertDelegate call_SilentAssertDelegate;

	public static WarningDelegate call_WarningDelegate;

	public static WriteDebugLineOnScreenDelegate call_WriteDebugLineOnScreenDelegate;

	public static WriteLineDelegate call_WriteLineDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AbortGame(int ExitCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssertMemoryUsage(int memoryMB)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAllDebugRenderObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContentWarning(string MessageString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EchoCommandWindow(string content)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Error(string MessageString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FailedAssert(string messageString, string callerFile, string callerMethod, int callerLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetDebugVector()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetShowDebugInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsErrorReportModeActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsErrorReportModePauseMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTestMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int MessageBox(string lpText, string lpCaption, uint uType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PostWarningLine(string line)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugBoxObject(Vec3 min, Vec3 max, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugBoxObjectWithFrame(Vec3 min, Vec3 max, ref MatrixFrame frame, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugCapsule(Vec3 p0, Vec3 p1, float radius, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugDirectionArrow(Vec3 position, Vec3 direction, uint color, bool depthCheck)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugFrame(ref MatrixFrame frame, float lineLength, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugLine(Vec3 position, Vec3 direction, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugRect(float left, float bottom, float right, float top)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugRectWithColor(float left, float bottom, float right, float top, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugSphere(Vec3 position, float radius, uint color, bool depthCheck, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugText(float screenX, float screenY, string str, uint color, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugText3d(Vec3 worldPosition, string str, uint color, int screenPosOffsetX, int screenPosOffsetY, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDebugVector(Vec3 debugVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDumpGenerationDisabled(bool Disabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetErrorReportScene(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShowDebugInfo(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SilentAssert(string messageString, string callerFile, string callerMethod, int callerLine, bool getDump)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Warning(string MessageString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteDebugLineOnScreen(string line)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteLine(int logLevel, string line, int color, ulong filter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIDebug()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIDebug()
	{
		throw null;
	}
}
