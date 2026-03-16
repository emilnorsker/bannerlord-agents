using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TownManagement;

public class SettlementGovernorSelectionVM : ViewModel
{
	private readonly Settlement _settlement;

	private readonly Action<Hero> _onDone;

	private MBBindingList<SettlementGovernorSelectionItemVM> _availableGovernors;

	private int _currentGovernorIndex;

	[DataSourceProperty]
	public MBBindingList<SettlementGovernorSelectionItemVM> AvailableGovernors
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
	public int CurrentGovernorIndex
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
	public SettlementGovernorSelectionVM(Settlement settlement, Action<Hero> onDone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelection(SettlementGovernorSelectionItemVM item)
	{
		throw null;
	}
}
