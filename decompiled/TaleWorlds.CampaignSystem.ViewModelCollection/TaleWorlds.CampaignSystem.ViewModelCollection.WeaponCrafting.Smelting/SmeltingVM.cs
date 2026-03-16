using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Smelting;

public class SmeltingVM : ViewModel
{
	private ItemRoster _playerItemRoster;

	private Action _updateValuesOnSelectItemAction;

	private Action _updateValuesOnSmeltItemAction;

	private List<string> _lockedItemIDs;

	private readonly ICraftingCampaignBehavior _smithingBehavior;

	private string _weaponTypeName;

	private string _weaponTypeCode;

	private SmeltingItemVM _currentSelectedItem;

	private MBBindingList<SmeltingItemVM> _smeltableItemList;

	private SmeltingSortControllerVM _sortController;

	private HintViewModel _selectAllHint;

	private bool _isAnyItemSelected;

	[DataSourceProperty]
	public string WeaponTypeName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string WeaponTypeCode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public SmeltingItemVM CurrentSelectedItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsAnyItemSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<SmeltingItemVM> SmeltableItemList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public HintViewModel SelectAllHint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public SmeltingSortControllerVM SortController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SmeltingVM(Action updateValuesOnSelectItemAction, Action updateValuesOnSmeltItemAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnCraftingHeroChanged(CraftingAvailableHeroItemVM newHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemSelection(SmeltingItemVM newItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TrySmeltingSelectedItems(Hero currentCraftingHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessLockItem(SmeltingItemVM item, bool isLocked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SmeltSelectedItems(Hero currentCraftingHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsItemLocked(EquipmentElement equipmentElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveItemLockStates()
	{
		throw null;
	}
}
