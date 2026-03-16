using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Encyclopedia;

public class EncyclopediaFilterItem
{
	public readonly TextObject Name;

	public readonly Predicate<object> Predicate;

	public bool IsActive;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaFilterItem(TextObject name, Predicate<object> predicate)
	{
		throw null;
	}
}
