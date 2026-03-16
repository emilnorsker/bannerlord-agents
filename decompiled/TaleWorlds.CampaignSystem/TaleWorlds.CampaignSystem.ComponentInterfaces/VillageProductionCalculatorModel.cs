using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class VillageProductionCalculatorModel : MBGameModel<VillageProductionCalculatorModel>
{
	public abstract float CalculateProductionSpeedOfItemCategory(ItemCategory item);

	public abstract ExplainedNumber CalculateDailyProductionAmount(Village village, ItemObject item);

	public abstract float CalculateDailyFoodProductionAmount(Village village);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected VillageProductionCalculatorModel()
	{
		throw null;
	}
}
