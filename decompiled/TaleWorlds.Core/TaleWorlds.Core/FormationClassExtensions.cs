using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public static class FormationClassExtensions
{
	public const TroopUsageFlags DefaultInfantryTroopUsageFlags = TroopUsageFlags.OnFoot | TroopUsageFlags.Melee | TroopUsageFlags.OneHandedUser | TroopUsageFlags.ShieldUser | TroopUsageFlags.TwoHandedUser | TroopUsageFlags.PolearmUser;

	public const TroopUsageFlags DefaultRangedTroopUsageFlags = TroopUsageFlags.OnFoot | TroopUsageFlags.Ranged | TroopUsageFlags.BowUser | TroopUsageFlags.ThrownUser | TroopUsageFlags.CrossbowUser;

	public const TroopUsageFlags DefaultCavalryTroopUsageFlags = TroopUsageFlags.Mounted | TroopUsageFlags.Melee | TroopUsageFlags.OneHandedUser | TroopUsageFlags.ShieldUser | TroopUsageFlags.TwoHandedUser | TroopUsageFlags.PolearmUser;

	public const TroopUsageFlags DefaultHorseArcherTroopUsageFlags = TroopUsageFlags.Mounted | TroopUsageFlags.Ranged | TroopUsageFlags.BowUser | TroopUsageFlags.ThrownUser | TroopUsageFlags.CrossbowUser;

	public static FormationClass[] FormationClassValues;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetName(this FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetLocalizedName(this FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopUsageFlags GetTroopUsageFlags(this FormationClass troopClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopType GetTroopTypeForRegularFormation(this FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsDefaultFormationClass(this FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsRegularFormationClass(this FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FormationClass FallbackClass(this FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FormationClassExtensions()
	{
		throw null;
	}
}
