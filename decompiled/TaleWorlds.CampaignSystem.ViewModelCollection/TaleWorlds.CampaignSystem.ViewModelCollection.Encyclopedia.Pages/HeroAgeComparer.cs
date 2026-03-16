using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;

public class HeroAgeComparer : IComparer<HeroVM>
{
	private readonly bool _isAscending;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HeroAgeComparer(bool isAscending)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	int IComparer<HeroVM>.Compare(HeroVM x, HeroVM y)
	{
		throw null;
	}
}
