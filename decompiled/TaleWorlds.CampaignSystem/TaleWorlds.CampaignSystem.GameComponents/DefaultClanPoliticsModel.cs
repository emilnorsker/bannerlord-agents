using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultClanPoliticsModel : ClanPoliticsModel
{
	private static readonly TextObject _supporterStr;

	private static readonly TextObject _crimeStr;

	private static readonly TextObject _armyMemberStr;

	private static readonly TextObject _townProjectStr;

	private static readonly TextObject _courtshipPerkStr;

	private static readonly TextObject _mercenaryStr;

	private static readonly TextObject _kingBonusStr;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateInfluenceChange(Clan clan, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateInfluenceChangeInternal(Clan clan, ref ExplainedNumber influenceChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateInfluenceChangeDueToIssues(Clan clan, ref ExplainedNumber influenceChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateInfluenceChangeDueToPolicies(Clan clan, ref ExplainedNumber influenceChange)
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
	public DefaultClanPoliticsModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultClanPoliticsModel()
	{
		throw null;
	}
}
