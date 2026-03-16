using System.Runtime.CompilerServices;
using NavalDLC.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace NavalDLC.GameComponents;

public class NavalDLCShipDistributionModel : ShipDistributionModel
{
	private const float CulturePenalty = 0.96f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanPartyTakeShip(PartyBase party, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanSendShipToParty(Ship ship, MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreForPartyShipComposition(MobileParty party, MBReadOnlyList<Ship> shipsToConsider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCShipDistributionModel()
	{
		throw null;
	}
}
