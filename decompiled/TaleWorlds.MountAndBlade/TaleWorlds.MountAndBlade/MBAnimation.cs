using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public struct MBAnimation
{
	private readonly int _index;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBAnimation(MBAnimation animation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBAnimation(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(MBAnimation a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetAnimationIndexWithName(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Agent.ActionCodeType GetActionType(ActionIndexCache actionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PrefetchAnimationClip(MBActionSet actionSet, ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationDuration(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationDuration(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationParameter1(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationParameter1(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationParameter2(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationParameter2(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationParameter3(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationBlendInPeriod(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationBlendInPeriod(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetAnimationBlendsWithActionIndex(string animationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetAnimationBlendsWithActionIndex(int animationIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 GetAnimationDisplacementAtProgress(string animationName, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 GetAnimationDisplacementAtProgress(int animationIndex, float progress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetActionCodeWithName(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumActionCodes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumAnimations()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAnyAnimationLoadingFromDisk()
	{
		throw null;
	}
}
