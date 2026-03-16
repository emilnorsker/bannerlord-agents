using System;
using System.Runtime.CompilerServices;
using SandBox.View.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TroopSelection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Menu;

[OverrideView(typeof(MenuTroopSelectionView))]
public class GauntletMenuTroopSelectionView : MenuView
{
	private readonly Action<TroopRoster> _onDone;

	private readonly TroopRoster _fullRoster;

	private readonly TroopRoster _initialSelections;

	private readonly Func<CharacterObject, bool> _changeChangeStatusOfTroop;

	private readonly int _maxSelectableTroopCount;

	private readonly int _minSelectableTroopCount;

	private GauntletLayer _layerAsGauntletLayer;

	private GameMenuTroopSelectionVM _dataSource;

	private GauntletMovieIdentifier _movie;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMenuTroopSelectionView(TroopRoster fullRoster, TroopRoster initialSelections, Func<CharacterObject, bool> changeChangeStatusOfTroop, Action<TroopRoster> onDone, int maxSelectableTroopCount, int minSelectableTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDone(TroopRoster obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationDeactivated()
	{
		throw null;
	}
}
