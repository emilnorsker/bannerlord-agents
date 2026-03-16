using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.Port.PortScreenHandlers;

public readonly struct PortActionInfo
{
	public readonly bool IsRelevant;

	public readonly bool IsEnabled;

	public readonly int GoldCost;

	public readonly TextObject ActionName;

	public readonly TextObject Tooltip;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PortActionInfo(bool isRelevant, bool isEnabled, int goldCost, TextObject actionName, TextObject tooltip = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PortActionInfo CreateValid(bool isEnabled, int goldCost, TextObject name, TextObject tooltip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PortActionInfo CreateInvalid(TextObject reason = null)
	{
		throw null;
	}
}
