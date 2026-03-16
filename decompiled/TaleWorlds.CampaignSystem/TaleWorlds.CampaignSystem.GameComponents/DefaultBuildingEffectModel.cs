using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements.Buildings;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBuildingEffectModel : BuildingEffectModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetBuildingEffect(Building building, BuildingEffectEnum effect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBuildingEffectModel()
	{
		throw null;
	}
}
