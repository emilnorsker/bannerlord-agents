using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.ClassLoadout;

public class ShallowItemVM : ViewModel
{
	public enum ItemGroup
	{
		None,
		Spear,
		Javelin,
		Bow,
		Crossbow,
		Sword,
		Axe,
		Mace,
		ThrowingAxe,
		ThrowingKnife,
		Ammo,
		Shield,
		Mount,
		Stone
	}

	public class ArmoryItemFlagVM : ViewModel
	{
		private string _icon;

		private HintViewModel _hint;

		[DataSourceProperty]
		public string Icon
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
		public HintViewModel Hint
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
		public ArmoryItemFlagVM(string icon, TextObject hintText)
		{
			throw null;
		}
	}

	private readonly Action<ShallowItemVM> _onSelect;

	private AlternativeUsageItemOptionVM _latestUsageOption;

	private Equipment _equipment;

	private EquipmentIndex _equipmentIndex;

	private bool _isInitialized;

	private ItemImageIdentifierVM _icon;

	private string _name;

	private string _typeAsString;

	private bool _isValid;

	private bool _isSelected;

	private bool _hasAnyAlternativeUsage;

	private MBBindingList<ArmoryItemFlagVM> _itemInformationList;

	private MBBindingList<ShallowItemPropertyVM> _propertyList;

	private SelectorVM<AlternativeUsageItemOptionVM> _alternativeUsageSelector;

	public ItemGroup Type
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<ArmoryItemFlagVM> ItemInformationList
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
	public MBBindingList<ShallowItemPropertyVM> PropertyList
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
	public string Name
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
	public ItemImageIdentifierVM Icon
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
	public string TypeAsString
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
	public bool IsSelected
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
	public bool HasAnyAlternativeUsage
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
	public bool IsValid
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
	public SelectorVM<AlternativeUsageItemOptionVM> AlternativeUsageSelector
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
	public ShallowItemVM(Action<ShallowItemVM> onSelect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshWith(EquipmentIndex equipmentIndex, Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAlternativeUsageChanged(SelectorVM<AlternativeUsageItemOptionVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshItemPropertyList(EquipmentIndex equipmentIndex, Equipment equipment, int alternativeIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<(string, TextObject)> GetWeaponFlagDetails(WeaponFlags weaponFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddProperty(TextObject name, float fraction, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ItemGroup GetItemGroupType(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public void OnSelect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsItemUsageApplicable(WeaponComponentData weapon)
	{
		throw null;
	}
}
