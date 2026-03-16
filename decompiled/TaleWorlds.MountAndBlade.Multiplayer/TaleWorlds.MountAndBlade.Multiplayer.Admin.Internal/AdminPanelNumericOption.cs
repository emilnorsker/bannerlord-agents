using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer.Admin.Internal;

internal class AdminPanelNumericOption : AdminPanelOption<int>, IAdminPanelNumericOption, IAdminPanelOption<int>, IAdminPanelOption
{
	private int? _minimumValue;

	private int? _maximumValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelNumericOption(string uniqueId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool AreEqualValues(int first, int second)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelNumericOption SetMinimumValue(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelNumericOption SetMaximumValue(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AdminPanelNumericOption SetMinimumAndMaximumFrom(OptionType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int? GetMinimumValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int? GetMaximumValue()
	{
		throw null;
	}
}
