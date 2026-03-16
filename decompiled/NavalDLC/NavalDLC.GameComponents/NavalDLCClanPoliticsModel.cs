using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Election;

namespace NavalDLC.GameComponents;

public class NavalDLCClanPoliticsModel : ClanPoliticsModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateInfluenceChange(Clan clan, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateSupportForPolicyInClan(Clan clan, PolicyObject policy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateRelationshipChangeWithSponsor(Clan clan, Clan sponsorClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceRequiredToOverrideKingdomDecision(DecisionOutcome popularOption, DecisionOutcome overridingOption, KingdomDecision decision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanHeroBeGovernor(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCClanPoliticsModel()
	{
		throw null;
	}
}
