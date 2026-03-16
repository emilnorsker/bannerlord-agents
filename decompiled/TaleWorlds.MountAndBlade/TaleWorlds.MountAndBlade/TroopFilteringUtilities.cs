using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public static class TroopFilteringUtilities
{
	public const int MinPriority = 1;

	public const int EquipmentPriority = 10;

	public const int EngagementTypePriority = 100;

	public const int MountedPriority = 1000;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopTraitsMask GetFilter(bool isMounted, bool isRanged, bool isMelee, bool hasHeavyArmor, bool hasThrown, bool hasSpear, bool hasShield)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopTraitsMask GetFilter(params FormationClass[] formationClasses)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopTraitsMask GetFilter(params FormationFilterType[] filterTypes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetPriorityFunction(TroopTraitsMask filter, out Func<Agent, int> priorityFunc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetPriorityFunction(TroopTraitsMask filter, out Func<IAgentOriginBase, int> priorityFunc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetTroopPriority(TroopTraitsMask troopMask, int battleTier, TroopTraitsMask filter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMaxPriority(TroopTraitsMask filter)
	{
		throw null;
	}
}
