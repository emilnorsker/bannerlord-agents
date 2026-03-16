using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MBItem
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetItemUsageIndex(string itemUsageName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetItemHolsterIndex(string itemHolsterName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetItemIsPassiveUsage(string itemUsageName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame GetHolsterFrameByIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ItemObject.ItemUsageSetFlags GetItemUsageSetFlags(string ItemUsageName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ActionIndexCache GetItemUsageReloadActionCode(string itemUsageName, int usageDirection, bool isMounted, int leftHandUsageSetIndex, bool isLeftStance, bool isLowLookDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetItemUsageStrikeType(string itemUsageName, int usageDirection, bool isMounted, int leftHandUsageSetIndex, bool isLeftStance, bool isLowLookDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetMissileRange(float shotSpeed, float zDiff)
	{
		throw null;
	}
}
