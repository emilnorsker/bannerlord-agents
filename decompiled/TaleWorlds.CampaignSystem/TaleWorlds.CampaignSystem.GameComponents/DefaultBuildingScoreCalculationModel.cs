using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBuildingScoreCalculationModel : BuildingScoreCalculationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Building GetNextDailyBuilding(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Building GetNextBuilding(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBuildingScoreCalculationModel()
	{
		throw null;
	}
}
