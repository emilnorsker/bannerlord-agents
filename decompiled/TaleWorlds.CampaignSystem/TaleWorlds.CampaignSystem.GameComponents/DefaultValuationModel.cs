using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultValuationModel : ValuationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMilitaryValueOfParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetValueOfTroop(CharacterObject troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetValueOfHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultValuationModel()
	{
		throw null;
	}
}
