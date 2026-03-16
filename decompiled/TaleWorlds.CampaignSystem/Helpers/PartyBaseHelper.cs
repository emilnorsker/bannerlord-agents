using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Helpers;

public static class PartyBaseHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SortRoster(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetPartySizeText(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject GetPartySizeText(int healtyNumber, int woundedNumber, bool isInspected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetShipSizeText(int shipCount, bool isInspected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float FindPartySizeNormalLimit(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Hero GetCaptainOfTroop(PartyBase affectorParty, CharacterObject affectorCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string PrintRosterContents(TroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject PrintSummarisedItemRoster(ItemRoster items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextObject PrintRegularTroopCategories(TroopRoster roster)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CharacterObject GetVisualPartyLeader(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetSpeedLimitation(ItemRoster partyItemRoster, out ItemObject speedLimitationItem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasFeat(PartyBase party, FeatObject feat)
	{
		throw null;
	}
}
