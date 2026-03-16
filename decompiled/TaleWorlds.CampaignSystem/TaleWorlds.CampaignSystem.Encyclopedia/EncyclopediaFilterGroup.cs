using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Encyclopedia;

public class EncyclopediaFilterGroup : ViewModel
{
	public readonly List<EncyclopediaFilterItem> Filters;

	public readonly TextObject Name;

	public Predicate<object> Predicate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaFilterGroup(List<EncyclopediaFilterItem> filters, TextObject name)
	{
		throw null;
	}
}
