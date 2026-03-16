using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIShader : IShader
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFromResourceDelegate(byte[] shaderName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate ulong GetMaterialShaderFlagMaskDelegate(UIntPtr shaderPointer, byte[] flagName, [MarshalAs(UnmanagedType.U1)] bool showError);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr shaderPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseDelegate(UIntPtr shaderPointer);

	private static readonly Encoding _utf8;

	public static GetFromResourceDelegate call_GetFromResourceDelegate;

	public static GetMaterialShaderFlagMaskDelegate call_GetMaterialShaderFlagMaskDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static ReleaseDelegate call_ReleaseDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Shader GetFromResource(string shaderName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetMaterialShaderFlagMask(UIntPtr shaderPointer, string flagName, bool showError)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr shaderPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release(UIntPtr shaderPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIShader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIShader()
	{
		throw null;
	}
}
