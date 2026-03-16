using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.HostGame.HostGameOptions;

public class MultipleSelectionHostGameOptionDataVM : GenericHostGameOptionDataVM
{
	public Action<MultipleSelectionHostGameOptionDataVM> OnChangedSelection;

	private SelectorVM<SelectorItemVM> _selector;

	[DataSourceProperty]
	public SelectorVM<SelectorItemVM> Selector
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
	public MultipleSelectionHostGameOptionDataVM(OptionType optionType, int preferredIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChangeSelected(SelectorVM<SelectorItemVM> selector)
	{
		throw null;
	}
}
