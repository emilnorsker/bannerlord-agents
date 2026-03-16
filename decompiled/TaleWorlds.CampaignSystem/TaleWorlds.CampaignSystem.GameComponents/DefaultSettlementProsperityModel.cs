using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementProsperityModel : SettlementProsperityModel
{
	private readonly TextObject SurplusFoodText;

	private readonly TextObject LoyaltyText;

	private static readonly TextObject FoodShortageText;

	private static readonly TextObject ProsperityFromMarketText;

	private static readonly TextObject RaidedText;

	private static readonly TextObject HousingCostsText;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateProsperityChange(Town fortification, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateHearthChange(Village village, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateHearthChangeInternal(Village village, ref ExplainedNumber result, bool includeDescriptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateProsperityChangeInternal(Town fortification, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetSettlementProsperityChangeDueToIssues(Settlement settlement, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementProsperityModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultSettlementProsperityModel()
	{
		throw null;
	}
}
