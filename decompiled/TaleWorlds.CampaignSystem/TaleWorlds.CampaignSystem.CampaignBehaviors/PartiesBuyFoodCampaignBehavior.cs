using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PartiesBuyFoodCampaignBehavior : CampaignBehaviorBase
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryBuyingFood(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateFoodCountToBuy(MobileParty mobileParty, float minimumDaysToLast)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BuyFoodInternal(MobileParty mobileParty, Settlement settlement, int numberOfFoodItemsNeededToBuy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BuyFoodForArmy(MobileParty mobileParty, Settlement settlement, float minimumDaysToLast)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HourlyTickParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartiesBuyFoodCampaignBehavior()
	{
		throw null;
	}
}
