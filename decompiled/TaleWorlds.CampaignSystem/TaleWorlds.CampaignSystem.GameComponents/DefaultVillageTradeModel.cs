using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultVillageTradeModel : VillageTradeModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float TradeBoundDistanceLimitAsDays(MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Settlement GetTradeBoundToAssignForVillage(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultVillageTradeModel()
	{
		throw null;
	}
}
