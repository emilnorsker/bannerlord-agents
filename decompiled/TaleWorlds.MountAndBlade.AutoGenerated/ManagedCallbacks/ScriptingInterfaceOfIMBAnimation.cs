using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBAnimation : IMBAnimation
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int AnimationIndexOfActionCodeDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckAnimationClipExistsDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetActionAnimationDurationDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetActionBlendOutStartProgressDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetActionCodeWithNameDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetActionNameWithCodeDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Agent.ActionCodeType GetActionTypeDelegate(int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAnimationBlendInPeriodDelegate(int animationIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAnimationBlendsWithActionIndexDelegate(int animationIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAnimationContinueToActionDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetAnimationDisplacementAtProgressDelegate(int animationIndex, float progress);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAnimationDurationDelegate(int animationIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate AnimFlags GetAnimationFlagsDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAnimationNameDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAnimationParameter1Delegate(int animationIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAnimationParameter2Delegate(int animationIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAnimationParameter3Delegate(int animationIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetDisplacementVectorDelegate(int actionSetNo, int actionIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetIDWithIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetIndexWithIDDelegate(byte[] id);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumActionCodesDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumAnimationsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsAnyAnimationLoadingFromDiskDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PrefetchAnimationClipDelegate(int actionSetNo, int actionIndex);

	private static readonly Encoding _utf8;

	public static AnimationIndexOfActionCodeDelegate call_AnimationIndexOfActionCodeDelegate;

	public static CheckAnimationClipExistsDelegate call_CheckAnimationClipExistsDelegate;

	public static GetActionAnimationDurationDelegate call_GetActionAnimationDurationDelegate;

	public static GetActionBlendOutStartProgressDelegate call_GetActionBlendOutStartProgressDelegate;

	public static GetActionCodeWithNameDelegate call_GetActionCodeWithNameDelegate;

	public static GetActionNameWithCodeDelegate call_GetActionNameWithCodeDelegate;

	public static GetActionTypeDelegate call_GetActionTypeDelegate;

	public static GetAnimationBlendInPeriodDelegate call_GetAnimationBlendInPeriodDelegate;

	public static GetAnimationBlendsWithActionIndexDelegate call_GetAnimationBlendsWithActionIndexDelegate;

	public static GetAnimationContinueToActionDelegate call_GetAnimationContinueToActionDelegate;

	public static GetAnimationDisplacementAtProgressDelegate call_GetAnimationDisplacementAtProgressDelegate;

	public static GetAnimationDurationDelegate call_GetAnimationDurationDelegate;

	public static GetAnimationFlagsDelegate call_GetAnimationFlagsDelegate;

	public static GetAnimationNameDelegate call_GetAnimationNameDelegate;

	public static GetAnimationParameter1Delegate call_GetAnimationParameter1Delegate;

	public static GetAnimationParameter2Delegate call_GetAnimationParameter2Delegate;

	public static GetAnimationParameter3Delegate call_GetAnimationParameter3Delegate;

	public static GetDisplacementVectorDelegate call_GetDisplacementVectorDelegate;

	public static GetIDWithIndexDelegate call_GetIDWithIndexDelegate;

	public static GetIndexWithIDDelegate call_GetIndexWithIDDelegate;

	public static GetNumActionCodesDelegate call_GetNumActionCodesDelegate;

	public static GetNumAnimationsDelegate call_GetNumAnimationsDelegate;

	public static IsAnyAnimationLoadingFromDiskDelegate call_IsAnyAnimationLoadingFromDiskDelegate;

	public static PrefetchAnimationClipDelegate call_PrefetchAnimationClipDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AnimationIndexOfActionCode(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckAnimationClipExists(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetActionAnimationDuration(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetActionBlendOutStartProgress(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetActionCodeWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetActionNameWithCode(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent.ActionCodeType GetActionType(int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationBlendInPeriod(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAnimationBlendsWithActionIndex(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAnimationContinueToAction(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetAnimationDisplacementAtProgress(int animationIndex, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationDuration(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AnimFlags GetAnimationFlags(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAnimationName(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationParameter1(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationParameter2(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAnimationParameter3(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetDisplacementVector(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetIDWithIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIndexWithID(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumActionCodes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumAnimations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyAnimationLoadingFromDisk()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrefetchAnimationClip(int actionSetNo, int actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBAnimation()
	{
		throw null;
	}
}
