using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace Helpers;

public static class HeroHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetLastSeenText(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement GetClosestSettlement(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LordWillConspireWithLord(Hero lord, Hero otherLord, bool suggestingBetrayal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool UnderPlayerCommand(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetTitleInIndefiniteCase(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetCharacterTypeName(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetOccupiedEventReasonText(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<string> OrderHeroesOnPlayerSideByPriority(bool includeArmyLeader = false, bool includePlayerCompanions = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool WillLordAttack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPlayerSalutation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SpawnHeroForTheFirstTime(Hero hero, Settlement spawnSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int DefaultRelation(Hero hero, Hero otherHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsCompanionInPlayerParty(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool NPCPoliticalDifferencesWithNPC(Hero firstNPC, Hero secondNPC)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int NPCPersonalityClashWithNPC(Hero firstNPC, Hero secondNPC)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int TraitHarmony(Hero considerer, TraitObject trait, Hero consideree, bool sensitive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float CalculateReliabilityConstant(Hero hero, float maxValueConstant = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPropertiesToTextObject(this Hero hero, TextObject textObject, string tagName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPropertiesToTextObject(this Settlement settlement, TextObject textObject, string tagName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HeroCanRecruitFromHero(Hero buyerHero, Hero sellerHero, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<CharacterObject> GetVolunteerTroopsOfHeroForRecruitment(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Clan GetRandomClanForNotable(Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetProbabilityForClan(Clan clan, IEnumerable<Settlement> applicableSettlements, Hero notable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignTime GetRandomBirthDayForAge(float age)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetRandomDeathDayAndBirthDay(int deathAge, out CampaignTime birthday, out CampaignTime deathday)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float StartRecruitingMoneyLimit(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float StartRecruitingMoneyLimitForClanLeader(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetPersonalityTraitChangeName(TraitObject traitObject, Hero hero, bool isPositive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement FindASuitableSettlementToTeleportForHero(Hero hero, float minimumScore = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetMoveScoreForHero(Hero hero, Town fief)
	{
		throw null;
	}
}
