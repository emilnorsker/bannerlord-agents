using System.Runtime.CompilerServices;
using NavalDLC.CustomBattle.CustomBattle.SelectionItem;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleGameTypeSelectionGroupVM : ViewModel
{
	private SelectorVM<NavalCustomBattlePlayerSideItemVM> _playerSideSelection;

	private string _playerSideText;

	public NavalCustomBattlePlayerSide SelectedPlayerSide
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
	public SelectorVM<NavalCustomBattlePlayerSideItemVM> PlayerSideSelection
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
	public string PlayerSideText
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
	public NavalCustomBattleGameTypeSelectionGroupVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RandomizeAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerSideSelection(SelectorVM<NavalCustomBattlePlayerSideItemVM> selector)
	{
		throw null;
	}
}
