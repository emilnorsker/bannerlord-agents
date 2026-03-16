using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultTradeAgreementModel : TradeAgreementModel
{
	private const float FirstDegreeNeighborScore = 1.6f;

	private const float SecondDegreeNeighborScore = 0.3f;

	private const float MaxPeaceDurationBonus = 20f;

	private const float RelationshipMultiplier = 0.25f;

	private const float MaxAssumedExposureBonus = 40f;

	private static readonly TextObject _kingdomsAtWarText;

	private static readonly TextObject _eliminatedKingdomText;

	private static readonly TextObject _existingTradeAgreementText;

	private static readonly TextObject _maximumNumberOfTradeAgreementsText;

	private static readonly TextObject _limitedSharerBordersText;

	private static readonly TextObject _relationsText;

	private static readonly TextObject _recentWarText;

	private const int MaxReasonsInExplanation = 3;

	private ITradeAgreementsCampaignBehavior _tradeAgreementsBehavior;

	private ITradeAgreementsCampaignBehavior TradeAgreementsCampaignBehavior
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfProposingTradeAgreement(Clan proposerClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMaximumTradeAgreementCount(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanMakeTradeAgreement(Kingdom kingdom, Kingdom other, bool checkOtherSideTradeSupport, out TextObject reason, bool includeReason = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfStartingTradeAgreement(Kingdom kingdom, Kingdom targetKingdom, Clan clan, out TextObject explanation, bool includeExplanation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddExposureEffectToTradeAgreementExplanationTooltip(float exposure, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRelationshipEffectToTradeAgreementExplanationTooltip(float relationshipScore, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRecentWarEffectToTradeAgreementExplanationTooltip(float warScore, CampaignTime peaceDeclarationDate, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject BuildExplanationForTradeAgreement(Kingdom other, ExplainedNumber tooltip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetTradeAgreementExplanation(ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetTradeAgreementDurationInYears(Kingdom iniatatingKingdom, Kingdom otherKingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetExposureScoreToOtherKingdom(Kingdom kingdom1, Kingdom kingdom2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultTradeAgreementModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultTradeAgreementModel()
	{
		throw null;
	}
}
