using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC.GameComponents;

public class NavalDLCPartyImpairmentModel : PartyImpairmentModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetDisorganizedStateDuration(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetVulnerabilityStateDuration(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSiegeExpectedVulnerabilityTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanGetDisorganized(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCPartyImpairmentModel()
	{
		throw null;
	}
}
