using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementEconomyModel : SettlementEconomyModel
{
	private class CategoryValues
	{
		public Dictionary<ItemCategory, int> PriceDict;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CategoryValues()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetValueOfCategory(ItemCategory category)
		{
			throw null;
		}
	}

	private CategoryValues _categoryValues;

	private const int ProsperityLuxuryTreshold = 3000;

	private const float dailyChangeFactor = 0.15f;

	private const float oneMinusDailyChangeFactor = 0.85f;

	private CategoryValues CategoryValuesCache
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (float, float) GetSupplyDemandForCategory(Town town, ItemCategory category, float dailySupply, float dailyDemand, float oldSupply, float oldDemand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDailyDemandForCategory(Town town, ItemCategory category, int extraProsperity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTownGoldChange(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateDailySettlementBudgetForItemCategory(Town town, float demand, ItemCategory category)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDemandChangeFromValue(float purchaseValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetEstimatedDemandForCategory(Town town, ItemData itemData, ItemCategory category)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementEconomyModel()
	{
		throw null;
	}
}
