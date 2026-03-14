using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AIInfluence.Behaviors.RolePlay;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class ItemMentionParser
{
	public const int DefaultMessagesToScan = 6;

	private static readonly object CacheLock = new object();

	private static volatile List<(string NormalizedName, ItemObject Item)> _normalizedItems;

	private static volatile List<(string NormalizedName, CharacterObject Troop)> _normalizedTroops;

	public static string GetMentionedItemsSummary(ItemRoster roster, IEnumerable<string> conversationHistory, int lastMessageCount = 6, bool isPlayerInventory = false, Hero contextHero = null)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		if (roster == null || roster.Count == 0)
		{
			return isPlayerInventory ? "No items available." : "Inventory is empty or no party available.";
		}
		HashSet<ItemObject> hashSet = null;
		bool flag = isPlayerInventory;
		if (isPlayerInventory)
		{
			bool flag2 = ((IEnumerable<ItemRosterElement>)roster).Any(delegate(ItemRosterElement e)
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				int result;
				if ((e).Amount > 0)
				{
					EquipmentElement equipmentElement2 = (e).EquipmentElement;
					ItemObject item3 = (equipmentElement2).Item;
					result = ((((item3 != null) ? item3.ItemComponent : null) is RPItemComponent) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			});
			if (conversationHistory == null || !conversationHistory.Any())
			{
				if (!flag2)
				{
					return "No items mentioned yet.";
				}
				hashSet = new HashSet<ItemObject>();
			}
			else
			{
				hashSet = GetMentionedItems(conversationHistory, lastMessageCount);
				if (hashSet.Count == 0 && !flag2)
				{
					return "No items mentioned yet.";
				}
			}
		}
		Settlement val = null;
		if (contextHero != null)
		{
			object obj = contextHero.CurrentSettlement;
			if (obj == null)
			{
				MobileParty partyBelongedTo = contextHero.PartyBelongedTo;
				obj = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
			}
			val = (Settlement)obj;
		}
		else if (Hero.MainHero != null)
		{
			object obj2 = Hero.MainHero.CurrentSettlement;
			if (obj2 == null)
			{
				MobileParty partyBelongedTo2 = Hero.MainHero.PartyBelongedTo;
				obj2 = ((partyBelongedTo2 != null) ? partyBelongedTo2.CurrentSettlement : null);
			}
			val = (Settlement)obj2;
		}
		StringBuilder stringBuilder = new StringBuilder();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		foreach (ItemRosterElement item4 in roster)
		{
			ItemRosterElement current = item4;
			if ((current).Amount <= 0)
			{
				continue;
			}
			EquipmentElement equipmentElement = (current).EquipmentElement;
			ItemObject item = (equipmentElement).Item;
			if (item == null)
			{
				continue;
			}
			bool flag3 = item.ItemComponent is RPItemComponent;
			if (flag && !flag3 && (hashSet == null || !hashSet.Contains(item)))
			{
				continue;
			}
			string item2;
			if (flag3)
			{
				string text = ((!(item.ItemComponent is RPItemComponent rPItemComponent)) ? null : ((object)rPItemComponent.Description)?.ToString()) ?? "";
				item2 = (string.IsNullOrEmpty(text) ? $"{item.Name} (id:{((MBObjectBase)item).StringId}): {(current).Amount}" : $"{item.Name} (id:{((MBObjectBase)item).StringId}): {(current).Amount} - Description: {text}");
			}
			else
			{
				int num = item.Value;
				bool flag4 = false;
				if (val != null)
				{
					try
					{
						if (val.IsTown && val.Town != null)
						{
							num = ((SettlementComponent)val.Town).GetItemPrice(item, (MobileParty)null, false);
							flag4 = true;
						}
						else if (val.IsVillage && val.Village != null)
						{
							num = ((SettlementComponent)val.Village).GetItemPrice(item, (MobileParty)null, false);
							flag4 = true;
						}
					}
					catch
					{
						num = item.Value;
					}
				}
				string text2 = (flag4 ? "avg market price" : "base value");
				item2 = $"{item.Name} (id:{((MBObjectBase)item).StringId}): {(current).Amount} (approx. {num} gold each)";
			}
			if (item.IsFood)
			{
				list.Add(item2);
			}
			else if (item.IsTradeGood || item.IsAnimal)
			{
				if (item.IsMountable)
				{
					list3.Add(item2);
				}
				else
				{
					list2.Add(item2);
				}
			}
			else if (item.IsMountable)
			{
				list3.Add(item2);
			}
			else
			{
				list4.Add(item2);
			}
		}
		if (list.Any())
		{
			stringBuilder.AppendLine("  - Food: " + string.Join(", ", list));
		}
		if (list2.Any())
		{
			stringBuilder.AppendLine("  - Goods: " + string.Join(", ", list2));
		}
		if (list3.Any())
		{
			stringBuilder.AppendLine("  - Mounts/Livestock: " + string.Join(", ", list3));
		}
		if (list4.Any())
		{
			stringBuilder.AppendLine("  - Equipment: " + string.Join(", ", list4));
		}
		if (stringBuilder.Length == 0)
		{
			return isPlayerInventory ? "No matching items in inventory." : "Inventory is empty or no party available.";
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	public static HashSet<ItemObject> GetMentionedItems(IEnumerable<string> conversationHistory, int lastMessageCount = 6)
	{
		HashSet<ItemObject> hashSet = new HashSet<ItemObject>();
		if (conversationHistory == null)
		{
			return hashSet;
		}
		List<string> list = conversationHistory.Where((string m) => !string.IsNullOrWhiteSpace(m)).ToList();
		if (list.Count == 0)
		{
			return hashSet;
		}
		EnsureLookup();
		int num = Math.Max(0, list.Count - lastMessageCount);
		for (int num2 = num; num2 < list.Count; num2++)
		{
			string text = NormalizeText(list[num2]);
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				continue;
			}
			foreach (var normalizedItem in _normalizedItems)
			{
				if (IsApproximateMatch(array, normalizedItem.NormalizedName) && !hashSet.Contains(normalizedItem.Item))
				{
					hashSet.Add(normalizedItem.Item);
				}
			}
		}
		return hashSet;
	}

	private static void EnsureLookup()
	{
		if (_normalizedItems != null)
		{
			return;
		}
		lock (CacheLock)
		{
			if (_normalizedItems != null)
			{
				return;
			}
			var temp = new List<(string, ItemObject)>();
			foreach (ItemObject item in (List<ItemObject>)(object)Items.All)
			{
				if (item == null)
				{
					continue;
				}
				string text = ((object)item.Name)?.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = NormalizeText(text);
					if (!string.IsNullOrEmpty(text2))
					{
						temp.Add((text2, item));
					}
				}
				if (!string.IsNullOrWhiteSpace(((MBObjectBase)item).StringId))
				{
					string text3 = NormalizeText(((MBObjectBase)item).StringId);
					if (!string.IsNullOrEmpty(text3))
					{
						temp.Add((text3, item));
					}
				}
			}
			_normalizedItems = temp;
		}
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

	private static void EnsureTroopLookup()
	{
		if (_normalizedTroops != null)
		{
			return;
		}
		lock (CacheLock)
		{
			if (_normalizedTroops != null)
			{
				return;
			}
			var tempTroops = new List<(string, CharacterObject)>();
			foreach (CharacterObject troop in CharacterObject.All)
			{
				if (troop == null)
				{
					continue;
				}
				string text = ((object)troop.Name)?.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					string normalized = NormalizeText(text);
					if (!string.IsNullOrEmpty(normalized))
					{
						tempTroops.Add((normalized, troop));
					}
				}
				if (!string.IsNullOrWhiteSpace(((MBObjectBase)troop).StringId))
				{
					string normalized2 = NormalizeText(((MBObjectBase)troop).StringId);
					if (!string.IsNullOrEmpty(normalized2))
					{
						tempTroops.Add((normalized2, troop));
					}
				}
			}
			_normalizedTroops = tempTroops;
		}
	}

	public static CharacterObject FindBestTroopMatch(string troopName)
	{
		if (string.IsNullOrWhiteSpace(troopName))
		{
			return null;
		}
		EnsureTroopLookup();
		string normalized = NormalizeText(troopName);
		if (string.IsNullOrEmpty(normalized))
		{
			return null;
		}
		string[] tokens = normalized.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		CharacterObject best = null;
		int bestScore = 0;
		foreach (var (candidateName, troop) in _normalizedTroops)
		{
			int score = ScoreItemMatch(tokens, normalized, candidateName);
			if (score > bestScore)
			{
				bestScore = score;
				best = troop;
			}
		}
		return bestScore > 0 ? best : null;
	}

	public static ItemObject FindBestItemMatch(string itemName)
	{
		if (string.IsNullOrWhiteSpace(itemName))
		{
			return null;
		}
		EnsureLookup();
		string normalized = NormalizeText(itemName);
		if (string.IsNullOrEmpty(normalized))
		{
			return null;
		}
		string[] tokens = normalized.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		ItemObject best = null;
		int bestScore = 0;
		foreach (var (candidateName, item) in _normalizedItems)
		{
			int score = ScoreItemMatch(tokens, normalized, candidateName);
			if (score > bestScore)
			{
				bestScore = score;
				best = item;
			}
		}
		return bestScore > 0 ? best : null;
	}

	private static int ScoreItemMatch(string[] queryTokens, string queryNormalized, string candidateNormalized)
	{
		if (candidateNormalized == queryNormalized)
		{
			return 100;
		}
		if (candidateNormalized.StartsWith(queryNormalized, StringComparison.Ordinal) || queryNormalized.StartsWith(candidateNormalized, StringComparison.Ordinal))
		{
			return 80;
		}
		if (IsApproximateMatch(queryTokens, candidateNormalized))
		{
			return 50;
		}
		return 0;
	}

	private static bool IsApproximateMatch(string[] messageTokens, string normalizedTerm)
	{
		if (messageTokens == null || messageTokens.Length == 0 || string.IsNullOrEmpty(normalizedTerm))
		{
			return false;
		}
		string[] array = normalizedTerm.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in messageTokens)
		{
			if (string.IsNullOrEmpty(text) || text.Length < 3)
			{
				continue;
			}
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (text2.Length < 3)
				{
					continue;
				}
				if (text.Equals(text2, StringComparison.Ordinal))
				{
					return true;
				}
				int num = Math.Min(4, Math.Min(text.Length - 1, text2.Length - 1));
				if (num >= 3)
				{
					string text3 = text.Substring(0, num);
					string value = text2.Substring(0, num);
					if (text3.Equals(value, StringComparison.Ordinal))
					{
						return true;
					}
				}
				if (text.Length >= 5 && text2.Length >= 5 && (text.StartsWith(text2, StringComparison.Ordinal) || text2.StartsWith(text, StringComparison.Ordinal)))
				{
					return true;
				}
			}
		}
		return false;
	}
}
