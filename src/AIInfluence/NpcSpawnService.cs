using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AIInfluence;

public class NpcSpawnService
{
	public class SpawnResult
	{
		public Hero Hero { get; set; }
		public MobileParty Party { get; set; }
		public string Error { get; set; }
		public bool Success => Error == null && (Hero != null || Party != null);
	}

	private readonly Action<string> _log;

	public NpcSpawnService(Action<string> log)
	{
		_log = log ?? (_ => { });
	}

	public SpawnResult Spawn(SpawnNpcData data)
	{
		if (data == null)
			return Fail("SpawnNpcData is null");

		bool hasName = !string.IsNullOrWhiteSpace(data.Name);
		bool wantsParty = !string.IsNullOrWhiteSpace(data.PartyName) || (data.PartySize.HasValue && data.PartySize.Value > 0);

		if (!hasName && wantsParty)
			return SpawnSimpleParty(data);

		if (!hasName)
			return Fail("NPC spawn requires a name, or party fields for a simple party");

		return SpawnNpcHero(data);
	}

	private SpawnResult SpawnNpcHero(SpawnNpcData data)
	{
		Settlement settlement = ResolveSettlement(data.Settlement);
		if (settlement == null)
			return Fail("Could not resolve a settlement for NPC spawn");

		Clan clan = ResolveClan(data.Alignment, data.Faction, settlement);
		if (clan == null)
			return Fail("Could not resolve a clan for NPC spawn");

		CharacterObject template = ResolveTemplate(data.Culture, data.Occupation, data.IsFemale, settlement);
		if (template == null)
			return Fail("Could not resolve a character template");

		int age = Math.Max(18, Math.Min(data.Age ?? 30, 70));
		Hero hero = HeroCreator.CreateSpecialHero(template, settlement, clan, null, age);
		if (hero == null)
			return Fail("HeroCreator.CreateSpecialHero returned null");

		TextObject nameText = new TextObject(data.Name, null);
		hero.SetName(nameText, nameText);

		if (data.IsFemale.HasValue)
			hero.IsFemale = data.IsFemale.Value;

		_log($"[NPC_SPAWN] Created hero '{hero.Name}' (id:{hero.StringId}) clan:{clan.Name} settlement:{settlement.Name}");

		MobileParty party = null;
		bool wantsParty = !string.IsNullOrWhiteSpace(data.PartyName) || (data.PartySize.HasValue && data.PartySize.Value > 0);
		if (wantsParty)
		{
			party = SpawnLordParty(hero, data, settlement);
			if (party == null)
				_log("[NPC_SPAWN] Party creation failed; hero placed in settlement instead");
		}

		if (party == null)
		{
			EnterSettlementAction.ApplyForCharacterOnly(hero, settlement);
			_log($"[NPC_SPAWN] Placed hero '{hero.Name}' in settlement '{settlement.Name}'");
		}

		InitializeNpcContext(hero, data);
		return new SpawnResult { Hero = hero, Party = party };
	}

	private SpawnResult SpawnSimpleParty(SpawnNpcData data)
	{
		Settlement settlement = ResolveSettlement(data.Settlement);
		if (settlement == null)
			return Fail("Could not resolve a settlement for simple party");

		Clan clan = ResolveClan(data.Alignment, data.Faction, settlement);
		if (clan == null)
			return Fail("Could not resolve a clan for simple party");

		int troopCount = Math.Max(5, Math.Min(data.PartySize ?? 10, 500));
		string partyName = data.PartyName ?? clan.Name?.ToString() ?? "War Party";
		Vec2 position = settlement.GetPosition2D;

		MobileParty party;
		if (clan.IsBanditFaction)
			party = SpawnBanditParty(clan, position, partyName, data.PartyTroops, troopCount);
		else
			party = SpawnFactionParty(clan, settlement, position, partyName, data.PartyTroops, troopCount);

		if (party == null)
			return Fail("Failed to create simple party");

		_log($"[NPC_SPAWN] Created simple {(clan.IsBanditFaction ? "bandit" : "faction")} party '{partyName}' (id:{party.StringId}) clan:{clan.Name} troops:{party.MemberRoster.TotalManCount}");
		return new SpawnResult { Party = party };
	}

	private MobileParty SpawnLordParty(Hero hero, SpawnNpcData data, Settlement homeSettlement)
	{
		string partyName = data.PartyName ?? $"{hero.Name}'s Party";
		Vec2 position = homeSettlement.GetPosition2D;

		MobileParty party = LordPartyComponent.CreateLordParty(
			"aiinfluence_spawned_" + hero.StringId,
			hero,
			new CampaignVec2(position, true),
			2f,
			homeSettlement,
			hero
		);

		if (party == null)
		{
			_log("[NPC_SPAWN] LordPartyComponent.CreateLordParty returned null");
			return null;
		}

		party.Party.SetCustomName(new TextObject(partyName, null));

		int troopCount = Math.Max(0, Math.Min(data.PartySize ?? 0, 500));
		if (troopCount > 0)
			AddTroopsToParty(party, data.PartyTroops, troopCount, hero.Culture);

		return party;
	}

	private MobileParty SpawnBanditParty(Clan banditClan, Vec2 position, string partyName, List<string> troopNames, int troopCount)
	{
		Hideout hideout = Settlement.All?
			.Where(s => s.IsHideout && s.Hideout != null)
			.OrderBy(s => s.GetPosition2D.Distance(position))
			.Select(s => s.Hideout)
			.FirstOrDefault();

		if (hideout == null)
		{
			_log("[NPC_SPAWN] No hideout found on map for bandit party");
			return null;
		}

		MobileParty party = BanditPartyComponent.CreateBanditParty(
			"aiinfluence_bandit_" + Guid.NewGuid().ToString("N"),
			banditClan,
			hideout,
			false,
			null,
			new CampaignVec2(position, true)
		);

		if (party == null)
		{
			_log("[NPC_SPAWN] BanditPartyComponent.CreateBanditParty returned null");
			return null;
		}

		party.Party.SetCustomName(new TextObject(partyName, null));
		AddTroopsToParty(party, troopNames, troopCount, banditClan.Culture);
		return party;
	}

	private MobileParty SpawnFactionParty(Clan clan, Settlement homeSettlement, Vec2 position, string partyName, List<string> troopNames, int troopCount)
	{
		TroopRoster memberRoster = new TroopRoster((PartyBase)null);
		TroopRoster prisonerRoster = new TroopRoster((PartyBase)null);

		if (clan.Leader == null)
		{
			_log($"[NPC_SPAWN] Clan '{clan.Name}' has no leader; cannot create faction party");
			return null;
		}

		MobileParty party = CustomPartyComponent.CreateCustomPartyWithTroopRoster(
			new CampaignVec2(position, true),
			2f,
			homeSettlement,
			new TextObject(partyName, null),
			clan,
			memberRoster,
			prisonerRoster,
			clan.Leader
		);

		if (party == null)
		{
			_log("[NPC_SPAWN] CustomPartyComponent.CreateCustomPartyWithTroopRoster returned null");
			return null;
		}

		AddTroopsToParty(party, troopNames, troopCount, clan.Culture);
		return party;
	}

	private void AddTroopsToParty(MobileParty party, List<string> troopNames, int totalCount, CultureObject fallbackCulture)
	{
		List<CharacterObject> resolved = new List<CharacterObject>();
		if (troopNames != null)
		{
			foreach (string name in troopNames.Where(n => !string.IsNullOrWhiteSpace(n)).Distinct(StringComparer.OrdinalIgnoreCase))
			{
				CharacterObject troop = ItemMentionParser.FindBestTroopMatch(name);
				if (troop != null)
					resolved.Add(troop);
				else
					_log($"[NPC_SPAWN] Could not resolve troop '{name}'");
			}
		}

		if (resolved.Count == 0 && fallbackCulture?.BasicTroop != null)
			resolved.Add(fallbackCulture.BasicTroop);

		if (resolved.Count == 0)
		{
			_log("[NPC_SPAWN] No troop types resolved");
			return;
		}

		int perType = totalCount / resolved.Count;
		int remainder = totalCount % resolved.Count;
		for (int i = 0; i < resolved.Count; i++)
		{
			int count = perType + (i < remainder ? 1 : 0);
			if (count > 0)
				party.MemberRoster.AddToCounts(resolved[i], count, false, 0, 0, true, -1);
		}
	}

	private void InitializeNpcContext(Hero hero, SpawnNpcData data)
	{
		AIInfluenceBehavior behavior = AIInfluenceBehavior.Instance;
		if (behavior == null)
			return;

		NPCContext context = behavior.GetOrCreateNPCContext(hero);
		if (context == null)
			return;

		if (!string.IsNullOrWhiteSpace(data.Backstory))
			context.AIGeneratedBackstory = data.Backstory;

		if (!string.IsNullOrWhiteSpace(data.Personality))
			context.AIGeneratedPersonality = data.Personality;
	}

	private Settlement ResolveSettlement(string settlementName)
	{
		if (!string.IsNullOrWhiteSpace(settlementName))
		{
			Settlement match = FuzzyMatchSettlement(settlementName);
			if (match != null)
				return match;
			_log($"[NPC_SPAWN] Settlement '{settlementName}' not found, falling back to nearest town");
		}

		Vec2 playerPos = MobileParty.MainParty?.GetPosition2D ?? default;
		return Settlement.All?
			.Where(s => s.IsTown)
			.OrderBy(s => s.GetPosition2D.Distance(playerPos))
			.FirstOrDefault();
	}

	private Settlement FuzzyMatchSettlement(string name)
	{
		string normalized = name.Trim().ToLowerInvariant();

		Settlement exact = Settlement.All?.FirstOrDefault(s =>
			(s.IsTown || s.IsCastle) &&
			s.Name != null && string.Equals(s.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
		if (exact != null)
			return exact;

		Settlement contains = Settlement.All?.FirstOrDefault(s =>
			(s.IsTown || s.IsCastle) &&
			s.Name != null && s.Name.ToString().ToLowerInvariant().Contains(normalized));
		if (contains != null)
			return contains;

		Settlement idMatch = Settlement.All?.FirstOrDefault(s =>
			(s.IsTown || s.IsCastle) &&
			s.StringId != null && s.StringId.ToLowerInvariant().Contains(normalized));
		return idMatch;
	}

	private Clan ResolveClan(string alignment, string factionName, Settlement settlement)
	{
		IFaction playerFaction = Hero.MainHero?.MapFaction;

		if (!string.IsNullOrWhiteSpace(factionName))
		{
			Clan match = FuzzyMatchClan(factionName);
			if (match != null)
			{
				if (!string.IsNullOrWhiteSpace(alignment) && playerFaction != null)
				{
					bool wantsFriendly = alignment.Equals("friendly", StringComparison.OrdinalIgnoreCase);
					bool isFriendly = !match.MapFaction.IsAtWarWith(playerFaction);
					if (wantsFriendly != isFriendly)
						_log($"[NPC_SPAWN] Warning: faction '{factionName}' resolved to '{match.Name}' but alignment is '{alignment}' and faction is {(isFriendly ? "friendly" : "hostile")} to player");
				}
				return match;
			}
			_log($"[NPC_SPAWN] Faction '{factionName}' not found, falling back to alignment-based resolution");
		}

		return ResolveByAlignment(alignment, playerFaction, settlement);
	}

	private Clan ResolveByAlignment(string alignment, IFaction playerFaction, Settlement settlement)
	{
		if (string.IsNullOrWhiteSpace(alignment) || alignment.Equals("neutral", StringComparison.OrdinalIgnoreCase))
			return ValidClanOrFallback(settlement.OwnerClan) ?? Clan.PlayerClan;

		if (alignment.Equals("friendly", StringComparison.OrdinalIgnoreCase))
		{
			if (playerFaction != null && IsValidOwnerClan(settlement.OwnerClan) && !settlement.OwnerClan.MapFaction.IsAtWarWith(playerFaction))
				return settlement.OwnerClan;
			return Clan.PlayerClan;
		}

		if (alignment.Equals("hostile", StringComparison.OrdinalIgnoreCase))
		{
			if (playerFaction == null)
				return Clan.BanditFactions?.FirstOrDefault() ?? settlement.OwnerClan;

			Clan warClan = Clan.All?
				.Where(c => c != null && !c.IsEliminated && !c.IsBanditFaction
					&& c.MapFaction != null && c.MapFaction.IsAtWarWith(playerFaction)
					&& c.Leader != null && c.Leader.IsAlive)
				.OrderBy(c => c.FactionMidSettlement != null
					? c.FactionMidSettlement.GetPosition2D.Distance(settlement.GetPosition2D)
					: float.MaxValue)
				.FirstOrDefault();
			if (warClan != null)
				return warClan;

			return Clan.BanditFactions?.FirstOrDefault();
		}

		_log($"[NPC_SPAWN] Unknown alignment '{alignment}', treating as neutral");
		return settlement.OwnerClan ?? Clan.PlayerClan;
	}

	private static bool IsValidOwnerClan(Clan clan)
	{
		return clan != null && !clan.IsEliminated && clan.Leader != null && clan.Leader.IsAlive && clan.MapFaction != null;
	}

	private static Clan ValidClanOrFallback(Clan clan)
	{
		return IsValidOwnerClan(clan) ? clan : null;
	}

	private Clan FuzzyMatchClan(string name)
	{
		string normalized = name.Trim().ToLowerInvariant();

		Clan exact = Clan.All?.FirstOrDefault(c =>
			c.Name != null && string.Equals(c.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
		if (exact != null)
			return exact;

		Kingdom kingdom = Kingdom.All?.FirstOrDefault(k =>
			k.Name != null && string.Equals(k.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
		if (kingdom != null)
			return kingdom.RulingClan ?? kingdom.Clans?.FirstOrDefault();

		Clan contains = Clan.All?.FirstOrDefault(c =>
			c.Name != null && c.Name.ToString().ToLowerInvariant().Contains(normalized));
		if (contains != null)
			return contains;

		Kingdom kingdomContains = Kingdom.All?.FirstOrDefault(k =>
			k.Name != null && k.Name.ToString().ToLowerInvariant().Contains(normalized));
		if (kingdomContains != null)
			return kingdomContains.RulingClan ?? kingdomContains.Clans?.FirstOrDefault();

		return null;
	}

	private CharacterObject ResolveTemplate(string cultureName, string occupationName, bool? isFemale, Settlement settlement)
	{
		CultureObject culture = ResolveCulture(cultureName, settlement);
		Occupation occupation = ParseOccupation(occupationName);

		CharacterObject template = Campaign.Current?.Models?.HeroCreationModel
			?.GetRandomTemplateByOccupation(occupation, settlement);

		if (template != null && culture != null && template.Culture != culture)
		{
			CharacterObject culturalMatch = CharacterObject.All?
				.Where(c => c.Occupation == occupation && c.Culture == culture
					&& (!isFemale.HasValue || c.IsFemale == isFemale.Value))
				.OrderBy(_ => MBRandom.RandomFloat)
				.FirstOrDefault();
			if (culturalMatch != null)
				template = culturalMatch;
		}

		return template;
	}

	private CultureObject ResolveCulture(string cultureName, Settlement settlement)
	{
		if (!string.IsNullOrWhiteSpace(cultureName))
		{
			CultureObject match = Game.Current?.ObjectManager?.GetObject<CultureObject>(cultureName.ToLowerInvariant());
			if (match != null)
				return match;

			match = Game.Current?.ObjectManager?.GetObjectTypeList<CultureObject>()
				?.FirstOrDefault(c => c.Name != null && c.Name.ToString().IndexOf(cultureName, StringComparison.OrdinalIgnoreCase) >= 0);
			if (match != null)
				return match;
		}

		return settlement?.Culture;
	}

	private static Occupation ParseOccupation(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
			return Occupation.Wanderer;

		if (Enum.TryParse<Occupation>(value, true, out var parsed))
			return parsed;

		return Occupation.Wanderer;
	}

	private SpawnResult Fail(string error)
	{
		_log($"[NPC_SPAWN] {error}");
		return new SpawnResult { Error = error };
	}
}
