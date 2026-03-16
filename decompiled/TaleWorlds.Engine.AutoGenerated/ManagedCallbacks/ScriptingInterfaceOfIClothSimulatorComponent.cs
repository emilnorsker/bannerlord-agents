using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIClothSimulatorComponent : IClothSimulatorComponent
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableForcedWindDelegate(UIntPtr cloth_pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableMorphAnimationDelegate(UIntPtr cloth_pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetMorphAnimCenterPointsDelegate(UIntPtr cloth_pointer, IntPtr leftPoints);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetMorphAnimLeftPointsDelegate(UIntPtr cloth_pointer, IntPtr leftPoints);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetMorphAnimRightPointsDelegate(UIntPtr cloth_pointer, IntPtr rightPoints);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumberOfMorphKeysDelegate(UIntPtr cloth_pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForcedGustStrengthDelegate(UIntPtr cloth_pointer, float gustStrength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForcedVelocityDelegate(UIntPtr cloth_pointer, in Vec3 velocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForcedWindDelegate(UIntPtr cloth_pointer, Vec3 windVector, [MarshalAs(UnmanagedType.U1)] bool isLocal);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMaxDistanceMultiplierDelegate(UIntPtr cloth_pointer, float multiplier);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMorphAnimationDelegate(UIntPtr cloth_pointer, float morphKey);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetResetRequiredDelegate(UIntPtr cloth_pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVectorArgumentDelegate(UIntPtr cloth_pointer, float x, float y, float z, float w);

	private static readonly Encoding _utf8;

	public static DisableForcedWindDelegate call_DisableForcedWindDelegate;

	public static DisableMorphAnimationDelegate call_DisableMorphAnimationDelegate;

	public static GetMorphAnimCenterPointsDelegate call_GetMorphAnimCenterPointsDelegate;

	public static GetMorphAnimLeftPointsDelegate call_GetMorphAnimLeftPointsDelegate;

	public static GetMorphAnimRightPointsDelegate call_GetMorphAnimRightPointsDelegate;

	public static GetNumberOfMorphKeysDelegate call_GetNumberOfMorphKeysDelegate;

	public static SetForcedGustStrengthDelegate call_SetForcedGustStrengthDelegate;

	public static SetForcedVelocityDelegate call_SetForcedVelocityDelegate;

	public static SetForcedWindDelegate call_SetForcedWindDelegate;

	public static SetMaxDistanceMultiplierDelegate call_SetMaxDistanceMultiplierDelegate;

	public static SetMorphAnimationDelegate call_SetMorphAnimationDelegate;

	public static SetResetRequiredDelegate call_SetResetRequiredDelegate;

	public static SetVectorArgumentDelegate call_SetVectorArgumentDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableForcedWind(UIntPtr cloth_pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableMorphAnimation(UIntPtr cloth_pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMorphAnimCenterPoints(UIntPtr cloth_pointer, Vec3[] leftPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMorphAnimLeftPoints(UIntPtr cloth_pointer, Vec3[] leftPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMorphAnimRightPoints(UIntPtr cloth_pointer, Vec3[] rightPoints)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfMorphKeys(UIntPtr cloth_pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForcedGustStrength(UIntPtr cloth_pointer, float gustStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForcedVelocity(UIntPtr cloth_pointer, in Vec3 velocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForcedWind(UIntPtr cloth_pointer, Vec3 windVector, bool isLocal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaxDistanceMultiplier(UIntPtr cloth_pointer, float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMorphAnimation(UIntPtr cloth_pointer, float morphKey)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetResetRequired(UIntPtr cloth_pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument(UIntPtr cloth_pointer, float x, float y, float z, float w)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIClothSimulatorComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIClothSimulatorComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClothSimulatorComponent.SetForcedVelocity(UIntPtr cloth_pointer, in Vec3 velocity)
	{
		throw null;
	}
}
