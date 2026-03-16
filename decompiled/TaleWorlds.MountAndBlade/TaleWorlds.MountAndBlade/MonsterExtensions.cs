using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public static class MonsterExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AnimationSystemData FillAnimationSystemData(this Monster monster, float stepSize, bool hasClippingPlane, bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AnimationSystemData FillAnimationSystemData(this Monster monster, MBActionSet actionSet, float stepSize, bool hasClippingPlane)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CopyArrayAndTruncateSourceIfNecessary(ref sbyte[] destinationArray, out sbyte destinationArraySize, sbyte destinationArrayCapacity, sbyte[] sourceArray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AgentCapsuleData FillCapsuleData(this Monster monster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AgentSpawnData FillSpawnData(this Monster monster, ItemObject mountItem)
	{
		throw null;
	}
}
