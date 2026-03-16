using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBSkeletonExtensions : IMBSkeletonExtensions
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateAgentSkeletonDelegate(byte[] skeletonName, [MarshalAs(UnmanagedType.U1)] bool isHumanoid, int actionSetIndex, byte[] monsterUsageSetName, ref AnimationSystemData animationSystemData);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateSimpleSkeletonDelegate(byte[] skeletonName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateWithActionSetDelegate(ref AnimationSystemData animationSystemData);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool DoesActionContinueWithCurrentActionAtChannelDelegate(UIntPtr skeletonPointer, int actionChannelNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetActionAtChannelDelegate(UIntPtr skeletonPointer, int channelNo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameDelegate(UIntPtr skeletonPointer, sbyte bone, [MarshalAs(UnmanagedType.U1)] bool useBoneMapping, [MarshalAs(UnmanagedType.U1)] bool forceToUpdate, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameAtAnimationProgressDelegate(UIntPtr skeletonPointer, sbyte boneIndex, int animationIndex, float progress, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSkeletonFaceAnimationNameDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetSkeletonFaceAnimationTimeDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAgentActionChannelDelegate(UIntPtr skeletonPointer, int actionChannelNo, int actionIndex, float channelParameter, float blendPeriodOverride, [MarshalAs(UnmanagedType.U1)] bool forceFaceMorphRestart, float blendWithNextActionFactor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAnimationAtChannelDelegate(UIntPtr skeletonPointer, int animationIndex, int channelNo, float animationSpeedMultiplier, float blendInPeriod, float startProgress);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFacialAnimationOfChannelDelegate(UIntPtr skeletonPointer, int channel, byte[] facialAnimationName, [MarshalAs(UnmanagedType.U1)] bool playSound, [MarshalAs(UnmanagedType.U1)] bool loop);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkeletonFaceAnimationTimeDelegate(UIntPtr entityId, float time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickActionChannelsDelegate(UIntPtr skeletonPointer);

	private static readonly Encoding _utf8;

	public static CreateAgentSkeletonDelegate call_CreateAgentSkeletonDelegate;

	public static CreateSimpleSkeletonDelegate call_CreateSimpleSkeletonDelegate;

	public static CreateWithActionSetDelegate call_CreateWithActionSetDelegate;

	public static DoesActionContinueWithCurrentActionAtChannelDelegate call_DoesActionContinueWithCurrentActionAtChannelDelegate;

	public static GetActionAtChannelDelegate call_GetActionAtChannelDelegate;

	public static GetBoneEntitialFrameDelegate call_GetBoneEntitialFrameDelegate;

	public static GetBoneEntitialFrameAtAnimationProgressDelegate call_GetBoneEntitialFrameAtAnimationProgressDelegate;

	public static GetSkeletonFaceAnimationNameDelegate call_GetSkeletonFaceAnimationNameDelegate;

	public static GetSkeletonFaceAnimationTimeDelegate call_GetSkeletonFaceAnimationTimeDelegate;

	public static SetAgentActionChannelDelegate call_SetAgentActionChannelDelegate;

	public static SetAnimationAtChannelDelegate call_SetAnimationAtChannelDelegate;

	public static SetFacialAnimationOfChannelDelegate call_SetFacialAnimationOfChannelDelegate;

	public static SetSkeletonFaceAnimationTimeDelegate call_SetSkeletonFaceAnimationTimeDelegate;

	public static TickActionChannelsDelegate call_TickActionChannelsDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Skeleton CreateAgentSkeleton(string skeletonName, bool isHumanoid, int actionSetIndex, string monsterUsageSetName, ref AnimationSystemData animationSystemData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Skeleton CreateSimpleSkeleton(string skeletonName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Skeleton CreateWithActionSet(ref AnimationSystemData animationSystemData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoesActionContinueWithCurrentActionAtChannel(UIntPtr skeletonPointer, int actionChannelNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetActionAtChannel(UIntPtr skeletonPointer, int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrame(UIntPtr skeletonPointer, sbyte bone, bool useBoneMapping, bool forceToUpdate, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrameAtAnimationProgress(UIntPtr skeletonPointer, sbyte boneIndex, int animationIndex, float progress, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetSkeletonFaceAnimationName(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSkeletonFaceAnimationTime(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAgentActionChannel(UIntPtr skeletonPointer, int actionChannelNo, int actionIndex, float channelParameter, float blendPeriodOverride, bool forceFaceMorphRestart, float blendWithNextActionFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationAtChannel(UIntPtr skeletonPointer, int animationIndex, int channelNo, float animationSpeedMultiplier, float blendInPeriod, float startProgress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFacialAnimationOfChannel(UIntPtr skeletonPointer, int channel, string facialAnimationName, bool playSound, bool loop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkeletonFaceAnimationTime(UIntPtr entityId, float time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickActionChannels(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBSkeletonExtensions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBSkeletonExtensions()
	{
		throw null;
	}
}
