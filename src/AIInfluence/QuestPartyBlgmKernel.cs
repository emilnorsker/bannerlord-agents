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
	public readonly struct QuestPartySpawnOutcome
	{
		public Hero Hero { get; init; }
		public MobileParty Party { get; init; }
		public string ErrorToken { get; init; }
	}

	public static QuestPartySpawnOutcome Run(SpawnPartyData spawnData, Settlement anchorSettlement)
	{
		if (spawnData == null || anchorSettlement == null)
			return new QuestPartySpawnOutcome { ErrorToken = "null" };
		if (!string.IsNullOrWhiteSpace(spawnData.TargetHeroStringId))
		{
			Hero existingById = HeroQueries.GetHeroById(spawnData.TargetHeroStringId.Trim().ToLowerInvariant());
			if (existingById != null)
				return new QuestPartySpawnOutcome { Hero = existingById, Party = existingById.PartyBelongedTo };
		}
		if (!string.IsNullOrWhiteSpace(spawnData.TargetHeroQuery))
		{
			Hero existingByQuery = HeroQueries.QueryHeroes(spawnData.TargetHeroQuery.Trim()).FirstOrDefault();
			if (existingByQuery != null)
				return new QuestPartySpawnOutcome { Hero = existingByQuery, Party = existingByQuery.PartyBelongedTo };
		}
		if (!string.IsNullOrWhiteSpace(spawnData.TargetHeroStringId) || !string.IsNullOrWhiteSpace(spawnData.TargetHeroQuery))
			return new QuestPartySpawnOutcome { ErrorToken = "hero" };
		bool wantsAnonymousParty = !string.IsNullOrWhiteSpace(spawnData.PartyName) || (spawnData.PartySize ?? 0) > 0;
		if (string.IsNullOrWhiteSpace(spawnData.Name))
		{
			if (!wantsAnonymousParty)
				return new QuestPartySpawnOutcome { ErrorToken = "no name" };
			MobileParty looterParty = MobilePartyGenerator.CreateLooterParty(anchorSettlement, null);
			return looterParty == null
				? new QuestPartySpawnOutcome { ErrorToken = "looter" }
				: new QuestPartySpawnOutcome { Party = looterParty };
		}
		CultureObject culture = Game.Current?.ObjectManager?.GetObject<CultureObject>(spawnData.Culture?.ToLowerInvariant() ?? "") ?? anchorSettlement.Culture;
		CultureFlags cultureFlags = (culture?.ToCultureFlag() ?? CultureFlags.None) != CultureFlags.None
			? culture.ToCultureFlag()
			: CultureFlags.AllMainCultures;
		GenderFlags genderFlags = spawnData.IsFemale == true ? GenderFlags.Female : spawnData.IsFemale == false ? GenderFlags.Male : GenderFlags.Either;
		int ageYears = spawnData.Age ?? -1;
		if (spawnData.IsOutlaw == true)
		{
			Hero outlawLeaderHero = spawnData.InternalOutlawLeader;
			Clan outlawMinorClan = ClanGenerator.CreateMinorClan(2, spawnData.PartyName ?? spawnData.Name, outlawLeaderHero,
				BanditHelpers.MapMainCultureToBanditCulture(culture)?.ToCultureFlag() ?? cultureFlags, true, 0);
			if (outlawMinorClan?.Leader == null)
				return new QuestPartySpawnOutcome { ErrorToken = "minor" };
			if (outlawLeaderHero == null)
				outlawMinorClan.Leader.SetName(new TextObject(spawnData.Name), new TextObject(spawnData.Name));
			Hero leaderHero = outlawMinorClan.Leader;
			MobileParty leaderParty = leaderHero.PartyBelongedTo;
			DeclareWarOnPlayerAndNearestNonBanditFaction(outlawMinorClan, leaderHero, anchorSettlement);
			AddBasicTroopPaddingToParty(leaderParty, spawnData, culture);
			return new QuestPartySpawnOutcome { Hero = leaderHero, Party = leaderParty };
		}
		Kingdom targetKingdom = KingdomQueries.QueryKingdoms(spawnData.Faction?.Trim() ?? "").FirstOrDefault();
		if (targetKingdom == null)
			return new QuestPartySpawnOutcome { ErrorToken = "kingdom" };
		Clan kingdomClan = targetKingdom.Clans?.FirstOrDefault(candidateClan => candidateClan != null && !candidateClan.IsEliminated && candidateClan.Leader != null)
			?? targetKingdom.RulingClan;
		if (kingdomClan == null)
			return new QuestPartySpawnOutcome { ErrorToken = "clan" };
		Hero spawnedLord = HeroGenerator.CreateLord(spawnData.Name.Trim(), targetKingdom.Culture?.ToCultureFlag() ?? cultureFlags, genderFlags, kingdomClan, true, anchorSettlement, 0.5f, -1, ageYears, true);
		if (spawnedLord == null)
			return new QuestPartySpawnOutcome { ErrorToken = "lord" };
		MobileParty lordParty = spawnedLord.PartyBelongedTo;
		AddBasicTroopPaddingToParty(lordParty, spawnData, kingdomClan.Culture ?? culture);
		return new QuestPartySpawnOutcome { Hero = spawnedLord, Party = lordParty };
	}

	/// <param name="spawnAnchorSettlement">Map reference when the hero has no party, settlement, or main party position.</param>
	static void DeclareWarOnPlayerAndNearestNonBanditFaction(Clan outlawClan, Hero warAnchorHero, Settlement spawnAnchorSettlement)
	{
		IFaction playerFaction = Clan.PlayerClan?.MapFaction ?? Clan.PlayerClan;
		Vec2 referencePosition = warAnchorHero.PartyBelongedTo != null ? GameVersionCompatibility.GetPosition2D(warAnchorHero.PartyBelongedTo)
			: warAnchorHero.CurrentSettlement != null ? GameVersionCompatibility.GetPosition2D(warAnchorHero.CurrentSettlement)
			: MobileParty.MainParty != null ? GameVersionCompatibility.GetPosition2D(MobileParty.MainParty)
			: spawnAnchorSettlement != null ? GameVersionCompatibility.GetPosition2D(spawnAnchorSettlement)
			: default;
		IFaction nearestMajorFaction = Settlement.All
			?.Where(candidateSettlement => candidateSettlement != null && !candidateSettlement.IsHideout && candidateSettlement.MapFaction != null
				&& (!(candidateSettlement.MapFaction is Clan banditClan) || !banditClan.IsBanditFaction))
			.OrderBy(candidateSettlement => candidateSettlement.GetPosition2D.DistanceSquared(referencePosition))
			.FirstOrDefault()?.MapFaction;
		try
		{
			if (playerFaction != null)
				ClanExtensions.DeclareWar(outlawClan, playerFaction);
			if (nearestMajorFaction != null && !ReferenceEquals(nearestMajorFaction, playerFaction))
				ClanExtensions.DeclareWar(outlawClan, nearestMajorFaction);
		}
		catch (Exception exception)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[QuestPartyBlgmKernel] DeclareWar failed: " + exception.Message + "\n" + exception.StackTrace);
		}
	}

	static void AddBasicTroopPaddingToParty(MobileParty party, SpawnPartyData spawnData, CultureObject troopCulture)
	{
		if (party == null || troopCulture?.BasicTroop == null)
			return;
		int troopsToAdd = Math.Max(0, Math.Min(spawnData.PartySize ?? 0, 5000)) - party.MemberRoster.TotalManCount;
		if (troopsToAdd > 0)
			party.MemberRoster.AddToCounts(troopCulture.BasicTroop, troopsToAdd, false, 0, 0, true, -1);
	}
}
