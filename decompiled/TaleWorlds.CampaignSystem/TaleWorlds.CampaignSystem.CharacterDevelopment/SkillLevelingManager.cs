using System.Runtime.CompilerServices;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CharacterDevelopment;

public static class SkillLevelingManager
{
	private static ISkillLevelingManager Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnCombatHit(CharacterObject affectorCharacter, CharacterObject affectedCharacter, CharacterObject captain, Hero commander, float speedBonusFromMovement, float shotDifficulty, WeaponComponentData affectorWeapon, float hitPointRatio, CombatXpModel.MissionTypeEnum missionType, bool isAffectorMounted, bool isTeamKill, bool isAffectorUnderCommand, float damageAmount, bool isFatal, bool isSiegeEngineHit, bool isHorseCharge, bool isSneakAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSiegeEngineDestroyed(MobileParty party, SiegeEngineType destroyedSiegeEngine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnWallBreached(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSimulationCombatKill(CharacterObject affectorCharacter, CharacterObject affectedCharacter, PartyBase affectorParty, PartyBase commanderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTradeProfitMade(PartyBase party, int tradeProfit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTradeProfitMade(Hero hero, int tradeProfit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSettlementProjectFinished(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSettlementGoverned(Hero governor, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnInfluenceSpent(Hero hero, float amountSpent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnGainRelation(Hero hero, Hero gainedRelationWith, float relationChange, ChangeRelationAction.ChangeRelationDetail detail = ChangeRelationAction.ChangeRelationDetail.Default)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTroopRecruited(Hero hero, int amount, int tier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnBribeGiven(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnBanditsRecruited(MobileParty mobileParty, CharacterObject bandit, int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnMainHeroReleasedFromCaptivity(float captivityTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnMainHeroTortured()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnMainHeroDisguised(bool isNotCaught)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnRaid(MobileParty attackerParty, ItemRoster lootedItems)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnLoot(MobileParty attackerParty, MobileParty forcedParty, ItemRoster lootedItems, bool attacked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnForceVolunteers(MobileParty attackerParty, PartyBase forcedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnForceSupplies(MobileParty attackerParty, ItemRoster lootedItems, bool attacked)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnPrisonerSell(MobileParty mobileParty, in TroopRoster prisonerRoster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSurgeryApplied(MobileParty party, bool surgerySuccess, int troopTier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTacticsUsed(MobileParty party, float xp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnHideoutSpotted(MobileParty party, PartyBase spottedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTrackDetected(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTravelOnFoot(Hero hero, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTravelOnHorse(Hero hero, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTravelOnWater(Hero hero, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnAIPartiesTravel(Hero hero, bool isCaravanParty, TerrainType currentTerrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnTraverseTerrain(MobileParty mobileParty, TerrainType currentTerrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnBattleEnded(PartyBase party, CharacterObject troop, int excessXp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnHeroHealedWhileWaiting(Hero hero, int healingAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnRegularTroopHealedWhileWaiting(MobileParty mobileParty, int healedTroopCount, float averageTier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnLeadingArmy(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSieging(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnSiegeEngineBuilt(MobileParty mobileParty, SiegeEngineType siegeEngine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnUpgradeTroops(PartyBase party, CharacterObject troop, CharacterObject upgrade, int numberOfTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnPersuasionSucceeded(Hero targetHero, SkillObject skill, PersuasionDifficulty difficulty, int argumentDifficultyBonusCoefficient)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnPrisonBreakEnd(Hero prisonerHero, bool isSucceeded)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnFoodConsumed(MobileParty mobileParty, bool wasStarving)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnAlleyCleared(Alley alley)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnDailyAlleyTick(Alley alley, Hero alleyLeader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnBoardGameWonAgainstLord(Hero lord, BoardGameHelper.AIDifficulty difficulty, bool extraXpGain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnProductionProducedToWarehouse(EquipmentElement production)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnAIPartyLootCasualties(int goldAmount, Hero winnerPartyLeader, PartyBase defeatedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnShipDamaged(Ship ship, float rawDamage, float finalDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnShipRepaired(Ship ship, float repairedHitPoints)
	{
		throw null;
	}
}
