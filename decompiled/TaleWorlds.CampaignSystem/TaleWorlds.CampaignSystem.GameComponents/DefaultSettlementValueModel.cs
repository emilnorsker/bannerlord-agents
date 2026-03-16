using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementValueModel : SettlementValueModel
{
	private const float BenefitRatioForFaction = 0.33f;

	private const float CastleMultiplier = 1.25f;

	private const float SameMapFactionMultiplier = 1.1f;

	private const float SameCultureMultiplier = 1.1f;

	private const float BeingOwnerMultiplier = 1.1f;

	private const float HavingNoCoastalSettlementMultiplier = 1.4f;

	private const float HavingPortMultiplier = 1.2f;

	private const int SettlementAtWarWithClan = 10240;

	private const int HomeSettlementToOtherClanScore = 10;

	private const int AlreadyOwnerClanScoreForHomeSettlement = 5120;

	private const int SameFactionWithClanScoreForHomeSettlement = 2560;

	private const int SettlementTypeScoreForHomeSettlementTown = 1280;

	private const int SettlementTypeScoreForHomeSettlementCastle = 640;

	private const int SettlementTypeScoreForHomeSettlementVillage = 320;

	private const int MidSettlementDistanceScoreForHomeSettlement = 20;

	private const int SameCultureWithClanCultureScoreForHomeSettlement = 17;

	private const float AlreadyHomeSettlementScoreForHomeSettlement = 4.5f;

	private const float InitialHomeSettlementScoreForHomeSettlement = 3.5f;

	private const int SettlementOwnerClanCultureSameForHomeSettlement = 12;

	private const int NeighborScoreForHomeSettlement = 10;

	private const int ProsperityScoreForHomeSettlement = 5;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetSettlementScoreForBeingHomeSettlementOfClan(Settlement settlement, Clan clan, float maxDistanceOfSettlementsToHomeSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Settlement FindMostSuitableHomeSettlement(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void TryToFindHomeSettlementForClan(Clan clanToConsider, IEnumerable<Settlement> settlementsToConsider, float maxDistance, out Settlement homeSettlement, ref float maxScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float FindFarthestDistanceBetweenSettlementsInClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int CalculateTotalProsperity(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateSettlementBaseValue(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateSettlementValueForFaction(Settlement settlement, IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateSettlementValueForEnemyHero(Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetBaseGeographicalAdvantage(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GeographicalAdvantageForFaction(Settlement settlement, IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementValueModel()
	{
		throw null;
	}
}
