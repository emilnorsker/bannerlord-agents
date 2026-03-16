using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.Admin.Internal;

internal class AdminPanelMultiSelectionOption : AdminPanelOption<IAdminPanelMultiSelectionItem>, IAdminPanelMultiSelectionOption, IAdminPanelOption<IAdminPanelMultiSelectionItem>, IAdminPanelOption
{
	protected IAdminPanelMultiSelectionItem _selectedOption;

	protected MBList<IAdminPanelMultiSelectionItem> _availableOptions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelMultiSelectionOption(string uniqueId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool AreEqualValues(IAdminPanelMultiSelectionItem first, IAdminPanelMultiSelectionItem second)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override IAdminPanelMultiSelectionItem GetOptionValue(OptionType optionType, MultiplayerOptionsAccessMode accessMode = (MultiplayerOptionsAccessMode)0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnValueChanged(IAdminPanelMultiSelectionItem previousValue, IAdminPanelMultiSelectionItem newValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool OnGetCanRevertToDefaultValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual AdminPanelMultiSelectionOption BuildAvailableOptions(MBReadOnlyList<IAdminPanelMultiSelectionItem> options)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual AdminPanelMultiSelectionOption BuildAvailableOptions(OptionType optionType, bool buildDefaultValue = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<IAdminPanelMultiSelectionItem> GetAvailableOptions()
	{
		throw null;
	}
}
