using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementGarrisonModel : SettlementGarrisonModel
{
	private static readonly TextObject TownWallsText;

	private static readonly TextObject MoraleText;

	private static readonly TextObject FoodShortageText;

	private readonly TextObject SurplusFoodText;

	private readonly TextObject VillageBeingRaided;

	private readonly TextObject VillageLooted;

	private readonly TextObject TownIsUnderSiege;

	private readonly TextObject RetiredText;

	private readonly TextObject PaymentIsLessText;

	private readonly TextObject UnpaidWagesText;

	private readonly TextObject RebellionText;

	private const int MaximumDailyAutoRecruitmentCount = 1;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMaximumDailyAutoRecruitmentCount(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateBaseGarrisonChange(Settlement settlement, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int FindNumberOfTroopsToTakeFromGarrison(MobileParty mobileParty, Settlement settlement, float defaultIdealGarrisonStrengthPerWalledCenter = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int FindNumberOfTroopsToLeaveToGarrison(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMaximumDailyRepairAmount(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementGarrisonModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultSettlementGarrisonModel()
	{
		throw null;
	}
}
