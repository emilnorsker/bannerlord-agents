using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPartyHealingModel : PartyHealingModel
{
	private const int StarvingEffectHeroes = -19;

	private const int FortificationEffectForHeroes = 8;

	private const int FortificationEffectForRegulars = 10;

	private const int BaseDailyHealingForHeroes = 11;

	private const int DailyHealingForPrisonerHeroes = 20;

	private const int DailyHealingForPrisonerRegulars = 1;

	private const int BaseDailyHealingForTroops = 5;

	private const int SkillEXPFromHealingTroops = 5;

	private const float StarvingWoundedEffectRatio = 0.25f;

	private const float StarvingWoundedEffectRatioForGarrison = 0.1f;

	private const float DriftingWoundedEffectRatio = 0.25f;

	private const float AISurgeonSurvivalMultiplier = 0.25f;

	private const float DoctorsOathMultiplier = 0.1f;

	private static readonly TextObject _starvingText;

	private static readonly TextObject _settlementText;

	private static readonly TextObject _raftStateText;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSurgeryChance(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSiegeBombardmentHitSurgeryChance(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetSurvivalChance(PartyBase party, CharacterObject character, DamageTypes damageType, bool canDamageKillEvenIfBlunt, PartyBase enemyParty = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetSkillXpFromHealingTroop(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetDailyHealingForRegulars(PartyBase party, bool isPrisoners, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetDailyHealingHpForHeroes(PartyBase party, bool isPrisoners, bool includeDescriptions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHeroesEffectedHealingAmount(Hero hero, float healingRate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetBattleEndHealingAmount(PartyBase party, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void AddDoctorsOathSkillBonusForParty(MobileParty enemyParty, ref ExplainedNumber explainedNumber)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSurgeonSurvivalBonus(MobileParty mobileParty, ref ExplainedNumber survivalDenominator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPartyHealingModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultPartyHealingModel()
	{
		throw null;
	}
}
