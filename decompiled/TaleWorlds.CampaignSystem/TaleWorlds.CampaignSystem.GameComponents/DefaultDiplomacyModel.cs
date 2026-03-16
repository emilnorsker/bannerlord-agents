using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultDiplomacyModel : DiplomacyModel
{
	private struct WarStats
	{
		public float Strength;

		public float ValueOfSettlements;

		public float TotalStrengthOfEnemies;
	}

	private const int DailyValueFactorForTributes = 70;

	private const float ProsperityValueFactor = 50f;

	private const float StrengthFactor = 50f;

	private const float DenarsToInfluenceValue = 0.002f;

	private const float RulingClanToJoinOtherKingdomScore = -100000000f;

	private const float MinStrengthRequiredForFactionToConsiderWar = 500f;

	private const int MinWarPartyRequiredToConsiderWar = 2;

	private const float ClanRichnessEffectMultiplier = 0.15f;

	private const float FirstDegreeNeighborScore = 1f;

	private const float SecondDegreeNeighborScore = 0.2f;

	private const float MaxBenefitValue = 10000000f;

	private const float MeaningfulBenefitValue = 2000000f;

	private const float MinBenefitValue = 10000f;

	private const float DefaultRelationMultiplierForScoreOfWar = -250f;

	private const float SameCultureTownMultiplier = 0.3f;

	private const float MaxAcceptableProsperityValue = 100000f;

	public override int MinimumRelationWithConversationCharacterToJoinKingdom
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int GiftingTownRelationshipBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int GiftingCastleRelationshipBonus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxRelationLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MinRelationLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MaxNeutralRelationLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int MinNeutralRelationLimit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float WarDeclarationScorePenaltyAgainstAllies
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float WarDeclarationScoreBonusAgainstEnemiesOfAllies
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetStrengthThresholdForNonMutualWarsToBeIgnoredToJoinKingdom(Kingdom kingdomToJoin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetClanStrength(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHeroCommandingStrengthForClan(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHeroGoverningStrengthForClan(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetRelationIncreaseFactor(Hero hero1, Hero hero2, float relationChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceAwardForSettlementCapturer(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHourlyInfluenceAwardForBeingArmyMember(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHourlyInfluenceAwardForRaidingEnemyVillage(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHourlyInfluenceAwardForBesiegingEnemyFortification(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfClanToJoinKingdom(Clan clan, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfClanToLeaveKingdom(Clan clan, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfKingdomToGetClan(Kingdom kingdom, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfKingdomToSackClan(Kingdom kingdom, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfMercenaryToJoinKingdom(Clan mercenaryClan, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfMercenaryToLeaveKingdom(Clan mercenaryClan, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfKingdomToHireMercenary(Kingdom kingdom, Clan mercenaryClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfKingdomToSackMercenary(Kingdom kingdom, Clan mercenaryClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfDeclaringPeaceForClan(IFaction factionDeclaresPeace, IFaction factionDeclaredPeace, Clan evaluatingClan, out TextObject reason, bool includeReason = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfDeclaringPeace(IFaction factionDeclaresPeace, IFaction factionDeclaredPeace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetReasonForDeclaringPeace(IFaction factionDeclaresPeace, IFaction factionDeclaredPeace, Clan evaluatingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetWarProgressScore(IFaction factionDeclaresWar, IFaction factionDeclaredWar, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetWarScale(IFaction factionDeclaresWar, IFaction factionDeclaredWar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfDeclaringWar(IFaction factionDeclaresWar, IFaction factionDeclaredWar, Clan evaluatingClan, out TextObject reason, bool includeReason = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetAllianceFactor(IFaction factionDeclaresWar, IFaction factionDeclaredWar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetReasonForDeclaringWar(IFaction factionDeclaresWar, IFaction factionDeclaredWar, Clan evaluatingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float ApplyWarProgressToRiskScore(IFaction factionDeclaresPeace, IFaction factionDeclaredPeace, float riskScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetBenefitAndRiskScoreForPeace(IFaction factionDeclaresPeace, IFaction factionDeclaredPeace, IFaction evaluatingFaction, out float benefitScore, out float riskScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetBenefitAndRiskScoreForWar(IFaction factionDeclaresWar, IFaction factionDeclaredWar, IFaction evaluatingFaction, out float benefitScore, out float riskScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyTributeEffectToBenefitScoreForWar(IFaction factionDeclaresWar, IFaction factionDeclaredWar, IFaction evaluatingFaction, ref float benefitScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScoreOfLettingPartyGo(MobileParty party, MobileParty partyToLetGo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetValueOfHeroForFaction(Hero examinedHero, IFaction targetFaction, bool forMarriage = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRelationCostOfExpellingClanFromKingdom()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfSupportingClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfExpellingClan(Clan proposingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfProposingPeace(Clan proposingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfProposingWar(Clan proposingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceValueOfSupportingClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRelationValueOfSupportingClan()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfAnnexation(Clan proposingClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfChangingLeaderOfArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfDisbandingArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRelationCostOfDisbandingArmy(bool isLeaderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfPolicyProposalAndDisavowal(Clan proposerClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetInfluenceCostOfAbandoningArmy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetPerkEffectsOnKingdomDecisionInfluenceCost(Clan proposingClan, ref ExplainedNumber cost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetBaseRelationBetweenHeroes(Hero hero1, Hero hero2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetBaseRelation(Hero hero1, Hero hero2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetEffectiveRelation(Hero hero1, Hero hero2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetHeroesForEffectiveRelation(Hero hero1, Hero hero2, out Hero effectiveHero1, out Hero effectiveHero2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRelationChangeAfterClanLeaderIsDead(Hero deadLeader, Hero relationHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRelationChangeAfterVotingInSettlementOwnerPreliminaryDecision(Hero supporter, bool hasHeroVotedAgainstOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetPersonalityEffects(ref int effectiveRelation, Hero hero1, Hero effectiveHero2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetTraitEffect(ref int effectiveRelation, Hero hero1, Hero effectiveHero2, TraitObject trait, int effectMagnitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetCharmExperienceFromRelationGain(Hero hero, float relationChange, ChangeRelationAction.ChangeRelationDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override uint GetNotificationColor(ChatNotificationType notificationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float DenarsToInfluence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDecisionMakingThreshold(IFaction consideringFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanSettlementBeGifted(Settlement settlementToGift)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetValueOfSettlementsForFaction(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<BarterGroup> GetBarterGroups()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsPeaceSuitable(IFaction factionDeclaresPeace, IFaction factionDeclaredPeace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetDailyTributeToPay(Clan factionToPay, Clan factionToReceive, out int tributeDurationInDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsClanEligibleToBecomeRuler(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override DiplomacyStance? GetShallowDiplomaticStance(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override DiplomacyStance GetDefaultDiplomaticStance(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsAtConstantWar(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static WarStats CalculateWarStatsForPeace(IFaction faction, IFaction targetFaction, IFaction evaluatingFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static WarStats CalculateWarStatsForWar(IFaction faction, IFaction targetFaction, IFaction evaluatingFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetExposureScoreToOtherFaction(IFaction factionDeclaresWar, IFaction factionDeclaredWar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float CalculateBenefitScore(WarStats faction1Stats, WarStats faction2Stats)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float CalculateRiskScore(WarStats faction1Stats, WarStats faction2Stats)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float AdjustValueOfSettlements(float valueOfSettlements)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetRelationScore(IFaction factionDeclaresWar, IFaction factionDeclaredWar, IFaction evaluatingFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetSameCultureTownScore(IFaction factionDeclaresWar, IFaction factionDeclaredWar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void UpdateOurBenefitMinusOurRiskBasedOnEvaluatingFaction(IFaction evaluatingFaction, ref float ourBenefit, ref float ourRisk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultDiplomacyModel()
	{
		throw null;
	}
}
