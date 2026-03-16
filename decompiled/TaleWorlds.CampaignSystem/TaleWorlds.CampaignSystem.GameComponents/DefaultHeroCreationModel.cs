using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultHeroCreationModel : HeroCreationModel
{
	private const int AverageSkillValueForHeroComesOfAge = 112;

	private const int NonCombatantSkillThresholdValue = 100;

	private const float FemaleCombatantChance = 0.6f;

	private const int NoiseValueToAddSkill = 5;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (CampaignTime, CampaignTime) GetBirthAndDeathDay(CharacterObject character, bool createAlive, int age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Settlement GetBornSettlement(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override StaticBodyProperties GetStaticBodyProperties(Hero hero, bool isOffspring, float variationAmount = 0.35f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override FormationClass GetPreferredUpgradeFormation(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Clan GetClan(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CultureObject GetCulture(Hero hero, Settlement bornSettlement, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CharacterObject GetRandomTemplateByOccupation(Occupation occupation, Settlement settlement = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(TraitObject trait, int level)> GetTraitsForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int CalculateTraitValueForHero(Hero hero, TraitObject trait)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Equipment GetCivilianEquipment(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Equipment GetBattleEquipment(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CharacterObject GetCharacterTemplateForOffspring(Hero mother, Hero father, bool isOffspringFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (TextObject firstName, TextObject name) GenerateFirstAndFullName(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(SkillObject, int)> GetDefaultSkillsForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetInheritedSkillValue(Hero hero, SkillObject skillObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(SkillObject, int)> GetInheritedSkillsForHero(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsSkillCombatant(SkillObject skillObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int AddNoiseToSkillValue(int skillValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsHeroCombatant(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultHeroCreationModel()
	{
		throw null;
	}
}
