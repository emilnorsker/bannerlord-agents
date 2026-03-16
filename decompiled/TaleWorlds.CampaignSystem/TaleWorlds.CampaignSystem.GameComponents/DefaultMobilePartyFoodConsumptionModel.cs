using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultMobilePartyFoodConsumptionModel : MobilePartyFoodConsumptionModel
{
	private const float MinimumDailyFoodConsumption = 0.01f;

	private static readonly TextObject _partyConsumption;

	public override int NumberOfMenOnMapToEatOneFood
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateDailyBaseFoodConsumptionf(MobileParty party, bool includeDescription = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateDailyFoodConsumptionf(MobileParty party, ExplainedNumber baseConsumption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculatePerkEffects(MobileParty party, ref ExplainedNumber result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool DoesPartyConsumeFood(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMobilePartyFoodConsumptionModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultMobilePartyFoodConsumptionModel()
	{
		throw null;
	}
}
