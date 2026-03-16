using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace Helpers;

public static class MobilePartyHelper
{
	public delegate void ResumePartyEscortBehaviorDelegate();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MobileParty SpawnLordParty(Hero hero, Settlement spawnSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MobileParty SpawnLordParty(Hero hero, CampaignVec2 position, float spawnRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MobileParty SpawnLordPartyAux(Hero hero, CampaignVec2 position, float spawnRadius, Settlement spawnSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MobileParty CreateNewClanMobileParty(Hero hero, Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHeroAssignableForScoutInParty(Hero hero, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHeroAssignableForEngineerInParty(Hero hero, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHeroAssignableForSurgeonInParty(Hero hero, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsHeroAssignableForQuartermasterInParty(Hero hero, MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GetHeroWithHighestSkill(MobileParty party, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopRoster GetStrongestAndPriorTroops(MobileParty mobileParty, int maxTroopCount, bool includePlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopRoster GetStrongestAndPriorTroops(FlattenedTroopRoster roster, int maxTroopCount, bool includePlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMaximumXpAmountPartyCanGet(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PartyAddSharedXp(MobileParty party, float xpToDistribute)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WoundNumberOfNonHeroTroopsRandomlyWithChanceOfDeath(TroopRoster roster, int numberOfMen, float chanceOfDeathPerUnit, out int deathAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanTroopGainXp(PartyBase owner, CharacterObject character, out int gainableMaxXp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TryMatchPartySpeedWithItemWeight(MobileParty party, float targetPartySpeed, ItemObject itemToUse = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GetMainPartySkillCounsellor(SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement GetCurrentSettlementOfMobilePartyForAICalculation(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopRoster GetPlayerPrisonersPlayerCanSell()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FillPartyManuallyAfterCreation(MobileParty mobileParty, PartyTemplateObject partyTemplate, int desiredMenCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanPartyAttackWithCurrentMorale(MobileParty mobileParty)
	{
		throw null;
	}
}
