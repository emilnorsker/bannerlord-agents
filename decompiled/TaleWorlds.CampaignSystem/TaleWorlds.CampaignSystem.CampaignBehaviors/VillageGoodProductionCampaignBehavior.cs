using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class VillageGoodProductionCampaignBehavior : CampaignBehaviorBase
{
	public const float DistributingItemsAtWorldConstant = 1.5f;

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
	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter starter, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DistributeInitialItemsToTowns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateInitialAccumulatedTaxes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickProductions(Settlement settlement, bool initialProductionForTowns = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickGoodProduction(Village village, bool initialProductionForTowns)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickFoodProduction(Village village, bool initialProductionForTowns)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VillageGoodProductionCampaignBehavior()
	{
		throw null;
	}
}
