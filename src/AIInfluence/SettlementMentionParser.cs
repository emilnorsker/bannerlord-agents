using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class SettlementMentionParser
{
	public const int DefaultMessagesToScan = 6;

	private static readonly object CacheLock = new object();

	private static List<(string NormalizedAlias, Settlement Settlement)> _normalizedAliases;

	public static IReadOnlyList<string> GetMentionedSettlementSummaries(IEnumerable<string> conversationHistory, int lastMessageCount = 6, Hero npc = null)
	{
		if (conversationHistory == null)
		{
			return Array.Empty<string>();
		}
		List<string> list = conversationHistory.Where((string message) => !string.IsNullOrWhiteSpace(message)).ToList();
		if (list.Count == 0)
		{
			return Array.Empty<string>();
		}
		EnsureLookup();
		List<Settlement> list2 = new List<Settlement>();
		int count = Math.Max(0, list.Count - lastMessageCount);
		List<string> list3 = list.Skip(count).Take(lastMessageCount).ToList();
		for (int num = 0; num < list3.Count; num++)
		{
			string text = list3[num];
			if (text == null || text.Length > 1000)
			{
				continue;
			}
			string text2 = NormalizeText(text);
			if (string.IsNullOrEmpty(text2))
			{
				continue;
			}
			string[] array = (from token in text2.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				where token.Length >= 3
				select token).ToArray();
			if (array.Length == 0)
			{
				continue;
			}
			foreach (var normalizedAlias in _normalizedAliases)
			{
				if (normalizedAlias.NormalizedAlias.Length >= 3 && IsApproximateMatch(array, normalizedAlias.NormalizedAlias) && !list2.Contains(normalizedAlias.Settlement))
				{
					list2.Add(normalizedAlias.Settlement);
				}
			}
		}
		if (list2.Count == 0)
		{
			return Array.Empty<string>();
		}
		return (from settlement in list2
			where !ShouldIgnoreSettlement(settlement)
			select BuildSummary(settlement, npc) into summary
			where !string.IsNullOrEmpty(summary)
			select summary).ToList();
	}

	private static void EnsureLookup()
	{
		if (_normalizedAliases != null)
		{
			return;
		}
		lock (CacheLock)
		{
			if (_normalizedAliases != null)
			{
				return;
			}
			_normalizedAliases = new List<(string, Settlement)>();
			foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
			{
				if (ShouldIgnoreSettlement(item))
				{
					continue;
				}
				foreach (string alias in GetAliases(item))
				{
					string text = NormalizeText(alias);
					if (!string.IsNullOrEmpty(text))
					{
						_normalizedAliases.Add((text, item));
					}
				}
			}
		}
	}

	private static IEnumerable<string> GetAliases(Settlement settlement)
	{
		if (settlement == null)
		{
			yield break;
		}
		string nameText = ((object)settlement.Name)?.ToString();
		if (string.IsNullOrWhiteSpace(nameText))
		{
			yield break;
		}
		if (settlement.IsCastle)
		{
			string[] parts = nameText.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length >= 2)
			{
				string withoutFirst = string.Join(" ", parts.Skip(1));
				if (!string.IsNullOrWhiteSpace(withoutFirst))
				{
					yield return withoutFirst;
				}
			}
			else
			{
				yield return nameText;
			}
		}
		else
		{
			yield return nameText;
		}
	}

	private static string BuildSummary(Settlement settlement, Hero npc = null)
	{
		if (settlement == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string text = ((object)settlement.Name)?.ToString() ?? "Unknown settlement";
		string text2 = ((MBObjectBase)settlement).StringId ?? "unknown";
		stringBuilder.Append(text + " (id:" + text2 + ") - ");
		string value = (settlement.IsTown ? "town" : (settlement.IsCastle ? "castle" : (settlement.IsVillage ? "village" : "location")));
		stringBuilder.Append(value);
		CultureObject culture = settlement.Culture;
		object obj = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString());
		if (obj == null)
		{
			CultureObject culture2 = settlement.Culture;
			obj = ((culture2 != null) ? ((MBObjectBase)culture2).StringId : null);
		}
		string text3 = (string)obj;
		if (!string.IsNullOrWhiteSpace(text3))
		{
			stringBuilder.Append(", culture: " + text3);
		}
		if (settlement.OwnerClan != null && npc != null && npc.MapFaction != null && settlement.MapFaction != null && npc.MapFaction == settlement.MapFaction)
		{
			stringBuilder.Append($", owner clan: {settlement.OwnerClan.Name} (id:{((MBObjectBase)settlement.OwnerClan).StringId})");
			if (settlement.OwnerClan.Leader != null)
			{
				stringBuilder.Append($", ruler: {settlement.OwnerClan.Leader.Name} (id:{((MBObjectBase)settlement.OwnerClan.Leader).StringId})");
			}
		}
		if (settlement.MapFaction != null)
		{
			stringBuilder.Append($", faction: {settlement.MapFaction.Name} (id:{settlement.MapFaction.StringId})");
		}
		List<string> settlementNotables = GetSettlementNotables(settlement);
		if (settlementNotables != null && settlementNotables.Count > 0)
		{
			stringBuilder.Append(". Notables: " + string.Join(", ", settlementNotables));
		}
		return stringBuilder.ToString();
	}

	private static List<string> GetSettlementNotables(Settlement settlement)
	{
		if (settlement == null)
		{
			return null;
		}
		try
		{
			MBReadOnlyList<Hero> notables = settlement.Notables;
			if (notables == null || ((List<Hero>)(object)notables).Count == 0)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (Hero item in (List<Hero>)(object)notables)
			{
				if (item != null && item.IsAlive)
				{
					string text = ((object)item.Name)?.ToString();
					string stringId = ((MBObjectBase)item).StringId;
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(stringId))
					{
						list.Add(text + " (id:" + stringId + ")");
					}
				}
			}
			return (list.Count > 0) ? list : null;
		}
		catch
		{
			return null;
		}
	}

	private static bool ShouldIgnoreSettlement(Settlement settlement)
	{
		if (settlement == null)
		{
			return true;
		}
		bool flag = false;
		try
		{
			flag = settlement.IsHideout;
		}
		catch
		{
		}
		if (flag)
		{
			return true;
		}
		string stringId = ((MBObjectBase)settlement).StringId;
		if (!string.IsNullOrWhiteSpace(stringId) && stringId.IndexOf("hideout", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		return false;
	}

	private static string NormalizeText(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		string text2 = text.Normalize(NormalizationForm.FormD);
		StringBuilder stringBuilder = new StringBuilder(text2.Length);
		char c = '\0';
		string text3 = text2;
		foreach (char c2 in text3)
		{
			UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c2);
			if (unicodeCategory != UnicodeCategory.NonSpacingMark)
			{
				if (char.IsLetterOrDigit(c2))
				{
					char c3 = char.ToLowerInvariant(c2);
					stringBuilder.Append(c3);
					c = c3;
				}
				else if (c != ' ')
				{
					stringBuilder.Append(' ');
					c = ' ';
				}
			}
		}
		return stringBuilder.ToString().Trim();
	}

	private static bool IsApproximateMatch(string[] messageTokens, string normalizedTerm)
	{
		if (messageTokens == null || messageTokens.Length == 0 || string.IsNullOrEmpty(normalizedTerm))
		{
			return false;
		}
		foreach (string text in messageTokens)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (text.Equals(normalizedTerm, StringComparison.Ordinal))
				{
					return true;
				}
				int num = Math.Min(text.Length, normalizedTerm.Length);
				if (num >= 4 && (text.StartsWith(normalizedTerm, StringComparison.Ordinal) || normalizedTerm.StartsWith(text, StringComparison.Ordinal)))
				{
					return true;
				}
				if (num >= 4 && AreTokensClose(text, normalizedTerm, 1))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool AreTokensClose(string s1, string s2, int maxEdits)
	{
		if ((object)s1 == s2)
		{
			return true;
		}
		if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
		{
			return false;
		}
		int length = s1.Length;
		int length2 = s2.Length;
		if (Math.Abs(length - length2) > maxEdits)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (num < length && num2 < length2)
		{
			if (s1[num] == s2[num2])
			{
				num++;
				num2++;
				continue;
			}
			num3++;
			if (num3 > maxEdits)
			{
				return false;
			}
			if (length > length2)
			{
				num++;
				continue;
			}
			if (length2 > length)
			{
				num2++;
				continue;
			}
			num++;
			num2++;
		}
		num3 += length - num + (length2 - num2);
		return num3 <= maxEdits;
	}
}
