using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultAllianceModel : AllianceModel
{
	private const int _thresholdForCallToWarWallet = 100000;

	private const float SharedWarsEffect = 25f;

	private const int MaxRelationshipEffect = 20;

	private const int PotentialAllyBonus = 5;

	private const int TooPowerfulEffect = 20;

	private static readonly TextObject _sharedWarsText;

	private static readonly TextObject _unsharedWarsText;

	private static readonly TextObject _lackOfCommonEnemiesText;

	private static readonly TextObject _relationText;

	private static readonly TextObject _traitLevelText;

	private static readonly TextObject _receivedTributeText;

	private static readonly TextObject _paidTributeText;

	private static readonly TextObject _threatenedText;

	private static readonly TextObject _townsText;

	private static readonly TextObject _warWithTheirAllyText;

	private static readonly TextObject _allyWithTheirEnemyText;

	private static readonly TextObject _conflictingAllianceText;

	private const int MaxReasonsInExplanation = 3;

	public override CampaignTime MaxDurationOfAlliance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override CampaignTime MaxDurationOfWarParticipation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxNumberOfAlliances
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override CampaignTime DurationForOffers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetCallToWarCost(Kingdom callingKingdom, Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetScoreOfStartingAlliance(Kingdom kingdomDeclaresAlliance, Kingdom kingdomDeclaredAlliance, IFaction evaluatingFaction, out TextObject explanationText, bool includeDescription = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddHonorEffectToExplanationTooltip(int honor, Hero ruler, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddConflictingAlliancesEffectToExplanationTooltip(int enemyAllyEffectOnOurSide, int enemyAllyEffectOnTheirSide, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSharedWarsEffectToExplanationTooltip(int numberOfSharedWars, float sharedWarsEffect, float unsharedWarsEffect, int numberOfWarsOfDeclaredKingdom, int numberOfWarsOfDeclaringKingdom, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddNoWarsEffectToExplanationTooltip(ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTributeEffectToExplanationTooltip(float tributeEffect, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddTooPowerfulEffectToExplanationTooltip(ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddLowRelationEffectToExplanationTooltip(int relationshipEffect, ref ExplainedNumber explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject BuildExplanationForAlliance(Kingdom other, ExplainedNumber tooltip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetAllianceExplanation(ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfProposingStartingAlliance(Clan proposingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfCallingToWar(Kingdom callingKingdom, Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst, IFaction evaluatingFaction, out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfJoiningWar(Kingdom callingKingdom, Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst, IFaction evaluatingFaction, out TextObject reason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfCallingToWar(Clan proposingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetCallToWarCostForCalledKingdom(Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetCallToWarBudgetOfCallingKingdom(Kingdom callingKingdom, Kingdom calledKingdom, Kingdom kingdomToCallToWarAgainst)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultAllianceModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultAllianceModel()
	{
		throw null;
	}
}
