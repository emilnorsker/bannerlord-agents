using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.Admin;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.AdminPanel;

public class MultiplayerAdminPanelMultiSelectionOptionVM : MultiplayerAdminPanelOptionBaseVM
{
	public class AdminPanelOptionSelectorVM : SelectorVM<AdminPanelOptionSelectorItemVM>
	{
		private bool _isEnabled;

		[DataSourceProperty]
		public bool IsEnabled
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
		public AdminPanelOptionSelectorVM(int selectedIndex, Action<SelectorVM<AdminPanelOptionSelectorItemVM>> onChange)
		{
			throw null;
		}
	}

	public class AdminPanelOptionSelectorItemVM : SelectorItemVM
	{
		public readonly IAdminPanelMultiSelectionItem SelectionItem;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public AdminPanelOptionSelectorItemVM(IAdminPanelMultiSelectionItem selectionItem)
		{
			throw null;
		}
	}

	private new readonly IAdminPanelMultiSelectionOption _option;

	private readonly SelectorItemVM _initialValue;

	private bool _isMultiSelectionOption;

	private AdminPanelOptionSelectorVM _multiSelectionOptions;

	[DataSourceProperty]
	public bool IsMultiSelectionOption
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
	public AdminPanelOptionSelectorVM MultiSelectionOptions
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
	public MultiplayerAdminPanelMultiSelectionOptionVM(IAdminPanelMultiSelectionOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectorChange(SelectorVM<AdminPanelOptionSelectorItemVM> selector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdateValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteRestoreDefaults()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteRevertChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshOptions()
	{
		throw null;
	}
}
