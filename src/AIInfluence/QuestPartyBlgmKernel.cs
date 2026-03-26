using System;
using System.Linq;
using Bannerlord.GameMaster.Bandits;
using Bannerlord.GameMaster.Clans;
using Bannerlord.GameMaster.Characters;
using Bannerlord.GameMaster.Cultures;
using Bannerlord.GameMaster.Heroes;
using Bannerlord.GameMaster.Kingdoms;
using Bannerlord.GameMaster.Party;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using AIInfluence.Util;

namespace AIInfluence;
public static class QuestPartyBlgmKernel
{
	public struct R { public Hero Hero; public MobileParty Party; public string Err; }

	public static R Run(SpawnPartyData d, Settlement a)
	{
		var x = new R();
		if (d == null || a == null) { x.Err = "null"; return x; }
		if (!string.IsNullOrWhiteSpace(d.TargetHeroStringId))
		{
			x.Hero = HeroQueries.GetHeroById(d.TargetHeroStringId.Trim().ToLowerInvariant());
			if (x.Hero != null) { x.Party = x.Hero.PartyBelongedTo; return x; }
		}
		if (!string.IsNullOrWhiteSpace(d.TargetHeroQuery))
		{
			x.Hero = HeroQueries.QueryHeroes(d.TargetHeroQuery.Trim()).FirstOrDefault();
			if (x.Hero != null) { x.Party = x.Hero.PartyBelongedTo; return x; }
		}
		if (!string.IsNullOrWhiteSpace(d.TargetHeroStringId) || !string.IsNullOrWhiteSpace(d.TargetHeroQuery)) { x.Err = "hero"; return x; }
		bool want = !string.IsNullOrWhiteSpace(d.PartyName) || (d.PartySize ?? 0) > 0;
		if (string.IsNullOrWhiteSpace(d.Name))
		{
			if (!want) { x.Err = "no name"; return x; }
			x.Party = MobilePartyGenerator.CreateLooterParty(a, null);
			return x.Party == null ? new R { Err = "looter" } : new R { Party = x.Party };
		}
		CultureObject cu = Game.Current?.ObjectManager?.GetObject<CultureObject>(d.Culture?.ToLowerInvariant() ?? "") ?? a.Culture;
		CultureFlags cf = (cu?.ToCultureFlag() ?? CultureFlags.None) != CultureFlags.None ? cu.ToCultureFlag() : CultureFlags.AllMainCultures;
		GenderFlags gf = d.IsFemale == true ? GenderFlags.Female : d.IsFemale == false ? GenderFlags.Male : GenderFlags.Either;
		int ag = d.Age ?? -1;
		if (d.IsOutlaw == true)
		{
			Hero lead = d.InternalOutlawLeader;
			Clan mc = ClanGenerator.CreateMinorClan(2, d.PartyName ?? d.Name, lead, BanditHelpers.MapMainCultureToBanditCulture(cu)?.ToCultureFlag() ?? cf, true, 0);
			if (mc?.Leader == null) { x.Err = "minor"; return x; }
			if (lead == null) mc.Leader.SetName(new TextObject(d.Name), new TextObject(d.Name));
			x.Hero = mc.Leader; x.Party = x.Hero.PartyBelongedTo;
			War(mc, x.Hero); AddT(x.Party, d, cu); return x;
		}
		Kingdom k = KingdomQueries.QueryKingdoms(d.Faction?.Trim() ?? "").FirstOrDefault();
		if (k == null) { x.Err = "kingdom"; return x; }
		Clan c = k.Clans?.FirstOrDefault(z => z != null && !z.IsEliminated && z.Leader != null) ?? k.RulingClan;
		if (c == null) { x.Err = "clan"; return x; }
		x.Hero = HeroGenerator.CreateLord(d.Name.Trim(), k.Culture?.ToCultureFlag() ?? cf, gf, c, true, a, 0.5f, -1, ag, true);
		x.Party = x.Hero?.PartyBelongedTo; AddT(x.Party, d, c.Culture ?? cu); return x.Hero == null ? new R { Err = "lord" } : x;
	}
	static void War(Clan o, Hero h)
	{
		IFaction p = Clan.PlayerClan?.MapFaction ?? Clan.PlayerClan;
		Vec2 v = h.PartyBelongedTo != null ? GameVersionCompatibility.GetPosition2D(h.PartyBelongedTo) : h.CurrentSettlement != null ? GameVersionCompatibility.GetPosition2D(h.CurrentSettlement) : MobileParty.MainParty != null ? GameVersionCompatibility.GetPosition2D(MobileParty.MainParty) : default;
		IFaction n = Settlement.All?.Where(s => s != null && !s.IsHideout && s.MapFaction != null && (!(s.MapFaction is Clan b) || !b.IsBanditFaction)).OrderBy(s => s.GetPosition2D.DistanceSquared(v)).FirstOrDefault()?.MapFaction;
		try
		{
			if (p != null) ClanExtensions.DeclareWar(o, p);
			if (n != null && !ReferenceEquals(n, p)) ClanExtensions.DeclareWar(o, n);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[QuestPartyBlgmKernel] DeclareWar failed: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	static void AddT(MobileParty p, SpawnPartyData d, CultureObject cu)
	{
		if (p == null || cu?.BasicTroop == null) return;
		int n = Math.Max(0, Math.Min(d.PartySize ?? 0, 5000)) - p.MemberRoster.TotalManCount;
		if (n > 0) p.MemberRoster.AddToCounts(cu.BasicTroop, n, false, 0, 0, true, -1);
	}
}
