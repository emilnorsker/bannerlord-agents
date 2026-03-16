using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBattleRewardModel : BattleRewardModel
{
	private static readonly int[] _indices;

	private const float DestroyHideoutBannerLootChance = 0.1f;

	private const float CaptureSettlementBannerLootChance = 0.5f;

	private const float DefeatRegularHeroBannerLootChance = 0.5f;

	private const float DefeatClanLeaderBannerLootChance = 0.25f;

	private const float DefeatKingdomRulerBannerLootChance = 0.1f;

	private const float MainPartyMemberScatterChance = 0.1f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPlayerGainedRelationAmount(MapEvent mapEvent, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateRenownGain(PartyBase party, float renownValueOfBattle, float contributionShare)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateMoraleGainVictory(PartyBase party, float renownValueOfBattle, float contributionShare, MapEvent battle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculateGoldLossAfterDefeat(Hero partyLeaderHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override EquipmentElement GetLootedItemFromTroop(CharacterObject character, float targetValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static EquipmentElement GetRandomItem(Equipment equipment, float targetValue = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetExpectedLootedItemValueFromCasualty(Hero winnerPartyLeaderHero, CharacterObject casualtyCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAITradePenalty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMainPartyMemberScatterChance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int CalculatePlunderedGoldAmountFromDefeatedParty(PartyBase defeatedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<KeyValuePair<MapEventParty, float>> GetLootGoldChances(MBReadOnlyList<MapEventParty> winnerParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<KeyValuePair<MapEventParty, float>> GetLootMemberChancesForWinnerParties(MBReadOnlyList<MapEventParty> winnerParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<KeyValuePair<MapEventParty, float>> GetLootPrisonerChances(MBReadOnlyList<MapEventParty> winnerParties, TroopRosterElement prisonerElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBList<KeyValuePair<MapEventParty, float>> GetLootItemChancesForWinnerParties(MBReadOnlyList<MapEventParty> winnerParties, PartyBase defeatedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<KeyValuePair<MapEventParty, float>> GetLootCasualtyChances(MBReadOnlyList<MapEventParty> winnerParties, PartyBase defeatedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateShipDamageAfterDefeat(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<KeyValuePair<Ship, MapEventParty>> DistributeDefeatedPartyShipsAmongWinners(MapEvent mapEvent, MBReadOnlyList<Ship> shipsToLoot, MBReadOnlyList<MapEventParty> winnerParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetBannerLootChanceFromDefeatedHero(Hero defeatedHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ItemObject GetBannerRewardForWinningMapEvent(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSunkenShipMoraleEffect(PartyBase shipOwner, Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber CalculateMoraleChangeOnRoundVictory(PartyBase party, MapEventSide partySide, BattleSideEnum roundWinner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShipSiegeEngineHitMoraleEffect(Ship ship, SiegeEngineType siegeEngineType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Figurehead GetFigureheadLoot(MBReadOnlyList<MapEventParty> defeatedParties, PartyBase defeatedSideLeaderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBReadOnlyList<MapEventParty> GetWinnerPartiesThatCanPlunderGoldFromShips(MBReadOnlyList<MapEventParty> winnerParties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBattleRewardModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultBattleRewardModel()
	{
		throw null;
	}
}
