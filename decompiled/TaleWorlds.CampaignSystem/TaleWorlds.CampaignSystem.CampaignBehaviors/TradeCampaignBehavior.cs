using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class TradeCampaignBehavior : CampaignBehaviorBase
{
	public enum TradeGoodType
	{
		Grain,
		Wood,
		Meat,
		Wool,
		Cheese,
		Iron,
		Salt,
		Spice,
		Raw_Silk,
		Fish,
		Flax,
		Grape,
		Hides,
		Clay,
		Date_Fruit,
		Bread,
		Beer,
		Wine,
		Tools,
		Pottery,
		Cloth,
		Linen,
		Leather,
		Velvet,
		Saddle_Horse,
		Steppe_Horse,
		Hunter,
		Desert_Horse,
		Charger,
		War_Horse,
		Steppe_Charger,
		Desert_War_Horse,
		Unknown,
		NumberOfTradeItems
	}

	private Dictionary<ItemCategory, float> _numberOfTotalItemsAtGameWorld;

	public const float MaximumTaxRatioForVillages = 1f;

	public const float MaximumTaxRatioForTowns = 0.5f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter campaignGameStarter, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTrade()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DailyTickTown(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMarketStores(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMarkets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TradeCampaignBehavior()
	{
		throw null;
	}
}
