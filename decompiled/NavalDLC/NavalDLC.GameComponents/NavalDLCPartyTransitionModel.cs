using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC.GameComponents;

public class NavalDLCPartyTransitionModel : PartyTransitionModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetTransitionTimeForEmbarking(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetTransitionTimeDisembarking(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetFleetTravelTimeToPoint(MobileParty owner, CampaignVec2 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCPartyTransitionModel()
	{
		throw null;
	}
}
