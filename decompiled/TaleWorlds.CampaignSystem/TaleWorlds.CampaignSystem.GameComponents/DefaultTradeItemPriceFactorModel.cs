using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultTradeItemPriceFactorModel : TradeItemPriceFactorModel
{
	private const float MinPriceFactor = 0.1f;

	private const float MaxPriceFactor = 10f;

	private const float MinPriceFactorNonTrade = 0.8f;

	private const float MaxPriceFactorNonTrade = 1.3f;

	private const float HighTradePenaltyBaseValue = 1.5f;

	private const float PackAnimalTradePenalty = 0.8f;

	private const float MountTradePenalty = 0.8f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetTradePenalty(ItemObject item, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStore, float supply, float demand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetPriceFactor(ItemObject item, MobileParty tradingParty, PartyBase merchant, float inStoreValue, float supply, float demand, bool isSelling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetBasePriceFactor(ItemCategory itemCategory, float inStoreValue, float supply, float demand, bool isSelling, int transferValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTheoreticalMaxItemMarketValue(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultTradeItemPriceFactorModel()
	{
		throw null;
	}
}
