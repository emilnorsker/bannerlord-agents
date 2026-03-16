using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("int", false, null)]
public struct MBActionSet
{
	[CustomEngineStructMemberData("ignoredMember", true)]
	internal readonly int Index;

	public static readonly MBActionSet InvalidActionSet;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal MBActionSet(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(MBActionSet a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetSkeletonName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAnimationName(in ActionIndexCache actionCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AreActionsAlternatives(in ActionIndexCache actionCode1, in ActionIndexCache actionCode2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfActionSets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfMonsterUsageSets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBActionSet GetActionSet(string objectID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBActionSet GetActionSetWithIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static sbyte GetBoneIndexWithId(string actionSetId, string boneId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetBoneHasParentBone(string actionSetId, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec3 GetActionDisplacementVector(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AnimFlags GetActionAnimationFlags(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckActionAnimationClipExists(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetAnimationIndexOfAction(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetActionAnimationName(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetActionAnimationDuration(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ActionIndexCache GetActionAnimationContinueToAction(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetTotalAnimationDurationWithContinueToAction(MBActionSet actionSet, ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetActionBlendOutStartProgress(MBActionSet actionSet, in ActionIndexCache actionIndexCache)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBActionSet()
	{
		throw null;
	}
}
