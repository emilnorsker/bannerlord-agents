using System;
using System.Runtime.CompilerServices;
using NavalDLC.CustomBattle.CustomBattle.SelectionItem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleFactionSelectionVM : ViewModel
{
	private Action<BasicCultureObject> _onSelectionChanged;

	private MBBindingList<NavalCustomBattleFactionItemVM> _factions;

	private string _selectedFactionName;

	private NavalCustomBattleFactionItemVM _selectedItem;

	[DataSourceProperty]
	public MBBindingList<NavalCustomBattleFactionItemVM> Factions
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
	public string SelectedFactionName
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
	public NavalCustomBattleFactionItemVM SelectedItem
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
	public NavalCustomBattleFactionSelectionVM(Action<BasicCultureObject> onSelectionChanged)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectFaction(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRandomize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFactionSelected(NavalCustomBattleFactionItemVM faction)
	{
		throw null;
	}
}
