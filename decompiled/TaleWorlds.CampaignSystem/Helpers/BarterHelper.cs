using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.BarterSystem.Barterables;

namespace Helpers;

public static class BarterHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool ItemExistsInBarterables(List<Barterable> barterables, ItemBarterable itemBarterable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<(Barterable barterable, int count)> GetAutoBalanceBarterablesAdd(BarterData barterData, IFaction factionToBalanceFor, IFaction offerer, Hero offererHero, float fulfillRatio = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<(Barterable barterable, int count)> GetAutoBalanceBarterablesToRemove(BarterData barterData, IFaction factionToBalanceFor, IFaction offerer, Hero offererHero)
	{
		throw null;
	}
}
