using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartyTransitionModel : PartyTransitionModel
{
	private const float MinHoursToMoveAnchor = 1f;

	private const float MaxHoursToMoveAnchor = 6f;

	private const float InstantEmbarkDistanceThreshold = 20f;

	private const float DisembarkHours = 2f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetFleetTravelTimeToPoint(MobileParty mobileParty, CampaignVec2 target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetTransitionTimeDisembarking(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetTransitionTimeForEmbarking(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartyTransitionModel()
	{
		throw null;
	}
}
