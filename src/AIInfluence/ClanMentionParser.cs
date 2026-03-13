using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public static class ClanMentionParser
{
	public const int DefaultMessagesToScan = 4;

	private static readonly object CacheLock = new object();

	private static List<(string NormalizedAlias, Clan Clan)> _normalizedAliases;

	public static IReadOnlyList<Clan> GetMentionedClans(IEnumerable<string> conversationHistory, int lastMessageCount = 4)
	{
		if (conversationHistory == null)
		{
			return Array.Empty<Clan>();
		}
		List<string> list = conversationHistory.Where((string message) => !string.IsNullOrWhiteSpace(message)).ToList();
		if (list.Count == 0)
		{
			return Array.Empty<Clan>();
		}
		EnsureLookup();
		List<Clan> list2 = new List<Clan>();
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
				if (normalizedAlias.NormalizedAlias.Length >= 3 && IsApproximateMatch(array, normalizedAlias.NormalizedAlias) && !list2.Contains(normalizedAlias.Clan))
				{
					list2.Add(normalizedAlias.Clan);
				}
			}
		}
		return list2.Where((Clan clan) => !ShouldIgnoreClan(clan)).ToList();
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
			_normalizedAliases = new List<(string, Clan)>();
			foreach (Clan item in (List<Clan>)(object)Clan.All)
			{
				if (ShouldIgnoreClan(item))
				{
					continue;
				}
				string text = ((object)item.Name)?.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = NormalizeText(text);
					if (!string.IsNullOrEmpty(text2))
					{
						_normalizedAliases.Add((text2, item));
					}
				}
			}
		}
	}

	private static bool ShouldIgnoreClan(Clan clan)
	{
		if (clan == null)
		{
			return true;
		}
		if (clan.IsMinorFaction || clan.IsBanditFaction)
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
