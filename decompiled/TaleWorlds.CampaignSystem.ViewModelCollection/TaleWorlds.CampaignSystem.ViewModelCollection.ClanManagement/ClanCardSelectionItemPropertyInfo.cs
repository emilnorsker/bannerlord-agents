using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;

public readonly struct ClanCardSelectionItemPropertyInfo
{
	public readonly TextObject Title;

	public readonly TextObject Value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanCardSelectionItemPropertyInfo(TextObject title, TextObject value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanCardSelectionItemPropertyInfo(TextObject value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject CreateLabeledValueText(TextObject label, TextObject value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject CreateActionGoldChangeText(int goldChange)
	{
		throw null;
	}
}
