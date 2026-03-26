using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace AIInfluence;

public static class QuestSpawnTroopFill
{
	public static void Apply(MobileParty party, SpawnPartyData data, CultureObject fallbackCulture)
	{
		if (party == null || data == null)
			return;
		int totalCount = Math.Max(0, Math.Min(data.PartySize ?? 0, 5000));
		int currentMemberCount = party.MemberRoster.TotalManCount;
		if (currentMemberCount >= totalCount)
			return;
		totalCount -= currentMemberCount;
		List<CharacterObject> resolved = new List<CharacterObject>();
		if (data.PartyTroops != null)
		{
			foreach (string troopQueryName in data.PartyTroops.Where(token => !string.IsNullOrWhiteSpace(token)).Distinct(StringComparer.OrdinalIgnoreCase))
			{
				CharacterObject troop = ItemMentionParser.FindBestTroopMatch(troopQueryName);
				if (troop != null)
					resolved.Add(troop);
			}
		}
		if (resolved.Count == 0 && fallbackCulture?.BasicTroop != null)
			resolved.Add(fallbackCulture.BasicTroop);
		if (resolved.Count == 0)
			return;
		int perType = totalCount / resolved.Count;
		int remainder = totalCount % resolved.Count;
		for (int i = 0; i < resolved.Count; i++)
		{
			int count = perType + (i < remainder ? 1 : 0);
			if (count > 0)
				party.MemberRoster.AddToCounts(resolved[i], count, false, 0, 0, true, -1);
		}
	}
}
