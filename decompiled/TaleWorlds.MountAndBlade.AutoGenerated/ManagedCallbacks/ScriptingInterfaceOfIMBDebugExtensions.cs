using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBDebugExtensions : IMBDebugExtensions
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OverrideNativeParameterDelegate(byte[] paramName, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReloadNativeParametersDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugArcOnTerrainDelegate(UIntPtr scenePointer, ref MatrixFrame frame, float radius, float beginAngle, float endAngle, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, [MarshalAs(UnmanagedType.U1)] bool isDotted);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugCircleOnTerrainDelegate(UIntPtr scenePointer, ref MatrixFrame frame, float radius, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, [MarshalAs(UnmanagedType.U1)] bool isDotted);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderDebugLineOnTerrainDelegate(UIntPtr scenePointer, Vec3 position, Vec3 direction, uint color, [MarshalAs(UnmanagedType.U1)] bool depthCheck, float time, [MarshalAs(UnmanagedType.U1)] bool isDotted, float pointDensity);

	private static readonly Encoding _utf8;

	public static OverrideNativeParameterDelegate call_OverrideNativeParameterDelegate;

	public static ReloadNativeParametersDelegate call_ReloadNativeParametersDelegate;

	public static RenderDebugArcOnTerrainDelegate call_RenderDebugArcOnTerrainDelegate;

	public static RenderDebugCircleOnTerrainDelegate call_RenderDebugCircleOnTerrainDelegate;

	public static RenderDebugLineOnTerrainDelegate call_RenderDebugLineOnTerrainDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OverrideNativeParameter(string paramName, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReloadNativeParameters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugArcOnTerrain(UIntPtr scenePointer, ref MatrixFrame frame, float radius, float beginAngle, float endAngle, uint color, bool depthCheck, bool isDotted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugCircleOnTerrain(UIntPtr scenePointer, ref MatrixFrame frame, float radius, uint color, bool depthCheck, bool isDotted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderDebugLineOnTerrain(UIntPtr scenePointer, Vec3 position, Vec3 direction, uint color, bool depthCheck, float time, bool isDotted, float pointDensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBDebugExtensions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBDebugExtensions()
	{
		throw null;
	}
}
