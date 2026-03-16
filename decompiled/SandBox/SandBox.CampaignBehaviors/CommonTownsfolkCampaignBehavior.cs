using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;

namespace SandBox.CampaignBehaviors;

public class CommonTownsfolkCampaignBehavior : CampaignBehaviorBase
{
	public const float TownsmanSpawnPercentageMale = 0.2f;

	public const float TownsmanSpawnPercentageFemale = 0.15f;

	public const float TownsmanSpawnPercentageLimitedMale = 0.15f;

	public const float TownsmanSpawnPercentageLimitedFemale = 0.1f;

	public const float TownOtherPeopleSpawnPercentage = 0.05f;

	public const float TownsmanSpawnPercentageTavernMale = 0.3f;

	public const float TownsmanSpawnPercentageTavernFemale = 0.1f;

	public const float BeggarSpawnPercentage = 0.33f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSpawnRate(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetConfigValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetProsperityMultiplier(SettlementComponent settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetWeatherEffectMultiplier(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float TimeOfDayPercentage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPeopleToTownTavern(Settlement settlement, Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddPeopleToTownCenter(Settlement settlement, Dictionary<string, int> unusedUsablePointCount, bool isDayTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetActionSetSuffixAndMonsterForItem(string itemId, int race, bool isFemale, out Monster monster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<string, Monster> GetRandomTownsManActionSetAndMonster(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<string, Monster> GetRandomTownsWomanActionSetAndMonster(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsMan(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsManForTavern(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsWomanForTavern(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsManCarryingStuff(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsWoman(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateMaleChild(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateFemaleChild(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateMaleTeenager(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateFemaleTeenager(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateTownsWomanCarryingStuff(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LocationCharacter CreateBroomsWoman(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static LocationCharacter CreateDancer(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LocationCharacter CreateMaleBeggar(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LocationCharacter CreateFemaleBeggar(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CommonTownsfolkCampaignBehavior()
	{
		throw null;
	}
}
