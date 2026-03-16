using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementFoodModel : SettlementFoodModel
{
	private readonly TextObject ProsperityText;

	private readonly TextObject GarrisonText;

	private readonly TextObject LandsAroundSettlementText;

	private readonly TextObject NormalVillagesText;

	private readonly TextObject RaidedVillagesText;

	private readonly TextObject VillagesUnderSiegeText;

	private readonly TextObject FoodBoughtByCiviliansText;

	private const int FoodProductionPerVillage = 10;

	public override int FoodStocksUpperLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfProsperityToEatOneFood
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMenOnGarrisonToEatOneFood
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int CastleFoodStockUpperLimitBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateTownFoodStocksChange(Town town, bool includeMarketStocks = true, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ExplainedNumber CalculateTownFoodChangeInternal(Town town, bool includeMarketStocks, bool includeDescriptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetSettlementFoodChangeDueToIssues(Town town, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementFoodModel()
	{
		throw null;
	}
}
