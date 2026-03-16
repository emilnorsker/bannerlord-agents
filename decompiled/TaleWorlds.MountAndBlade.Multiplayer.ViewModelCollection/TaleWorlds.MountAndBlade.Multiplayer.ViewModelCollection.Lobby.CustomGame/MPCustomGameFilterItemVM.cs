using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.CustomGame;

public class MPCustomGameFilterItemVM : ViewModel
{
	public readonly Func<GameServerEntry, bool> GetIsApplicaple;

	public readonly Action _onSelectionChange;

	private readonly TextObject _descriptionObj;

	private MPCustomGameFiltersVM.CustomGameFilterType _filterType;

	private bool _isSelected;

	private string _description;

	[DataSourceProperty]
	public bool IsSelected
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
	public string Description
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
	public MPCustomGameFilterItemVM(MPCustomGameFiltersVM.CustomGameFilterType filterType, TextObject description, Func<GameServerEntry, bool> getFilterApplicaple, Action onSelectionChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnToggled()
	{
		throw null;
	}
}
