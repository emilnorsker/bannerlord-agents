using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD;

public class MissionMainAgentEquipmentControllerVM : ViewModel
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
		Banner,
		Stone
	}

	private TextObject _replaceWithLocalizedText;

	private TextObject _dropLocalizedText;

	private SpawnedItemEntity _focusedWeaponEntity;

	private readonly Action<EquipmentIndex> _onDropEquipment;

	private readonly Action<SpawnedItemEntity, EquipmentIndex> _onEquipItem;

	private readonly TextObject _pickText;

	private bool _isDropControllerActive;

	private bool _isEquipControllerActive;

	private string _selectedItemText;

	private string _dropText;

	private string _equipText;

	private string _focusedItemText;

	private MBBindingList<EquipmentActionItemVM> _dropActions;

	private MBBindingList<EquipmentActionItemVM> _equipActions;

	[DataSourceProperty]
	public bool IsDropControllerActive
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
	public bool IsEquipControllerActive
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
	public string DropText
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
	public string EquipText
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
	public string FocusedItemText
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
	public string SelectedItemText
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
	public MBBindingList<EquipmentActionItemVM> DropActions
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
	public MBBindingList<EquipmentActionItemVM> EquipActions
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
	public MissionMainAgentEquipmentControllerVM(Action<EquipmentIndex> onDropEquipment, Action<SpawnedItemEntity, EquipmentIndex> onEquipItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDropControllerToggle(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleDropItemActionSelection(object selectedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentFocusedWeaponEntity(SpawnedItemEntity weaponEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnEquipControllerToggle(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCancelEquipController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCancelDropController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleEquipItemActionSelection(object selectedItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnItemSelected(EquipmentActionItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetWeaponName(MissionWeapon weapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetItemTypeAsString(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool DoesPlayerHaveAtLeastOneShield()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsWieldedWeaponAtIndex(EquipmentIndex index)
	{
		throw null;
	}
}
