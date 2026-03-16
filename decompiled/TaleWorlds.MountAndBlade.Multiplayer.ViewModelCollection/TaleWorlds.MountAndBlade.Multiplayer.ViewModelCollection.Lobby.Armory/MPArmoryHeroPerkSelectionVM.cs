using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.ClassLoadout;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory;

public class MPArmoryHeroPerkSelectionVM : ViewModel
{
	private readonly Action<HeroPerkVM, MPPerkVM> _onPerkSelection;

	private readonly Action _forceRefreshCharacter;

	private List<string> _availableGameModes;

	private MBBindingList<HeroPerkVM> _perks;

	private SelectorVM<SelectorItemVM> _gameModes;

	public MPHeroClass CurrentHeroClass
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

	public List<IReadOnlyPerkObject> CurrentSelectedPerks
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
	public MBBindingList<HeroPerkVM> Perks
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
	public SelectorVM<SelectorItemVM> GameModes
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
	public MPArmoryHeroPerkSelectionVM(Action<HeroPerkVM, MPPerkVM> onPerkSelection, Action forceRefreshCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshPerksListWithHero(MPHeroClass heroClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameModeSelectionChanged(SelectorVM<SelectorItemVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPerkSelection(HeroPerkVM heroPerk, MPPerkVM candidate)
	{
		throw null;
	}
}
