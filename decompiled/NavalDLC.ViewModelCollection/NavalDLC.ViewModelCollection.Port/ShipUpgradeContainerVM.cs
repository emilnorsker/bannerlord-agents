using System.Runtime.CompilerServices;
using NavalDLC.ViewModelCollection.Port.PortScreenHandlers;
using TaleWorlds.Library;

namespace NavalDLC.ViewModelCollection.Port;

public class ShipUpgradeContainerVM : ViewModel
{
	public delegate void ShipSlotSelectedDelegate(ShipUpgradeSlotBaseVM slot);

	public static ShipSlotSelectedDelegate OnSlotSelected;

	private bool _canTradeUpgrades;

	private bool _hasSelectedSlot;

	private ShipItemVM _ship;

	private ShipUpgradeSlotBaseVM _selectedSlot;

	private MBBindingList<ShipUpgradeSlotBaseVM> _upgradeSlots;

	[DataSourceProperty]
	public bool CanTradeUpgrades
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
	public bool HasSelectedSlot
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
	public ShipItemVM Ship
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
	public ShipUpgradeSlotBaseVM SelectedSlot
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
	public MBBindingList<ShipUpgradeSlotBaseVM> UpgradeSlots
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
	public ShipUpgradeContainerVM(ShipItemVM ship)
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
	public void ResetUpgradePieces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateEnabledStatus(in PortActionInfo actionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSlotSelectedAux(ShipUpgradeSlotBaseVM slot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteClearSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update()
	{
		throw null;
	}
}
