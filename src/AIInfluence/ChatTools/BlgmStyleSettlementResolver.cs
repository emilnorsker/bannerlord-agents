using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.ChatTools;

/// <summary>
/// Resolves a settlement from a name/ID search plus optional filters, mirroring BLGM
/// <c>gm.query.settlement</c> AND semantics (see Bannerlord.GameMaster wiki API-Query-Settlement-settlement).
/// </summary>
public static class BlgmStyleSettlementResolver
{
	public static string TryResolve(string search, IList<string> filterTokens, out Settlement settlement)
	{
		settlement = null;
		string trimmed = search?.Trim();
		if (string.IsNullOrEmpty(trimmed))
			return JsonConvert.SerializeObject(new { error = "missing", message = "settlement_name is empty" });

		var tokens = (filterTokens ?? Array.Empty<string>())
			.Where(t => !string.IsNullOrWhiteSpace(t))
			.Select(t => t.Trim().ToLowerInvariant())
			.ToList();

		IEnumerable<Settlement> candidates = Settlement.All ?? Enumerable.Empty<Settlement>();
		candidates = candidates.Where(s => s != null);
		foreach (string tok in tokens)
		{
			candidates = candidates.Where(s => MatchesKeyword(s, tok));
		}

		var list = candidates.ToList();
		string q = trimmed.ToLowerInvariant();
		List<Settlement> matched = list
			.Where(s =>
				string.Equals(((MBObjectBase)s).StringId, trimmed, StringComparison.OrdinalIgnoreCase)
				|| (s.Name != null && string.Equals(s.Name.ToString(), trimmed, StringComparison.OrdinalIgnoreCase)))
			.ToList();
		if (matched.Count == 0)
		{
			matched = list
				.Where(s => s.Name != null && s.Name.ToString().IndexOf(trimmed, StringComparison.OrdinalIgnoreCase) >= 0)
				.ToList();
		}

		if (matched.Count == 0)
			return JsonConvert.SerializeObject(new { error = "not_found", search = trimmed, filters = tokens });

		if (matched.Count > 1)
		{
			var options = matched
				.Take(12)
				.Select(s => new { string_id = ((MBObjectBase)s).StringId, name = s.Name?.ToString() ?? "" })
				.ToList();
			return JsonConvert.SerializeObject(new { error = "ambiguous", search = trimmed, matches = options });
		}

		settlement = matched[0];
		return null;
	}

	private static bool MatchesKeyword(Settlement s, string tok)
	{
		switch (tok)
		{
		case "town":
		case "city":
			return s.IsTown;
		case "castle":
			return s.IsCastle;
		case "village":
			return s.IsVillage;
		case "hideout":
			return s.IsHideout;
		case "player":
		case "playerowned":
			return s.OwnerClan == Clan.PlayerClan;
		case "besieged":
		case "siege":
			return s.SiegeEvent != null;
		case "raided":
			return s.IsVillage && s.Village != null && (int)s.Village.VillageState == 1;
		case "empire":
		case "vlandia":
		case "sturgia":
		case "aserai":
		case "khuzait":
		case "battania":
		case "nord":
			return s.Culture != null && string.Equals(s.Culture.StringId, tok, StringComparison.OrdinalIgnoreCase);
		case "low":
		case "lowprosperity":
			return HasLowProsperity(s);
		case "medium":
		case "mediumprosperity":
			return HasMediumProsperity(s);
		case "high":
		case "highprosperity":
			return HasHighProsperity(s);
		default:
			return true;
		}
	}

	private static bool HasLowProsperity(Settlement s)
	{
		if (s.Town != null)
			return s.Town.Prosperity < 2000f;
		if (s.Village != null)
			return s.Village.Hearth < 200f;
		return false;
	}

	private static bool HasHighProsperity(Settlement s)
	{
		if (s.Town != null)
			return s.Town.Prosperity > 5000f;
		if (s.Village != null)
			return s.Village.Hearth > 500f;
		return false;
	}

	private static bool HasMediumProsperity(Settlement s)
	{
		if (s.Town != null)
		{
			float p = s.Town.Prosperity;
			return p >= 2000f && p <= 5000f;
		}
		if (s.Village != null)
		{
			float h = s.Village.Hearth;
			return h >= 200f && h <= 500f;
		}
		return false;
	}
}
