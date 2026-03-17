using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Extensions;
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
		public string Warning { get; set; }
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

		if (!hasName && WantsParty(data))
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

		if (data.Equipment != null)
			ApplyEquipmentOverrides(hero, data.Equipment);

		_log($"[NPC_SPAWN] Created hero '{hero.Name}' (id:{hero.StringId}) clan:{clan.Name} settlement:{settlement.Name}");

		MobileParty party = null;
		string warning = null;
		if (WantsParty(data))
		{
			party = SpawnLordParty(hero, data, settlement);
			if (party == null)
			{
				warning = "Party creation failed; hero placed in settlement instead";
				_log("[NPC_SPAWN] " + warning);
			}
		}

		if (party == null)
		{
			EnterSettlementAction.ApplyForCharacterOnly(hero, settlement);
			_log($"[NPC_SPAWN] Placed hero '{hero.Name}' in settlement '{settlement.Name}'");
		}

		InitializeNpcContext(hero, data);
		return new SpawnResult { Hero = hero, Party = party, Warning = warning };
	}

	private SpawnResult SpawnSimpleParty(SpawnNpcData data)
	{
		Settlement settlement = ResolveSettlement(data.Settlement);
		if (settlement == null)
			return Fail("Could not resolve a settlement for simple party");

		Clan clan = ResolveClan(data.Alignment, data.Faction, settlement);
		if (clan == null)
			return Fail("Could not resolve a clan for simple party");

		int troopCount = Math.Max(1, Math.Min(data.PartySize ?? 10, 5000));
		string partyName = data.PartyName ?? clan.Name?.ToString() ?? "War Party";
		CampaignVec2 gatePos = settlement.GatePosition;
		Vec2 position = gatePos.ToVec2();

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
		CampaignVec2 spawnPosition = homeSettlement.GatePosition;

		MobileParty party = LordPartyComponent.CreateLordParty(
			"aiinfluence_spawned_" + hero.StringId,
			hero,
			spawnPosition,
			0f,
			homeSettlement,
			hero
		);

		if (party == null)
		{
			_log("[NPC_SPAWN] LordPartyComponent.CreateLordParty returned null");
			return null;
		}

		party.Party.SetCustomName(new TextObject(partyName, null));

		int troopCount = Math.Max(0, Math.Min(data.PartySize ?? 0, 5000));
		if (troopCount > 0)
			AddTroopsToParty(party, data.PartyTroops, troopCount, hero.Culture);

		return party;
	}

	private MobileParty SpawnBanditParty(Clan banditClan, Vec2 position, string partyName, List<string> troopNames, int troopCount)
	{
		Hideout hideout = Settlement.All?
			.Where(s => s.IsHideout && s.Hideout != null && s.OwnerClan == banditClan)
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

	private void ApplyEquipmentOverrides(Hero hero, SpawnNpcEquipment eq)
	{
		int tier = eq.Tier.HasValue ? Math.Max(0, Math.Min(eq.Tier.Value, 6)) : -1;
		TryEquipSlot(hero, EquipmentIndex.Weapon0, eq.Weapon, tier);
		TryEquipSlot(hero, EquipmentIndex.Weapon1, eq.Shield, tier);
		TryEquipSlot(hero, EquipmentIndex.Head, eq.Head, tier);
		TryEquipSlot(hero, EquipmentIndex.Body, eq.Body, tier);
		TryEquipSlot(hero, EquipmentIndex.Cape, eq.Cape, tier);
		TryEquipSlot(hero, EquipmentIndex.Gloves, eq.Gloves, tier);
		TryEquipSlot(hero, EquipmentIndex.Leg, eq.Legs, tier);
		TryEquipSlot(hero, EquipmentIndex.Horse, eq.Horse, tier);
	}

	private void TryEquipSlot(Hero hero, EquipmentIndex slot, string itemName, int preferredTier)
	{
		if (string.IsNullOrWhiteSpace(itemName))
			return;

		ItemObject item = FindItemWithTier(itemName, preferredTier);
		if (item == null)
		{
			_log($"[NPC_SPAWN] Could not resolve equipment '{itemName}' for slot {slot}");
			return;
		}

		hero.BattleEquipment[slot] = new EquipmentElement(item);
		_log($"[NPC_SPAWN] Equipped '{item.Name}' (tier {(int)item.Tier}) in {slot}");
	}

	private ItemObject FindItemWithTier(string itemName, int preferredTier)
	{
		ItemObject bestMatch = ItemMentionParser.FindBestItemMatch(itemName);
		if (bestMatch == null || preferredTier < 0)
			return bestMatch;

		ItemObject.ItemTiers targetTier = (ItemObject.ItemTiers)Math.Min(preferredTier, 5);
		if (bestMatch.Tier == targetTier)
			return bestMatch;

		ItemObject tieredMatch = Items.All?
			.Where(i => i.Type == bestMatch.Type && i.Tier == targetTier
				&& i.Culture == bestMatch.Culture)
			.OrderBy(i => i.Name != null && bestMatch.Name != null
				? LevenshteinLike(i.Name.ToString(), bestMatch.Name.ToString())
				: int.MaxValue)
			.FirstOrDefault();

		if (tieredMatch != null)
			return tieredMatch;

		tieredMatch = Items.All?
			.Where(i => i.Type == bestMatch.Type && i.Tier == targetTier)
			.OrderBy(i => i.Name != null && bestMatch.Name != null
				? LevenshteinLike(i.Name.ToString(), bestMatch.Name.ToString())
				: int.MaxValue)
			.FirstOrDefault();

		return tieredMatch ?? bestMatch;
	}

	private static int LevenshteinLike(string a, string b)
	{
		string na = a.ToLowerInvariant();
		string nb = b.ToLowerInvariant();
		int shared = na.Split(' ').Count(w => nb.Contains(w));
		return -shared;
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
			!s.IsHideout &&
			s.Name != null && string.Equals(s.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
		if (exact != null)
			return exact;

		Settlement contains = Settlement.All?.FirstOrDefault(s =>
			!s.IsHideout &&
			s.Name != null && s.Name.ToString().ToLowerInvariant().Contains(normalized));
		if (contains != null)
			return contains;

		Settlement idMatch = Settlement.All?.FirstOrDefault(s =>
			!s.IsHideout &&
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
					bool isFriendly = match.MapFaction != null && !match.MapFaction.IsAtWarWith(playerFaction);
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
				return Clan.BanditFactions?.FirstOrDefault();

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
		return ValidClanOrFallback(settlement.OwnerClan) ?? Clan.PlayerClan;
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
			!c.IsEliminated &&
			c.Name != null && string.Equals(c.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
		if (exact != null)
			return exact;

		Kingdom kingdom = Kingdom.All?.FirstOrDefault(k =>
			!k.IsEliminated &&
			k.Name != null && string.Equals(k.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
		if (kingdom?.RulingClan != null)
			return kingdom.RulingClan;

		Clan contains = Clan.All?.FirstOrDefault(c =>
			!c.IsEliminated &&
			c.Name != null && c.Name.ToString().ToLowerInvariant().Contains(normalized));
		if (contains != null)
			return contains;

		Kingdom kingdomContains = Kingdom.All?.FirstOrDefault(k =>
			!k.IsEliminated &&
			k.Name != null && k.Name.ToString().ToLowerInvariant().Contains(normalized));
		if (kingdomContains?.RulingClan != null)
			return kingdomContains.RulingClan;

		return null;
	}

	private CharacterObject ResolveTemplate(string cultureName, string occupationName, bool? isFemale, Settlement settlement)
	{
		CultureObject culture = ResolveCulture(cultureName, settlement);
		Occupation occupation = ParseOccupation(occupationName);

		CharacterObject template = Campaign.Current?.Models?.HeroCreationModel
			?.GetRandomTemplateByOccupation(occupation, settlement);

		if (template != null && isFemale.HasValue && template.IsFemale != isFemale.Value)
			template = null;

		bool needsCulturalMatch = culture != null && (template == null || template.Culture != culture);
		if (needsCulturalMatch)
		{
			CharacterObject culturalMatch = CharacterObject.All?
				.Where(c => !c.IsHero && c.Occupation == occupation && c.Culture == culture
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

	private static bool WantsParty(SpawnNpcData data)
	{
		return !string.IsNullOrWhiteSpace(data.PartyName) || (data.PartySize.HasValue && data.PartySize.Value > 0);
	}

	private SpawnResult Fail(string error)
	{
		_log($"[NPC_SPAWN] {error}");
		return new SpawnResult { Error = error };
	}
}
