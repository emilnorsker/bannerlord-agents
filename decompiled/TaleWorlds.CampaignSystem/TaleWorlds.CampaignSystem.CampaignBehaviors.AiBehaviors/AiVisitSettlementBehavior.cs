using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors.AiBehaviors;

public class AiVisitSettlementBehavior : CampaignBehaviorBase
{
	private readonly struct SettlementNavigationData : IComparable<SettlementNavigationData>
	{
		public readonly float Distance;

		public readonly int SettlementIdentifier;

		public readonly Settlement Settlement;

		public readonly MobileParty.NavigationType BestNavigationType;

		public readonly bool IsFromPort;

		public readonly bool IsTargetingPortBetter;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SettlementNavigationData(float distance, int settlementIdentifier, Settlement settlement, MobileParty.NavigationType bestNavigationType, bool isFromPort, bool isTargetingPortBetter)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int CompareTo(SettlementNavigationData otherSettlementNavigationData)
		{
			throw null;
		}
	}

	public const float GoodEnoughScore = 8f;

	public const float MeaningfulScoreThreshold = 0.025f;

	public const float BaseVisitScore = 1.6f;

	private const float DefaultMoneyLimitForRecruiting = 2000f;

	private readonly List<SettlementNavigationData> _settlementsNavigationData;

	private IDisbandPartyCampaignBehavior _disbandPartyCampaignBehavior;

	private static float SearchForNeutralSettlementRadiusAsDays
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float NumberOfHoursAtDay
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float IdealTimePeriodForVisitingOwnedSettlement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetMaximumDistanceAsDays(MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float MaximumMeaningfulDistanceAsDays(MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AiHourlyTick(MobileParty mobileParty, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (int, float) GetApproximateVolunteersCanBeRecruitedDataFromSettlement(Hero hero, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateSellItemScore(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (float, float, int, int) CalculatePartyParameters(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CalculateVisitHideoutScoresForBanditParty(MobileParty mobileParty, Settlement currentSettlement, PartyThinkParams p)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (float, float, float, float) CalculateBeingSettlementOwnerScores(MobileParty mobileParty, Settlement settlement, Settlement currentSettlement, float idealGarrisonStrengthPerWalledCenter, float distanceScorePure, float averagePartySizeRatioToMaximumSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateMergeScoreForDisbandingParty(MobileParty disbandParty, Settlement settlement, float distanceAsDays)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateMergeScoreForLeaderlessParty(MobileParty leaderlessParty, Settlement settlement, float distanceAsDays, out bool canMerge)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void FillSettlementsToVisitWithDistancesAsDays(MobileParty mobileParty, List<SettlementNavigationData> listToFill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetBestNavigationDataForVisitingSettlement(MobileParty mobileParty, Settlement settlement, out MobileParty.NavigationType bestNavigationType, out float distanceAsDays, out bool isFromPort, out bool isTargetingPortBetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddBehaviorTupleWithScore(PartyThinkParams p, Settlement settlement, float visitingNearbySettlementScore, MobileParty.NavigationType navigationType, bool isFromPort, bool isTargetingPortBetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsSettlementSuitableForVisitingCondition(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AiVisitSettlementBehavior()
	{
		throw null;
	}
}
