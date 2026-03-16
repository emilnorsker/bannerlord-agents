using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Helpers;

public static class ItemHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsWeaponComparableWithUsage(ItemObject item, string comparedUsageId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsWeaponComparableWithUsage(ItemObject item, string comparedUsageId, out int comparableUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckComparability(ItemObject item, ItemObject comparedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckComparability(ItemObject item, ItemObject comparedItem, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextObject GetDamageDescription(int damage, DamageTypes damageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetSwingDamageText(WeaponComponentData weapon, ItemModifier itemModifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetMissileDamageText(WeaponComponentData weapon, ItemModifier itemModifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetThrustDamageText(WeaponComponentData weapon, ItemModifier itemModifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject NumberOfItems(int number, ItemObject item)
	{
		throw null;
	}
}
