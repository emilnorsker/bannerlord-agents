using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultVillageProductionCalculatorModel : VillageProductionCalculatorModel
{
	private readonly TextObject _cultureEffect;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateDailyProductionAmount(Village village, ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateDailyFoodProductionAmount(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetIssueEffectOnFoodProduction(Settlement settlement, out float issueEffect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateProductionSpeedOfItemCategory(ItemCategory item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultVillageProductionCalculatorModel()
	{
		throw null;
	}
}
