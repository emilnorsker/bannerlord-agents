using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.CustomBattle.CustomBattle.SelectionItem;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleShipSelectionGroupVM : ViewModel
{
	private readonly Action _onShipSelectedOrUpgraded;

	private MBBindingList<NavalCustomBattleShipSelectionItemVM> _shipSelectionItems;

	[DataSourceProperty]
	public MBBindingList<NavalCustomBattleShipSelectionItemVM> ShipSelectionItems
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
	public NavalCustomBattleShipSelectionGroupVM(bool isPlayerSide, NavalCustomBattleShipSelectionPopUpVM shipSelectionPopUp, Action onShipSelectedOrUpgraded, Action<NavalCustomBattleShipItemVM> onShipFocused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRandomize(int targetDeckSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<ShipHull> CreateRandomFleet(int targetDeckSize, out int deckSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<IShipOrigin> GetSelectedShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipSelectedOrUpgraded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCanShipsBecomeEmpty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCycleTierInputKey(HotKey hotkey)
	{
		throw null;
	}
}
