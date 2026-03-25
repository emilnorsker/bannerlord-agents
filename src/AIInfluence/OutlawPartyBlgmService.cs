using System;
using System.Collections.Generic;
using System.Linq;
using Bannerlord.GameMaster.Bandits;
using Bannerlord.GameMaster.Clans;
using Bannerlord.GameMaster.Cultures;
using Bannerlord.GameMaster;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using AIInfluence.Util;

using AIInfluence.Behaviors;

namespace AIInfluence;

/// <summary>
/// Uses BLGM (Bannerlord.GameMaster) to create minor-faction outlaw clans with lord parties,
/// then declares war on the player faction and the nearest major map faction.
/// </summary>
public static class OutlawPartyBlgmService
{
	public sealed class Result
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public List<string> Warnings { get; } = new List<string>();
		public Clan Clan { get; set; }
		public MobileParty Party { get; set; }
	}

	public static bool ShouldUseOutlawBlgmPath(Hero hero, bool forceOutlaw = false)
	{
		if (hero == null || forceOutlaw)
			return forceOutlaw;
		if (hero.Clan?.IsBanditFaction == true)
			return true;
		CultureFlags cf = hero.Culture != null ? hero.Culture.ToCultureFlag() : CultureFlags.None;
		if (cf == CultureFlags.None)
			return false;
		return (cf & CultureFlags.AllBanditCultures) != 0;
	}

	/// <param name="clanDisplayName">Optional outlaw clan name; defaults to hero-based name in BLGM.</param>
	public static Result TryCreateOutlawMinorClanFromPlayerCompanion(Hero hero, int tier, string clanDisplayName = null)
	{
		var result = new Result();
		if (!ValidateCampaignAndHero(hero, result))
			return result;

		Clan playerClan = Clan.PlayerClan;
		if (playerClan == null)
		{
			SetFail(result, "Outlaw party: player clan is null.");
			return result;
		}

		if (hero.Clan != playerClan)
		{
			SetFail(result, $"Outlaw party: {hero.Name} is not in the player's clan (required for companion outlaw flow).");
			return result;
		}

		tier = Math.Max(1, Math.Min(tier, 6));
		CultureFlags cultureFlags = ResolveCultureFlagsForOutlaw(hero);

		try
		{
			RemoveHeroFromPlayerControl(hero);
			RemoveCompanionAction.ApplyByFire(playerClan, hero);
		}
		catch (Exception ex)
		{
			SetFail(result, "Outlaw party: failed to remove hero from player clan / party: " + ex.Message);
			return result;
		}

		return FinishCreateMinorClan(hero, tier, clanDisplayName, cultureFlags, result);
	}

	/// <summary>Spawn pipeline: hero is not necessarily in the player's clan.</summary>
	public static Result TryCreateOutlawMinorClanForSpawnedHero(Hero hero, int tier, string clanDisplayName = null)
	{
		var result = new Result();
		if (!ValidateCampaignAndHero(hero, result))
			return result;

		tier = Math.Max(1, Math.Min(tier, 6));
		CultureFlags cultureFlags = ResolveCultureFlagsForOutlaw(hero);
		RemoveHeroFromPlayerControl(hero);
		return FinishCreateMinorClan(hero, tier, clanDisplayName, cultureFlags, result);
	}

	private static bool ValidateCampaignAndHero(Hero hero, Result result)
	{
		if (hero == null)
		{
			SetFail(result, "Outlaw party: hero is null.");
			return false;
		}

		if (Campaign.Current == null)
		{
			SetFail(result, "Outlaw party: no active campaign.");
			return false;
		}

		if (!BLGMObjectManager.CampaignFullyLoaded)
		{
			SetFail(result, "Outlaw party: BLGM reports campaign not fully loaded yet.");
			return false;
		}

		if (hero.IsDead || hero.IsPrisoner)
		{
			SetFail(result, $"Outlaw party: {hero.Name} cannot lead a party (dead or prisoner).");
			return false;
		}

		return true;
	}

	private static void SetFail(Result result, string msg)
	{
		result.Error = msg;
		ReportFailure(msg);
	}

	private static Result FinishCreateMinorClan(Hero hero, int tier, string clanDisplayName, CultureFlags cultureFlags, Result result)
	{
		Clan newClan;
		try
		{
			newClan = ClanGenerator.CreateMinorClan(tier, clanDisplayName, hero, cultureFlags, createParty: true, companionCount: 0);
		}
		catch (Exception ex)
		{
			SetFail(result, "Outlaw party: BLGM CreateMinorClan failed: " + ex.Message);
			return result;
		}

		if (newClan == null)
		{
			SetFail(result, "Outlaw party: BLGM CreateMinorClan returned null.");
			return result;
		}

		MobileParty party = hero.PartyBelongedTo;
		if (party == null)
			result.Warnings.Add("Outlaw party: hero has no party after CreateMinorClan.");
		else
		{
			try
			{
				GameVersionCompatibility.ConditionalEnableAi(party);
			}
			catch (Exception ex)
			{
				result.Warnings.Add("Failed to enable party AI: " + ex.Message);
			}

			NonCombatantPartyProtector protector = NonCombatantPartyProtector.Instance;
			if (protector != null)
				protector.RegisterPartyForProtection(party, hero, "OutlawBLGM");
		}

		ApplyOutlawWars(newClan, hero, result.Warnings);

		result.Success = true;
		result.Clan = newClan;
		result.Party = party;
		return result;
	}

	private static CultureFlags ResolveCultureFlagsForOutlaw(Hero hero)
	{
		CultureObject culture = hero.Culture;
		if (culture == null)
			return CultureFlags.AllMainCultures;

		CultureFlags fromHero = culture.ToCultureFlag();
		if ((fromHero & CultureFlags.AllBanditCultures) != 0)
			return fromHero;

		CultureObject mapped = BanditHelpers.MapMainCultureToBanditCulture(culture);
		if (mapped != null)
		{
			CultureFlags banditSide = mapped.ToCultureFlag();
			if (banditSide != CultureFlags.None)
				return banditSide;
		}

		return fromHero != CultureFlags.None ? fromHero : CultureFlags.AllMainCultures;
	}

	private static void RemoveHeroFromPlayerControl(Hero hero)
	{
		if (MobileParty.MainParty == null)
			return;
		if (hero.PartyBelongedTo == MobileParty.MainParty && PartyBase.MainParty?.MemberRoster != null
		    && PartyBase.MainParty.MemberRoster.Contains(hero.CharacterObject))
		{
			PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
			if (PartyBase.MainParty.MemberRoster.Contains(hero.CharacterObject))
			{
				int n = PartyBase.MainParty.MemberRoster.GetTroopCount(hero.CharacterObject);
				if (n > 0)
					PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, n, default(UniqueTroopDescriptor), 0);
			}
		}
		else if (hero.PartyBelongedTo != null && hero.PartyBelongedTo != MobileParty.MainParty)
			hero.PartyBelongedTo.AddElementToMemberRoster(hero.CharacterObject, -1, false);
	}

	private static void ApplyOutlawWars(Clan outlawClan, Hero hero, List<string> warnings)
	{
		IFaction playerSide = Clan.PlayerClan?.MapFaction ?? Clan.PlayerClan;
		Vec2 anchor = hero.PartyBelongedTo != null ? GameVersionCompatibility.GetPosition2D(hero.PartyBelongedTo)
			: hero.CurrentSettlement != null ? GameVersionCompatibility.GetPosition2D(hero.CurrentSettlement)
			: MobileParty.MainParty != null ? GameVersionCompatibility.GetPosition2D(MobileParty.MainParty)
			: default;
		IFaction nearest = ResolveNearestMajorFaction(anchor);

		try
		{
			if (playerSide != null)
				outlawClan.DeclareWar(playerSide);
		}
		catch (Exception ex)
		{
			warnings.Add("Declare war on player faction failed: " + ex.Message);
		}

		if (nearest == null || ReferenceEquals(nearest, playerSide))
			return;

		try
		{
			outlawClan.DeclareWar(nearest);
		}
		catch (Exception ex)
		{
			warnings.Add("Declare war on nearest faction failed: " + ex.Message);
		}
	}

	private static IFaction ResolveNearestMajorFaction(Vec2 pos)
	{
		if (Settlement.All == null)
			return null;
		foreach (Settlement s in Settlement.All
			         .Where(s => s != null && !s.IsHideout && s.MapFaction != null)
			         .OrderBy(s => s.GetPosition2D.DistanceSquared(pos)))
		{
			IFaction f = s.MapFaction;
			if (f is Clan c && c.IsBanditFaction)
				continue;
			return f;
		}
		return null;
	}

	private static void ReportFailure(string message)
	{
		InformationManager.DisplayMessage(new InformationMessage("[AI Influence] " + message, ExtraColors.RedAIInfluence));
		AIInfluenceBehavior.Instance?.LogMessage("[OUTLAW_BLGM] " + message);
	}
}
