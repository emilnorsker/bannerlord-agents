using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.CustomGame;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.HostGame.HostGameOptions;
using TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.HostGame;

public class MPHostGameOptionsVM : ViewModel
{
	private class OptionPreferredIndexComparer : IComparer<GenericHostGameOptionDataVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(GenericHostGameOptionDataVM x, GenericHostGameOptionDataVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OptionPreferredIndexComparer()
		{
			throw null;
		}
	}

	private List<GenericHostGameOptionDataVM> _hostGameItemsForNextTick;

	private OptionPreferredIndexComparer _optionComparer;

	private MPCustomGameVM.CustomGameMode _customGameMode;

	private bool _isRefreshed;

	private bool _isInMission;

	private MBBindingList<GenericHostGameOptionDataVM> _generalOptions;

	[DataSourceProperty]
	public MBBindingList<GenericHostGameOptionDataVM> GeneralOptions
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
	public bool IsRefreshed
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
	public bool IsInMission
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
	public MPHostGameOptionsVM(bool isInMission, MPCustomGameVM.CustomGameMode customGameMode = MPCustomGameVM.CustomGameMode.CustomServer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeDefaultOptionList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChangeSelected(MultipleSelectionHostGameOptionDataVM option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameModeChanged(string gameModeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillOptionsForCustomServer(string gameModeName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillOptionsForPremadeGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GenericHostGameOptionDataVM CreateOption(OptionType type, int preferredIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private OptionsDataType GetSpecificHostGameOptionTypeOf(OptionType type)
	{
		throw null;
	}
}
