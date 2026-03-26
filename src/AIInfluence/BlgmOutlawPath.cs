using Bannerlord.GameMaster.Bandits;
using Bannerlord.GameMaster.Cultures;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace AIInfluence;

public static class BlgmOutlawPath
{
	public static bool Use(Hero hero, bool forceOutlawMinorClan) => hero != null && (forceOutlawMinorClan || hero.Clan?.IsBanditFaction == true
		|| (((hero.Culture?.ToCultureFlag() ?? CultureFlags.None) & CultureFlags.AllBanditCultures) != 0));

	public static void StripFromMain(Hero hero)
	{
		if (MobileParty.MainParty == null || PartyBase.MainParty?.MemberRoster == null || hero.PartyBelongedTo != MobileParty.MainParty
		    || !PartyBase.MainParty.MemberRoster.Contains(hero.CharacterObject)) return;
		PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
		int remainingSameTroopCount = PartyBase.MainParty.MemberRoster.GetTroopCount(hero.CharacterObject);
		if (remainingSameTroopCount > 0)
			PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, remainingSameTroopCount, default(UniqueTroopDescriptor), 0);
	}
}
