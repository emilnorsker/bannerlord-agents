using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultHeroAgentLocationModel : HeroAgentLocationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool WillBeListedInOverlay(LocationCharacter locationCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Location GetLocationForHero(Hero hero, Settlement settlement, out HeroLocationDetail heroLocationDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultHeroAgentLocationModel()
	{
		throw null;
	}
}
