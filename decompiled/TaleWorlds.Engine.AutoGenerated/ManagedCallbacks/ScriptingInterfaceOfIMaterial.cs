using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMaterial : IMaterial
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMaterialShaderFlagDelegate(UIntPtr materialPointer, byte[] flagName, [MarshalAs(UnmanagedType.U1)] bool showErrors);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateCopyDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAlphaBlendModeDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAlphaTestValueDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetDefaultMaterialDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate MaterialFlags GetFlagsDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFromResourceDelegate(byte[] materialName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetOutlineMaterialDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetShaderDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate ulong GetShaderFlagsDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetTextureDelegate(UIntPtr materialPointer, int textureType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseDelegate(UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveMaterialShaderFlagDelegate(UIntPtr materialPointer, byte[] flagName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAlphaBlendModeDelegate(UIntPtr materialPointer, int alphaBlendMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAlphaTestValueDelegate(UIntPtr materialPointer, float alphaTestValue);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAreaMapScaleDelegate(UIntPtr materialPointer, float scale);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEnableSkinningDelegate(UIntPtr materialPointer, [MarshalAs(UnmanagedType.U1)] bool enable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFlagsDelegate(UIntPtr materialPointer, MaterialFlags flags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMeshVectorArgumentDelegate(UIntPtr materialPointer, float x, float y, float z, float w);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNameDelegate(UIntPtr materialPointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetShaderDelegate(UIntPtr materialPointer, UIntPtr shaderPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetShaderFlagsDelegate(UIntPtr materialPointer, ulong shaderFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTextureDelegate(UIntPtr materialPointer, int textureType, UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTextureAtSlotDelegate(UIntPtr materialPointer, int textureSlotIndex, UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool UsingSkinningDelegate(UIntPtr materialPointer);

	private static readonly Encoding _utf8;

	public static AddMaterialShaderFlagDelegate call_AddMaterialShaderFlagDelegate;

	public static CreateCopyDelegate call_CreateCopyDelegate;

	public static GetAlphaBlendModeDelegate call_GetAlphaBlendModeDelegate;

	public static GetAlphaTestValueDelegate call_GetAlphaTestValueDelegate;

	public static GetDefaultMaterialDelegate call_GetDefaultMaterialDelegate;

	public static GetFlagsDelegate call_GetFlagsDelegate;

	public static GetFromResourceDelegate call_GetFromResourceDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetOutlineMaterialDelegate call_GetOutlineMaterialDelegate;

	public static GetShaderDelegate call_GetShaderDelegate;

	public static GetShaderFlagsDelegate call_GetShaderFlagsDelegate;

	public static GetTextureDelegate call_GetTextureDelegate;

	public static ReleaseDelegate call_ReleaseDelegate;

	public static RemoveMaterialShaderFlagDelegate call_RemoveMaterialShaderFlagDelegate;

	public static SetAlphaBlendModeDelegate call_SetAlphaBlendModeDelegate;

	public static SetAlphaTestValueDelegate call_SetAlphaTestValueDelegate;

	public static SetAreaMapScaleDelegate call_SetAreaMapScaleDelegate;

	public static SetEnableSkinningDelegate call_SetEnableSkinningDelegate;

	public static SetFlagsDelegate call_SetFlagsDelegate;

	public static SetMeshVectorArgumentDelegate call_SetMeshVectorArgumentDelegate;

	public static SetNameDelegate call_SetNameDelegate;

	public static SetShaderDelegate call_SetShaderDelegate;

	public static SetShaderFlagsDelegate call_SetShaderFlagsDelegate;

	public static SetTextureDelegate call_SetTextureDelegate;

	public static SetTextureAtSlotDelegate call_SetTextureAtSlotDelegate;

	public static UsingSkinningDelegate call_UsingSkinningDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMaterialShaderFlag(UIntPtr materialPointer, string flagName, bool showErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material CreateCopy(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAlphaBlendMode(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAlphaTestValue(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material GetDefaultMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MaterialFlags GetFlags(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material GetFromResource(string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material GetOutlineMaterial(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Shader GetShader(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetShaderFlags(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTexture(UIntPtr materialPointer, int textureType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMaterialShaderFlag(UIntPtr materialPointer, string flagName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlphaBlendMode(UIntPtr materialPointer, int alphaBlendMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlphaTestValue(UIntPtr materialPointer, float alphaTestValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAreaMapScale(UIntPtr materialPointer, float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnableSkinning(UIntPtr materialPointer, bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFlags(UIntPtr materialPointer, MaterialFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMeshVectorArgument(UIntPtr materialPointer, float x, float y, float z, float w)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetName(UIntPtr materialPointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShader(UIntPtr materialPointer, UIntPtr shaderPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShaderFlags(UIntPtr materialPointer, ulong shaderFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTexture(UIntPtr materialPointer, int textureType, UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTextureAtSlot(UIntPtr materialPointer, int textureSlotIndex, UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UsingSkinning(UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMaterial()
	{
		throw null;
	}
}
