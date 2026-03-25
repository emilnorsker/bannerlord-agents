using System;
using System.Collections.Generic;
using System.Linq;
using Bannerlord.GameMaster;
using Bannerlord.GameMaster.Bandits;
using Bannerlord.GameMaster.Clans;
using Bannerlord.GameMaster.Cultures;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using AIInfluence.Util;
using AIInfluence.Behaviors;

namespace AIInfluence;

public static class BlgmNpcParty
{
	public sealed class Result { public bool Ok; public string Err; public Clan Clan; public MobileParty Party; public List<string> Warnings { get; } = new List<string>(); }

	public static bool UseOutlawPath(Hero h, bool force) => h != null && (force || h.Clan?.IsBanditFaction == true
		|| (((h.Culture?.ToCultureFlag() ?? CultureFlags.None) & CultureFlags.AllBanditCultures) != 0));

	public static Result TryOutlawMinorClan(Hero hero, int tier, string clanName, bool leavePlayerClanIfNeeded)
	{
		var r = new Result();
		if (hero == null || hero.IsDead || hero.IsPrisoner) { r.Err = "invalid hero"; return r; }
		if (Campaign.Current == null || !BLGMObjectManager.CampaignFullyLoaded) { r.Err = "BLGM/campaign not ready"; return r; }
		tier = Math.Max(1, Math.Min(tier, 6));
		StripMainParty(hero);
		Clan c = TryMinor(hero, tier, clanName, r);
		if (c == null && leavePlayerClanIfNeeded && hero.Clan == Clan.PlayerClan)
		{
			try { RemoveCompanionAction.ApplyByFire(Clan.PlayerClan, hero); } catch (Exception ex) { r.Err = ex.Message; return r; }
			c = TryMinor(hero, tier, clanName, r);
		}
		if (c == null) { r.Err = r.Err ?? "CreateMinorClan failed"; return r; }
		MobileParty p = hero.PartyBelongedTo;
		if (p != null)
		{
			try { GameVersionCompatibility.ConditionalEnableAi(p); } catch (Exception ex) { r.Warnings.Add(ex.Message); }
			NonCombatantPartyProtector.Instance?.RegisterPartyForProtection(p, hero, "BlgmNpc");
		}
		War(c, hero, r.Warnings);
		r.Ok = true; r.Clan = c; r.Party = p; return r;
	}
	static Clan TryMinor(Hero h, int t, string n, Result r) { try { return ClanGenerator.CreateMinorClan(t, n, h, Cf(h), true, 0); } catch (Exception ex) { r.Err = ex.Message; return null; } }

	static CultureFlags Cf(Hero h)
	{
		var cu = h.Culture;
		if (cu == null) return CultureFlags.AllMainCultures;
		var a = cu.ToCultureFlag();
		if ((a & CultureFlags.AllBanditCultures) != 0) return a;
		var b = BanditHelpers.MapMainCultureToBanditCulture(cu)?.ToCultureFlag() ?? CultureFlags.None;
		return b != CultureFlags.None ? b : (a != CultureFlags.None ? a : CultureFlags.AllMainCultures);
	}

	static void StripMainParty(Hero h)
	{
		if (MobileParty.MainParty == null || PartyBase.MainParty?.MemberRoster == null || h.PartyBelongedTo != MobileParty.MainParty
		    || !PartyBase.MainParty.MemberRoster.Contains(h.CharacterObject)) return;
		PartyBase.MainParty.MemberRoster.RemoveTroop(h.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
		int n = PartyBase.MainParty.MemberRoster.GetTroopCount(h.CharacterObject);
		if (n > 0) PartyBase.MainParty.MemberRoster.RemoveTroop(h.CharacterObject, n, default(UniqueTroopDescriptor), 0);
	}

	static void War(Clan o, Hero h, List<string> w)
	{
		IFaction ps = Clan.PlayerClan?.MapFaction ?? Clan.PlayerClan;
		Vec2 a = h.PartyBelongedTo != null ? GameVersionCompatibility.GetPosition2D(h.PartyBelongedTo) : h.CurrentSettlement != null ? GameVersionCompatibility.GetPosition2D(h.CurrentSettlement) : MobileParty.MainParty != null ? GameVersionCompatibility.GetPosition2D(MobileParty.MainParty) : default;
		IFaction nf = Settlement.All?.Where(s => s != null && !s.IsHideout && s.MapFaction != null && (!(s.MapFaction is Clan bc) || !bc.IsBanditFaction)).OrderBy(s => s.GetPosition2D.DistanceSquared(a)).FirstOrDefault()?.MapFaction;
		try { if (ps != null) o.DeclareWar(ps); } catch (Exception ex) { w.Add(ex.Message); }
		try { if (nf != null && !ReferenceEquals(nf, ps)) o.DeclareWar(nf); } catch (Exception ex) { w.Add(ex.Message); }
	}
}
