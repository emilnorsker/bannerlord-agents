using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class SellGoodsForTradeAction
{
	private enum SellGoodsForTradeActionDetail
	{
		VillagerTrade,
		LordTrade
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Settlement settlement, MobileParty mobileParty, SellGoodsForTradeActionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByVillagerTrade(Settlement settlement, MobileParty villagerParty)
	{
		throw null;
	}
}
