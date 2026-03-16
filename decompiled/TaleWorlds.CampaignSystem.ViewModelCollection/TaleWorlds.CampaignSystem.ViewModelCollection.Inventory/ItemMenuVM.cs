using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;

public class ItemMenuVM : ViewModel
{
	private readonly TextObject _swingDamageText;

	private readonly TextObject _swingSpeedText;

	private readonly TextObject _weaponTierText;

	private readonly TextObject _armorTierText;

	private readonly TextObject _horseTierText;

	private readonly TextObject _horseTypeText;

	private readonly TextObject _chargeDamageText;

	private readonly TextObject _hitPointsText;

	private readonly TextObject _speedText;

	private readonly TextObject _maneuverText;

	private readonly TextObject _thrustSpeedText;

	private readonly TextObject _thrustDamageText;

	private readonly TextObject _lengthText;

	private readonly TextObject _weightText;

	private readonly TextObject _handlingText;

	private readonly TextObject _weaponLengthText;

	private readonly TextObject _damageText;

	private readonly TextObject _missileSpeedText;

	private readonly TextObject _accuracyText;

	private readonly TextObject _stackAmountText;

	private readonly TextObject _ammoLimitText;

	private readonly TextObject _requiresText;

	private readonly TextObject _foodText;

	private readonly TextObject _partyMoraleText;

	private readonly TextObject _typeText;

	private readonly TextObject _tradeRumorsText;

	private readonly TextObject _classText;

	private readonly TextObject _headArmorText;

	private readonly TextObject _horseArmorText;

	private readonly TextObject _bodyArmorText;

	private readonly TextObject _legArmorText;

	private readonly TextObject _armArmorText;

	private readonly TextObject _stealthBonusText;

	private readonly TextObject _bannerEffectText;

	private readonly TextObject _noneText;

	private readonly string GoldIcon;

	private readonly Color ConsumableColor;

	private readonly Color TitleColor;

	private TooltipProperty _costProperty;

	private InventoryLogic _inventoryLogic;

	private Action<ItemVM, int> _resetComparedItems;

	private readonly Func<WeaponComponentData, ItemObject.ItemUsageSetFlags> _getItemUsageSetFlags;

	private readonly Func<EquipmentIndex, SPItemVM> _getEquipmentAtIndex;

	private int _lastComparedItemVersion;

	private ItemVM _targetItem;

	private bool _isComparing;

	private bool _isStealthModeActive;

	private ItemVM _comparedItem;

	private bool _isPlayerItem;

	private BasicCharacterObject _character;

	private ItemImageIdentifierVM _imageIdentifier;

	private ItemImageIdentifierVM _comparedImageIdentifier;

	private string _itemName;

	private string _comparedItemName;

	private MBBindingList<ItemMenuTooltipPropertyVM> _comparedItemProperties;

	private MBBindingList<ItemMenuTooltipPropertyVM> _targetItemProperties;

	private bool _isInitializationOver;

	private int _transactionTotalCost;

	private MBBindingList<ItemFlagVM> _targetItemFlagList;

	private MBBindingList<ItemFlagVM> _comparedItemFlagList;

	private int _alternativeUsageIndex;

	private MBBindingList<StringItemWithHintVM> _alternativeUsages;

	private ITradeRumorCampaignBehavior _tradeRumorsBehavior;

	[DataSourceProperty]
	public bool IsComparing
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
	public bool IsPlayerItem
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
	public ItemImageIdentifierVM ImageIdentifier
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
	public ItemImageIdentifierVM ComparedImageIdentifier
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
	public int TransactionTotalCost
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
	public bool IsInitializationOver
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
	public string ItemName
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
	public string ComparedItemName
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
	public bool IsStealthModeActive
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
	public MBBindingList<ItemMenuTooltipPropertyVM> TargetItemProperties
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
	public MBBindingList<ItemMenuTooltipPropertyVM> ComparedItemProperties
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
	public MBBindingList<ItemFlagVM> TargetItemFlagList
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
	public MBBindingList<ItemFlagVM> ComparedItemFlagList
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
	public int AlternativeUsageIndex
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
	public MBBindingList<StringItemWithHintVM> AlternativeUsages
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
	public ItemMenuVM(Action<ItemVM, int> resetComparedItems, InventoryLogic inventoryLogic, Func<WeaponComponentData, ItemObject.ItemUsageSetFlags> getItemUsageSetFlags, Func<EquipmentIndex, SPItemVM> getEquipmentAtIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetItem(SPItemVM item, InventoryLogic.InventorySide currentEquipmentMode, ItemVM comparedItem = null, BasicCharacterObject character = null, int alternativeUsageIndex = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshItemTooltips(ItemVM item, ItemVM comparedItem, int alternativeUsageIndex = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CompareValues(float currentValue, float comparedValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CompareValues(int currentValue, int comparedValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AlternativeUsageIndexUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetComparedWeapon(string weaponUsageId, out EquipmentElement comparedWeapon, out int comparedUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGeneralComponentTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSkillRequirement(ItemVM itemVm, MBBindingList<ItemMenuTooltipPropertyVM> itemProperties, bool isComparison)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGeneralItemFlags(MBBindingList<ItemFlagVM> list, ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddFoodItemFlags(MBBindingList<ItemFlagVM> list, ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddWeaponItemFlags(MBBindingList<ItemFlagVM> list, WeaponComponentData weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Color GetColorFromBool(bool booleanValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFoodTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetHorseComponentTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddHorseItemFlags(MBBindingList<ItemFlagVM> list, ItemObject item, HorseComponent horse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMerchandiseComponentTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateTradeRumorOldnessFactor(TradeRumor rumor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAlternativeUsages(EquipmentElement targetWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetWeaponComponentTooltip(in EquipmentElement targetWeapon, int targetWeaponUsageIndex, EquipmentElement comparedWeapon, int comparedWeaponUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIntProperty(TextObject description, int targetValue, int? comparedValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddFloatProperty(TextObject description, Func<EquipmentElement, float> func, bool reversedCompare = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddFloatProperty(TextObject description, float targetValue, float? comparedValue, bool reversedCompare = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddComparableStringProperty(TextObject description, Func<EquipmentElement, string> valueAsStringFunc, Func<EquipmentElement, int> valueAsIntFunc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSwingDamageProperty(TextObject description, in EquipmentElement targetWeapon, int targetWeaponUsageIndex, in EquipmentElement comparedWeapon, int comparedWeaponUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMissileDamageProperty(TextObject description, in EquipmentElement targetWeapon, int targetWeaponUsageIndex, in EquipmentElement comparedWeapon, int comparedWeaponUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddThrustDamageProperty(TextObject description, in EquipmentElement targetWeapon, int targetWeaponUsageIndex, in EquipmentElement comparedWeapon, int comparedWeaponUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetArmorComponentTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDonationXpTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Color GetColorFromComparison(int result, bool isCompared)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetHorseCategoryValue(ItemCategory itemCategory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ItemMenuTooltipPropertyVM CreateProperty(MBBindingList<ItemMenuTooltipPropertyVM> targetList, string definition, string value, int textHeight = 0, HintViewModel hint = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ItemMenuTooltipPropertyVM CreateColoredProperty(MBBindingList<ItemMenuTooltipPropertyVM> targetList, string definition, string value, Color color, int textHeight = 0, HintViewModel hint = null, TooltipProperty.TooltipPropertyFlags propertyFlags = TooltipProperty.TooltipPropertyFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTransactionCost(int getItemTotalPrice, int maxIndividualPrice)
	{
		throw null;
	}
}
