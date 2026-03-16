using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.CampaignSystem.Encyclopedia.Pages;

namespace NavalDLC.Encyclopedia.Pages;

[OverrideEncyclopediaModel(new Type[] { typeof(CharacterObject) })]
public class NavalEncyclopediaUnityPage : DefaultEncyclopediaUnitPage
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<EncyclopediaFilterItem> GetTypeFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalEncyclopediaUnityPage()
	{
		throw null;
	}
}
