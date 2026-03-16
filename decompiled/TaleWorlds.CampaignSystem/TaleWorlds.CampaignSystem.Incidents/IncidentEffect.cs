using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Incidents;

public class IncidentEffect
{
	private readonly Func<bool> _condition;

	private readonly Func<List<TextObject>> _consequence;

	private Func<IncidentEffect, List<TextObject>> _hint;

	private Func<List<TextObject>> _customInformation;

	private float _chanceToOccur;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IncidentEffect(Func<bool> condition, Func<List<TextObject>> consequence, Func<IncidentEffect, List<TextObject>> hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TextObject> Consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TextObject> GetHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IncidentEffect WithChance(float chance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IncidentEffect WithCustomInformation(Func<List<TextObject>> customInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IncidentEffect WithHint(Func<IncidentEffect, List<TextObject>> hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect GoldChange(Func<int> amountGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect TraitChange(TraitObject trait, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect BuildingLevelChange(Func<Building> buildingGetter, Func<int> amountGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect SiegeProgressChange(Func<float> amountGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WorkshopProfitabilityChange(Func<Workshop> workshopGetter, float percentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect SkillChange(SkillObject skill, float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect MoraleChange(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect HealthChance(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect RenownChange(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect CrimeRatingChange(Func<IFaction> factionGetter, float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect InfluenceChange(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect SettlementRelationChange(Func<Settlement> settlementGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect TownBoundVillageRelationChange(Func<Town> townGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect TownBoundVillageHearthChange(Func<Town> townGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect VillageHearthChange(Func<Village> villageGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect TownSecurityChange(Func<Town> townGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect HeroRelationChange(Func<Hero> heroGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect TownProsperityChange(Func<Town> townGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect SettlementMilitiaChange(Func<Settlement> settlementGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect InfestNearbyHideout(Func<Settlement> settlementGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroopsRandomly(float percentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroopsRandomly(Func<TroopRosterElement, bool> predicate, Func<int> amountGetter, bool specifyUnitTypeOnHint = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroopsRandomlyWithChanceOfDeath(float percentage, float chanceOfDeathPerUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect BreachSiegeWall(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroopsRandomly(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroopsRandomlyWithChanceOfDeath(int amount, float chanceOfDeathPerUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroop(Func<CharacterObject> characterGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect WoundTroopsRandomlyByChance(float chancePerUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect KillTroopsRandomlyOrderedByTier(Func<TroopRosterElement, bool> predicate, Func<int> amountGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect KillTroopsRandomly(Func<TroopRosterElement, bool> predicate, Func<int> amountGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect KillTroopsRandomlyByChance(float chancePerUnit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect KillTroop(Func<CharacterObject> characterGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect ChangeTroopAmount(Func<CharacterObject> characterGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect UpgradeTroop(Func<CharacterObject> characterGetter, Func<CharacterObject, bool> upgradePredicate, int amount, Func<long> incidentSeedGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect UpgradeTroop(Func<CharacterObject> characterGetter, Func<CharacterObject> upgradedCharacterGetter, int amount, Func<long> incidentSeedGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect RemovePrisonersRandomlyWithPredicate(Func<TroopRosterElement, bool> predicate, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect ChangeItemsAmount(Func<List<ItemObject>> itemsGetter, int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect ChangeItemAmount(Func<ItemObject> itemGetter, Func<int> amountGetter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect PartyExperienceChance(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect DisorganizeParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect HealTroopsRandomly(int amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect DemoteTroopsRandomlyWithPredicate(Func<TroopRosterElement, bool> predicate, Func<CharacterObject, bool> demotionPredicate, int amount, bool specifyUnitTypeOnHint = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool FindTroopToDemoteTo(CharacterObject troop, Func<CharacterObject, bool> demotionPredicate, out CharacterObject troopToDemoteTo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int FindUpgradeDistanceBfs(CharacterObject start, CharacterObject target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect Group(params IncidentEffect[] effects)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect Select(IncidentEffect effectOne, IncidentEffect effectTwo, float chanceOfFirstOne)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IncidentEffect Custom(Func<bool> condition, Func<List<TextObject>> consequence, Func<IncidentEffect, List<TextObject>> hint)
	{
		throw null;
	}
}
