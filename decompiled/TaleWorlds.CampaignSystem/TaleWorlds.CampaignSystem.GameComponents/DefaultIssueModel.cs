using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultIssueModel : IssueModel
{
	private static readonly TextObject SettlementIssuesText;

	private static readonly TextObject HeroIssueText;

	private static readonly TextObject RelatedSettlementIssuesText;

	private static readonly TextObject ClanIssuesText;

	public override int IssueOwnerCoolDownInDays
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetIssueDifficultyMultiplier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetIssueEffectsOfSettlement(IssueEffect issueEffect, Settlement settlement, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetIssueEffectOfHero(IssueEffect issueEffect, Hero hero, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetIssueEffectOfClan(IssueEffect issueEffect, Clan clan, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (int, int) GetCausalityForHero(Hero alternativeSolutionHero, IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetFailureRiskForHero(Hero alternativeSolutionHero, IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetDurationOfResolutionForHero(Hero alternativeSolutionHero, IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTroopsRequiredForHero(Hero alternativeSolutionHero, IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (SkillObject, int) GetIssueAlternativeSolutionSkill(Hero hero, IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetIssueEffectOfHeroInternal(IssueEffect issueEffect, Hero hero, ref ExplainedNumber explainedNumber, TextObject customText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanTroopsReturnFromAlternativeSolution()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultIssueModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultIssueModel()
	{
		throw null;
	}
}
