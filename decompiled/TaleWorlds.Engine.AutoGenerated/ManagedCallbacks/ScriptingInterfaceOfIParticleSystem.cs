using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIParticleSystem : IParticleSystem
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateParticleSystemAttachedToBoneDelegate(int runtimeId, UIntPtr skeletonPtr, sbyte boneIndex, ref MatrixFrame boneLocalFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateParticleSystemAttachedToEntityDelegate(int runtimeId, UIntPtr entityPtr, ref MatrixFrame boneLocalFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetLocalFrameDelegate(UIntPtr pointer, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetRuntimeIdByNameDelegate(byte[] particleSystemName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasAliveParticlesDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RestartDelegate(UIntPtr psysPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDontRemoveFromEntityDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEnableDelegate(UIntPtr psysPointer, [MarshalAs(UnmanagedType.U1)] bool enable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLocalFrameDelegate(UIntPtr pointer, in MatrixFrame newFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetParticleEffectByNameDelegate(UIntPtr pointer, byte[] effectName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPreviousGlobalFrameDelegate(UIntPtr pointer, in MatrixFrame newFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRuntimeEmissionRateMultiplierDelegate(UIntPtr pointer, float multiplier);

	private static readonly Encoding _utf8;

	public static CreateParticleSystemAttachedToBoneDelegate call_CreateParticleSystemAttachedToBoneDelegate;

	public static CreateParticleSystemAttachedToEntityDelegate call_CreateParticleSystemAttachedToEntityDelegate;

	public static GetLocalFrameDelegate call_GetLocalFrameDelegate;

	public static GetRuntimeIdByNameDelegate call_GetRuntimeIdByNameDelegate;

	public static HasAliveParticlesDelegate call_HasAliveParticlesDelegate;

	public static RestartDelegate call_RestartDelegate;

	public static SetDontRemoveFromEntityDelegate call_SetDontRemoveFromEntityDelegate;

	public static SetEnableDelegate call_SetEnableDelegate;

	public static SetLocalFrameDelegate call_SetLocalFrameDelegate;

	public static SetParticleEffectByNameDelegate call_SetParticleEffectByNameDelegate;

	public static SetPreviousGlobalFrameDelegate call_SetPreviousGlobalFrameDelegate;

	public static SetRuntimeEmissionRateMultiplierDelegate call_SetRuntimeEmissionRateMultiplierDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParticleSystem CreateParticleSystemAttachedToBone(int runtimeId, UIntPtr skeletonPtr, sbyte boneIndex, ref MatrixFrame boneLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParticleSystem CreateParticleSystemAttachedToEntity(int runtimeId, UIntPtr entityPtr, ref MatrixFrame boneLocalFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetLocalFrame(UIntPtr pointer, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRuntimeIdByName(string particleSystemName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAliveParticles(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Restart(UIntPtr psysPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDontRemoveFromEntity(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnable(UIntPtr psysPointer, bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLocalFrame(UIntPtr pointer, in MatrixFrame newFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetParticleEffectByName(UIntPtr pointer, string effectName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPreviousGlobalFrame(UIntPtr pointer, in MatrixFrame newFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRuntimeEmissionRateMultiplier(UIntPtr pointer, float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIParticleSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIParticleSystem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IParticleSystem.SetLocalFrame(UIntPtr pointer, in MatrixFrame newFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IParticleSystem.SetPreviousGlobalFrame(UIntPtr pointer, in MatrixFrame newFrame)
	{
		throw null;
	}
}
