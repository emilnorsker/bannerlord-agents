using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace Helpers;

public static class FactionHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindPotentialStrength(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Kingdom> GetEnemyKingdoms(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<StanceLink> GetStances(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetPowerRatioToEnemies(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<TextObject> IsFactionNameApplicable(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<bool, string> IsClanNameApplicable(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Tuple<bool, string> IsKingdomNameApplicable(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetPowerRatioToTributePayedKingdoms(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanClanBeGrantedFief(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanPlayerEnterFaction(bool asVassal = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetTotalEnemyKingdomPower(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetTotalTributePayedKingdomsPower(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Army> GetKingdomArmies(IFaction mapFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SettlementProsperityEffectOnGarrisonSizeConstant(Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float SettlementFoodPotentialEffectOnGarrisonSizeConstant(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float OwnerClanEconomyEffectOnGarrisonSizeConstant(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindIdealGarrisonStrengthPerWalledCenter(Kingdom kingdom, Clan clan = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FinishAllRelatedHostileActionsOfNobleToFaction(Hero noble, IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FinishAllRelatedHostileActionsOfFactionToFaction(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FinishAllRelatedHostileActions(Clan clan1, Clan clan2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FinishAllRelatedHostileActions(Kingdom kingdom1, Kingdom kingdom2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdjustFactionStancesForClanJoiningKingdom(Clan joiningClan, Kingdom kingdomToJoin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetTermUsedByOtherFaction(IFaction faction, IFaction otherFaction, bool pejorative)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetFormalNameForFactionCulture(CultureObject factionCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetInformalNameForFactionCulture(CultureObject factionCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetAdjectiveForFactionCulture(CultureObject factionCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetAdjectiveForFaction(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GenerateClanNameforPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDistanceToClosestNonAllyFortificationOfFaction(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Settlement GetMidSettlementOfFaction(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<IFaction> GetPossibleKingdomsToDeclareWar(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<IFaction> GetPossibleKingdomsToDeclarePeace(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Clan> GetAllyMinorFactions(CharacterObject otherCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Clan ChooseHeirClanForFiefs(Clan oldClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsMainClanMemberAvailableForRelocate(Hero hero, out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanPlayerOfferMercenaryService(Kingdom offerKingdom, out List<IFaction> playerWars, out List<IFaction> warsOfFactionToJoin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanPlayerOfferVassalage(Kingdom offerKingdom, out List<IFaction> playerWars, out List<IFaction> warsOfFactionToJoin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMainClanMemberAvailableForRecall(Hero hero, MobileParty targetParty, out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMainClanMemberAvailableForPartyLeaderChange(Hero hero, bool isSend, MobileParty targetParty, out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMainClanMemberAvailableForSendingSettlement(Hero hero, Settlement targetSettlement, out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsMainClanMemberAvailableForSendingSettlementAsGovernor(Hero hero, Settlement settlementOfGovernor, out TextObject explanation)
	{
		throw null;
	}
}
