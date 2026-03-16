using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.Diamond.Cosmetics.CosmeticTypes;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby;

internal static class LobbyTauntHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Equipment PrepareForTaunt(Equipment originalEquipment, TauntCosmeticElement taunt, bool doNotAddComplimentaryWeapons = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Tuple<EquipmentIndex, EquipmentElement, WeaponComponentData> GetWeaponInfoOfType(this Equipment equipment, WeaponClass type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Tuple<EquipmentIndex, EquipmentElement, WeaponComponentData> GetWeaponInfoOfPredicate(this Equipment equipment, Predicate<WeaponComponentData> predicate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Tuple<EquipmentIndex, EquipmentElement, WeaponComponentData> GetTwoHandedWeaponInfo(this Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TryAddElement(this Equipment equipment, ref EquipmentIndex eqIndex, EquipmentElement element)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SwapItems(this Equipment equipment, EquipmentIndex first, EquipmentIndex second)
	{
		throw null;
	}
}
