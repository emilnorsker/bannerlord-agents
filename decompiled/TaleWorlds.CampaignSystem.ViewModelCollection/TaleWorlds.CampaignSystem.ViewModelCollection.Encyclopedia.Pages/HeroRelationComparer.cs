using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;

public class HeroRelationComparer : IComparer<HeroVM>
{
	private readonly Hero _pageHero;

	private readonly bool _isAscending;

	private readonly bool _showLeadersFirst;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HeroRelationComparer(Hero pageHero, bool isAscending, bool showLeadersFirst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	int IComparer<HeroVM>.Compare(HeroVM x, HeroVM y)
	{
		throw null;
	}
}
