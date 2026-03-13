using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class NearbyPartyInfoProvider
{
	public const float DefaultDetectionRadius = 10f;

	private const int DefaultMaxEntries = 6;

	public static IReadOnlyList<string> GetNearbyPartySummaries(Hero referenceHero, float radius = 10f, int maxEntries = 6, IEnumerable<MobileParty> additionalPartiesToExclude = null)
	{
		if (referenceHero == null)
		{
			return Array.Empty<string>();
		}
		Vec2? position = GetReferencePosition(referenceHero);
		if (!position.HasValue)
		{
			return Array.Empty<string>();
		}
		MobileParty partyBelongedTo = referenceHero.PartyBelongedTo;
		radius = Math.Max(0.5f, radius);
		maxEntries = Math.Max(1, maxEntries);
		HashSet<MobileParty> excludedParties = new HashSet<MobileParty>();
		if (partyBelongedTo != null)
		{
			excludedParties.Add(partyBelongedTo);
		}
		if (additionalPartiesToExclude != null)
		{
			foreach (MobileParty item in additionalPartiesToExclude)
			{
				if (item != null)
				{
					excludedParties.Add(item);
				}
			}
		}
		return (from entry in (from entry in ((IEnumerable<MobileParty>)MobileParty.All).Where(delegate(MobileParty party)
				{
					//IL_002a: Unknown result type (might be due to invalid IL or missing references)
					//IL_002f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0038: Unknown result type (might be due to invalid IL or missing references)
					int result;
					if (party != null && !excludedParties.Contains(party) && !party.IsDisbanding && !party.IsGarrison && !party.IsMilitia)
					{
						Vec2 position2D = party.GetPosition2D();
						result = ((((Vec2)(ref position2D)).Distance(position.Value) <= radius) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				}).Select(delegate(MobileParty party)
				{
					//IL_0002: Unknown result type (might be due to invalid IL or missing references)
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_0010: Unknown result type (might be due to invalid IL or missing references)
					Vec2 position2D = party.GetPosition2D();
					return new
					{
						Party = party,
						Distance = ((Vec2)(ref position2D)).Distance(position.Value)
					};
				})
				orderby entry.Distance
				select entry).Take(maxEntries)
			select BuildSummary(entry.Party, entry.Distance, referenceHero) into summary
			where !string.IsNullOrEmpty(summary)
			select summary).ToList();
	}

	private static Vec2? GetReferencePosition(Hero hero)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((hero != null) ? hero.PartyBelongedTo : null) != null)
			{
				return hero.PartyBelongedTo.GetPosition2D();
			}
			if (((hero != null) ? hero.CurrentSettlement : null) != null)
			{
				return hero.CurrentSettlement.GetPosition2D();
			}
		}
		catch
		{
		}
		return null;
	}

	private static string BuildSummary(MobileParty party, float distance, Hero referenceHero)
	{
		if (party == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string text = ((object)party.Name)?.ToString() ?? "Unnamed party";
		string text2 = ((MBObjectBase)party).StringId ?? "unknown";
		stringBuilder.Append(text + " (id:" + text2 + ")");
		string relationInfo = GetRelationInfo(party, referenceHero);
		if (!string.IsNullOrEmpty(relationInfo))
		{
			stringBuilder.Append(", STATUS: " + relationInfo);
		}
		string partyCategory = GetPartyCategory(party);
		if (!string.IsNullOrEmpty(partyCategory))
		{
			stringBuilder.Append(", type: " + partyCategory);
		}
		IFaction mapFaction = party.MapFaction;
		Clan val;
		List<string> list;
		Kingdom val3;
		if (mapFaction != null)
		{
			val = null;
			if (party.LeaderHero != null && party.LeaderHero.Clan != null)
			{
				val = party.LeaderHero.Clan;
			}
			else
			{
				Clan val2 = (Clan)(object)((mapFaction is Clan) ? mapFaction : null);
				if (val2 != null)
				{
					val = val2;
				}
			}
			list = new List<string>();
			if (val != null)
			{
				list.Add($"clan: {val.Name} (id:{((MBObjectBase)val).StringId})");
			}
			val3 = null;
			if (mapFaction.IsKingdomFaction)
			{
				Kingdom val4 = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
				if (val4 != null)
				{
					val3 = val4;
					goto IL_019b;
				}
			}
			if (val != null && val.Kingdom != null)
			{
				val3 = val.Kingdom;
			}
			goto IL_019b;
		}
		goto IL_0245;
		IL_019b:
		if (val3 != null)
		{
			list.Add($"kingdom: {val3.Name} (id:{((MBObjectBase)val3).StringId})");
		}
		else if (val != null)
		{
			list.Add("kingdom: does not belong to any kingdom");
		}
		else if (!mapFaction.IsKingdomFaction)
		{
			list.Add($"faction: {mapFaction.Name} (id:{mapFaction.StringId})");
		}
		if (list.Any())
		{
			stringBuilder.Append(", " + string.Join(", ", list));
		}
		goto IL_0245;
		IL_0245:
		if (party.LeaderHero != null)
		{
			stringBuilder.Append($", leader: {party.LeaderHero.Name} (id:{((MBObjectBase)party.LeaderHero).StringId})");
		}
		string armyInfo = GetArmyInfo(party);
		if (!string.IsNullOrEmpty(armyInfo))
		{
			stringBuilder.Append(", " + armyInfo);
		}
		string troopEstimate = GetTroopEstimate(party);
		if (!string.IsNullOrEmpty(troopEstimate))
		{
			stringBuilder.Append(", size: " + troopEstimate);
		}
		string partyTargetDescription = GetPartyTargetDescription(party);
		if (!string.IsNullOrEmpty(partyTargetDescription))
		{
			stringBuilder.Append(", target: " + partyTargetDescription);
		}
		stringBuilder.Append($", distance: {distance:F1}");
		return stringBuilder.ToString();
	}

	private static string GetRelationInfo(MobileParty party, Hero referenceHero)
	{
		if (party == null || referenceHero == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		IFaction mapFaction = party.MapFaction;
		IFaction mapFaction2 = referenceHero.MapFaction;
		bool flag = false;
		if (Hero.MainHero != null)
		{
			IFaction mapFaction3 = Hero.MainHero.MapFaction;
			if (mapFaction3 != null && (party == MobileParty.MainParty || (party.LeaderHero != null && party.LeaderHero == Hero.MainHero) || mapFaction == mapFaction3))
			{
				flag = true;
				list.Add("ALLIED TO PLAYER (Same Faction)");
			}
		}
		if (mapFaction != null && mapFaction2 != null)
		{
			if (mapFaction == mapFaction2)
			{
				if (!list.Any((string p) => p.Contains("ALLIED")))
				{
					list.Add("ALLIED (Same Kingdom)");
				}
			}
			else if (FactionManager.IsAtWarAgainstFaction(mapFaction, mapFaction2))
			{
				if (!flag)
				{
					list.Add("**ENEMY** (AT WAR)");
				}
			}
			else if (mapFaction.IsKingdomFaction && mapFaction2.IsKingdomFaction && !list.Any((string p) => p.Contains("ALLIED") || p.Contains("ENEMY")))
			{
				list.Add("NEUTRAL");
			}
		}
		Hero leaderHero = party.LeaderHero;
		if (leaderHero != null && leaderHero != referenceHero)
		{
			if (leaderHero.Clan == referenceHero.Clan)
			{
				list.Add("CLAN MEMBER");
			}
			string detailedRelationship = GetDetailedRelationship(referenceHero, leaderHero);
			if (detailedRelationship != null)
			{
				list.Add("RELATIVE (" + detailedRelationship + ")");
			}
			if (referenceHero.IsFriend(leaderHero))
			{
				list.Add("FRIEND");
			}
			else if (referenceHero.IsEnemy(leaderHero))
			{
				list.Add("PERSONAL ENEMY");
			}
		}
		if (party == MobileParty.MainParty)
		{
			list.Add("PLAYER");
		}
		return list.Any() ? string.Join(", ", list) : null;
	}

	private static string GetDetailedRelationship(Hero observer, Hero target)
	{
		if (observer == null || target == null)
		{
			return null;
		}
		if (observer.Spouse == target)
		{
			return observer.Spouse.IsFemale ? "wife" : "husband";
		}
		if (observer.Father == target)
		{
			return "father";
		}
		if (observer.Mother == target)
		{
			return "mother";
		}
		if (((List<Hero>)(object)observer.Children).Contains(target))
		{
			return target.IsFemale ? "daughter" : "son";
		}
		if (observer.Siblings.Contains(target))
		{
			return target.IsFemale ? "sister" : "brother";
		}
		if (observer.Father != null && observer.Father.Siblings.Contains(target))
		{
			return target.IsFemale ? "paternal aunt" : "paternal uncle";
		}
		if (observer.Mother != null && observer.Mother.Siblings.Contains(target))
		{
			return target.IsFemale ? "maternal aunt" : "maternal uncle";
		}
		foreach (Hero sibling in observer.Siblings)
		{
			if (((List<Hero>)(object)sibling.Children).Contains(target))
			{
				return target.IsFemale ? "niece" : "nephew";
			}
		}
		foreach (Hero sibling2 in observer.Siblings)
		{
			if (sibling2.Spouse == target)
			{
				return sibling2.IsFemale ? "brother-in-law" : "sister-in-law";
			}
		}
		return null;
	}

	private static string GetPartyCategory(MobileParty party)
	{
		if (party == null)
		{
			return null;
		}
		if (party == MobileParty.MainParty)
		{
			return "player party";
		}
		if (party.IsLordParty)
		{
			return "lord warband";
		}
		if (party.IsCaravan)
		{
			return "caravan";
		}
		if (party.IsVillager)
		{
			return "villager convoy";
		}
		if (party.IsBandit)
		{
			return "bandit party";
		}
		if (party.IsMilitia)
		{
			return "militia patrol";
		}
		if (party.IsGarrison)
		{
			return "garrison detachment";
		}
		return "mobile party";
	}

	private static string GetArmyInfo(MobileParty party)
	{
		if (((party != null) ? party.Army : null) == null)
		{
			return "no army";
		}
		Army army = party.Army;
		if (army.LeaderParty == party)
		{
			string text = ((object)army.Name)?.ToString();
			if (!string.IsNullOrWhiteSpace(text))
			{
				return "army leader (" + text + ")";
			}
			return "army leader";
		}
		MobileParty leaderParty = army.LeaderParty;
		object obj;
		if (leaderParty == null)
		{
			obj = null;
		}
		else
		{
			Hero leaderHero = leaderParty.LeaderHero;
			obj = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString());
		}
		string text2 = (string)obj;
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return "army member under " + text2;
		}
		MobileParty leaderParty2 = army.LeaderParty;
		string text3 = ((leaderParty2 == null) ? null : ((object)leaderParty2.Name)?.ToString());
		if (!string.IsNullOrWhiteSpace(text3))
		{
			return "army member under " + text3;
		}
		return "army member";
	}

	private static string GetTroopEstimate(MobileParty party)
	{
		if (((party != null) ? party.MemberRoster : null) == null)
		{
			return null;
		}
		int totalManCount = party.MemberRoster.TotalManCount;
		if (totalManCount <= 0)
		{
			return "almost empty (~0)";
		}
		string arg = ((totalManCount <= 50) ? "small" : ((totalManCount <= 150) ? "medium" : ((totalManCount <= 300) ? "large" : ((totalManCount > 600) ? "massive" : "very large"))));
		return $"{arg} (~{totalManCount})";
	}

	private static string GetPartyTargetDescription(MobileParty party)
	{
		if (party == null)
		{
			return null;
		}
		try
		{
			string directPartyTargetDescription = GetDirectPartyTargetDescription(party);
			if (!string.IsNullOrEmpty(directPartyTargetDescription))
			{
				return directPartyTargetDescription;
			}
			object obj;
			if (party == null)
			{
				obj = null;
			}
			else
			{
				Army army = party.Army;
				obj = ((army != null) ? army.LeaderParty : null);
			}
			if (obj != null && party.Army.LeaderParty != party)
			{
				string directPartyTargetDescription2 = GetDirectPartyTargetDescription(party.Army.LeaderParty);
				if (!string.IsNullOrEmpty(directPartyTargetDescription2))
				{
					Hero leaderHero = party.Army.LeaderParty.LeaderHero;
					if (leaderHero != null)
					{
						return $"army leader objective ({leaderHero.Name}): {directPartyTargetDescription2}";
					}
					return "army leader objective: " + directPartyTargetDescription2;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static string GetDirectPartyTargetDescription(MobileParty party)
	{
		if (party == null)
		{
			return null;
		}
		if (party.SiegeEvent?.BesiegedSettlement != null)
		{
			Settlement besiegedSettlement = party.SiegeEvent.BesiegedSettlement;
			return $"besieging {besiegedSettlement.Name} (id:{((MBObjectBase)besiegedSettlement).StringId})";
		}
		if (party.TargetSettlement != null)
		{
			Settlement targetSettlement = party.TargetSettlement;
			return $"moving to {targetSettlement.Name} (id:{((MBObjectBase)targetSettlement).StringId})";
		}
		if (party.TargetParty != null)
		{
			MobileParty targetParty = party.TargetParty;
			return $"tracking {targetParty.Name} (id:{((MBObjectBase)targetParty).StringId})";
		}
		if (party.MoveTargetParty != null)
		{
			MobileParty moveTargetParty = party.MoveTargetParty;
			return $"moving towards {moveTargetParty.Name} (id:{((MBObjectBase)moveTargetParty).StringId})";
		}
		if (party.ShortTermTargetParty != null)
		{
			MobileParty shortTermTargetParty = party.ShortTermTargetParty;
			return $"pursuing {shortTermTargetParty.Name} (id:{((MBObjectBase)shortTermTargetParty).StringId})";
		}
		return null;
	}
}
