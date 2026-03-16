using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory.CosmeticItem;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory.CosmeticCategory;

public class MPArmoryClothingCosmeticCategoryVM : MPArmoryCosmeticCategoryBaseVM
{
	public readonly MPArmoryCosmeticsVM.ClothingCategory ClothingCategory;

	private List<string> _defaultCosmeticIDs;

	public static event Action<MPArmoryClothingCosmeticCategoryVM> OnSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MPArmoryClothingCosmeticCategoryVM(MPArmoryCosmeticsVM.ClothingCategory clothingCategory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ExecuteSelectCategory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDefaultItem(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDefaultEquipments(Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReplaceCosmeticWithDefaultItem(MPArmoryCosmeticClothingItemVM cosmetic, MPArmoryCosmeticsVM.ClothingCategory clothingCategory, MPHeroClass selectedClass, List<string> ownedCosmetics)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEquipmentRefreshed(EquipmentIndex equipmentIndex)
	{
		throw null;
	}
}
