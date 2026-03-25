using Bannerlord.GameMaster.Bandits;
using Bannerlord.GameMaster.Cultures;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace AIInfluence;

public static class BlgmOutlawPath
{
	public static bool Use(Hero h, bool force) => h != null && (force || h.Clan?.IsBanditFaction == true
		|| (((h.Culture?.ToCultureFlag() ?? CultureFlags.None) & CultureFlags.AllBanditCultures) != 0));

	public static void StripFromMain(Hero h)
	{
		if (MobileParty.MainParty == null || PartyBase.MainParty?.MemberRoster == null || h.PartyBelongedTo != MobileParty.MainParty
		    || !PartyBase.MainParty.MemberRoster.Contains(h.CharacterObject)) return;
		PartyBase.MainParty.MemberRoster.RemoveTroop(h.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
		int n = PartyBase.MainParty.MemberRoster.GetTroopCount(h.CharacterObject);
		if (n > 0) PartyBase.MainParty.MemberRoster.RemoveTroop(h.CharacterObject, n, default(UniqueTroopDescriptor), 0);
	}
}
